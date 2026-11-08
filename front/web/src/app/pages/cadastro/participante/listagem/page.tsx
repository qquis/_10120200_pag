'use client'

import { useEffect, useState, useRef } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";
import CmbParticipanteTipo from '../../_components/CmbParticipanteTipo/page';
import ParticipanteModal from './modalParticipante';

import {moduleParticipante} from "@/api/m0011_Participante/moduleParticipante";







export default function ParticipanteList() {

    const __SIS_AC_CD : number = 1011

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);


    /* STATES LISTS */
    const [List, setList] = useState<any[]>([]);

    /* STATES FILTERS */
    const [nome_razaoFilter, setnome_razaoFilter] = useState('');
    const [participante_tipo_cdFilter, setParticipante_tipo_cdFilter] = useState('');

    
    /* STATES MODAL */
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedParticipanteId, setSelectedParticipanteId] = useState<number | null>(null);

    




    const ConsultarList = async () => {
        try {
            setList([]) // Limpando a lista antes de buscar novos dados
            setActionStatus(1);

            const myMODULE : moduleParticipante = new moduleParticipante(user, __SIS_AC_CD);            

            let parametro : any = {
                nome_razao: nome_razaoFilter,
                participante_tipo_cd: participante_tipo_cdFilter
            }
            
            const response = await myMODULE.getParticipanteList(parametro);

            setList(response || []);
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setList([]);
            setActionStatus(0);
        }
    };

    const limparFiltros = () => {
        setnome_razaoFilter('');
        setParticipante_tipo_cdFilter('');

    };

 
    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Participante | Listagem">
                    <div className="flex space-x-2">
                        <ButtonPag 
                            TypeButton="_BUTTON_HEADER" 
                            label="Pesquisar" 
                            TypeIcon="_PESQUISAR" 
                            title="Pesquisar Serviços" 
                            onClick={ConsultarList} 
                        />
                        <ButtonPag 
                            TypeButton="_BUTTON_HEADER" 
                            label="Limpar" 
                            TypeIcon="_PESQUISAR" 
                            title="Limpar Filtros" 
                            onClick={limparFiltros} 
                        />
                    </div>
                </HeaderMain>

                {/* Área de Filtros */}
                <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
                    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                        {/* Filtro por Descrição */}
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
                            <label className="block text-sm font-medium text-gray-700 mb-1">Tipo de Participante</label>
                            <CmbParticipanteTipo user={user} onChange={(value) => setParticipante_tipo_cdFilter(value)} value={participante_tipo_cdFilter} />
                        </div>
                    </div>
                </div>

                {/* Grid de Serviços */}
                <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
                    <div className="max-h-[500px] overflow-y-auto">
                        <table className="min-w-full divide-y divide-gray-200">
                            <thead className="bg-gray-100 sticky top-0 z-10">
                                <tr>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Part.</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Blue Cd</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">RH Cd</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">CPF/CNPJ</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Nome/Razão</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Ativo</th>                                    

                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Cl</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Ve</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Fo</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Fa</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Pessoa Status</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Cliente Status</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">E-mail</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Celular DDD</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Celular Número</th>                                    

                                </tr>
                            </thead>
                            <tbody className="bg-white divide-y divide-gray-200">
                                {List.length > 0 ? (
                                    List.map((itemList) => (
                                        <tr key={itemList.cdparticipante} className="hover:bg-gray-50">
                                            <td className="px-4 py-2 text-xs text-blue-700 underline cursor-pointer"
                                                onClick={() => {
                                                    setSelectedParticipanteId(itemList.cdparticipante);
                                                    setIsModalOpen(true);
                                                }}
                                            >
                                                {itemList.cdparticipante}
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700">{itemList.cdpessoabluesoft}</td>
                                            <td className="px-4 py-2 text-sm text-gray-700">{itemList.funcionario_cd}</td>
                                            <td className="px-4 py-2 text-sm text-gray-700">{itemList.cpf_cnpj}</td>
                                            <td className="px-4 py-2 text-sm text-gray-700 whitespace-nowrap">{itemList.nome_razao}</td>
                                            <td className="px-4 py-2 text-sm text-gray-700">
                                                <span className={`inline-block w-3 h-3 rounded-full ${itemList.participante_status === 1 ? 'bg-green-500' : 'bg-red-500'}`}></span>
                                            </td>

                                            <td className="px-4 py-2 text-sm text-gray-700">
                                                <span className={`inline-block w-3 h-3 rounded-full ${itemList.bluesoftcliente === 1 ? 'bg-green-500' : 'bg-red-500'}`}></span>
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700">
                                                <span className={`inline-block w-3 h-3 rounded-full ${itemList.bluesoftvendedor === 1 ? 'bg-green-500' : 'bg-red-500'}`}></span>
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700">
                                                <span className={`inline-block w-3 h-3 rounded-full ${itemList.bluesoftfornecedor === 1 ? 'bg-green-500' : 'bg-red-500'}`}></span>
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700">
                                                <span className={`inline-block w-3 h-3 rounded-full ${itemList.bluesoftfabricante === 1 ? 'bg-green-500' : 'bg-red-500'}`}></span>
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700">
                                                <span className={`inline-block w-3 h-3 rounded-full ${itemList.bluesoft_pessoa_status === 1 ? 'bg-green-500' : 'bg-red-500'}`}></span>
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700">
                                                <span className={`inline-block w-3 h-3 rounded-full ${itemList.bluesoftclientestatus === 1 ? 'bg-green-500' : 'bg-red-500'}`}></span>
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700">{itemList.email_main}</td>
                                            <td className="px-4 py-2 text-sm text-gray-700">{itemList.celular_dd}</td>
                                            <td className="px-4 py-2 text-sm text-gray-700">{itemList.celular_numero}</td>

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

                {/* Rodapé com total de registros */}
                <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
                    <div className="flex justify-between items-center">
                        <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
                            Total de Registros {List.length} 
                        </span>
                    </div>
                </div>


                {/* Modal Participante */}
                {isModalOpen && (
                <ParticipanteModal
                    isOpen={isModalOpen}
                    onClose={() => setIsModalOpen(false)}
                    participanteId={selectedParticipanteId}
                />
                )}
            </div>
        </div>
    );
}