module.exports =  class produtobluesoft_tributacao {
    constructor(       prb_cdprodutobluesoft     
                    ,  prbt_pis_saida_cst        
					,  prbt_pis_saida_aliquota	
					,  prbt_cofins_saida_cst     
					,  prbt_cofins_saida_aliquota
					,  prbt_icms_saida_cst       
					,  prbt_icms_aliquota_interna
					,  prbt_icms_reducao		
					,  prbt_ncm                  
					,  prbt_cest                 

                    )
        {
               this.prb_cdprodutobluesoft           = prb_cdprodutobluesoft     
               this.prbt_pis_saida_cst              = prbt_pis_saida_cst                  
               this.prbt_pis_saida_aliquota		    = prbt_pis_saida_aliquota	
               this.prbt_cofins_saida_cst           = prbt_cofins_saida_cst     
               this.prbt_cofins_saida_aliquota	    = prbt_cofins_saida_aliquota
               this.prbt_icms_saida_cst             = prbt_icms_saida_cst       
               this.prbt_icms_aliquota_interna	    = prbt_icms_aliquota_interna
               this.prbt_icms_reducao			    = prbt_icms_reducao		
               this.prbt_ncm                        = prbt_ncm                  
               this.prbt_cest                       = prbt_cest                 
  
    }
    static bluesoftApiConstructor (item)
        {
                    return new produtobluesoft_tributacao ( 
                       item.prb_cdprodutobluesoft      
                    ,  item.prbt_pis_saida_cst         
                    ,  parseFloat(item.prbt_pis_saida_aliquota)
                    ,  item.prbt_cofins_saida_cst      
                    ,  parseFloat(item.prbt_cofins_saida_aliquota)
                    ,  item.prbt_icms_saida_cst        
                    ,  parseFloat(item.prbt_icms_aliquota_interna)
                    ,  parseFloat(item.prbt_icms_reducao)
                    ,  item.prbt_ncm                   
                    ,  item.prbt_cest                  
                    );
       }
    
     F0023_01_ProdutoBluesoft_Tributacao() {
        return `SELECT f0021_04_1011940_produtobluesoft_tributacao_crud
        (   'DBINSERT_API',
            2,
            ${this.prb_cdprodutobluesoft},
            99999,
            99999,
            'X',
            '5102',
            '000',
            0.00,
            '${this.prbt_pis_saida_cst}',
             ${this.prbt_pis_saida_aliquota},
            '000',
             0.00,
            '${this.prbt_cofins_saida_cst}',
             ${this.prbt_cofins_saida_aliquota},
             '000',
             0.00,
             0.00,
             '${this.prbt_icms_saida_cst}', 
             ${this.prbt_icms_aliquota_interna},
             ${this.prbt_icms_reducao},
             '000',
             0.00,
             0.00,
             '${this.prbt_ncm}', 
             '${this.prbt_cest}',              
             0.00,
            'true'
                 )`
    }

    display() {
        console.log(`Cód: ${this.prbg_cdbarra_pk} Descrição: ${this.prbg_embalagem}`)
    }
}

