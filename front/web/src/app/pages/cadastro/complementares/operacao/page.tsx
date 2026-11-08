'use client'
const __SIS_AC_CD : number = 1012

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";
import CmbParticipanteTipo from '../../_components/CmbParticipanteTipo/page';


import {moduleFinanceiro} from "@/api/m0080_financeiro/modulefinanceiro";



let myModuleFananceiro: moduleFinanceiro;

export default function ParticipanteOperacao() {

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);








    useEffect(() => {
            myModuleFananceiro = new moduleFinanceiro(user);

    }, []);

  
    const CadastroFinanceiroFormaPgtoAtualizar = async () => {
        try {
            setActionStatus(1);

            const response = await myModuleFananceiro.moduleBluesoft.CadastroFormaPgtoAtualizar({} );
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setActionStatus(0);
        }
    };

    


 
    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Atualizações de Cadastros Complementares">
                    <div></div>

                </HeaderMain>

        <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4">
            
                <div className="flex flex-col gap-4">
                        <h2 className="text-base font-semibold text-gray-800">
                        Cadastro Complementar | Financeiro - FORMA DE PGTO
                        </h2>

                        <div className="flex flex-col md:flex-row md:items-end gap-4">
                        <p className="text-xs text-gray-500">
                            Importa as formas de pagamento via API Bluesoft
                        </p>                    
        
                           
                            <ButtonPag TypeButton="_BUTTON_HEADER" label="" TypeIcon="_UPDATE" title="Importar Base NFCE" onClick={CadastroFinanceiroFormaPgtoAtualizar} ActionStatus={ActionStatus} />
                            
                        </div>
                    </div>        
         </div>            


            </div>
        </div>
    );
}