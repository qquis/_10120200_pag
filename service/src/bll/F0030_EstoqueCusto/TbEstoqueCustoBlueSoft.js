

module.exports =  class TbEstoqueCustoBlueSoft {
    constructor(        prb_cdprodutobluesoft     
                    ,	ecb_embalagemestoqueqtde			
                    ,	ecb_embalagemestoqueqtde_online		
                    ,	ecb_embalagemestoqueqtde_disponivel 
                    ,	ecb_embalagemestoqueqtde_Contabil	
                    ,	ecb_valor_customedio_contabil		
                    , 	ecb_valor_custoMedio_SemImposto		
                    ,   ecb_valor_custoMedio_ComImposto		
                    ,   ecb_valor_custoBruto_UltimaCompra	
                    ,  	ecb_valor_custoLiquido_UltimaCompra	
                    )
        {
               this.prb_cdprodutobluesoft                   =   prb_cdprodutobluesoft 
               this.ecb_embalagemestoqueqtde			    =   parseFloat(ecb_embalagemestoqueqtde || 0.00 )
               this.ecb_embalagemestoqueqtde_online		    =   parseFloat(ecb_embalagemestoqueqtde_online || 0.00 )
               this.ecb_embalagemestoqueqtde_disponivel     =   parseFloat(ecb_embalagemestoqueqtde_disponivel || 0.00 )
               this.ecb_embalagemestoqueqtde_Contabil	    =   parseFloat(ecb_embalagemestoqueqtde_Contabil || 0.00 )
               this.ecb_valor_customedio_contabil		    =   parseFloat(ecb_valor_customedio_contabil || 0.00 )
               this.ecb_valor_custoMedio_SemImposto		    =   parseFloat(ecb_valor_custoMedio_SemImposto || 0.00 )
               this.ecb_valor_custoMedio_ComImposto		    =   parseFloat(ecb_valor_custoMedio_ComImposto || 0.00 )
               this.ecb_valor_custoBruto_UltimaCompra	    =   parseFloat(ecb_valor_custoBruto_UltimaCompra || 0.00 )
               this.ecb_valor_custoLiquido_UltimaCompra	    =   parseFloat(ecb_valor_custoLiquido_UltimaCompra || 0.00 )
    }
    static bluesoftApiConstructor (item)
        {

                    return new TbEstoqueCustoBlueSoft ( 
                       item.produtoKey      
                    ,  item.saldoFisico                         //-> ecb_embalagemestoqueqtde  
                    ,  item.saldoOnline                         //-> ecb_embalagemestoqueqtde_online
                    ,  item.saldoDisponivel                     //-> ecb_embalagemestoqueqtde_disponivel
                    ,  item.saldoEstoqueContabil                //-> ecb_embalagemestoqueqtde_Contabil
                    ,  item.custoMedioContabil
                    ,  item.custoMedioSemImposto
                    ,  item.custoMedioComImposto
                    ,  item.custoBrutoUltimaCompra
                    ,  item.custoLiquidoUltimaCompra
                    );
       }
    
    DBInsert() {
        return `SELECT f0030_09_1011980_estoquecustobluesoft_crud 
        (   'DBINSERT_API',
            ${this.prb_cdprodutobluesoft},
            ${this.ecb_embalagemestoqueqtde},
            ${this.ecb_embalagemestoqueqtde_online},
            ${this.ecb_embalagemestoqueqtde_disponivel},
            ${this.ecb_embalagemestoqueqtde_Contabil},		
            ${this.ecb_valor_customedio_contabil},			
            ${this.ecb_valor_custoMedio_SemImposto},		
            ${this.ecb_valor_custoMedio_ComImposto},		
            ${this.ecb_valor_custoBruto_UltimaCompra},		
            ${this.ecb_valor_custoLiquido_UltimaCompra},	
            'true'
                 )`
    }

    display() {
        console.log(`Cód: ${this.prb_cdprodutobluesoft}`)
    }
}