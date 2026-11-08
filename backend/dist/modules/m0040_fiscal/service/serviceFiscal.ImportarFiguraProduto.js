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
const report_1 = __importDefault(require("../../m0020_produto/report/report"));
const modelfc_figura_produto_1 = __importDefault(require("../model/modelfc_figura_produto"));
const CONSOLE_LOG = true;
const DEBUG_ITEM = false;
const myBase = new modelbase_1.clsBase();
class serviceAtualizarFiguraFiscalPorProdutoUnitario {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            try {
                let report = yield report_1.default.list.get(parametro);
                let listaProdutos = report;
                if (listaProdutos.length === 0) {
                    yield modelbase_1.clsTools.pagConsole(`M0040_FISCAL - Importar Figura Produto: *NENHUM PRODUTO ENCONTRADO*`, CONSOLE_LOG, false);
                    return;
                }
                let sql = ``;
                let iControl = 0;
                let numeroRegistros = listaProdutos.length;
                let iControlMax = 70;
                let BlocoTotal = Math.ceil(numeroRegistros / iControlMax);
                let BlocoAtual = 1;
                try {
                    for (var _d = true, listaProdutos_1 = __asyncValues(listaProdutos), listaProdutos_1_1; listaProdutos_1_1 = yield listaProdutos_1.next(), _a = listaProdutos_1_1.done, !_a; _d = true) {
                        _c = listaProdutos_1_1.value;
                        _d = false;
                        let itemProduto = _c;
                        let itemmodelfc_figurafiscal_produto = new modelfc_figura_produto_1.default();
                        itemmodelfc_figurafiscal_produto.prb_cdprodutobluesoft = itemProduto.prb_cdprodutobluesoft;
                        sql += yield itemmodelfc_figurafiscal_produto.getInsertScriptByProdutoBluesoft(itemProduto.prb_cdprodutobluesoft);
                        if (CONSOLE_LOG && DEBUG_ITEM) {
                            yield modelbase_1.clsTools.pagConsole(`M0040_FISCAL - Importar Figura Produto: ${itemProduto.prb_cdprodutobluesoft} - ${itemProduto.prb_descricao}`, CONSOLE_LOG, false);
                        }
                        if (iControl >= iControlMax) {
                            yield modelbase_1.clsTools.pagConsole(`M0040_FISCAL - Importar Figura Produto: Executando bloco ${BlocoAtual} de ${BlocoTotal}`, CONSOLE_LOG, false);
                            yield myBase.myDataBase.pag.Execute(sql);
                            sql = ``;
                            iControl = 0;
                            BlocoAtual++;
                        }
                        iControl++;
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listaProdutos_1.return)) yield _b.call(listaProdutos_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql != '') {
                    yield modelbase_1.clsTools.pagConsole(`M0040_FISCAL - Executando último bloco`, CONSOLE_LOG, false);
                    yield myBase.myDataBase.pag.Execute(sql);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscal_Figura', e);
            }
            finally {
                modelbase_1.clsTools.pagConsole('M0040_FISCAL - Importação de Figura Produto finalizada', CONSOLE_LOG, false);
            }
        });
    }
}
exports.default = serviceAtualizarFiguraFiscalPorProdutoUnitario;
