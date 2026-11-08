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
/*  CONSTANTES _________________________________________________________________________________*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0085 ZANTHUS - Service | CARGA VIA DESKTOP";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE = ``;
/*  ____________________________________________________________________________________________*/
const modelbase_1 = require("../../../model/modelbase");
const report_1 = __importDefault(require("../report/report"));
const serviceAtualizacao_Carga_Processar_old_1 = __importDefault(require("./serviceAtualizacao.Carga.Processar.old"));
const serviceAtualizacao_Carga_Processar_new_1 = __importDefault(require("./serviceAtualizacao.Carga.Processar.new"));
class serviceAtualizacaoDeskTop {
    static start(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let resultadoCarga;
            parametros.integracao_tipo_cd = 0,
                parametros.integracao_tipo_descricao = "NÃO IDENTIFICADA",
                parametros.tipoCarga = parametros.TipoCompleta ? `COMPLETA` : `PARCIAL`,
                parametros.integracao_pendente_qtde = 0,
                parametros.integracao_qtde_promocional = 0,
                parametros.numero_voucher_atual = 0,
                parametros.carga_tipo_cd = 1;
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - **** CARGA DE DESKTOP INICIADA ****`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - ***********************************`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - TIPO DE CARGA SELECIONADA NO .ENV ${process.env.ZANTHUS_TIPO_CARGA}`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                if (process.env.ZANTHUS_TIPO_CARGA === "REFORMA_TRIBUTARIA") {
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - CARGA REFORMA_TRIBUTARIA - OLD`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    yield serviceAtualizacao_Carga_Processar_old_1.default.start(parametros);
                    parametros.integracao_tipo_descricao = "CARGA TIPO REFORMA_TRIBUTARIA OLD";
                }
                if (process.env.ZANTHUS_TIPO_CARGA === "REFORMA_TRIBUTARIA_NEW") {
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - CARGA REFORMA_TRIBUTARIA - NEW`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    yield serviceAtualizacao_Carga_Processar_new_1.default.start(parametros);
                    parametros.integracao_tipo_descricao = "CARGA TIPO REFORMA_TRIBUTARIA NEW.2026";
                }
                parametros.integracao_qtde_promocional = yield this.conferirVoucher(parametros);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`${FLG_MODULO}`, 'start', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - FIM DO PROCESSO DE CARGA`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                return parametros;
            }
        });
    }
    static conferirVoucher(resultadoCarga) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Conferindo o Voucher`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let numeroVoucherAtual = parseInt(modelbase_1.clsTools._datemomentDateToStr(new Date(), `YYYYMMDD`));
                let result = yield report_1.default.ZeusVoucherQtdeProdutos({ cod_voucher: numeroVoucherAtual });
                let qtdePromocional = Array.isArray(result) ? result[0].qtde_voucher_promocional_prd : 0;
                return qtdePromocional;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`${FLG_MODULO}`, 'conferirVoucher', e, false, "ERRO AO CONFERIR VOUCHER", FLG_DEBUG_FILE_CONSOLE_LOG);
                return 0;
            }
        });
    }
}
exports.default = serviceAtualizacaoDeskTop;
