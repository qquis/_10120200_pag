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
const pg_f0070_25_faturamentocontrato_processar_1 = __importDefault(require("../scriptdb/pg.f0070_25_faturamentocontrato_processar"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = true;
const FLG_MODULO = "M0070-FATURAMENTO | Faturamento Contrato Processamento";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
class serviceFaturamentoContratoProcessar {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myBase = new modelbase_1.clsBase();
                if (parametro.data_val_ini == null || parametro.data_val_fim == null) {
                    yield this._log(`Parâmetro data_val_ini ou data_val_fim não informado`);
                    throw new Error("serviceFaturamento | processarFaturamento \n data_val_ini ou data_val_fim não informado");
                }
                let scriptSql = pg_f0070_25_faturamentocontrato_processar_1.default.get(parametro, parametro.reprocessaritem);
                yield this._log(`M0070 | Fat Blue - Processar | Contrato | Iniciando: ${parametro.contrato_seq} || Data Validade: ${modelbase_1.clsTools._datemomentDateToStr(parametro.data_val_ini, 'YYYY-MM-DD')} até ${modelbase_1.clsTools._datemomentDateToStr(parametro.data_val_fim, 'YYYY-MM-DD')}`);
                yield myBase.myDataBase.pag.Execute(scriptSql);
                yield this._log(`M0070 | Fat Blue - Processar | Contrato | Finalizado: ${parametro.contrato_seq} || Data Validade: ${modelbase_1.clsTools._datemomentDateToStr(parametro.data_val_ini, 'YYYY-MM-DD')} até ${modelbase_1.clsTools._datemomentDateToStr(parametro.data_val_fim, 'YYYY-MM-DD')}`);
            }
            catch (e) {
                throw new Error(`serviceFaturamento | processarFaturamento \n Error ${e}`);
            }
        });
    }
    static _log(message) {
        return __awaiter(this, void 0, void 0, function* () {
            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | ${message}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
        });
    }
}
exports.default = serviceFaturamentoContratoProcessar;
