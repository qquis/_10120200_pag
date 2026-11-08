const {dateFormat_yymmdd} = require('../../tools/dateFormat');

module.exports =  class produtobluesoft_gtins {
    constructor(       cdbarra_pk
                    ,  cdprodutobluesoft			
                    ,  embalagem 
                    ,  embalagemdescricao 
                    )
        {
               this.prbg_cdbarra_pk = cdbarra_pk
            ,  this.prb_cdprodutobluesoft = cdprodutobluesoft
            ,  this.prbg_embalagem = embalagem
            ,  this.prbg_embalagemdescricao = embalagemdescricao
  
    }
    static bluesoftApiConstructor (item)
        {
                    return new produtobluesoft_gtins ( 
                       item.prbg_cdbarra_nk
                    ,  parseInt(item.prb_cdprodutobluesoft)
                    ,  (item.prbg_embalagem || "PRODUTO SEM DESCRICAO").replace(`'`, ``)  
                    ,  (item.prbg_descricao || "PRODUTO SEM DESCRICAO").replace(`'`, ``)  
                    );
       }
    
    F0021_02_ProdutoBlueSoftGtins_CRUD() {
        return `SELECT f0021_02_1011924_produtobluesoft_gtins_crud 
        ('DBINSERT_API',
                '${this.prbg_cdbarra_pk}',
                ${this.prb_cdprodutobluesoft},
                '${this.prbg_embalagem}',
                '${this.prbg_embalagemdescricao}', 
                'true'
                    )`
    }

    display() {
        console.log(`Cód: ${this.prbg_cdbarra_pk} Descrição: ${this.prbg_embalagem}`)
    }
}
