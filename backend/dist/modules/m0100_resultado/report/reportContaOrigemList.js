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
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const scriptdbResultadoContaOrigem_1 = __importDefault(require("../scriptdb/scriptdbResultadoContaOrigem"));
class reportContaOrigemList {
    static sql(parametros = {}) { return scriptdbResultadoContaOrigem_1.default.get(parametros); }
    static get() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            const myTools = new modelbase_1.clsBase();
            try {
                return yield myTools.myDataBase.pag.DataGet(this.sql(parametros));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`reportDREContaList`, 'sql', e);
            }
        });
    }
}
exports.default = reportContaOrigemList;
