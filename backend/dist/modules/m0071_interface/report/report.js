"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const rerpot_interfaceJohnson_Dial_Venda_1 = __importDefault(require("./rerpot.interfaceJohnson.Dial.Venda"));
const report_interface_faturamentoitem_1 = __importDefault(require("./report.interface.faturamentoitem"));
const rerpot_interfaceJohnson_Dial_Cliente_1 = __importDefault(require("./rerpot.interfaceJohnson.Dial.Cliente"));
const rerpot_interfaceJohnson_Dial_Estoque_1 = __importDefault(require("./rerpot.interfaceJohnson.Dial.Estoque"));
class reportInterface {
}
reportInterface.reportInterfaceFaturamentoItem = report_interface_faturamentoitem_1.default;
reportInterface.reportInterfaceJohnson_Dial_Venda = rerpot_interfaceJohnson_Dial_Venda_1.default;
reportInterface.reportInterfaceJohnson_Dial_Cliente = rerpot_interfaceJohnson_Dial_Cliente_1.default;
reportInterface.reportInterfaceJohnson_Dial_Estoque = rerpot_interfaceJohnson_Dial_Estoque_1.default;
exports.default = reportInterface;
