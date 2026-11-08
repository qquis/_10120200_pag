'use client'
import React, { use } from "react";
import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";
import { usePersistedState } from "@/app/hooks/usePersistedState";
import dynamic from 'next/dynamic';

import ModalFinanceiroPagItem from "../pag/ModalAutorizacaoPgtoPag";

// Importação dinâmica do ApexCharts para evitar problemas de SSR
const Chart = dynamic(() => import('react-apexcharts'), { ssr: false });

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";


/*Modulos API*/
import { moduleFinanceiro, tpfluxoCaixa, tpAutorizacaoPagamentoPag} from "@/api/m0080_financeiro/modulefinanceiro";
import { moduleResultado, re_conta } from "@/api/m0100_resultado/moduleResultado";
import { moduleEnterprise, re_compentencia } from "@/api/m0002_enterprise/moduleEnterprise";
  


/*Modals*/



export default function FinanceiroFluxo() {
  
  const { user } = useAuth()
  
  let myModule : moduleFinanceiro = new moduleFinanceiro(user);
  let myModuleResultado : moduleResultado = new moduleResultado()


    // Estados que serão persistidos entre navegações de guias
  const [ActionStatus, setActionStatus] = usePersistedState('ActionStatus', 0);
  const [isModalOpen, setIsModalOpen] = usePersistedState('isModalOpen', false);
  const [actionOpenModel, setActionOpenModel] = usePersistedState('actionOpenModel', "_SELECT");
  


  // Filtros persistidos
  const [filterdata, setfilterdata] = usePersistedState('filterdata', 0);
  const [filterdata_ini, setfilterdata_ini] = usePersistedState('filterdata_ini', new Date());
  const [filterdata_fim, setfilterdata_fim] = usePersistedState('filterdata_fim', new Date());
  const [datafilter, setdatafilter] = usePersistedState('datafilter', "");
  const [numeroRegistros, setNumeroRegistros] = usePersistedState('numeroRegistros', 0);
  const [itemModalAutorizacaoPagamentoSelect, setModalAutorizacaoPagamentoSelect] = usePersistedState<tpAutorizacaoPagamentoPag | null>('itemModalAutorizacaoPagamentoSelect', null);



  

  // Lista principal persistida
  const [listFluxo, SetlistFluxo] = usePersistedState<tpfluxoCaixa[]>('listFluxo', []);
  const [listRegistros, SetlistRegistros] = usePersistedState<tpfluxoCaixa[]>('listresultado', []);
  const [listRegistrosShow, setListRegistrosShow]= useState<tpfluxoCaixa[]>([]);

  // Item modal persistido


  /*------------------------------------------------------------------------*/


  useEffect(() => { 
    async function Binding() {

    }
    Binding()
  }, [])

  
  const ListarRegistros = async () => {
    try {
      setActionStatus(1)
      let ListResultado : tpfluxoCaixa[] = [] 
      SetlistFluxo( [] );
      ListResultado = await myModule.financeiroFluxoCaixaGet({tipovisualizacao: "FLUXO" })
      SetlistFluxo(ListResultado);


      //Limpa os registros
      
      SetlistRegistros([]);


      /*Processa consulta geral*/
      let ListRegistros : tpfluxoCaixa[] = await myModule.financeiroFluxoCaixaGet({tipovisualizacao: "LIST"})
      SetlistRegistros(ListRegistros);
      setListRegistrosShow([])
      setdatafilter("")
      setActionStatus(0)


    } catch(e) { 
      alert('Erro ao filtrar registros: ' + e)
      setActionStatus(0)    }
  }


const filterRegistros = async (dt: Date) => {
  try { 
    setActionStatus(1)
    setdatafilter(`${new Date(dt).toLocaleDateString('pt-BR')}`)
    const filterDateStr = `${new Date(dt).toLocaleDateString('pt-BR')}`;

    // Se precisar de filtro assíncrono:
    const results = await Promise.all(
      listRegistros.map(async item => {
        // Exemplo: alguma verificação assíncrona
        if (!item.data_previsao) return null;
        const itemDateStr = `${new Date(item.data_previsao).toLocaleDateString('pt-BR')}`;
        // Suponha que precise de uma chamada assíncrona:
        // const isValid = await someAsyncCheck(item);
        // return isValid && itemDateStr === filterDateStr ? item : null;
        return itemDateStr === filterDateStr ? item : null;
      })
    );
    const lreg = results.filter(item => item !== null) as tpfluxoCaixa[];
    setListRegistrosShow(lreg)
    setNumeroRegistros(lreg.length)
    setActionStatus(0)
  }
  catch(e) { 
    alert('Erro ao filtrar registros: ' + e)
    setActionStatus(0)
  }
}
  // Função para preparar dados do gráfico
  const prepareChartData = () => {
    if (listFluxo.length === 0) return { categories: [], series: [], colors: [] };

    const categories = listFluxo.map(item => 
      item.data_previsao ? new Date(item.data_previsao).toLocaleDateString('pt-BR') : 'Data inválida'
    );
    
    // Função para exibir legenda apenas no dia 1 de cada mês
    const formatCategoriesForFirstDayOfMonth = () => {
      return listFluxo.map(item => {
        if (!item.data_previsao) return 'Data inválida';
        const date = new Date(item.data_previsao);
        if (date.getDate() === 1) {
          return date.toLocaleDateString('pt-BR');
        } else {
          return '';
        }
      });
    };
    
    const saldoData = listFluxo.map(item => Number(item.saldo));
    
    // Cores dinâmicas baseadas no valor (positivo = azul, negativo = vermelho)
    const colors = saldoData.map(value => value >= 0 ? '#60A5FA' : '#EF4444');

    return {
      categories: formatCategoriesForFirstDayOfMonth(),
      series: [{
        name: 'Saldo',
        data: saldoData
      }],
      colors
    };
  };

  // Configuração do gráfico
  const getChartOptions = () => {
    const chartData = prepareChartData();
    
    return {
      chart: {
        type: 'bar' as const,
        height: 350,
        toolbar: {
          show: true
        },
        responsive: [{
          breakpoint: 768,
          options: {
            chart: {
              height: 300
            },
            plotOptions: {
              bar: {
                horizontal: false,
                columnWidth: '70%'
              }
            }
          }
        }]
      },
      plotOptions: {
        bar: {
          horizontal: false,
          columnWidth: '55%',
          borderRadius: 4,
          distributed: true, // Permite cores diferentes para cada barra
          dataLabels: {
            position: 'top',
          }
        },
      },
      dataLabels: {
        enabled: false
      },
      stroke: {
        show: true,
        width: 2,
        colors: ['transparent']
      },
      xaxis: {
        categories: chartData.categories,
        title: {
          text: 'Data Previsão'
        },
        labels: {
          rotate: -45,
          style: {
            fontSize: '11px'
          },
          formatter: function(value: string) {
            // Se o valor estiver vazio, não mostra nada
            return value || '';
          }
        },
        axisBorder: {
          show: true
        },
        axisTicks: {
          show: true
        }
      },
      yaxis: {
        title: {
          text: 'Valor (R$)'
        },
        labels: {
          formatter: function (val: number) {
            return (val / 1000).toLocaleString('pt-BR');
          }
        }
      },
      fill: {
        opacity: 1
      },
      tooltip: {
        x: {
          formatter: function(value: any, { dataPointIndex }: any) {
            // Mostra a data completa no tooltip, independente da label
            const item = listFluxo[dataPointIndex];
            if (item && item.data_previsao) {
              return new Date(item.data_previsao).toLocaleDateString('pt-BR');
            }
            return 'Data inválida';
          }
        },
        y: {
          formatter: function (val: number) {
            return val.toLocaleString('pt-BR', {
              style: 'currency',
              currency: 'BRL'
            });
          }
        }
      },
      colors: chartData.colors, // Azul para positivo, vermelho para negativo
      title: {
        text: 'Fluxo de Caixa',
        align: 'center' as const,
        style: {
          fontSize: '16px',
          fontWeight: '600',
          color: '#374151'
        }
      },
      legend: {
        show: false // Esconde a legenda para distributed bars
      },
      grid: {
        borderColor: '#e5e7eb',
        strokeDashArray: 3
      }
    };
  };

  const ScreenOpenModal = async (aut_pgto_pag_seq: number, action: string ) => {
      setActionOpenModel(action)

      let myItemModal : tpAutorizacaoPagamentoPag  = await myModule.modulelancamentoPag.new()

      if (aut_pgto_pag_seq !== 0)
         myItemModal = await myModule.modulelancamentoPag.consultar(aut_pgto_pag_seq)


      setModalAutorizacaoPagamentoSelect(myItemModal)
      setIsModalOpen(true);
  };

  /*------------------------------------------------------------------------*/  
  
  const ScreenCloseModal = () => {
    setModalAutorizacaoPagamentoSelect(null);
    setIsModalOpen(false);
  };



  /*------------------------------------------------------------------------*/  
  

  return (
  <div className="min-h-screen bg-gray-50 p-6">
      <div className="max-w-7xl mx-auto">
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Fluxo de Caixa" >
          <div className="flex space-x-2">
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={ListarRegistros} ></ButtonPag>
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Ajuste de Previsão" TypeIcon="_NEW" title="Novo Lançamento" onClick={() => ScreenOpenModal(0, "_NEW")} ></ButtonPag>
          </div>              
        </HeaderMain>
        


        {/* Grid List */}

        <div className="flex gap-4 items-start">
          <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
            <div className="max-h-[500px] overflow-y-auto">
              <table className="min-w-full divide-y divide-gray-200">
                <thead className="bg-gray-100 sticky top-0 z-10">
                  <tr>
                    <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Data Previsão</th>
                    <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Qtde</th>
                    <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Cartão (d-1)</th>
                    <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Ct Receber</th>
                    <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Ct Pagar</th>
                    <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Adm</th>
                    <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Saldo</th>
                  </tr>
                </thead>
                <tbody className="bg-white divide-y divide-gray-200">
                      {listFluxo.length > 0 ? (
                        (() => {
                          // Agrupa os itens por mês/ano
                          const groupedByMonth: { [key: string]: tpfluxoCaixa[] } = {};
                          listFluxo.forEach(item => {
                            const date = item.data_previsao ? new Date(item.data_previsao) : null;
                            const key = date ? `${date.getFullYear()}-${(date.getMonth() + 1).toString().padStart(2, '0')}` : 'Data inválida';
                            if (!groupedByMonth[key]) groupedByMonth[key] = [];
                            groupedByMonth[key].push(item);
                          });

                          // Renderiza os grupos
                          return Object.entries(groupedByMonth).map(([monthKey, items]) => {
                            // Formata o nome do mês
                            const [year, month] = monthKey.split('-');
                            const monthName = new Date(Number(year), Number(month) - 1).toLocaleString('pt-BR', { month: 'long', year: 'numeric' });

                            return (
                              <React.Fragment key={monthKey}>
                                <tr>
                                  <td colSpan={6} className="bg-purple-50 text-purple-700 font-semibold px-3 py-2 sticky top-0 z-0">
                                    {monthName.charAt(0).toUpperCase() + monthName.slice(1)}
                                  </td>
                                </tr>
                                {items.map(item => (
                                  <tr
                                    key={item.data_previsao ? new Date(item.data_previsao).toLocaleDateString('pt-BR') + item.saldo : Math.random()}
                                    className={`hover:bg-gray-50 ${Number(item.saldo) >= 0 ? 'bg-blue-100' : 'bg-red-300'}`}
                                  >
                                  <td className="px-2 py-4 whitespace-nowrap text-sm text-gray-700 cursor-pointer"
                                      onClick={() => {
                                        if (item.data_previsao) {
                                          filterRegistros(new Date(item.data_previsao));
                                        }
                                      }}>
                                    {item.data_previsao
                                      ? `${new Date(item.data_previsao).getDate().toString().padStart(2, '0')} - ${new Date(item.data_previsao).toLocaleDateString('pt-BR', { weekday: 'short' })}`
                                      : 'Data inválida'}
                                  </td>
                                    <td className="px-4 py-4 whitespace-nowrap text-sm text-gray-700 text-right">
                                      {Number(item.qtde).toLocaleString('pt-BR', { minimumFractionDigits: 0, maximumFractionDigits: 2 })}
                                    </td>
                                    <td className="px-4 py-4 whitespace-nowrap text-sm text-gray-700 text-right">
                                      {Number(item.valor_cartao).toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                                    </td>
                                    <td className="px-4 py-4 whitespace-nowrap text-sm text-gray-700 text-right">
                                      {Number(item.valor_receber).toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                                    </td>
                                    <td className="px-4 py-4 whitespace-nowrap text-sm text-gray-700 text-right">
                                      {Number(item.valor_pagar).toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                                    </td>
                                    <td className="px-4 py-4 whitespace-nowrap text-sm text-gray-700 text-right">
                                      {Number(item.valor_adm_previsao).toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                                    </td>                                    
                                    <td className="px-4 py-4 whitespace-nowrap text-sm text-gray-700 text-right">
                                      {Number(item.saldo).toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                                    </td>
                                  </tr>
                                ))}
                              </React.Fragment>
                            );
                          });
                        })()
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

          {/* Gráfico de Barras - Saldo */}
          {listFluxo.length > 0 && (
          <div className="bg-white rounded-lg shadow-md p-6 border border-purple-100 w-2/4">
              <div className="w-full">
                <Chart
                  options={getChartOptions()}
                  series={prepareChartData().series}
                  type="bar"
                  height={350}
                />
              </div>
            </div>
          )}

          
        </div>

        <div className="flex items-center gap-4 mt-4">
        <span className="text-sm text-gray-600 font-semibold">Data filtrada:</span>
        <span className="bg-purple-100 text-purple-700 px-3 py-1 rounded-full text-sm font-bold">
          {datafilter || 'Nenhuma data selecionada'}
        </span>
        <span className="text-sm text-gray-600 font-semibold">Registros:</span>
        <span className="bg-blue-100 text-blue-700 px-3 py-1 rounded-full text-sm font-bold">
          {listRegistrosShow.length}
        </span>
      </div>
          {/* Tabela de ListRegistros abaixo do grid e gráfico */}
          <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100 mt-8">
            <div className="max-h-[400px] overflow-y-auto">
              <table className="min-w-full divide-y divide-gray-200">
                <thead className="bg-gray-100 sticky top-0 z-10">
                  <tr>
                    <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Dup / Cod. Mov</th>
                    <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Descrição</th>
                    <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Dt Prev</th>
                    <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Venc</th>
                    <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Pgto</th>
                    <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Quitacao</th>
                    <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Valor Previsto</th>
                    <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Tipo Previsão</th>
                  </tr>
                </thead>
              <tbody className="bg-white divide-y divide-gray-200">
              {listRegistrosShow.length > 0 ? (
                [...listRegistrosShow]
                  .sort((b, a) => Number(b.saldo) - Number(a.saldo)) // Ordena do maior para o menor
                  .map(itemItemShow => (
                    <tr
                      key={itemItemShow.autpgto_seq_pk}
                      className={`hover:bg-gray-50 ${Number(itemItemShow.saldo) >= 0 ? 'bg-blue-50' : 'bg-red-50'}`}
                    >
                      <td className="px-4 py-4 whitespace-nowrap text-sm text-gray-700 text-right">
                      {itemItemShow.registro_adm === 1 ? (
                        <a
                          href="#"
                          className="text-blue-600 underline font-bold"
                          onClick={(e) => {
                            e.preventDefault();
                            ScreenOpenModal(itemItemShow.autpgto_seq_pk, "_EDIT");
                          }}
                        >
                          {itemItemShow.autpgto_seq_pk}
                        </a>
                      ) : (
                        itemItemShow.autpgto_seq_pk
                      )}
                    </td>
                      <td className="px-4 py-4  text-sm text-gray-700 text-left">{itemItemShow.descricao} </td>
                      <td className="px-2 py-4 whitespace-nowrap text-sm text-gray-700">
                        {itemItemShow.data_previsao
                          ? `${new Date(itemItemShow.data_previsao).toLocaleDateString('pt-BR')}`
                          : 'Data inválida'}
                      </td>
                      <td className="px-2 py-4 whitespace-nowrap text-sm text-gray-700">
                        {itemItemShow.autpgto_datavencimento
                          ? `${new Date(itemItemShow.autpgto_datavencimento).toLocaleDateString('pt-BR')}`
                          : 'Data inválida'}
                      </td>
                      <td className="px-2 py-4 whitespace-nowrap text-sm text-gray-700">
                        {itemItemShow.autpgto_datapagamento
                          ? `${new Date(itemItemShow.autpgto_datapagamento).toLocaleDateString('pt-BR')}`
                          : 'Data inválida'}
                      </td>
                      <td className="px-2 py-4 whitespace-nowrap text-sm text-gray-700">
                        {itemItemShow.autpgto_dataquitacao
                          ? `${new Date(itemItemShow.autpgto_dataquitacao).toLocaleDateString('pt-BR')}`
                          : 'Data inválida'}
                      </td>
                      <td className="px-4 py-4 whitespace-nowrap text-sm text-gray-700 text-right">
                        {Number(itemItemShow.saldo).toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                      </td>
                      <td className="px-4 py-4 whitespace-nowrap text-sm text-gray-700 text-center">
                        {itemItemShow.registro_adm === 1 ? "SIM" : "NÃO"}
                      </td>
                    </tr>
                  ))
              ) : (
                <tr>
                  <td colSpan={6} className="px-6 py-4 text-center text-sm text-gray-500">
                    Nenhum registro encontrado.
                  </td>
                </tr>
              )}
            </tbody>
              </table>
            </div>
          </div>
        {isModalOpen && itemModalAutorizacaoPagamentoSelect && (
          <ModalFinanceiroPagItem 
            aut_pgto_pag_seq ={itemModalAutorizacaoPagamentoSelect.aut_pgto_pag_seq} 
            action = {actionOpenModel}
            onClose={ScreenCloseModal} 
            tipo_lancamento={2}
            />
        )}

      </div>
    </div>
  );
}