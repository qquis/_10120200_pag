import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'

export default class tbprecoaplicacao extends modelTb  {
    preco_aplicacao_seq: number 
    preco_aplicacao_data: Date 
    tab_pre_cd: number
    pr_cdproduto: number
    pr_embalagemestoque: string 
    prc_valor_embalagemestoque: number 
    pre_fatorestoque: number 
    prb_cdprodutobluesoft: number 
    pre_embalagem: string
    prc_valor: number 
    preco_aplicacao_agendamento: boolean
    prca_seq: number 
    prc_qtde_promocional: number 
    prc_valor_promocional: number 
    prb_cdprodutobluesoft_unitario: number  


    constructor (prb_cdprodutobluesoft: number) {
        super()


        this.prb_cdprodutobluesoft = prb_cdprodutobluesoft; 
        this.preco_aplicacao_seq = 0;
        this.preco_aplicacao_data = this.__defaultDateNow; 
        this.tab_pre_cd= 0
        this.pr_cdproduto = 0
        this.pr_embalagemestoque = 'UN'
        this.prc_valor_embalagemestoque = 0;
        this.pre_fatorestoque = 1
        this.pre_embalagem = 'UN'; 
        this.prc_valor = 0; 
        this.preco_aplicacao_agendamento = false; 
        this.prca_seq = 0; 
        this.prc_qtde_promocional = 0 ;
        this.prc_valor_promocional = 0;
        this.prb_cdprodutobluesoft_unitario = 0;
        
    }

    async binding(item: any) {
        if (item != undefined) {

           

            this.prb_cdprodutobluesoft = item.prb_cdprodutobluesoft? item.prb_cdprodutobluesoft: 0 
            this.preco_aplicacao_seq = item.preco_aplicacao_seq? parseInt(item.preco_aplicacao_seq): 0 
            this.preco_aplicacao_data = myTools.pagDateTime_getDate(item.preco_aplicacao_data?item.preco_aplicacao_data:this.__defaultDateNow)
            this.tab_pre_cd= item.tab_pre_cd? parseInt(item.tab_pre_cd): 0 
            this.pr_cdproduto = item.pr_cdproduto? parseInt(item.pr_cdproduto): 0
            this.pr_embalagemestoque = item.pr_embalagemestoque? item.pr_embalagemestoque :  'UN'
            this.prc_valor_embalagemestoque = item.prc_valor_embalagemestoque? parseFloat(item.prc_valor_embalagemestoque): 0 ;
            this.pre_fatorestoque = item.pre_fatorestoque? item.pre_fatorestoque: 1 
            this.pre_embalagem = item.pre_embalagem? item.pre_embalagem: `UN`; 
            this.prc_valor = item.prc_valor? parseFloat(item.prc_valor) : 0 ; 
            this.preco_aplicacao_agendamento = item.preco_aplicacao_agendamento? item.preco_aplicacao_agendamento : false; 
            this.prca_seq = item.prca_seq? item.prca_seq: 0 ; 
            this.prc_qtde_promocional = item.prc_qtde_promocional? parseFloat(item.prc_qtde_promocional) : 0 ;
            this.prc_valor_promocional = item.prc_valor_promocional? parseFloat(item.prc_valor_promocional): 0 ;
            this.prb_cdprodutobluesoft_unitario = item.prb_cdprodutobluesoft_unitario? item.prb_cdprodutobluesoft_unitario : 0 ;
        }    
    }

}