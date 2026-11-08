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
const modelfc_cofins_1 = __importDefault(require("../model/modelfc_cofins"));
class serviceFiscalImportarCofins {
    static start() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.serviceFiscalImportarCofins.start - Iniciando...', false, false);
                let myBase = new modelbase_1.clsBase();
                yield modelbase_1.clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.serviceFiscalImportarCofins - Processando COFINS DE SAIDA', false, false);
                let resultCofinsTipoSaida = yield myBase.blueSoftApi.api_get('/fiscal/cofins?tipo=SAIDA');
                yield this.ProcessarDadosDaApi(resultCofinsTipoSaida.data, 'SAIDA');
                yield modelbase_1.clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.serviceFiscalImportarCofins - Processando COFINS DE ENTRADA', false, false);
                let resultCofinsTipoEntrada = yield myBase.blueSoftApi.api_get('/fiscal/cofins?tipo=ENTRADA');
                yield this.ProcessarDadosDaApi(resultCofinsTipoEntrada.data, 'ENTRADA');
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalImportarCofins', e);
            }
            finally {
                modelbase_1.clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.serviceFiscalImportarCofins - Finalizado', false, false);
            }
        });
    }
    static ProcessarDadosDaApi(DadosApi, tipo) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, DadosApi_1, DadosApi_1_1;
            var _b, e_1, _c, _d;
            try {
                let myBase = new modelbase_1.clsBase();
                let i = 0;
                let iMaxExecute = 50;
                let sql = ``;
                try {
                    for (_a = true, DadosApi_1 = __asyncValues(DadosApi); DadosApi_1_1 = yield DadosApi_1.next(), _b = DadosApi_1_1.done, !_b; _a = true) {
                        _d = DadosApi_1_1.value;
                        _a = false;
                        const item = _d;
                        let itemCofins = new modelfc_cofins_1.default();
                        itemCofins.bindingApiBluesoft_urlFiscalCofins(item);
                        itemCofins.tipo_entrada = 0;
                        if (tipo == 'ENTRADA') {
                            itemCofins.tipo_entrada = 1;
                        }
                        sql += itemCofins.script_insert();
                        i++;
                        if (i >= iMaxExecute) {
                            yield myBase.myDataBase.pag.Execute(sql);
                            sql = ``;
                            i = 0;
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_a && !_b && (_c = DadosApi_1.return)) yield _c.call(DadosApi_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql.trim() != '') {
                    yield myBase.myDataBase.pag.Execute(sql);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalImportarCofins.ProcessarDadosDaApi', e);
            }
        });
    }
}
exports.default = serviceFiscalImportarCofins;
