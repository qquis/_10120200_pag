"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const reportZanthusPagamentos_1 = __importDefault(require("./reportZanthusPagamentos"));
const reportZanthusCupom_1 = __importDefault(require("./reportZanthusCupom"));
const reportZanthusCupomItem_1 = __importDefault(require("./reportZanthusCupomItem"));
class reportFaturamentoZanthus {
}
reportFaturamentoZanthus.Cupom = reportZanthusCupom_1.default;
reportFaturamentoZanthus.CupomItem = reportZanthusCupomItem_1.default;
reportFaturamentoZanthus.Pagamento = reportZanthusPagamentos_1.default;
exports.default = reportFaturamentoZanthus;
