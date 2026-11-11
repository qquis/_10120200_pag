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
const serviceForcaVendaMeta_Fabricante_Processar_1 = __importDefault(require("./serviceForcaVendaMeta.Fabricante.Processar"));
const serviceForcaVendaMeta_Processar_1 = __importDefault(require("./serviceForcaVendaMeta.Processar"));
const report_1 = __importDefault(require("../../m0001_sistema/report/report"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = true;
const FLG_MODULO = "ForcaVenda Meta ATUAL | serviceProcessarMetasAtuais.ts ";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
class serviceProcessarMetasAtuais {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let dadosOperacionais = yield report_1.default.Operacional.getDefault();
                console.log(dadosOperacionais);
                if (!dadosOperacionais) {
                    yield this.__log(`Dados operacionais não encontrados para o Período/Competência atual`);
                    return;
                }
                if (dadosOperacionais.fv_fab_meta_cd) {
                    yield this.__log(`Processando os dados da Meta Fabricante: ${dadosOperacionais.fv_fab_meta_cd}`);
                    parametro.fv_fab_meta_cd = dadosOperacionais.fv_fab_meta_cd;
                    yield serviceForcaVendaMeta_Fabricante_Processar_1.default.start(parametro);
                }
                if (dadosOperacionais.competencia_cd) {
                    yield this.__log(`Processando os dados Meta OXAN: ${dadosOperacionais.competencia_cd}`);
                    parametro.competencia_cd = dadosOperacionais.competencia_cd;
                    yield serviceForcaVendaMeta_Processar_1.default.start(parametro);
                }
            }
            catch (e) {
                console.error("Error in serviceProcessarMetasAtuais.start:", e);
            }
        });
    }
    static __db(string_sql) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let __db = new modelbase_1.clsBase();
                let result = __db.myDataBase.pag.DataGet(string_sql);
                return result;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "__db (Service.if0017)", e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static __log(message) {
        return __awaiter(this, void 0, void 0, function* () {
            yield modelbase_1.clsTools.pagConsole(` ${FLG_MODULO} - ${message}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
        });
    }
}
exports.default = serviceProcessarMetasAtuais;
