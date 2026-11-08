'use client'
const __SIS_AC_CD : number = 3050

import { useCallback, useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";
import { usePersistedState } from '@/app/hooks/usePersistedState';

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";

import ButtonPag from "@/app/components/Buttons/button";
import ConfirmDialog from "@/app/components/DialogConfirm/confirmDialog";
import ModalContrato from './modalContrato';


import { moduleFaturamento } from '@/api/m0070_faturamento/moduleFaturamento';
import { moduleForcaVenda } from '@/api/m0004_forcavenda/moduleforcavenda';


let myModule: moduleFaturamento;
let myModuleForcaVenda: moduleForcaVenda;






const fmtData = (v: string) => {
    const m = /^(\d{4})-(\d{2})-(\d{2})/.exec(v || "");
    return m ? `${m[3]}/${m[2]}/${m[1]}` : v;
};
const fmtNum = (v: number | string) => Number(v ?? 0).toLocaleString('pt-BR');




const hoje = () => new Date().toISOString().slice(0, 10);
const toYYYYMMDD = (d: string) => {
    const match = /^(\d{4})-?(\d{2})-?(\d{2})$/.exec(d);
    return match ? `${match[1]}-${match[2]}-${match[3]}` : d;
};

const competencia_list = {
    "01": 'Janeiro',
    "02": 'Fevereiro',
    "03": 'Março',
    "04": 'Abril',
    "05": 'Maio',
    "06": 'Junho',
    "07": 'Julho',
    "08": 'Agosto',
    "09": 'Setembro',
    "10": 'Outubro',
    "11": 'Novembro',
    "12": 'Dezembro',
}



export default function FaturamentoContrato() {

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);
    const [messageInfo, setMessageInfo] = useState<string>("");
    const [contrato_data_val_ini, setcontrato_data_val_ini] = usePersistedState<string>('contrato_data_val_ini', user.getCurrentDate());
    const [contrato_data_val_fim, setcontrato_data_val_fim] = usePersistedState<string>('contrato_data_val_fim', user.getCurrentDate());
    const [listFabricanteForcaVenda, setlistFabricanteForcaVenda] = usePersistedState<any[]>('listFabricanteForcaVenda', []);
    const [listTipoContrato, setlistTipoContrato] = usePersistedState<any[]>('listTipoContrato', []);
    const [contrato_tipo_cd_filter, set_contrato_tipo_cd] = usePersistedState<string>('contrato_tipo_cd', "");
    const [cdpessoabluesoftfabricanteFilter, setcdpessoabluesoftfabricanteFilter] = usePersistedState<string>('cdpessoabluesoftfabricanteFilter', "");
    const [prb_descricaoFilter, setprb_descricaoFilter] = usePersistedState<string>('prb_descricaoFilter', "");
    const [prb_cdprodutoBluesoftFilter, setprb_cdprodutoBluesoftFilter] = usePersistedState<string>('prb_cdprodutoBluesoftFilter', "");
    const [contrato_statusFilter, set_contrato_status] = usePersistedState<string>('contrato_status', "1");

    const [listContrato, setlistContrato] = useState<any[]>([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [contratoSeqConsulta, setContratoSeqConsulta] = useState<number | undefined>(undefined);
    const [modoModal, setModoModal] = useState<'consulta' | 'edicao'>('consulta');
    const [confirmacao, setConfirmacao] = useState<{ acao: 'processar' | 'inativar'; contrato: any } | null>(null);

    const [competencia_ano, set_competencia_ano] = usePersistedState<number>('competencia_ano', user.getCurrentYear());
    const [competencia_mes, set_competencia_mes] = usePersistedState<number>('competencia_mes', user.getCurrentMonth());
    const competencia_cd = Number(`${competencia_ano}${String(competencia_mes).padStart(2, '0')}`);

    const ajustarPeriodoCompetencia = useCallback((mes: number) => {
        if (!Number.isInteger(competencia_ano) || competencia_ano < 1 || mes < 1 || mes > 12) {
            return;
        }

        const mesFormatado = String(mes).padStart(2, '0');
        const ultimoDia = new Date(competencia_ano, mes, 0).getDate();
        const dataInicial = `${competencia_ano}-${mesFormatado}-01`;
        const dataFinal = `${competencia_ano}-${mesFormatado}-${String(ultimoDia).padStart(2, '0')}`;

        if (contrato_data_val_ini !== dataInicial) {
            setcontrato_data_val_ini(dataInicial);
        }
        if (contrato_data_val_fim !== dataFinal) {
            setcontrato_data_val_fim(dataFinal);
        }
    }, [
        competencia_ano,
        contrato_data_val_fim,
        contrato_data_val_ini,
        setcontrato_data_val_fim,
        setcontrato_data_val_ini,
    ]);

    useEffect(() => {
        ajustarPeriodoCompetencia(competencia_mes);
    }, [ajustarPeriodoCompetencia, competencia_mes]);


    const ConsultaFabricanteFv = async () => {
        try {
         
            const response = await myModuleForcaVenda.getFabricanteFv({fv_fabricante_status: 1});

            setlistFabricanteForcaVenda(response || []);
        } catch (error) {
            console.error('Erro ao consultar fabricantes FV:', error);
            setlistFabricanteForcaVenda([]);
        }
    };

    const consultaTipoContrato = async () => {
        try {
            const response = await myModule.contrato.tipoContratoConsultar({});
            setlistTipoContrato(response || []);
        } catch (error) {
            console.error('Erro ao consultar tipos de contrato:', error);
            setlistTipoContrato([]);
        }
    };



    useEffect(() => {
        myModule = new moduleFaturamento(user, __SIS_AC_CD);
        myModuleForcaVenda = new moduleForcaVenda(user,__SIS_AC_CD);
        const fetchData = async () => {
            if (user) {
                await ConsultaFabricanteFv();
                await consultaTipoContrato();
            }
        };
        fetchData();
    }, []);

    const validarPeriodo = (): boolean => {
        if (!contrato_data_val_ini || !contrato_data_val_fim) {
            setMessageInfo("Informe a data inicial e final.");
            return false;
        }

        if (contrato_data_val_ini > contrato_data_val_fim) {
            setMessageInfo("A data inicial não pode ser maior que a data final.");
            return false;
        }
        return true;
    };
    
    const Pesquisar = async () => {
        setMessageInfo("");
        if (!contrato_data_val_ini || !contrato_data_val_fim) {
            setMessageInfo("Informe a data inicial e final.");
            return;
        }
        if (contrato_data_val_ini > contrato_data_val_fim) {
            setMessageInfo("A data inicial não pode ser maior que a data final.");
            return;
        }
        if (!validarPeriodo()) {
            return;
        }

        try {
            setActionStatus(1);
            let parametros : any = { 
                contrato_data_val_ini,
                contrato_data_val_fim,
                contrato_tipo_cd: contrato_tipo_cd_filter,
                contrato_status: contrato_statusFilter,
                competencia_cd
            }

            const response = await myModule.contrato.contratoList(parametros)
            setlistContrato(response || [])

        } catch (error) {
            setMessageInfo("Erro ao pesquisar o resumo de vendas.");
        } finally {
            setActionStatus(0);
        }
    };

    const processarApurarContrato = async (contrato: any) => {
        try { 
            let parametro : any = {
                competencia_cd,
                faturamento_controle_seq: 0,
                contrato_seq: contrato.contrato_seq,
                data_val_ini: contrato.contrato_data_val_ini,
                data_val_fim: contrato.contrato_data_val_fim,

            }
            setActionStatus(1);
            await myModule.contrato.contratoProcessarApurar(parametro);
            setActionStatus(0);
        } catch { 
            setActionStatus(0);
            setMessageInfo("Erro ao processar o contrato.");
        }
    };

    const ProcessarApurarCompetencia = async () => {
        setMessageInfo("");
        try {
            const parametro = {
                competencia_cd,
                faturamento_controle_seq: 0,
                contrato_seq: 0
            };
            setActionStatus(1);
            await myModule.contrato.contratoProcessarApurar(parametro);
            setMessageInfo("Competência processada e apurada com sucesso.");
        } catch {
            setMessageInfo("Erro ao processar a competência.");
        } finally {
            setActionStatus(0);
        }
    };


    const inativarContrato = async (contrato: any) => {
        try { 
            let parametro : any = {
                faturamento_controle_seq: 0,
                contrato_seq: contrato.contrato_seq,
                data_val_ini: contrato.contrato_data_val_ini,
                data_val_fim: contrato.contrato_data_val_fim,

            }
            setActionStatus(1);
            await myModule.contrato.contratoInativar(parametro); 
            setActionStatus(0);
        } catch { 
            setActionStatus(0);
            setMessageInfo("Erro ao inativar o contrato.");
        }
    };

    const confirmarOperacao = async () => {
        if (!confirmacao) return;

        const { acao, contrato } = confirmacao;
        setConfirmacao(null);

        if (acao === 'processar') {
            await processarApurarContrato(contrato);
        } else {
            await inativarContrato(contrato);
        }
    };





    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain
                    tipo={"_PAGE"}
                    ActionStatus={ActionStatus}
                    header_title="Faturamento | Contrato"
                >
                    <div className="flex space-x-2">
                        <ButtonPag TypeButton="_BUTTON_HEADER" label="Novo Lançamento" TypeIcon="_NEW" title="Novo" onClick={() => { setModoModal('consulta'); setContratoSeqConsulta(undefined); setIsModalOpen(true) }} ActionStatus={ActionStatus}></ButtonPag>
                        <ButtonPag TypeButton="_BUTTON_HEADER" label="Atualizar Comp." TypeIcon="_UPDATE" title="Atualizar Comp." onClick={ProcessarApurarCompetencia} ActionStatus={ActionStatus}></ButtonPag>
                        <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={Pesquisar} ActionStatus={ActionStatus}></ButtonPag>
                        
                        
                    </div>
                </HeaderMain>

                {messageInfo && (
                    <div
                        role={messageInfo.startsWith("Erro") ? "alert" : "status"}
                        aria-live="polite"
                        className={`mb-4 rounded-md border p-3 text-sm ${
                            messageInfo.startsWith("Erro")
                                ? "border-red-200 bg-red-50 text-red-800"
                                : "border-blue-200 bg-blue-50 text-blue-800"
                        }`}
                    >
                        {messageInfo}
                    </div>
                )}

                {/* Área de Filtros */}
                <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-blue-100">
                    <h3 className="text-lg font-medium text-gray-900 mb-4">Filtros</h3>
                    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-8 gap-4">
                        {/* Tipo Contrato */}
                        <div className="lg:col-span-2">
                            <label className="block text-sm font-medium text-gray-700 mb-1">
                                Tipo Contrato <span className="text-red-500">*</span>
                            </label>
                            <select
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black"
                                value={contrato_tipo_cd_filter}
                                disabled={ActionStatus === 1}
                                onChange={(e) => {set_contrato_tipo_cd(e.target.value)}}
                            >
                                <option value="0">Selecione um tipo de contrato...</option>
                                {(listTipoContrato.length > 0) && listTipoContrato.map((tipoContrato) => (
                                    <option key={tipoContrato.contrato_tipo_cd} value={tipoContrato.contrato_tipo_cd}>
                                        {tipoContrato.contrato_tipo_descricao}
                                    </option>
                                ))}
                            </select>
                        </div>

                        {/* Competência */}
                        <div className="lg:col-span-2">
                            <label className="block text-sm font-medium text-gray-700 mb-1">
                                Competência (Ano / Mês) <span className="text-red-500">*</span>
                            </label>
                            <div className="flex gap-2">
                                <input
                                    id="competencia-ano"
                                    type="text"
                                    inputMode="numeric"
                                    aria-label="Ano da competência"
                                    placeholder="Ano"
                                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black"
                                    value={competencia_ano}
                                    onChange={(e) => set_competencia_ano(Number(e.target.value))}
                                />
                                <select
                                    id="competencia-mes"
                                    aria-label="Mês da competência"
                                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black"
                                    value={competencia_mes}
                                    onChange={(e) => set_competencia_mes(Number(e.target.value))}
                                >
                                    {Object.entries(competencia_list)
                                        .sort(([mesA], [mesB]) => Number(mesA) - Number(mesB))
                                        .map(([mes, descricao]) => (
                                            <option key={mes} value={Number(mes)}>
                                                {descricao}
                                            </option>
                                        ))}
                                </select>
                            </div>
                        </div>



                        
                        {/* Combobox Fabricante */}
                        <div className="lg:col-span-2">
                            <label className="block text-sm font-medium text-gray-700 mb-1">
                                Fabricante <span className="text-red-500">*</span>
                            </label>
                            <select
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black"
                                disabled={ActionStatus === 1}
                                value={cdpessoabluesoftfabricanteFilter}
                                onChange={(e) => {setcdpessoabluesoftfabricanteFilter(e.target.value)}}
                            >
                                <option value="0">Selecione um fabricante...</option>
                                {(listFabricanteForcaVenda.length > 0) && listFabricanteForcaVenda.map((fabricante) => (
                                    <option key={fabricante.fv_fabricante_cdpessoabluesoft} value={fabricante.fv_fabricante_cdpessoabluesoft}>
                                        {fabricante.fv_fabricante_descricao}
                                    </option>
                                ))}
                            </select>
                        </div>  
                        {/* Campo Data Vigência */}
                        <div className="lg:col-span-1">
                            <label className="block text-sm font-medium text-gray-700 mb-1">Vigência Inicial</label>
                            <input
                                type="date"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black"
                                disabled={ActionStatus === 1}
                                value={contrato_data_val_ini}
                                onChange={(e) => setcontrato_data_val_ini(e.target.value)}
                            />
                        </div>

                        <div className="lg:col-span-1">
                            <label className="block text-sm font-medium text-gray-700 mb-1">Vigência Final</label>
                            <input
                                type="date"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black"
                                disabled={ActionStatus === 1}
                                value={contrato_data_val_fim}
                                onChange={(e) => setcontrato_data_val_fim(e.target.value)}
                            />
                        </div>
                        {/* Campo Status */}
                        <div className="lg:col-span-2">
                            <label className="block text-sm font-medium text-gray-700 mb-1">Status</label>
                            <select
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black"
                                disabled={ActionStatus === 1}
                                value={contrato_statusFilter}
                                onChange={(e) => set_contrato_status(e.target.value)}
                            >
                                <option value="9">Todos</option>
                                <option value="1">Ativo</option>
                                <option value="0">Inativo</option>
                            </select>
                        </div>                        
                        {/* Campo Codigo Produto */}
                        <div className="lg:col-span-4">
                            <label className="block text-sm font-medium text-gray-700 mb-1">Código do Produto</label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black"
                                disabled={ActionStatus === 1}
                                placeholder="Filtrar por código do produto"
                                value={prb_cdprodutoBluesoftFilter}
                                onChange={(e) => setprb_cdprodutoBluesoftFilter(e.target.value)}
                            />
                        </div>  
                        {/* Campo Descrição Produto */}
                        <div className="lg:col-span-4">
                            <label className="block text-sm font-medium text-gray-700 mb-1">Descrição do Produto</label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black"
                                disabled={ActionStatus === 1}
                                placeholder="Filtrar por descrição do produto"
                                value={prb_descricaoFilter}
                                onChange={(e) => setprb_descricaoFilter(e.target.value)}
                            />
                        </div>  
                       
                    </div>
                </div>

                {/* Resultado */}
                <div className="bg-white rounded-lg shadow-md border border-blue-100 overflow-x-auto">
                    <table className="min-w-full divide-y divide-gray-200 text-sm">
                        <thead className="bg-gray-100">
                            <tr>
                                <th className="px-4 py-2 text-left font-medium text-gray-700">Seq</th>
                                <th className="px-4 py-2 text-left font-medium text-gray-700">Descrição</th>
                                <th className="px-4 py-2 text-left font-medium text-gray-700">Data</th>
                                <th className="px-4 py-2 text-left font-medium text-gray-700">Tipo</th>
                                <th className="px-4 py-2 text-left font-medium text-gray-700">Vigência Inicial</th>
                                <th className="px-4 py-2 text-left font-medium text-gray-700">Vigência Final</th>
                                <th className="px-4 py-2 text-left font-medium text-gray-700">Dados de Contrato Vinculado</th>

                                <th className="px-4 py-2 text-center font-medium text-gray-700">Ação</th>
                            </tr>
                        </thead>
                        <tbody className="divide-y divide-gray-100 text-black">
                            {listContrato.length === 0 ? (
                                <tr>
                                    <td colSpan={7} className="px-4 py-4 text-center text-gray-500">Nenhum contrato encontrado.</td>
                                </tr>
                            ) : listContrato.map((c, i) => (
                                <tr key={c.contrato_seq ?? i} className="hover:bg-gray-50">
                                    <td className="px-4 py-2">
                                        <button
                                            type="button"
                                            disabled={ActionStatus === 1}
                                            className="text-blue-600 hover:underline"
                                            onClick={() => { setModoModal('consulta'); setContratoSeqConsulta(Number(c.contrato_seq)); setIsModalOpen(true) }}
                                        >
                                            {c.contrato_seq}
                                        </button>
                                    </td>
                                    <td className="px-4 py-2">{c.contrato_descricao}</td>
                                    <td className="px-4 py-2">{fmtData(c.contrato_data)}</td>
                                    <td className="px-4 py-2">{c.contrato_tipo_descricao}</td>
                                    <td className="px-4 py-2">{fmtData(c.contrato_data_val_ini)}</td>
                                    <td className="px-4 py-2">{fmtData(c.contrato_data_val_fim)}</td>
                                    <td className="px-4 py-2">
                                        <div>Número do Pedido: {c.numeropedido} - {c.numeropedido_fv} </div>
                                        <div>Cliente {c.nome_razao}</div>


                                    </td>
                                    <td className="px-4 py-2 text-center">
                                        <ButtonPag
                                            TypeButton="_BUTTON_ICON"
                                            label=""
                                            TypeIcon="_EDIT"
                                            title="Editar contrato"
                                            ActionStatus={ActionStatus}
                                            onClick={() => {
                                                setModoModal('edicao');
                                                setContratoSeqConsulta(Number(c.contrato_seq));
                                                setIsModalOpen(true);
                                            }}
                                        />
                                        <button
                                            type="button"
                                            title="Processar e apurar contrato"
                                            className="px-4 py-1 rounded-full bg-blue-600 text-white text-xs font-medium hover:bg-blue-700 disabled:opacity-50"
                                            disabled={ActionStatus === 1}
                                            onClick={() => setConfirmacao({ acao: 'processar', contrato: c })}
                                        >
                                            Processar e Apurar
                                        </button>
                                        <button
                                            type="button"
                                            title="Inativar contrato"
                                            className="ml-2 px-4 py-1 rounded-full bg-blue-600 text-white text-xs font-medium hover:bg-blue-700 disabled:opacity-50"
                                            disabled={ActionStatus === 1}
                                            onClick={() => setConfirmacao({ acao: 'inativar', contrato: c })}
                                        >
                                            Inativar
                                        </button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>

            </div>

            <ConfirmDialog
                open={confirmacao !== null}
                title={confirmacao?.acao === 'inativar' ? 'Inativar contrato' : 'Processar contrato'}
                message={confirmacao?.acao === 'inativar'
                    ? 'Deseja realmente inativar este contrato?'
                    : 'Deseja realmente processar este contrato?'}
                confirmLabel={confirmacao?.acao === 'inativar' ? 'Inativar' : 'Processar'}
                onConfirm={confirmarOperacao}
                onCancel={() => setConfirmacao(null)}
            />

            {isModalOpen && (
                <div className="fixed inset-0 z-50 flex items-start justify-center bg-black/50 overflow-y-auto">
                    <div className="bg-white w-full max-w-3xl my-6 mx-4 rounded-lg shadow-xl">
                        <ModalContrato
                            key={`${contratoSeqConsulta ?? 'novo'}-${modoModal}`}
                            contrato_seq={contratoSeqConsulta}
                            modo={modoModal}
                            sis_ac_cd={__SIS_AC_CD}
                            competencia_cd={competencia_cd}
                            listTipoContrato={listTipoContrato}
                            listFabricante={listFabricanteForcaVenda}
                            onClose={() => setIsModalOpen(false)}
                            onSaved={Pesquisar}
                        />
                    </div>
                </div>
            )}
        </div>
    );
}
