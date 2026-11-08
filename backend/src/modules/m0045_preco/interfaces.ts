interface reportPrecoFilter {
    tipo_relatorio 					: string 
	//	---	LOG_BLUE_ALL
	//	---	LOG_BLUE_D1	
	//	--- CUSTOM			
	tab_pre_cd						: number 
	data_log_filter					: number 
	data_log_ini					: Date
	data_log_fim					: Date
	pr_cdproduto 					: number
	prb_cdprodutobluesoft_unitario 	: number
	prb_cdprodutobluesoft			: number
    pr_descricao 					: string 
 	prb_descricao 					: string 
	tipo_produto					: string 
	data_agendamento_filter			: number
	data_agendamento_inicial		: Date 
	data_agendamento_final			: Date
        // UNITARIO
        // UNI_ASSOC
        // TODOS 
}

export default reportPrecoFilter