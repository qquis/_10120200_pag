'use client'
import { useEffect, useState} from "react";
import { moduleResultado , re_conta, re_contaOrigem} from "@/api/m0100_resultado/moduleResultado";


/*Screen Imports */
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";
import ModalConta from "./ModalConta";


export default function listConta() {

    //Screen Controls
  const [ActionStatus, setActionStatus] = useState(0)

  /*Listas */
  const [DataList, setDataList] = useState <re_conta[]>([])
  const [selectedConta, setSelectedConta] = useState<re_conta | null>(null);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [ResultadoGrupoList, setResultadoGrupoList] = useState <any[]>([]);
  const [DataListRateios, setDataListRateios] = useState <[]>([]);

  /*Filter */
  const [FilterContaDescricao, setFilterContaDescricao] = useState("")
  const [Filterrgrupo_cd, setfilterr_grupo_cd] = useState(0)
  let myModule : moduleResultado = new moduleResultado();
  

  useEffect(() => { 
    async function BindingDataInit() {
        try {
          setActionStatus(1);
          setDataListRateios(await myModule.getListRateios({r_rateio_sistema : 0}));
          let listResultadoGrupo : any[] = await myModule.getListResultadoGrupo({});
          setResultadoGrupoList(listResultadoGrupo);
        } catch (error) {
            alert(`Erro ao carregar dados iniciais: ${error}`);
        } finally {
            setActionStatus(0);
        }
    }

    BindingDataInit()
  }, [])

  
  const ListAtualizar = async () => {
    try {
      setActionStatus(1);
      setDataList([]);
      const apiListConta : re_conta[] =  await myModule.getListConta
      ( {
            r_conta_descricao: FilterContaDescricao.toUpperCase().replace("'", ""),
            r_grupo_cd : Filterrgrupo_cd,
        }
      )
      setDataList(apiListConta);
    } catch (error) {
      alert(`Erro ao consultar contas: ${error}`);
    } finally {
      setActionStatus(0);
    }

  }
  

    
  const ScreenOpenModal = async (conta: re_conta) => {
      let dadosDetalhadosDaConta : re_conta 
      dadosDetalhadosDaConta = await myModule.apiDRE_Conta.get(conta.r_conta_cd)
      setSelectedConta(dadosDetalhadosDaConta);
      setIsModalOpen(true);
  };

  const ScreenCloseModal = () => {
    
    setIsModalOpen(false);
    setSelectedConta(null);
  };
  return (
  <div className="min-h-screen bg-gray-50 p-6">
      <div className="max-w-7xl mx-auto">
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Resultado | Consulta" >
            <div className="flex space-x-2">
              <div>
                <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Voltar" onClick={ListAtualizar} ></ButtonPag>
              </div>  
            </div>
        </HeaderMain>    
        {/* Área de Filtros */}
        <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
          <h2 className="text-xl font-semibold text-gray-700 mb-4">Filtros</h2>
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-6 gap-4">
            {/* Filtro por Descrição */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Nome da Conta</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent"
                placeholder="Filtrar por descrição"
                value={FilterContaDescricao}
                onChange={(e) => setFilterContaDescricao(e.target.value)}
              />
            </div>
            {/* Competencia (TIPO) */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Grupo</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent"
                value={Filterrgrupo_cd}
                onChange={(e) => {
                    setfilterr_grupo_cd(parseInt(e.target.value))
                }}
              >
                <option value={0} key={0}>Todos</option>
                {ResultadoGrupoList.map((item) => (
                  <option key={item.r_grupo_cd} 
                          value={item.r_grupo_cd}>
                        {item.r_grupo_descricao}
                  </option>
                ))}
              </select>
            </div>
          </div>
        </div>

      {/* Grid de Contas */}
        <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
          <div className="max-h-[500px] overflow-y-auto">
            <table className="min-w-full divide-y divide-gray-200">
              <thead className="bg-gray-100 sticky top-0 z-10">
                <tr>
                  <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Grupo Id</th>
                  <th className="px-2 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Grupo </th>
                  <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Conta</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Descriação</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Lançamento Manual</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Lançamento à Crédito</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Rateio</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Descrição do Rateio</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">N. Reg. Vinculados</th>

                </tr>
              </thead>
              <tbody className="bg-white divide-y divide-gray-200">
                {DataList.length > 0 ? (
                  DataList.map((item: re_conta) => (
                    <tr key={item.r_conta_cd} className="hover:bg-gray-50">
                      <td className="w-16 px-3 py-3 whitespace-nowrap text-xs text-gray-700 text-right">{item.r_grupo_cd}</td>
                      <td className="w-16 px-2 py-3 whitespace-nowrap text-xs text-gray-700">{item.r_grupo_descricao}</td>
                       <td className="w-16 px-1 py-3 whitespace-nowrap text-xs text-gray-700">
                        <button 
                          onClick={() => ScreenOpenModal(item)}
                          className="text-purple-600 hover:text-purple-800 hover:underline"
                        >
                          {item.r_conta_cd}
                        </button>
                      </td>
                      <td className="px-4 py-3 whitespace-nowrap text-xs text-gray-700">{item.r_conta_descricao}</td>
                      <td className="px-4 py-3 whitespace-nowrap text-xs text-gray-700">{item.r_conta_lancamento_manual == 1 ? "Sim": "Não"}</td>
                      <td className="px-4 py-3 whitespace-nowrap text-xs text-gray-700">{item.debitocredito == 1 ? "Sim": "Não"}</td>
                      <td className="px-4 py-3 whitespace-nowrap text-xs text-gray-700">{item.r_rateio_cd}</td>
                      <td className="px-4 py-3 whitespace-nowrap text-xs text-gray-700">{item.r_rateio_descricao}</td>
                      <td className="px-4 py-3 whitespace-nowrap text-xs text-gray-700">{item.qtde_reg_vinculado}</td>

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
 {/* Modal de Detalhes */}
        {isModalOpen && selectedConta && (
          <ModalConta r_conta_cd={selectedConta.r_conta_cd} onClose={ScreenCloseModal} />
        )}
      </div>
    </div>

  );
}