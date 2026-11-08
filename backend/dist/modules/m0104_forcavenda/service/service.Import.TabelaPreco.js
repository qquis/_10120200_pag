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
const modelforca_venda_tabelapreco_1 = __importDefault(require("../model/modelforca_venda_tabelapreco"));
const modelforca_venda_tabelaprecoVersao_1 = __importDefault(require("../model/modelforca_venda_tabelaprecoVersao"));
const modelforca_venda_tabelaprecoProdutoBluesoft_1 = __importDefault(require("../model/modelforca_venda_tabelaprecoProdutoBluesoft"));
const myBase = new modelbase_1.clsBase();
class ForcaVendaImportTabelaPrecoApi {
    static start() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            try {
                modelbase_1.clsTools.pagConsole(`Iniciando Importação Tabela Preço Força de Venda`, false, false);
                let result = yield myBase.blueSoftApi.api_get('/forca-de-vendas/tabelas-preco-venda?currentPage=0');
                let sqlInsert = ``;
                let i = 0;
                let max = 3;
                try {
                    for (var _d = true, _e = __asyncValues(result.data.data), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const item = _c;
                        sqlInsert += yield this.getSqlInsertTabelaPreco(item);
                        sqlInsert += yield this.getSqlUpdateTabelaPrecoVersao(item);
                        if (item === null || item === void 0 ? void 0 : item.produtos) {
                            sqlInsert += yield this.getSqlInsertTabelaPrecoProdutoBluesoft(item, item === null || item === void 0 ? void 0 : item.tabelaPrecoVendaKey);
                        }
                        if (i >= max) {
                            yield myBase.myDataBase.pag.Execute(sqlInsert);
                            sqlInsert = ``;
                            i = 0;
                        }
                        i++;
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sqlInsert) {
                    yield myBase.myDataBase.pag.Execute(sqlInsert);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto `, "start", e);
                throw new Error(`modules | m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto.start | Error ${e}`);
            }
        });
    }
    static getSqlInsertTabelaPreco(dadosApi) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let itemTabelaPreco = new modelforca_venda_tabelapreco_1.default();
                itemTabelaPreco.apiBluesoftGet(dadosApi);
                return itemTabelaPreco.sqlPrimeInsert();
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto `, "start", e);
                throw new Error(`modules | m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto.getSqlInsertTabelaPreco | Error ${e}`);
            }
        });
    }
    static getSqlUpdateTabelaPrecoVersao(dadosApi) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let itemTabelaPrecoVersao = new modelforca_venda_tabelaprecoVersao_1.default();
                itemTabelaPrecoVersao.apiBluesoftGet(dadosApi);
                return itemTabelaPrecoVersao.sqlPrimeInsert();
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto `, "start", e);
                throw new Error(`modules | m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto.getSqlUpdateTabelaPrecoVersao | Error ${e}`);
            }
        });
    }
    static getSqlInsertTabelaPrecoProdutoBluesoft(dadosApi, tabelaPrecoVendaKey) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_2, _b, _c;
            try {
                let sqlinsertItem = ``;
                try {
                    for (var _d = true, _e = __asyncValues(dadosApi === null || dadosApi === void 0 ? void 0 : dadosApi.produtos), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const item = _c;
                        let itemTabelaPrecoProdutoBluesoft = new modelforca_venda_tabelaprecoProdutoBluesoft_1.default();
                        itemTabelaPrecoProdutoBluesoft.apiBluesoftGet(item, tabelaPrecoVendaKey);
                        sqlinsertItem += itemTabelaPrecoProdutoBluesoft.sqlPrimeInsert();
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
                return sqlinsertItem;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto `, "start", e);
                throw new Error(`modules | m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto.getSqlInsertTabelaPrecoProdutoBluesoft | Error ${e}`);
            }
        });
    }
}
class serviceForcaVendaImportTabelaPrecoRedshift {
    static sqlRedShiftTabelaPreco() {
        let sql = ``;
        sql = `SELECT tabela_preco_venda_key 
                ,     descricao 
                from tabela_preco_venda

        `;
        return sql;
    }
    static sqlRedShiftTabelaPrecoVersao() {
        let sql = `
                    SELECT  tabela_preco_venda_versao_key 
                        ,   tabela_preco_venda_key 
                        ,   versao 
                        ,   desconto_maximo 
                        ,   desconto_padrao 
                        ,   acrescimo_maximo
                        ,   publicada 
                        ,   coalesce(data_inicio_vigencia, '1900-01-01 01:01:01') as data_inicio_vigencia
                        ,   coalesce(data_fim_vigencia, '1900-01-01 01:01:01') as data_fim_vigencia      
                    from tabela_preco_venda_versao
                    where 1 = 1
                      and coalesce(data_inicio_vigencia, '1900-01-01 01:01:01') >= current_date - interval '10 day'

        `;
        return sql;
    }
    static sqlRedShiftTabelaPrecoProduto() {
        let sql = `
        select      i.tabela_preco_venda_item_key 
                ,   coalesce(v.versao, 0) as versao
                ,   coalesce(i.produto_key, 0) as produto_key
                ,   coalesce(i.desconto_maximo,0) as desconto_maximo
                ,   coalesce(i.desconto_padrao,0) as desconto_padrao
                ,   coalesce(i.quantidade_minima,0) as quantidade_minima
                ,   coalesce(i.quantidade_maxima,0) as quantidade_maxima
                ,   coalesce(i.preco,0) as preco
                ,   coalesce(v.tabela_preco_venda_key, 0) as tabela_preco_venda_key
            from tabela_preco_venda_item i 
            inner join tabela_preco_venda_versao v on v.tabela_preco_venda_versao_key = i.tabela_preco_venda_versao_key
            where 1= 1
            and coalesce(v.versao, 0) > 0 
            and coalesce(i.produto_key, 0) > 0 
            and coalesce(v.tabela_preco_venda_key, 0) > 0 
            and coalesce(data_inicio_vigencia, '1900-01-01 01:01:01') >= current_date - interval '10 day'

        `;
        return sql;
    }
    static start() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_3, _b, _c, _d, e_4, _e, _f, _g, e_5, _h, _j;
            try {
                let i = 0;
                let imax = 3;
                let bloq = 1;
                let sql = ``;
                modelbase_1.clsTools.pagConsole(`Iniciando Importação Tabela Preço Força de Venda`, false, false);
                let resultTabela = yield myBase.myDataBase.redshift.DataGet(this.sqlRedShiftTabelaPreco());
                try {
                    for (var _k = true, _l = __asyncValues(resultTabela), _m; _m = yield _l.next(), _a = _m.done, !_a; _k = true) {
                        _c = _m.value;
                        _k = false;
                        const item = _c;
                        let itemTabelaPreco = new modelforca_venda_tabelapreco_1.default();
                        itemTabelaPreco.redshiftGet(item);
                        sql += itemTabelaPreco.sqlPrimeInsert();
                    }
                }
                catch (e_3_1) { e_3 = { error: e_3_1 }; }
                finally {
                    try {
                        if (!_k && !_a && (_b = _l.return)) yield _b.call(_l);
                    }
                    finally { if (e_3) throw e_3.error; }
                }
                modelbase_1.clsTools.pagConsole(`Importação Tabela Preço Força de Venda - Tabela/Versão`, false, false);
                let resultVersao = yield myBase.myDataBase.redshift.DataGet(this.sqlRedShiftTabelaPrecoVersao());
                try {
                    for (var _o = true, _p = __asyncValues(resultVersao), _q; _q = yield _p.next(), _d = _q.done, !_d; _o = true) {
                        _f = _q.value;
                        _o = false;
                        const item = _f;
                        let itemTabelaPrecoVersao = new modelforca_venda_tabelaprecoVersao_1.default();
                        itemTabelaPrecoVersao.redshiftGet(item);
                        sql += itemTabelaPrecoVersao.sqlPrimeInsert();
                    }
                }
                catch (e_4_1) { e_4 = { error: e_4_1 }; }
                finally {
                    try {
                        if (!_o && !_d && (_e = _p.return)) yield _e.call(_p);
                    }
                    finally { if (e_4) throw e_4.error; }
                }
                /*  Todas as tabelas e versões são inseridas
                    no banco de dados por meio de apenas um processo
                */
                if (sql) {
                    yield myBase.myDataBase.pag.Execute(sql);
                }
                /* Inserindo os itens no banco de dados por meio de blocos */
                let resultproduto = yield myBase.myDataBase.redshift.DataGet(this.sqlRedShiftTabelaPrecoProduto());
                sql = ``;
                i = 0;
                imax = 300;
                try {
                    for (var _r = true, _s = __asyncValues(resultproduto), _t; _t = yield _s.next(), _g = _t.done, !_g; _r = true) {
                        _j = _t.value;
                        _r = false;
                        const item = _j;
                        let itemTabelaPrecoProdutoBluesoft = new modelforca_venda_tabelaprecoProdutoBluesoft_1.default();
                        itemTabelaPrecoProdutoBluesoft.redshiftGet(item);
                        sql += itemTabelaPrecoProdutoBluesoft.sqlPrimeInsert();
                        if (i >= imax) {
                            modelbase_1.clsTools.pagConsole(`m0104_ForcaVenda | service | serviceForcaVendaImport- Tabela Preço Redshift Bloco ${bloq} `, true, true);
                            yield myBase.myDataBase.pag.Execute(sql);
                            sql = ``;
                            i = 0;
                            bloq++;
                        }
                        i++;
                    }
                }
                catch (e_5_1) { e_5 = { error: e_5_1 }; }
                finally {
                    try {
                        if (!_r && !_g && (_h = _s.return)) yield _h.call(_s);
                    }
                    finally { if (e_5) throw e_5.error; }
                }
                if (sql) {
                    yield myBase.myDataBase.pag.Execute(sql);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`M0104 - serviceForcaVendaImportTabelaPrecoRedshift `, "start", e);
                throw new Error(`M0104 - serviceForcaVendaImportTabelaPrecoRedshift.start | Error ${e}`);
            }
        });
    }
}
class serviceForcaVendaImportTabelaPreco {
    static start() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield serviceForcaVendaImportTabelaPrecoRedshift.start();
                yield ForcaVendaImportTabelaPrecoApi.start();
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`M0104 - serviceForcaVendaImportTabelaPreco `, "start", e);
                throw new Error(`M0104 - serviceForcaVendaImportTabelaPreco.start | Error ${e}`);
            }
        });
    }
}
exports.default = serviceForcaVendaImportTabelaPreco;
