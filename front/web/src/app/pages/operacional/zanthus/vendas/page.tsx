'use client'

import { useState, useMemo, useEffect } from 'react'
import dynamic from 'next/dynamic'
import { useAuth } from '../../../../context/context'
import { moduleFatutamentoZanthus, tpFaturamentoZanthusCupom, tpFaturamentoZanthusTipoNota, tpFaturamentoZanthusStatus_Cancelado } from '@/api/m0055_faturamentoZanthus/moduleFaturamentoZanthus'

// Importar ApexCharts dinamicamente para evitar problemas de SSR
const Chart = dynamic(() => import('react-apexcharts'), { ssr: false })

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";
import CupomModal from "./modalcupom";

// Tipo para controle de ordenação
type SortConfig = {
  key: keyof tpFaturamentoZanthusCupom | null;
  direction: 'asc' | 'desc';
}

export default function ConsultaCupomFiscalPage() {
  
  //Filtros
  const [data, setData] = useState<string>(new Date().toISOString().split('T')[0])
  const [cpfCnpj, setCpfCnpj] = useState<string>('')
  const [numeroEcf, setNumeroEcf] = useState<string>('')
  const [numeroCupom, setNumeroCupom] = useState<string>('')
  const [valorinicial , setValorinicial] = useState<number>(0)
  const [valorfinal , setValorfinal] = useState<number>(0)
  const [comDesconto, setComDesconto] = useState<boolean>(false)
  const [comVoucher, setComVoucher] = useState<boolean>(false)
  const [comDescontoSemVoucher, setComDescontoSemVoucher] = useState<boolean>(false)
  const [tiponota, setTiponota] = useState<tpFaturamentoZanthusTipoNota>({ tiponota: 999, tiponota_descricao: 'Todas' })
  const [status, setStatus] = useState<tpFaturamentoZanthusStatus_Cancelado>({ status_cancelado: 999, status_cancelado_descriao: 'Todas' })
  const [tiponotaLista, setTiponotaLista] = useState<tpFaturamentoZanthusTipoNota[]>([])
  const [statusLista, setStatusLista] = useState<tpFaturamentoZanthusStatus_Cancelado[]>([])

  //List
  const [cupons, setCupons] = useState<tpFaturamentoZanthusCupom[]>([])
  
  //screen
  const [loading, setLoading] = useState<boolean>(false)
  const [error, setError] = useState<string | null>(null)

  // Estado para controle de ordenação
  const [sortConfig, setSortConfig] = useState<SortConfig>({ key: null, direction: 'asc' })

  const [ActionStatus, setActionStatus] = useState(0);

  // Estados para o modal de cupom
  const [modalCupomOpen, setModalCupomOpen] = useState<boolean>(false);
  const [cupomSelecionado, setCupomSelecionado] = useState<{
    ecf: number;
    numeroCupom: string;
    dataCupom: string;
  } | null>(null);

  const { user } = useAuth();
  let moduleFaturamentoZanthus = new moduleFatutamentoZanthus(user)

  // Função para abrir o modal de cupom
  const abrirModalCupom = (cupom: tpFaturamentoZanthusCupom) => {
    setCupomSelecionado({
      ecf: cupom.ecf,
      numeroCupom: cupom.numero_cupom.toString(),
      dataCupom: new Date(cupom.data).toISOString().split('T')[0]
    });
    setModalCupomOpen(true);
  };

  // Função para fechar o modal de cupom
  const fecharModalCupom = () => {
    setModalCupomOpen(false);
    setCupomSelecionado(null);
  };

  // Limpar dados quando os filtros mudarem
  useEffect(() => {
    // Limpar cupons e erros quando qualquer filtro for alterado

    if (moduleFaturamentoZanthus.TipoNotaLista !== tiponotaLista) {
      setTiponotaLista(moduleFaturamentoZanthus.TipoNotaLista);
    }

    if (moduleFaturamentoZanthus.TipoCancelamentoLista !== statusLista) {
      setStatusLista(moduleFaturamentoZanthus.TipoCancelamentoLista);
    }

    if (cupons.length > 0) {
      setCupons([]);
    }
    if (error) {
      setError(null);
    }
  }, [data, cpfCnpj, numeroEcf, valorinicial, valorfinal, comDesconto, comVoucher, comDescontoSemVoucher]);

  // Dados processados para o gráfico por ECF
  const dadosGrafico = useMemo(() => {
    if (cupons.length === 0) return { categorias: [], valores: [], totalGeral: 0 };

    // Agrupar por ECF e somar valores
    const agrupamentoPorEcf = cupons.reduce((acc, cupom) => {
      const ecf = cupom.ecf || 'S/ECF';
      if (!acc[ecf]) {
        acc[ecf] = 0;
      }
      // Garantir que o valor seja um número válido
      const valor = Number(cupom.valor_efetivo) || 0;
      acc[ecf] += valor;
      return acc;
    }, {} as Record<string, number>);

    // Ordenar por valor decrescente
    const ecfsOrdenados = Object.entries(agrupamentoPorEcf)
      .sort(([, a], [, b]) => b - a);

    const categorias = ecfsOrdenados.map(([ecf]) => `ECF ${ecf}`);
    const valores = ecfsOrdenados.map(([, valor_efetivo]) => valor_efetivo);
    const totalGeral = valores.reduce((acc, val) => acc + val, 0);

    return { categorias, valores, totalGeral };
  }, [cupons]);

  // Dados processados para cupons cancelados
  const dadosCancelados = useMemo(() => {
    if (cupons.length === 0) return { quantidadeCancelados: 0, valorCancelados: 0, totalCupons: 0 };

    const cancelados = cupons.filter(cupom => cupom.status_cancelado === 1);
    const valorCancelados = cancelados.reduce((acc, cupom) => {
      const valor = Number(cupom.valor) || 0;
      return acc + valor;
    }, 0);

    return {
      quantidadeCancelados: cancelados.length,
      valorCancelados: valorCancelados,
      totalCupons: cupons.length
    };
  }, [cupons]);

  // Configuração do gráfico por ECF
  const chartOptionsEcf = {
    chart: {
      type: 'bar' as const,
      height: 400,
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
        dataLabels: {
          position: 'top'
        }
      }
    },
    dataLabels: {
      enabled: true,
      formatter: function(val: number) {
        return new Intl.NumberFormat('pt-BR', {
          minimumFractionDigits: 2,
          maximumFractionDigits: 2
        }).format(val);
      },
      offsetY: -20,
      style: {
        fontSize: '12px',
        colors: ['#304758']
      }
    },
    xaxis: {
      categories: dadosGrafico.categorias,
      title: {
        text: 'ECFs'
      }
    },
    yaxis: {
      title: {
        text: 'Valor Total (R$)'
      },
      labels: {
        formatter: function(val: number) {
          return new Intl.NumberFormat('pt-BR', {
            style: 'currency',
            currency: 'BRL'
          }).format(val);
        }
      }
    },
    title: {
      text: 'Totalização por ECF',
      align: 'center' as const,
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
      strokeDashArray: 0,
      position: 'back' as const
    },
    tooltip: {
      y: {
        formatter: function(val: number) {
          return new Intl.NumberFormat('pt-BR', {
            style: 'currency',
            currency: 'BRL'
          }).format(val);
        }
      }
    }
  };

  const chartSeriesEcf = [{
    name: 'Valor Total',
    data: dadosGrafico.valores
  }];

  const consultarCupom = async () => {
    if (!data) {
      setError('Data é obrigatória')
      return
    }

    setCupons([])
    setLoading(true)
    setError(null)

    try {
      const parametros = {
        filtrar_data_cupom: 1,
        data_cupom_ini: data + 'T00:00:00.000Z',
        data_cupom_fim: data + 'T23:59:59.999Z',
        ...(numeroEcf && { ecf: numeroEcf }),
        ...(cpfCnpj && { cpf_cnpj: cpfCnpj }),
        ...(numeroCupom && { numero_cupom: numeroCupom }),
        ...(valorinicial > 0 && { valor_inicial: valorinicial }),
        ...(valorfinal > 0 && { valor_final: valorfinal }),
        ...(comDesconto && { com_desconto: 1 }),
        ...(comVoucher && { com_voucher: 1 }),
        ...(comDescontoSemVoucher && { comDescontoSemVoucher: 1 }),
        ...(tiponota.tiponota !== 999 && { tipo_nota: tiponota.tiponota }),
        ...(status.status_cancelado !== 999 && { status_cancelado: status.status_cancelado })
      }
      setActionStatus(1)
      const response = await moduleFaturamentoZanthus.getCupom(parametros)
      setActionStatus(0)
      
      if (response) {
        setCupons(response)
      } else {
        setError('Erro ao consultar cupons fiscais')
      }
    } catch (err) {
      setError('Erro interno do sistema')
      console.error('Erro na consulta:', err)
    } finally {
      setLoading(false)
    }
  }

  const formatCurrency = (value: number) => {
    // Verificar se o valor é um número válido
    if (isNaN(value) || value === null || value === undefined) {
      return '0,00';
    }
    
    return new Intl.NumberFormat('pt-BR', {
      minimumFractionDigits: 2,
      maximumFractionDigits: 2
    }).format(value);
  }

  const formatarData = (data: Date) => {
    return new Date(data).toLocaleDateString('pt-BR');
  };

  const formatarHora = (hora: string | Date) => {
    if (!hora) return '';
    
    // Se for uma string no formato "HH:MM:SS" ou "HH:MM"
    if (typeof hora === 'string') {
      // Se já está no formato correto (HH:MM:SS ou HH:MM)
      if (hora.includes(':')) {
        const parts = hora.split(':');
        if (parts.length >= 2) {
          return `${parts[0].padStart(2, '0')}:${parts[1].padStart(2, '0')}`;
        }
      }
      
      // Se for uma string de números (HHMMSS ou HHMM)
      if (/^\d+$/.test(hora)) {
        if (hora.length === 6) {
          // HHMMSS
          return `${hora.substring(0, 2)}:${hora.substring(2, 4)}`;
        } else if (hora.length === 4) {
          // HHMM
          return `${hora.substring(0, 2)}:${hora.substring(2, 4)}`;
        }
      }
      
      return hora;
    }
    
    // Se for um objeto Date
    if (hora instanceof Date) {
      return hora.toLocaleTimeString('pt-BR', {
        hour: '2-digit',
        minute: '2-digit'
      });
    }
    
    return '';
  };

  const formatCpfCnpj = (doc: string) => {
    if (!doc) return ''
    
    if (doc.length === 11) {
      return doc.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1.$2.$3-$4')
    } else if (doc.length === 14) {
      return doc.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, '$1.$2.$3/$4-$5')
    }
    
    return doc
  }

  // Função para lidar com a ordenação
  const handleSort = (key: keyof tpFaturamentoZanthusCupom) => {
    let direction: 'asc' | 'desc' = 'asc';
    
    if (sortConfig.key === key && sortConfig.direction === 'asc') {
      direction = 'desc';
    }
    
    setSortConfig({ key, direction });
  }

  // Função para obter o ícone de ordenação
  const getSortIcon = (columnKey: keyof tpFaturamentoZanthusCupom) => {
    if (sortConfig.key !== columnKey) {
      return (
        <svg className="w-4 h-4 text-gray-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M7 16V4m0 0L3 8m4-4l4 4m6 0v12m0 0l4-4m-4 4l-4-4" />
        </svg>
      );
    }
    
    return sortConfig.direction === 'asc' ? (
      <svg className="w-4 h-4 text-blue-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M5 15l7-7 7 7" />
      </svg>
    ) : (
      <svg className="w-4 h-4 text-blue-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M19 9l-7 7-7-7" />
      </svg>
    );
  }

  // Dados dos cupons ordenados
  const cuponsSorted = useMemo(() => {
    if (!sortConfig.key) return cupons;

    return [...cupons].sort((a, b) => {
      const aValue = a[sortConfig.key!];
      const bValue = b[sortConfig.key!];
      
      // Campos que devem ser tratados como números
      const numericFields: (keyof tpFaturamentoZanthusCupom)[] = [
        'numero_cupom',
        'nf_numero', 
        'nf_chave',
        'item_qtde',
        'item_valor',
        'item_desconto',
        'valor_efetivo',
        'voucher_valor',
        'voucher_numero_itens'
      ];
      
      // Tratamento especial para diferentes tipos de dados
      let comparison = 0;
      
      if (numericFields.includes(sortConfig.key as keyof tpFaturamentoZanthusCupom)) {
        // Converter para número, tratando valores nulos/undefined como 0
        const aNum = Number(aValue) || 0;
        const bNum = Number(bValue) || 0;
        comparison = aNum - bNum;
      } else if (typeof aValue === 'number' && typeof bValue === 'number') {
        comparison = aValue - bValue;
      } else if (aValue instanceof Date && bValue instanceof Date) {
        comparison = aValue.getTime() - bValue.getTime();
      } else {
        // Para strings e outros tipos
        const aStr = String(aValue || '').toLowerCase();
        const bStr = String(bValue || '').toLowerCase();
        comparison = aStr.localeCompare(bStr);
      }
      
      return sortConfig.direction === 'desc' ? comparison * -1 : comparison;
    });
  }, [cupons, sortConfig]);

  // Componente para cabeçalho clicável
  const SortableHeader = ({ 
    children, 
    sortKey, 
    align = 'left' 
}: { 
  children: React.ReactNode; 
  sortKey: keyof tpFaturamentoZanthusCupom;
  align?: 'left' | 'right' | 'center';
}) => {
  const isActive = sortConfig.key === sortKey;
  
  return (
    <th 
      className={`px-6 py-3 text-${align} text-xs font-medium text-gray-500 uppercase tracking-wider cursor-pointer hover:bg-gray-300 transition-colors duration-200 select-none ${
        isActive 
          ? 'bg-blue-100 text-blue-700 font-semibold' 
          : 'bg-gray-100'
      }`}
      onClick={() => handleSort(sortKey)}
    >
      <div className={`flex items-center ${align === 'right' ? 'justify-end' : align === 'center' ? 'justify-center' : 'justify-start'} space-x-1`}>
        <span>{children}</span>
        {getSortIcon(sortKey)}
      </div>
    </th>
  );
  }

  return (
    <div className="p-6">
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Faturamento | Zanthus" >
          <div className="flex space-x-2">
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={consultarCupom} ></ButtonPag>
          </div>
        </HeaderMain>

      <div className="bg-white rounded-lg shadow-sm border border-gray-200 mb-6">
        <div className="p-6">
          <h2 className="text-lg font-semibold text-gray-900 mb-4">
            Filtros de Consulta
          </h2>
          
          <div className="grid grid-cols-1 md:grid-cols-12 gap-4 mb-4">
            <div className="w-full flex flex-col md:col-span-2">
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Data do Cupom *
              </label>
              <input
                type="date"
                value={data}
                onChange={(e) => setData(e.target.value)}
                required
                className="w-full px-3 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent"
              />
            </div>

            <div className="w-full flex flex-col md:col-span-1">
              <label className="block text-sm font-medium text-gray-700 mb-2">
                ECF
              </label>
              <input
                type="text"
                value={numeroEcf}
                onChange={(e) => setNumeroEcf(e.target.value.replace(/\D/g, ''))}
                placeholder="ECF"
                maxLength={3}
                className="w-full px-1 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent text-center"
              />
            </div>
            <div className="w-full flex flex-col md:col-span-1">
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Número Cupom
              </label>
              <input
                type="text"
                value={numeroCupom}
                onChange={(e) => setNumeroCupom(e.target.value.replace(/\D/g, ''))}
                placeholder="N. Cupom"
                maxLength={7}
                className="w-full px-3 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent text-center"
              />
            </div>            

            <div className="w-full flex flex-col md:col-span-2">
              <label className="block text-sm font-medium text-gray-700 mb-2">
                CPF/CNPJ
              </label>
              <input
                type="text"
                value={cpfCnpj}
                onChange={(e) => setCpfCnpj(e.target.value)}
                placeholder="Digite o CPF ou CNPJ"
                maxLength={18}
                className="w-full px-2 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent"
              />
            </div>

            <div className="w-full flex flex-col md:col-span-1">
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Valor Inicial
              </label>
              <input
                type="number"
                value={valorinicial || ''}
                onChange={(e) => setValorinicial(e.target.value ? parseFloat(e.target.value) : 0)}
                placeholder="0,00"
                min="0"
                step="0.01"
                className="w-full px-2 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent text-right"
              />
            </div>

            <div className="w-full flex flex-col md:col-span-1">
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Valor Final
              </label>
              <input
                type="number"
                value={valorfinal || ''}
                onChange={(e) => setValorfinal(e.target.value ? parseFloat(e.target.value) : 0)}
                placeholder="0,00"
                min="0"
                step="0.01"
                className="w-full px-2 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent text-right"
              />
            </div>
            
            <div className="w-full flex flex-col md:col-span-2">
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Tipo Nota
              </label>
              <select
                value={tiponota.tiponota}
                onChange={(e) => {
                  const selectedValue = parseInt(e.target.value);
                  const selectedTipo = tiponotaLista.find(t => t.tiponota === selectedValue) || { tiponota: 999, tiponota_descricao: 'Todas' };
                  setTiponota(selectedTipo);
                }}
                className="w-full px-2 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent"
              >
                <option value={0}>Todas</option>
                {tiponotaLista.map((tipo) => (
                  <option key={tipo.tiponota} value={tipo.tiponota}>
                    {tipo.tiponota_descricao}
                  </option>
                ))}
              </select>
            </div>

            <div className="w-full flex flex-col md:col-span-2">
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Status Cupom
              </label>
              <select
                value={status.status_cancelado}
                onChange={(e) => {
                  const selectedValue = parseInt(e.target.value);
                  const selectedStatus = statusLista.find(s => s.status_cancelado === selectedValue) || { status_cancelado: 999, status_cancelado_descriao: 'Todas' };
                  setStatus(selectedStatus);
                }}
                className="w-full px-3 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent"
              >
                <option value={999}>Todas</option>
                {statusLista.map((statusItem) => (
                  <option key={statusItem.status_cancelado} value={statusItem.status_cancelado}>
                    {statusItem.status_cancelado_descriao}
                  </option>
                ))}
              </select>
            </div>
          </div>

          {/* Segunda linha com os checkboxes */}
          <div className="grid grid-cols-1 sm:grid-cols-3 gap-4 mb-4">
            <div>
              <div className={`${comDescontoSemVoucher ? 'bg-gray-100 border-gray-200' : 'bg-blue-50 border-blue-200'} border rounded-lg p-3 transition-colors duration-200`}>
                <label className="flex items-center space-x-3 cursor-pointer">
                  <input
                    type="checkbox"
                    checked={comDesconto}
                    disabled={comDescontoSemVoucher}
                    onChange={(e) => setComDesconto(e.target.checked)}
                    className={`w-5 h-5 ${comDescontoSemVoucher ? 'text-gray-400 bg-gray-100 border-gray-300' : 'text-blue-600 bg-white border-blue-300'} border-2 rounded focus:ring-blue-500 focus:ring-2 disabled:cursor-not-allowed`}
                  />
                  <div className="flex items-center space-x-2">
                    <span className={comDescontoSemVoucher ? 'text-gray-400' : 'text-blue-600'}>
                      <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M7 7h.01M7 3h5c.512 0 1.024.195 1.414.586l7 7a2 2 0 010 2.828l-7 7a2 2 0 01-2.828 0l-7-7A1.994 1.994 0 013 12V7a4 4 0 014-4z" />
                      </svg>
                    </span>
                    <span className={`text-sm font-medium ${comDescontoSemVoucher ? 'text-gray-400' : 'text-blue-700'}`}>Com Desconto</span>
                  </div>
                </label>
              </div>
            </div>

            <div>
              <div className={`${comDescontoSemVoucher ? 'bg-gray-100 border-gray-200' : 'bg-green-50 border-green-200'} border rounded-lg p-3 transition-colors duration-200`}>
                <label className="flex items-center space-x-3 cursor-pointer">
                  <input
                    type="checkbox"
                    checked={comVoucher}
                    disabled={comDescontoSemVoucher}
                    onChange={(e) => setComVoucher(e.target.checked)}
                    className={`w-5 h-5 ${comDescontoSemVoucher ? 'text-gray-400 bg-gray-100 border-gray-300' : 'text-green-600 bg-white border-green-300'} border-2 rounded focus:ring-green-500 focus:ring-2 disabled:cursor-not-allowed`}
                  />
                  <div className="flex items-center space-x-2">
                    <span className={comDescontoSemVoucher ? 'text-gray-400' : 'text-green-600'}>
                      <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M15 5v2m0 4v2m0 4v2M5 5a2 2 0 00-2 2v3a2 2 0 110 4v3a2 2 0 002 2h14a2 2 0 002-2v-3a2 2 0 110-4V7a2 2 0 00-2-2H5z" />
                      </svg>
                    </span>
                    <span className={`text-sm font-medium ${comDescontoSemVoucher ? 'text-gray-400' : 'text-green-700'}`}>Com Voucher</span>
                  </div>
                </label>
              </div>
            </div>

            <div>
              <div className="bg-orange-50 border border-orange-200 rounded-lg p-3">
                <label className="flex items-center space-x-3 cursor-pointer">
                  <input
                    type="checkbox"
                    checked={comDescontoSemVoucher}
                    onChange={(e) => {
                      setComDescontoSemVoucher(e.target.checked);
                      if (e.target.checked) {
                        setComDesconto(false);
                        setComVoucher(false);
                      }
                    }}
                    className="w-5 h-5 text-orange-600 bg-white border-2 border-orange-300 rounded focus:ring-orange-500 focus:ring-2"
                  />
                  <div className="flex items-center space-x-2">
                    <span className="text-orange-600">
                      <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M20 12H4m16 0l-4 4m4-4l-4-4M9 12l-3-3m0 0l3-3m-3 3h12" />
                      </svg>
                    </span>
                    <span className="text-sm font-medium text-orange-700">Com Desconto sem Voucher</span>
                  </div>
                </label>
              </div>
            </div>
          </div>
          

          {error && (
            <div className="mt-4 p-4 bg-red-50 border border-red-200 rounded-md">
              <p className="text-red-700 text-sm">{error}</p>
            </div>
          )}
        </div>
      </div>

      {cupons.length > 0 && (
        <>
          {/* TABELA DE RESULTADOS */}
          <div className="bg-white rounded-lg shadow-sm border border-gray-200 mb-6">
            <div className="p-6">
              <h2 className="text-lg font-semibold text-gray-900 mb-4">
                {cupons.length} Registros Encontrados
                {sortConfig.key && (
                  <span className="text-sm text-gray-500 ml-2">
                    (ordenado por {sortConfig.key} - {sortConfig.direction === 'asc' ? 'crescente' : 'decrescente'})
                  </span>
                )}
              </h2>
              
              <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
                <div className="max-h-[500px] overflow-y-auto">
                  <table className="min-w-full divide-y divide-gray-200">
                      <thead className="bg-gray-100 sticky top-0 z-20 shadow-sm">
                        <tr>
                          <SortableHeader sortKey="ecf">Pdv</SortableHeader>
                          <SortableHeader sortKey="operador_nome">Operador</SortableHeader>
                          <SortableHeader sortKey="numero_cupom">Número do Cupom</SortableHeader>
                          <SortableHeader sortKey="status_cancelado_descricao">Status</SortableHeader>
                          <SortableHeader sortKey="data">Data/Hora</SortableHeader>
                          <SortableHeader sortKey="nf_numero">Número Nf</SortableHeader>
                          <SortableHeader sortKey="nf_chave">Chave Nf</SortableHeader>
                          <SortableHeader sortKey="tiponota_descricao">Nf Tipo/Status</SortableHeader>
                          <SortableHeader sortKey="cpf_cnpj">CPF/CNPJ</SortableHeader>
                          <SortableHeader sortKey="item_qtde" align="right">Itens</SortableHeader>
                          <SortableHeader sortKey="item_valor" align="right">Valor Base</SortableHeader>
                          <SortableHeader sortKey="item_desconto" align="right">Valor Desconto</SortableHeader>
                          <SortableHeader sortKey="valor_efetivo" align="right">Valor efetivo</SortableHeader>
                          <SortableHeader sortKey="voucher">Voucher</SortableHeader>
                          <SortableHeader sortKey="voucher_valor" align="right">Voucher Valor</SortableHeader>
                          <SortableHeader sortKey="voucher_numero_itens" align="right">Voucher N. Itens</SortableHeader>
                        </tr>
                      </thead>
                      <tbody className="bg-white divide-y divide-gray-200">
                        {cuponsSorted.map((cupom, index) => (
                          <tr key={`cupom-${cupom.id || index}-${cupom.numero_cupom || 'sem-numero'}-${index}`} className="hover:bg-gray-50">
                            <td className="px-3 py-4 whitespace-nowrap text-sm font-medium text-gray-500">
                              {cupom.ecf}
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-500">
                              {cupom.operador_nome}
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm font-medium">
                              <button
                                onClick={() => abrirModalCupom(cupom)}
                                className="text-blue-600 hover:text-blue-800 hover:underline font-medium cursor-pointer transition-colors duration-200 flex items-center space-x-1"
                                title="Clique para ver os itens do cupom"
                              >
                                <span>{cupom.numero_cupom}</span>
                                <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M9 12h6m-6 4h6m2 5H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
                                </svg>
                              </button>
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
                              {cupom.status_cancelado_descricao}
                            </td>                            
                            <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                              {formatarData(cupom.data)} {formatarHora(cupom.hora_ini)}
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
                              {cupom.nf_numero}
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
                              {cupom.nf_chave}
                            </td>         
                            <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
                              {cupom.tiponota_descricao}
                            </td>                                                                                    
                            <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                              {formatCpfCnpj(cupom.cpf_cnpj)}
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-900 text-right">
                              {cupom.item_qtde}
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-900 text-right">
                              {formatCurrency(cupom.item_valor)}
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-900 text-right">
                              {formatCurrency(cupom.item_desconto)}
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-900 text-right">
                              {formatCurrency(cupom.valor_efetivo)}
                            </td>                            
                            <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
                              {cupom.voucher}
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-900 text-right">
                              {formatCurrency(cupom.voucher_valor)}
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-900 text-right">
                              {cupom.voucher_numero_itens}
                            </td>
                          </tr>
                        ))}
                      </tbody>
                    </table>
                  </div>
                </div>
            </div>
          </div>

                    {/* GRÁFICOS DE ANÁLISE */}
          <div className="bg-white rounded-lg shadow-sm border border-gray-200 mb-6">
            <div className="p-6">
              <div className="mb-4 flex justify-between items-center">
                <h2 className="text-lg font-semibold text-gray-900">
                  Totalização
                </h2>
                
              </div>
              
              {/* Grid com os dois gráficos */}
              <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
                {/* Gráfico por ECF */}
                <div className="w-full">
                  {dadosGrafico.categorias.length > 0 ? (
                    <Chart
                      options={chartOptionsEcf}
                      series={chartSeriesEcf}
                      type="bar"
                      height={400}
                    />
                  ) : (
                    <div className="text-center py-8">
                      <p className="text-gray-500">Nenhum dado disponível para o gráfico por ECF</p>
                    </div>
                  )}
                </div>

                {/* Cards de Resumo */}
                <div className="w-full space-y-4">
                  {/* Card Total Geral */}
                  <div className="bg-gradient-to-r from-blue-50 to-blue-100 rounded-lg p-6 border-l-4 border-blue-500">
                    <div className="text-center">
                      <h3 className="text-lg font-semibold text-blue-700 mb-4">
                        Resumo Geral
                      </h3>
                      
                      <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                        <div className="bg-white rounded-lg p-4 shadow-sm">
                          <div className="text-2xl font-bold text-blue-600">
                            {dadosCancelados.totalCupons}
                          </div>
                          <div className="text-sm text-gray-600">
                            Total Geral de REgistros
                          </div>
                        </div>
                        
                        <div className="bg-white rounded-lg p-4 shadow-sm">
                          <div className="text-2xl font-bold text-blue-600">
                            R$ {formatCurrency(dadosGrafico.totalGeral)}
                          </div>
                          <div className="text-sm text-gray-600">
                            Valor Total Efetivo
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>

                  {/* Card de Cupons Cancelados */}
                  <div className="bg-gradient-to-r from-red-50 to-red-100 rounded-lg p-6 border-l-4 border-red-500">
                    <div className="text-center">
                      <h3 className="text-lg font-semibold text-red-700 mb-4">
                        Cupons Cancelados
                      </h3>
                      
                      <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                        <div className="bg-white rounded-lg p-4 shadow-sm">
                          <div className="text-2xl font-bold text-red-600">
                            {dadosCancelados.quantidadeCancelados}
                          </div>
                          <div className="text-sm text-gray-600">
                            Quantidade de Cupons
                          </div>
                          <div className="text-xs text-gray-500 mt-1">
                            de {dadosCancelados.totalCupons} total
                          </div>
                        </div>
                        
                        <div className="bg-white rounded-lg p-4 shadow-sm">
                          <div className="text-2xl font-bold text-red-600">
                            R$ {formatCurrency(dadosCancelados.valorCancelados)}
                          </div>
                          <div className="text-sm text-gray-600">
                            Valor Total Cancelado
                          </div>
                          <div className="text-xs text-gray-500 mt-1">
                            {dadosCancelados.quantidadeCancelados === 0 
                              ? '0% do total'
                              : `${((dadosCancelados.quantidadeCancelados / dadosCancelados.totalCupons) * 100).toFixed(1)}% do total`
                            }
                          </div>
                        </div>
                      </div>
                      
                      {dadosCancelados.quantidadeCancelados === 0 && (
                        <div className="mt-4 text-green-600 font-medium">
                          🎉 Nenhum cupom cancelado encontrado!
                        </div>
                      )}
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </>
      )}

      {!loading && cupons.length === 0 && data && (
        <div className="bg-white rounded-lg shadow-sm border border-gray-200">
          <div className="p-8 text-center">
            <div className="text-gray-400 mb-2">
              <svg className="w-12 h-12 mx-auto" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M9 12h6m-6 4h6m2 5H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
              </svg>
            </div>
            <p className="text-gray-500">
              Nenhum cupom fiscal encontrado para os filtros informados.
            </p>
          </div>
        </div>
      )}

      {/* Modal de Cupom */}
      {modalCupomOpen && cupomSelecionado && (
        <CupomModal
          isOpen={modalCupomOpen}
          onClose={fecharModalCupom}
          ecf={cupomSelecionado.ecf}
          numeroCupom={cupomSelecionado.numeroCupom}
          dataCupom={cupomSelecionado.dataCupom}
        />
      )}
    </div>
  )
}