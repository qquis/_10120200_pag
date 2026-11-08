'use client'

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";


import {moduleSistema} from '@/api/m0001_sistema/moduleSistema';

import CmbSistema from '../../_components/CmbSistema/page';
import CmbSistemaFuncao from '../../_components/cmbSistemFuncao/page';
import CmbSistemaAcesso from '../../_components/cmbSistemAcesso/page';



let myModuleSistema: moduleSistema;

export default function SistemaPermissaoList() {

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);

    /* STATES FILTERS */
    const [descricaoFilter, setDescricaoFilter] = useState('');
    const [filterSis_Cd, setFilterSis_Cd] = useState('');
    const [filterSis_Fc_Cd, setFilterSis_Fc_Cd] = useState('');
    const [filterSis_Ac_Cd, setFilterSis_Ac_Cd] = useState('');
    const [tipoFilter, setTipoFilter] = useState('');

    /* STATES LISTS */
    const [List, setList] = useState<any[]>([]);


    /* STATES MODAL */
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedServiceId, setSelectedServiceId] = useState<number>(0);

    /* EFFECTS */
    useEffect(() => {
        myModuleSistema = new moduleSistema(user);

        const BindingData = async () => {
            await ConsultarListaDePermissoes();
        };

        BindingData();
    }, []);

    const ConsultarListaDePermissoes = async () => {
        try {
            setActionStatus(1);

            let parametro : any = {
                sis_cd: filterSis_Cd,
                sis_fc_cd: filterSis_Fc_Cd,
            }

            setList([]) // Limpando a lista antes de buscar novos dados
            const response = await myModuleSistema.getSistemaPermissaoListGet(parametro)
            setList(response);
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setList([]);
            setActionStatus(0);
        }
    };

    const limparFiltros = () => {
        setDescricaoFilter('');
        setFilterSis_Cd('');
        setTipoFilter('');
    };

 
    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Sistema - Listagem de Permissões">
                    <div className="flex space-x-2">
                        <ButtonPag 
                            TypeButton="_BUTTON_HEADER" 
                            label="Pesquisar" 
                            TypeIcon="_PESQUISAR" 
                            title="Pesquisar Serviços" 
                            onClick={ConsultarListaDePermissoes} 
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

                        {/* Filtro por Sistema */}
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Sistema</label>
                            <CmbSistema
                                user={user}
                                value={filterSis_Cd}
                                onChange={(value) => setFilterSis_Cd(value)}
                            />
                        </div>

                        {/* Filtro por Função */}
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Função</label>
                            <CmbSistemaFuncao
                                user={user}
                                value={filterSis_Fc_Cd}
                                onChange={(value) => setFilterSis_Fc_Cd(value)}
                            />
                        </div>   

                        {/* Filtro por Acesso */}
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Acesso</label>
                            <CmbSistemaAcesso
                                user={user}
                                value={filterSis_Ac_Cd}
                                onChange={(value) => setFilterSis_Ac_Cd(value)}
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
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Sis Cd</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Sistema</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">F Cd</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Função</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Acesso</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Descrição</th>                                    
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Tarefa</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Descrição</th>
                                </tr>
                            </thead>
                            <tbody className="bg-white divide-y divide-gray-200">
                                {List.length > 0 ? (
                                    List.map((itemList) => (
                                        <tr key={`${itemList.sis_cd}-${itemList.sis_fc_cd}-${itemList.sis_ac_cd}-${itemList.sis_ta_cd}`} className="hover:bg-gray-50">
                                    <td className="px-4 py-2 text-xs text-gray-700">{itemList.sis_cd}</td>
                                            <td className="px-4 py-2 text-sm text-gray-700">{itemList.sis_descricao}</td>
                                            <td className="px-4 py-2 text-sm text-gray-700">{itemList.sis_fc_cd}</td>
                                            <td className="px-4 py-2 text-sm text-gray-700">{itemList.sis_fc_descricao}</td>
                                            <td className="px-4 py-2 text-sm text-gray-700">{itemList.sis_ac_cd}</td>
                                            <td className="px-4 py-2 text-sm text-gray-700">{itemList.sis_ac_descricao}</td>
                                            <td className="px-4 py-2 text-sm text-gray-700">{itemList.sis_ta_cd}</td>
                                            <td className="px-4 py-2 text-sm text-gray-700">{itemList.sis_ta_descricao}</td>
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
                        <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
                            Total de Registros {List.length} 
                        </span>
                    </div>
                </div>


            </div>
        </div>
    );
}