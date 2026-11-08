'use client'
import { useEffect, useState, useTransition  } from "react";
import { re_compentencia } from "@/api/m0002_enterprise/moduleEnterprise";
import {  moduleResultado 
        , re_fechamento
        , re_centrooperacional
        , re_responsavel
        , re_operacao
        , re_resultado
        , re_conta
      } 
        from "@/api/m0100_resultado/moduleResultado";


import ModalConta from "../conta/ModalConta";
import ModalFechamentoProcessamento from "./ModalFechamentoProcessamento";
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";

export default function DreFechamento() {

  //Screen Controls
  const [ActionStatus, setActionStatus] = useState(0)

  /*Report*/
  const [myReport, setMyReport] = useState<any | null>([]);

  /*Select ComboBox */
  const [CentroOperacionalList, setListCentroOperacional ] = useState<re_centrooperacional[]>([])
  const [ResponsavelList, setListResponsavel ] = useState<re_responsavel[]>([])
  const [OperacaoList, setListOperacao ] = useState<re_operacao[]>([])
  const [ResultadoList, setListResultado ] = useState<re_resultado[]>([])
  const [CompetenciaList, setListCompetencia ] = useState<re_compentencia[]>([])
  const [fechamentoValorResultado, setFechamentoValorResultado] = useState<number>(0);
  const [selectedConta, setSelectedConta] = useState<re_conta | null>(null);

  /*Filter*/
  const [CentroOperacionalFilter, setfilterCentroOperacional ] = useState<re_centrooperacional>({r_centro_op_cd : 0}) // Inicializa com r_centro_op_cd = 0 para pegar todos
  const [ResposavelFilter, setfilterResposavel ] = useState<re_responsavel>({r_resp_cd : 0}) // Inicializa com r_resp_cd = 0 para pegar todos
  const [OperacaoFilter, setfilterOperacao ] = useState<re_operacao>({op_cdoperacao : 0}) // Inicializa com op_cdoperacao = 0 para pegar todos
  const [ResultadoFilter, setFilterResultado ] = useState<re_resultado>({r_cd: 0, r_descricao: ''}); // Inicializa com r_cd = 0 para pegar todos
  const [CompetenciaFilter, setFilterCompetencia ] = useState<re_compentencia>({competencia_cd: 0, competencia_descricao: ''}); // Inicializa com competencia_cd = 0 para pegar todos
  const [ModalNewFechamento, setModalNewFechamento] = useState<boolean>(false);
  const [isModalOpen, setIsModalOpen] = useState(false);
  let myModule : moduleResultado = new moduleResultado();
  let openPag = true;
  

  useEffect(() => { 

    async function fechamentoBindind() {
      if (openPag){
        openPag = false;
        setListCentroOperacional(await myModule.getListCentroOperacional())
        setListResponsavel(await myModule.getListResponsavel())
        setListOperacao(await myModule.getListOperacao())
        setListCompetencia(await myModule.getListCompetencia())

        let mylistResultado : re_resultado[] = await myModule.getListResultado()
        //mylistResultado = await myModule.getListResultado()
        setListResultado(mylistResultado)
        if (mylistResultado.length > 0) {
          setFilterResultado(mylistResultado[0])
        }


        let myListCompetencia : re_compentencia[] = await myModule.getListCompetencia({fechamento: true})
        setListCompetencia(myListCompetencia)
        if (myListCompetencia.length > 0) { 
            setFilterCompetencia(myListCompetencia[0])
        }

      }
    }
    fechamentoBindind()
  }, [])

  
  const consultarFechamento = async () => {
      try {
        setActionStatus(1)
        const result = await myModule.getFechamento(CompetenciaFilter,OperacaoFilter, ResposavelFilter, CentroOperacionalFilter,ResultadoFilter )
        setFechamentoValorResultado(myModule.dre_fechamentoValorResultado);
        setMyReport(result);
      } catch (error) {
        alert(`Erro ao consultar fechamento: ${error}`);
      } finally {
        setActionStatus(0)
      }

  }

  const OpenModalFechamento = () => {
    setModalNewFechamento(true);
  }

  const CloseModalFechamento = () => {
    setModalNewFechamento(false);
  }




  const OpenModalConta = async (r_conta_cd: number) => {
      let dadosDetalhadosDaConta : re_conta 
      dadosDetalhadosDaConta = await myModule.apiDRE_Conta.get(r_conta_cd)
      setSelectedConta(dadosDetalhadosDaConta);
      setIsModalOpen(true);
  };

  const CloseModalConta = () => {
    
    setIsModalOpen(false);
    setSelectedConta(null);
  };

  return (
  <div className="min-h-screen bg-gray-50 p-6">
      <div className="max-w-7xl mx-auto">
      <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Resultado | Consulta" >
          <div className="flex space-x-2">
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={consultarFechamento} ></ButtonPag>
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Novo" TypeIcon="_NEW" title="Novo" onClick={OpenModalFechamento} ></ButtonPag>
          </div>              
      </HeaderMain>
        
        {/* Área de Filtros */}
        <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
          <h2 className="text-xl font-semibold text-gray-700 mb-4">Filtros</h2>
          
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-6 gap-4">

            {/* Competencia (TIPO) */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Competência</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent"
                value={CompetenciaFilter? JSON.stringify(CompetenciaFilter):``}
                onChange={(e) => {
                    const selectValue = e.target.value
                    setFilterResultado(selectValue? JSON.parse(selectValue): null)
                }}
              >
                {CompetenciaList.map((item) => (
                  <option key={item.competencia_cd} 
                          value={JSON.stringify(item)}>
                        {item.competencia_descricao}
                  </option>
                ))}
              </select>
            </div>


            {/* Resultado (TIPO) */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Operação</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                value={ResultadoFilter? JSON.stringify(ResultadoFilter):``}
                onChange={(e) => {
                    const selectValue = e.target.value
                    setFilterResultado(selectValue? JSON.parse(selectValue): null)
                }}
              >
                {ResultadoList.map((item) => (
                  <option key={item.r_cd} 
                          value={JSON.stringify(item)}>
                        {item.r_descricao}
                  </option>
                ))}
              </select>
            </div>

            {/* Filtro por Operacional */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Operação</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                value={OperacaoFilter? JSON.stringify(OperacaoFilter):``}
                onChange={(e) => {
                    const selectValue = e.target.value
                    setfilterOperacao(selectValue? JSON.parse(selectValue): {op_cdoperacao: 0}) // Define default if empty
                }}
              >

                {OperacaoList.map((item) => (
                  <option key={item.op_cdoperacao} 
                          value={JSON.stringify(item)}>
                        {item.op_descricao}
                  </option>
                ))}
              </select>
            </div>


            {/* Filtro por Responsabilidade */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Responsabilidade</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                value={ResposavelFilter? JSON.stringify(ResposavelFilter):``}
                onChange={(e) => {
                    const selectValue = e.target.value
                    setfilterResposavel(selectValue? JSON.parse(selectValue): null)
                }}
              >
                {ResponsavelList.map((item) => (
                  <option key={item.r_resp_cd} 
                          value={JSON.stringify(item)}>
                        {item.r_resp_descricao}
                  </option>
                ))}
              </select>
            </div>
          
            <div>
            <label className="block text-sm font-medium text-gray-700 mb-1">Centro de Receita</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                value={CentroOperacionalFilter? JSON.stringify(CentroOperacionalFilter):``}
                onChange={(e) => {
                    const selectValue = e.target.value
                    setfilterCentroOperacional(selectValue? JSON.parse(selectValue): null)
                }}
              >
                {CentroOperacionalList.map((item) => (
                  <option key={item.r_centro_op_cd} 
                          value={JSON.stringify(item)}>
                        {item.r_centro_op_descricao}
                  </option>
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
                <tr>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Composição</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Conta</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">DISTRIBUIÇÃO</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">LOJA</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">E-COMMERCE</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Total</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Part / Rec Liq</th>
                </tr>
              </thead>
              <tbody className="bg-white divide-y divide-gray-200">
                {myReport.length > 0 ? (
                myReport.map((item: any, index: number) => {
                  // Verifica se é um novo grupo
                  const isNewGroup = index === 0 || item.r_grupo_descricao !== myReport[index - 1].r_grupo_descricao;
                  
                  // Conta quantos grupos únicos existem até agora para alternar as cores
                  const groupCount = myReport.slice(0, index + 1).filter(
                    (row: any, i: number) => i === 0 || row.r_grupo_descricao !== myReport[i - 1].r_grupo_descricao
                  ).length;
                  
                  // Alterna a cor baseada no número do grupo (ímpar/par)
                  const bgColorClass = groupCount % 2 === 1 ? 'bg-gray-50' : 'bg-white';

                  // Verifica se é a mesma linha do grupo anterior (para rowSpan)
                  const isSameGroup = index > 0 && item.r_grupo_descricao === myReport[index - 1].r_grupo_descricao;
                  const rowSpan = isSameGroup ? 0 : 
                    myReport.filter((row: any) => row.r_grupo_descricao === item.r_grupo_descricao).length;

                  return (
                    <tr key={item.r_conta_cd} className={`hover:bg-gray-100 ${isNewGroup ? bgColorClass : ''}`}>
                      {!isSameGroup ? (
                        <td rowSpan={rowSpan} className={`px-6 py-4 whitespace-nowrap text-xs text-gray-700 ${bgColorClass}`}>
                            <div className="font-semibold">{item.r_grupo_descricao}</div>
                            <div className="text-xs text-gray-500 mt-1">
                              Total R$: {Number(item.total_grupo).toLocaleString('pt-BR', {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2,
                              })}
                            </div>
                        </td>
                        
                      ) : null}
                      <td className={`px-6 py-2 whitespace-nowrap text-xs text-gray-700 ${bgColorClass} ${item.r_conta_cd == "1001" || item.r_conta_cd == "1999" ? "text-base font-semibold" : ""}`}>
                        {item.r_conta_descricao } 
                        (
                        <button 
                          onClick={() => OpenModalConta(item.r_conta_cd)}
                          className="text-gray-700 hover:text-blue-800 hover:underline"
                        >
                          {item.r_conta_cd}
                        </button>

                        )
                      </td>
                      <td className={`px-6 py-2 whitespace-nowrap text-xs text-gray-700 text-right ${bgColorClass} ${item.r_conta_cd == "1001" || item.r_conta_cd == "1999" ? "text-base font-semibold" : ""}`}>
                        {Number(item.distribuicao).toLocaleString('pt-BR', {
                          minimumFractionDigits: 2,
                          maximumFractionDigits: 2,
                        })}
                      </td>
                      <td className={`px-6 py-2 whitespace-nowrap text-xs text-gray-700 text-right ${bgColorClass} ${item.r_conta_cd == "1001" || item.r_conta_cd == "1999"  ? "text-base font-semibold" : ""}`}>
                        {Number(item.loja).toLocaleString('pt-BR', {
                          minimumFractionDigits: 2,
                          maximumFractionDigits: 2,
                        })}
                      </td>
                      <td className={`px-6 py-2 whitespace-nowrap text-xs text-gray-700 text-right ${bgColorClass} ${item.r_conta_cd == "1001" || item.r_conta_cd == "1999"  ? "text-base font-semibold" : ""}`}>
                        {Number(item.ecommerce).toLocaleString('pt-BR', {
                          minimumFractionDigits: 2,
                          maximumFractionDigits: 2,
                        })}
                      </td>
                      <td className={`px-6 py-2 whitespace-nowrap text-xs text-gray-700 text-right ${bgColorClass} ${item.r_conta_cd == "1001" || item.r_conta_cd == "1999"  ? "text-base font-semibold" : ""}`}>
                        {Number(item.total).toLocaleString('pt-BR', {
                          minimumFractionDigits: 2,
                          maximumFractionDigits: 2,
                        })}
                      </td>    
                      <td className={`px-6 py-2 whitespace-nowrap text-xs text-gray-700 text-right ${bgColorClass} ${item.r_conta_cd == "1001" || item.r_conta_cd == "1999"  ? "text-base font-semibold" : ""}`}>
                        {Number(item.percentual_conta_receita).toLocaleString('pt-BR', {
                          minimumFractionDigits: 2,
                          maximumFractionDigits: 2,
                        })}
                      </td>                                           
                    </tr>
                  );
                })
              ) : null}
              </tbody>
            </table>
          </div>

        </div>
        <div className="bg-white rounded-lg shadow-md p-2 mb-2 border border-purple-100 text-right">
        <div>Resultado Fechamento {Number(fechamentoValorResultado).toLocaleString('pt-BR', {
                          minimumFractionDigits: 2,
                          maximumFractionDigits: 2,
                        })} </div>
        </div>
      </div>
      
{ModalNewFechamento && (
  <ModalFechamentoProcessamento onClose={CloseModalFechamento}/>
)}

{/* Modal de Detalhes */}
{isModalOpen && selectedConta && (
  <ModalConta r_conta_cd={selectedConta.r_conta_cd} onClose={CloseModalConta} />
)}
  </div>
  );
}