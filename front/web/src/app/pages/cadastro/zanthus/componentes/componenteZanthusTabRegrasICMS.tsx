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
                            Destinação
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            CST
                        </th>


                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Alíquota (%)
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Redução (%)
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            NCM
                        </th>
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            Cad/Atualização
                        </th>            
   
                        <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                            UF
                        </th>                                       
                    </tr>
                </thead>
                <tbody className="bg-white divide-y divide-gray-200">
                    {listregraICMS.map((regra, index) => {
                        const tipoImposto = String(regra.flg_tipo_imposto ?? '').trim();
                        const cst = String(regra.cst ?? '').trim();
                        const cbenef = String(regra.codigo_beneficio_fiscal ?? '').trim();
                        const exibirCbenef = tipoImposto === '0' && ['040', '020'].includes(cst);

                        return (
                        <tr key={regra.cod_regras_icms || index} className="hover:bg-gray-50">
                            <td className={`px-4 py-3 whitespace-nowrap text-sm font-medium text-gray-900 ${regra.flg_revenda?.trim() == 'S' ? 'bg-red-100' : 'bg-green-100'}`}>
                                {regra.flg_revenda?.trim() == 'S'? 'REVENDA' : 'CONSUMIDOR'} Tipo Imp. {tipoImposto || 'N/A'} <br />
                                {regra.cod_regras_icms || 'N/A'} | {regra.tipo_imposto_descricao?.trim() || 'N/A'}

                            </td>
                            <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-blue-100 text-blue-800">
                                    {cst || 'N/A'} 
                                    {exibirCbenef && (
                                        
                                        <span className={`ml-1 ${cbenef ? '' : 'text-red-600'}`}>
                                            | CBENEF {cbenef || 'N/A'}
                                        </span>
                                    )}
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
                                {regra.cod_ncm_final || 'N/A'}
                            </td>
                             <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                            {new Date(regra.data_cadastro).toLocaleString() || 'N/A'} 
                            <br/>
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
                                                        <td className="px-4 py-3 whitespace-nowrap text-sm text-gray-900">
                                <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-orange-100 text-orange-800">
                                     {regra.uf_origem || 'N/A'}/{regra.uf_destino || 'N/A'}
                                </span>
                            </td>

                        </tr>
                        );
                    })}
                </tbody>
            </table>
        </div>
    );
}