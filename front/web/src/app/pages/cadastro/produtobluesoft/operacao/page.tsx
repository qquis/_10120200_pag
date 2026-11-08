'use client'
const __SIS_AC_CD : number = 1012

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";


import { moduleProdutoBluesoft, type moduleProdutoBluesoftParametro } from "@/api/m0021_produtoBluesoft/moduleprodutobluesoft";





let myModule: moduleProdutoBluesoft;

export default function ParticipanteOperacao() {

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);
    const [numeroDiasUltimaAlteracao, setnumeroDiasUltimaAlteracao] = useState<number>(0);
    const [AtualizaLog, setAtualizaLog] = useState<number>(0);
    const [mensagemConclusao, setMensagemConclusao] = useState<string>('');

    useEffect(() => {
            myModule = new moduleProdutoBluesoft(user, __SIS_AC_CD);

    }, []);

  
    const AtualizarProdutoList = async () => {
        try {
            setActionStatus(1);
             setMensagemConclusao('');
            let parametros: moduleProdutoBluesoftParametro = {
                numeroDiasUltimaAlteracao: numeroDiasUltimaAlteracao,
                AtualizaLog: AtualizaLog,
                produtoKey: ""
            }

            const response = await myModule.postImportList(parametros);
            setMensagemConclusao('Importação concluída com sucesso.');
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao importar produtos Bluesoft:', error);
            setMensagemConclusao('Erro ao importar produtos Bluesoft.');
            setActionStatus(0);
        }
    };

    const integrarBluePag  = async () => {
        try {
            setActionStatus(1);
            setMensagemConclusao('');
            const response = await myModule.postIntegrarBluePag({});
            setMensagemConclusao('Integração com Blue/Pag concluída com sucesso.');
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao integrar Blue/Pag:', error);
            setMensagemConclusao('Erro ao integrar Blue/Pag.');
            setActionStatus(0);
        }
    };



 
    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Produto Bluesoft | Operações">
                    <div></div>

                </HeaderMain>




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
                                Número de Dias pendentes [ZERO para lista Geral]
                            </label>
                            <input
                                type="text"
                                className="px-3 py-2 border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-2 focus:ring-green-500  text-black"
                                value={numeroDiasUltimaAlteracao}
                                onChange={(e) => setnumeroDiasUltimaAlteracao(Number(e.target.value))}
                            />
                        </div>

                        <div className="flex flex-col min-w-[180px]">
                            <label htmlFor="dataInicial" className="text-sm font-medium text-gray-700 mb-1">
                                Gravar log de Pendência Zanthus
                            </label>
                            <input
                                type="checkbox"
                                className="px-3 py-2 border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-2 focus:ring-green-500"
                                checked={AtualizaLog === 1}
                                onChange={(e) => setAtualizaLog(e.target.checked ? 1 : 0)}
                            />
                        </div>


                    <button
                            type="button"
                            className="inline-flex items-center justify-center gap-1 h-8 px-2.5 text-xs font-medium bg-green-600 hover:bg-green-700 text-white rounded-md shadow-sm transition disabled:opacity-70 disabled:cursor-not-allowed"
                            title="Atualizar Base Geral de Preços do Força de Venda"
                            onClick={AtualizarProdutoList}
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
                            Importar
                        </button>
                    
                    </div>
                    
                </div>




            </div>

            <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4">

                <div className="flex flex-col gap-4 ">
                    
                    <div className="flex justify-start">
                        <h2 className="text-base font-semibold text-gray-800">
                        Integrar Blue/Pag
                        </h2>
                    </div>

                    <div className="flex flex-col md:flex-row md:items-end gap-4">
                            <label htmlFor="dataInicial" className="text-sm font-medium text-gray-700 mb-1">
                               Integração Blue/Pag 
                                <br />
                                Executa a função de banco de dados que atualiza os produtos Pag. 
                                <br />
                                Importante considerar que está função é executada automaticamente a cada 10m (aproximadamente)
                               <br />
                               [F0021_90_ProdutoBlueSoft_Processamento]
                            </label>

                    <button
                            type="button"
                            className="inline-flex items-center justify-center gap-1 h-8 px-2.5 text-xs font-medium bg-green-600 hover:bg-green-700 text-white rounded-md shadow-sm transition disabled:opacity-70 disabled:cursor-not-allowed"
                            title="Executar Integração Blue/Pag"
                            onClick={integrarBluePag}
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
                            Executar
                        </button>                    
                    </div>
                    
                </div>

            </div>


            {mensagemConclusao && (
                <span className={`inline-flex items-center gap-1.5 text-sm font-medium px-2.5 py-1 rounded-md ${
                    mensagemConclusao.toLowerCase().includes('erro')
                        ? 'text-red-700 bg-red-50 border border-red-200'
                        : 'text-green-700 bg-green-50 border border-green-200'
                }`}>
                    {mensagemConclusao.toLowerCase().includes('erro') ? (
                        <svg className="w-4 h-4" fill="none" stroke="currentColor" strokeWidth={2} viewBox="0 0 24 24">
                            <path strokeLinecap="round" strokeLinejoin="round" d="M12 9v2m0 4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                        </svg>
                    ) : (
                        <svg className="w-4 h-4" fill="none" stroke="currentColor" strokeWidth={2} viewBox="0 0 24 24">
                            <path strokeLinecap="round" strokeLinejoin="round" d="M5 13l4 4L19 7" />
                        </svg>
                    )}
                    {mensagemConclusao}
                </span>
            )}
            </div>
        </div>
    );
}