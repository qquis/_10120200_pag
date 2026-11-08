import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'

export default class tbpreco_agendamento extends modelTb {
    prca_seq : number 
    prca_dt_aplicacao : Date 
    pr_cdproduto: number 
    prb_cdprodutobluesoft : number 
    tab_pre_cd: number 
    prc_valor: number 
    prc_qtde_promocional : number 
    prc_valor_promocional : number 
    prc_valor_embalagemestoque : number 
    prc_aplicacao_definitiva: number 

    constructor() {
        super()
        this.prca_seq = 0 ; 
        this.prca_dt_aplicacao = this.__defaultDateNow;
        this.pr_cdproduto =  0
        this.prb_cdprodutobluesoft = 0 
        this.tab_pre_cd = 0 
        this.prc_valor = 0 
        this.prc_qtde_promocional = 0 
        this.prc_valor_promocional = 0 
        this.prc_valor_embalagemestoque = 0 
        this.prc_aplicacao_definitiva= 0        

    }

    async binding(item: any) {
        if (item != undefined) {
            this.prca_seq = item.prca_seq? item.prca_seq : 0  ; 
            this.prca_dt_aplicacao = item.prca_dt_aplicacao? this.__defaultDateNow : item.prca_dt_aplicacao;
            this.pr_cdproduto =  item.pr_cdproduto? item.pr_cdproduto : 0;
            this.prb_cdprodutobluesoft = item.prb_cdprodutobluesoft? item.prb_cdprodutobluesoft : 0;
            this.tab_pre_cd = item.tab_pre_cd? item.tab_pre_cd : 0;
            this.prc_valor = item.prc_valor? item.prc_valor : 0;
            this.prc_qtde_promocional = item.prc_qtde_promocional? item.prc_qtde_promocional : 0
            this.prc_valor_promocional = item.prc_valor_promocional? item.prc_valor_promocional : 0
            this.prc_valor_embalagemestoque = item.prc_valor_embalagemestoque? item.prc_valor_embalagemestoque : 0;
            this.prc_aplicacao_definitiva = item.prc_aplicacao_definitiva? item.prc_aplicacao_definitiva : 0;
        }
    }
}