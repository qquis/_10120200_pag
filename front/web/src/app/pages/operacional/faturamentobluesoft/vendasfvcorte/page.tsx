'use client'

import { useEffect, useState } from 'react'
import { useAuth } from "@/app/context/context"

import HeaderMain from "@/app/components/divs/headerMain"
import ButtonPag from "@/app/components/Buttons/button"
import CmbOperacao from '@/app/pages/cadastro/_components/CmbOperacao/page'
import CmbVendedor from '@/app/pages/cadastro/_components/CmbVendedor/page'
import CmbFaturamentoBluesoftStatusPersonalizado from '../vendas/_components/CmbFaturamentoStatusPersonalizado/page'
import CmbFaturamentoBluesoftStatus from '../vendas/_components/CmbFaturamentoBlueSoftStatus/page'

import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect"
import { moduleFaturamentoBluesoft, tpFaturamentoBlueSoftStatus } from "@/api/m0050_faturamentoBluesoft/moduleFaturamentoBluesoft"

const SIS_AC_CD: number = 3211


let myMODULE: moduleFaturamentoBluesoft

export default function VendasFVCortePage() {
    const { user } = useAuth()

    const [ActionStatus, setActionStatus] = useState<number>(0)
    const [List, setList] = useState<any[]>([])

    const [cdParticipanteVendedorFilter, setCdParticipanteVendedor] = useState(0)



    const [dataFaturamento_filter, setDataFaturamento_filter] = useState(false)
    const [dataFaturamento_ini, setDataFaturamento_ini] = useState(new Date().toISOString().split('T')[0])
    const [dataFaturamento_fim, setDataFaturamento_fim] = useState(new Date().toISOString().split('T')[0])
    const [mail, setMail] = useState(0)
    const [mail_to, setMail_to] = useState('')

    const [descricaogrupoeconomico_Filter, setdescricaogrupoeconomico_Filter] = useState('')
    const [numeropedido, setnumeropedido] = useState(0)

    useEffect(() => {
        myMODULE = new moduleFaturamentoBluesoft(user, SIS_AC_CD)

        const OpenPage = async () => {
            try {
                await myMODULE.BindingFaturamentoStatus()
                setDataFaturamento_filter(true)

            } catch (error) {
                console.error('Erro ao carregar status:', error)
            }
        }

        OpenPage()
    }, [])

    const clearDadosGrid = () => {
        setList([])
    }


    const ConsultarList = async (mail: number) => {
        try {
            setActionStatus(1)
            setList([])

            const parametro: any = {
                op_cdoperacao: 1,
                cdparticipantevendedor: cdParticipanteVendedorFilter,
                mail: mail,
                mail_to: mail_to? mail_to : "suporte@oxan.com.br"
            }

            if (numeropedido && numeropedido !== 0) {
                parametro.numeropedido = numeropedido
            }

            if (dataFaturamento_filter) {
                parametro.dataFaturamento_filter = 1
                parametro.dataFaturamento_ini = dataFaturamento_ini
                parametro.dataFaturamento_fim = dataFaturamento_fim
            }

            if (descricaogrupoeconomico_Filter) {
                parametro.descricaogrupoeconomico = descricaogrupoeconomico_Filter
            }

            parametro.view = "DETALHE"

            const response = await myMODULE.getFaturamentoBluesoftFVPedidoComCorte(parametro)
            setList(response || [])
        } catch (error) {
            console.error('Erro ao consultar pedidos com corte:', error)
            setList([])
        } finally {
            setActionStatus(0)
        }
    }

    const formatDate = (value: string) => {
        return user?.formatDateDDMMYYYY ? user.formatDateDDMMYYYY(value) : value
    }

    const formatMoney = (value: any) => {
        return user?.formatNumber ? user.formatNumber(value, 2, true) : String(value ?? 0)
    }

    const formatQty = (value: any) => {
        return user?.formatNumber ? user.formatNumber(value, 4, false) : String(value ?? 0)
    }

    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Vendas Bluesoft | Pedidos com Corte">
                    <div className="flex space-x-2">
                        <ButtonPag
                            TypeButton="_BUTTON_HEADER"
                            label="Pesquisar"
                            TypeIcon="_PESQUISAR"
                            title="Pesquisar Pedidos com Corte"
                            onClick={() => ConsultarList(0)}
                        />
                    </div>
                </HeaderMain>

                <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
                    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">


                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Vendedor</label>
                            <CmbVendedor
                                user={user}
                                onChange={(value) => {
                                    clearDadosGrid()
                                    setCdParticipanteVendedor(Number(value))
                                }}
                                value={cdParticipanteVendedorFilter.toString()}
                                sis_ac_cd={SIS_AC_CD}
                            />
                        </div>

                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Número do Pedido</label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-right"
                                placeholder="Número do pedido"
                                value={numeropedido || ''}
                                onChange={(e) => {
                                    clearDadosGrid()
                                    setnumeropedido(Number(e.target.value))
                                }}
                            />
                        </div>

                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Grupo Econômico</label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                                placeholder="Filtrar por grupo econômico"
                                value={descricaogrupoeconomico_Filter}
                                onChange={(e) => {
                                    clearDadosGrid()
                                    setdescricaogrupoeconomico_Filter(e.target.value)
                                }}
                            />
                        </div>


                        <div>
                            <label className="flex items-center space-x-2 text-sm font-medium text-gray-700 mb-1">
                                <input
                                    type="checkbox"
                                    checked={dataFaturamento_filter}
                                    disabled={true}
                                    onChange={e => {
                                        clearDadosGrid()
                                        setDataFaturamento_filter(e.target.checked)
                                    }}
                                />
                                <span>Faturamento</span>
                            </label>
                            <div className="flex space-x-2 items-end gap-2">
                                <input
                                    type="date"
                                    value={dataFaturamento_ini}
                                    onChange={e => {
                                        clearDadosGrid()
                                        setDataFaturamento_ini(e.target.value)
                                    }}
                                    disabled={!dataFaturamento_filter}
                                    className="p-2 border border-gray-300 rounded-md text-black flex-1"
                                />
                                <input
                                    type="date"
                                    value={dataFaturamento_fim}
                                    onChange={e => {
                                        clearDadosGrid()
                                        setDataFaturamento_fim(e.target.value)
                                    }}
                                    disabled={!dataFaturamento_filter}
                                    className="p-2 border border-gray-300 rounded-md text-black flex-1"
                                />
                            </div>
                        </div>


           
                    </div>
                </div>

                <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100 md:block hidden">
                    <div className="max-h-[560px] overflow-y-auto">
                        <table className="min-w-full divide-y divide-gray-200">
                            <thead className="bg-gray-100 sticky top-0 z-10">
                                <tr>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Dados do Pedido</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Produto</th>
                                    <th className="px-4 py-3 text-right text-xs font-medium text-purple-700 tracking-wider">Qtde Sol.</th>
                                    <th className="px-4 py-3 text-right text-xs font-medium text-purple-700 tracking-wider">Qtde Fat.</th>
                                    <th className="px-4 py-3 text-right text-xs font-medium text-purple-700 tracking-wider">Vl. Item Pedido</th>
                                    <th className="px-4 py-3 text-right text-xs font-medium text-purple-700 tracking-wider">Vl. Item Faturado</th>


                                </tr>
                            </thead>
                            <tbody className="bg-white divide-y divide-gray-200">
                                {List.length > 0 ? (
                                    List.map((item) => (
                                        <tr key={`${item.numeropedido}-${item.prb_cdprodutobluesoft}-${item.prb_cdprodutobluesoft_unitario}`} className="bg-white hover:bg-gray-50">
                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap text-left">
                                                N. Pedido {item.numeropedido} <br />
                                                Vendedor {item.cdpessoabluesoft_vendedor} - {item.nome_razao_vendedor} <br />
                                                Cliente {item.nome_razao_cliente} <br />
                                                Status {item.fat_blue_status_descricao} <br />
                                                Valor do Pedido {formatMoney(item.valor_pedido)} <br />
                                                Valor do Faturamento {formatMoney(item.valor_faturamento)} <br />
                                                Emissão {formatDate(item.data_emissao)} <br />
                                                Faturamento {formatDate(item.data_faturamento)} <br />
                                            </td>

                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap" title={item.prb_descricao}>
                                                {item.prb_cdprodutobluesoft} - {item.prb_descricao}
                                            </td>
                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap text-right">{formatQty(item.qtde_solicitada)}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap text-right">{formatQty(item.qtde_faturada)}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap text-right">{formatMoney(item.valor_item_pedido)}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap text-right">{formatMoney(item.valor_item_faturamento)}</td>
                                            
                                        </tr>
                                    ))
                                ) : (
                                    <tr>
                                        <td colSpan={16} className="px-6 py-4 text-center text-sm text-gray-500">
                                            Nenhum registro encontrado
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
                            <div key={`${item.numeropedido}-${item.prb_cdprodutobluesoft}-${item.prb_cdprodutobluesoft_unitario}`} className="bg-white rounded-lg shadow p-4 mb-4 border border-purple-100">
                                <div className="mb-2"><span className="font-semibold text-slate-500">Pedido:</span> {item.numeropedido}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Status:</span> {item.fat_blue_status_descricao}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Vendedor:</span> {item.cdpessoabluesoft_vendedor} - {item.nome_razao_vendedor}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Cliente:</span> {item.nome_razao_cliente}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Produto:</span> {item.prb_cdprodutobluesoft} - {item.prb_descricao}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Qtde Sol.:</span> {formatQty(item.qtde_solicitada)}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Qtde Fat.:</span> {formatQty(item.qtde_faturada)}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Valor Pedido:</span> {formatMoney(item.valor_pedido)}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Valor Faturamento:</span> {formatMoney(item.valor_faturamento)}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Vl. Item Bruto:</span> {formatMoney(item.valor_nf_item_bruto)}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Vl. Item NF:</span> {formatMoney(item.valor_nf_item)}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Bonif.:</span> {item.item_nf_bonificado}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">E-mail:</span> {item.email_vendedor}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Emissão:</span> {formatDate(item.data_emissao)}</div>
                                <div className="mb-2"><span className="font-semibold text-slate-500">Faturamento:</span> {formatDate(item.data_faturamento)}</div>
                                <div><span className="font-semibold text-slate-500">Semana:</span> {item.semana_mes}</div>
                            </div>
                        ))
                    ) : (
                        <div className="px-6 py-4 text-center text-sm text-gray-500">
                            Nenhum registro encontrado
                        </div>
                    )}
                </div>

                <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
                    <div className="flex justify-between items-center">
                        <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
                            Total de Registros {List.length}
                        </span>
                    </div>
                </div>

                
                <div className="flex justify-end gap-3 mt-4">
                    <div> 
                        <input type="email" placeholder="E-mail para envio" 
                                className="p-2 border border-gray-300 rounded-md focus:ring-2   
                                focus:ring-purple-500 focus:border-transparent
                                 text-black" value={mail_to} 
                                 onChange={e => setMail_to(e.target.value)} />

                        
                    </div>
                    <div className="w-auto">
                        <ButtonPag
                            TypeButton="_BUTTON_HEADER"
                            ActionStatus={ActionStatus}
                            label="Enviar e-mail"
                            TypeIcon="_SALVAR"
                            title="Enviar e-mail"
                            type="button"
                            onClick={async () => await ConsultarList(1)}
                        />
                    </div>
                </div>
            </div>
        </div>
    )
}