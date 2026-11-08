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
const report_ZanthusTabMercadoria_Select_1 = __importDefault(require("../report/report.ZanthusTabMercadoria_Select"));
const report_ZanthusTabRegrasIcms_Select_1 = __importDefault(require("../report/report.ZanthusTabRegrasIcms_Select"));
const service_1 = __importDefault(require("./service"));
class serviceAtualizacaoGeral {
    static start() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myZanthusService = new service_1.default();
                yield myZanthusService.PrepararDadosZanthusNaBasePag();
                yield this.atualizaTabMercadoria();
                yield this.atualizaTabRegrasIcms();
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`serviceAtualizacaoGeral`, 'start', e);
                throw new Error(`F0085 | serviceAtualizacaoGeral ${e} `);
            }
        });
    }
    static atualizaTabMercadoria() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            try {
                let myreportZanthusTabMercadoria_Select = new report_ZanthusTabMercadoria_Select_1.default({ AlteracaoTributaria: "1" });
                let listTabMercadoria = yield myreportZanthusTabMercadoria_Select.tblist_Get();
                modelbase_1.clsTools.pagConsole(`TAB_MERCADORIA | Total de itens para processamento: ${listTabMercadoria.length}`);
                let i = 0;
                let CountExecute = 50;
                let scriptSQL = ``;
                let myBase = new modelbase_1.clsBase();
                try {
                    for (var _d = true, listTabMercadoria_1 = __asyncValues(listTabMercadoria), listTabMercadoria_1_1; listTabMercadoria_1_1 = yield listTabMercadoria_1.next(), _a = listTabMercadoria_1_1.done, !_a; _d = true) {
                        _c = listTabMercadoria_1_1.value;
                        _d = false;
                        const item = _c;
                        scriptSQL += item.ZanthusPostGre_CRUD();
                        modelbase_1.clsTools.pagConsole(`TAB_MERCADORIA | Processando item : ${item.pr_cdproduto}/${item.prb_cdprodutobluesoftunitario} - ${item.descricao} - ${item.cod_mercadoria}`);
                        if (i >= CountExecute) {
                            yield myBase.myDataBase.zanthusPostgre.Execute(scriptSQL);
                            modelbase_1.clsTools.pagConsole(`TAB_MERCADORIA | Processados ${CountExecute} itens.`);
                            i = 0;
                            scriptSQL = ``;
                        }
                        i++;
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listTabMercadoria_1.return)) yield _b.call(listTabMercadoria_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (scriptSQL !== ``) {
                    yield myBase.myDataBase.zanthusPostgre.Execute(scriptSQL);
                    modelbase_1.clsTools.pagConsole(`TAB_MERCADORIA | Processados ${i} itens.`);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`serviceAtualizacaoGeral`, 'atualizaTabMercadoria', e);
                throw new Error(`F0085 | serviceAtualizacaoGeral ${e} `);
            }
        });
    }
    static atualizaTabRegrasIcms() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_2, _b, _c;
            try {
                let myreportZanthusTabRegrasIcms_Select = new report_ZanthusTabRegrasIcms_Select_1.default({ AlteracaoTributaria: "1" });
                let listTabRegrasIcms = yield myreportZanthusTabRegrasIcms_Select.tblist_Get();
                modelbase_1.clsTools.pagConsole(`TAB_REGRAS_ICMS | Total de itens para processamento: ${listTabRegrasIcms.length}`);
                let i = 0;
                let CountExecute = 50;
                let scriptSQL = ``;
                let myBase = new modelbase_1.clsBase();
                try {
                    for (var _d = true, listTabRegrasIcms_1 = __asyncValues(listTabRegrasIcms), listTabRegrasIcms_1_1; listTabRegrasIcms_1_1 = yield listTabRegrasIcms_1.next(), _a = listTabRegrasIcms_1_1.done, !_a; _d = true) {
                        _c = listTabRegrasIcms_1_1.value;
                        _d = false;
                        const item = _c;
                        scriptSQL += item.ZanthusPostGre_CRUD();
                        modelbase_1.clsTools.pagConsole(`TAB_REGRAS_ICMS | Processando item : ${item.pr_cdproduto}/${item.prb_cdprodutobluesoft} - ${item.descricao} - ${item.cod_regras_icms}`, false, false);
                        if (i >= CountExecute) {
                            yield myBase.myDataBase.zanthusPostgre.Execute(scriptSQL);
                            modelbase_1.clsTools.pagConsole(`TAB_REGRAS_ICMS | Processados ${CountExecute} itens.`);
                            i = 0;
                            scriptSQL = ``;
                        }
                        i++;
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listTabRegrasIcms_1.return)) yield _b.call(listTabRegrasIcms_1);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
                if (scriptSQL !== ``) {
                    yield myBase.myDataBase.zanthusPostgre.Execute(scriptSQL);
                    modelbase_1.clsTools.pagConsole(`TAB_REGRAS_ICMS | Processados ${i} itens.`);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`serviceAtualizacaoGeral`, 'atualizaTabRegrasIcms', e);
                throw new Error(`F0085 | serviceAtualizacaoGeral ${e} `);
            }
        });
    }
}
exports.default = serviceAtualizacaoGeral;
