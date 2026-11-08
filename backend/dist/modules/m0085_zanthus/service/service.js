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
const FLG_MODULO = "M0085 ZANTHUS - Service (Básico PRINCIPAL) ";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
require("dotenv/config");
const modelbase_1 = require("../../../model/modelbase");
const model_service_OLD_1 = __importDefault(require("../../../model/model.service-OLD"));
const DataBase_1 = __importDefault(require("../../../database/DataBase"));
const f0085_50_zanthus_carga_decomposicao_1 = __importDefault(require("../scriptsPg/f0085_50_zanthus_carga_decomposicao"));
const f0085_51_zanthus_carga_basetributaria_1 = __importDefault(require("../scriptsPg/f0085_51_zanthus_carga_basetributaria"));
const f0085_52_zanthus_carga_log_1 = __importDefault(require("../scriptsPg/f0085_52_zanthus_carga_log"));
const f0085_53_zanthus_carga_tabregra_icms_1 = __importDefault(require("../scriptsPg/f0085_53_zanthus_carga_tabregra_icms"));
const f0085_54_zanthus_carga_mercadoria_1 = __importDefault(require("../scriptsPg/f0085_54_zanthus_carga_mercadoria"));
const f0085_55_zanthus_carga_preco_voucher_1 = __importDefault(require("../scriptsPg/f0085_55_zanthus_carga_preco_voucher"));
const report_1 = __importDefault(require("../report/report"));
const scriptUpdateZanthusVoucherPromocional_1 = __importDefault(require("../scriptsPg/scriptUpdateZanthusVoucherPromocional"));
const scriptUpdateZanthusZeusRetailOxanCarga_1 = __importDefault(require("../scriptsPg/scriptUpdateZanthusZeusRetailOxanCarga"));
let myDATABASE = new DataBase_1.default();
class zanthusService extends model_service_OLD_1.default {
    constructor() {
        super();
    }
    PrepararDadosZanthusNaBasePag() {
        return __awaiter(this, arguments, void 0, function* (AtualizacaDadosBasicos = false) {
            try {
                //CARGA DECOMPOSIÇÃO
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_50_zanthus_carga_decomposicao_1.default.sqlScript_VERSION()}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield myDATABASE.pag.Execute(f0085_50_zanthus_carga_decomposicao_1.default.ScriptExecute());
                //CARGA TRIBUTAÇÃO
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_51_zanthus_carga_basetributaria_1.default.sqlScript_VERSION()}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield myDATABASE.pag.Execute(f0085_51_zanthus_carga_basetributaria_1.default.ScriptExecute());
                //CARGA LOG
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_52_zanthus_carga_log_1.default.sqlScript_VERSION()}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield myDATABASE.pag.Execute(f0085_52_zanthus_carga_log_1.default.ScriptExecute());
                //CARGA REGRA ICMS
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_53_zanthus_carga_tabregra_icms_1.default.sqlScript_VERSION()}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield myDATABASE.pag.Execute(f0085_53_zanthus_carga_tabregra_icms_1.default.ScriptExecute());
                //CARGA TAB MERCADORIA
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_54_zanthus_carga_mercadoria_1.default.sqlScript_VERSION()}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield myDATABASE.pag.Execute(f0085_54_zanthus_carga_mercadoria_1.default.ScriptExecute());
                /*  DADOS BASICOS (Padrão FALSE)
                    Não sendo atualização de dados básicos será atualizado preços também.
                */
                if (!AtualizacaDadosBasicos) {
                    //CARGA PREÇO VOUCHER
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_55_zanthus_carga_preco_voucher_1.default.sqlScript_VERSION()}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    yield myDATABASE.pag.Execute(f0085_55_zanthus_carga_preco_voucher_1.default.ScriptExecute());
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'PrepararDadosZanthusNaBasePag', e);
                throw new Error(`F0085 | zanthusService Metodo: atualizarBaseZanthus() ${e}`);
            }
        });
    }
    AtualizarVoucherPromocionais() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | ATUALIZANDO VOUCHER`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield this._serviceLogRegister(`${FLG_MODULO} | Gerando VOUCHER na base ZANTHUS`, false);
                let MyDataBASE = new DataBase_1.default();
                let script = yield scriptUpdateZanthusVoucherPromocional_1.default.ScriptExecute(`ZANTHUSPOSTGRE`);
                yield MyDataBASE.zanthusPostgre.Execute(script);
                yield this._serviceLogRegister(`Finalizado VOUCHER na base ZANTHUS`, true);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`${FLG_MODULO}`, 'AtualizarVoucherPromocionais', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
                throw new Error(`F0085 | zanthusService Metodo: AtualizarVoucherPromocionais() ${e} `);
            }
        });
    }
    ZeusRetailCargaOxan() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Executando ZeusRetailCargaOxan na base ZEUSRETAIL`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield this._serviceLogRegister(`${FLG_MODULO} | Zanthus.CargaLoja() Prod. de Conf ini`, false);
                yield myDATABASE.zanthusPostgre.Execute(scriptUpdateZanthusZeusRetailOxanCarga_1.default.ScriptExecute(`ZANTHUSPOSTGRE`));
                yield this._serviceLogRegister(`${FLG_MODULO} | Zanthus.CargaLoja() Prod. de Conf fim`, false);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`${FLG_MODULO}`, 'ZeusRetailCargaOxan', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
                throw new Error(`F0085 | zanthusService Metodo: ZeusRetailCargaOxan() ${e} `);
            }
        });
    }
    ZeusRetailConferirVoucher() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Executando ZeusRetailConferirVoucher na base ZEUSRETAIL`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            let qtdeVouchers = 0;
            try {
                let numeroVoucherAtual = parametros.cod_voucher || modelbase_1.clsTools._datemomentDateToStr(new Date(), `YYYYMMDD`);
                let result = yield report_1.default.ZeusVoucherQtdeProdutos({ cod_voucher: numeroVoucherAtual });
                qtdeVouchers = Array.isArray(result) ? result[0].qtde_voucher_promocional_prd : 0;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`${FLG_MODULO}`, 'ZeusRetailConferirVoucher', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
                throw new Error(`F0085 | zanthusService Metodo: ZeusRetailConferirVoucher() ${e}`);
            }
            finally {
                return qtdeVouchers;
            }
        });
    }
}
exports.default = zanthusService;
