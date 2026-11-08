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
const myClsBase = new modelbase_1.clsBase();
class apiFaturamentoBluesoft {
    static obterPedidosBluesoft(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                if (parametro.numeropedido_fv && parametro.numeropedido_fv != "") {
                    result = yield myClsBase.blueSoftApi.api_get(`forca-de-vendas/pedidos/${parametro.numeropedido_fv}`);
                }
                else {
                    console.log("consultou pela data");
                    result = yield myClsBase.blueSoftApi.api_get(`forca-de-vendas/pedidos?dataEmissaoInicial=01/02/2026 00:01&dataEmissaoFinal=02/02/2026 23:59`);
                }
                console.log(result.data.data.length);
                for (let pedido of result.data.data) {
                    if (pedido.pedidoForcaVendaKey == 329846) {
                        console.log(`Numero do pedido ${pedido.pedidoForcaVendaKey}`);
                        console.log(pedido);
                        for (let item of pedido.itens) {
                            console.log(`Produto: ${item.produtoKey} | Quantidade: ${item.quantidadePedida} | Valor Unitário: ${item.preco}`);
                        }
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`apiFaturamentoBluesoft | obterPedidoBlueSoft \n Error: ${e}`);
                return {};
            }
        });
    }
}
exports.default = apiFaturamentoBluesoft;
