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
class tbfaturamentoitens extends modelbase_1.clsBase {
    constructor() {
        super();
        this.dtlog_insert = this.__defaultDateNow;
        this.dtlog_update = this.__defaultDateNow;
        this.ec_valorcusto_faturamento_total = 0;
        this.ec_valorcusto_precificacao_total = 0;
        this.embalagemcompraqtde = 0;
        this.embalagemestoqueqtde = 0;
        this.pr_cdproduto = 0;
        this.seqfaturamentoorigem = 0;
        this.seqitem = 0;
        this.statusfaturamentoitem = 0;
        this.valortotaldescontofinanceiro = 0;
        this.valortotalfaturamento = 0;
        this.valortotalfaturamentobase = 0;
        this.valortotalfaturamentobruto = 0;
        this.valortotalfaturamentoliquido = 0;
        this.valortotalsubsidiosaplicados = 0;
        this.valortotalsubsidioscorrentes = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_insert, `YYYY-MM-DD HH:mm:ss`);
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_update, `YYYY-MM-DD HH:mm:ss`);
                this.ec_valorcusto_faturamento_total = item === null || item === void 0 ? void 0 : item.ec_valorcusto_faturamento_total;
                this.ec_valorcusto_precificacao_total = item === null || item === void 0 ? void 0 : item.ec_valorcusto_precificacao_total;
                this.embalagemcompraqtde = item === null || item === void 0 ? void 0 : item.embalagemcompraqtde;
                this.embalagemestoqueqtde = item === null || item === void 0 ? void 0 : item.embalagemestoqueqtde;
                this.pr_cdproduto = item === null || item === void 0 ? void 0 : item.pr_cdproduto;
                this.seqfaturamentoorigem = item === null || item === void 0 ? void 0 : item.seqfaturamentoorigem;
                this.seqitem = item === null || item === void 0 ? void 0 : item.seqitem;
                this.statusfaturamentoitem = item === null || item === void 0 ? void 0 : item.statusfaturamentoitem;
                this.valortotaldescontofinanceiro = item === null || item === void 0 ? void 0 : item.valortotaldescontofinanceiro;
                this.valortotalfaturamentobase = item === null || item === void 0 ? void 0 : item.valortotalfaturamentobase;
                this.valortotalfaturamentobruto = item === null || item === void 0 ? void 0 : item.valortotalfaturamentobruto;
                this.valortotalfaturamento = item === null || item === void 0 ? void 0 : item.valortotalfaturamento;
                this.valortotalfaturamentoliquido = item === null || item === void 0 ? void 0 : item.valortotalfaturamentoliquido;
                this.valortotalsubsidiosaplicados = item === null || item === void 0 ? void 0 : item.valortotalsubsidiosaplicados;
                this.valortotalsubsidioscorrentes = item === null || item === void 0 ? void 0 : item.valortotalsubsidioscorrentes;
            }
        });
    }
}
exports.default = tbfaturamentoitens;
