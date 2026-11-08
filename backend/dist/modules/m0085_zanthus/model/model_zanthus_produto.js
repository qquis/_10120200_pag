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
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const modelbase_1 = require("../../../model/modelbase");
class model_zanthus_produto {
    constructor() {
        this.pr_cdproduto = 0;
        this.prb_cdprodutobluesoft = 0;
        this.ListTabMercadoria = [];
        this.ListTabRegrasIcms = [];
        this.ListTabMercadoriaTipoVenda = [];
        this.ListTabMercadoriaTipoVendaQtde = [];
        this.ListTabProdutoDecomposicao = [];
        this.ListTabProdudoDecomposicaoInsum = [];
        this.PostGreSqlScriptUpdate = ``;
        this.SqlServerScriptUpdate = ``;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.pr_cdproduto = item === null || item === void 0 ? void 0 : item.pr_cdproduto;
                this.prb_cdprodutobluesoft = item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoft;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`m0085 | model_zanthus_produto`, `binding`, e);
            }
        });
    }
    binding_mercadoria(listtabmercadoria, listtabRegrasIcms, listtabMercadoriaTipoVenda, listtabMercadoriaTipoVendaQtde, listtabProdutoDecomposicao, listtabProdutoDecomposicaoInsum) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, listtabmercadoria_1, listtabmercadoria_1_1, _b, listtabRegrasIcms_1, listtabRegrasIcms_1_1, _c, listtabMercadoriaTipoVenda_1, listtabMercadoriaTipoVenda_1_1, _d, listtabMercadoriaTipoVendaQtde_1, listtabMercadoriaTipoVendaQtde_1_1, _e, listtabProdutoDecomposicao_1, listtabProdutoDecomposicao_1_1, _f, listtabProdutoDecomposicaoInsum_1, listtabProdutoDecomposicaoInsum_1_1;
            var _g, e_1, _h, _j, _k, e_2, _l, _m, _o, e_3, _p, _q, _r, e_4, _s, _t, _u, e_5, _v, _w, _x, e_6, _y, _z;
            try {
                try {
                    for (_a = true, listtabmercadoria_1 = __asyncValues(listtabmercadoria); listtabmercadoria_1_1 = yield listtabmercadoria_1.next(), _g = listtabmercadoria_1_1.done, !_g; _a = true) {
                        _j = listtabmercadoria_1_1.value;
                        _a = false;
                        const item = _j;
                        if (item.pr_cdproduto == this.pr_cdproduto) {
                            this.ListTabMercadoria.push(item);
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_a && !_g && (_h = listtabmercadoria_1.return)) yield _h.call(listtabmercadoria_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                try {
                    for (_b = true, listtabRegrasIcms_1 = __asyncValues(listtabRegrasIcms); listtabRegrasIcms_1_1 = yield listtabRegrasIcms_1.next(), _k = listtabRegrasIcms_1_1.done, !_k; _b = true) {
                        _m = listtabRegrasIcms_1_1.value;
                        _b = false;
                        const item = _m;
                        if (item.pr_cdproduto == this.pr_cdproduto) {
                            this.ListTabRegrasIcms.push(item);
                        }
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_b && !_k && (_l = listtabRegrasIcms_1.return)) yield _l.call(listtabRegrasIcms_1);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
                try {
                    for (_c = true, listtabMercadoriaTipoVenda_1 = __asyncValues(listtabMercadoriaTipoVenda); listtabMercadoriaTipoVenda_1_1 = yield listtabMercadoriaTipoVenda_1.next(), _o = listtabMercadoriaTipoVenda_1_1.done, !_o; _c = true) {
                        _q = listtabMercadoriaTipoVenda_1_1.value;
                        _c = false;
                        const item = _q;
                        if (item.pr_cdproduto == this.pr_cdproduto) {
                            this.ListTabMercadoriaTipoVenda.push(item);
                        }
                    }
                }
                catch (e_3_1) { e_3 = { error: e_3_1 }; }
                finally {
                    try {
                        if (!_c && !_o && (_p = listtabMercadoriaTipoVenda_1.return)) yield _p.call(listtabMercadoriaTipoVenda_1);
                    }
                    finally { if (e_3) throw e_3.error; }
                }
                try {
                    for (_d = true, listtabMercadoriaTipoVendaQtde_1 = __asyncValues(listtabMercadoriaTipoVendaQtde); listtabMercadoriaTipoVendaQtde_1_1 = yield listtabMercadoriaTipoVendaQtde_1.next(), _r = listtabMercadoriaTipoVendaQtde_1_1.done, !_r; _d = true) {
                        _t = listtabMercadoriaTipoVendaQtde_1_1.value;
                        _d = false;
                        const item = _t;
                        if (item.pr_cdproduto == this.pr_cdproduto) {
                            this.ListTabMercadoriaTipoVendaQtde.push(item);
                        }
                    }
                }
                catch (e_4_1) { e_4 = { error: e_4_1 }; }
                finally {
                    try {
                        if (!_d && !_r && (_s = listtabMercadoriaTipoVendaQtde_1.return)) yield _s.call(listtabMercadoriaTipoVendaQtde_1);
                    }
                    finally { if (e_4) throw e_4.error; }
                }
                try {
                    for (_e = true, listtabProdutoDecomposicao_1 = __asyncValues(listtabProdutoDecomposicao); listtabProdutoDecomposicao_1_1 = yield listtabProdutoDecomposicao_1.next(), _u = listtabProdutoDecomposicao_1_1.done, !_u; _e = true) {
                        _w = listtabProdutoDecomposicao_1_1.value;
                        _e = false;
                        const item = _w;
                        if (item.pr_cdproduto == this.pr_cdproduto) {
                            this.ListTabProdutoDecomposicao.push(item);
                        }
                    }
                }
                catch (e_5_1) { e_5 = { error: e_5_1 }; }
                finally {
                    try {
                        if (!_e && !_u && (_v = listtabProdutoDecomposicao_1.return)) yield _v.call(listtabProdutoDecomposicao_1);
                    }
                    finally { if (e_5) throw e_5.error; }
                }
                try {
                    for (_f = true, listtabProdutoDecomposicaoInsum_1 = __asyncValues(listtabProdutoDecomposicaoInsum); listtabProdutoDecomposicaoInsum_1_1 = yield listtabProdutoDecomposicaoInsum_1.next(), _x = listtabProdutoDecomposicaoInsum_1_1.done, !_x; _f = true) {
                        _z = listtabProdutoDecomposicaoInsum_1_1.value;
                        _f = false;
                        const item = _z;
                        if (item.pr_cdproduto == this.pr_cdproduto) {
                            this.ListTabProdudoDecomposicaoInsum.push(item);
                        }
                    }
                }
                catch (e_6_1) { e_6 = { error: e_6_1 }; }
                finally {
                    try {
                        if (!_f && !_x && (_y = listtabProdutoDecomposicaoInsum_1.return)) yield _y.call(listtabProdutoDecomposicaoInsum_1);
                    }
                    finally { if (e_6) throw e_6.error; }
                }
                yield this.montarScriptAtualizacao();
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`m0085 | model_zanthus_produto`, `binding_mercadoria`, e);
            }
        });
    }
    montarScriptAtualizacao() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                /*TAB MERCADORIA */
                this.ListTabMercadoria.forEach(item => {
                    this.PostGreSqlScriptUpdate += item.ZanthusPostGre_CRUD();
                });
                /*TAB REGRA ICMS */
                this.ListTabRegrasIcms.forEach(item => {
                    this.PostGreSqlScriptUpdate += item.ZanthusPostGre_CRUD();
                });
                /*TAB TIPO VENDA */
                this.ListTabMercadoriaTipoVenda.forEach(item => {
                    this.PostGreSqlScriptUpdate += item.ZanthusPostGre_CRUD();
                });
                /*TAB TIPO VENDA QTDE */
                this.ListTabMercadoriaTipoVendaQtde.forEach(item => {
                    this.PostGreSqlScriptUpdate += item.ZanthusPostGre_CRUD();
                });
                /*PRODUTO DECOMPOSICAO */
                this.ListTabProdutoDecomposicao.forEach(item => {
                    this.PostGreSqlScriptUpdate += item.ZanthusPostGre_CRUD();
                });
                /*PRODUTO INSUM */
                this.ListTabProdudoDecomposicaoInsum.forEach(item => {
                    //console.log(item.ZanthusPostGre_CRUD())
                    this.PostGreSqlScriptUpdate += item.ZanthusPostGre_CRUD();
                });
                yield Tools_1.default._wait(30);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`m0085 | model_zanthus_produto`, `montarScriptAtualizacao`, e);
            }
        });
    }
}
exports.default = model_zanthus_produto;
