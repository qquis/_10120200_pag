import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'

export default class tbintegracao_produto extends modelTb  {
    integracao_produto_seq: number 
    integracao_tipo_cd: number 
    integracao_tipo_descricao: string
    integracao_status_cd: number 
    pr_cdproduto: number
    prb_cdprodutobluesoftunitario: number 
    prb_cdprodutobluesoft: number 

    constructor () {
        super()
        this.integracao_produto_seq = 0;
        this.integracao_tipo_cd = 0; 
        this.integracao_tipo_descricao = `` 
        this.pr_cdproduto = 0; 
        this.prb_cdprodutobluesoftunitario = 0; 
        this.prb_cdprodutobluesoft = 0; 
        this.integracao_status_cd = 0;
        
    }

    _Db_Pg_script_Update(): string {
        let sql = `UPDATE tbintegracao_produto 
                   set    integracao_status_cd = ${this.integracao_status_cd}
                       ,  dtlog_update = current_timestamp
                   where  integracao_produto_seq = ${this.integracao_produto_seq}
                  ;
                ` 
        return sql; 
    }
}