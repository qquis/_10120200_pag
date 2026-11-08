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
const bluesoftApiUrl_1 = __importDefault(require("../../../Apis/bluesoftApi/url/bluesoftApiUrl"));
class FaturamentoForcaVendaItem {
    constructor() {
        this.produtoKey = 0;
    }
}
class FaturamentoForcaVenda {
    constructor() {
        this.pedidoForcaVendaKey = 0;
        this.itens = [];
    }
}
class faturamentoforcavenda {
    static Obter() {
        return __awaiter(this, void 0, void 0, function* () {
            let dados = yield bluesoftApiUrl_1.default.api_get(`https://erp.bluesoft.com.br/oxan/api/forca-de-vendas/pedidos?dataEmissaoInicial=18/01/2024`);
            let dadosResulta = dados.data.data;
            console.log(dadosResulta);
            let resultado = Array.from(dadosResulta).map((item) => {
                return {
                    pedidoForcaVendaKey: item.pedidoForcaVendaKey
                };
            });
            console.log(resultado);
            return [];
        });
    }
}
exports.default = faturamentoforcavenda;
