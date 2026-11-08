'use client'

import { useEffect, useState, useRef } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";
import CmbOperacao from '@/app/pages/cadastro/_components/CmbOperacao/page';
import CmbVendedor from '@/app/pages/cadastro/_components/CmbVendedor/page';
import CmbStatusFaturamento from '../_components/CmbStatusFaturamento/page';
import ModalFaturamentoControle from './modalfaturamentoControle';

/*API*/
import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";
import { moduleFaturamento, type tpFaturamentoStatus } from '@/api/m0070_faturamento/moduleFaturamento';


    
let myMODULE : moduleFaturamento 




export default function FaturamentoList() {

    const __SIS_AC_CD : number = 3210 /* CONSULTA FATURAMENTO BLUESOFT */

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);


    /* STATES LISTS */
    const [List, setList] = useState<any[]>([]);
    const [ListFaturamentoStatus, setListFaturamentoStatus] = useState<tpFaturamentoStatus[]>([]);


    /* STATES FILTERS */
    const [nome_razaoFilter, setnome_razaoFilter] = useState('');
    const [op_cdoperacaoFilter, setOp_CdOperacaoFilter] = useState('');
    
    const [statusfaturamentoFiltrar, setStatusfaturamentoFiltrar] = useState(true);
    const [statusfaturamentoFilter, setStatusfaturamentoFilter] = useState(1);
    


    const [cdParticipanteVendedorFilter, setCdParticipanteVendedor] = useState(0);
    
    const [dataPedidoEmissao_filter, setDataPedidoEmissao_filter] = useState(false);
    const [dataPedidoEmissao_ini, setDataPedidoEmissao_ini] = useState(new Date().toISOString().split('T')[0]);
    const [dataPedidoEmissao_fim, setDataPedidoEmissao_fim] = useState(new Date().toISOString().split('T')[0]);

    
    const [dataFaturamento_filter, setDataFaturamento_filter] = useState(false);
    const [datafaturamento_ini, setDataFaturamento_ini] = useState(new Date().toISOString().split('T')[0]);
    const [datafaturamento_fim, setDataFaturamento_fim] = useState(new Date().toISOString().split('T')[0]);

    const [descricaogrupoeconomico_Filter, setdescricaogrupoeconomico_Filter] = useState('');

    const [numeropedido, setnumeropedido] = useState(0);

    /* STATES MODAL */
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedPedido, setSelectedPedido] = useState<{ numeropedido: number; faturamento_controle_seq: number } | null>(null);


    
    
    useEffect(() => {
        myMODULE = new moduleFaturamento(user, __SIS_AC_CD);
        
        const OpenPage = async () => {
            try {
                await myMODULE.BindingFaturamentoStatus();
                setListFaturamentoStatus(myMODULE.listFaturamentoStatus);
            } catch (error) {
                console.error('Erro ao buscar status de faturamento:', error);
            }
        };
        OpenPage();
    }, []);




    const ConsultarList = async () => {
        try {
            setList([]) // Limpando a lista antes de buscar novos dados
            setActionStatus(1);
            
            let parametro = { 
                statusfaturamentoFiltrar: statusfaturamentoFiltrar,
                statusfaturamentoFilter: statusfaturamentoFilter,
                op_cdoperacao: op_cdoperacaoFilter,
                cdParticipanteVendedor: cdParticipanteVendedorFilter,
                dataPedidoEmissao_filter: dataPedidoEmissao_filter,
                dataPedidoEmissao_ini: dataPedidoEmissao_ini,
                dataPedidoEmissao_fim: dataPedidoEmissao_fim,
                dataFaturamento_filter: dataFaturamento_filter,
                datafaturamento_ini: datafaturamento_ini,
                datafaturamento_fim: datafaturamento_fim,
                descricaogrupoeconomico_Filter: descricaogrupoeconomico_Filter,
                numeropedido: numeropedido,
                nome_razaoFilter: nome_razaoFilter,
            }

            let result = await myMODULE.getList(parametro);
            setList(result as any[]);




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
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Faturamento PRIME | Listagem">
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
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Status do Faturamento</label>
                            <CmbStatusFaturamento
                                onChange={(value) => {
                                    clearDadosGrid();
                                    setStatusfaturamentoFilter(Number(value));
                                }}
                                
                                value={statusfaturamentoFilter}
                                ListFaturamentoStatus={ListFaturamentoStatus}
                                disabled={true}
                            />
                        </div>
                         <div >
                            <label className="flex items-center space-x-2 text-sm font-medium text-gray-700 mb-1">
                                <input
                                    type="checkbox"
                                    checked={dataPedidoEmissao_filter}
                                    
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
                                value={datafaturamento_ini}
                                onChange={e => setDataFaturamento_ini(e.target.value)}
                                disabled={!(statusfaturamentoFilter === 1)}
                                className="p-2 border border-gray-300 rounded-md text-black flex-1"
                            />
                            <input
                                type="date"
                                id="end-date-faturamento"
                                name="end-date-faturamento"
                                value={datafaturamento_fim}
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
                    
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Id</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Tipo Lançamento</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vendedor</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Nome/Razão</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Emissão/Faturamento</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vl Nota Fiscal</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vl Base</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Subsídios Correntes</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Faturamento Fiscal</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Desconto Financeiro</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Faturamento Bruto</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Subsídios Aplicados</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Faturamento Líquido</th>
                    
                    
                </tr>
            </thead>
            <tbody className="bg-white divide-y divide-gray-200">
                {List.length > 0 ? (
                    List.map((itemList) => (
                        <tr
                            key={itemList.faturamento_controle_seq}
                            className="bg-white hover:bg-gray-50 cursor-pointer"
                            onClick={() => {
                                setSelectedPedido({ numeropedido: itemList.numeropedido, faturamento_controle_seq: itemList.faturamento_controle_seq });
                                setIsModalOpen(true);
                            }}
                            >
                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap text-right">
                                <div>Seq Controle: {itemList.faturamento_controle_seq}</div>
                                <div>N. Pedido: {itemList.numeropedido}</div>
                                
                                
                                </td>
                            <td className="px-4 py-2 text-xs text-gray-700">{itemList.fat_controle_tipo_descricao}</td>
                            <td className="px-1 py-2 text-xs text-gray-700 whitespace-nowrap">
                                <div>
                                    {itemList.vendedor_nome_razao} 
                                </div>
                                <div className='text-xs text-gray-500'>
                                    Cod Participante {itemList.cdparticipante_vendedor}
                                </div>
                            </td>
                            <td className="px-3 py-2 text-xs text-gray-900 whitespace-nowrap">
                                {itemList.cliente_nome_razao}
                                <div className='text-xs text-gray-500'>
                                    Código {itemList.cdpessoabluesoft_cliente}
                                </div>    
                                <div className='text-xs text-gray-500'>
                                Grupo: {`${itemList.descricaogrupoeconomico}`.length > 50 ? itemList.descricaogrupoeconomico.substring(0, 47) + '...' : itemList.descricaogrupoeconomico}    
                                </div> 

                            </td>
                            <td className="px-4 py-2 text-xs text-gray-700 whitespace-nowrap">
                                <div>
                                    Emissão {user.formatDateDDMMYYYY(itemList.dataemissao)}
                                </div>
                                <div>
                                    Faturamento {user.formatDateDDMMYYYY(itemList.datafaturamento)}
                                </div>
                                
                            </td>
                                
                            
                            <td className="px-4 py-2 text-sm text-gray-700 whitespace-nowrap text-right">{user.formatNumber(itemList.df_valor_total,2, true)}</td>
                            <td className="px-4 py-2 text-sm text-gray-700 whitespace-nowrap text-right">{user.formatNumber(itemList.valorfaturamentobase,2, true)}</td>
                            <td className="px-4 py-2 text-sm text-gray-700 whitespace-nowrap text-right">{user.formatNumber(itemList.subsidioscorrentes,2, true)}</td>
                            <td className="px-4 py-2 text-sm text-gray-700 whitespace-nowrap text-right">{user.formatNumber(itemList.valorfaturamento,2, true)}</td>
                            <td className="px-4 py-2 text-sm text-gray-700 whitespace-nowrap text-right">{user.formatNumber(itemList.valortotaldescontofinanceiro,2, true)}</td>
                            <td className="px-4 py-2 text-sm text-gray-700 whitespace-nowrap text-right">{user.formatNumber(itemList.valorfaturamentobruto,2, true)}</td>
                            <td className="px-4 py-2 text-sm text-gray-700 whitespace-nowrap text-right">{user.formatNumber(itemList.valortotalsubsidiosaplicados,2, true)}</td>
                            <td className="px-4 py-2 text-sm text-gray-700 whitespace-nowrap text-right">{user.formatNumber(itemList.valortotalfaturamentoliquido,2, true)}</td>


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
            <div key={itemList.faturamento_controle_seq} className="bg-white rounded-lg shadow p-4 mb-4 border border-purple-100 cursor-pointer"
                onClick={() => {
                    setSelectedPedido({ numeropedido: itemList.numeropedido, faturamento_controle_seq: itemList.faturamento_controle_seq });
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
                    <ModalFaturamentoControle
                        numeropedido={selectedPedido.numeropedido}
                        faturamento_controle_seq={selectedPedido.faturamento_controle_seq}
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
