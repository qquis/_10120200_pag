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
const f0100_10_fechamento_processar_1 = __importDefault(require("../scriptdb/f0100_10_fechamento_processar"));
class serviceResultado {
    static ProcessarFechamento(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myclsBase = new modelbase_1.clsBase();
                const sql = f0100_10_fechamento_processar_1.default.post(parametros);
                yield myclsBase.myDataBase.pag.Execute(sql);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceDRE", "ContaAtualizarCodigoRateio", e);
            }
        });
    }
}
exports.default = serviceResultado;
