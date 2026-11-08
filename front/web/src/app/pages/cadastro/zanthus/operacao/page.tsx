'use client'
    const __SIS_AC_CD : number = 1290 

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";

import { moduleZanthus } from '@/api/m0085_zanthus/moduleZanthus';




let myModule: moduleZanthus;

export default function ControllerFiscalOperacao() {

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);
    const [FiltrarIntegracaoTipoCd, setFiltrarIntegracaoTipoCd] = useState<boolean>(true);
    



    useEffect(() => {
            const hoje = new Date();
            myModule = new moduleZanthus(user, __SIS_AC_CD);

    }, []);



    const AtualizarBaseZanthusFiscal = async () => {
        try {

            let parametro = { 
                integracao_tipo_cd : FiltrarIntegracaoTipoCd ? 20008590 : 0,
                ProdutosPendentesDeIntegracao: FiltrarIntegracaoTipoCd ? true : false
            }

            setActionStatus(1);
            const response = await myModule.postAtualizacaoFiscal(parametro);
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setActionStatus(0);
        }
    };

    const ExportarClientesZanthus = async () => {
        try {
            let parametro = { 
                atualizacaoGeral: 1
            }
            setActionStatus(1);
             const response = await myModule.postAtualizacaoCliente(parametro);
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao exportar clientes Zanthus:', error);
            setActionStatus(0);
        }
    };





 
    return (

        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Controller Fiscal - Operações">
                    <div className="flex space-x-2">
                     
                    </div>
                </HeaderMain>
          <div className="flex flex-col gap-4">

            <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4"> 
                        <div className="flex flex-col gap-4">
                            <h2 className="text-base font-semibold text-gray-800">
                                Atualização do Cadastro Mercadorias e Do Cadastro Fiscal na BASE ZANTHUS
                            </h2>

                            <div className="flex flex-col md:flex-row md:items-end gap-4">
                                <div className="flex flex-col min-w-[220px]">
                                    <label htmlFor="numeroDiasUltimaAlteracao" className="text-sm font-medium text-gray-700 mb-1">
                                        Pendência Zanthus Simples [20008590]
                                    </label>
                                    <input type="checkbox" className="border border-gray-300 rounded-md p-2" id="checkbox1" 
                                      checked={FiltrarIntegracaoTipoCd}
                                      onChange={(e) => setFiltrarIntegracaoTipoCd(e.target.checked)}
                                    />
                                </div>

                                <button
                                    type="button"
                                    className="flex items-center px-4 py-2 bg-green-600 hover:bg-green-700 text-white rounded shadow transition disabled:opacity-70 disabled:cursor-not-allowed"
                                    title="Exportar Clientes Zanthus"
                                    onClick={AtualizarBaseZanthusFiscal}
                                    disabled={ActionStatus === 1}
                                >
                                    {ActionStatus === 1 ? (
                                        <svg className="w-5 h-5 mr-2 animate-spin" fill="none" viewBox="0 0 24 24">
                                            <circle className="opacity-25" cx="12" cy="12" r="10" stroke="white" strokeWidth="4" />
                                            <path className="opacity-75" fill="white" d="M4 12a8 8 0 018-8v8z" />
                                        </svg>
                                    ) : (
                                        <svg className="w-5 h-5 mr-2" fill="none" stroke="currentColor" strokeWidth={2} viewBox="0 0 24 24">
                                            <path strokeLinecap="round" strokeLinejoin="round" d="M12 4v16m8-8H4" />
                                        </svg>
                                    )}
                                    Atualização de Mercadorias 
                                </button>
                            </div>

                        </div>
            </div>

            <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4"> 
                        <div className="flex flex-col gap-4">
                            <h2 className="text-base font-semibold text-gray-800">
                                Atualização Base de Cliente
                            </h2>

                            <div className="flex flex-col md:flex-row md:items-end gap-4">
                                <div className="flex flex-col min-w-[220px]">
                                    <label htmlFor="numeroDiasUltimaAlteracao" className="text-sm font-medium text-gray-700 mb-1">
                                        Atualização Geral
                                    </label>
                                    <input type="checkbox" className="border border-gray-300 rounded-md p-2" id="checkbox1" 
                                      checked={FiltrarIntegracaoTipoCd}
                                      onChange={(e) => setFiltrarIntegracaoTipoCd(e.target.checked)}
                                    />
                                </div>

                                <button
                                    type="button"
                                    className="flex items-center px-4 py-2 bg-green-600 hover:bg-green-700 text-white rounded shadow transition disabled:opacity-70 disabled:cursor-not-allowed"
                                    title="Exportar Clientes Zanthus"
                                    onClick={ExportarClientesZanthus}
                                    disabled={ActionStatus === 1}
                                >
                                    {ActionStatus === 1 ? (
                                        <svg className="w-5 h-5 mr-2 animate-spin" fill="none" viewBox="0 0 24 24">
                                            <circle className="opacity-25" cx="12" cy="12" r="10" stroke="white" strokeWidth="4" />
                                            <path className="opacity-75" fill="white" d="M4 12a8 8 0 018-8v8z" />
                                        </svg>
                                    ) : (
                                        <svg className="w-5 h-5 mr-2" fill="none" stroke="currentColor" strokeWidth={2} viewBox="0 0 24 24">
                                            <path strokeLinecap="round" strokeLinejoin="round" d="M12 4v16m8-8H4" />
                                        </svg>
                                    )}
                                    Atualização de Clientes 
                                </button>
                            </div>

                        </div>
            </div>            
          </div>
        </div>
    </div>
    );
}