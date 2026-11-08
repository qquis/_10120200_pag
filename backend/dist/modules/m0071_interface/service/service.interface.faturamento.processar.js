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
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = true;
const FLG_MODULO = "M0070-FATURAMENTO | Faturamento Bluesoft Processamento";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
const modelbase_1 = require("../../../model/modelbase");
const scriptsql_1 = __importDefault(require("../sql/scriptsql"));
class serviceInterfaceFaturamentoProcessar {
    static start(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                let myDataBase = new modelbase_1.clsBase();
                let sql = scriptsql_1.default.functions.f0071_10_interface_faturamento_processar.get(parametros);
                yield myDataBase.myDataBase.pag.DataGet(sql);
                result.status = true;
                result.descricao = `Atualização realizada com sucesso`;
            }
            catch (e) {
                this._log(`serviceInterfaceFaturamentoProcessar | ${e}`);
                result.status = false;
                result.info = `Erro ${e}`;
            }
            finally {
                return result;
            }
        });
    }
    static _log(message) {
        return __awaiter(this, void 0, void 0, function* () {
            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | ${message}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
        });
    }
}
exports.default = serviceInterfaceFaturamentoProcessar;
