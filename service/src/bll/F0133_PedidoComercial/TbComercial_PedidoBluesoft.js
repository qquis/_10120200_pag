const {dateFormat_yymmdd} = require('../../tools/dateFormat');

module.exports =  class TbComercial_PedidoBluesoft {
    constructor(        cm_pedblue_numeropedido						
                    ,	cm_pedblue_dataemissao 						
                    ,	cm_pedblue_datafechamento					
                    ,	cm_pedblue_dataentregainicial				
                    ,	cm_pedblue_dataentregafinal					
                    ,	cm_pedblue_cdpessoabluesoft_comprador		
                    ,	cm_pedblue_cdpessoabluesoft_fornecedor		
                    ,	cm_pedblue_divisao_cd	
                    ,   cm_pedblue_status_bluesoft					
                    ,	cm_pedblue_status_cd	

                    )
        {
                this.cm_pedblue_numeropedido	            = cm_pedblue_numeropedido	                   				
            ,	this.cm_pedblue_dataemissao 				= cm_pedblue_dataemissao 				 	
            ,	this.cm_pedblue_datafechamento				= cm_pedblue_datafechamento				 
            ,	this.cm_pedblue_dataentregainicial			= cm_pedblue_dataentregainicial			 
            ,	this.cm_pedblue_dataentregafinal			= cm_pedblue_dataentregafinal			 	
            ,	this.cm_pedblue_cdpessoabluesoft_comprador	= cm_pedblue_cdpessoabluesoft_comprador	 
            ,	this.cm_pedblue_cdpessoabluesoft_fornecedor	= cm_pedblue_cdpessoabluesoft_fornecedor	 
            ,	this.cm_pedblue_divisao_cd					= cm_pedblue_divisao_cd					 
            ,   this.cm_pedblue_status_bluesoft             = cm_pedblue_status_bluesoft
            ,	this.cm_pedblue_status_cd	                = cm_pedblue_status_cd	                   
    }
    static bluesoftApiConstructor (item)
        {
                    return new TbComercial_PedidoBluesoft( 
                       parseInt(item.numeroPedido)
                    ,  dateFormat_yymmdd(item.dataEmissao || "1900-01-01 01:01:01")
                    ,  dateFormat_yymmdd(item.dataFechamento || "1900-01-01 01:01:01")
                    ,  dateFormat_yymmdd(item.dataEntregaInicial || "1900-01-01 01:01:01")
                    ,  dateFormat_yymmdd(item.dataEntregaFinal || "1900-01-01 01:01:01")
                    ,  parseInt(item.compradorKey || 0 )
                    ,  parseInt(item.fornecedorKey)
                    ,  parseInt(item.divisaoKey)
                    ,  item.statusPedido || "ABERTO"
                    ,  parseInt(1)
                    );
       }
    
    F0133_01_DBINSERT_API() {
        return `SELECT f0133_01_1011900_comercial_pedidoblusoft_crud_result 
        ('DBINSERT_API',
                0,
                 ${this.cm_pedblue_numeropedido},
                '${this.cm_pedblue_dataemissao}',
                '${this.cm_pedblue_datafechamento}',
                '${this.cm_pedblue_dataentregainicial}',
                '${this.cm_pedblue_dataentregafinal}',
                ${this.cm_pedblue_cdpessoabluesoft_comprador},
                ${this.cm_pedblue_cdpessoabluesoft_fornecedor},
                ${this.cm_pedblue_divisao_cd},
                '${this.cm_pedblue_status_bluesoft}',                
                ${this.cm_pedblue_status_cd}
                    )`
    }

    display() {
        console.log(`Número do Pedido: ${this.cm_pedblue_numeropedido}`)
    }
}






