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
const serviceAutorizacaoPgto_1 = __importDefault(require("./serviceAutorizacaoPgto"));
const serviceMovimentoCaixaBluesoft_1 = __importDefault(require("./serviceMovimentoCaixaBluesoft"));
const modelsistema_nucleo_procedimento_1 = __importDefault(require("../../../modules/m9030_sistema_batch/model/modelsistema_nucleo_procedimento"));
const service_Financeiro_FormaPgto_1 = __importDefault(require("./service.Financeiro.FormaPgto"));
class serviceFinanceiro {
    static AutorizacaoPgtoAtualizar() {
        return __awaiter(this, void 0, void 0, function* () {
            return yield serviceAutorizacaoPgto_1.default.Atualizar(0);
        });
    }
    static AutorizacaoPgtoAtualizarDuplicata(param) {
        return __awaiter(this, void 0, void 0, function* () {
            return yield serviceAutorizacaoPgto_1.default.AtualizarDuplicata(param);
        });
    }
    static MovimentoCaixaBluesoftAtualizar() {
        return __awaiter(this, void 0, void 0, function* () {
            let nucleo_procedimento = new modelsistema_nucleo_procedimento_1.default();
            nucleo_procedimento.sis_nucleo_prc_cd = 8002;
            return yield serviceMovimentoCaixaBluesoft_1.default.start(nucleo_procedimento);
        });
    }
}
serviceFinanceiro.FinanceiroFormaPgto = service_Financeiro_FormaPgto_1.default;
exports.default = serviceFinanceiro;
