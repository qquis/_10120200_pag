const {dateFormat_yymmdd} = require('../../tools/dateFormat');

module.exports =  class produtobluesoft {
    constructor(       cdprodutobluesoft_pk
                    ,  cdprodutobluesoftunitario			
                    ,  descricao 						
                    ,  embalagemestoque                 
                    ,  fatorestoque 						
                    ,  status_embalagemcaixa				
                    ,  embalagemcompra					
                    ,  embalagemcompra_qtdeunitaria		
                    ,  cdbarra_principal					
                    ,  cdprodutobluesoft_controleestoque
                    ,  cdprodutobluesoft_controlepreco	
                    ,  cdsubgrupo						
                    ,  dt_cadastro						
                    ,  dt_ultimaalteracao				
                    ,  cdpessoabluesoft_fabricante		
                    ,  vendaexterna	
                    ,  cdproduto_compra_padrao	
                    ,  prbf_seq				
                    ,  status
                    ,  observacaoFiscal		
                    ,  descricaoGondola	 
                    ,  descricaoCupom              
                    ,  descricaoBalanca

                    )
        {
               this.prb_cdprodutobluesoft_pk = cdprodutobluesoft_pk
            ,  this.prb_cdprodutobluesoftunitario = cdprodutobluesoftunitario
            ,  this.prb_descricao = descricao
            ,  this.prb_embalagemestoque = embalagemestoque
            ,  this.prb_fatorestoque = fatorestoque
            ,  this.prb_status_embalagemcaixa = status_embalagemcaixa
            ,  this.prb_embalagemcompra = embalagemcompra
            ,  this.prb_embalagemcompra_qtdeunitaria = embalagemcompra_qtdeunitaria
            ,  this.prb_cdbarra_principal = cdbarra_principal	
            ,  this.prb_cdprodutobluesoft_controleestoque = cdprodutobluesoft_controleestoque
            ,  this.prb_cdprodutobluesoft_controlepreco = cdprodutobluesoft_controlepreco
            ,  this.prb_cdsubgrupo	= cdsubgrupo
            ,  this.prb_dt_cadastro =	 dt_cadastro					
            ,  this.prb_dt_ultimaalteracao = dt_ultimaalteracao
            ,  this.prb_cdpessoabluesoft_fabricante = cdpessoabluesoft_fabricante
            ,  this.prb_vendaexterna =	 vendaexterna	
            ,  this.prb_cdproduto_compra_padrao = cdproduto_compra_padrao
            ,  this.prbf_seq = prbf_seq
            ,  this.prb_status = status
            ,  this.prb_descricao_fiscal = observacaoFiscal
            ,  this.prb_descricao_gondola = descricaoGondola
            ,  this.prb_descricao_cupom  = descricaoCupom
            ,  this.prb_descricao_balanca  = descricaoBalanca;
    }
    static bluesoftApiConstructor (item)
        {
                    return new produtobluesoft( 
                       parseInt(item.produtoKey)
                    ,  parseInt(item.produtoUnitarioKey)
                    ,  (item.descricao || "PRODUTO SEM DESCRICAO").replace(`'`, ``)  
                    ,  item.embalagemKey
                    ,  item.fatorEstoque
                    ,  item.caixa 
                    ,  ""
                    ,  0
                    ,  item.gtinPrincipal
                    ,  0
                    ,  0
                    ,  item.subGrupoProdutoKey
                    ,  dateFormat_yymmdd(item.dataCadastro || "1900-01-01 01:01:01")
                    ,  dateFormat_yymmdd(item.ultimaAlteracao || "1900-01-01  01:01:01")
                    ,  (item.fabricanteKey || 0 )
                    ,  0
                    ,  0
                    ,  0 
                    ,  item.status
                    ,  (item.observacaoFiscal || "").replace(`'`, ``)  
                    ,  (item.descricaoGondola || "").replace(`'`, ``)  
                    ,  (item.descricaoCupom || "").replace(`'`, ``)  
                    ,  (item.descricaoBalanca || "").replace(`'`, ``)  
                    );
       }
    
     F0021_01_ProdutoBlueSoft_CRUD() {
        return `SELECT f0021_01_1011970_produtobluesoft_crud 
        ('DBINSERT_API',
                ${this.prb_cdprodutobluesoft_pk},
                ${this.prb_cdprodutobluesoftunitario},
                '${this.prb_descricao}',
                '${this.prb_embalagemestoque}',
                ${this.prb_fatorestoque},
                '${this.prb_status_embalagemcaixa}',
                'XX',
                0.00,
                '${this.prb_cdbarra_principal}',
                0,
                0,
                ${this.prb_cdsubgrupo},						
                '${this.prb_dt_cadastro}',
                '${this.prb_dt_ultimaalteracao}',
                ${this.prb_cdpessoabluesoft_fabricante},
                '0',
                '${this.prb_descricao_fiscal}',
                0,
                0,
                '${this.prb_status}', 
                0, 
                '${this.prb_descricao_gondola}', 
                '${this.prb_descricao_cupom}', 
                '${this.prb_descricao_balanca}', 
                0,
                0,
                0,
                0,
                'true'
                    )`
    }

    display() {
        console.log(`Cód: ${this.prb_cdprodutobluesoft_pk} Descrição: ${this.prb_descricao}`)
    }
}

/*
module.exports =  class Produtobluesoft {
    static _contruc (   cdprodutobluesoft_pk, 
                        descricao)
                        {
                            var newProdutobluesoft = new Produtobluesoft();
                            newProdutobluesoft.prb_cdprodutobluesoft_pk = cdprodutobluesoft_pk
                            newProdutobluesoft.prb_descricao = descricao 
                            return newProdutobluesoft;
                        }

    _display() {
        console.log(`Código do Produto BlueSoft: ${this.prb_cdprodutobluesoft_pk} Descrição ${this.prb_descricao}`)
    }
}
*/

