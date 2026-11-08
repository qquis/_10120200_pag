'use client'

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";

import { moduleForcaVenda } from "@/api/m0004_forcavenda/moduleforcavenda";

export default function TabelaPrecoList() {

    const __SIS_AC_CD : number = 3216

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);

    /* FILTER*/
    const [fv_tabelapreco_descricaoFilter, setfv_tabelapreco_descricaoFilter] = useState<string>('')

    /* SELECTED TABLE */
    const [selectedTable, setSelectedTable] = useState<any>(null);

    /* FILTERS VERSAO */
    const [vigenciaInicialFilter, setVigenciaInicialFilter] = useState<string>(new Date().toISOString().split('T')[0]);

    /* STATES LISTS */
    const [List, setList] = useState<any[]>([]);
    const [ListVersao, setListVersao] = useState<any[]>([]);

    const ConsultarList = async () => {
        try {
            setList([]) // Limpando a lista antes de buscar novos dados
            setListVersao([]) // Limpando a lista de versões antes de buscar novos dados
            setSelectedTable(null); // Limpando a seleção
            setActionStatus(1);

            const myMODULE : moduleForcaVenda = new moduleForcaVenda(user, __SIS_AC_CD);            

           let filter = { 
                fv_tabelapreco_descricao: fv_tabelapreco_descricaoFilter
            }

            const response = await myMODULE.getTabela(filter);

            setList(response || []);
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar tabelas de preço:', error);
            setList([]);
            setActionStatus(0);
        }
    };

    // Carregar dados automaticamente ao montar o componente
    useEffect(() => {
        if (user) {
            ConsultarList();
        }
    }, [user]);

    const ConsultarListVersao = async (tabelaSelected?: any) => {
        try {
            setListVersao([]) // Limpando a lista de versões antes de buscar novos dados
            setActionStatus(1);

            const myMODULE : moduleForcaVenda = new moduleForcaVenda(user, __SIS_AC_CD);            

            let filter = { 
                fv_tabelapreco_cd: tabelaSelected ? tabelaSelected.fv_tabelapreco_cd : selectedTable?.fv_tabelapreco_cd,
                vigencia_inicial: vigenciaInicialFilter
            }

            const response = await myMODULE.getTabelaVersao(filter);

            setListVersao(response || []);
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar versões das tabelas de preço:', error);
            setListVersao([]);
            setActionStatus(0);
        }
    };

    const handleSelectTable = (table: any) => {
        setSelectedTable(table);
        ConsultarListVersao(table);
    };

    const isInactive = (description: string) => {
        return description.toLowerCase().includes('(inativo)');
    };

    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Força de Vendas | Tabelas de Preço">
                    <div className="flex space-x-2">
                        <ButtonPag 
                            TypeButton="_BUTTON_HEADER" 
                            label="Atualizar Base de Preços" 
                            TypeIcon="_PESQUISAR" 
                            title="Atualizar Base de Preços" 
                            onClick={ConsultarList} 
                        />
                    </div>
                    <div className="flex space-x-2">
                        <ButtonPag 
                            TypeButton="_BUTTON_HEADER" 
                            label="Pesquisar" 
                            TypeIcon="_PESQUISAR" 
                            title="Pesquisar" 
                            onClick={ConsultarList} 
                        />
                    </div>                    
                </HeaderMain>

                {/* Área de Filtros */}
                <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
                    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Descrição da Tabela de Preço</label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                                placeholder="Filtrar por descrição"
                                value={fv_tabelapreco_descricaoFilter}
                                onChange={(e) => setfv_tabelapreco_descricaoFilter(e.target.value)}
                            />
                        </div>  
                    </div>
                </div>

                {/* Grid de Tabelas de Preço */}
                <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100 mb-6">
                    <div className="max-h-[400px] overflow-y-auto">
                        <table className="min-w-full divide-y divide-gray-200">
                            <thead className="bg-gray-100 sticky top-0 z-10">
                                <tr>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Código</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Descrição</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">% Comissão</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Qtd. Versões</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Versão Atual</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vigência Inicial</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vigência Fim</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Status</th>
                                </tr>
                            </thead>
                            <tbody className="bg-white divide-y divide-gray-200">
                                {List.length > 0 ? (
                                    List.map((itemList, index) => (
                                        <tr 
                                            key={itemList.fv_tabelapreco_cd || index} 
                                            className={`cursor-pointer transition-colors ${
                                                selectedTable?.fv_tabelapreco_cd === itemList.fv_tabelapreco_cd
                                                    ? 'bg-purple-100 border-l-4 border-purple-500'
                                                    : isInactive(itemList.fv_tabelapreco_descricao) 
                                                        ? 'bg-red-50 hover:bg-red-100' 
                                                        : 'hover:bg-gray-50'
                                            }`}
                                            onClick={() => handleSelectTable(itemList)}
                                        >
                                            <td className="px-4 py-2 text-sm text-gray-700 font-medium">
                                                {itemList.fv_tabelapreco_cd}
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700 max-w-xs">
                                                <div className="truncate" title={itemList.fv_tabelapreco_descricao}>
                                                    {itemList.fv_tabelapreco_descricao}
                                                </div>
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700 text-right">
                                                {user.formatNumber(itemList.percentual_comissao,2)}
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700 text-center">
                                                <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${
                                                    parseInt(itemList.qtde_versao) > 0 ? 'bg-blue-100 text-blue-800' : 'bg-gray-100 text-gray-800'
                                                }`}>
                                                    {itemList.qtde_versao}
                                                </span>
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700 text-center">
                                                <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${
                                                    Number(itemList.versao_atual) > 0 ? 'bg-green-100 text-green-800' : 'bg-gray-100 text-gray-800'
                                                }`}>
                                                    {user.formatNumber(itemList.versao_atual,0)}
                                                </span>
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700 text-center">
                                                {user.formatDateDDMMYYYY(itemList.vigencia_inicial_atual)}
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700 text-center">
                                                {user.formatDateDDMMYYYY(itemList.vigencia_fim_atual)}
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700">
                                                <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${
                                                    isInactive(itemList.fv_tabelapreco_descricao) ? 'bg-red-100 text-red-800' : 'bg-green-100 text-green-800'
                                                }`}>
                                                    <span className={`inline-block w-2 h-2 rounded-full mr-1 ${
                                                        isInactive(itemList.fv_tabelapreco_descricao) ? 'bg-red-500' : 'bg-green-500'
                                                    }`}></span>
                                                    {isInactive(itemList.fv_tabelapreco_descricao) ? 'Inativo' : 'Ativo'}
                                                </span>
                                            </td>
                                        </tr>
                                    ))
                                ) : (
                                    <tr>
                                        <td colSpan={8} className="px-6 py-4 text-center text-sm text-gray-500">
                                            {ActionStatus === 1 ? 'Carregando...' : 'Nenhum Registro Encontrado'}
                                        </td>
                                    </tr>
                                )}
                            </tbody>
                        </table>
                    </div>
                </div>

                {/* Rodapé com total de registros das tabelas */}
                <div className="px-6 py-4 bg-gray-50 border-b border-gray-200 mb-6">
                    <div className="flex justify-between items-center">
                        <div className="flex space-x-4">
                            <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
                                Total de Registros: {List.length} 
                            </span>
                            <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-green-100 text-green-800">
                                Ativas: {List.filter(item => !isInactive(item.fv_tabelapreco_descricao)).length}
                            </span>
                            <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-red-100 text-red-800">
                                Inativas: {List.filter(item => isInactive(item.fv_tabelapreco_descricao)).length}
                            </span>
                        </div>
                        <div className="text-xs text-gray-500">
                            {selectedTable && (
                                <span className="mr-4 text-purple-600 font-medium">
                                    Tabela Selecionada: {selectedTable.fv_tabelapreco_cd} - {selectedTable.fv_tabelapreco_descricao}
                                </span>
                            )}
                            Última atualização: {new Date().toLocaleString('pt-BR')}
                        </div>
                    </div>
                </div>

                {/* Filtros para Versões */}
                {selectedTable && (
                    <>
                        <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-orange-100">
                            <h3 className="text-lg font-medium text-gray-900 mb-4">Filtros para Versões</h3>
                            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                                <div>
                                    <label className="block text-sm font-medium text-gray-700 mb-1">Vigência Inicial</label>
                                    <input
                                        type="date"
                                        className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-orange-500 focus:border-transparent text-black"
                                        value={vigenciaInicialFilter}
                                        onChange={(e) => setVigenciaInicialFilter(e.target.value)}
                                    />
                                </div>
                                <div className="flex items-end">
                                    <ButtonPag 
                                        TypeButton="_BUTTON_HEADER" 
                                        label="Filtrar Versões" 
                                        TypeIcon="_PESQUISAR" 
                                        title="Filtrar Versões" 
                                        onClick={() => ConsultarListVersao()} 
                                    />
                                </div>
                            </div>
                        </div>

                        {/* Grid de Versões */}
                        <div className="bg-white rounded-lg shadow-md overflow-hidden border border-gray-200">
                            <div className="bg-gray-50 px-6 py-3 border-b border-gray-200">
                                <h3 className="text-lg font-medium text-gray-900 m">
                                    Versões da Tabela: {selectedTable.fv_tabelapreco_descricao}
                                </h3>
                            </div>
                            <div className="max-h-[400px] overflow-y-auto">
                                <table className="min-w-full divide-y divide-gray-200">
                                    <thead className="bg-gray-100 sticky top-0 z-10">
                                        <tr>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Código</th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Versão</th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Desconto Máximo</th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Desconto Padrão</th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Acréscimo Máximo</th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vigência Inicial</th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vigência Fim</th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Status</th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Referência</th>
                                        </tr>
                                    </thead>
                                    <tbody className="bg-white divide-y divide-gray-200">
                                        {ListVersao.length > 0 ? (
                                            ListVersao.map((versao, index) => (
                                                <tr key={`${versao.fv_tabelapreco_cd}_${versao.versao}` || index} className="hover:bg-orange-50">
                                                    <td className="px-4 py-2 text-sm text-gray-700 font-medium">
                                                        {versao.fv_tabelapreco_cd}
                                                    </td>
                                                    <td className="px-4 py-2 text-sm text-gray-700 text-center">
                                                        <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-orange-100 text-orange-800">
                                                            {versao.versao}
                                                        </span> 
                                                    </td>
                                                    <td className="px-4 py-2 text-sm text-gray-700 text-right">
                                                        {user.formatNumber(versao.descontomaximo, 2)}%
                                                    </td>
                                                    <td className="px-4 py-2 text-sm text-gray-700 text-right">
                                                        {user.formatNumber(versao.descontopadrao, 2)}%
                                                    </td>
                                                    <td className="px-4 py-2 text-sm text-gray-700 text-right">
                                                        {user.formatNumber(versao.acrescimomaximo, 2)}%
                                                    </td>
                                                    <td className="px-4 py-2 text-sm text-gray-700 text-center">
                                                        {user.formatDateDDMMYYYY(versao.datainiciovigencia)}
                                                    </td>
                                                    <td className="px-4 py-2 text-sm text-gray-700 text-center">
                                                        {user.formatDateDDMMYYYY(versao.datafimvigencia)}
                                                    </td>
                                                    <td className="px-4 py-2 text-sm text-gray-700">
                                                        <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${
                                                            versao.ativo === 1 ? 'bg-green-100 text-green-800' : 'bg-red-100 text-red-800'
                                                        }`}>
                                                            <span className={`inline-block w-2 h-2 rounded-full mr-1 ${
                                                                versao.ativo === 1 ? 'bg-green-500' : 'bg-red-500'
                                                            }`}></span>
                                                            {versao.ativo === 1 ? 'Ativo' : 'Inativo'}
                                                        </span>
                                                    </td>
                                                    <td className="px-4 py-2 text-sm text-gray-700 text-center">
                                                        <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${
                                                            versao.tabelareferencia === 1 ? 'bg-blue-100 text-blue-800' : 'bg-gray-100 text-gray-800'
                                                        }`}>
                                                            {versao.tabelareferencia === 1 ? 'Sim' : 'Não'}
                                                        </span>
                                                    </td>
                                                </tr>
                                            ))
                                        ) : (
                                            <tr>
                                                <td colSpan={9} className="px-6 py-4 text-center text-sm text-gray-500">
                                                    {ActionStatus === 1 ? 'Carregando versões...' : 'Nenhuma Versão Encontrada'}
                                                </td>
                                            </tr>
                                        )}
                                    </tbody>
                                </table>
                            </div>

                            {/* Rodapé com total de versões */}
                            <div className="px-6 py-4 bg-gray-50 border-t border-gray-200">
                                <div className="flex justify-between items-center">
                                    <div className="flex space-x-4">
                                        <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-gray-100 text-gray-800">
                                            Total de Versões: {ListVersao.length} 
                                        </span>
                                        <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-green-100 text-green-800">
                                            Ativas: {ListVersao.filter(versao => versao.ativo === 1).length}
                                        </span>
                                        <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-blue-100 text-blue-800">
                                            Referência: {ListVersao.filter(versao => versao.tabelareferencia === 1).length}
                                        </span>
                                    </div>
                                    <div className="text-xs text-gray-500">
                                        Última consulta: {new Date().toLocaleString('pt-BR')}
                                    </div>
                                </div>
                            </div>
                        </div>
                    </>
                )}
            </div>
        </div>
    );
}