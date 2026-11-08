'use client'

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";

import { moduleForcaVenda } from "@/api/m0004_forcavenda/moduleforcavenda";

export default function PrazoPagamentoList() {

    const __SIS_AC_CD : number = 3215

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);

    /* STATES LISTS */
    const [List, setList] = useState<any[]>([]);

    const ConsultarList = async () => {
        try {
            setList([]) // Limpando a lista antes de buscar novos dados
            setActionStatus(1);

            const myMODULE : moduleForcaVenda = new moduleForcaVenda(user, __SIS_AC_CD);       
            
 
            const response = await myMODULE.getPrazoPgto();

            setList(response || []);
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar prazos de pagamento:', error);
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

    const formatCurrency = (value: any) => {
        if (!value) return '-';
        return parseFloat(value).toLocaleString('pt-BR', {
            style: 'currency',
            currency: 'BRL'
        });
    };

    const formatCoeficiente = (value: any) => {
        if (!value) return '-';
        return parseFloat(value).toFixed(5);
    };

    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Força de Vendas | Prazos de Pagamento">
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

                {/* Grid de Prazos de Pagamento */}
                <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
                    <div className="max-h-[600px] overflow-y-auto">
                        <table className="min-w-full divide-y divide-gray-200">
                            <thead className="bg-gray-100 sticky top-0 z-10">
                                <tr>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Código</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Descrição</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Tabela Preço Padrão / N. Order</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Custo Financeiro</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Coef. Custo Financeiro</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Tipo</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Tipo Custo</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Status</th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Versão</th>
                                </tr>
                            </thead>
                            <tbody className="bg-white divide-y divide-gray-200">
                                {List.length > 0 ? (
                                    List.map((itemList, index) => (
                                        <tr key={itemList.fv_prazopgto_cd || index} className="hover:bg-gray-50">
                                            <td className="px-4 py-2 text-sm text-gray-700 font-medium">
                                                {itemList.fv_prazopgto_cd}
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700 max-w-xs">
                                                {itemList.fv_prazopgto_descricao}
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700 text-right">
                                                {itemList.listapadraoorder}
                                            </td>                                            
                                            <td className="px-4 py-2 text-sm text-gray-700 text-right">
                                                {user.formatNumber(itemList.custofinanceiro,4)}
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700 text-right">
                                                {user.formatNumber(itemList.coefcustofinanceiro,5)}
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700">
                                                <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${
                                                    itemList.tipo === 'PARCELA' ? 'bg-blue-100 text-blue-800' : 
                                                    itemList.tipo === 'À VISTA' ? 'bg-green-100 text-green-800' : 
                                                    'bg-gray-100 text-gray-800'
                                                }`}>
                                                    {itemList.tipo}
                                                </span>
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700">
                                                <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${
                                                    itemList.tipocusto === 'MENSAL' ? 'bg-purple-100 text-purple-800' : 
                                                    itemList.tipocusto === 'ANUAL' ? 'bg-orange-100 text-orange-800' : 
                                                    'bg-gray-100 text-gray-800'
                                                }`}>
                                                    {itemList.tipocusto}
                                                </span>
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700">
                                                <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${
                                                    itemList.status === 1 ? 'bg-green-100 text-green-800' : 'bg-red-100 text-red-800'
                                                }`}>
                                                    <span className={`inline-block w-2 h-2 rounded-full mr-1 ${
                                                        itemList.status === 1 ? 'bg-green-500' : 'bg-red-500'
                                                    }`}></span>
                                                    {itemList.status === 1 ? 'Ativo' : 'Inativo'}
                                                </span>
                                            </td>
                                            <td className="px-4 py-2 text-sm text-gray-700 text-center">
                                                {itemList.versao}
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

                {/* Rodapé com total de registros */}
                <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
                    <div className="flex justify-between items-center">
                        <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
                            Total de Registros: {List.length} 
                        </span>
                        <div className="text-xs text-gray-500">
                            Última atualização: {new Date().toLocaleString('pt-BR')}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}