interface ComponenteMercadoriaVoucherProps {
  listVouchers: any[];
}

export default function ComponenteMercadoriaVoucher({ listVouchers }: ComponenteMercadoriaVoucherProps) {
    if (!listVouchers || listVouchers.length === 0) {
        return (
            <div className="bg-gray-50 border border-gray-200 rounded-lg p-4">
                <p className="text-sm text-gray-500 italic">Nenhum voucher encontrado</p>
            </div>
        );
    }

    const formatCurrency = (value: string | number | null) => {
        if (!value) return 'N/A';
        return `R$ ${parseFloat(value.toString()).toFixed(2).replace('.', ',')}`;
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

    const formatQuantity = (qty: string | number | null) => {
        if (!qty) return 'N/A';
        return parseFloat(qty.toString()).toFixed(3);
    };

    const getTipoDescontoLabel = (tipo: string) => {
        switch (tipo) {
            case '1': return '1';
            case '2': return '2';
            default: return tipo || 'N/A';
        }
    };

    const getTipoUtilizacaoLabel = (tipo: string) => {
        switch (tipo) {
            case '0': return '0';
            case '1': return '1';
            default: return tipo || 'N/A';
        }
    };

    const getTipoAplicacaoLabel = (tipo: string) => {
        switch (tipo) {
            case '1': return '1';
            case '2': return '2';
            default: return tipo || 'N/A';
        }
    };

    return (
        <div className="overflow-x-auto">
            <table className="min-w-full bg-white border border-gray-200 rounded-lg">
                <thead className="bg-gray-50">
                    <tr>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Código Voucher
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Descrição Parceiro
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Código Produto
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Qtd Máxima
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Valor Aplicação
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Data Inclusão
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Data Alteração
                        </th>                        
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Validade Inicial
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Validade Final
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Mínimo Venda
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Tipo Desconto
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Tipo Utilização
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Tipo Aplicação
                        </th>

                    </tr>
                </thead>
                <tbody className="bg-white divide-y divide-gray-200">
                    {listVouchers.map((voucher, index) => (
                        <tr key={voucher.cod_voucher || index} className="hover:bg-gray-50">
                            <td className="px-4 py-3 whitespace-nowrap text-sm font-medium text-gray-900">
                                <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-blue-100 text-blue-800">
                                    {voucher.cod_voucher || 'N/A'}
                                </span>
                            </td>
                            <td className="px-4 py-3 text-sm text-gray-900 max-w-xs truncate" title={voucher.descricao_parceiro?.trim() || 'N/A'}>
                                {voucher.descricao_parceiro?.trim() || 'N/A'}
                            </td>

                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-yellow-100 text-yellow-800">
                                    {voucher.cod_produto || 'N/A'}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="font-semibold text-blue-600">
                                    {formatQuantity(voucher.qtd_maxima)}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="font-semibold text-orange-600">
                                    {formatCurrency(voucher.valor_aplicacao)}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="text-gray-600">
                                    {formatDate(voucher.dth_inclusao)}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="text-gray-600">
                                    {formatDate(voucher.dth_alteracao)}
                                </span>
                            </td>

                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="text-gray-600">
                                    {formatDate(voucher.validade_inicial)}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="text-gray-600">
                                    {formatDate(voucher.validade_final)}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="font-semibold text-green-600">
                                    {formatCurrency(voucher.minimo_venda)}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-purple-100 text-purple-800">
                                    {getTipoDescontoLabel(voucher.tipo_desconto)}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-indigo-100 text-indigo-800">
                                    {getTipoUtilizacaoLabel(voucher.tipo_utilizacao)}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-cyan-100 text-cyan-800">
                                    {getTipoAplicacaoLabel(voucher.tipo_aplicacao)}
                                </span>
                            </td>
                         
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}
