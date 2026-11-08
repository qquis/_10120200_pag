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
class tbfaturamentoorigem extends modelbase_1.clsBase {
    constructor() {
        super();
        this.seqfaturamento = 0;
        this.seqfaturamentoorigem = 0;
        this.cupomfiscal = 0;
        this.cupomfiscalcancelador = 0;
        this.df_nf_seq_blue = 0;
        this.dtlog_insert = this.__defaultDateNow;
        this.dtlog_update = this.__defaultDateNow;
        this.nfeseq = 0;
        this.numeronfe = 0;
        this.numeronfedevolucao = 0;
        this.numeropedido = 0;
        this.prazopgtomedio = 0;
        this.sat_ecf = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.seqfaturamento = item === null || item === void 0 ? void 0 : item.seqfaturamento;
                this.seqfaturamentoorigem = item === null || item === void 0 ? void 0 : item.seqfaturamentoorigem;
                this.cupomfiscalcancelador = item === null || item === void 0 ? void 0 : item.cupomfiscalcancelador;
                this.cupomfiscal = item === null || item === void 0 ? void 0 : item.cupomfiscal;
                this.df_nf_seq_blue = item === null || item === void 0 ? void 0 : item.df_nf_seq_blue;
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_insert, `YYYY-MM-DD HH:mm:ss`);
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_update, `YYYY-MM-DD HH:mm:ss`);
                this.nfeseq = item === null || item === void 0 ? void 0 : item.nfeseq;
                this.numeronfedevolucao = item === null || item === void 0 ? void 0 : item.numeronfedevolucao;
                this.numeronfe = item === null || item === void 0 ? void 0 : item.numeronfe;
                this.numeropedido = item === null || item === void 0 ? void 0 : item.numeropedido;
                this.prazopgtomedio = item === null || item === void 0 ? void 0 : item.prazopgtomedio;
                this.sat_ecf = item === null || item === void 0 ? void 0 : item.sat_ecf;
            }
        });
    }
}
exports.default = tbfaturamentoorigem;
