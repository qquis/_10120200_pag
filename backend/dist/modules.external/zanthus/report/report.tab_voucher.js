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
class reportExternalZanthusVoucher {
    static sql(parametro) {
        let sql = ``;
        try {
            sql = `
            select a.cod_voucher 
                ,  a.descricao_parceiro 
                ,  a.validade_inicial
                ,  a.validade_final
                ,  a.dth_inclusao 
                ,  a.dth_alteracao 
                ,  i.qtde as qtde_itens
            from   tab_voucher_promocional a 
            left join (  select cod_voucher
                                , count(distinct(cod_produto)) as qtde 
                        from tab_voucher_promocional_prod 
                        group by cod_voucher 
                        ) i on i.cod_voucher = a.cod_voucher 
            WHERE 1 = 1
            `;
            if (parametro.cod_voucher && parametro.cod_voucher !== "") {
                sql += ` AND a.cod_voucher = '${parametro.cod_voucher}' `;
            }
            if (parametro.descricao_parceiro && parametro.descricao_parceiro !== "") {
                sql += ` AND a.descricao_parceiro LIKE '%${parametro.descricao_parceiro}%' `;
            }
            if (parametro.validade_inicial && parametro.validade_inicial !== "") {
                sql += ` AND a.validade_inicial >= '${parametro.validade_inicial}' `;
            }
            if (parametro.validade_final && parametro.validade_final !== "") {
                sql += ` AND a.validade_final <= '${parametro.validade_final}' `;
            }
            if (parametro.voucheratual && parametro.voucheratual !== "") {
                let data_hoje = new Date();
                let cod_voucher = modelbase_1.clsTools._datemomentDateToStr(data_hoje, "YYYYMMDD");
                sql += ` AND a.cod_voucher = '${cod_voucher}' `;
            }
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException("External.Zanthus", "reportExternalZanthusVoucher - sql", e);
        }
        finally {
            return sql;
        }
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let mylist = [];
            try {
                let myBase = new modelbase_1.clsBase();
                mylist = yield myBase.myDataBase.zanthusPostgre.DataGet(this.sql(parametro));
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("External.Zanthus", "reportExternalZanthusVoucher - get", e);
            }
            finally {
                return mylist;
            }
        });
    }
}
exports.default = reportExternalZanthusVoucher;
