interface ComponenteZanthusComposicaoProps {
  composicao: {
    cod_mercadoria: string;
    forma_decomposicao: string;
    tipo_decomposicao: string;
    data_cadastro: string;
    data_ultima_alteracao: string;
    itens?: Array<{
      cod_mercadoria: string;
      cod_insumo: string;
      percentual_insumo: string;
      quantidade_insumo: string;
      preco_unitario_insumo: string | null;
      data_cadastro: string;
      data_ultima_alteracao: string;
    }>;
  } | null;
}

export default function ComponenteZanthusComposicao({ composicao }: ComponenteZanthusComposicaoProps) {
    // Debug: Vamos verificar o que está chegando

    if (!composicao) {
        return (
            <div className="bg-gray-50 border border-gray-200 rounded-lg p-4">
                <p className="text-sm text-gray-500 italic">Nenhuma composição encontrada</p>
            </div>
        );
    }

    const formatDate = (dateString: string | null) => {
        if (!dateString) return 'N/A';
        try {
            return new Date(dateString).toLocaleDateString('pt-BR', {
                day: '2-digit',
                month: '2-digit',
                year: 'numeric',
                hour: '2-digit',
                minute: '2-digit'
            });
        } catch (error) {
            console.error('Erro ao formatar data:', error);
            return 'Data inválida';
        }
    };

    const formatCurrency = (value: string | number | null) => {
        if (!value || value === null || value === 'null') return 'N/A';
        try {
            return `R$ ${parseFloat(value.toString()).toFixed(2).replace('.', ',')}`;
        } catch (error) {
            return 'N/A';
        }
    };

    const formatPercentage = (value: string | number | null) => {
        if (!value) return 'N/A';
        try {
            return `${parseFloat(value.toString()).toFixed(2)}%`;
        } catch (error) {
            return 'N/A';
        }
    };

    const formatQuantity = (value: string | number | null) => {
        if (!value) return 'N/A';
        try {
            return parseFloat(value.toString()).toFixed(3);
        } catch (error) {
            return 'N/A';
        }
    };

    const getFormaDecomposicaoLabel = (forma: string) => {
        switch (forma?.trim()) {
            case '1': return 'Por Receita';
            case '2': return 'Por Lista';
            case '3': return 'Por Fórmula';
            case '4': return 'Automática';
            default: return forma || 'N/A';
        }
    };

    const getTipoDecomposicaoLabel = (tipo: string) => {
        switch (tipo?.trim()) {
            case '1': return 'Percentual';
            case '2': return 'Quantidade';
            case '3': return 'Valor';
            case '7': return 'Mista';
            default: return tipo || 'N/A';
        }
    };

    // Verificar se existem itens de forma mais robusta
    const hasItens = composicao.itens && Array.isArray(composicao.itens) && composicao.itens.length > 0;

    return (
        <div className="space-y-6">

            {/* Informações da Composição Principal */}
            <div className="bg-white border border-gray-200 rounded-lg p-6">
                <h3 className="text-lg font-semibold text-gray-900 mb-4">Informações da Composição</h3>
                <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                    <div>
                        <label className="block text-sm font-medium text-gray-500">Código Mercadoria</label>
                        <span className="inline-flex px-3 py-1 text-sm font-semibold rounded-full bg-blue-100 text-blue-800">
                            {composicao.cod_mercadoria || 'N/A'}
                        </span>
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-500">Forma Decomposição</label>
                        <span className="inline-flex px-3 py-1 text-sm font-semibold rounded-full bg-green-100 text-green-800">
                            {getFormaDecomposicaoLabel(composicao.forma_decomposicao)}
                        </span>
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-500">Tipo Decomposição</label>
                        <span className="inline-flex px-3 py-1 text-sm font-semibold rounded-full bg-purple-100 text-purple-800">
                            {getTipoDecomposicaoLabel(composicao.tipo_decomposicao)}
                        </span>
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-500">Data Cadastro</label>
                        <p className="text-sm text-gray-900">{formatDate(composicao.data_cadastro)}</p>
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-500">Última Alteração</label>
                        <p className="text-sm text-gray-900">{formatDate(composicao.data_ultima_alteracao)}</p>
                    </div>
                </div>
            </div>

            {/* Tabela de Itens/Insumos */}
            {!hasItens ? (
                <div className="bg-gray-50 border border-gray-200 rounded-lg p-4">
                    <p className="text-sm text-gray-500 italic">
                        Nenhum insumo encontrado para esta composição
                        {composicao.itens && (
                            <span className="block text-xs mt-1">
                                (Estrutura presente mas vazia ou inválida: {JSON.stringify(composicao.itens)})
                            </span>
                        )}
                    </p>
                </div>
            ) : (
                <div className="bg-white border border-gray-200 rounded-lg">
                    <div className="px-6 py-4 border-b border-gray-200">
                        <h3 className="text-lg font-semibold text-gray-900">Insumos da Composição</h3>
                        <p className="text-sm text-gray-500">Total de {composicao.itens!.length} insumos</p>
                    </div>
                    <div className="overflow-x-auto">
                        <table className="min-w-full bg-white">
                            <thead className="bg-gray-50">
                                <tr>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                                        Código Insumo
                                    </th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                                        Percentual (%)
                                    </th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                                        Quantidade
                                    </th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                                        Preço Unitário
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
                                {composicao.itens!.map((item, index) => (
                                    <tr key={`${item.cod_insumo}-${index}`} className="hover:bg-gray-50">
                                        <td className="px-4 py-3 whitespace-nowrap text-sm font-medium text-gray-900">
                                            <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-yellow-100 text-yellow-800">
                                                {item.cod_insumo || 'N/A'}
                                            </span>
                                        </td>
                                        <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                            <span className="font-semibold text-blue-600">
                                                {formatPercentage(item.percentual_insumo)}
                                            </span>
                                        </td>
                                        <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                            <span className="font-semibold text-green-600">
                                                {formatQuantity(item.quantidade_insumo)}
                                            </span>
                                        </td>
                                        <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                            <span className={`font-semibold ${item.preco_unitario_insumo ? 'text-orange-600' : 'text-gray-400'}`}>
                                                {formatCurrency(item.preco_unitario_insumo)}
                                            </span>
                                        </td>
                                        <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                            <span className="text-gray-600">
                                                {formatDate(item.data_cadastro)}
                                            </span>
                                        </td>
                                        <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                            <span className="text-gray-600">
                                                {formatDate(item.data_ultima_alteracao)}
                                            </span>
                                        </td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    </div>
                </div>
            )}
        </div>
    );
}
