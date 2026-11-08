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
let myBase = new modelbase_1.clsBase();
const model_1 = __importDefault(require("../model/model"));
const report_1 = __importDefault(require("../report/report"));
const model_2 = __importDefault(require("../../m0001_sistema/model/model"));
const SISTEMA_NUCLEO_PRC_CD = 10050011;
class serviceParticipanteBlueSoftImport {
    static start(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            try {
                const result = yield report_1.default.Redshift.get(parametros);
                const DataList = Array.isArray(result)
                    ? result
                    : (result != null ? [result] : []);
                let sqlInsert = "";
                let maxUpdate = yield model_2.default.resources.Sistema.limiteRegBloqUpdateGet(SISTEMA_NUCLEO_PRC_CD);
                if (maxUpdate == 0)
                    maxUpdate = 100;
                let i = 0;
                try {
                    for (var _d = true, DataList_1 = __asyncValues(DataList), DataList_1_1; DataList_1_1 = yield DataList_1.next(), _a = DataList_1_1.done, !_a; _d = true) {
                        _c = DataList_1_1.value;
                        _d = false;
                        const item = _c;
                        sqlInsert += yield model_1.default.gets.Participante.getSqlIncluirParticipanteFromRedshift(item);
                        i++;
                        if (i >= maxUpdate) {
                            yield myBase.myDataBase.pag.Execute(sqlInsert);
                            sqlInsert = "";
                            i = 0;
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = DataList_1.return)) yield _b.call(DataList_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sqlInsert.length > 0) {
                    yield myBase.myDataBase.pag.Execute(sqlInsert);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`F0011 - Participante`, `serviceParticipanteBlueSoftImport.start()`, e, true);
                throw new Error(`modules | Participante | Error ${e.message}`);
            }
        });
    }
}
exports.default = serviceParticipanteBlueSoftImport;
