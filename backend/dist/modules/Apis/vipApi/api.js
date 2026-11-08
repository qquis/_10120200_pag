"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const clientes_1 = __importDefault(require("./clientes"));
const faturamento_1 = __importDefault(require("./faturamento"));
class apiVip {
}
apiVip.clientes = clientes_1.default;
apiVip.faturamentoPedido = faturamento_1.default;
exports.default = apiVip;
