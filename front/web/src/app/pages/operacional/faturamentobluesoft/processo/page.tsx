'use client'

import { useEffect, useState } from 'react'
import { useAuth } from "@/app/context/context"

import HeaderMain from "@/app/components/divs/headerMain"
import ButtonPag from "@/app/components/Buttons/button"
import CmbOperacao from '@/app/pages/cadastro/_components/CmbOperacao/page'

import { moduleFaturamentoBluesoft } from '@/api/m0050_faturamentoBluesoft/moduleFaturamentoBluesoft'

const SIS_AC_CD: number = 3211

type tpProcessoFaturamentoBluesoft = {
    fat_blue_processo_seq: number
    fat_blue_processo_tipo_cd: number
    fat_blue_processo_tipo_descricao: string
    op_cdoperacao: number
    numeropedido: number
    numeropedido_fv: number
    fat_blue_status_cd: number
    notificacao_cd: number | null
    notificado: number | null
    valor_pedido: string
    valor_faturamento: string
    qtde_itens: string
    qtde_itens_corte: string
    vendedor_nome_razao: string
    cliente_nome_razao: string
    grupo_economico_descricao: string
    data_emissao: string
    data_faturamento: string
    celular_dd: number | null
    celular_numero: number | null
}

let myMODULE: moduleFaturamentoBluesoft

export default function FaturamentoBlueSoftProcessoList() {

    const { user } = useAuth()

    const [ActionStatus, setActionStatus] = useState<number>(0)
    const [List, setList] = useState<tpProcessoFaturamentoBluesoft[]>([])

    const [op_cdoperacaoFilter, setOp_CdOperacaoFilter] = useState<string>('')
    const [dataInicialFilter, setDataInicialFilter] = useState<string>(new Date().toISOString().split('T')[0])
    const [dataFinalFilter, setDataFinalFilter] = useState<string>(new Date().toISOString().split('T')[0])
    const [numeropedidoFilter, setnumeropedidoFilter] = useState<string>('')
    const [numeropedidoFvFilter, setnumeropedidoFvFilter] = useState<string>('')
    const [vendedor_status, setVendedor_Status] = useState<string>("")
    const [notificacao_pendente, setNotificacao_Pendente] = useState<string>("")

    useEffect(() => {
        myMODULE = new moduleFaturamentoBluesoft(user, SIS_AC_CD)
        setVendedor_Status("1")
        setNotificacao_Pendente("1")
    }, [])

    const clearDadosGrid = () => {
        setList([])
    }

    const ConsultarList = async () => {
        try {
            setActionStatus(1)
            setList([])

            const parametro: any = {
                op_cdoperacao: op_cdoperacaoFilter,
                dataInicial: dataInicialFilter,
                dataFinal: dataFinalFilter,
            }

            if (numeropedidoFilter.trim() !== '') {
                parametro.numeropedido = Number(numeropedidoFilter)
            }

            if (numeropedidoFvFilter.trim() !== '') {
                parametro.numeropedido_fv = Number(numeropedidoFvFilter)
            }

            if (vendedor_status === "1") {
                parametro.vendedor_status = "1"
            }

            if (notificacao_pendente === "1") {
                parametro.notificacao_pendente = "1"
            }

            const response = await myMODULE.getFaturamentoBluesoftProcessoConsultar(parametro)
            setList(response || [])
        } catch (error) {
            console.error('Erro ao consultar processos do faturamento bluesoft:', error)
            setList([])
        } finally {
            setActionStatus(0)
        }
    }

    const formatPhone = (dd: number | null, numero: number | null) => {
        if (!dd || !numero) return '-'
        return '(' + dd + ') ' + numero
    }

    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Vendas Bluesoft | Processos">
                    <div className="flex space-x-2">
                        <ButtonPag
                            TypeButton="_BUTTON_HEADER"
                            label="Pesquisar"
                            TypeIcon="_PESQUISAR"
                            title="Pesquisar Processos do Faturamento Bluesoft"
                            onClick={ConsultarList}
                        />
                    </div>
                </HeaderMain>

                <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
                    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-7 gap-4">

                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Operação</label>
                            <CmbOperacao
                                user={user}
                                onChange={(value) => {
                                    clearDadosGrid()
                                    setOp_CdOperacaoFilter(value)
                                }}
                                value={op_cdoperacaoFilter}
                                sis_ac_cd={SIS_AC_CD}
                            />
                        </div>

                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Data Inicial</label>
                            <input
                                type="date"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                                value={dataInicialFilter}
                                onChange={(e) => {
                                    clearDadosGrid()
                                    setDataInicialFilter(e.target.value)
                                }}
                            />
                        </div>

                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Data Final</label>
                            <input
                                type="date"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                                value={dataFinalFilter}
                                onChange={(e) => {
                                    clearDadosGrid()
                                    setDataFinalFilter(e.target.value)
                                }}
                            />
                        </div>

                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">N. Pedido</label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-right"
                                placeholder="Número do pedido"
                                value={numeropedidoFilter}
                                onChange={(e) => {
                                    clearDadosGrid()
                                    setnumeropedidoFilter(e.target.value)
                                }}
                            />
                        </div>

                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">N. Pedido FV</label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-right"
                                placeholder="Número do pedido FV"
                                value={numeropedidoFvFilter}
                                onChange={(e) => {
                                    clearDadosGrid()
                                    setnumeropedidoFvFilter(e.target.value)
                                }}
                            />
                        </div>

                        <div className="flex items-end">
                            <label className="inline-flex items-center gap-2 text-sm font-medium text-gray-700 cursor-pointer">
                                <input
                                    disabled={true}
                                    type="checkbox"
                                    className="h-4 w-4 rounded border-gray-300 text-purple-600 focus:ring-purple-500"
                                    checked={vendedor_status === "1"}
                                    onChange={(e) => {
                                        clearDadosGrid()
                                        setVendedor_Status(e.target.checked ? "1" : "0")
                                    }}
                                />
                                Status Prime Vendedor
                            </label>
                        </div>

                        <div className="flex items-end">
                            <label className="inline-flex items-center gap-2 text-sm font-medium text-gray-700 cursor-pointer">
                                <input
                                    type="checkbox"
                                    className="h-4 w-4 rounded border-gray-300 text-purple-600 focus:ring-purple-500"
                                    checked={notificacao_pendente === "1"}
                                    onChange={(e) => {
                                        clearDadosGrid()
                                        setNotificacao_Pendente(e.target.checked ? "1" : "0")
                                    }}
                                />
                                Apenas notificações Pendentes
                            </label>
                        </div>
                    </div>
                </div>

                <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100 md:block hidden">
                    <div className="max-h-[560px] overflow-y-auto">
                        <table className="min-w-full divide-y divide-gray-200">
                            <thead className="bg-gray-100 sticky top-0 z-10">
                                <tr>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Seq</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Tipo Processo</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Operação</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">N. Pedido</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">N. Pedido FV</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vendedor</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Cliente</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Emissão</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Faturamento</th>
                                    <th className="px-4 py-3 text-right text-xs font-medium text-purple-700 tracking-wider">Itens</th>
                                    <th className="px-4 py-3 text-right text-xs font-medium text-purple-700 tracking-wider">Itens Corte</th>
                                    <th className="px-4 py-3 text-right text-xs font-medium text-purple-700 tracking-wider">Valor Pedido</th>
                                    <th className="px-4 py-3 text-right text-xs font-medium text-purple-700 tracking-wider">Valor Faturamento</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Contato</th>
                                </tr>
                            </thead>
                            <tbody className="bg-white divide-y divide-gray-200">
                                {List.length > 0 ? (
                                    List.map((item) => (
                                        <tr key={item.fat_blue_processo_seq} className="bg-white hover:bg-gray-50">
                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap text-right">{item.fat_blue_processo_seq}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap">
                                                {item.fat_blue_processo_tipo_cd} - {item.fat_blue_processo_tipo_descricao}
                                            </td>
                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap text-right">{item.op_cdoperacao}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap text-right">{item.numeropedido}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap text-right">{item.numeropedido_fv}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap">{item.vendedor_nome_razao}</td>
                                            <td className="px-4 py-2 text-xs text-gray-900 whitespace-nowrap">
                                                {item.cliente_nome_razao}
                                                <div className="text-xs text-gray-500">
                                                    Grupo: {item.grupo_economico_descricao}
                                                </div>
                                            </td>
                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap">{user.formatDateDDMMYYYY(item.data_emissao)}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap">{user.formatDateDDMMYYYY(item.data_faturamento)}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap text-right">{user.formatNumber(item.qtde_itens, 0, true)}</td>
                                            <td className="px-4 py-2 text-xs text-red-700 whitespace-nowrap text-right">{user.formatNumber(item.qtde_itens_corte, 0, true)}</td>
                                            <td className="px-4 py-2 text-sm text-gray-700 whitespace-nowrap text-right">{user.formatNumber(item.valor_pedido, 2, true)}</td>
                                            <td className="px-4 py-2 text-sm text-gray-700 whitespace-nowrap text-right">{user.formatNumber(item.valor_faturamento, 2, true)}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap">{formatPhone(item.celular_dd, item.celular_numero)}</td>
                                        </tr>
                                    ))
                                ) : (
                                    <tr>
                                        <td colSpan={14} className="px-6 py-4 text-center text-sm text-gray-500">
                                            Nenhum Registro Encontrado
                                        </td>
                                    </tr>
                                )}
                            </tbody>
                        </table>
                    </div>
                </div>

                <div className="md:hidden">
                    {List.length > 0 ? (
                        List.map((item) => (
                            <div key={item.fat_blue_processo_seq} className="bg-white rounded-lg shadow p-4 mb-4 border border-purple-100">
                                <div className="mb-2"><span className="font-semibold text-slate-500">Seq:</span> {item.fat_blue_processo_seq}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Tipo:</span> {item.fat_blue_processo_tipo_cd} - {item.fat_blue_processo_tipo_descricao}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Pedido:</span> {item.numeropedido}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Pedido FV:</span> {item.numeropedido_fv}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Vendedor:</span> {item.vendedor_nome_razao}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Cliente:</span> {item.cliente_nome_razao}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Grupo:</span> {item.grupo_economico_descricao}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Emissão:</span> {user.formatDateDDMMYYYY(item.data_emissao)}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Faturamento:</span> {user.formatDateDDMMYYYY(item.data_faturamento)}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Itens:</span> {user.formatNumber(item.qtde_itens, 0, true)}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Itens Corte:</span> {user.formatNumber(item.qtde_itens_corte, 0, true)}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Valor Pedido:</span> {user.formatNumber(item.valor_pedido, 2, true)}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Valor Faturamento:</span> {user.formatNumber(item.valor_faturamento, 2, true)}</div>
                                <div><span className="font-semibold text-slate-500">Celular:</span> {formatPhone(item.celular_dd, item.celular_numero)}</div>
                            </div>
                        ))
                    ) : (
                        <div className="px-6 py-4 text-center text-sm text-gray-500">
                            Nenhum Registro Encontrado
                        </div>
                    )}
                </div>

                <div className="px-6 py-4 bg-gray-50 border-b border-gray-200 mt-2 rounded-lg">
                    <div className="flex justify-between items-center">
                        <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
                            Total de Registros {List.length}
                        </span>
                    </div>
                </div>
            </div>
        </div>
    )
}