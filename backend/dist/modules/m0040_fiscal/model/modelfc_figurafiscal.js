"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const tbfc_figurafiscal_1 = __importDefault(require("../tbs/tbfc_figurafiscal"));
class modelfc_figurafiscal extends tbfc_figurafiscal_1.default {
    constructor() {
        super();
    }
    script_insert() {
        let sql = ` insert into tbfc_figurafiscal 
        (
            	fc_figurafiscal_cd 			
            ,   fc_figurafiscal_descricao 	
            ,   fc_figurafiscal_codigo 		
            ,   fc_figurafiscal_base 		
            ,   fc_figurafiscal_versao 		
         )
            SELECT     ${this.fc_figurafiscal_cd}
                    , '${this.fc_figurafiscal_descricao}'
                    , '${this.fc_figurafiscal_codigo}'
                    ,  ${this.fc_figurafiscal_base}
                    ,  ${this.fc_figurafiscal_versao}
            
            WHERE NOT EXISTS (SELECT 1 FROM tbfc_figurafiscal WHERE fc_figurafiscal_cd = ${this.fc_figurafiscal_cd})
            ;

            UPDATE tbfc_figurafiscal
             SET   fc_figurafiscal_descricao = '${this.fc_figurafiscal_descricao}'
                , fc_figurafiscal_codigo = '${this.fc_figurafiscal_codigo}'
                , fc_figurafiscal_base =  ${this.fc_figurafiscal_base}
                , fc_figurafiscal_versao =  ${this.fc_figurafiscal_versao}
                , dtlog_update = current_timestamp
            WHERE fc_figurafiscal_cd = ${this.fc_figurafiscal_cd}
            ;

            `;
        return sql;
    }
    bindingApiBluesoft(item) {
        if (item) {
            this.fc_figurafiscal_cd = item.codigoFiguraFiscal ? item.codigoFiguraFiscal : 0;
            this.fc_figurafiscal_codigo = item.codigo ? modelbase_1.clsTools.stringToDabase(item.codigo) : 'SEM CODIGO';
            this.fc_figurafiscal_descricao = item.descricao ? modelbase_1.clsTools.stringToDabase(item.descricao) : 'SEM DESCRICAO';
            this.fc_figurafiscal_base = item.base ? item.base : 0;
            this.fc_figurafiscal_versao = item.versao ? item.versao : 0;
        }
    }
}
exports.default = modelfc_figurafiscal;
