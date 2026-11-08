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
const modelfc_regrafiscalNfceProduto_1 = __importDefault(require("../model/modelfc_regrafiscalNfceProduto"));
const _serviceFiscalShare_1 = __importDefault(require("./_serviceFiscalShare"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 10050011;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0040-Fiscal | ServiceFiscalImportarRegraNfceProduto";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
const myBase = new modelbase_1.clsBase();
class serviceFiscalImportarRegraNfceProduto {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            const ServiceShare = new _serviceFiscalShare_1.default();
            try {
                let isql = ``;
                let ipagCount = 1000;
                if (parametro.prb_cdprodutobluesoft && parametro.prb_cdprodutobluesoft != '') {
                    ipagCount = 1;
                }
                for (let ipag = 1; ipag <= ipagCount; ipag++) {
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando Bloco ${ipag}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    let url = `/modulos/fiscal/regra-fiscal/pdv/sat-nfces?lojaKey=1&page=${ipag}`;
                    if (parametro.prb_cdprodutobluesoft && parametro.prb_cdprodutobluesoft != '') {
                        url += `&produtoKey=${parametro.prb_cdprodutobluesoft}`;
                    }
                    const report = yield myBase.blueSoftApi.api_get(url);
                    if (report.data.length == 0) {
                        yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Import DADOS NFCE SEM REGISTRO ${ipag}`, FLG_DEBUG_CONSOLE_LOG, true, FLG_DEBUG_FILE_CONSOLE_LOG);
                        break;
                    }
                    else {
                        yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Import DADOS NFCE Bloco ${ipag} Possui informacoes e sera processado`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                        let i = 0;
                        let iCount = 50;
                        try {
                            for (var _d = true, _e = (e_1 = void 0, __asyncValues(report.data)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                                _c = _f.value;
                                _d = false;
                                const item = _c;
                                const modelItem = new modelfc_regrafiscalNfceProduto_1.default();
                                modelItem.LerDadosDaAPI(item);
                                modelItem.LOCAL_STATUS_API = 1;
                                isql += modelItem.sql_CRUD();
                                ServiceShare.Complemento.ProcessarReformaDadosComplementares(item);
                                i++;
                                if (i >= iCount) {
                                    yield this.dadaBaseProcessar(isql);
                                    i = 0;
                                    isql = ``;
                                }
                            }
                        }
                        catch (e_1_1) { e_1 = { error: e_1_1 }; }
                        finally {
                            try {
                                if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                            }
                            finally { if (e_1) throw e_1.error; }
                        }
                        yield this.dadaBaseProcessar(isql);
                    }
                }
                yield ServiceShare.Complemento.SalvarDadosDosLists();
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscal_Figura', e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Importação NFCE FINALIZADA`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static dadaBaseProcessar(scriptSQL) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (scriptSQL.length > 0) {
                    yield myBase.myDataBase.pag.Execute(scriptSQL);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'serviceFiscalImportarRegraNfceProduto.dadaBaseProcessar', e);
            }
        });
    }
}
exports.default = serviceFiscalImportarRegraNfceProduto;
