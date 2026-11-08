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
class reportPermissaolist {
    static sql(parametros = {}) {
        try {
            let sql = `   SELECT 	pm.sis_cd 
                            ,	s.sis_descricao
                            ,	pm.sis_fc_cd 
                            ,	f.sis_fc_descricao 
                            ,	pm.sis_ac_cd
                            ,	a.sis_ac_descricao 
                            ,	pm.sis_ta_cd 
                            ,	t.sis_ta_descricao 
                        FROM 		TBSISTEMA_PERMISSAO pm 
                        LEFT JOIN   tbsistema s on s.sis_cd_pk = pm.sis_cd 
                        LEFT JOIN   tbsistema_funcao f on f.sis_fc_cd = pm.sis_fc_cd 
                        LEFT JOIN   tbsistema_acesso a on a.sis_ac_cd = pm.sis_ac_cd 
                        LEFT JOIN   tbsistema_tarefa t on t.sis_ta_cd = pm.sis_ta_cd 
                        WHERE 1 = 1
                        ${parametros.sis_cd && parametros.sis_cd !== '0' ? `and pm.sis_cd = ${parametros.sis_cd}` : ''}
                        ${parametros.sis_fc_cd ? `and pm.sis_fc_cd = ${parametros.sis_fc_cd}` : ''}
                        ${parametros.sis_ac_cd ? `and pm.sis_ac_cd = ${parametros.sis_ac_cd}` : ''}                                
                        ${parametros.sis_ta_cd ? `and pm.sis_ta_cd = ${parametros.sis_ta_cd}` : ''}

        `;
            return sql;
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException(`reportPermissaolist`, 'sql', e);
            return '';
        }
    }
    static get() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            const myTools = new modelbase_1.clsBase();
            try {
                let result = yield myTools.myDataBase.pag.DataGet(this.sql(parametros));
                return result; //await myTools.myDataBase.pag.DataGet(this.sql(parametros));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemalist', e);
            }
        });
    }
}
exports.default = reportPermissaolist;
