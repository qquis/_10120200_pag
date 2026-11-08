

'use client'

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";

import { moduleForcaVenda } from "@/api/m0004_forcavenda/moduleforcavenda";

export default function TabelaProdutoList() {

    const __SIS_AC_CD : number = 3218

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);

    /* FILTERS */
    const [tabelaPrecoFilter, setTabelaPrecoFilter] = useState<number | string>('');
    const [vigenciaInicialFilter, setVigenciaInicialFilter] = useState<string>(new Date().toISOString().split('T')[0]);
    const [prb_descricaoFilter, setPrb_descricaoFilter] = useState<string>('');
    const [prb_cdprodutoBluesoftFilter, setPrb_cdprodutoBluesoftFilter] = useState<string>('');
    const [cdpessoabluesoftfabricanteFilter, setCdpessoabluesoftfabricanteFilter] = useState<number | string>('');
    

    /* STATES LISTS */
    const [ListTabelas, setListTabelas] = useState<any[]>([]);
    const [ListProdutos, setListProdutos] = useState<any[]>([]);
    const [ListFabricanteFv, setListFabricanteFv] = useState<any[]>([]);

    const ConsultaFabricanteFv = async () => {
        try {
            const myMODULE : moduleForcaVenda = new moduleForcaVenda(user, __SIS_AC_CD);            
            const response = await myMODULE.getFabricanteFv({fv_fabricante_status: 1});

            setListFabricanteFv(response || []);
        } catch (error) {
            console.error('Erro ao consultar fabricantes FV:', error);
            setListFabricanteFv([]);
        }
    };    
    const ConsultarListTabelas = async () => {
        try {
            setActionStatus(1);

            const myMODULE : moduleForcaVenda = new moduleForcaVenda(user, __SIS_AC_CD);            
            const response = await myMODULE.getTabela({});

            setListTabelas(response || []);
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar tabelas de preço:', error);
            setListTabelas([]);
            setActionStatus(0);
        }
    };

    const ConsultarListProdutos = async () => {
        try {
            setListProdutos([]) // Limpando a lista antes de buscar novos dados
            setActionStatus(1);

            if (tabelaPrecoFilter == '' && prb_descricaoFilter.trim() === '') { 
                window.alert('Por favor! Selecione uma Tabela de Preço ou Produto');
                setActionStatus(0);
                return;
            } 

            const myMODULE : moduleForcaVenda = new moduleForcaVenda(user, __SIS_AC_CD);            

            let filter = { 
                fv_tabelapreco_cd: tabelaPrecoFilter,
                vigencia_inicial: vigenciaInicialFilter,
                prb_descricao: prb_descricaoFilter,
                prb_cdprodutoBluesoftFilter: prb_cdprodutoBluesoftFilter,
                prb_cdpessoabluesoft_fabricante: cdpessoabluesoftfabricanteFilter
            }

            const response = await myMODULE.getTabelaProduto(filter);
            

            setListProdutos(response || []);
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar produtos da tabela:', error);
            setListProdutos([]);
            setActionStatus(0);
        }
    };

    // Carregar tabelas automaticamente ao montar o componente
    useEffect(() => {
        const fetchData = async () => {
            if (user) {
                await ConsultarListTabelas();
                await ConsultaFabricanteFv();
            }
        };
        fetchData();
    }, [user]);



    const getSelectedTabelaDescricao = () => {
        if (!tabelaPrecoFilter) return '';
        const tabela = ListTabelas.find(t => t.fv_tabelapreco_cd == tabelaPrecoFilter);
        return tabela ? tabela.fv_tabelapreco_descricao : '';
    };

    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Força de Vendas | Produtos da Tabela">
                    <div className="flex space-x-2">
                        <ButtonPag 
                            TypeButton="_BUTTON_HEADER" 
                            label="Pesquisar" 
                            TypeIcon="_PESQUISAR" 
                            title="Pesquisar Produtos" 
                            onClick={ConsultarListProdutos} 
                        />
                    </div>
                </HeaderMain>

                {/* Área de Filtros */}
                <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-blue-100">
                    <h3 className="text-lg font-medium text-gray-900 mb-4">Filtros</h3>
                    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                        
                        {/* Combobox Tabela de Preço */}
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">
                                Tabela de Preço <span className="text-red-500">*</span>
                            </label>
                            <select
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black"
                                value={tabelaPrecoFilter}
                                onChange={(e) => setTabelaPrecoFilter(e.target.value)}
                            >
                                <option value="">Selecione uma tabela...</option>
                                {ListTabelas.map((tabela) => (
                                    <option key={tabela.fv_tabelapreco_cd} value={tabela.fv_tabelapreco_cd}>
                                        {tabela.fv_tabelapreco_cd} - {tabela.fv_tabelapreco_descricao}
                                    </option>
                                ))}
                            </select>
                        </div>
                        {/* Combobox Fabricante */}
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">
                                Fabricante <span className="text-red-500">*</span>
                            </label>
                            <select
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black"
                                value={cdpessoabluesoftfabricanteFilter}
                                onChange={(e) => {setCdpessoabluesoftfabricanteFilter(e.target.value)}}
                            >
                                <option value="0">Selecione um fabricante...</option>
                                {(ListFabricanteFv.length > 0) && ListFabricanteFv.map((fabricante) => (
                                    <option key={fabricante.fv_fabricante_cdpessoabluesoft} value={fabricante.fv_fabricante_cdpessoabluesoft}>
                                        {fabricante.fv_fabricante_descricao}
                                    </option>
                                ))}
                            </select>
                        </div>  
                        {/* Campo Data Vigência */}
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Vigência Inicial</label>
                            <input
                                type="date"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black"
                                value={vigenciaInicialFilter}
                                onChange={(e) => setVigenciaInicialFilter(e.target.value)}
                            />
                        </div>
                        {/* Campo Codigo Produto */}
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Código do Produto</label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black"
                                placeholder="Filtrar por código do produto"
                                value={prb_cdprodutoBluesoftFilter}
                                onChange={(e) => setPrb_cdprodutoBluesoftFilter(e.target.value)}
                            />
                        </div>  
                        {/* Campo Descrição Produto */}
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Descrição do Produto</label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black"
                                placeholder="Filtrar por descrição do produto"
                                value={prb_descricaoFilter}
                                onChange={(e) => setPrb_descricaoFilter(e.target.value)}
                            />
                        </div>  
                       
                    </div>
                </div>

                {/* Informação da Tabela Selecionada */}
                {tabelaPrecoFilter && (
                    <div className="bg-blue-50 rounded-lg p-4 mb-6 border border-blue-200">
                        <h4 className="text-md font-medium text-blue-800 mb-2">Tabela Selecionada</h4>
                        <p className="text-sm text-blue-700">
                            <strong>Código:</strong> {tabelaPrecoFilter} | <strong>Descrição:</strong> {getSelectedTabelaDescricao()}
                        </p>
                    </div>
                )}

                {/* Grid de Produtos */}
                {ListProdutos.length > 0  ? (
                    <div className="bg-white rounded-lg shadow-md overflow-hidden border border-blue-100">
                        <div className="bg-blue-50 px-6 py-3 border-b border-blue-200">
                            <h3 className="text-lg font-medium text-blue-800">
                                Produtos da Tabela
                            </h3>
                        </div>
                        <div className="max-h-[600px] overflow-y-auto">
                            <table className="min-w-full divide-y divide-gray-200">
                                <thead className="bg-blue-100 sticky top-0 z-10">
                                    <tr>
                                        <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Tabela</th>
                                        <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Versão</th>
                                        <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Data Início Vigência</th>
                                        <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Cód. Produto</th>
                                        <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Descrição</th>
                                        <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Preço Embalagem</th>
                                        <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Preço Unitário</th>
                                        <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Desc. Máximo (%)</th>
                                        <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Desc. Padrão (%)</th>
                                        <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Acrésc. Máximo (%)</th>
                                        <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Fator Preço</th>
                                        <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Preço Promocional</th>
                                    </tr>
                                </thead>
                                <tbody className="bg-white divide-y divide-gray-200">
                                    {ListProdutos.length > 0 ? (
                                        ListProdutos.map((produto, index) => (
                                            <tr key={`${produto.prb_cdprodutobluesoft}_${produto.versao}_${produto.fv_tabelapreco_cd}` || index} className="hover:bg-blue-50">
                                                <td className="px-4 py-2 text-sm text-gray-700 font-medium">
                                                    {produto.fv_tabelapreco_descricao}
                                                </td>
                                                <td className="px-4 py-2 text-sm text-gray-700 text-center">
                                                    <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-blue-100 text-blue-800">
                                                        {produto.versao}
                                                    </span>
                                                </td>
                                                <td className="px-4 py-2 text-sm text-gray-700 font-medium">
                                                    {user.formatDateDDMMYYYY(produto.datainiciovigencia)}
                                                </td>
                                                <td className="px-4 py-2 text-sm text-gray-700 font-medium">
                                                    {produto.prb_cdprodutobluesoft}
                                                </td>
                                                <td className="px-4 py-2 text-sm text-gray-700 ">
                                                    
                                                        {produto.prb_descricao}
                                                    
                                                </td>

                                                <td className="px-4 py-2 text-sm text-gray-700 text-right font-medium">
                                                    {user.formatNumber(produto.precoembalagem, 2)}
                                                </td>
                                                <td className="px-4 py-2 text-sm text-gray-700 text-right">
                                                    {user.formatNumber(produto.precounitario, 3)}
                                                </td>
                                                <td className="px-4 py-2 text-sm text-gray-700 text-right">
                                                    {user.formatNumber(produto.descontomaximo, 2)}
                                                </td>
                                                <td className="px-4 py-2 text-sm text-gray-700 text-right">
                                                    {user.formatNumber(produto.descontopadrao, 2)}
                                                </td>
                                                <td className="px-4 py-2 text-sm text-gray-700 text-right">
                                                    {user.formatNumber(produto.acrescimomaximo, 2)}
                                                </td>
                                                <td className="px-4 py-2 text-sm text-gray-700 text-right">
                                                    {user.formatNumber(produto.fatorpreco, 4)}
                                                </td>
                                                <td className="px-4 py-2 text-sm text-gray-700 text-right">
                                                    {parseFloat(produto.precopromocional) > 0 ? (
                                                        <span className="font-medium text-green-700">
                                                            R$ {user.formatNumber(produto.precopromocional, 2)}
                                                        </span>
                                                    ) : (
                                                        <span className="text-gray-400">-</span>
                                                    )}
                                                </td>
                                            </tr>
                                        ))
                                    ) : (
                                        <tr>
                                            <td colSpan={10} className="px-6 py-4 text-center text-sm text-gray-500">
                                                {ActionStatus === 1 ? 'Carregando produtos...' : 'Nenhum Produto Encontrado'}
                                            </td>
                                        </tr>
                                    )}
                                </tbody>
                            </table>
                        </div>

                        {/* Rodapé com total de produtos */}
                        <div className="px-6 py-4 bg-blue-50 border-t border-blue-200">
                            <div className="flex justify-between items-center">
                                <div className="flex space-x-4">
                                    <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-blue-100 text-blue-800">
                                        Total de Produtos: {ListProdutos.length} 
                                    </span>
                                    <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-green-100 text-green-800">
                                        Com Promoção: {ListProdutos.filter(produto => parseFloat(produto.precopromocional) > 0).length}
                                    </span>

                                </div>
                                <div className="text-xs text-gray-500">
                                    Última consulta: {new Date().toLocaleString('pt-BR')}
                                </div>
                            </div>
                        </div>
                    </div>
                ) : (
                    <div className="bg-white rounded-lg shadow-md p-8 border border-gray-200 text-center">
                        <div className="text-gray-500">
                            <svg className="mx-auto h-12 w-12 text-gray-400" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M19 11H5m14 0a2 2 0 012 2v6a2 2 0 01-2 2H5a2 2 0 01-2-2v-6a2 2 0 012-2m14 0V9a2 2 0 00-2-2M5 11V9a2 2 0 012-2m0 0V5a2 2 0 012-2h6a2 2 0 012 2v2M7 7h10" />
                            </svg>
                            <h3 className="mt-2 text-sm font-medium text-gray-900">Selecione uma Tabela de Preço</h3>
                            <p className="mt-1 text-sm text-gray-500">
                                Para visualizar os produtos, primeiro selecione uma tabela de preço nos filtros acima.
                            </p>
                        </div>
                    </div>
                )}
            </div>
        </div>
    );
}