interface ComponenteMercadoriaProps {
  infoExternalZanthusMercadoria: any;
}

export default function ComponenteZanthusTabMercadoria({ infoExternalZanthusMercadoria }: ComponenteMercadoriaProps) {
    return (
        <div className="space-y-4">
            {/* Informações Básicas */}
            <div className="bg-gray-50 border border-gray-200 rounded p-3">
                <h5 className="text-sm font-medium text-gray-700 mb-2 border-b border-gray-200 pb-1">
                    Informações Básicas
                </h5>
                <div className="grid grid-cols-1 md:grid-cols-6 gap-3 text-sm">
                    <div className="md:col-span-2">
                        <span className="text-gray-600">Código:</span>
                        <span className="ml-2 font-medium text-gray-800">
                            {infoExternalZanthusMercadoria?.cod_mercadoria || 'N/A'}
                        </span>
                    </div>
                    <div>
                        <span className="text-gray-600">CFOP:</span>
                        <span className="ml-2 font-medium text-gray-800">
                            {infoExternalZanthusMercadoria?.cfop || 'N/A'}
                        </span>
                    </div>
                    <div>
                        <span className="text-gray-600">Cód. Trib:</span>
                        <span className="ml-2 font-medium text-gray-800">
                            {infoExternalZanthusMercadoria?.cod_tributacao_mercadoria || 'N/A'}
                        </span>
                    </div>
                    <div className="md:col-span-6">
                        <span className="text-gray-600">Descrição:</span>
                        <span className="ml-2 font-medium text-gray-800">
                            {infoExternalZanthusMercadoria?.descricao || 'N/A'}
                        </span>
                    </div>
                </div>
            </div>

            {/* Informações Tributárias */}
            <div className="bg-gray-50 border border-gray-200 rounded p-3">
                <h5 className="text-sm font-medium text-gray-700 mb-2 border-b border-gray-200 pb-1">
                    Informações Tributárias
                </h5>
                <div className="grid grid-cols-1 md:grid-cols-5 gap-3 text-sm">

                    {/* REFORMA TRIBUTARIA */}
                    <div className="md:col-span-2">
                        <div className="font-medium text-purple-700 mb-1">Reforma Tributária</div>
                        <div className="space-y-1">
                            <div>
                                <span className="text-gray-600">CST IBS/CBS:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.cod_sit_tributaria_ibs_cbs || 'N/A'}</span>
                            </div>
                            <div>
                                <span className="text-gray-600">Class Trib IBS/CBS:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.cod_class_tributaria_ibs_cbs || 'N/A'}</span>
                            </div>

	                        <div>
                                <span className="text-gray-600">Alíquota IBS/UF:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.per_aliquota_ibs_uf || 'N/A'}</span>
                            </div>
        
                            <div>
                                <span className="text-gray-600">Redução IBS/UF:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.per_reducao_aliquota_ibs_uf || 'N/A'}</span>
                            </div>

                            <div>
                                <span className="text-gray-600">Diferimento IBS/UF:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.per_diferimento_ibs_uf || 'N/A'}</span>
                            </div>

                            <div>
                                <span className="text-gray-600">Alíquota IBS/MUN:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.per_aliquota_ibs_mun || 'N/A'}</span>
                            </div>
        
                            <div>
                                <span className="text-gray-600">Redução IBS/MUN:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.per_reducao_aliquota_ibs_mun || 'N/A'}</span>
                            </div>

                            <div>
                                <span className="text-gray-600">Diferimento IBS/MUN:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.per_diferimento_ibs_mun || 'N/A'}</span>
                            </div>

                            <div>
                                <span className="text-gray-600">Alíquota CBS:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.per_aliquota_cbs || 'N/A'}</span>
                            </div>
        
                            <div>
                                <span className="text-gray-600">Diferimento CBS:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.per_diferimento_cbs || 'N/A'}</span>
                            </div>

                            <div>
                                <span className="text-gray-600">Redução CBS:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.per_reducao_aliquota_cbs || 'N/A'}</span>
                            </div>

                            <div>
                                <span className="text-gray-600">Origem Cadastro:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.origem_cadastro || 'N/A'}</span>
                            </div>  
                        </div>
                    </div>  


                    {/* ICMS */}
                    <div>
                        <div className="font-medium text-blue-700 mb-1">ICMS</div>
                        <div className="space-y-1">
                            <div>
                                <span className="text-gray-600">CST:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.cod_situacao_tributaria || 'N/A'}</span>
                            </div>
                            <div>
                                <span className="text-gray-600">Alíquota:</span>
                                <span className="ml-1 text-gray-800"> 
                                    {infoExternalZanthusMercadoria?.aliquota_icms !== undefined 
                                        ? infoExternalZanthusMercadoria.aliquota_icms 
                                        : 'N/A'}%</span>
                            </div>
                            <div>
                                <span className="text-gray-600">Redução:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.percentual_reduz_b_calculo || 'N/A'}%</span>
                            </div>
                            <div>
                                <span className="text-gray-600">CBENEF:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.codigo_beneficio_fiscal || 'N/A'}</span>
                            </div>                            
                        </div>
                    </div>

                    {/* PIS */}
                    <div>
                        <div className="font-medium text-green-700 mb-1">PIS</div>
                        <div className="space-y-1">
                            <div>
                                <span className="text-gray-600">CST:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.cod_sit_trib_pis || 'N/A'}</span>
                            </div>
                            <div>
                                <span className="text-gray-600">Alíquota:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.aliquota_pis || 'N/A'}%</span>
                            </div>
                        </div>
                    </div>

                    {/* COFINS */}
                    <div>
                        <div className="font-medium text-purple-700 mb-1">COFINS</div>
                        <div className="space-y-1">
                            <div>
                                <span className="text-gray-600">CST:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.cod_sit_trib_cofins || 'N/A'}</span>
                            </div>
                            <div>
                                <span className="text-gray-600">Alíquota:</span>
                                <span className="ml-1 text-gray-800">{infoExternalZanthusMercadoria?.aliquota_cofins || 'N/A'}%</span>
                            </div>
                        </div>
                    </div>
                  
                </div>
            </div>
        </div>
    )
}