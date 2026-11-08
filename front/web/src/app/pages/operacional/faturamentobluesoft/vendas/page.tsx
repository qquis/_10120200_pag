'use client'

import { useEffect, useState, useRef } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";
import CmbOperacao from '@/app/pages/cadastro/_components/CmbOperacao/page';
import CmbVendedor from '@/app/pages/cadastro/_components/CmbVendedor/page';
//import CmbFaturamentoBluesoftStatusPersonalizado from './_components/CmbFaturamentoStatusPersonalizado/page';
import CmbFaturamentoBluesoftStatusPersonalizado from './_components/CmbFaturamentoStatusPersonalizado/page'
import CmbFaturamentoBluesoftStatus from './_components/CmbFaturamentoBlueSoftStatus/page';

/*API*/
import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";
import {moduleFaturamentoBluesoft, tpFaturamentoBlueSoftStatus} from "@/api/m0050_faturamentoBluesoft/moduleFaturamentoBluesoft";

/*MODAL*/

import ModalFaturamentoBluesoft from './modalfaturamentobluesoft';

let myMODULE : moduleFaturamentoBluesoft 




export default function FaturamentoBlueSoftList() {

    const __SIS_AC_CD : number = 3210 /* CONSULTA FATURAMENTO BLUESOFT */

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);


    /* STATES LISTS */
    const [List, setList] = useState<any[]>([]);
    const [ListFaturamentoStatusPersonalizado, setListFaturamentoStatusPersonalizado] = useState<tpFaturamentoBlueSoftStatus[]>([]);
    const [ListFaturamentoBlueSoftStatus, setListFaturamentoBlueSoftStatus] = useState<tpFaturamentoBlueSoftStatus[]>([]);

    /* STATES FILTERS */
    const [nome_razaoFilter, setnome_razaoFilter] = useState('');
    const [op_cdoperacaoFilter, setOp_CdOperacaoFilter] = useState('');
    
    const [statusfaturamentoFiltrar, setStatusfaturamentoFiltrar] = useState(true);
    const [statusfaturamentoFilter, setStatusfaturamentoFilter] = useState(0);
    const [statusfaturamentoBluesoftFilter, setStatusfaturamentoBluesoftFilter] = useState(0);


    const [cdParticipanteVendedorFilter, setCdParticipanteVendedor] = useState(0);
    
    const [dataPedidoEmissao_filter, setDataPedidoEmissao_filter] = useState(false);
    const [dataPedidoEmissao_ini, setDataPedidoEmissao_ini] = useState(new Date().toISOString().split('T')[0]);
    const [dataPedidoEmissao_fim, setDataPedidoEmissao_fim] = useState(new Date().toISOString().split('T')[0]);

    
    const [dataFaturamento_filter, setDataFaturamento_filter] = useState(false);
    const [dataFaturamento_ini, setDataFaturamento_ini] = useState(new Date().toISOString().split('T')[0]);
    const [dataFaturamento_fim, setDataFaturamento_fim] = useState(new Date().toISOString().split('T')[0]);

    const [descricaogrupoeconomico_Filter, setdescricaogrupoeconomico_Filter] = useState('');

    const [numeropedido, setnumeropedido] = useState(0);

    /* STATES MODAL */
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedPedido, setSelectedPedido] = useState<{ numeropedido: number; op_cdoperacao: number; numeropedido_fv: number } | null>(null);


    
    
    useEffect(() => {
        myMODULE = new moduleFaturamentoBluesoft(user, __SIS_AC_CD);
                
        const OpenPage = async () => {
            try {
                await myMODULE.BindingFaturamentoStatus();
                setListFaturamentoStatusPersonalizado(myMODULE.listFaturamentoStatusPersonalizado);
                await faturamentoStatusPersonalizadoFilter(0);
            } catch (error) {
                console.error('Erro ao buscar status de faturamento:', error);
            }
        };
        OpenPage();
    }, []);


    const faturamentoStatusPersonalizadoFilter = async (statusfaturamento: number) => {
        try {
                setActionStatus(1);

                if (statusfaturamento === 1) {
                    /* Se a consulta for para pedidos faturados será obrigatório informar o período de emissão dos pedidos */
                    setDataPedidoEmissao_filter(false);
                    setDataFaturamento_filter(true);
                }
                if (statusfaturamento === 0) {
                    setDataFaturamento_filter(false);
                    setDataPedidoEmissao_filter(false);
                }


                setStatusfaturamentoFilter(0); // Resetar o filtro Bluesoft
                setStatusfaturamentoFilter(statusfaturamento);

                setListFaturamentoBlueSoftStatus([]);
                let list = await myMODULE.getFaturamentoBlueSoftFilter(statusfaturamento)
                setListFaturamentoBlueSoftStatus(list);
            } catch (error) {
                console.error('Erro ao filtrar status de faturamento bluesoft:', error);
            }
            finally { 
                setActionStatus(0);
            }
    }


    const ConsultarList = async () => {
        try {
            setList([]) // Limpando a lista antes de buscar novos dados
            setActionStatus(1);

                        

            let parametro : any = {
                nome_razao: nome_razaoFilter,
                op_cdoperacao: op_cdoperacaoFilter,
                cdparticipantevendedor: cdParticipanteVendedorFilter,
                statusfaturamentoFiltrar: statusfaturamentoFiltrar ? 1 : 0,
                statusfaturamento: statusfaturamentoFilter,
                fat_blue_status_cd: statusfaturamentoBluesoftFilter,
            }



            if (numeropedido && numeropedido !== 0) {
                parametro.numeropedido = numeropedido
            }

            if (dataPedidoEmissao_filter) { 
                parametro.dataPedidoEmissao_filter = 1
                parametro.dataPedidoEmissao_ini = dataPedidoEmissao_ini
                parametro.dataPedidoEmissao_fim = dataPedidoEmissao_fim
            }

            if (dataFaturamento_filter) { 
                parametro.dataFaturamento_filter = 1
                parametro.dataFaturamento_ini = dataFaturamento_ini
                parametro.dataFaturamento_fim = dataFaturamento_fim
            }            
            
            if (descricaogrupoeconomico_Filter) {
                parametro.descricaogrupoeconomico = descricaogrupoeconomico_Filter;
            }

            const response = await myMODULE.getFaturamentoList(parametro);

            setList(response || []);
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setList([]);
            setActionStatus(0);
        }
    };

    const limparFiltros = () => {
        setnome_razaoFilter('');
        setdescricaogrupoeconomico_Filter('');
        setOp_CdOperacaoFilter('');

    };

    const clearDadosGrid = async () => { 
        setList([]);
    }

 
    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Vendas Bluesoft | Listagem">
                    <div className="flex space-x-2">
                        <ButtonPag 
                            TypeButton="_BUTTON_HEADER" 
                            label="Pesquisar" 
                            TypeIcon="_PESQUISAR" 
                            title="Pesquisar Vendas Bluesoft" 
                            onClick={ConsultarList} 
                        />

                    </div>
                </HeaderMain>

                {/* Área de Filtros */}
                <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
                    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">

                     

                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Operação</label>
                            <CmbOperacao user={user} onChange={(value) => setOp_CdOperacaoFilter(value)} value={op_cdoperacaoFilter} sis_ac_cd={__SIS_AC_CD} />
                        </div>                        
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Vendedor</label>
                            <CmbVendedor user={user} onChange={(value) => setCdParticipanteVendedor(Number(value))} value={cdParticipanteVendedorFilter.toString()} sis_ac_cd={__SIS_AC_CD} />
                        </div> 


                        <div>
                            <label className="flex items-center space-x-2 text-sm font-medium text-gray-700 mb-1">
                                <input
                                    type="checkbox"
                                    checked={statusfaturamentoFiltrar}
                                    onChange={e => { 
                                        clearDadosGrid()
                                        setStatusfaturamentoFiltrar(e.target.checked) 
                                        

                                    }}
                                />
                                <span>Filtrar Status Faturamento</span>
                            </label>
                            <div className='flex space-x-2, items-end'> 
                                {ListFaturamentoStatusPersonalizado.length > 0 ? (
                                <CmbFaturamentoBluesoftStatusPersonalizado
                                    user={user}
                                    onChange={async (value) => 
                                        {
                                            clearDadosGrid()
                                            await faturamentoStatusPersonalizadoFilter(Number(value))

                                        }
                                    }
                                    value={statusfaturamentoFilter}
                                    sis_ac_cd={__SIS_AC_CD}
                                    listFaturamentoStatusPersonalizado={ListFaturamentoStatusPersonalizado}
                                    disabled={!statusfaturamentoFiltrar}
                                />
                                ) : (
                                  <div>Carregando status...</div>
                                )}

                                {ListFaturamentoBlueSoftStatus.length > 0 ? (
                                <CmbFaturamentoBluesoftStatus user={user} 
                                    onChange={(value) => setStatusfaturamentoBluesoftFilter(Number(value))} 
                                    value={statusfaturamentoBluesoftFilter} 
                                    sis_ac_cd={__SIS_AC_CD} 
                                    ListFaturamentoBlueSoftStatus={ListFaturamentoBlueSoftStatus} 
                                    disabled={!statusfaturamentoFiltrar} />
                                ) : (
                                  <div>Carregando status Bluesoft...</div>
                                )}
                            </div>
                        </div>
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Número do Pedido</label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-right"
                                placeholder="Filtrar por descrição"
                                value={numeropedido}
                                onChange={(e) => setnumeropedido(Number(e.target.value))}
                            />
                        </div> 
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Nome / Razão Social</label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                                placeholder="Filtrar por descrição"
                                value={nome_razaoFilter}
                                onChange={(e) => setnome_razaoFilter(e.target.value)}
                            />
                        </div>  
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Grupo Econômico</label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                                placeholder="Filtrar por descrição"
                                value={descricaogrupoeconomico_Filter}
                                onChange={(e) => setdescricaogrupoeconomico_Filter(e.target.value)}
                            />
                        </div>  
                         <div >
                            <label className="flex items-center space-x-2 text-sm font-medium text-gray-700 mb-1">
                                <input
                                    type="checkbox"
                                    checked={dataPedidoEmissao_filter}
                                    disabled={statusfaturamentoFilter === 1 || !statusfaturamentoFiltrar }
                                    onChange={e => { 
                                        clearDadosGrid()
                                        setDataPedidoEmissao_filter(e.target.checked)

                                    }}
                                />
                                <span>Emissão do Pedido</span>
                            </label>

                          <div className='flex space-x-2 items-end gap-2'>
                            <input
                                type="date"
                                id="start-date"
                                name="start-date"
                                value={dataPedidoEmissao_ini}
                                onChange={e => 
                                    { 
                                        clearDadosGrid()
                                        setDataPedidoEmissao_ini(e.target.value)
                                    } 
                                }

                                disabled={!dataPedidoEmissao_filter}
                                className="p-2 border border-gray-300 rounded-md text-black flex-1"
                            />
                            <input
                                type="date"
                                id="end-date"
                                name="end-date"
                                value={dataPedidoEmissao_fim}
                                onChange={e => { 
                                    clearDadosGrid()
                                    setDataPedidoEmissao_fim(e.target.value)
                                }}
                                disabled={!dataPedidoEmissao_filter}
                                className="p-2 border border-gray-300 rounded-md text-black flex-1"
                            />
                            </div>
                        </div>

                        <div >
                            <label className="flex items-center space-x-2 text-sm font-medium text-gray-700 mb-1">
                                <input
                                    type="checkbox"
                                    checked={statusfaturamentoFilter === 1 }
                                    disabled={true}
                                    onChange={e => { 
                                        clearDadosGrid()
                                        setDataFaturamento_filter(e.target.checked)
                                    }}
                                />
                                <span>Faturamento</span>
                            </label>

                          <div className='flex space-x-2 items-end gap-2'>
                            <input
                                type="date"
                                id="start-date-faturamento"
                                name="start-date-faturamento"
                                value={dataFaturamento_ini}
                                onChange={e => setDataFaturamento_ini(e.target.value)}
                                disabled={!(statusfaturamentoFilter === 1)}
                                className="p-2 border border-gray-300 rounded-md text-black flex-1"
                            />
                            <input
                                type="date"
                                id="end-date-faturamento"
                                name="end-date-faturamento"
                                value={dataPedidoEmissao_fim}
                                onChange={e => setDataFaturamento_fim(e.target.value)}
                                disabled={!(statusfaturamentoFilter === 1)}
                                className="p-2 border border-gray-300 rounded-md text-black flex-1"
                            />
                            </div>
                        </div>
  
                    
                    </div>
                </div>

                {/* Grid de Serviços - Tabela para desktop */}
                <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100 md:block hidden">
    <div className="max-h-[500px] overflow-y-auto">
        <table className="min-w-full divide-y divide-gray-200">
            <thead className="bg-gray-100 sticky top-0 z-10">
                <tr>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">N. Pedido</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vendedor</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Nome/Razão</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Emissão</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Fat.</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Valor</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Valor Faturado</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Situação</th>
                </tr>
            </thead>
            <tbody className="bg-white divide-y divide-gray-200">
                {List.length > 0 ? (
                    List.map((itemList) => (
                        <tr
                            key={itemList.numeropedido}
                            className="bg-white hover:bg-gray-50 cursor-pointer"
                            onClick={() => {
                                setSelectedPedido({ numeropedido: itemList.numeropedido, numeropedido_fv: itemList.numeropedido_fv, op_cdoperacao: itemList.op_cdoperacao });
                                setIsModalOpen(true);
                            }}
                            >
                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap text-right">{itemList.numeropedido}</td>
                            <td className="px-1 py-2 text-xs text-gray-700 whitespace-nowrap">{itemList.vendedor_nome_razao}</td>
                            <td className="px-3 py-2 text-xs text-gray-900 whitespace-nowrap">
                                {itemList.cliente_nome_razao}
                                <div className='text-xs text-gray-500'>
                                    Código {itemList.cdpessoabluesoft_cliente} / CNPJ: {itemList.cpf_cnpj_cliente}
                                </div>    
                                <div className='text-xs text-gray-500'>
                                Grupo: {`${itemList.descricaogrupoeconomico}`.length > 50 ? itemList.descricaogrupoeconomico.substring(0, 47) + '...' : itemList.descricaogrupoeconomico}    
                                </div> 

                            </td>
                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap">{user.formatDateDDMMYYYY(itemList.data_emissao)}</td>
                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap">{user.formatDateDDMMYYYY(itemList.data_faturamento)}</td>
                            <td className="px-4 py-2 text-sm text-gray-700 whitespace-nowrap text-right">{user.formatNumber(itemList.valor_pedido,2, true)}</td>
                            <td
                                className={`px-4 py-2 text-sm text-gray-700 whitespace-nowrap text-right ${
                                    Number(itemList.valor_faturamento) !== Number(itemList.valor_pedido) && statusfaturamentoFilter === 1 ? 'bg-red-200' : ''
                                }`}
                                >
                                {user.formatNumber(itemList.valor_faturamento, 2, true)}
                            </td>
                            <td className="px-4 py-2 text-xs text-gray-700">{itemList.fat_blue_status_descricao}</td>
                        </tr>
                    ))
                ) : (
                    <tr>
                        <td colSpan={16} className="px-6 py-4 text-center text-sm text-gray-500">
                            Nenhum Registro Encontrado
                        </td>
                    </tr>
                )}
            </tbody>
        </table>
    </div>
</div>

{/* Lista para mobile */}
<div className="md:hidden">
    {List.length > 0 ? (
        List.map((itemList) => (
            <div key={itemList.numeropedido} className="bg-white rounded-lg shadow p-4 mb-4 border border-purple-100 cursor-pointer"
                onClick={() => {
                    setSelectedPedido({ numeropedido: itemList.numeropedido, numeropedido_fv: itemList.numeropedido_fv, op_cdoperacao: itemList.op_cdoperacao });
                    setIsModalOpen(true);
                }}
>
                <div className="mb-2"><span className="font-semibold text-slate-500">Vendedor:</span> {itemList.vendedor_nome_razao}</div>
                <div className="mb-2"><span className="font-semibold text-slate-500">Cliente:</span> 
                                                    {itemList.cdpessoabluesoft_cliente} - {itemList.cliente_nome_razao}
                                                            <div className='text-xs text-gray-500'>
                                                                Grupo Econômico: {itemList.descricaogrupoeconomico}
                                                            </div>    
                                                    </div>
                <div className="mb-2"><span className="font-semibold text-slate-500">CPF/CNPJ:</span> {itemList.cpf_cnpj_cliente}</div>
                <div className="mb-2"><span className="font-semibold text-slate-500">Número do Pedido:</span> {itemList.numeropedido}</div>
                <div className="mb-2"><span className="font-semibold text-slate-500">Emissão:</span> {user.formatDateDDMMYYYY(itemList.data_emissao)}</div>
                <div className="mb-2"><span className="font-semibold text-slate-500">Fat.:</span> {user.formatDateDDMMYYYY(itemList.data_faturamento)}</div>
                <div className="mb-2"><span className="font-semibold text-slate-500">Valor:</span> {user.formatNumber(itemList.valor_pedido,2, true)}</div>
                <div className="mb-2"><span className="font-semibold text-slate-500">Valor Faturado:</span> {user.formatNumber(itemList.valor_faturamento,2, true)}</div>
                <div><span className="font-semibold text-slate-500">Situação:</span> {itemList.fat_blue_status_descricao}</div>
            </div>
        ))
    ) : (
        <div className="px-6 py-4 text-center text-sm text-gray-500">
            Nenhum Registro Encontrado
        </div>
    )}
</div>

                {/* Rodapé com total de registros */}
                <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
                    <div className="flex justify-between items-center">
                        <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
                            Total de Registros {List.length} 
                        </span>
                    </div>
                </div>


        {isModalOpen && selectedPedido && (
        <div className="fixed inset-0 z-50 flex items-start justify-center bg-black/50 overflow-y-auto">
            <div className="bg-white w-full max-w-6xl my-6 mx-4 rounded-lg shadow-xl">
            <ModalFaturamentoBluesoft
                numeropedido={selectedPedido.numeropedido}
                op_cdoperacao={selectedPedido.op_cdoperacao}
                numeropedido_fv={selectedPedido.numeropedido_fv}
                onClose={() => {
                setIsModalOpen(false);
                setSelectedPedido(null);
                }}
            />
            </div>
        </div>
        )}            
        </div>
    </div>
    );
}

