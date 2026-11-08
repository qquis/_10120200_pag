// app/produtos/page.tsx
'use client'

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

const SIS_AC_CD = 4215;

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";

import { modulefiscal } from '@/api/m0040_fiscal/modulefiscal';

    let myModuleFiscal : modulefiscal
    

export default function Cbenef() {

  /* USER */
  const { user } = useAuth();
  const [ActionStatus, setActionStatus] = useState<number>(0);
  const [fc_cbenef_cdFilter, setfc_cbenef_cdFilter] = useState<string>('');
  const [fc_cbenef_dispositivoFilter, setfc_cbenef_dispositivoFilter] = useState<string>('');
  const [fc_cbenef_objetivoFilter, setfc_cbenef_objetivoFilter] = useState<string>('');
  const [fc_cbenef_bluesoftFilter, setfc_cbenef_bluesoftFilter] = useState<number>(0);
  const [fc_cbenef_pag_qtde_Filter, setfc_cbenef_pag_qtde_Filter] = useState<number>(0);
  const [fc_cbenef_blue_qtde_Filter, setfc_cbenef_blue_qtde_Filter] = useState<number>(0);

  const [List, setList] = useState<any>([]);

  useEffect(() => {
    myModuleFiscal = new modulefiscal(user, SIS_AC_CD);


    const BindingData = async () => {
          await BindingList()

  };

  BindingData();
}, []);



const AtualizarListCbenefBluesoft = async () => { 
    try {
      if (window.confirm("Deseja importar os dados do ambiente Bluesoft?")) {
          setActionStatus(1)
          await myModuleFiscal.cbenefImportarListBluesoft()
          await BindingList()
          setActionStatus(0)
          
      }
    } catch (error) {
      console.error("Erro ao importar os dados do ambiente Bluesoft:", error);
      alert("Ocorreu um erro ao importar os dados do ambiente Bluesoft. Por favor, tente novamente.");
    }

  }



  const BindingList = async () => { 

    let parametro : any = { 
        fc_cbenef_dispositivo: fc_cbenef_dispositivoFilter,
        fc_cbenef_cd: fc_cbenef_cdFilter,
        fc_cbenef_objetivo: fc_cbenef_objetivoFilter,
        fc_cbenef_bluesoftFilter: fc_cbenef_bluesoftFilter,
        fc_cbenef_pag_qtde_Filter: fc_cbenef_pag_qtde_Filter,
        fc_cbenef_blue_qtde_Filter: fc_cbenef_blue_qtde_Filter

    }
    setActionStatus(1)
      const response = await myModuleFiscal.getListCbenef(parametro)
      setList(response)
    setActionStatus(0)

  }
  return (
    <div className="min-h-screen bg-gray-50 p-6">
      <div className="max-w-7xl mx-auto">
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Produto | CBENEF _ Código de Benefício Fiscal" >
          <div className="flex space-x-2">
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={BindingList} ActionStatus={ActionStatus}></ButtonPag>
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Atualizar Lista Cbenef Bluesoft" TypeIcon="_UPDATE" title="Atualizar Lista Cbenef Bluesoft" onClick={AtualizarListCbenefBluesoft} ActionStatus={ActionStatus}></ButtonPag>
          </div>              
     
        </HeaderMain>
        
        {/* Área de Filtros */}
        <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100 flex space-x-4">
            {/* Filtro por Código */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Código do Benefício Fiscal</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por código"
                value={fc_cbenef_cdFilter}
                onChange={(e) => setfc_cbenef_cdFilter(e.target.value)}
              />
            </div>
        
            {/* Filtro por Dispositivo */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Dispositivo</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por dispositivo"
                value={fc_cbenef_dispositivoFilter}
                onChange={(e) => setfc_cbenef_dispositivoFilter(e.target.value)}
              />
            </div>
            {/* Filtro por Objetivo */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Objetivo</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por objetivo"
                value={fc_cbenef_objetivoFilter}
                onChange={(e) => setfc_cbenef_objetivoFilter(e.target.value)}
              />
            </div> 

              {/* Filtro por Ambiente Bluesoft */}
              <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Contém no Ambiente Bluesoft</label>
              <input
                type="checkbox"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por código ambiente bluesoft"
                checked={fc_cbenef_bluesoftFilter === 1}
                onChange={(e) => setfc_cbenef_bluesoftFilter(e.target.checked ? 1 : 0)}
              />
            </div>   

              {/* Filtro por Quantidade Pag */}
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Quantidade Pag</label>
                <input
                type="checkbox"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por código ambiente bluesoft"
                checked={fc_cbenef_pag_qtde_Filter === 1}
                onChange={(e) => setfc_cbenef_pag_qtde_Filter(e.target.checked ? 1 : 0)}
                />
              </div>

              {/* Filtro por Quantidade Bluesoft */}
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Quantidade Bluesoft</label>
                <input
                type="checkbox"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por código ambiente bluesoft"
                checked={fc_cbenef_blue_qtde_Filter === 1}
                onChange={(e) => setfc_cbenef_blue_qtde_Filter(e.target.checked ? 1 : 0)}
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
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Código Cbenef</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Dispositivo</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Pag Qtde</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Blue qtde</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Ambiente Bluesoft</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Observação</th>
                  </tr>
            
                </thead>
              <tbody className="bg-white divide-y divide-gray-200">
                {List.length > 0 ? (
                  List.map((item: any) => (
                    <tr key={item.fc_cbenef_cd} className="hover:bg-gray-50">
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 ">{item.fc_cbenef_cd}</td>
                      <td className="px-1 py-2  text-sm text-gray-700 ">
                         <div className='flex flex-col text-gray-700' > 
                            <label className='text-[12px] font-bold'>Dispositivo {item.fc_cbenef_dispositivo}</label>
                            <label className='text-[12px] font-bold'>Objetivo {item.fc_cbenef_objetivo}</label>
                        </div>
                      </td>

                      <td className="px-1 text-sm text-gray-700 ">{item.pag_qtde}</td>
                      <td className="px-1 text-sm text-gray-700 ">{item.blue_qtde}</td>

                      <td className="w-12 px-1 py-2">
                        {item.fc_cbenef_bluesoft_cd && item.fc_cbenef_bluesoft_cd !== 0?  
                        <div className='flex flex-col text-gray-700' > 
                         <label className='text-[12px] font-bold  text-blue-600'>CBenef Blue {item.fc_cbenef_bluesoft_cd}</label>
                         <label className='text-[12px] font-bold'>Dispositivo {item.fc_cbenef_bluesoft_dispositivo}</label>
                         <label className='text-[12px] font-bold'>Objetivo {item.fc_cbenef_bluesoft_objetivo}</label>
                        </div>
                        : ""
                        }
                      </td>
                      <td className="px-1 text-sm text-gray-700 ">{item.fc_cbenef_observacao}</td>
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





