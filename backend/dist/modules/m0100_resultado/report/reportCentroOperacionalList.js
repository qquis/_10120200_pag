"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class reportCentroOperacionalList {
    static sql(parametros = {}) {
        try {
            let sql = `
                            select 		co.op_cdoperacao 
                    ,		op.op_descricao 
                    ,		co.r_centro_op_cd
                    ,		co.r_centro_op_descricao
                    ,		co.r_resp_Cd 
                    ,		rs.r_resp_descricao 
                from 		tbresultado_centro_operacional co
                inner join  tboperacao op on op.op_cdoperacao = co.op_cdoperacao 
                inner join  tbresultado_resp rs on rs.r_resp_cd = co.r_resp_cd 
                where 		1 = 1 
                union 
                    select 0        as op_cdoperacao
                        , 'Todos'   as op_descricao
                        , 0         as r_centro_op_cd
                        , 'Todos'   as r_centro_op_descricao
                        , 0         as r_resp_cd
                        , 'Todos' as r_resp_descricao
                order by 	3
                        asc
            `;
            return sql;
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException(`reportDREFechamento`, 'sql', e);
            return '';
        }
    }
    static get() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            const myTools = new modelbase_1.clsBase();
            try {
                return yield myTools.myDataBase.pag.DataGet(this.sql(parametros));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`reportDREFechamento`, 'sql', e);
            }
        });
    }
}
exports.default = reportCentroOperacionalList;
