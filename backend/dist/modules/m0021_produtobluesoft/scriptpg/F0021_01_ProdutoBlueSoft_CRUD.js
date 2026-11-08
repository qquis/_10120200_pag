"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class F0021_01_ProdutoBlueSoft_CRUD {
    //public static sqlScript_VERSION(): string {return `f0021_01_1012006_produtobluesoft_crud`}
    static sqlScript_VERSION() { return `f0021_01_1012019_produtobluesoft_crud`; }
    static CRUD(item) {
        return `SELECT ${this.sqlScript_VERSION}
                ('DBINSERT_API',
                        ${item.prb_cdprodutobluesoft_pk},
                        ${item.prb_cdprodutobluesoftunitario},
                        '${item.prb_descricao}',
                        '${item.prb_embalagemestoque}',
                        ${item.prb_fatorestoque},
                        '${item.prb_status_embalagemcaixa}',
                        'XX',
                        0.00,
                        '${item.prb_cdbarra_principal}',
                        0,
                        0,
                        ${item.prb_cdsubgrupo},						
                        '${item.prb_dt_cadastro}',
                        '${item.prb_dt_ultimaalteracao}',
                        ${item.prb_cdpessoabluesoft_fabricante},
                        '0',
                        '${item.prb_descricao_fiscal}',
                        0,
                        0,
                        '${item.prb_status}', 
                        0, 
                        '${item.prb_descricao_gondola}', 
                        '${item.prb_descricao_cupom}', 
                        '${item.prb_descricao_balanca}', 
                        0,
                        0,
                        0,
                        0,
                        '${item.prb_blue_fc_cbenef_cd}', 
                        'true'
                            )`;
    }
}
exports.default = F0021_01_ProdutoBlueSoft_CRUD;
