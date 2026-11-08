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
class tbresultado_conta extends modelbase_1.clsBase {
    constructor() {
        super();
        this.dtlog_insert = this.__defaultDateNow;
        this.dtlog_update = this.__defaultDateNow;
        this.r_conta_cd = 0;
        this.r_conta_descricao = '';
        this.r_conta_lancamento_manual = 0;
        this.debitocredito = -1;
        this.r_grupo_cd = 0;
        this.r_rateio_cd = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_insert, `YYYY-MM-DD HH:mm:ss`);
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_update, `YYYY-MM-DD HH:mm:ss`);
                this.r_conta_cd = item === null || item === void 0 ? void 0 : item.r_conta_cd;
                this.r_conta_descricao = item === null || item === void 0 ? void 0 : item.r_conta_descricao;
                this.r_conta_lancamento_manual = item === null || item === void 0 ? void 0 : item.r_conta_lancamento_manual;
                this.debitocredito = item === null || item === void 0 ? void 0 : item.debitocredito;
                this.r_grupo_cd = item === null || item === void 0 ? void 0 : item.r_grupo_cd;
                this.r_rateio_cd = item === null || item === void 0 ? void 0 : item.r_rateio_cd;
            }
        });
    }
}
exports.default = tbresultado_conta;
