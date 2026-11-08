"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const tbforca_venda_prazopgto_1 = __importDefault(require("../tbs/tbforca_venda_prazopgto"));
class modelforca_venda_pgtos extends tbforca_venda_prazopgto_1.default {
    constructor() {
        super();
    }
    apiBluesoftGet(item) {
        try {
            this.fv_prazopgto_cd = item === null || item === void 0 ? void 0 : item.prazoPagamentoFvKey;
            this.fv_prazopgto_descricao = item === null || item === void 0 ? void 0 : item.descricao;
            this.custofinanceiro = item === null || item === void 0 ? void 0 : item.custoFinanceiro;
            this.coefcustofinanceiro = item === null || item === void 0 ? void 0 : item.coefCustoFinanceiro;
            this.tipo = item === null || item === void 0 ? void 0 : item.tipo;
            this.tipocusto = item === null || item === void 0 ? void 0 : item.tipoCusto;
            this.status = (item === null || item === void 0 ? void 0 : item.status) ? 1 : 0;
            this.versao = item === null || item === void 0 ? void 0 : item.versao;
        }
        catch (e) {
            modelbase_1.clsTools.pagConsole(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | apiBluesoftGet | Error \n ${e}`, false, false, 'modelforca_venda_pgtos');
            throw new Error(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | apiBluesoftGet | Error ${e}`);
        }
    }
    sqlPrimeInsert() {
        let sql = ``;
        try {
            sql = `insert into tbforca_venda_prazopgto (fv_prazopgto_cd, fv_prazopgto_descricao, custofinanceiro, coefcustofinanceiro, tipo, tipocusto, status, versao) 
            select  ${this.fv_prazopgto_cd}
                 , '${this.fv_prazopgto_descricao}'
                 ,  ${this.custofinanceiro}
                 ,  ${this.coefcustofinanceiro}
                 , '${this.tipo}'
                 , '${this.tipocusto}'
                 ,  ${this.status}
                 ,  ${this.versao}
            
                 where not exists (select 1 from tbforca_venda_prazopgto where fv_prazopgto_cd = ${this.fv_prazopgto_cd})

                 ;

                 update tbforca_venda_prazopgto set
                    fv_prazopgto_descricao = '${this.fv_prazopgto_descricao}'
                    , custofinanceiro = ${this.custofinanceiro}
                    , coefcustofinanceiro = ${this.coefcustofinanceiro}
                    , tipo = '${this.tipo}'
                    , tipocusto = '${this.tipocusto}'
                    , status = ${this.status}
                    , versao = ${this.versao}

                where fv_prazopgto_cd = ${this.fv_prazopgto_cd}
            ;
                 
            `;
        }
        catch (e) {
            modelbase_1.clsTools.pagConsole(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | sqlPrimeInsert | Error \n ${e}`, false, false, 'modelforca_venda_pgtos');
            throw new Error(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | sqlPrimeInsert | Error ${e}`);
        }
        finally {
            return sql;
        }
    }
}
exports.default = modelforca_venda_pgtos;
