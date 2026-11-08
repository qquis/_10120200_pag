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
const modelforca_venda_prazopgtos_1 = __importDefault(require("../model/modelforca_venda_prazopgtos"));
const myBase = new modelbase_1.clsBase();
class serviceForcaVendaImportPrazoPgto {
    static start() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            try {
                let result = yield myBase.blueSoftApi.api_get('/forca-de-vendas/prazos-de-pagamento');
                let sqlInsert = ``;
                try {
                    for (var _d = true, _e = __asyncValues(result.data.data), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const item = _c;
                        let model = new modelforca_venda_prazopgtos_1.default();
                        model.apiBluesoftGet(item);
                        sqlInsert += model.sqlPrimeInsert();
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                yield myBase.myDataBase.pag.Execute(sqlInsert);
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`modules | m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto.start | Error \n ${e}`, false, false);
                throw new Error(`modules | m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto.start | Error ${e}`);
            }
        });
    }
}
exports.default = serviceForcaVendaImportPrazoPgto;
