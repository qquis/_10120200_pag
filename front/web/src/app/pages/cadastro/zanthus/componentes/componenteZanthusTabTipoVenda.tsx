interface ComponenteTabTipoVendaProps {
  listTipoVenda: any[];
}

export default function ComponenteTabTipoVenda({ listTipoVenda }: ComponenteTabTipoVendaProps) {
    if (!listTipoVenda || listTipoVenda.length === 0) {
        return (
            <div className="bg-gray-50 border border-gray-200 rounded-lg p-4">
                <p className="text-sm text-gray-500 italic">Nenhum tipo de venda encontrado</p>
            </div>
        );
    }

    const formatPrice = (price: string | number | null) => {
        if (!price) return 'N/A';
        return `R$ ${parseFloat(price.toString()).toFixed(2).replace('.', ',')}`;
    };

    const formatDate = (dateString: string | null) => {
        if (!dateString) return 'N/A';
        return new Date(dateString).toLocaleDateString('pt-BR', {
            day: '2-digit',
            month: '2-digit',
            year: 'numeric',
            hour: '2-digit',
            minute: '2-digit'
        });
    };

    return (
        <div className="overflow-x-auto">
            <table className="min-w-full bg-white border border-gray-200 rounded-lg">
                <thead className="bg-gray-50">
                    <tr>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Código Mercadoria
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Código Tipo Venda
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Preço Unitário
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Preço Anterior
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Data Cadastro
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Última Alteração
                        </th>
                    </tr>
                </thead>
                <tbody className="bg-white divide-y divide-gray-200">
                    {listTipoVenda.map((tipoVenda, index) => (
                        <tr key={`${tipoVenda.cod_mercadoria}-${tipoVenda.cod_tipo_venda}` || index} className="hover:bg-gray-50">
                            <td className="px-4 py-3 whitespace-nowrap text-sm font-medium text-gray-900">
                                <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-blue-100 text-blue-800">
                                    {tipoVenda.cod_mercadoria || 'N/A'}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-green-100 text-green-800">
                                    {tipoVenda.cod_tipo_venda || 'N/A'}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="font-semibold text-green-600">
                                    {formatPrice(tipoVenda.preco_unitario)}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className={`font-semibold ${tipoVenda.preco_anterior ? 'text-orange-600' : 'text-gray-400'}`}>
                                    {formatPrice(tipoVenda.preco_anterior)}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="text-gray-600">
                                    {formatDate(tipoVenda.data_cadastro)}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="text-gray-600">
                                    {formatDate(tipoVenda.data_ultima_alteracao)}
                                </span>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}
