'use client'
const __SIS_AC_CD : number = 1012

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";


import { moduleInformativo } from '@/api/m1000_informativo/moduleinformativo'; 

type tipoEmail = { 
    tipo: string;
    descricao: string;
}



let myModule: moduleInformativo;

export default function InformativoEmail() {
    
    
    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);
    const [ListTipoEmails, setListTipoEmails] = useState<tipoEmail[]>([]);
    const [SelectedTipoEmail, setSelectedTipoEmail] = useState<tipoEmail | null>(null); 
    const [emailConferencia, setEmailConferencia] = useState<string>("");
    const [emailForcaEnvioEmailControlado, setemailForcaEnvioEmailControlado] = useState<boolean>(false);
    const [competenciaAno, setCompetenciaAno] = useState<string>("2026");
    const [competenciaMes, setCompetenciaMes] = useState<string>("10");
    const [dataProcessamentoIni, setDataProcessamentoIni] = useState<string>("2026-10-01");
    const [dataProcessamentoFim, setDataProcessamentoFim] = useState<string>("2026-10-31");
   

    useEffect(() => {
        const initializeModule = async () => {
         
            setListTipoEmails([
                { tipo: "if0017", descricao: "IF0017 - Distribuição | Análise de GIRO E ESTOQUE" },
                { tipo: "if0045", descricao: "IF0045 - Distribuição | Mix Johnson" },
                { tipo: "if0100", descricao: "IF0100 - Distribuição | Análise de Venda " },
                { tipo: "if0050", descricao: "IF0050 - Distribuição | Notificação de Cortes - Por e-mail " },
                { tipo: "if0110", descricao: "IF0110 - Distribuição | Comissão " }
            ]);
            setSelectedTipoEmail({ tipo: "if0017", descricao: "IF0017 - Distribuição | Análise de GIRO E ESTOQUE" });

            myModule = new moduleInformativo(user, __SIS_AC_CD);

        };

        initializeModule();
    }, []);

  
    const EnviaMail = async () => {
        try {
            setActionStatus(1);

            const response = 
            await myModule.email({ 
                  tipo: SelectedTipoEmail?.tipo || ""
                , email_conferencia: emailConferencia 
                , email_forca_envio_email_controlado: emailForcaEnvioEmailControlado? 1 : 0
                , competencia_cd: Number(`${competenciaAno}${competenciaMes.padStart(2, '0')}`)
                , data_processamento_ini: dataProcessamentoIni
                , data_processamento_fim: dataProcessamentoFim
            });


            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setActionStatus(0);
        }
    };

 
    return (
        <div className="min-h-screen bg-gray-50 p-4 sm:p-6">
            <div className="mx-auto max-w-5xl">
                <HeaderMain
                    tipo={"_PAGE"}
                    ActionStatus={ActionStatus}
                    header_title="Informativo | Operações"
                >
                    <></>
                </HeaderMain>

                

                <section className="overflow-hidden rounded-xl border border-gray-200 bg-white shadow-sm">
                    <div className="border-b border-gray-100 px-5 py-4 sm:px-6">
                        <h2 className="text-base font-semibold text-gray-800">
                            Envio de informativos
                        </h2>
                        <p className="mt-1 text-sm text-gray-500">
                            Escolha o relatório e, se necessário, informe um endereço para conferência.
                        </p>
                    </div>

                    <div className="p-5 sm:p-6">
                        <div className="grid grid-cols-1 gap-5 md:grid-cols-2">
                            <div className="min-w-0">
                                <label htmlFor="tipoEmail" className="mb-1.5 block text-sm font-medium text-gray-700">
                                    Tipo de e-mail
                                </label>
                                <select
                                    id="tipoEmail"
                                    value={SelectedTipoEmail?.tipo || ""}
                                    disabled={ActionStatus === 1}
                                    onChange={(e) => {
                                        const selected = ListTipoEmails.find(item => item.tipo === e.target.value);
                                        setSelectedTipoEmail(selected || null);
                                    }}
                                    className="block w-full rounded-md border border-gray-300 bg-white px-3 py-2.5 text-sm text-gray-800 shadow-sm outline-none transition focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200"
                                >
                                    {ListTipoEmails.map((item) => (
                                        <option key={item.tipo} value={item.tipo}>
                                            {item.descricao}
                                        </option>
                                    ))}
                                </select>
                            </div>

                            <div className="min-w-0">
                                <label htmlFor="emailTeste" className="mb-1.5 block text-sm font-medium text-gray-700">
                                    E-mail para conferência
                                    <span className="ml-1 font-normal text-gray-400">(opcional)</span>
                                </label>
                                <input
                                    id="emailTeste"
                                    type="email"
                                    value={emailConferencia}
                                    disabled={ActionStatus === 1}
                                    onChange={(e) => setEmailConferencia(e.target.value)}
                                    placeholder="exemplo@empresa.com"
                                    className="block w-full rounded-md border border-gray-300 px-3 py-2.5 text-sm text-gray-800 shadow-sm outline-none transition placeholder:text-gray-400 focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200"
                                />
                            </div>
                            <fieldset className="min-w-0">
                                <legend className="mb-1.5 block text-sm font-medium text-gray-700">
                                    Competência
                                </legend>
                                <div className="grid grid-cols-2 gap-3">
                                    <div>
                                        <label htmlFor="competenciaAno" className="mb-1 block text-xs text-gray-500">
                                            Ano
                                        </label>
                                        <input
                                            id="competenciaAno"
                                            type="number"
                                            min="1000"
                                            max="9999"
                                            value={competenciaAno}
                                            disabled={ActionStatus === 1}
                                            onChange={(e) => setCompetenciaAno(e.target.value)}
                                            className="block w-full rounded-md border border-gray-300 px-3 py-2.5 text-sm text-gray-800 shadow-sm outline-none focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200"
                                        />
                                    </div>
                                    <div>
                                        <label htmlFor="competenciaMes" className="mb-1 block text-xs text-gray-500">
                                            Mês
                                        </label>
                                        <input
                                            id="competenciaMes"
                                            type="number"
                                            min="1"
                                            max="12"
                                            value={competenciaMes}
                                            disabled={ActionStatus === 1}
                                            onChange={(e) => setCompetenciaMes(e.target.value)}
                                            className="block w-full rounded-md border border-gray-300 px-3 py-2.5 text-sm text-gray-800 shadow-sm outline-none focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200"
                                        />
                                    </div>
                                </div>
                            </fieldset>
                            <div className="grid min-w-0 grid-cols-2 gap-3 md:col-span-2">
                                <div className="min-w-0">
                                    <label htmlFor="dataProcessamentoIni" className="mb-1.5 block text-sm font-medium text-gray-700">
                                        Início do período
                                    </label>
                                    <input
                                        id="dataProcessamentoIni"
                                        type="date"
                                        value={dataProcessamentoIni}
                                        disabled={ActionStatus === 1}
                                        onChange={(e) => setDataProcessamentoIni(e.target.value)}
                                        className="block w-full min-w-0 rounded-md border border-gray-300 px-2 py-2.5 text-sm text-gray-800 shadow-sm outline-none focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200 sm:px-3"
                                    />
                                </div>
                                <div className="min-w-0">
                                    <label htmlFor="dataProcessamentoFim" className="mb-1.5 block text-sm font-medium text-gray-700">
                                        Fim do período
                                    </label>
                                    <input
                                        id="dataProcessamentoFim"
                                        type="date"
                                        value={dataProcessamentoFim}
                                        disabled={ActionStatus === 1}
                                        onChange={(e) => setDataProcessamentoFim(e.target.value)}
                                        className="block w-full min-w-0 rounded-md border border-gray-300 px-2 py-2.5 text-sm text-gray-800 shadow-sm outline-none focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200 sm:px-3"
                                    />
                                </div>
                            </div>
                            <div className="min-w-0">
                                <label htmlFor="emailForcaEnvioEmailControlado" className="mb-1.5 block text-sm font-medium text-gray-700">
                                    Forçar envio de e-mail controlado
                                </label>
                                <input
                                    id="emailForcaEnvioEmailControlado"
                                    type="checkbox"
                                    checked={emailForcaEnvioEmailControlado}
                                    disabled={ActionStatus === 1}
                                    onChange={(e) => setemailForcaEnvioEmailControlado(e.target.checked)}
                                    className="h-4 w-4 rounded border-gray-300 text-indigo-600 focus:ring-indigo-500"
                                />
                            </div>
                        </div>

                        <div className="mt-6 flex justify-stretch border-t border-gray-100 pt-5 sm:justify-end">
                            <button
                                type="button"
                                className="inline-flex w-full items-center justify-center gap-2 rounded-md bg-green-600 px-4 py-2.5 text-sm font-medium text-white shadow-sm transition hover:bg-green-700 focus:outline-none focus:ring-2 focus:ring-green-500 focus:ring-offset-2 disabled:cursor-not-allowed disabled:opacity-70 sm:w-auto"
                                title="Enviar e-mail"
                                onClick={() => EnviaMail()}
                                disabled={ActionStatus === 1}
                            >
                                {ActionStatus === 1 ? (
                                    <svg className="h-4 w-4 animate-spin" fill="none" viewBox="0 0 24 24" aria-hidden="true">
                                        <circle className="opacity-25" cx="12" cy="12" r="10" stroke="white" strokeWidth="4" />
                                        <path className="opacity-75" fill="white" d="M4 12a8 8 0 018-8v8z" />
                                    </svg>
                                ) : (
                                    <svg className="h-4 w-4" fill="none" stroke="currentColor" strokeWidth={2} viewBox="0 0 24 24" aria-hidden="true">
                                        <path strokeLinecap="round" strokeLinejoin="round" d="M5 12h14m-6-6 6 6-6 6" />
                                    </svg>
                                )}
                                Enviar e-mail
                            </button>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    );
}