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
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "ForcaVenda Meta ATUAL | serviceProcessarMetasAtuais.ts ";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
class serviceProcessarMetasAtuais {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a;
            try {
                yield modelbase_1.clsTools.pagConsole(` ${FLG_MODULO} - Processando Meta FABRICANTE (Obtendo o Seq da Meta FAB atual)`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let sql_max = `select max(fv_fab_meta_cd) as fv_fab_meta_cd from tbforca_venda_fab_meta`;
                let result_max = yield this.__db(sql_max);
                parametro.fv_fab_meta_cd = ((_a = result_max[0]) === null || _a === void 0 ? void 0 : _a.fv_fab_meta_cd) || 0;
                yield modelbase_1.clsTools.pagConsole(` ${FLG_MODULO} - Processando Meta FABRICANTE Sequência Obtida: ${parametro.fv_fab_meta_cd}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield serviceForcaVendaMeta_Fabricante_Processar_1.default.start(parametro);
                yield modelbase_1.clsTools.pagConsole(` ${FLG_MODULO} - Processando Meta FABRICANTE (Obtendo o Seq da Meta FAB atual) - Concluído`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                const dataAtual = new Date();
                const competencia_cd_atual = `${dataAtual.getFullYear()}${String(dataAtual.getMonth() + 1).padStart(2, "0")}`;
                let parametroserviceForcaVendaMetaProcessar = parametro;
                parametroserviceForcaVendaMetaProcessar.competencia_cd = competencia_cd_atual;
                yield modelbase_1.clsTools.pagConsole(` ${FLG_MODULO} - Processando META FORÇA DE VENDA _ Competência: ${competencia_cd_atual} - Início`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield serviceForcaVendaMeta_Processar_1.default.start(parametroserviceForcaVendaMetaProcessar);
                yield modelbase_1.clsTools.pagConsole(` ${FLG_MODULO} - Processando META FORÇA DE VENDA _ Competência: ${competencia_cd_atual} - Concluído`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
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
}
exports.default = serviceProcessarMetasAtuais;
