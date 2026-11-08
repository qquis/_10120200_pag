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
const FLG_MODULO = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ ZEUSRETAIL.CARGAOXAN() (JS ServiceAtualizacao.tabMercadoria)";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE = ``;
/*  ____________________________________________________________________________________________*/
const modelbase_1 = require("../../../model/modelbase");
const script_1 = __importDefault(require("../scriptsPg/script"));
class serviceAtualizacaoDadosZeusRetailCargaOxan {
    static start() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            try {
                let myData = new modelbase_1.clsBase();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Iniciando o processamento de Voucher Promocional`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let data_hoje = new Date();
                let cod_voucher = modelbase_1.clsTools._datemomentDateToStr(data_hoje, "YYYYMMDD");
                parametros.cod_voucher = cod_voucher;
                yield myData.myDataBase.zanthusPostgre.Execute(script_1.default.zeusRetailCargaOxan.ScriptExecute());
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`${FLG_MODULO}`, 'start', e, false, "CARGA NEW 2026 - ZEUSRETAIL.CARGAOXAN()", FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
}
exports.default = serviceAtualizacaoDadosZeusRetailCargaOxan;
