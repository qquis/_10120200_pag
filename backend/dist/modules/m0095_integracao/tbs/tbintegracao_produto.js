"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const model_1 = require("../../../model/model");
class tbintegracao_produto extends model_1.modelTb {
    constructor() {
        super();
        this.integracao_produto_seq = 0;
        this.integracao_tipo_cd = 0;
        this.integracao_tipo_descricao = ``;
        this.pr_cdproduto = 0;
        this.prb_cdprodutobluesoftunitario = 0;
        this.prb_cdprodutobluesoft = 0;
        this.integracao_status_cd = 0;
    }
    _Db_Pg_script_Update() {
        let sql = `UPDATE tbintegracao_produto 
                   set    integracao_status_cd = ${this.integracao_status_cd}
                       ,  dtlog_update = current_timestamp
                   where  integracao_produto_seq = ${this.integracao_produto_seq}
                  ;
                `;
        return sql;
    }
}
exports.default = tbintegracao_produto;
