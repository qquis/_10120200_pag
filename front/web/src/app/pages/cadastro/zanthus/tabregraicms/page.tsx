// app/produtos/page.tsx
'use client'

import { useMemo, useState } from 'react';
import dynamic from 'next/dynamic';
import { useAuth } from "@/app/context/context";

/* Componentes */
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";

import { moduleExternalZanthus } from '@/api/external/externalzanthus';
import ModalZanthusMercadoria from '../mercadoria/modalzanthusMercadoria';
import { usePersistedState } from '@/app/hooks/usePersistedState';

const Chart = dynamic(() => import('react-apexcharts'), { ssr: false });

type DadosGraficoOrigem = {
  categorias: string[];
  valores: number[];
  total: number;
};

export default function zanthusTabRegraIcmsList() {
  /* USER */
  const { user } = useAuth();

  /* MODULE */
  const moduloZanthus = useMemo(() => new moduleExternalZanthus(user,0), [user]);

  /* MODAL STATES */
  const [modalOpen, setModalOpen] = useState(false);
  const [selectedProdutoId, setSelectedProdutoId] = useState<string | null>(null);

  /* STATES SCREEN */
  const [ActionStatus, setActionStatus] = useState<number>(0);

  /* STATES FILTERS */
  const [filterCodMercadoria, setFilterCodMercadoria] = usePersistedState<string>('filterCodMercadoria', '');
  const [filterDescricao, setFilterDescricao] = usePersistedState<string>('filterDescricao', '');
  const [filterVenda, setFilterVenda] = usePersistedState<boolean>('filterVenda', false);
  const [filterDataVendaIni, setFilterDataVendaIni] = usePersistedState<Date | null>('filterDataVendaIni', new Date());
  const [filterEcf, setFilterEcf] = usePersistedState<string>('filterEcf', '');
  const [filterNumeroCupom, setFilterNumeroCupom] = usePersistedState<string>('filterNumeroCupom', '');
  const [filterNumeroNf, setFilterNumeroNf] = usePersistedState<string>('filterNumeroNf', '');
  

  /* STATES LIST */
  const [TabRegraIcmsLista, setTabRegraIcmsList] = usePersistedState<any[]>('TabRegraIcmsLista', []);

  const consultarProdutos = async () => {
    const parametro: any = {};

    if (filterCodMercadoria === "" && !filterVenda && filterDescricao === "") {
      alert("Por favor, preencha pelo menos um filtro para realizar a consulta.");
      return;
    }

    if (filterCodMercadoria) parametro.cod_mercadoria = filterCodMercadoria;
    if (filterDescricao) parametro.descricao = filterDescricao.toUpperCase();

    if (filterVenda) {
      parametro.filtrar_data_venda = 1;
      if (filterDataVendaIni) parametro.data_venda_ini = filterDataVendaIni.toISOString().split('T')[0];
      if (filterDataVendaIni) parametro.data_venda_fim = filterDataVendaIni.toISOString().split('T')[0];
      if (filterEcf) parametro.ecf = filterEcf;
      if (filterNumeroCupom) parametro.numero_cupom = filterNumeroCupom;
      if (filterNumeroNf) parametro.numero_nf = filterNumeroNf;
    }

    try {
      setActionStatus(1);
      const response = await moduloZanthus.getlistTabRegraIcms(parametro);
      setTabRegraIcmsList(Array.isArray(response) ? response : []);
    } finally {
      setActionStatus(0);
    }
  };

  const handleOpenModal = (cod_mercadoria: string) => {
    setSelectedProdutoId(cod_mercadoria);
    setModalOpen(true);
  };

  const dadosGraficoOrigem = useMemo<DadosGraficoOrigem>(() => {
    if (!Array.isArray(TabRegraIcmsLista) || TabRegraIcmsLista.length === 0) {
      return { categorias: [], valores: [], total: 0 };
    }

    const contagemPorOrigem: Record<string, number> = {};

    for (const item of TabRegraIcmsLista) {
      const origem = String(item?.origem_cadastro ?? 'SEM ORIGEM').trim() || 'SEM ORIGEM';
      contagemPorOrigem[origem] = (contagemPorOrigem[origem] ?? 0) + 1;
    }

  const ordenado: Array<[string, number]> = Object.keys(contagemPorOrigem)
  .map((origem): [string, number] => [origem, contagemPorOrigem[origem] ?? 0])
  .sort((a, b) => b[1] - a[1]);

    const categorias = ordenado.map((item) => item[0]);
    const valores = ordenado.map((item) => item[1]);
    const total = valores.reduce((acc, v) => acc + v, 0);

    return { categorias, valores, total };
  }, [TabRegraIcmsLista]);

  const chartOptionsOrigem: any = {
    chart: {
      type: 'bar',
      height: 360,
      toolbar: {
        show: true,
        tools: {
          download: true,
          selection: false,
          zoom: false,
          zoomin: false,
          zoomout: false,
          pan: false,
          reset: false
        }
      }
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: '60%',
        borderRadius: 4,
        dataLabels: { position: 'top' }
      }
    },
    dataLabels: {
      enabled: true,
      formatter: (val: number) => String(val),
      offsetY: -18,
      style: {
        fontSize: '12px',
        colors: ['#304758']
      }
    },
    xaxis: {
      categories: dadosGraficoOrigem.categorias,
      title: { text: 'Tipo de Origem' }
    },
    yaxis: {
      title: { text: 'Quantidade de Mercadorias' },
      labels: {
        formatter: (val: number) => String(Math.round(val))
      }
    },
    title: {
      text: 'Mercadorias por Tipo de Origem',
      align: 'center',
      style: {
        fontSize: '16px',
        fontWeight: 'bold',
        color: '#374151'
      }
    },
    colors: ['#3B82F6'],
    grid: {
      show: true,
      borderColor: '#E5E7EB',
      position: 'back'
    }
  };

  const chartSeriesOrigem = [
    {
      name: 'Quantidade',
      data: dadosGraficoOrigem.valores
    }
  ];

  return (
    <div className="min-h-screen bg-gray-50 p-6">
      <div className="max-w-7xl mx-auto">
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Zanthus | Tab Regra ICMS">
          <div className="flex space-x-2">
            <ButtonPag
              TypeButton="_BUTTON_HEADER"
              label="Pesquisar"
              TypeIcon="_PESQUISAR"
              title="Pesquisar"
              onClick={consultarProdutos}
            />
          </div>
        </HeaderMain>

        {/* Área de Filtros */}
        <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
          <div className="space-y-6">
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-6 gap-4">
              <div className="lg:col-span-2">
                <label className="block text-sm font-medium text-gray-700 mb-1">
                  GTIN
                </label>
                <input
                  type="text"
                  className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                  placeholder="Filtrar por código da mercadoria"
                  value={filterCodMercadoria}
                  onChange={(e) => setFilterCodMercadoria(e.target.value)}
                />
              </div>
              <div className="lg:col-span-2">
                <label className="block text-sm font-medium text-gray-700 mb-1">
                  Descrição da Mercadoria
                </label>
                <input
                  type="text"
                  className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                  placeholder="Filtrar por descrição da mercadoria"
                  value={filterDescricao}
                  onChange={(e) => setFilterDescricao(e.target.value)}
                />
              </div>              
            </div>

            <div>
              <div className="mb-3">
                <input
                  id="filtrar-venda"
                  type="checkbox"
                  className="h-4 w-4 text-purple-600 border-gray-300 rounded focus:ring-purple-500"
                  checked={filterVenda}
                  onChange={(e) => setFilterVenda(e.target.checked)}
                />
                <label htmlFor="filtrar-venda" className="ml-2 text-sm text-gray-700 font-semibold">
                  Filtrar por Data de Venda
                </label>
              </div>

              <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4">
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Data</label>
                  <input
                    type="date"
                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                    value={filterDataVendaIni ? filterDataVendaIni.toISOString().substring(0, 10) : ""}
                    onChange={(e) => setFilterDataVendaIni(e.target.value ? new Date(e.target.value) : null)}
                    disabled={!filterVenda}
                  />
                </div>

                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">ECF</label>
                  <input
                    type="text"
                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                    placeholder="ECF"
                    value={filterEcf}
                    onChange={(e) => setFilterEcf(e.target.value)}
                    disabled={!filterVenda}
                  />
                </div>

                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Número do Cupom</label>
                  <input
                    type="text"
                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                    placeholder="Número do Cupom"
                    value={filterNumeroCupom}
                    onChange={(e) => setFilterNumeroCupom(e.target.value)}
                    disabled={!filterVenda}
                  />
                </div>

                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Nota Fiscal</label>
                  <input
                    type="text"
                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                    placeholder="Nota Fiscal"
                    value={filterNumeroNf}
                    onChange={(e) => setFilterNumeroNf(e.target.value)}
                    disabled={!filterVenda}
                  />
                </div>
              </div>
            </div>
          </div>
        </div>

        {/* Grid de Produtos */}
        <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
          <div className="max-h-[500px] overflow-y-auto">
            <table className="min-w-full divide-y divide-gray-200">
              <thead className="bg-gray-100 sticky top-0 z-10">
                <tr>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Mercadoria</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Tipo</th>
                  <th className="px-2 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Regra</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Dados Fiscais</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Reforma</th>




                </tr>
              </thead>

              <tbody className="bg-white divide-y divide-gray-200">
                {TabRegraIcmsLista.length > 0 ? (
                  TabRegraIcmsLista.map((item) => (
                    <tr key={item.cod_regras_icms} className="hover:bg-gray-50">

                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700">
                          <div>{item.descricao}</div>
                          <div> {item.cod_mercadoria} - N. Regras: {item.regra_count}</div>
                      </td>

                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700">
                          {item.flg_revenda === 'S' ? 'Revenda' : 'Consumidor'}
                      </td>
                      
                      <td
                        className="px-2 py-2 whitespace-nowrap text-sm text-gray-700 cursor-pointer hover:text-purple-700"
                        onClick={() => handleOpenModal(item.cod_mercadoria)}
                      >
                          <div>Tipo Imposto: {item.tipo_imposto_descricao}</div>
                          <div>{item.regra_descricao} - {item.cod_regras_icms}</div>
                          <div>Tipo: {item.flg_tipo_imposto}</div>
                      </td>
                    <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700">
                      <div>
                        Cst: {item.cst_orig} - {item.cst} | Alíquota: {item.aliquota} | Redução: {item.perc_reducao}
                        {String(item.flg_tipo_imposto) === '0' && (
                          <>
                            {' '}| Cod. Ben. Fiscal: {item.codigo_beneficio_fiscal}
                            {['020', '040'].includes(String(item.cst)) &&
                              !String(item.codigo_beneficio_fiscal ?? '').trim() && (
                                <span className="ml-2 px-2 py-0.5 rounded bg-red-600 text-white text-xs font-semibold">
                                  Falta CBENEF
                                </span>
                              )}
                          </>
                        )}
                      </div>
                      <div> NCM: {item.cod_ncm_ini} - {item.cod_ncm_final} </div>
                    </td>

                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700">
                          <div> Cod Class Trib: {item.cod_class_tributaria}</div>
                          <div> Per Ibs Mono {item.per_cred_presumido_ibs_mono} | Per CBS Mono {item.per_cred_presumido_cbs_mono}</div>
                      </td>

                    </tr>
                  ))
                ) : (
                  <tr>
                    <td colSpan={19} className="px-6 py-4 text-center text-sm text-gray-500">
                      Nenhum produto encontrado com os filtros aplicados.
                    </td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        </div>

        {/* Gráfico por Origem */}
        {TabRegraIcmsLista.length > 0 && (
          <div className="bg-white rounded-lg shadow-md p-6 mt-6 mb-6 border border-purple-100">
            <div className="flex items-center justify-between mb-4">
              <h2 className="text-lg font-semibold text-gray-900">Totalização por Origem</h2>
              <span className="text-sm text-gray-500">
                {dadosGraficoOrigem.categorias.length} origem{dadosGraficoOrigem.categorias.length !== 1 ? 'ens' : ''}
              </span>
            </div>

            <Chart
              options={chartOptionsOrigem}
              series={chartSeriesOrigem}
              type="bar"
              height={360}
            />
          </div>
        )}

        {/* Total de Registros */}
        <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
          <div className="flex justify-between items-center">
            <h3 className="text-mg font-medium text-gray-500">Total de Registros</h3>
            <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
              {TabRegraIcmsLista.length} produto{TabRegraIcmsLista.length !== 1 ? 's' : ''}
            </span>
          </div>
        </div>

        {/* Modal de Mercadoria */}
        {modalOpen && selectedProdutoId && (
          <ModalZanthusMercadoria
            isOpen={modalOpen}
            gtin={selectedProdutoId}
            onClose={() => setModalOpen(false)}
          />
        )}
      </div>
    </div>
  );
}

