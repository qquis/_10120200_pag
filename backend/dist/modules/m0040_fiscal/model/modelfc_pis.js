"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbfc_pis_1 = __importDefault(require("../tbs/tbfc_pis"));
class modelfc_pis extends tbfc_pis_1.default {
    constructor() {
        super();
    }
    script_insert() {
        let sql = ``;
        if (this.pis_cd > 0) {
            sql = `insert into tbfc_pis 
            (
                    pis_cd 			
                ,   cst
                ,   pis_descricao 		
                ,   pisAliquota 		
                ,   pisReducao 	
                ,   cofinsrelacionado	
                ,   tipo_entrada
            )
                SELECT   ${this.pis_cd}
                        ,  ${this.cst}
                        ,  '${this.pis_descricao}'
                        ,  ${this.pisAliquota}
                        ,  ${this.pisReducao}
                        ,  ${this.cofinsRelacionado}
                        ,  ${this.tipo_entrada}

                
                WHERE NOT EXISTS (SELECT 1 FROM tbfc_pis WHERE pis_cd = ${this.pis_cd})
                ;

                UPDATE tbfc_pis
                SET   cst = ${this.cst}
                    , pisAliquota = ${this.pisAliquota}
                    , pisReducao = ${this.pisReducao}
                    , pis_descricao = '${this.pis_descricao}'
                    , cofinsRelacionado = ${this.cofinsRelacionado} 
                    , dtlog_update = current_timestamp
                    , tipo_entrada = ${this.tipo_entrada}
                WHERE pis_cd = ${this.pis_cd}
                ;

                `;
        }
        return sql;
    }
    bindingApiBluesoft_urlFiscalPis(item) {
        if (item) {
            this.pis_cd = item.codigo ? item.codigo : 0;
            this.pis_descricao = item.descricao ? item.descricao : '';
            this.cst = item.cst ? item.cst : 0;
            this.pisAliquota = item.aliquota && item.aliquota != undefined ? item.aliquota : 0;
            this.cofinsRelacionado = item.cofinsRelacionado ? item.cofinsRelacionado : 0;
        }
    }
}
exports.default = modelfc_pis;
