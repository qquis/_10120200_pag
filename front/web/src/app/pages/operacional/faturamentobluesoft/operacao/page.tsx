'use client'
const __SIS_AC_CD : number = 1012

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";


import { moduleFaturamentoBluesoft } from '@/api/m0050_faturamentoBluesoft/moduleFaturamentoBluesoft'; 


type tipoPeriodo = "EMISSAO" | "ALTERACAO" 


let myModule: moduleFaturamentoBluesoft;

export default function ForcaVendaOperacao() {
    
    
    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);
    const [DataInicialAPI, setDataInicialAPI] = useState<string>("");
    const [DataFinalAPI, setDataFinalAPI] = useState<string>("");
    const [TipoPeriodoApi, setTipoPeriodoApi] = useState<string>("")

    const [DataInicialRedshift, setDataInicialRedshift] = useState<string>("");
    const [DataFinalRedshift, setDataFinalRedshift] = useState<string>("");
    const [ExecuteOverwriteRedshift, setExecuteOverwriteRedshift] = useState<string>("0");
    const [dtlog_insert_inicial, setDtlog_insert_inicial] = useState<string>("");
    const [dtlog_insert_final, setDtlog_insert_final] = useState<string>("");
    const [ListLog, setListLog] = useState<any[]>([]);


    const formatDateInput = (date: Date) => {
        const local = new Date(date.getTime() - date.getTimezoneOffset() * 60000);
        return local.toISOString().slice(0, 10);
    };

    useEffect(() => {
        const initializeModule = async () => {
            const hoje = new Date();
            const cincoDiasAtras = new Date();  cincoDiasAtras.setDate(hoje.getDate() - 5);

            

            setDtlog_insert_inicial(formatDateInput(hoje));
            setDtlog_insert_final(formatDateInput(hoje));

            setDataInicialAPI(formatDateInput(cincoDiasAtras));
            setDataFinalAPI(formatDateInput(hoje));
            setDataInicialRedshift(formatDateInput(cincoDiasAtras));
            setDataFinalRedshift(formatDateInput(hoje));

            setTipoPeriodoApi("EMISSAO")

            myModule = new moduleFaturamentoBluesoft(user, __SIS_AC_CD);

        };

        initializeModule();
    }, []);

  
    const AtualizacaoFromBaseAPI = async () => {
        try {
            setActionStatus(1);

            const response = await myModule.postAtualizarBaseFromApi({
                dataInicial: DataInicialAPI,
                dataFinal: DataFinalAPI,
                tipo_periodo: TipoPeriodoApi

            });
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setActionStatus(0);
        }
    };

    const AtualizacaoFromBaseRedShift = async () => {
        try {
            setActionStatus(1);

            const response = await myModule.postAtualizarBaseFromRedShift({
                dataInicial: DataInicialRedshift,
                dataFinal: DataFinalRedshift,
                executeoverwrite: ExecuteOverwriteRedshift
            });
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setActionStatus(0);
        }
    };

    const AtualizacaoPendente = async () => {
        try {
            setActionStatus(1);

            const response = await myModule.postAtualizarPendente({})
            
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setActionStatus(0);
        }
    };    

    const ConsultarLogsImportacao = async () => {
        try { 

            setActionStatus(1);
            setListLog([])
            let listLog = await myModule.getLogFaturamentoBluesoft(
                {   dtlog_insert_inicial: dtlog_insert_inicial + " 00:00:00", 
                    dtlog_insert_final: dtlog_insert_final + " 23:59:59",
                })
            setListLog(listLog as any[])
            setActionStatus(0);

        } catch (error) {
            setActionStatus(0);
            console.error('Erro ao consultar serviços:', error);
        }

    }

 
    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Força de Venda | Operações">
                    <div></div>

                </HeaderMain>

        <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4">
            <div className="flex flex-col gap-4">
                
                <div className="flex justify-start">
                    <h2 className="text-base font-semibold text-gray-800">
                        Execução diária do Módulo de Faturamento Bluesoft (Processamento de Pendentes e Envio de E-mails)
                    </h2>
                </div>

                <div className="flex flex-col md:flex-row md:items-end gap-4">
                 

                   

                   <button
                        type="button"
                        className="inline-flex items-center justify-center gap-1 h-8 px-2.5 text-xs font-medium bg-green-600 hover:bg-green-700 text-white rounded-md shadow-sm transition disabled:opacity-70 disabled:cursor-not-allowed"
                        title="Atualizar Base Geral de Preços do Força de Venda"
                        onClick={AtualizacaoPendente}
                        disabled={ActionStatus === 1}
                    >
                        {ActionStatus === 1 ? (
                        <svg className="w-3.5 h-3.5 animate-spin" fill="none" viewBox="0 0 24 24">
                            <circle className="opacity-25" cx="12" cy="12" r="10" stroke="white" strokeWidth="4" />
                            <path className="opacity-75" fill="white" d="M4 12a8 8 0 018-8v8z" />
                        </svg>
                        ) : (
                        <svg className="w-3.5 h-3.5" fill="none" stroke="currentColor" strokeWidth={2} viewBox="0 0 24 24">
                            <path strokeLinecap="round" strokeLinejoin="round" d="M12 4v16m8-8H4" />
                        </svg>
                        )}
                        Atualização Pendente Diária
                    </button>

                </div>
            </div>
        </div>                

        <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4">
            
            <div className="flex flex-col gap-4">
                
                <div className="flex justify-start">
                    <h2 className="text-base font-semibold text-gray-800">
                        Importar dados da API
                    </h2>
                </div>

                <div className="flex flex-col md:flex-row md:items-end gap-4">
                    <div className="flex flex-col min-w-[180px]">
                        <label htmlFor="dataInicial" className="text-sm font-medium text-gray-700 mb-1">
                            Data Inicial
                        </label>
                        <input
                            id="dataInicial"
                            name="dataInicial"
                            type="date"
                            value={DataInicialAPI}
                            onChange={(e) => setDataInicialAPI(e.target.value)}
                            className="px-3 py-2 border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-2 focus:ring-green-500"
                        />
                    </div>

                    <div className="flex flex-col min-w-[180px]">
                        <label htmlFor="dataFinal" className="text-sm font-medium text-gray-700 mb-1">
                            Data Final
                        </label>
                        <input
                            id="dataFinal"
                            name="dataFinal"
                            type="date"
                            value={DataFinalAPI}
                            onChange={(e) => setDataFinalAPI(e.target.value)}
                            className="px-3 py-2 border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-2 focus:ring-green-500"
                        />
                    </div>
                    <div className="flex flex-col min-w-[180px]">
                        <label htmlFor="tipoPeriodo" className="text-sm font-medium text-gray-700 mb-1">
                            Tipo de Período
                        </label>
                        <select
                            id="tipoPeriodo"
                            name="tipoPeriodo"
                            value={TipoPeriodoApi}
                            onChange={(e) => setTipoPeriodoApi(e.target.value)}
                            className="px-3 py-2 border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-2 focus:ring-green-500"
                        >
                            <option value="EMISSAO">Data de Emissão</option>
                            <option value="ALTERACAO">Data de Alteração</option>
                        </select>
                    </div>

                   <button
                        type="button"
                        className="inline-flex items-center justify-center gap-1 h-8 px-2.5 text-xs font-medium bg-green-600 hover:bg-green-700 text-white rounded-md shadow-sm transition disabled:opacity-70 disabled:cursor-not-allowed"
                        title="Atualizar Base Geral de Preços do Força de Venda"
                        onClick={AtualizacaoFromBaseAPI}
                        disabled={ActionStatus === 1}
                    >
                        {ActionStatus === 1 ? (
                        <svg className="w-3.5 h-3.5 animate-spin" fill="none" viewBox="0 0 24 24">
                            <circle className="opacity-25" cx="12" cy="12" r="10" stroke="white" strokeWidth="4" />
                            <path className="opacity-75" fill="white" d="M4 12a8 8 0 018-8v8z" />
                        </svg>
                        ) : (
                        <svg className="w-3.5 h-3.5" fill="none" stroke="currentColor" strokeWidth={2} viewBox="0 0 24 24">
                            <path strokeLinecap="round" strokeLinejoin="round" d="M12 4v16m8-8H4" />
                        </svg>
                        )}
                        Importar dados da API
                    </button>
                </div>
            </div>
        </div>

        <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4">
            <div className="flex flex-col gap-4">
                
                <div className="flex justify-start">
                    <h2 className="text-base font-semibold text-gray-800">
                        Importar dados Base Redshift (D-1)
                    </h2>
                </div>

                <div className="flex flex-col md:flex-row md:items-end gap-4">
                    <div className="flex flex-col min-w-[180px]">
                        <label htmlFor="dataInicial" className="text-sm font-medium text-gray-700 mb-1">
                            Data Inicial
                        </label>
                        <input
                            id="dataInicial"
                            name="dataInicial"
                            type="date"
                            value={DataInicialRedshift}
                            onChange={(e) => setDataInicialRedshift(e.target.value)}
                            className="px-3 py-2 border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-2 focus:ring-green-500"
                        />
                    </div>

                    <div className="flex flex-col min-w-[180px]">
                        <label htmlFor="dataFinal" className="text-sm font-medium text-gray-700 mb-1">
                            Data Final
                        </label>
                        <input
                            id="dataFinal"
                            name="dataFinal"
                            type="date"
                            value={DataFinalRedshift}
                            onChange={(e) => setDataFinalRedshift(e.target.value)}
                            className="px-3 py-2 border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-2 focus:ring-green-500"
                        />
                    </div>
                    <div className="flex flex-col min-w-[180px]">
                        <label htmlFor="tipoPeriodo" className="text-sm font-medium text-gray-700 mb-1">
                            Tipo de Período
                        </label>
                        <select
                            disabled={true}
                            id="tipoPeriodo"
                            name="tipoPeriodo"
                            className="px-3 py-2 border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-2 focus:ring-green-500"
                        >
                            <option value="EMISSAO">Data de Emissão</option>
                        </select>
                    </div>

                   <button
                        type="button"
                        className="inline-flex items-center justify-center gap-1 h-8 px-2.5 text-xs font-medium bg-green-600 hover:bg-green-700 text-white rounded-md shadow-sm transition disabled:opacity-70 disabled:cursor-not-allowed"
                        title="Atualizar Base Geral de Preços do Força de Venda"
                        onClick={AtualizacaoFromBaseRedShift}
                        disabled={ActionStatus === 1}
                    >
                        {ActionStatus === 1 ? (
                        <svg className="w-3.5 h-3.5 animate-spin" fill="none" viewBox="0 0 24 24">
                            <circle className="opacity-25" cx="12" cy="12" r="10" stroke="white" strokeWidth="4" />
                            <path className="opacity-75" fill="white" d="M4 12a8 8 0 018-8v8z" />
                        </svg>
                        ) : (
                        <svg className="w-3.5 h-3.5" fill="none" stroke="currentColor" strokeWidth={2} viewBox="0 0 24 24">
                            <path strokeLinecap="round" strokeLinejoin="round" d="M12 4v16m8-8H4" />
                        </svg>
                        )}
                        Importar dados da base Redshift
                    </button>
                    <label className="inline-flex items-center gap-2 text-sm font-medium text-gray-700">
                    <input
                    type="checkbox"
                    className="h-4 w-4 rounded border-gray-300 text-green-600 focus:ring-green-500"
                    checked={ExecuteOverwriteRedshift === "1"}
                    onChange={(e) => setExecuteOverwriteRedshift(e.target.checked ? "1" : "0")}
                    />
                    Reexecutar mesmo se já executado hoje
                    </label>
                </div>
            </div>
        </div>






<div className="flex justify-end">
    <div className="w-5/6 bg-white border border-gray-200 rounded-xl shadow-sm p-4 flex flex-col gap-4">

        <div className="flex justify-start">
            <h2 className="text-base font-semibold text-gray-800">Logs do Módulo</h2>
        </div>

        {/* Filtros em linha */}
        <div className="flex flex-col md:flex-row md:items-end gap-3">
            <div className="flex flex-col min-w-[180px]">
                <label htmlFor="dtlog_insert_inicial" className="text-sm font-medium text-gray-700 mb-1">
                    Dt. Log Inicial
                </label>
                <input
                    id="dtlog_insert_inicial"
                    name="dtlog_insert_inicial"
                    type="date"
                    value={dtlog_insert_inicial}
                    onChange={(e) => setDtlog_insert_inicial(e.target.value)}
                    className="px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
                />
            </div>

            <div className="flex flex-col min-w-[180px]">
                <label htmlFor="dtlog_insert_final" className="text-sm font-medium text-gray-700 mb-1">
                    Dt. Log Final
                </label>
                <input
                    id="dtlog_insert_final"
                    name="dtlog_insert_final"
                    type="date"
                    value={dtlog_insert_final}
                    onChange={(e) => setDtlog_insert_final(e.target.value)}
                    className="px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
                />
            </div>

            <button
                type="button"
                className="inline-flex items-center justify-center gap-1 h-10 px-4 text-sm font-medium bg-blue-600 hover:bg-blue-700 text-white rounded-md shadow-sm transition disabled:opacity-70 disabled:cursor-not-allowed"
                title="Pesquisar logs da importação"
                onClick={ConsultarLogsImportacao}
                disabled={ActionStatus === 1}
            >
                {ActionStatus === 1 ? (
                    <svg className="w-3.5 h-3.5 animate-spin" fill="none" viewBox="0 0 24 24">
                        <circle className="opacity-25" cx="12" cy="12" r="10" stroke="white" strokeWidth="4" />
                        <path className="opacity-75" fill="white" d="M4 12a8 8 0 018-8v8z" />
                    </svg>
                ) : (
                    <svg className="w-3.5 h-3.5" fill="none" stroke="currentColor" strokeWidth={2} viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" d="M21 21l-4.35-4.35M17 11A6 6 0 1 1 5 11a6 6 0 0 1 12 0z" />
                    </svg>
                )}
                Pesquisar logs
            </button>
        </div>

        {/* Tabela com scroll horizontal */}
        <div className="overflow-x-auto rounded-lg border border-gray-200">
            <table className="min-w-full divide-y divide-gray-200 text-xs">
                <thead className="bg-gray-50">
                    <tr>
                        <th className="px-3 py-2.5 text-left font-semibold text-gray-600 whitespace-nowrap">Dt Log</th>
                        <th className="px-3 py-2.5 text-left font-semibold text-gray-600 whitespace-nowrap">Informações</th>
                    </tr>
                </thead>
                <tbody className="divide-y divide-gray-100 bg-white">
                    {ListLog.length > 0 ? (
                        ListLog.map((item, index) => (
                            <tr key={item.sis_log_seq} className={index % 2 === 0 ? "hover:bg-blue-50/40" : "bg-gray-50/60 hover:bg-blue-50/40"}>
                                <td className="px-3 py-2 text-gray-700 whitespace-nowrap">
                                 <div> {item.dtlog_insert ? new Date(item.dtlog_insert).toLocaleString("pt-BR") : "-"}</div>
                                 <div> Seq.: {item.sis_log_seq} </div>
                                </td>
                                <td className="px-3 py-2 text-gray-700 whitespace-nowrap">
                                        <div>Cod Procedimento: {item.sis_nucleo_prc_cd} </div>
                                        <div>Descritivo: {item.sis_nucleo_prc_descritivo} </div>
                                        <div>Descrição: {item.sis_nucleo_prc_descricao}</div>
                                        <span className="inline-block px-1.5 py-0.5 rounded bg-blue-100 text-blue-700 font-mono text-[11px]">
                                            {item.sis_log_tag}
                                        </span>    
                                        <div className="font-bold">{item.sis_log_info}</div>
                                        
                                </td>


                            </tr>
                        ))
                    ) : (
                        <tr>
                            <td colSpan={7} className="px-4 py-8 text-sm text-center text-gray-400 italic">
                                Nenhum log encontrado para o período informado
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>

    </div>
</div>




        </div>


    </div>

    );
}