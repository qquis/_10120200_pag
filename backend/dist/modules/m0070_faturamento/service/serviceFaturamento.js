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
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = true;
const FLG_MODULO = "Faturamento | serviceFaturamento.ts ";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
const serviceFaturamentoBluesoftProcessar_1 = __importDefault(require("./serviceFaturamentoBluesoftProcessar"));
const serviceFaturamentoContratoProcessarApurar_1 = __importDefault(require("./serviceFaturamentoContratoProcessarApurar"));
const service_1 = __importDefault(require("../../m0005_forcavenda_meta/service/service"));
class serviceFaturamento {
    static FaturamentoProcessar(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(` ${FLG_MODULO} - Iniciando processamento do faturamento`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield serviceFaturamentoBluesoftProcessar_1.default.start(parametro);
                /** Contratos Processar **/
                yield modelbase_1.clsTools.pagConsole(` ${FLG_MODULO} - Processamento CONTRATOS`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                parametro.faturamento_controle_seq = 0;
                parametro.contrato_seq = 0;
                parametro.competencia_cd = Number(parametro.data_processamento.replace(/-/g, '').slice(0, 6));
                parametro.data_val_ini = modelbase_1.clsTools._datemomentDatStrToDate(parametro.data_processamento, "YYYY-MM-DD");
                parametro.data_val_fim = modelbase_1.clsTools._datemomentDatStrToDate(parametro.data_processamento, "YYYY-MM-DD");
                yield serviceFaturamentoContratoProcessarApurar_1.default.start(parametro);
                /** Processamento META FORÇA DE VENDA **/
                yield modelbase_1.clsTools.pagConsole(` ${FLG_MODULO} - Processamento META FORÇA DE VENDA (FABRICANTE E DO FORÇA INTERNO)`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield service_1.default.metasAtuais.start(parametro);
                yield modelbase_1.clsTools.pagConsole(` ${FLG_MODULO} - Processamento do faturamento concluído`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "FaturamentoProcessar", e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
}
serviceFaturamento.faturamentoBluesoft = serviceFaturamentoBluesoftProcessar_1.default;
serviceFaturamento.faturamentoContratoService = serviceFaturamentoContratoProcessarApurar_1.default;
exports.default = serviceFaturamento;
