"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbfaturamento_controle_1 = __importDefault(require("../tbs/tbfaturamento_controle"));
/*scripts*/
const pg_f0070_23_faturamentoitem_processar_1 = __importDefault(require("../scriptdb/pg.f0070_23_faturamentoitem_processar"));
const pg_f0070_24_faturamentoitem_rateiocomplemento_1 = __importDefault(require("../scriptdb/pg.f0070_24_faturamentoitem_rateiocomplemento"));
const pg_f0070_26_faturamento_recusa_processar_1 = __importDefault(require("../scriptdb/pg.f0070_26_faturamento_recusa_processar"));
class model_faturamento extends tbfaturamento_controle_1.default {
    constructor() {
        super();
    }
    sqlProcessarFaturamentoPorControle(parametro) {
        let sql = ` `;
        sql += pg_f0070_23_faturamentoitem_processar_1.default.get(this);
        if (this.op_cdoperacao == 4) {
            sql += pg_f0070_24_faturamentoitem_rateiocomplemento_1.default.get(this);
        }
        if (this.fat_controle_tipo_cd == 2) {
            sql += pg_f0070_26_faturamento_recusa_processar_1.default.get(this);
        }
        sql += " update tbfaturamento_controle set processamento_pendente = 0 where faturamento_controle_seq = " + this.faturamento_controle_seq + "; ";
        return sql;
    }
}
exports.default = model_faturamento;
