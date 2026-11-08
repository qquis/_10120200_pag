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
const modelbase_1 = require("../../../model/modelbase");
const report_1 = __importDefault(require("../../../modules/m0020_produto/report/report"));
const modelfc_figura_produto_1 = __importDefault(require("../model/modelfc_figura_produto"));
const myBase = new modelbase_1.clsBase();
class serviceFiscal_Figura_Produto {
    static atualizarBasePag() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            try {
                let report = yield report_1.default.list.get({});
                let sql = ``;
                let iControl = 0;
                let iControlMax = 50;
                try {
                    for (var _d = true, _e = __asyncValues(report), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        let itemProduto = _c;
                        console.log(`codigo do produto ${itemProduto.pr_cdproduto} - ${itemProduto.prb_cdprodutobluesoft}`);
                        let itemmodelfc_figurafiscal_produto = new modelfc_figura_produto_1.default();
                        itemmodelfc_figurafiscal_produto.prb_cdprodutobluesoft = itemProduto.prb_cdprodutobluesoft;
                        sql += yield itemmodelfc_figurafiscal_produto.getInsertScriptByProdutoBluesoft(itemProduto.prb_cdprodutobluesoft);
                        if (iControl >= iControlMax) {
                            yield myBase.myDataBase.pag.Execute(sql);
                            sql = ``;
                            iControl = 0;
                        }
                        iControl++;
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql != '') {
                    yield myBase.myDataBase.pag.Execute(sql);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscal_Figura', e);
            }
            finally {
                console.log("concluído");
            }
        });
    }
}
exports.default = serviceFiscal_Figura_Produto;
