'use client'
const __SIS_AC_CD : number = 1012

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";


import { moduleFaturamento } from '@/api/m0070_faturamento/moduleFaturamento';




let myModule: moduleFaturamento;

export default function FaturamentoExportacao() {

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);
    const [dataFaturamento_ini, setdataFaturamento_ini] = useState<string>('');
    const [dataFaturamento_fim, setdataFaturamento_fim] = useState<string>('');


    useEffect(() => {
            const hoje = new Date();
            myModule = new moduleFaturamento(user, __SIS_AC_CD);

            

            setdataFaturamento_ini(user.formatDateToStringYYYMMDD(hoje));
            setdataFaturamento_fim(user.formatDateToStringYYYMMDD(hoje));
    }, []);



    const ExportarBaseAnaliseDistribuicao = async () => {
        try {
            setActionStatus(1);
        const dataInicial = new Date(`${dataFaturamento_ini}T00:00:00`);
        const dataFinal = new Date(`${dataFaturamento_fim}T00:00:00`);
            // 1. Buscar dados da API
            const response = await myModule.getExport(
                    { 
                        dataFaturamento_ini: dataFaturamento_ini,
                        dataFaturamento_fim: dataFaturamento_fim  
                    }

            );
        
        const diferencaEmDias =
            (dataFinal.getTime() - dataInicial.getTime()) /
            (1000 * 60 * 60 * 24);

        if (diferencaEmDias < 0) {
            alert('A data final não pode ser anterior à data inicial.');
            return;
        }

        if (diferencaEmDias > 31) {
            alert('O período não pode ser maior que 31 dias.');
            return;
        }
            await myModule.tools.ExportFaturamentoTxtAnaliseBI(response, dataFaturamento_ini);
            
        
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setActionStatus(0);
        }
    };



 
    return (
        <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4">
            <div className="flex flex-col gap-4">
                
                <div className="flex justify-start">
                    <h2 className="text-base font-semibold text-gray-800">
                        Exportar dados para Anális de Venda Distribuição
                    </h2>
                </div>

                <div className="flex flex-col md:flex-row md:items-end gap-4">
                    <div className="flex flex-col min-w-[180px] ">
                        <label htmlFor="dataInicial" className="text-sm font-medium text-gray-700 mb-1">
                            Data Inicial
                        </label>
                        <input
                            id="dataInicial"
                            name="dataInicial"
                            type="date"
                            value={dataFaturamento_ini}
                            onChange={(e) => { 
                                setdataFaturamento_ini(e.target.value)
                            }}
                            className="px-3 py-2 border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-2  text-gray-800 focus:ring-green-500"
                        />
                    </div>
                    <div className="flex flex-col min-w-[180px]">
                        <label htmlFor="dataInicial" className="text-sm font-medium text-gray-700 mb-1">
                            Data Final
                        </label>
                        <input
                            id="dataFinal"
                            name="dataFinal"
                            type="date"
                            value={dataFaturamento_fim}
                            onChange={(e) => { 
                                setdataFaturamento_fim(e.target.value)
                            }}
                            className="px-3 py-2 border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-2  text-gray-800 selection:focus:ring-green-500"
                        />
                    </div>


                   <button
                        type="button"
                        className="inline-flex items-center justify-center gap-1 h-8 px-2.5 text-xs font-medium bg-green-600 hover:bg-green-700 text-white rounded-md shadow-sm transition disabled:opacity-70 disabled:cursor-not-allowed"
                        title="Atualizar Base Geral de Preços do Força de Venda"
                        onClick={ExportarBaseAnaliseDistribuicao}
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
                        Exportar dados para Anális de Venda Distribuição
                    </button>

                </div>
            </div>
        </div>
    );
}