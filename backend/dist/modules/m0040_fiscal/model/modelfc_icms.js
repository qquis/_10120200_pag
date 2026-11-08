"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const tbfc_icms_1 = __importDefault(require("../tbs/tbfc_icms"));
class modelfc_icms extends tbfc_icms_1.default {
    constructor() {
        super();
    }
    script_insert() {
        let sql = ``;
        if (this.icms_cd > 0) {
            sql = `insert into tbfc_icms 
            (
                    icms_cd 			
                ,   icms_descricao 	
                ,   codigoOrigem 		
                ,   codigoTributacao 		
                ,   sigla 		
                ,   aliquota 		
                ,   reducao 		
                ,   porcentagemDiferimento 		
            )
                SELECT   ${this.icms_cd}
                        , '${this.icms_descricao}'
                        ,  ${this.codigoOrigem}
                        ,  ${this.codigoTributacao}
                        , '${this.sigla}'
                        ,  ${this.aliquota}
                        ,  ${this.reducao}
                        ,  ${this.porcentagemDiferimento}
                
                WHERE NOT EXISTS (SELECT 1 FROM tbfc_icms WHERE icms_cd = ${this.icms_cd})
                ;

                UPDATE tbfc_icms
                SET   icms_descricao = '${this.icms_descricao}'
                    , codigoOrigem = ${this.codigoOrigem}
                    , codigoTributacao = ${this.codigoTributacao}
                    , sigla = '${this.sigla}'
                    , aliquota = ${this.aliquota}
                    , reducao = ${this.reducao}
                    , porcentagemDiferimento = ${this.porcentagemDiferimento}
                    , dtlog_update = current_timestamp
                WHERE icms_cd = ${this.icms_cd}
                ;

                `;
        }
        return sql;
    }
    bindingApiBluesoft(item) {
        if (item) {
            this.icms_cd = item.codigo ? item.codigo : 0;
            this.codigoOrigem = item.codigoOrigem ? item.codigoOrigem : 0;
            this.codigoTributacao = item.codigoTributacao ? item.codigoTributacao : 0;
            this.icms_descricao = item.descricao ? modelbase_1.clsTools.stringToDabase(item.descricao) : 'SEM DESCRICAO';
            this.sigla = item.sigla ? modelbase_1.clsTools.stringToDabase(item.sigla) : 'SEM SIGLA';
            this.aliquota = item.aliquota ? item.aliquota : 0;
            this.reducao = item.reducao ? item.reducao : 0;
            this.porcentagemDiferimento = item.porcentagemDiferimento ? item.porcentagemDiferimento : 0;
        }
    }
}
exports.default = modelfc_icms;
