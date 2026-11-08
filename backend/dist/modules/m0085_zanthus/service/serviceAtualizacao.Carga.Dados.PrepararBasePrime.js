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
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0085 ZANTHUS - Service CARGA | PREPARACAO NA BASE PRIME/PAG ";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
require("dotenv/config");
const modelbase_1 = require("../../../model/modelbase");
const f0085_50_zanthus_carga_decomposicao_1 = __importDefault(require("../scriptsPg/f0085_50_zanthus_carga_decomposicao"));
const f0085_51_zanthus_carga_basetributaria_1 = __importDefault(require("../scriptsPg/f0085_51_zanthus_carga_basetributaria"));
const f0085_52_zanthus_carga_log_1 = __importDefault(require("../scriptsPg/f0085_52_zanthus_carga_log"));
const f0085_53_zanthus_carga_tabregra_icms_1 = __importDefault(require("../scriptsPg/f0085_53_zanthus_carga_tabregra_icms"));
const f0085_54_zanthus_carga_mercadoria_1 = __importDefault(require("../scriptsPg/f0085_54_zanthus_carga_mercadoria"));
const f0085_55_zanthus_carga_preco_voucher_1 = __importDefault(require("../scriptsPg/f0085_55_zanthus_carga_preco_voucher"));
class serviceZanthusAtualizacaoDadosPrepararBasePrime {
    static start() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            try {
                /* CARGA ANTIGA */
                let myDATABASE = new modelbase_1.clsBase();
                //CARGA DECOMPOSIÇÃO
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_50_zanthus_carga_decomposicao_1.default.sqlScript_VERSION()}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield myDATABASE.myDataBase.pag.Execute(f0085_50_zanthus_carga_decomposicao_1.default.ScriptExecute());
                //CARGA TRIBUTAÇÃO
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_51_zanthus_carga_basetributaria_1.default.sqlScript_VERSION()}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield myDATABASE.myDataBase.pag.Execute(f0085_51_zanthus_carga_basetributaria_1.default.ScriptExecute());
                //CARGA LOG
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_52_zanthus_carga_log_1.default.sqlScript_VERSION()}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield myDATABASE.myDataBase.pag.Execute(f0085_52_zanthus_carga_log_1.default.ScriptExecute());
                //CARGA REGRA ICMS
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_53_zanthus_carga_tabregra_icms_1.default.sqlScript_VERSION()}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield myDATABASE.myDataBase.pag.Execute(f0085_53_zanthus_carga_tabregra_icms_1.default.ScriptExecute());
                //CARGA TAB MERCADORIA
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_54_zanthus_carga_mercadoria_1.default.sqlScript_VERSION()}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield myDATABASE.myDataBase.pag.Execute(f0085_54_zanthus_carga_mercadoria_1.default.ScriptExecute());
                /*  DADOS BASICOS (Padrão FALSE)
                    Não sendo atualização de dados básicos será atualizado preços também.
                */
                if (!parametros.AtualizacaDadosBasicos || parametros.AtualizacaDadosBasicos === false) {
                    //CARGA PREÇO VOUCHER
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_55_zanthus_carga_preco_voucher_1.default.sqlScript_VERSION()}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    yield myDATABASE.myDataBase.pag.Execute(f0085_55_zanthus_carga_preco_voucher_1.default.ScriptExecute());
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'start', e);
                throw new Error(`F0085 | zanthusService Metodo: start() ${e}`);
            }
        });
    }
}
exports.default = serviceZanthusAtualizacaoDadosPrepararBasePrime;
