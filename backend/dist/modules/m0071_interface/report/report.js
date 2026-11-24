"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const report_interface_faturamentoitem_1 = __importDefault(require("./report.interface.faturamentoitem"));
const rerpot_interfaceJohnson_Dial_Venda_1 = __importDefault(require("./rerpot.interfaceJohnson.Dial.Venda"));
const rerpot_interfaceJohnson_Dial_Cliente_1 = __importDefault(require("./rerpot.interfaceJohnson.Dial.Cliente"));
const rerpot_interfaceJohnson_Dial_Estoque_1 = __importDefault(require("./rerpot.interfaceJohnson.Dial.Estoque"));
const rerpot_interfaceJohnson_Mtrix_Venda_1 = __importDefault(require("./rerpot.interfaceJohnson.Mtrix.Venda"));
const rerpot_interfaceJohnson_Mtrix_Cliente_1 = __importDefault(require("./rerpot.interfaceJohnson.Mtrix.Cliente"));
const rerpot_interfaceJohnson_Mtrix_ForcaVenda_1 = __importDefault(require("./rerpot.interfaceJohnson.Mtrix.ForcaVenda"));
const rerpot_interfaceJohnson_Mtrix_Produto_1 = __importDefault(require("./rerpot.interfaceJohnson.Mtrix.Produto"));
const rerpot_interfaceJohnson_Mtrix_Estoque_1 = __importDefault(require("./rerpot.interfaceJohnson.Mtrix.Estoque"));
class reportInterface {
}
reportInterface.reportInterfaceFaturamentoItem = report_interface_faturamentoitem_1.default;
reportInterface.reportInterfaceJohnson_Dial_Venda = rerpot_interfaceJohnson_Dial_Venda_1.default;
reportInterface.reportInterfaceJohnson_Dial_Cliente = rerpot_interfaceJohnson_Dial_Cliente_1.default;
reportInterface.reportInterfaceJohnson_Dial_Estoque = rerpot_interfaceJohnson_Dial_Estoque_1.default;
reportInterface.reportInterfaceJohnson_Mtrix_Venda = rerpot_interfaceJohnson_Mtrix_Venda_1.default;
reportInterface.reportInterfaceJohnson_Mtrix_Cliente = rerpot_interfaceJohnson_Mtrix_Cliente_1.default;
reportInterface.reportInterfaceJohnson_Mtrix_ForcaVenda = rerpot_interfaceJohnson_Mtrix_ForcaVenda_1.default;
reportInterface.reportInterfaceJohnson_Mtrix_Produto = rerpot_interfaceJohnson_Mtrix_Produto_1.default;
reportInterface.reportInterfaceJohnson_Mtrix_Estoque = rerpot_interfaceJohnson_Mtrix_Estoque_1.default;
exports.default = reportInterface;
