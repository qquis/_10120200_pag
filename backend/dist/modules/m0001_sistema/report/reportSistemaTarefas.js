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
class reportSistemaTarefa {
    static sql(parametros = {}) {
        try {
            return `    SELECT 		ta.sis_ta_seq
                            ,		ta.sis_ta_cd 
                            ,		ta.sis_ta_descricao 
                            ,		ta.sis_ta_tipo_cd 
                            ,		ac.sistemas
                            ,		ac.funcoes
                            ,		ac.acessos
                            ,     tp.sis_ta_tipo_descricao  
                        FROM   		tbsistema_tarefa ta
                        LEFT JOIN	tbsistema_tarefa_tipo tp on tp.sis_ta_tipo_cd = ta.sis_ta_tipo_cd
                        LEFT JOIN   (
                                        select pm.sis_ta_cd
                                            ,	count(distinct(pm.sis_cd)) sistemas 
                                            ,	count(distinct(pm.sis_fc_cd)) funcoes
                                            ,	count(distinct(pm.sis_ac_cd)) acessos
                                        from tbsistema_permissao pm
                                        group by  pm.sis_ta_cd	
                                    ) ac on ac.sis_ta_cd = ta.sis_ta_Cd 
                        WHERE       1= 1

                        ${parametros.sis_ta_cd ? `and ta.sis_ta_cd = ${parametros.sis_ta_cd}` : ''}
                        ${parametros.sis_ta_descricao ? `and UPPER(ta.sis_ta_descricao) like UPPER('%${parametros.sis_ta_descricao}%')` : ''}
                        ${parametros.sis_ta_tipo_descricao ? `and UPPER(tp.sis_ta_tipo_descricao) like UPPER('%${parametros.sis_ta_tipo_descricao}%')` : ''}
        `;
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException(`reportSistemaTarefa`, 'sql', e);
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
                modelbase_1.clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemaTarefa', e);
            }
        });
    }
}
exports.default = reportSistemaTarefa;
