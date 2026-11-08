'use client'

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";


import {moduleSistema} from '@/api/m0001_sistema/moduleSistema';

let myModuleSistema: moduleSistema;

export default function SistemaTarefaList() {

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);

    /* STATES FILTERS */
    const [descricaoFilter, setDescricaoFilter] = useState('');
    const [codigoFilter, setCodigoFilter] = useState('');
    const [tipoFilter, setTipoFilter] = useState('');

    /* STATES LISTS */
    const [tarefaList, setTarefaList] = useState<any[]>([]);

    /* STATES MODAL */
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedServiceId, setSelectedServiceId] = useState<number>(0);

    /* EFFECTS */
    useEffect(() => {
        myModuleSistema = new moduleSistema(user);

        const BindingData = async () => {
            await ConsultarListaDeTarefas();
        };

        BindingData();
    }, []);

    const ConsultarListaDeTarefas = async () => {
        try {
            setActionStatus(1);

            let parametro : any = {
                sis_ta_descricao: descricaoFilter,
                sis_ta_cd: codigoFilter,
                sis_ta_tipo_descricao: tipoFilter
            }


            const response = await myModuleSistema.getSistemaTarafaListGet(parametro)
            setTarefaList(response);
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setTarefaList([]);
            setActionStatus(0);
        }
    };

    const limparFiltros = () => {
        setDescricaoFilter('');
        setCodigoFilter('');
        setTipoFilter('');
    };

 
    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Sistema - Listagem de tarefasa">
                    <div className="flex space-x-2">
                        <ButtonPag 
                            TypeButton="_BUTTON_HEADER" 
                            label="Pesquisar" 
                            TypeIcon="_PESQUISAR" 
                            title="Pesquisar Serviços" 
                            onClick={ConsultarListaDeTarefas} 
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
                            <label className="block text-sm font-medium text-gray-700 mb-1">Tipo de Tarefa</label>
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
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">N. Sistemas</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">N. funções</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">N. Acessos</th>
                                </tr>
                            </thead>
                            <tbody className="bg-white divide-y divide-gray-200">
                                {tarefaList.length > 0 ? (
                                    tarefaList.map((tarefa) => (
                                        <tr key={tarefa.sis_ta_cd} className="hover:bg-gray-50">
                                            <td className="px-6 py-4 text-sm text-gray-700">
                                                {tarefa.sis_ta_cd}
                                            </td>
                                            <td className="px-6 py-4 text-sm text-gray-700">
                                                {tarefa.sis_ta_descricao}
                                            </td>
                                            <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-700">
                                                <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-blue-100 text-blue-800">
                                                    {tarefa.sis_ta_tipo_descricao}
                                                </span>
                                            </td>
                                            <td className="px-6 py-4 text-sm text-gray-700">
                                                {tarefa.sistemas}
                                            </td>
                                            <td className="px-6 py-4 text-sm text-gray-700">
                                                {tarefa.funcoes}
                                            </td>
                                            <td className="px-6 py-4 text-sm text-gray-700">
                                                {tarefa.acessos}
                                            </td>
                                        </tr>
                                    ))
                                ) : (
                                    <tr>
                                        <td colSpan={3} className="px-6 py-4 text-center text-sm text-gray-500">
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
                        <h3 className="text-mg font-medium text-gray-500">Total de Registros</h3>
                        <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
                            {tarefaList.length} Tarefas{tarefaList.length !== 1 ? 's' : ''}
                        </span>
                    </div>
                </div>


            </div>
        </div>
    );
}