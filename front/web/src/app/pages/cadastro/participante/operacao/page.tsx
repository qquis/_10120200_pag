'use client'
const __SIS_AC_CD : number = 1012

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";
import CmbParticipanteTipo from '../../_components/CmbParticipanteTipo/page';

import {moduleParticipante} from "@/api/m0011_Participante/moduleParticipante";





let myModule: moduleParticipante;

export default function ParticipanteOperacao() {

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);


    /* STATES LISTS */
    const [List, setList] = useState<any[]>([]);

    /* STATES FILTERS */
    const [nome_razaoFilter, setnome_razaoFilter] = useState('');
    const [participante_tipo_cdFilter, setParticipante_tipo_cdFilter] = useState('');
    const [numeroDiasUltimaAlteracao, setnumeroDiasUltimaAlteracao] = useState<number>(1);





    /* STATES MODAL */
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedServiceId, setSelectedServiceId] = useState<number>(0);


    useEffect(() => {
            myModule = new moduleParticipante(user, __SIS_AC_CD);

    }, []);

  
    const ParticipanteVIPImportar = async () => {
        try {
            setActionStatus(1);
            setList([]) // Limpando a lista antes de buscar novos dados
            const response = await myModule.postOperacaoVipImmport();
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setList([]);
            setActionStatus(0);
        }
    };

    const ParticipanteBluesoftApiImportar = async () => {
        try {
            setActionStatus(1);
            setList([]) // Limpando a lista antes de buscar novos dados
            const response = await myModule.postOperacaoBluesoftApiImport({numeroDiasUltimaAlteracao: numeroDiasUltimaAlteracao});
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setList([]);
            setActionStatus(0);
        }
    };

    const GrupoEconomicoBluesoftApiImportar = async () => {
        try {
            setActionStatus(1);
            setList([]) // Limpando a lista antes de buscar novos dados
            const response = await myModule.postOperacaoGrupoEconomicoImport({});
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setList([]);
            setActionStatus(0);
        }
    };    

    const ParticipanteBluesoftRedshiftImportar = async () => {
        try {
            setActionStatus(1);
            setList([]) // Limpando a lista antes de buscar novos dados
            const response = await myModule.postOperacaoBluesoftRedshiftImport({numeroDiasUltimaAlteracao: numeroDiasUltimaAlteracao});
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setList([]);
            setActionStatus(0);
        }
    };



 
    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Participante | Operações">
                    <div></div>

                </HeaderMain>

                

        <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4">
            
                <div className="flex flex-col gap-4">
                        <h2 className="text-base font-semibold text-gray-800">
                        Importar Clientes VIP
                        </h2>

                        <div className="flex flex-col md:flex-row md:items-end gap-4">
                        <p className="text-xs text-gray-500">
                            Importa os clientes do cadastro Bluesoft via API
                        </p>                    

                           
                            <ButtonPag TypeButton="_BUTTON_HEADER" label="" TypeIcon="_UPDATE" title="Importar Base NFCE" onClick={ParticipanteVIPImportar} ActionStatus={ActionStatus} />
                            
                        </div>
                    </div>        
         </div>            


        <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4">
            
                <div className="flex flex-col gap-4">
                        <h2 className="text-base font-semibold text-gray-800">
                        Grupo Econômico Bluesoft
                        </h2>

                        <div className="flex flex-col md:flex-row md:items-end gap-4">
                        <p className="text-xs text-gray-500">
                            Importar Grupos Economicos via API
                        </p>                    

                           
                            <ButtonPag TypeButton="_BUTTON_HEADER" label="" TypeIcon="_UPDATE" title="Importar Base NFCE" onClick={GrupoEconomicoBluesoftApiImportar} ActionStatus={ActionStatus} />
                            
                        </div>
                    </div>        
         </div>  

          <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4"> 
                    <div className="flex flex-col gap-4">
                        <h2 className="text-base font-semibold text-gray-800">
                            Importar Pessoas Bluesoft via API
                        </h2>

                        <div className="flex flex-col md:flex-row md:items-end gap-4">
                            <div className="flex flex-col min-w-[220px]">
                                <label htmlFor="numeroDiasUltimaAlteracao" className="text-sm font-medium text-gray-700 mb-1">
                                    Número de Dias da Última Alteração [ZERO para lista Geral]
                                </label>
                                <input
                                    id="numeroDiasUltimaAlteracao"
                                    type="text"
                                    className="px-3 py-2 border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-2 focus:ring-green-500 text-black"
                                    value={numeroDiasUltimaAlteracao}
                                    onChange={(e) => setnumeroDiasUltimaAlteracao(Number(e.target.value))}
                                />
                            </div>


                            <ButtonPag TypeButton="_BUTTON_HEADER" label="" TypeIcon="_UPDATE" title="Importar Base NFCE" onClick={ParticipanteBluesoftApiImportar} ActionStatus={ActionStatus} />       
                        </div>

                        <p className="text-xs text-gray-500">
                            Importa os clientes do cadastro Bluesoft via API
                        </p>
                    </div>
        </div>

        <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4"> 
                    <div className="flex flex-col gap-4">
                        <h2 className="text-base font-semibold text-gray-800">
                            Importar Pessoas Bluesoft Via Redshift
                        </h2>

                        <div className="flex flex-col md:flex-row md:items-end gap-4">
                            <div className="flex flex-col min-w-[220px]">
                                <label htmlFor="numeroDiasUltimaAlteracao" className="text-sm font-medium text-gray-700 mb-1">
                                    Número de Dias da Última Alteração [ZERO para lista Geral]
                                </label>
                                <input
                                    id="numeroDiasUltimaAlteracao"
                                    type="text"
                                    className="px-3 py-2 border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-2 focus:ring-green-500 text-black"
                                    value={numeroDiasUltimaAlteracao}
                                    onChange={(e) => setnumeroDiasUltimaAlteracao(Number(e.target.value))}
                                />
                            </div>
                            <ButtonPag TypeButton="_BUTTON_HEADER" label="" TypeIcon="_UPDATE" title="Importar Base NFCE" onClick={ParticipanteBluesoftRedshiftImportar} ActionStatus={ActionStatus} />       

                        </div>

                        <p className="text-xs text-gray-500">
                            O Servidor precisa estar com a VPN ativa.
                        </p>
                    </div>
        </div>

            </div>
        </div>
    );
}