'use client'
const __SIS_AC_CD : number = 1012

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";


import { moduleForcaVenda } from '@/api/m0004_forcavenda/moduleforcavenda';




let myModule: moduleForcaVenda;

export default function ForcaVendaOperacao() {

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);


    useEffect(() => {
            myModule = new moduleForcaVenda(user, __SIS_AC_CD);

    }, []);

  
    const AtualizacaoGeral = async () => {
        try {
            setActionStatus(1);

            const response = await myModule.postAtualizarBaseGeral();
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setActionStatus(0);
        }
    };



 
    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Força de Venda | Operações">
                    <div></div>

                </HeaderMain>
                <div className="flex space-x-2">
                    <button
                        type="button"
                        className="flex items-center px-4 py-2 bg-green-600 hover:bg-green-700 text-white rounded shadow transition"
                        title="Atualizar Base Geral de Preços do Força de Venda"
                        onClick={AtualizacaoGeral}
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
                        Atualizar Base Geral | Atualização Geral de Dados de Preços do Força de Venda
                    </button>
                </div>


            </div>
        </div>
    );
}