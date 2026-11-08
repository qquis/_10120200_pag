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
class reportFaturamentoContrato {
    static sql(parametro) {
        let sql = `	select f.contrato_seq
                ,  f.contrato_descricao 
                ,  t.contrato_tipo_descricao 
                ,  f.contrato_data
                ,  f.contrato_tipo_cd
                ,  f.contrato_data_val_ini
                ,  f.contrato_data_val_fim
                ,  f.op_cdoperacao
                ,  f.cdparticipante_contratante
                ,  f.seqfaturamento
                ,  f.seqfaturamentoorigem
                ,  f.faturamento_controle_seq
                ,  f.contrato_valor
                ,  f.contrato_uuid
                ,  l.numeropedido_fv
                ,  l.numeropedido
                ,  l.numeronfe
                ,  f.contrato_status
            from   tbfaturamentocontrato f
            left join tbfaturamentocontrato_tipo t on t.contrato_tipo_cd = f.contrato_tipo_cd
            left join tbfaturamento_controle l 
                    on l.faturamento_controle_seq = f.faturamento_controle_seq
            where 1 = 1
        `;
        if (parametro.competencia_cd) {
            sql += ` and f.competencia_cd = ${parametro.competencia_cd}`;
        }
        if (parametro.contrato_status && parseInt(parametro.contrato_status) !== 9) {
            sql += ` and f.contrato_status = ${parametro.contrato_status}`;
        }
        if (parametro.contrato_seq) {
            sql += ` and f.contrato_seq = ${parametro.contrato_seq}`;
        }
        if (parametro.contrato_data_val_ini) {
            sql += ` and f.contrato_data_val_ini >= '${parametro.contrato_data_val_ini}'
                     and f.contrato_data_val_ini <= '${parametro.contrato_data_val_fim}'
            
            `;
        }
        if (parametro.contrato_data_val_fim) {
            sql += ` and f.contrato_data_val_fim >= '${parametro.contrato_data_val_ini}'
                     and f.contrato_data_val_fim <= '${parametro.contrato_data_val_fim}'
            
            `;
        }
        if (parametro.contrato_tipo_cd && parseInt(parametro.contrato_tipo_cd) !== 0) {
            sql += ` and f.contrato_tipo_cd = ${parametro.contrato_tipo_cd}`;
        }
        return sql;
    }
    static get(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
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
exports.default = reportFaturamentoContrato;
