interface ComponenteTabRegrasICMSProps {
  listregraICMS: any[];
}

export default function ComponenteTabRegrasICMS({ listregraICMS }: ComponenteTabRegrasICMSProps) {
    if (!listregraICMS || listregraICMS.length === 0) {
        return (
            <div className="bg-gray-50 border border-gray-200 rounded-lg p-4">
                <p className="text-sm text-gray-500 italic">Nenhuma regra ICMS encontrada</p>
            </div>
        );
    }

    return (
        <div className="overflow-x-auto">
            <table className="min-w-full bg-white border border-gray-200 rounded-lg">
                <thead className="bg-gray-50">
                    <tr>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Código
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Destino
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Descrição
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Tipo Imposto
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            CST
                        </th>

                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            NCM Inicial
                        </th>

                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            UF Destino
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Alíquota (%)
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Redução (%)
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            NCM Final
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            UF Origem
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Data Cadastro
                        </th>            
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Última Atualização
                        </th>                                                
                    </tr>
                </thead>
                <tbody className="bg-white divide-y divide-gray-200">
                    {listregraICMS.map((regra, index) => (
                        <tr key={regra.cod_regras_icms || index} className="hover:bg-gray-50">
                            <td className="px-4 py-3 whitespace-nowrap text-sm font-medium text-gray-900">
                                {regra.cod_regras_icms || 'N/A'}
                            </td>
                            <td className="px-4 py-3 text-sm text-gray-900 max-w-xs truncate" title={regra.flg_revenda?.trim() || 'N/A'}>
                                {regra.flg_revenda?.trim() == 'S'? 'REVENDA' : 'CONSUMIDOR'}
                            </td>                            
                            <td className="px-4 py-3 text-sm text-gray-900 max-w-xs truncate" title={regra.descricao?.trim() || 'N/A'}>
                                {regra.descricao?.trim() || 'N/A'}
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                {regra.flg_tipo_imposto || 'N/A'}
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-blue-100 text-blue-800">
                                    {regra.cst?.trim() || 'N/A'}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-green-100 text-green-800">
                                    {regra.uf_origem || 'N/A'}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-orange-100 text-orange-800">
                                    {regra.uf_destino || 'N/A'}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="font-semibold text-blue-600">
                                    {regra.aliquota ? `${parseFloat(regra.aliquota).toFixed(2)}%` : 'N/A'}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="font-semibold text-orange-600">
                                    {regra.perc_reducao ? `${parseFloat(regra.perc_reducao).toFixed(2)}%` : 'N/A'}
                                </span>
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                {regra.cod_ncm_ini || 'N/A'}
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                {regra.cod_ncm_final || 'N/A'}
                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                {new Date(regra.data_cadastro).toLocaleString() || 'N/A'}
                            </td>
                         <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                {regra.data_ultima_alteracao ? 
                                    new Date(regra.data_ultima_alteracao).toLocaleString('pt-BR', {
                                        day: '2-digit',
                                        month: '2-digit', 
                                        year: 'numeric',
                                        hour: '2-digit',
                                        minute: '2-digit'
                                    }) : 'N/A'
                                }
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}