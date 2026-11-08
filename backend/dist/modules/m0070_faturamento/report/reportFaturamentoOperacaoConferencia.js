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
class reportFaturamentoStatus {
    static sql(filter) {
        let sql = `	SELECT 		f.datafaturamento 
                ,       f.em_cdempresa 
                ,       em.em_descricao
                ,	    f.op_cdoperacao
                ,       op.op_descricao  
                ,		sum(I.valortotalfaturamentobase) as valortotalfaturamentobase
                ,		sum(i.valortotalsubsidioscorrentes) as valortotalsubsidioscorrentes
                ,		sum(i.valortotalfaturamento) as valortotalfaturamento
                ,		sum(i.valortotaldescontofinanceiro) as valortotaldescontofinanceiro
                ,		sum(i.valortotalsubsidiosaplicados) as valortotalsubsidiosaplicados
                ,		sum(i.valortotalfaturamentoliquido) as valortotalfaturamentoliquido
            FROM 		TBFATURAMENTO 		f
            inner join 	tbfaturamentoorigem o on o.seqfaturamento = f.seqfaturamento
            inner join  tbfaturamentoitens  i on i.seqfaturamentoorigem = o.seqfaturamentoorigem 
            inner join  tboperacao         op on op.op_cdoperacao = f.op_cdoperacao
            inner join  tbempresa          em on em.em_cdempresa = f.em_cdempresa 
            WHERE 		1 = 1
            `;
        if (filter.op_cdoperacao && filter.op_cdoperacao > 0) {
            sql += ` AND f.op_cdoperacao = ${filter.op_cdoperacao}`;
        }
        if (filter.statusfaturamentoFiltrar && filter.statusfaturamentoFiltrar > 0) {
            sql += ` AND f.statusfaturamento = ${filter.statusfaturamentoFiltrar}`;
        }
        if (filter.dataFaturamento_ini) {
            sql += ` AND f.datafaturamento >= '${filter.dataFaturamento_ini}'`;
        }
        if (filter.dataFaturamento_fim) {
            sql += ` AND f.datafaturamento <= '${filter.dataFaturamento_fim}'`;
        }
        sql += `
            group by 	f.datafaturamento 
                ,       f.em_cdempresa 
                ,       em.em_descricao
                ,	    f.op_cdoperacao
                ,       op.op_descricao
        `;
        return sql;
    }
    static get(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                if (!filter.dataFaturamento_ini || !filter.dataFaturamento_fim) {
                    throw new Error('Parâmetros de filtro inválidos. dataFaturamento_ini e dataFaturamento_fim são obrigatórios.');
                }
                result = yield new modelbase_1.clsBase().myDataBase.pag.DataGet(this.sql(filter));
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`reportFaturamentoStatus | get \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportFaturamentoStatus;
