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
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../model/modelbase");
class pagN2011001 {
    static execute() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            try {
                console.log("Migration _ pagN2011001 - Inicializada");
                let sql = "SELECT sis_us_seq, passwd_web from tbsistema_usuario where coalesce(passwd_web,'') != '' ";
                let myBase = new modelbase_1.clsBase();
                let listuser = yield myBase.myDataBase.pag.DataGet(sql);
                let sqlUpdatePassWord = ``;
                try {
                    for (var _d = true, _e = __asyncValues(Object.entries(listuser)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [key, value] = _c;
                        sqlUpdatePassWord += `UPDATE tbsistema_usuario set passwd_web = '${myBase.criptString(value.passwd_web)}', dtlog_update = current_timestamp
                                where sis_us_seq =  ${value.sis_us_seq};`;
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                yield myBase.myDataBase.pag.Execute(sqlUpdatePassWord);
                console.log("Migration _ pagN2011001 - Finalizada");
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("migrationUtil", "pagN2011001", e);
                throw new Error(`Error ${e}`);
            }
        });
    }
}
exports.default = pagN2011001;
