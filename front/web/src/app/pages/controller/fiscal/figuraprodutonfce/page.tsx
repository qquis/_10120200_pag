// app/produtos/page.tsx
'use client'

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";


/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";

import { modulefiscal, modulefiscalConst } from '@/api/m0040_fiscal/modulefiscal';

import ExcelExporter from './figuraprodutonfce_export';



import {moduleProduto
      , moduleProdutoCategoria
      , TpProduto
      , TpProdutoCategoria
      , TpProdutoDepartamento
      , TpProdutoGrupo
      , TpProdutoSecao
      , TpProdutoSubGrupo
    
    } from '@/api/m0020_produto/moduleproduto'


    let myModuleFiscal : modulefiscal
    let myModuleProdutoCategoria : moduleProdutoCategoria

export default function FiguraFiscalProdutoList() {







  /* USER */
  const { user } = useAuth();
  

    /* MODULES  */

  /* STATES SCREEN */    
    const [ActionStatus, setActionStatus] = useState<number>(0);

  
  
    /* STATES FILTERS */
    const [apenasunitario, setApenasUnitario] = useState<boolean>(true)
    const [descricaoFilter, setDescricaoFilter] = useState('');
    const [descricaoFiscalFilter, setDescricaoFiscalFilter] = useState('');
    const [pr_cdprodutoFilter, setpr_cdProdutoFilter] = useState('');
    const [prb_cdprodutobluesoftFilter, setPrb_cdprodutobluesoftFilter] = useState('');
    const [DepartamentoFilterID, setDepartamentoFilterId] = useState(0);
    const [SecaoFilterID, setSecaoFilterId] = useState(0);
    const [filtrar_vendaexterna, setfiltrar_vendaexterna] = useState('');
    const [filtraDataCadastro, setfiltraDataCadastro] = useState(false);
    const [dataCadastroInicial, setdataCadastroInicial] = useState(() => {
      const today = new Date();
      return today.toISOString().split('T')[0]; // Formato YYYY-MM-DD
    });
    const [dataCadastroFinal, setdataCadastroFinal] = useState(() => {
      const today = new Date();
      return today.toISOString().split('T')[0]; // Formato YYYY-MM-DD
    });
    const [filtrarComMovimentacao, setfiltrarComMovimentacao] = useState(false);
    const [filtrarComMovimentacaoNegativa, setfiltrarComMovimentacaoNegativa] = useState(false);
    const [filtrarComMovimentacaoTipo, setfiltrarComMovimentacaoTipo] = useState('ENTRADA');
    const [filtrarComMovimentacaoNumeroMes, setfiltrarComMovimentacaoNumeroMes] = useState(1);
    const [fornecedor_razao_social, setfornecedor_razao_social] = useState<string>("");

  /* STATES LISTS */
    const [ProdutoDepartamento, setProdutoDepartamento] = useState<TpProdutoDepartamento[]>([]);
    const [ProdutosSecao, setProdutosSecao] = useState<TpProdutoSecao[]>([]);
    
    const [produtosList, setListProduto] = useState<any[]>([]);
    const [filtrar_status_bluesoft, setfiltrar_status_bluesoft] = useState('ATIVO'); 
    const [figurafiscalassociada, setfigurafiscalassociada] = useState("T");
    const [filtrarComRegraNfce, setfiltrarComRegraNfce] = useState("T");
    const [figurafiscal, setfigurafiscal] = useState("");
    const [ncm, setNCM] = useState("");
    const [cest, setCest] = useState("");


    const [nfceProdutoTipoList, setNfceProdutoTipoList] = useState<any[]>([]);
    const [nfceProdutoTipoFilter, setNfceProdutoTipoFilter] = useState(1);


/* EFFECTS */


  useEffect(() => {
      myModuleFiscal = new modulefiscal(user,4211);

      myModuleProdutoCategoria = new moduleProdutoCategoria(user);



      const BindingData = async () => {
        await myModuleProdutoCategoria.getCategoria()
        setProdutoDepartamento( await myModuleProdutoCategoria.getDepartamento() );
        setNfceProdutoTipoList( modulefiscalConst.getregrafiscal_nfce_produto_tipo() );
      
        await FiltrarSecao(0)
      };
    
      BindingData();
}, []);


  const processarProdutos = async () => {
      setActionStatus(1)  
      let numproc = 0
      let nummax = 500
      for (const produto of produtosList) {
          await myModuleFiscal.atualizarCadastroProdutoGeral(produto);
          numproc += 1
          if (numproc >= nummax) {
              break;
          }
      }
      await consultraProdutos();
      setActionStatus(0)  
  }




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
        setActionStatus(0)

    } catch (e) {
        console.log(`Filtrar Secao Error ${e}`)

  }
}

const obterProdutos = async () :Promise<any[]> => {
  let listProduto: any[] = [];
  try { 

    let parametro : any = { 
              pr_descricao : descricaoFilter
            , pr_cdproduto : pr_cdprodutoFilter !== '' ? Number(pr_cdprodutoFilter) : 0
            , prd_cddepartamento : DepartamentoFilterID
            , prs_cdsecao : SecaoFilterID
            , filtrar_status_bluesoft : filtrar_status_bluesoft 
            , filtrar_vendaexterna : filtrar_vendaexterna
            , filter_prb_dt_cadastro : filtraDataCadastro ? 1 : 0
            , filtra_prb_dt_cadastro_ini : user.formatDateToStringYYYMMDD(dataCadastroInicial)
            , filtra_prb_dt_cadastro_fim : user.formatDateToStringYYYMMDD(dataCadastroFinal)
            , filtrar_entrada_saida : filtrarComMovimentacao ? 1 : 0
            , filtrar_entrada_saida_tipo : filtrarComMovimentacaoTipo
            , filtrar_entrada_saida_numero_mes : filtrarComMovimentacaoNumeroMes
            , fornecedor_razao_social: fornecedor_razao_social
            , figurafiscalassociada: figurafiscalassociada
            , figurafiscal: figurafiscal
            , ncm: ncm 
            , cest: cest
            , operacaoVisualizar: ""
            , filtrar_entrada_saida_negativo: filtrarComMovimentacaoNegativa ? 1 : 0
            , prb_descricao_fiscal: descricaoFiscalFilter
            , filtrarComRegraNfce: filtrarComRegraNfce
            , nfce_produto_tipo_cd: nfceProdutoTipoFilter
            , apenasunitario: apenasunitario ? 1 : 0
            , prb_cdprodutobluesoft: prb_cdprodutobluesoftFilter !== '' ? Number(prb_cdprodutobluesoftFilter) : 0
        }
        setActionStatus(1)

        
        const response = await myModuleFiscal.getListfiguranfceproduto(parametro)
        listProduto = response
        setActionStatus(0)


  } catch (e) {
      console.log(`Obter Produtos Error ${e}`)
  }
  finally {
    setActionStatus(0)
    return listProduto;
  }
}


const consultraProdutos = async () => { 

   
    setActionStatus(1)
    setListProduto([])
    
    const response = await obterProdutos()
    setListProduto(response)
    setActionStatus(0)

  }


  const exportToExcel = async () => {
    let listProduto = await obterProdutos()
    if (listProduto.length > 0) {
      ExcelExporter.exportProdutosFiscais(listProduto, user);
    } else { 
      alert("Nenhum produto para exportar.");
    }
     
  };


  return (
    <div className="min-h-screen bg-gray-50 p-6">
      <div className="max-w-7xl mx-auto">
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Produto | Regra Fiscal NFCE" >
          <div className="flex space-x-2">

            <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={consultraProdutos} ActionStatus={ActionStatus}></ButtonPag>
          </div>              
         <ButtonPag 
              TypeButton="_BUTTON_HEADER" 
              label="Exportar Excel" 
              TypeIcon="_PESQUISAR" 
              title="Exportar para Excel" 
              onClick={exportToExcel} 
              ActionStatus={ActionStatus}

            />          
        </HeaderMain>
        
        {/* Área de Filtros */}
        <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
         
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-6 gap-4">


            <div className="lg:col-span-2 flex items-center border rounded p-2">
              <div className="flex items-center gap-2">
                <input
                  type="checkbox"
                  checked={apenasunitario}
                  onChange={(e) => setApenasUnitario(e.target.checked)}
                />
                <label className="text-xs font-medium text-gray-700">Listar apenas unitário</label>
              </div>
            </div>


            {/* Filtro por Descrição */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Descrição</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por descrição"
                value={descricaoFilter}
                onChange={(e) => setDescricaoFilter(e.target.value)}
              />
            </div>

            {/* Filtro por Descrição */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Descrição Fiscal</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por descrição Fiscal"
                value={descricaoFiscalFilter}
                onChange={(e) => setDescricaoFiscalFilter(e.target.value)}
              />
            </div>

            {/* Filtro por Código */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Código</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por código"
                value={pr_cdprodutoFilter}
                onChange={(e) => setpr_cdProdutoFilter(e.target.value)}
              />
            </div>
            {/* Filtro por Blue */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Código Blue</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por cod Blue Unitário"
                value={prb_cdprodutobluesoftFilter}
                onChange={(e) => setPrb_cdprodutobluesoftFilter(e.target.value)}
              />
            </div>            

            
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

            {/* Filtro por Status */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Status</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                value={filtrar_status_bluesoft}
                onChange={(e) => setfiltrar_status_bluesoft(e.target.value)}
              >
                <option value="">Todos</option>
                <option value="ATIVO">Ativo</option>
                <option value="INATIVO">Inativo</option>
              </select>
            </div>

            {/* Filtro por Venda Externa */}
            <div className='flex-row'>
              <label className="block text-sm font-medium text-gray-700 mb-1">Venda Externa</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                value={filtrar_vendaexterna}
                onChange={(e) => setfiltrar_vendaexterna(e.target.value)}
              >
                <option value="">Todos</option>
                <option value="SIM">Sim</option>
                <option value="NAO">Não</option>
              </select>
            </div>

        {/* Filtro por Data de Cadastro - Seção separada */}
          <div className="flex-row col-span-2">
            <label className="block text-sm font-medium text-gray-700 mb-1">
              <input
                type="checkbox"
                checked={filtraDataCadastro}
                onChange={(e) => setfiltraDataCadastro(e.target.checked)}
                className="mr-2 h-3 w-3 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
              />
              Filtrar por Data de Cadastro
            </label>
            
             <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                <div>
                  <input
                    type="date"
                    disabled={!filtraDataCadastro}
                    value={dataCadastroInicial}
                    onChange={(e) => setdataCadastroInicial(e.target.value)}
                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                  />
                </div>
                <div>
                  <input
                    type="date"
                    disabled={!filtraDataCadastro}
                    value={dataCadastroFinal}
                    onChange={(e) => setdataCadastroFinal(e.target.value)}
                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                  />
                </div>
              </div>
          
          </div>



          <div className="flex-row col-span-2">
              <label className="block text-sm font-medium text-gray-700 mb-1">
                <input
                  type="checkbox"
                  checked={filtrarComMovimentacao}
                  onChange={(e) => setfiltrarComMovimentacao(e.target.checked)}
                  className="mr-2 h-3 w-3 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
                />
                Filtrar por Movimentação de Estoque
              </label>

              <label className="block text-sm font-medium text-gray-700 mb-1">
                <input
                  type="checkbox"
                  checked={filtrarComMovimentacaoNegativa}
                  disabled={!filtrarComMovimentacao}
                  onChange={(e) => setfiltrarComMovimentacaoNegativa(e.target.checked)}
                  className="mr-2 h-3 w-3 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
                />
                Sem Movimentação
              </label>
              
              <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                <div className='flex-row'>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Tipo Movimentação</label>
                  <select
                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                    value={filtrarComMovimentacaoTipo}
                    onChange={(e) => setfiltrarComMovimentacaoTipo(e.target.value)}
                    disabled={!filtrarComMovimentacao}
                  >
                    <option value="Todas">Todas</option>
                    <option value="ENTRADA">Entrada</option>
                    <option value="SAIDA">Saída</option>
                  </select>
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">N. de Meses</label>
                  <input
                    type="number"
                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                    placeholder="Número de meses retroativo de movimentação"
                    value={filtrarComMovimentacaoNumeroMes}
                    onChange={(e) => setfiltrarComMovimentacaoNumeroMes(Number(e.target.value))}
                    disabled={!filtrarComMovimentacao}
                  />
                </div>
              </div>
            </div>


            {/* Filtro por Fornecedor */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Fornecedor</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por fornecedor"
                value={fornecedor_razao_social}
                onChange={(e) => setfornecedor_razao_social(e.target.value)}
              />
            </div>


            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Status Figura Fiscal</label>
              <select

                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black bg-white disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                value={figurafiscalassociada}
                onChange={(e) => { 
                  setfigurafiscalassociada(e.target.value)
                  setfigurafiscal("")

                }}

              >
                <option value="T">Todos</option>
                <option value="S">Com Figura Fiscal</option>
                <option value="N">Sem Figura Fiscal</option>
              </select>
            </div>

            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Status Regra NFCE</label>
              <select

                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black bg-white disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                value={filtrarComRegraNfce}
                onChange={(e) => { 
                  setfiltrarComRegraNfce(e.target.value)

                }}
                disabled={!(figurafiscalassociada === "S")}

              >
                <option value="T">Todos</option>
                <option value="S">C/ Regra NFCE</option>
                <option value="N">S/ Regra NFCE</option>
              </select>
            </div>            


            {/* Descrição Figura FIscal */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Descrição Figura Fiscal</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black bg-white disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                placeholder="Filtrar por descrição"
                value={figurafiscal}
                disabled={!(figurafiscalassociada === "S")}
                onChange={(e) => setfigurafiscal(e.target.value)}
              />
            </div>


            {/* Filtro por ncm */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">NCM</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Informe o NCM"
                value={ncm}
                onChange={(e) => setNCM(e.target.value)}
              />
            </div>

            {/* Filtro por ncm */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">CEST</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Informe o CEST"
                value={cest}
                onChange={(e) => setCest(e.target.value)}
              />
            </div>

            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Tipo NFCE</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                value={nfceProdutoTipoFilter}
                onChange={(e) => setNfceProdutoTipoFilter(user.toNumber(e.target.value))}
              >

                {nfceProdutoTipoList.map((TipoNfce, index) => (
                  <option key={index} value={TipoNfce.nfce_produto_tipo_cd}>{TipoNfce.nfce_produto_tipo_descricao}</option>
                ))}
              </select>
            </div>


         </div>
        </div>
        
        {/* Grid de Produtos */}
        <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
          <div className="max-h-[500px] overflow-y-auto">
            <table className="min-w-full divide-y divide-gray-200">
                    <thead className="bg-gray-100 sticky top-0 z-10">
        {/* Primeira linha do cabeçalho - Grupos principais */}
        <tr>
          <th rowSpan={2} className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Pag</th>
          <th rowSpan={2} className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Blue Unit.</th>
          <th rowSpan={2} className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Descrição / Descrição Fiscal</th>
          <th rowSpan={2} className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Est.</th>
          <th rowSpan={2} className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Status</th>

          <th rowSpan={2} className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Figura Fiscal</th>

          <th rowSpan={2} className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Cadastro</th>
          <th rowSpan={2} className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Fornecedor</th>
          <th rowSpan={2} className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">NCM</th>
          
          
          {/* Grupos de colunas */}
          <th colSpan={8} className="px-4 py-3 text-center text-xs font-medium text-purple-700 tracking-wider border-l border-gray-300 bg-green-50">Reforma</th>
          <th rowSpan={2} className="px-4 py-3 text-center text-xs font-medium text-purple-700 tracking-wider border-x border-gray-300 bg-purple-50">PIS</th>
          <th rowSpan={2} className="px-4 py-3 text-center text-xs font-medium text-purple-700 tracking-wider border-x border-gray-300 bg-blue-50">COFINS</th>
          <th rowSpan={2} className="px-4 py-3 text-center text-xs font-medium text-purple-700 tracking-wider border-l border-gray-300 bg-green-50">ICMS</th>
          
        </tr>
        
        {/* Segunda linha do cabeçalho - Subcolunas */}
        <tr>
          

       


          <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">S.CST</th>
          <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Class Trib</th>
          <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">IBS</th>
          <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">IBS Red</th>
          <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">CBS</th>
          <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">CBS Red</th>
          <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">IBS Mun</th>
          <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">IBS Mun Red</th>          
        </tr>
      </thead>
              <tbody className="bg-white divide-y divide-gray-200">
                {produtosList.length > 0 ? (
                  produtosList.map((product, index) => (
                    <tr key={`${product.pr_cdproduto}_${index}`} className="hover:bg-gray-50">
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{product.pr_cdproduto}</td>
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-right">
                        {product.prb_cdprodutobluesoft_pk}
                        <div className="break-words">
                          Unit. {product.prb_cdprodutobluesoft}
                        </div>
                      </td>
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 ">
                        {product.prb_descricao}
                        <div className="break-words">
                          {product.prb_descricao_fiscal && `${product.prb_descricao_fiscal}`.trimEnd().length > 80
                            ? product.prb_descricao_fiscal.match(/.{1,65}/g)?.join('\n') 
                            : product.prb_descricao_fiscal
                          }  
                        </div>
                      </td>
                     

                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 ">{product.pr_embalagemestoque}</td>
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-left">
                          {product.prb_status === 1 ? "Ativo" : "Inativo" }
                          <div className="break-words">
                          Ext.: {product.prb_vendaexterna === 1 ? "Sim" : "Não" }
                          </div>
                      </td>
                      <td className={`px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-left ${product.fc_figurafiscal_descricao ? "bg-green-300" : ""}`}>
                        <span className={`inline-block w-3 h-3 rounded-full ${product.status_regra_nfce === "SIM" ? 'bg-green-500' : 'bg-red-500'}`}></span>
                        {product.fc_figurafiscal_descricao}
                        <div className="break-words">
                          Qtde Nfce {product.qtde_nfce}
                        </div>
                        </td>


                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-left">{user.formatDateDDMMYYYY(product.prb_dt_cadastro)}</td>
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-left">{product.fornecedor_nome_razao}</td>
                      
                      
                      
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{product.ncm_codigo}</td>  

                                            <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{product.rt_codigo_cst_ibs_cbs}</td>
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{product.rt_codigo_class_trib_ibs_cbs}</td>

                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{user.formatNumber(product.ibs_aliquota)}</td>  
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{user.formatNumber(product.ibs_percentual_reducao)}</td>   
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{user.formatNumber(product.cbs_aliquota)}</td>   
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{user.formatNumber(product.cbs_percentual_reducao)}</td>   
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{user.formatNumber(product.ibs_mun_aliquota)}</td>  
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{user.formatNumber(product.ibs_mun_percentual_reducao)}</td>                         

                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-right">
                        Cst {product.pis_cst} Aliq. {user.formatNumber(product.pis_aliquota)}
                      
                      </td>

                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-right">
                        Cst {product.cofins_cst} Aliq. {user.formatNumber(product.cofins_aliquota)}
                      </td>                                                 

                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-right">
                            {product.icms_descricao}
                            <div className="break-words font-bold">
                            Cst: {product.cst} Aliquota: {user.formatNumber(product.icms_aliquota)} Redução: {user.formatNumber(product.icms_reducao)}
                            </div>
                      </td>
                                                                                           




                  </tr>
                  ))
                ) : (
                  <tr>
                    <td colSpan={6} className="px-6 py-4 text-center text-sm text-gray-500">
                      Nenhum produto encontrado com os filtros aplicados.
                    </td>
                  </tr>
                )}
              </tbody>
            </table>

          </div>

        </div>
          <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
            <div className="flex justify-between items-center">
              <h3 className="text-mg font-medium text-gray-500">Total de Registros</h3>
              <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
                {produtosList.length} produto{produtosList.length !== 1 ? 's' : ''}
              </span>
            </div>
          </div>


          <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
            <div className="flex justify-end items-center">
              <h3 className="text-mg font-medium text-gray-500">A fim de evitar lentidão na interface é altamente recomendável empregar o máximo de filtros disponíveis.</h3>
            </div>
          </div>
          <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
            <div className="flex justify-end items-center">
              <h3 className="text-mg font-medium text-gray-500">A fim de evitar lentidão na interface é altamente recomendável empregar o máximo de filtros disponíveis.</h3>
              <ButtonPag TypeButton="_BUTTON_HEADER" label="Processar os 500 primeiros itens e atualizar a lista" TypeIcon="_SALVAR" title="Associar" onClick={processarProdutos} ActionStatus={ActionStatus}></ButtonPag>
            </div>
          </div>          
      </div>
    </div>
  );
}