"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbfc_cofins_1 = __importDefault(require("../tbs/tbfc_cofins"));
class modelfc_cofins extends tbfc_cofins_1.default {
    constructor() {
        super();
    }
    script_insert() {
        let sql = ``;
        if (this.cofins_cd > 0) {
            sql = `insert into tbfc_cofins 
            (
                    cofins_cd 			
                ,   cofins_descricao 
                ,   cst 		
                ,   cofinsAliquota 		
                ,   cofinsReducao 	
                ,   pisrelacionado    
                ,   tipo_entrada	
            )
                SELECT   ${this.cofins_cd}
                        , '${this.cofins_descricao}'
                        ,  ${this.cst}
                        ,  ${this.cofinsAliquota}
                        ,  ${this.cofinsReducao}
                        ,  ${this.pisrelacionado}
                        ,  ${this.tipo_entrada}

                
                WHERE NOT EXISTS (SELECT 1 FROM tbfc_cofins WHERE cofins_cd = ${this.cofins_cd})
                ;

                UPDATE tbfc_cofins
                SET   cofins_descricao = '${this.cofins_descricao}'
                    , cst = ${this.cst}
                    , cofinsAliquota = ${this.cofinsAliquota}
                    , cofinsReducao = ${this.cofinsReducao}
                    , pisrelacionado = ${this.pisrelacionado}
                    , tipo_entrada = ${this.tipo_entrada}
                    , dtlog_update = current_timestamp
                WHERE cofins_cd = ${this.cofins_cd}
                ;

                `;
        }
        return sql;
    }
    bindingApiBluesoft_urlFiscalCofins(item) {
        if (item) {
            this.cofins_cd = item.codigo ? item.codigo : 0;
            this.cofins_descricao = item.descricao ? item.descricao : '';
            this.cst = item.cst ? item.cst : 0;
            this.cofinsAliquota = item.aliquota && item.aliquota != undefined ? item.aliquota : 0;
            this.pisrelacionado = item.pisRelacionado ? item.pisRelacionado : 0;
        }
    }
}
exports.default = modelfc_cofins;
