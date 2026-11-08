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
var __asyncValues = (this && this.__asyncValues) || function (o) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var m = o[Symbol.asyncIterator], i;
    return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i);
    function verb(n) { i[n] = o[n] && function (v) { return new Promise(function (resolve, reject) { v = o[n](v), settle(resolve, reject, v.done, v.value); }); }; }
    function settle(resolve, reject, d, v) { Promise.resolve(v).then(function(v) { resolve({ value: v, done: d }); }, reject); }
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const model_faturamento_1 = __importDefault(require("../model/model_faturamento"));
const report_1 = __importDefault(require("../../m0050_faturamento_bluesoft/report/report"));
class serviceFaturamentoBluesoft {
    static start(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let listAProcessar = [];
            try {
                if (filter.op_cdoperacao === 0) {
                    throw new Error("serviceFaturamento | processarFaturamento \n op_cdoperacao não informado");
                }
                let listFaturamentoBluesoft = yield report_1.default.list.getModel(filter);
                try {
                    for (var _d = true, listFaturamentoBluesoft_1 = __asyncValues(listFaturamentoBluesoft), listFaturamentoBluesoft_1_1; listFaturamentoBluesoft_1_1 = yield listFaturamentoBluesoft_1.next(), _a = listFaturamentoBluesoft_1_1.done, !_a; _d = true) {
                        _c = listFaturamentoBluesoft_1_1.value;
                        _d = false;
                        let itemFaturamentoBluesoft = _c;
                        console.log(`Número pedido FV: ${itemFaturamentoBluesoft.numeropedido_fv} || Número pedido: ${itemFaturamentoBluesoft.numeropedido}`);
                        let itemFaturamento = new model_faturamento_1.default();
                        yield itemFaturamento.ProcessarFaturamentoBluesoft(itemFaturamentoBluesoft, filter.reprocessaritem);
                        listAProcessar.push(itemFaturamento);
                        console.log(`Faturamento processado para o pedido FV: ${itemFaturamento.numeropedido_fv} || Número pedido: ${itemFaturamento.numeropedido}`);
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listFaturamentoBluesoft_1.return)) yield _b.call(listFaturamentoBluesoft_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
            }
            catch (e) {
                throw new Error(`serviceFaturamento | processarFaturamento \n Error ${e}`);
            }
            finally {
                return listAProcessar;
            }
        });
    }
}
exports.default = serviceFaturamentoBluesoft;
