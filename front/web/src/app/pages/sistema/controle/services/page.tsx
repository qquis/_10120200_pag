'use client'

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";
import ServiceModal from './modalservice'

import {moduleSistemaBatchService} from '@/api/m9030_sistemaBatchService/moduleSistemaBatchService';

let myModuleSistemaBatchService: moduleSistemaBatchService;

export default function ServicesList() {

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);

    /* STATES FILTERS */
    const [descricaoFilter, setDescricaoFilter] = useState('');
    const [codigoFilter, setCodigoFilter] = useState('');
    const [tipoFilter, setTipoFilter] = useState('');

    /* STATES LISTS */
    const [servicesList, setServicesList] = useState<any[]>([]);

    /* STATES MODAL */
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedServiceId, setSelectedServiceId] = useState<number>(0);

    /* EFFECTS */
    useEffect(() => {
        myModuleSistemaBatchService = new moduleSistemaBatchService(user);

        const BindingData = async () => {
            await consultarServicos();
        };

        BindingData();
    }, []);

    const consultarServicos = async () => {
        try {
            setActionStatus(1);
            const response = await myModuleSistemaBatchService.getSistemaServiceList({})
            
            // Aplicar filtros se existirem
            let filteredServices = response;
            
            if (descricaoFilter) {
                filteredServices = filteredServices.filter((service: any)=>
                    service.sis_batch_service_descricao.toLowerCase().includes(descricaoFilter.toLowerCase())
                );
            }
            
            if (codigoFilter) {
                filteredServices = filteredServices.filter((service: any)=>
                    service.sis_batch_service_cd.toString().includes(codigoFilter)
                );
            }
            
            if (tipoFilter) {
                filteredServices = filteredServices.filter((service: any)=>
                    service.sis_batch_service_tipo_descricao.toLowerCase().includes(tipoFilter.toLowerCase())
                );
            }
            
            setServicesList(filteredServices);
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setServicesList([]);
            setActionStatus(0);
        }
    };

    const limparFiltros = () => {
        setDescricaoFilter('');
        setCodigoFilter('');
        setTipoFilter('');
    };

    const handleServiceClick = (serviceId: number) => {
        setSelectedServiceId(serviceId);
        setIsModalOpen(true);
    };

    const handleModalClose = () => {
        setIsModalOpen(false);
        setSelectedServiceId(0);
    };

    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Sistema - Listagem de Serviços Batch">
                    <div className="flex space-x-2">
                        <ButtonPag 
                            TypeButton="_BUTTON_HEADER" 
                            label="Pesquisar" 
                            TypeIcon="_PESQUISAR" 
                            title="Pesquisar Serviços" 
                            onClick={consultarServicos} 
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

                        {/* Filtro por Código */}
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Código</label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                                placeholder="Filtrar por código"
                                value={codigoFilter}
                                onChange={(e) => setCodigoFilter(e.target.value)}
                            />
                        </div>

                        {/* Filtro por Descrição */}
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Descrição</label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                                placeholder="Filtrar por descrição"
                                value={descricaoFilter}
                                onChange={(e) => setDescricaoFilter(e.target.value)}
                            />
                        </div>

                        {/* Filtro por Tipo */}
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Tipo de Serviço</label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                                placeholder="Filtrar por tipo"
                                value={tipoFilter}
                                onChange={(e) => setTipoFilter(e.target.value)}
                            />
                        </div>

                    </div>
                </div>

                {/* Grid de Serviços */}
                <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
                    <div className="max-h-[500px] overflow-y-auto">
                        <table className="min-w-full divide-y divide-gray-200">
                            <thead className="bg-gray-100 sticky top-0 z-10">
                                <tr>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Código</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Descrição do Serviço</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Tipo Descrição</th>
                                </tr>
                            </thead>
                            <tbody className="bg-white divide-y divide-gray-200">
                                {servicesList.length > 0 ? (
                                    servicesList.map((service) => (
                                        <tr key={service.sis_batch_service_cd} className="hover:bg-gray-50">
                                            <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-700 font-medium text-right">
                                                <button
                                                    onClick={() => handleServiceClick(service.sis_batch_service_cd)}
                                                    className="text-blue-600 hover:text-blue-800 hover:underline transition-colors duration-200 cursor-pointer"
                                                    title="Clique para ver detalhes do serviço"
                                                >
                                                    {service.sis_batch_service_cd}
                                                </button>
                                            </td>
                                            <td className="px-6 py-4 text-sm text-gray-700">
                                                {service.sis_batch_service_descricao}
                                            </td>
                                            <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-700">
                                                <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-blue-100 text-blue-800">
                                                    {service.sis_batch_service_tipo_descricao}
                                                </span>
                                            </td>

                                        </tr>
                                    ))
                                ) : (
                                    <tr>
                                        <td colSpan={3} className="px-6 py-4 text-center text-sm text-gray-500">
                                            Nenhum serviço encontrado com os filtros aplicados.
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
                        <h3 className="text-mg font-medium text-gray-500">Total de Registros</h3>
                        <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
                            {servicesList.length} serviço{servicesList.length !== 1 ? 's' : ''}
                        </span>
                    </div>
                </div>

                {/* Modal de Detalhes do Serviço */}
                <ServiceModal
                    isOpen={isModalOpen}
                    onClose={handleModalClose}
                    serviceId={selectedServiceId}
                />
            </div>
        </div>
    );
}