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
const f0100_20_fechamento_consultar_1 = __importDefault(require("../scriptdb/f0100_20_fechamento_consultar"));
class reportFechamento {
    static sql(parametros) {
        try {
            if (!parametros.competencia_cd)
                throw new Error("Parametro [competencia_cd] não informado ");
            let sql = f0100_20_fechamento_consultar_1.default.get(parametros);
            return sql;
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException(`reportDREFechamento`, 'sql', e);
            return ``;
        }
    }
    static get(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            const myTools = new modelbase_1.clsBase();
            try {
                return yield myTools.myDataBase.pag.DataGet(this.sql(parametros));
            }
            catch (e) {
                return modelbase_1.clsTools.PagErrorException(`reportDREFechamento`, 'sql', e);
            }
        });
    }
}
exports.default = reportFechamento;
