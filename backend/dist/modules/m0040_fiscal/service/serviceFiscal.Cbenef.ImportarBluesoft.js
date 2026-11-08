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
const modelfc_cbenef_1 = __importDefault(require("../model/modelfc_cbenef"));
const model_1 = __importDefault(require("../../m0040_fiscal/model/model"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0040-FISCAL-Service | Importar CBENEF Bluesoft";
const FLG_DEBUG_FILE_CONSOLE_LOG = `IMPORTACAO_CBENEF_BLUESOFT`;
/*  ------------------------------------------------------------------------------------------- */
const myBase = new modelbase_1.clsBase();
class serviceFiscal_Cbenef_ImportarBluesoft {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c, _d, e_2, _e, _f, _g, e_3, _h, _j, _k, e_4, _l, _m;
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | ServiceFiscal.Cbenef_ImportarBluesoft.start - Iniciando...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let maxPAG = 10000;
                if (parametro && parametro.fc_cbenef_cd && parametro.fc_cbenef_cd.trim() !== '') {
                    maxPAG = 0;
                }
                let listaCbenefBluesoft = [];
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | ServiceFiscal.Cbenef_ImportarBluesoft.start - Lendo a API DE CBENEF`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                for (let currentPage = 0; currentPage <= maxPAG; currentPage++) {
                    let url = `/fiscal/beneficio-uf?uf=SP&currentPage=${currentPage}`;
                    if (parametro && parametro.fc_cbenef_cd && parametro.fc_cbenef_cd.trim() !== '') {
                        url = `/fiscal/beneficio-uf?uf=SP&codigoBeneficioFiscal=${parametro.fc_cbenef_cd}&currentPage=${currentPage}`;
                    }
                    let result = yield myBase.blueSoftApi.api_get(url);
                    if (result.data.data.length && result.data.data.length !== 0) {
                        try {
                            for (var _o = true, _p = (e_1 = void 0, __asyncValues(result.data.data)), _q; _q = yield _p.next(), _a = _q.done, !_a; _o = true) {
                                _c = _q.value;
                                _o = false;
                                const item = _c;
                                let itemCbenef = new modelfc_cbenef_1.default();
                                itemCbenef.getCbenefBLueApi(item);
                                if (itemCbenef.fc_cbenef_cd !== 'SP099999') { /* CBENF GENERICO */
                                    listaCbenefBluesoft.push(itemCbenef);
                                }
                            }
                        }
                        catch (e_1_1) { e_1 = { error: e_1_1 }; }
                        finally {
                            try {
                                if (!_o && !_a && (_b = _p.return)) yield _b.call(_p);
                            }
                            finally { if (e_1) throw e_1.error; }
                        }
                    }
                    else {
                        modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processamento CBENEF - Nenhum registro encontrado na página ${currentPage}. Finalizando a consulta.`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                        break;
                    }
                }
                /*Inserindo os cbenefs na base de dados */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | ServiceFiscal.Cbenef_ImportarBluesoft.start - Inserindo os cbenefs na base de dados`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let scriptCbenef = ``;
                try {
                    for (var _r = true, listaCbenefBluesoft_1 = __asyncValues(listaCbenefBluesoft), listaCbenefBluesoft_1_1; listaCbenefBluesoft_1_1 = yield listaCbenefBluesoft_1.next(), _d = listaCbenefBluesoft_1_1.done, !_d; _r = true) {
                        _f = listaCbenefBluesoft_1_1.value;
                        _r = false;
                        const itemModelfc_cbenef = _f;
                        scriptCbenef += yield itemModelfc_cbenef.sqlInserirDadosDeApi();
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_r && !_d && (_e = listaCbenefBluesoft_1.return)) yield _e.call(listaCbenefBluesoft_1);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
                if (scriptCbenef.trim() != "") {
                    yield myBase.myDataBase.pag.Execute(scriptCbenef);
                }
                /*consultando e gravando os produtos relacionados*/
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | ServiceFiscal.Cbenef_ImportarBluesoft.start - Consultando e gravando os produtos relacionados`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let sqlCbenefList = ``;
                try {
                    for (var _s = true, listaCbenefBluesoft_2 = __asyncValues(listaCbenefBluesoft), listaCbenefBluesoft_2_1; listaCbenefBluesoft_2_1 = yield listaCbenefBluesoft_2.next(), _g = listaCbenefBluesoft_2_1.done, !_g; _s = true) {
                        _j = listaCbenefBluesoft_2_1.value;
                        _s = false;
                        const itemModelfc_cbenef = _j;
                        let resultAPICebenfProdutoBlue = yield myBase.blueSoftApi.api_get(`/fiscal/beneficio-uf/${itemModelfc_cbenef.fc_cbenef_bluesoft_cd}/produtos`);
                        if (resultAPICebenfProdutoBlue.data.data.length && resultAPICebenfProdutoBlue.data.data.length !== 0) {
                            let listaProdutos = [];
                            let icountMaxPage = 10000;
                            for (let ipagProduto = 0; ipagProduto <= icountMaxPage; ipagProduto++) {
                                let urlproduto = `/fiscal/beneficio-uf/${itemModelfc_cbenef.fc_cbenef_bluesoft_cd}/produtos?currentPage=${ipagProduto}`;
                                let resultAPICebenfProdutoBlue = yield myBase.blueSoftApi.api_get(urlproduto);
                                if (resultAPICebenfProdutoBlue.data.data.length && resultAPICebenfProdutoBlue.data.data.length !== 0) {
                                    try {
                                        for (var _t = true, _u = (e_4 = void 0, __asyncValues(resultAPICebenfProdutoBlue.data.data)), _v; _v = yield _u.next(), _k = _v.done, !_k; _t = true) {
                                            _m = _v.value;
                                            _t = false;
                                            const itemProduto = _m;
                                            listaProdutos.push(itemProduto.produtoKey);
                                        }
                                    }
                                    catch (e_4_1) { e_4 = { error: e_4_1 }; }
                                    finally {
                                        try {
                                            if (!_t && !_k && (_l = _u.return)) yield _l.call(_u);
                                        }
                                        finally { if (e_4) throw e_4.error; }
                                    }
                                }
                                else {
                                    break;
                                }
                            }
                            modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Numero de produtos encontrado no CBENEF ${itemModelfc_cbenef.fc_cbenef_bluesoft_cd}/${itemModelfc_cbenef.fc_cbenef_cd}: ${listaProdutos.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            if (listaProdutos.length > 0) {
                                /* Se foi encontrado produtos no CBENF será atualizado cada item de acordo com o list */
                                sqlCbenefList += model_1.default.sqlDELETE_tbfc_cbenef_produtobluesoft_PorCbenef(itemModelfc_cbenef.fc_cbenef_cd);
                                let liststringproduto = listaProdutos.join(',');
                                sqlCbenefList += yield model_1.default.sqlINSERT_TbFC_CBENEF_PRODUTO_FromList_PorCBENEF(itemModelfc_cbenef.fc_cbenef_cd, listaProdutos);
                                sqlCbenefList += model_1.default.sqlUPDATE_tbprodutobluesoft_CBENEF_NULL_PorCBENEF(itemModelfc_cbenef.fc_cbenef_cd);
                            }
                            else {
                                /* Se nao foi encontrado, será feito um update null*/
                                sqlCbenefList += model_1.default.sqlUPDATE_tbprodutobluesoft_NULL_porCBENEF(itemModelfc_cbenef.fc_cbenef_cd);
                            }
                        }
                        else {
                            sqlCbenefList += model_1.default.sqlUPDATE_tbprodutobluesoft_NULL_porCBENEF(itemModelfc_cbenef.fc_cbenef_cd);
                        }
                        /*Processando CBNEF por CBENEF*/
                        if (sqlCbenefList.trim() != "") {
                            yield myBase.myDataBase.pag.Execute(sqlCbenefList);
                            sqlCbenefList = ``;
                        }
                    }
                }
                catch (e_3_1) { e_3 = { error: e_3_1 }; }
                finally {
                    try {
                        if (!_s && !_g && (_h = listaCbenefBluesoft_2.return)) yield _h.call(listaCbenefBluesoft_2);
                    }
                    finally { if (e_3) throw e_3.error; }
                }
                /*Atualizar os codigos pag quando for null e quando tiver na bluesoft */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizar os codigos pag quando for null e quando tiver na bluesoft`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                sqlCbenefList += model_1.default.sqlUpdateALL_CBENEF_TbProduto_ComTbProdutoBluesoft();
                if (sqlCbenefList.trim() != "") {
                    yield myBase.myDataBase.pag.Execute(sqlCbenefList);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`${FLG_MODULO}`, 'start', e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | ServiceFiscal.Cbenef_ImportarBluesoft.start - Finalizado`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
}
exports.default = serviceFiscal_Cbenef_ImportarBluesoft;
