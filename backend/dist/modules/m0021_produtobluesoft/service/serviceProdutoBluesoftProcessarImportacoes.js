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
const F0021_90_ProdutoBlueSoft_Processamento_1 = __importDefault(require("../scriptpg/F0021_90_ProdutoBlueSoft_Processamento"));
/*

    APós a importação de produtos da bluesoft este script postgre faz a inclusão dos produtos importados na base PAG
        tbproduto
        tbprodutoembalagem
        tbprodutogtins

*/
class serviceProdutoBluesoftProcessarImportacoes {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = { success: false };
            try {
                let myBase = new modelbase_1.clsBase();
                yield myBase.myDataBase.pag.Execute(`SELECT ${F0021_90_ProdutoBlueSoft_Processamento_1.default.sqlScript_VERSION()} ()`);
            }
            catch (e) {
                result.success = false;
                modelbase_1.clsTools.pagConsole(`serviceProcessarImportacoes | start \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = serviceProdutoBluesoftProcessarImportacoes;
