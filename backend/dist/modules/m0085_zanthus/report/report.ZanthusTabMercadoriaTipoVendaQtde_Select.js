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
const tbZanthusTabMercadoriaTipoVendaQtde_1 = __importDefault(require("../tbs/tbZanthusTabMercadoriaTipoVendaQtde"));
const modelbase_1 = require("../../../model/modelbase");
class reportZanthusTabMercadoriaTipoVendaQtde_Select {
    constructor(filter) {
        this.filter = filter;
    }
    tblist_Get() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let listTabMercadoriaTipoVenda = [];
            try {
                let myClsBase = new modelbase_1.clsBase();
                let result = yield myClsBase.myDataBase.pag.DataGet(this.scriptSelect());
                try {
                    for (var _d = true, _e = __asyncValues(Object.entries(result)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [key, value] = _c;
                        let itemTbZanthusTabMercadoriaTipoVenda = new tbZanthusTabMercadoriaTipoVendaQtde_1.default();
                        itemTbZanthusTabMercadoriaTipoVenda.binding(value);
                        listTabMercadoriaTipoVenda.push(itemTbZanthusTabMercadoriaTipoVenda);
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`M0085_Zanthus`, `report.tab_mercadoria_tipo_venda_qtde_select | tblist_Get`, e);
            }
            finally {
                return listTabMercadoriaTipoVenda;
            }
        });
    }
    scriptSelect() {
        let sqlscript = ``;
        sqlscript =
            `select 		a.pr_cdproduto
                            ,	a.prb_cdprodutobluesoft 
                            ,	a.preg_cdbarra 
                            ,	a.cod_loja
                            ,	a.cod_mercadoria
                            ,	a.cod_tipo_venda
                            ,	a.qtde_venda
                            --,	a.flag_geral
                            ,	a.preco_unitario
                            ,	a.perc_desconto
                            --,	a.flag_ativo
                            ,	a.Dth_inclusao
                            ,	a.Dth_alteracao
                            ,	a.Idt_usuario_alteracao
                from   		tbzanthustab_mercadoria_tipo_venda_qtde a
                inner join  tbzanthustab_mercadoria  		   me on me.pr_cdproduto = a.pr_cdproduto 
                                                                 and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                inner join  tbproduto 						   pr on pr.pr_cdproduto = me.pr_cdproduto 												
                where		1 = 1 
                `
                + (this.filter.ProdutosPendentesDeIntegracao ?
                    ` and pr.pr_cdproduto in (
                                                 select x.pr_cdproduto 
                                                 from   tbintegracao_produto x 
                                                 where  1 = 1
                                                   and  x.integracao_tipo_cd = ${this.filter.integracao_tipo_cd || 20008501}
                                                   and  x.integracao_status_cd = 2
                    
                                              )` : ``);
        return sqlscript;
    }
}
exports.default = reportZanthusTabMercadoriaTipoVendaQtde_Select;
