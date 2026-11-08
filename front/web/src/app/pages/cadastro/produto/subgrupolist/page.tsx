// app/produtos/page.tsx
'use client'

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";


const AC_CD_FISCAL = 4211;


/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";

import { modulefiscal } from '@/api/m0040_fiscal/modulefiscal';
import { moduleProduto
      , moduleProdutoCategoria
      , TpProdutoDepartamento
      , TpProdutoSecao
      , TpProdutoSubGrupoList } from '@/api/m0020_produto/moduleproduto';

    let myModuleFiscal : modulefiscal
    let myModuleProdutoCategoria : moduleProdutoCategoria    
    let myModuleProduto : moduleProduto
    

export default function ProdutoSubGrupo() {

  /* USER */
  const { user } = useAuth();
  const [ActionStatus, setActionStatus] = useState<number>(0);
    
  /* STATES LISTS */
  const [ProdutoDepartamento, setProdutoDepartamento] = useState<TpProdutoDepartamento[]>([]);
  const [ProdutosSecao, setProdutosSecao] = useState<TpProdutoSecao[]>([]);
  const [CBenefList, setCBenefList] = useState<any>([]); 
  const [CBenefCstList, setCBenefCstList] = useState<any>([]); 

  const [DepartamentoFilterID, setDepartamentoFilterId] = useState(0);
  const [SecaoFilterID, setSecaoFilterId] = useState(0);
  const [fc_cbenef_cdAssociar, setfc_cbenef_cdAssociar] = useState<string>('');


  const [fc_cbenef_cdFilter, setfc_cbenef_cdFilter] = useState<string>('');
  const [comCbenefFilter, setcomCbenefFilter] = useState<boolean>(false);

  const [List, setList] = useState<TpProdutoSubGrupoList[]>([]);

  useEffect(() => {
    myModuleFiscal = new modulefiscal(user, AC_CD_FISCAL);
    myModuleProdutoCategoria = new moduleProdutoCategoria(user);
    myModuleProduto = new moduleProduto(user);
    
    
    
    const BindingData = async () => {

          //CBENF
           let cbenefList = await myModuleFiscal.getListCbenef({fc_cbenef_bluesoftFilter: 1})
           setCBenefList(cbenefList)
          //PRODUTO
          await myModuleProdutoCategoria.getCategoria()
          setProdutoDepartamento( await myModuleProdutoCategoria.getDepartamento() );
          await FiltrarSecao(0)
          await BindingList()

  };
  
  BindingData();
}, []);



  const changeDepartamento = async (prd_cddepartamento: number) => { 
      setDepartamentoFilterId(prd_cddepartamento)
      await FiltrarSecao(prd_cddepartamento)
  }

  const FiltrarSecao = async (departamentoID: number) => { 
    try {
        setActionStatus(1)
        await myModuleProdutoCategoria.getSecao(departamentoID)
        setProdutosSecao(myModuleProdutoCategoria.Secao)
        setSecaoFilterId(0)
        clearList()
        setActionStatus(0)

    } catch (e) {
        console.log(`Filtrar Secao Error ${e}`)

  }
}

  const BindingList = async () => { 

    let parametro : any = { 
        fc_cbenef_cd: fc_cbenef_cdFilter,
        prd_cddepartamento: DepartamentoFilterID,
        prs_cdsecao: SecaoFilterID,
        comCbenefFilter: comCbenefFilter? 1 : 0

    }
    setActionStatus(1)
      clearList()
      const response = await myModuleProduto.getSubGrupoList(parametro)
      setList(response)
    setActionStatus(0)

  }

  const clearList = () => {
    setList([])
  }


  const CbenefConsultar = async (cbenef_cd: string) => {


    if (cbenef_cd.trim() === '') {
      setCBenefCstList([])
      return
    }

    let parametro : any = {
        fc_cbenef_cd : cbenef_cd
    }

    setCBenefCstList([])


    let listCBNEFCST = await myModuleFiscal.getListCbenefCst(parametro)
    setCBenefCstList(listCBNEFCST)

    setfc_cbenef_cdAssociar(cbenef_cd)


    
  } 

    const ProcessarAssociacao = async () => {
      let selecionados = List.filter((item: any) => item.selecionado)
      alert(`Itens selecionado ${selecionados.length}`)


          for await (let item of selecionados) {
          let parametro : any = { 
              fc_cbenef_cd: fc_cbenef_cdAssociar,
              prsg_cdsubgrupo: item.prsg_cdsubgrupo
          }
          
          await myModuleProduto.postAssociarCbenefSubGrupo(parametro)
        }
      
      
  }


  return (
    <div className="min-h-screen bg-gray-50 p-6">
      <div className="max-w-7xl mx-auto">
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Produto | Sub Grupo Listagem" >
          <div className="flex space-x-2">
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={BindingList} ActionStatus={ActionStatus}></ButtonPag>
          </div>              
     
        </HeaderMain>
        
        {/* Área de Filtros */}
        <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100 flex space-x-4">
            
                        
            {/* Filtro por Departamento */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Departamento</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                value={DepartamentoFilterID}
                onChange={async (e) => await changeDepartamento(Number(e.target.value))}
                disabled={ProdutoDepartamento.length === 0}
              >
                <option value="">Todos</option>
                {ProdutoDepartamento.map((departamento, index) => (
                  <option key={index} value={departamento.prd_cddepartamento}>{departamento.prd_descricao}</option>
                ))}
              </select>
            </div>
            
            {/* Filtro por Seção */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Seção</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                value={SecaoFilterID}
                onChange={(e) => setSecaoFilterId(Number(e.target.value))}
              >
                <option value="">Todas</option>
                {ProdutosSecao.map((section, index) => (
                  <option key={index} value={section.prs_cdsecao}>{section.prs_descricao}</option>
                ))}
              </select>
            </div>
            
            
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Com Código de Benefício Fiscal</label>
              <input
                type="checkbox"
                className="h-4 w-4 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
                checked={comCbenefFilter}
                onChange={(e) => setcomCbenefFilter(e.target.checked)}
              />
            </div>


            {/* Filtro por Código */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Código do Benefício Fiscal</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por código"
                value={fc_cbenef_cdFilter}
                disabled={comCbenefFilter === false}
                onChange={(e) => setfc_cbenef_cdFilter(e.target.value)}
              />
            </div>
        
   
        </div>
        
        {/* Grid de Produtos */}
        <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
          <div className="max-h-[500px] overflow-y-auto">
            <table className="min-w-full divide-y divide-gray-200">
                <thead className="bg-gray-100 sticky top-0 z-10">
                  {/* Primeira linha do cabeçalho - Grupos principais */}
                  <tr>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Seção</th>
                    <th className="w-8 px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">S</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Cd</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Descrição</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">CBENEF Padrão</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Qtde de Prods</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Qtde cst 020</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Qtde cst 040</th>

                  </tr>
            
                </thead>
              <tbody className="bg-white divide-y divide-gray-200">
                {List.length > 0 ? (
                  List.map((item: TpProdutoSubGrupoList) => (
                    <tr key={item.fc_cbenef_cd} className="hover:bg-gray-50">
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 ">{item.prs_descricao}</td>
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 ">
                        <input
                          type="checkbox"
                          className="h-4 w-4 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
                          checked={item.selecionado}
                          onChange={() => item.selecionado = !item.selecionado}
                        />
                      </td>
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 ">{item.prsg_cdsubgrupo}</td>
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 ">{item.prsg_descricao}</td>
                      <td className="px-1 text-sm text-gray-700 ">
                        
                        {item.fc_cbenef_cd ? 
                        <div className='flex flex-col text-gray-700' >
                         
                         <label className='text-[14px]'>Cbenef {item.fc_cbenef_cd} </label>
                         <label className='text-[16px]'>Objetivo {item.fc_cbenef_objetivo} </label>

                        </div>
                        :
                        ""  
                      }

                      </td>
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 ">{item.qtdeproduto}</td>
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 ">{item.cst_20}</td>
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 ">{item.cst_40}</td>


                  </tr>
                  ))
                ) : (
                  <tr>
                    <td colSpan={6} className="px-6 py-4 text-center text-sm text-gray-500">
                      Nenhum registro encontrado com os filtros aplicados.
                    </td>
                  </tr>
                )}
              </tbody>
            </table>

          </div>

        </div>

          <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
         
            <div className='flex space-x-4'> 
              <label className="block text-sm font-medium text-gray-700 mb-1">Associar CBENEF</label>
              <select
                className="mt-2 w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                onChange={async (e) => await CbenefConsultar(e.target.value)}
                value={fc_cbenef_cdAssociar}
                > 

                {CBenefList.map((cbenef: any, index: number) => (
                  <option key={cbenef.fc_cbenef_cd} value={cbenef.fc_cbenef_cd}>{cbenef.fc_cbenef_cd} - {cbenef.fc_cbenef_objetivo}</option>
                ))}

              </select>

              <ButtonPag TypeButton="_BUTTON_HEADER" label="Salvar" TypeIcon="_SALVAR" title="Salvar x" type="button" onClick={ProcessarAssociacao} ></ButtonPag>
            </div>
            <div> 
              {CBenefCstList.length > 0 &&
                <div className='mt-4 p-4 bg-purple-50 border border-purple-200 rounded-md'>
                  <h4 className='text-sm font-medium text-purple-700 mb-2'>CBENEF CSTs Associados</h4>
                  <ul className='list-disc list-inside text-sm text-gray-700'>
                    {CBenefCstList.map((cbenefCst: any, index: number) => (
                      <li key={index}>CST: {cbenefCst.icms_codigo_tributacao}</li>
                    ))}
                  </ul>
                </div>
              }

            </div>
          </div>

          <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
            <div className="flex justify-between items-center">
              <h3 className="text-mg font-medium text-gray-500">Total de Registros</h3>
              <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
                {List.length} registro{List.length !== 1 ? 's' : ''}
              </span>
            </div>
           
          </div>

      </div>
    </div>
  );
}





