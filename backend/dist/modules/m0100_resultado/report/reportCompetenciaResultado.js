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
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const rptEnterpriseCompetenciaListGet_1 = __importDefault(require("../../m0002_enterprise/report/rptEnterpriseCompetenciaListGet"));
class reportCompetenciaResultado {
    static sql(parametros = {}) {
        let sql = `
            select      x.competencia_cd 
                    ,   x.competencia_ano 
                    ,   x.competencia_mes
                    ,   x.competencia_descricao
                    ,   x.competencia_data_ini 
                    ,   x.competencia_data_fim
                    ,   x.competencia_cd_ma 
            FROM       tbcompetencia x       
            
            WHERE 1 = 1 
            ${parametros.fechamento ? `AND x.competencia_cd  in (
                            SELECT a.competencia_cd FROM tbresultado_fechamento a
                )` : ''}
            
            `;
        return sql;
    }
    static get() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            let list = [];
            const myTools = new modelbase_1.clsBase();
            try {
                list = yield rptEnterpriseCompetenciaListGet_1.default.get(parametros, this.sql(parametros));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`reportDRresultado`, 'sql', e);
            }
            finally {
                return list;
            }
        });
    }
}
exports.default = reportCompetenciaResultado;
