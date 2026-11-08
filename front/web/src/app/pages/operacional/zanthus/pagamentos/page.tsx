'use client'

const SIS_AC_CD : number = 3921

import { useState, useMemo, useEffect, type ReactNode } from 'react'
import dynamic from 'next/dynamic'
import { useAuth } from '../../../../context/context'
import {
  moduleFatutamentoZanthus,
  tpFaturamentoZanthusTipoNota,
  tpFaturamentoZanthusStatus_Cancelado
} from '@/api/m0055_faturamentoZanthus/moduleFaturamentoZanthus'

import {moduleZanthus} from '@/api/external/zanthus'

import HeaderMain from '@/app/components/divs/headerMain'
import ButtonPag from '@/app/components/Buttons/button'

const Chart = dynamic(() => import('react-apexcharts'), { ssr: false })

type tpFaturamentoZanthusPagamento = {
  datafaturamento: string | Date
  ecf: number
  numerocupom: string
  nf_numero: string
  nf_serie: string
  nf_chave: string
  valor: string | number
  valor_troco: string | number
  valor_troco_x: number
  finalizadora_cd: number
  finalizadora_descricao: string
  bandeiracd: string
  sitef_codigo_autorizacao: string
  sitef_cartao_bin: string
  sitef_transacao: string
  sitef_credenciadora_cnpj: string
  sitef_bandeira_cartao: number
  sitef_tipo_cartao: string | null
  operador_codigo: string
  operador_nome: string
}

type SortConfig = {
  key: keyof tpFaturamentoZanthusPagamento | null
  direction: 'asc' | 'desc'
}

export default function ConsultaPagamentoCupomPage() {
  const { user } = useAuth()
  const moduleFaturamentoZanthus = useMemo(() => new moduleFatutamentoZanthus(user), [user])
  const mZanthus = useMemo(() => new moduleZanthus(user), [user])

  const [data, setData] = useState<string>(new Date().toISOString().split('T')[0])
  const [cpfCnpj, setCpfCnpj] = useState<string>('')
  const [numeroEcf, setNumeroEcf] = useState<string>('')
  const [numeroCupom, setNumeroCupom] = useState<string>('')
  
  const [filtrarValorCupom, setFiltrarValorCupom] = useState<number>(0)
  const [valorinicial, setValorinicial] = useState<number>(0)
  const [valorfinal, setValorfinal] = useState<number>(0)


  const [filtrarValorPgto, setFiltrarValorPgto] = useState<number>(0)
  const [valorPgtoInicial, setValorPgtoInicial] = useState<number>(0)
  const [valorPgtoFinal, setValorPgtoFinal] = useState<number>(0)


  const [filterFinalizadora_cd, setFilterFinalizadora_cd] = useState<number | null>(null)

  const [listFinalizadora, setListFinalizadora] = useState<any[]>([])

  


  const [tiponota, setTiponota] = useState<tpFaturamentoZanthusTipoNota>({
    tiponota: 999,
    tiponota_descricao: 'Todas'
  })
  const [status, setStatus] = useState<tpFaturamentoZanthusStatus_Cancelado>({
    status_cancelado: 999,
    status_cancelado_descriao: 'Todas'
  })
  const [tiponotaLista, setTiponotaLista] = useState<tpFaturamentoZanthusTipoNota[]>([])
  const [statusLista, setStatusLista] = useState<tpFaturamentoZanthusStatus_Cancelado[]>([])

  const [pagamentos, setPagamentos] = useState<tpFaturamentoZanthusPagamento[]>([])
  const [loading, setLoading] = useState<boolean>(false)
  const [error, setError] = useState<string | null>(null)
  const [sortConfig, setSortConfig] = useState<SortConfig>({ key: null, direction: 'asc' })
  const [ActionStatus, setActionStatus] = useState(0)

  useEffect(() => {
    let ativo = true

    const bindingListFinalizadora = async () => {
      try {
        const listTipoFinalizadora = (await mZanthus.getlistTabFinalizadora({})) as any[]

        if (!ativo) return

        setListFinalizadora(Array.isArray(listTipoFinalizadora) ? listTipoFinalizadora : [])
      } catch (e) {
        if (!ativo) return
        console.error('Erro ao carregar finalizadoras:', e)
        setListFinalizadora([])
      } finally {
        if (!ativo) return
        setTiponotaLista(moduleFaturamentoZanthus.TipoNotaLista)
        setStatusLista(moduleFaturamentoZanthus.TipoCancelamentoLista)
      }
    }

    bindingListFinalizadora()

    return () => {
      ativo = false
    }
  }, [mZanthus, moduleFaturamentoZanthus])

  useEffect(() => {
    if (pagamentos.length > 0) setPagamentos([])
    if (error) setError(null)
  }, [
    data,
    cpfCnpj,
    numeroEcf,
    numeroCupom,
    valorinicial,
    valorfinal,

    tiponota,
    status,
    filterFinalizadora_cd
  ])

useEffect(() => {
  setValorinicial(0)
  setValorfinal(0)
}, [filtrarValorCupom])

useEffect(() => {
  setValorPgtoInicial(0)
  setValorPgtoFinal(0)
}, [filtrarValorPgto])


  const formatarData = (value: string | Date) => {
    const d = new Date(value)
    if (Number.isNaN(d.getTime())) return ''
    return d.toLocaleDateString('pt-BR')
  }

  const formatCpfCnpj = (doc: string) => {
    if (!doc) return ''
    const digits = doc.replace(/\D/g, '')
    if (digits.length === 11) return digits.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1.$2.$3-$4')
    if (digits.length === 14) return digits.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, '$1.$2.$3/$4-$5')
    return doc
  }

  const handleSort = (key: keyof tpFaturamentoZanthusPagamento) => {
    let direction: 'asc' | 'desc' = 'asc'
    if (sortConfig.key === key && sortConfig.direction === 'asc') direction = 'desc'
    setSortConfig({ key, direction })
  }

  const getSortIcon = (columnKey: keyof tpFaturamentoZanthusPagamento) => {
    if (sortConfig.key !== columnKey) {
      return (
        <svg className="w-4 h-4 text-gray-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M7 16V4m0 0L3 8m4-4l4 4m6 0v12m0 0l4-4m-4 4l-4-4" />
        </svg>
      )
    }
    return sortConfig.direction === 'asc' ? (
      <svg className="w-4 h-4 text-blue-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M5 15l7-7 7 7" />
      </svg>
    ) : (
      <svg className="w-4 h-4 text-blue-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M19 9l-7 7-7-7" />
      </svg>
    )
  }

  const pagamentosSorted = useMemo(() => {
    if (!sortConfig.key) return pagamentos
    return [...pagamentos].sort((a, b) => {
      const aValue = a[sortConfig.key as keyof tpFaturamentoZanthusPagamento]
      const bValue = b[sortConfig.key as keyof tpFaturamentoZanthusPagamento]

      const numericFields: (keyof tpFaturamentoZanthusPagamento)[] = [
        'ecf',
        'valor',
        'valor_troco',
        'valor_troco_x',
        'finalizadora_cd',
        'sitef_bandeira_cartao'
      ]

      let comparison = 0
      if (numericFields.includes(sortConfig.key as keyof tpFaturamentoZanthusPagamento)) {
        comparison = user.toNumber(aValue) - user.toNumber(bValue)
      } else if (sortConfig.key === 'datafaturamento') {
        comparison = new Date(aValue as string).getTime() - new Date(bValue as string).getTime()
      } else {
        comparison = String(aValue ?? '').toLowerCase().localeCompare(String(bValue ?? '').toLowerCase())
      }

      return sortConfig.direction === 'desc' ? comparison * -1 : comparison
    })
  }, [pagamentos, sortConfig])

  const SortableHeader = ({
    children,
    sortKey,
    align = 'left'
  }: {
    children: ReactNode
    sortKey: keyof tpFaturamentoZanthusPagamento
    align?: 'left' | 'right' | 'center'
  }) => {
    const isActive = sortConfig.key === sortKey
    return (
      <th
        className={`px-4 py-3 text-${align} text-xs font-medium uppercase tracking-wider cursor-pointer hover:bg-gray-300 transition-colors duration-200 select-none ${
          isActive ? 'bg-blue-100 text-blue-700 font-semibold' : 'bg-gray-100 text-gray-500'
        }`}
        onClick={() => handleSort(sortKey)}
      >
        <div className={`flex items-center ${align === 'right' ? 'justify-end' : align === 'center' ? 'justify-center' : 'justify-start'} space-x-1`}>
          <span>{children}</span>
          {getSortIcon(sortKey)}
        </div>
      </th>
    )
  }

  const consultarPagamentos = async () => {
    if (!data) {
      setError('Data é obrigatória')
      return
    }

    setPagamentos([])
    setLoading(true)
    setError(null)

    try {
      const parametros = {
        filtrar_data_cupom: 1,
        data_cupom_ini: data,
        data_cupom_fim: data,
        ...(numeroEcf && { ecf: numeroEcf }),
        ...(cpfCnpj && { cpf_cnpj: cpfCnpj }),
        ...(numeroCupom && { numero_cupom: numeroCupom }),
        ...(filtrarValorCupom === 1 && { filtrarValorCupom: 1 }),
        ...(filtrarValorCupom === 1 && valorinicial > 0 && { valor_inicial: valorinicial }),
        ...(filtrarValorCupom === 1 && valorfinal > 0 && { valor_final: valorfinal }),

        ...(filtrarValorPgto === 1 && { filtrarValorPgto: 1 }),
        ...(filtrarValorPgto === 1 && valorPgtoInicial > 0 && { valor_pgto_inicial: valorPgtoInicial }),
        ...(filtrarValorPgto === 1 && valorPgtoFinal > 0 && { valor_pgto_final: valorPgtoFinal }),
        ...(tiponota.tiponota !== 999 && { tipo_nota: tiponota.tiponota }),
        ...(status.status_cancelado !== 999 && { status_cancelado: status.status_cancelado }),
        ...(filterFinalizadora_cd !== null && { finalizadora_cd: filterFinalizadora_cd }),

        
      }

      setActionStatus(1)
      const response = await moduleFaturamentoZanthus.getPagamento(parametros)
      setActionStatus(0)

      if (response) {
        setPagamentos(response as tpFaturamentoZanthusPagamento[])
      } else {
        setError('Erro ao consultar pagamentos')
      }
    } catch (e) {
      setError('Erro interno do sistema')
      console.error('Erro na consulta de pagamentos:', e)
    } finally {
      setLoading(false)
    }
  }

  const agruparValor = (items: tpFaturamentoZanthusPagamento[], keyGetter: (item: tpFaturamentoZanthusPagamento) => string) => {
    const grouped = items.reduce((acc, item) => {
      const key = keyGetter(item) || 'N/I'
      acc[key] = (acc[key] || 0) + user.toNumber(item.valor)
      return acc
    }, {} as Record<string, number>)

    const ordered = Object.entries(grouped).sort(([, a], [, b]) => b - a)
    return {
      categorias: ordered.map(([k]) => k),
      valores: ordered.map(([, v]) => Number(v.toFixed(2))),
      total: ordered.reduce((acc, [, v]) => acc + v, 0)
    }
  }

  const dadosPorEcf = useMemo(
    () => agruparValor(pagamentos, (p) => `ECF ${p.ecf ?? 'S/ECF'}`),
    [pagamentos]
  )

  const dadosPorOperador = useMemo(
    () => agruparValor(pagamentos, (p) => `${p.operador_codigo || 'S/COD'} - ${p.operador_nome || 'SEM NOME'}`),
    [pagamentos]
  )

  const dadosPorFinalizadora = useMemo(
    () => agruparValor(pagamentos, (p) => `${p.finalizadora_cd ?? 'S/COD'} - ${p.finalizadora_descricao || 'SEM DESCRICAO'}`),
    [pagamentos]
  )

  const totalTroco = useMemo(
    () => pagamentos.reduce((acc, p) => acc + user.toNumber(p.valor_troco), 0),
    [pagamentos]
  )

  const totalLiquido = useMemo(
    () => dadosPorEcf.total - totalTroco,
    [dadosPorEcf.total, totalTroco]
  )

  const resumoFinalizadora = useMemo(() => {
    if (dadosPorFinalizadora.categorias.length === 0) return null

    const categoriaTop = dadosPorFinalizadora.categorias[0]
    const valorTop = dadosPorFinalizadora.valores[0] || 0
    const participacao =
      dadosPorFinalizadora.total > 0
        ? (valorTop / dadosPorFinalizadora.total) * 100
        : 0

    return {
      categoriaTop,
      valorTop,
      participacao
    }
  }, [dadosPorFinalizadora])

  const moedaBRL = (val: unknown) => {
    const num =
      typeof val === 'number'
        ? val
        : Number(String(val ?? '').replace(',', '.'))

    if (!Number.isFinite(num)) return ''
    return new Intl.NumberFormat('pt-BR', {
      style: 'currency',
      currency: 'BRL'
    }).format(num)
  }

  const buildChartOptions = ({
    categorias,
    titulo,
    cor,
    horizontal = false
  }: {
    categorias: string[]
    titulo: string
    cor: string
    horizontal?: boolean
  }) => ({
    chart: {
      type: 'bar' as const,
      height: 380,
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
        horizontal,
        columnWidth: horizontal ? '70%' : '55%',
        borderRadius: 4,
        dataLabels: { position: 'top' }
      }
    },
    dataLabels: {
      enabled: true,
      formatter: (val: number) => moedaBRL(val),
      style: {
        fontSize: '11px',
        colors: ['#374151']
      }
    },
    xaxis: horizontal
      ? {
          categories: categorias,
          labels: {
            formatter: (val: string | number) => moedaBRL(val)
          },
          title: { text: 'Valor (R$)' }
        }
      : {
          categories: categorias,
          labels: { rotate: -35 }
        },
    yaxis: horizontal
      ? {
          labels: {
            show: true
          }
        }
      : {
          title: { text: 'Valor (R$)' },
          labels: {
            formatter: (val: number) => moedaBRL(val)
          }
        },
    title: {
      text: titulo,
      align: 'center' as const,
      style: { fontSize: '16px', fontWeight: 'bold', color: '#374151' }
    },
    colors: [cor],
    tooltip: {
      y: {
        formatter: (val: number) => moedaBRL(val)
      }
    },
    grid: {
      show: true,
      borderColor: '#E5E7EB',
      strokeDashArray: 0
    }
  })

  const chartOptionsEcf = useMemo(
    () => buildChartOptions({ categorias: dadosPorEcf.categorias, titulo: 'Total por ECF', cor: '#3B82F6' }),
    [dadosPorEcf.categorias]
  )

  const chartOptionsOperador = useMemo(
    () => buildChartOptions({ categorias: dadosPorOperador.categorias, titulo: 'Total por Operador', cor: '#10B981', horizontal: true }),
    [dadosPorOperador.categorias]
  )

  const chartOptionsFinalizadora = useMemo(
    () => buildChartOptions({ categorias: dadosPorFinalizadora.categorias, titulo: 'Total por Finalizadora', cor: '#F59E0B', horizontal: false }),
    [dadosPorFinalizadora.categorias]
  )

  return (
    <div className="min-h-screen bg-gray-50 p-6">
      <div className="max-w-7xl mx-auto">
        <HeaderMain tipo="_PAGE" ActionStatus={ActionStatus} header_title="Zanthus | Pagamentos - Online">
          <div className="flex space-x-2">
            <ButtonPag
              TypeButton="_BUTTON_HEADER"
              label="Pesquisar"
              TypeIcon="_PESQUISAR"
              title="Pesquisar"
              onClick={consultarPagamentos}
            />
          </div>
        </HeaderMain>

        <div className="bg-white rounded-lg shadow-sm border border-gray-200 mb-6">
          <div className="p-6">
            <h2 className="text-lg font-semibold text-gray-900 mb-4">Filtros de Consulta</h2>

            <div className="grid grid-cols-1 md:grid-cols-12 gap-4 mb-4">
              <div className="w-full flex flex-col md:col-span-2">
                <label className="block text-sm font-medium text-gray-700 mb-2">Data do Cupom *</label>
                <input
                  type="date"
                  value={data}
                  onChange={(e) => setData(e.target.value)}
                  required
                  className="w-full px-3 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                />
              </div>

              <div className="w-full flex flex-col md:col-span-1">
                <label className="block text-sm font-medium text-gray-700 mb-2">ECF</label>
                <input
                  type="text"
                  value={numeroEcf}
                  onChange={(e) => setNumeroEcf(e.target.value.replace(/\D/g, ''))}
                  placeholder="ECF"
                  maxLength={3}
                  className="w-full px-1 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 text-center"
                />
              </div>

              <div className="w-full flex flex-col md:col-span-1">
                <label className="block text-sm font-medium text-gray-700 mb-2">Cupom</label>
                <input
                  type="text"
                  value={numeroCupom}
                  onChange={(e) => setNumeroCupom(e.target.value.replace(/\D/g, ''))}
                  placeholder="N. Cupom"
                  maxLength={7}
                  className="w-full px-3 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 text-center"
                />
              </div>

              <div className="w-full flex flex-col md:col-span-2">
                <label className="block text-sm font-medium text-gray-700 mb-2">CPF/CNPJ</label>
                <input
                  type="text"
                  value={cpfCnpj}
                  onChange={(e) => setCpfCnpj(e.target.value)}
                  placeholder="Digite o CPF ou CNPJ"
                  maxLength={18}
                  className="w-full px-2 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                />
              </div>

              <div className="w-full flex flex-col md:col-span-2">
                <label className="block text-sm font-medium text-gray-700 mb-2">Tipo Nota</label>
                <select
                  value={tiponota.tiponota}
                  onChange={(e) => {
                    const selectedValue = parseInt(e.target.value)
                    const selectedTipo =
                      tiponotaLista.find((t) => t.tiponota === selectedValue) || {
                        tiponota: 999,
                        tiponota_descricao: 'Todas'
                      }
                    setTiponota(selectedTipo)
                  }}
                  className="w-full px-2 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                >
                  <option value={999}>Todas</option>
                  {tiponotaLista.map((tipo) => (
                    <option key={tipo.tiponota} value={tipo.tiponota}>
                      {tipo.tiponota_descricao}
                    </option>
                  ))}
                </select>
              </div>

              <div className="w-full flex flex-col md:col-span-2">
                <label className="block text-sm font-medium text-gray-700 mb-2">Status Cupom</label>
                <select
                  value={status.status_cancelado}
                  onChange={(e) => {
                    const selectedValue = parseInt(e.target.value)
                    const selectedStatus =
                      statusLista.find((s) => s.status_cancelado === selectedValue) || {
                        status_cancelado: 999,
                        status_cancelado_descriao: 'Todas'
                      }
                    setStatus(selectedStatus)
                  }}
                  className="w-full px-3 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                >
                  <option value={999}>Todas</option>
                  {statusLista.map((statusItem) => (
                    <option key={statusItem.status_cancelado} value={statusItem.status_cancelado}>
                      {statusItem.status_cancelado_descriao}
                    </option>
                  ))}
                </select>
              </div>

              <div className="w-full flex flex-col md:col-span-4">
                <label className="block text-sm font-medium text-gray-700 mb-2">
                  Finalizadora ({listFinalizadora.length})
                </label>
                <select
                  value={filterFinalizadora_cd ?? 0}
                  onChange={(e) => {
                    const selectedValue = Number(e.target.value)
                    setFilterFinalizadora_cd(selectedValue === 0 ? null : selectedValue)
                  }}
                  className="w-full h-10 px-3 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 text-sm"
                >
                  <option value={0}>Todas</option>

                  {listFinalizadora.length === 0 && (
                    <option value={0} disabled>
                      Sem finalizadoras carregadas
                    </option>
                  )}

                  {listFinalizadora.map((finalizadoraItem) => (
                    <option
                      key={finalizadoraItem.finalizadora_cd}
                      value={finalizadoraItem.finalizadora_cd}
                    >
                      {finalizadoraItem.finalizadora_descricao}
                    </option>
                  ))}
                </select>
              </div>

              <div className="w-full flex flex-col md:col-span-3">
                <label className="flex items-center gap-2 text-sm font-medium text-gray-700 mb-2">
                  <span>Filtrar Valor do Cupom</span>
                  <input
                    type="checkbox"
                    className="h-4 w-4 text-blue-600 border-gray-300 rounded focus:ring-blue-500"
                    checked={filtrarValorCupom === 1}
                    onChange={(e) => { 
                      setFiltrarValorCupom(e.target.checked ? 1 : 0) 

                    } }
                  />
                </label>

                <div className="flex items-center gap-2">
                  <input
                    type="number"
                    className="w-full h-10 px-2 border border-gray-300 text-right rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-sm"
                    value={valorinicial}
                    disabled={filtrarValorCupom === 0}
                    onChange={(e) => setValorinicial(user.toNumber(e.target.value))}
                  />
                  <span className="text-gray-500 text-sm whitespace-nowrap">até</span>
                  <input
                    type="number"
                    className="w-full h-10 px-2 border border-gray-300 text-right rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-sm"
                    value={valorfinal}
                    disabled={filtrarValorCupom === 0}
                    onChange={(e) => setValorfinal(user.toNumber(e.target.value))}
                  />
                </div>
              </div>

              <div className="w-full flex flex-col md:col-span-3">
                <label className="flex items-center gap-2 text-sm font-medium text-gray-700 mb-2">
                  <span>Filtrar Valor do Pgto</span>
                  <input
                    type="checkbox"
                    className="h-4 w-4 text-blue-600 border-gray-300 rounded focus:ring-blue-500"
                    checked={filtrarValorPgto === 1}
                    onChange={(e) => {
                      setFiltrarValorPgto(e.target.checked ? 1 : 0)

                    }}
                  />
                </label>

                <div className="flex items-center gap-2">
                  <input
                    type="number"
                    className="w-full h-10 px-2 border border-gray-300 text-right rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-sm"
                    value={valorPgtoInicial}
                    disabled={filtrarValorPgto === 0}
                    onChange={(e) => setValorPgtoInicial(user.toNumber(e.target.value))}
                  />
                  <span className="text-gray-500 text-sm whitespace-nowrap">até</span>
                  <input
                    type="number"
                    className="w-full h-10 px-2 border border-gray-300 text-right rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-sm"
                    value={valorPgtoFinal}
                    disabled={filtrarValorPgto === 0}
                    onChange={(e) => setValorPgtoFinal(user.toNumber(e.target.value))}
                  />
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

        {pagamentos.length > 0 && (
          <>
            <div className="bg-gradient-to-br from-amber-50 via-white to-amber-100 rounded-xl shadow-sm border border-amber-200 mb-6">
              <div className="p-6">
                <div className="flex flex-col md:flex-row md:items-center md:justify-between gap-3 mb-4">
                  <div>
                    <h2 className="text-lg font-semibold text-amber-900">Formas de Pagamento</h2>
                    <p className="text-sm text-amber-700">Distribuição por finalizadora</p>
                  </div>

                  {resumoFinalizadora && (
                    <div className="flex flex-wrap gap-2">
                      <span className="px-3 py-1 rounded-full bg-white border border-amber-300 text-amber-900 text-sm font-medium">
                        Top: {resumoFinalizadora.categoriaTop}
                      </span>
                      <span className="px-3 py-1 rounded-full bg-white border border-amber-300 text-amber-900 text-sm font-medium">
                        R$ {user.formatCurrency(resumoFinalizadora.valorTop)}
                      </span>
                      <span className="px-3 py-1 rounded-full bg-white border border-amber-300 text-amber-900 text-sm font-medium">
                        {resumoFinalizadora.participacao.toFixed(1)}%
                      </span>
                    </div>
                  )}
                </div>

                {dadosPorFinalizadora.categorias.length > 0 ? (
                  <Chart
                    options={chartOptionsFinalizadora}
                    series={[{ name: 'Valor', data: dadosPorFinalizadora.valores }]}
                    type="bar"
                    height={360}
                  />
                ) : (
                  <div className="text-center py-8 text-gray-500">
                    Sem dados para gráfico por Finalizadora
                  </div>
                )}
              </div>
            </div>

            <div className="bg-white rounded-lg shadow-sm border border-gray-200 mb-6">
              <div className="p-6">
                <h2 className="text-lg font-semibold text-gray-900 mb-4">
                  {pagamentos.length} Registros Encontrados
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
                          <SortableHeader sortKey="ecf">PDV</SortableHeader>
                          <SortableHeader sortKey="numerocupom">Cupom</SortableHeader>
                          <SortableHeader sortKey="datafaturamento">Data</SortableHeader>
                          <SortableHeader sortKey="operador_nome">Operador</SortableHeader>
                          <SortableHeader sortKey="finalizadora_descricao">Finalizadora</SortableHeader>
                          <SortableHeader sortKey="nf_numero">NF Número</SortableHeader>
                          <SortableHeader sortKey="nf_serie">NF Série</SortableHeader>
                          <SortableHeader sortKey="valor" align="right">Valor Pgto</SortableHeader>
                          <SortableHeader sortKey="nf_chave">NF Chave</SortableHeader>
                          <SortableHeader sortKey="sitef_transacao">Transação</SortableHeader>
                          <SortableHeader sortKey="sitef_codigo_autorizacao">Autorização</SortableHeader>
                          <SortableHeader sortKey="sitef_cartao_bin">BIN</SortableHeader>
                          <SortableHeader sortKey="sitef_credenciadora_cnpj">CNPJ Credenciadora</SortableHeader>

                          <SortableHeader sortKey="valor_troco" align="right">Troco</SortableHeader>
                        </tr>
                      </thead>
                      <tbody className="bg-white divide-y divide-gray-200">
                        {pagamentosSorted.map((pag, index) => (
                          <tr key={`pag-${index}-${pag.ecf}-${pag.numerocupom}`} className="hover:bg-gray-50">
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-700">{pag.ecf}</td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-700">{pag.numerocupom}</td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-700">{formatarData(pag.datafaturamento)}</td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-700">{pag.operador_codigo} - {pag.operador_nome}</td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-700">{pag.finalizadora_cd} - {pag.finalizadora_descricao}</td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-700">{pag.nf_numero}</td>

                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-700">{pag.nf_serie}</td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900 text-right">
                              {user.formatCurrency(user.toNumber(pag.valor))}
                            </td>                            
                            <td className="px-4 py-3 whitespace-nowrap text-xs text-gray-700">{pag.nf_chave}</td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-700">{pag.sitef_transacao}</td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-700">{pag.sitef_codigo_autorizacao}</td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-700">{pag.sitef_cartao_bin}</td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-700">{formatCpfCnpj(pag.sitef_credenciadora_cnpj || '')}</td>

                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900 text-right">
                              {user.formatCurrency(user.toNumber(pag.valor_troco))}
                            </td>
                          </tr>
                        ))}
                      </tbody>
                    </table>
                  </div>
                </div>
              </div>
            </div>

            <div className="bg-white rounded-lg shadow-sm border border-gray-200 mb-6">
              <div className="p-6">
                <h2 className="text-lg font-semibold text-gray-900 mb-4">Totalização de Pagamentos</h2>

                <div className="grid grid-cols-1 md:grid-cols-3 gap-4 mb-6">

                  <div className="bg-green-50 border-l-4 border-green-500 rounded-lg p-4">
                    <p className="text-sm text-green-700">Total</p>
                    <p className="text-2xl font-bold text-green-800">R$ {user.formatCurrency(totalLiquido)}</p>
                  </div>
                </div>

                <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
                  <div className="w-full">
                    {dadosPorEcf.categorias.length > 0 ? (
                      <Chart
                        options={chartOptionsEcf}
                        series={[{ name: 'Valor', data: dadosPorEcf.valores }]}
                        type="bar"
                        height={420}
                      />
                    ) : (
                      <div className="text-center py-8 text-gray-500">Sem dados para gráfico por ECF</div>
                    )}
                  </div>

                  <div className="w-full">
                    {dadosPorOperador.categorias.length > 0 ? (
                      <Chart
                        options={chartOptionsOperador}
                        series={[{ name: 'Valor', data: dadosPorOperador.valores }]}
                        type="bar"
                        height={420}
                      />
                    ) : (
                      <div className="text-center py-8 text-gray-500">Sem dados para gráfico por Operador</div>
                    )}
                  </div>
                </div>
              </div>
            </div>
          </>
        )}

        {!loading && pagamentos.length === 0 && data && (
          <div className="bg-white rounded-lg shadow-sm border border-gray-200">
            <div className="p-8 text-center">
              <div className="text-gray-400 mb-2">
                <svg className="w-12 h-12 mx-auto" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M9 12h6m-6 4h6m2 5H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
                </svg>
              </div>
              <p className="text-gray-500">Nenhum pagamento encontrado para os filtros informados.</p>
            </div>
          </div>
        )}
      </div>
    </div>
  )
}