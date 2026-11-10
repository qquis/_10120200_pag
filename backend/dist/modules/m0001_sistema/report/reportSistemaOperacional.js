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
class reportSistemaOperacional {
    static sql(parametros = {}) {
        try {
            let sql = `   SELECT 		
                                us.sis_operacional_cd 
                            ,   us.sis_operacional_default 
                            ,   us.data_processamento_venda_ini 
                            ,   us.data_processamento_venda_fim 
                            ,   us.competencia_cd 
                            ,   us.fv_fab_meta_cd 
                            ,   us.faturamento_numero_dias_qtde
                            ,   us.faturamento_data_limite
                            ,   c.competencia_data_ini
                            ,   c.competencia_data_fim                            
                FROM 		tbsistema_operacional us
                INNER JOIN  tbcompetencia c on c.competencia_cd = us.competencia_cd
                WHERE 1=1
        `;
            if (parametros.sis_operacional_default) {
                sql += ` AND us.sis_operacional_default = '${parametros.sis_operacional_default}' `;
            }
            return sql;
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException(`reportSistemaOperacional`, 'sql', e);
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
                yield modelbase_1.clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemaOperacional.get', e);
            }
        });
    }
    static getDefault() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const myTools = new modelbase_1.clsBase();
                let result = yield this.get({ sis_operacional_default: 1 });
                let item = yield myTools.myDataBase.RecordItem(result, 0);
                let dados = {
                    sis_operacional_cd: item.sis_operacional_cd,
                    sis_operacional_default: item.sis_operacional_default,
                    data_processamento_venda_ini: modelbase_1.clsTools._datemomentDateToStr(modelbase_1.clsTools._datemomentDatStrToDate(item.data_processamento_venda_ini, "YYYY-MM-DD HH:mm:ss"), "YYYY-MM-DD"),
                    data_processamento_venda_fim: modelbase_1.clsTools._datemomentDateToStr(modelbase_1.clsTools._datemomentDatStrToDate(item.data_processamento_venda_fim, "YYYY-MM-DD HH:mm:ss"), "YYYY-MM-DD"),
                    competencia_cd: item.competencia_cd,
                    fv_fab_meta_cd: item.fv_fab_meta_cd,
                    faturamento_numero_dias_qtde: item.faturamento_numero_dias_qtde,
                    faturamento_data_limite: modelbase_1.clsTools._datemomentDateToStr(modelbase_1.clsTools._datemomentDatStrToDate(item.faturamento_data_limite, "YYYY-MM-DD HH:mm:ss"), "YYYY-MM-DD"),
                    data_competencia_ini: modelbase_1.clsTools._datemomentDateToStr(modelbase_1.clsTools._datemomentDatStrToDate(item.competencia_data_ini, "YYYY-MM-DD HH:mm:ss"), "YYYY-MM-DD"),
                    data_competencia_fim: modelbase_1.clsTools._datemomentDateToStr(modelbase_1.clsTools._datemomentDatStrToDate(item.competencia_data_fim, "YYYY-MM-DD HH:mm:ss"), "YYYY-MM-DD")
                };
                return dados;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemaOperacional.getDefault', e);
            }
        });
    }
}
exports.default = reportSistemaOperacional;
