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
const reportAutorizacaoPgtoPag_1 = __importDefault(require("./reportAutorizacaoPgtoPag"));
const reportAutorizacaoPgto_1 = __importDefault(require("./reportAutorizacaoPgto"));
const reportFluxoCaixa_1 = __importDefault(require("./reportFluxoCaixa"));
const report_Financeiro_FormaPgtoBluesoft_1 = __importDefault(require("./report.Financeiro.FormaPgtoBluesoft"));
class reportFinanceiro {
    static autorizacaoPgtoPagGet(parms) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield reportAutorizacaoPgtoPag_1.default.get(parms);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("M0080", "autorizacaoPgtoPagGet", e);
            }
        });
    }
    static autorizacaoPgtoGet(parms) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield reportAutorizacaoPgto_1.default.get(parms);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("M0080", "autorizacaoPgtoGet", e);
            }
        });
    }
    static fluxoCaixaGet(parms) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield reportFluxoCaixa_1.default.get(parms);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("M0080", "FluxoCaixaGet", e);
            }
        });
    }
}
reportFinanceiro.formaPgtoBlueSoft = report_Financeiro_FormaPgtoBluesoft_1.default;
exports.default = reportFinanceiro;
