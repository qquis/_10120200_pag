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
const pg_f0070_25_faturamentocontrato_apuracao_1 = __importDefault(require("../scriptdb/pg.f0070_25_faturamentocontrato_apuracao"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 100700015;
const FLG_DEBUG_CONSOLE_LOG = true;
const FLG_MODULO = "M0070-FATURAMENTO | Faturamento Contrato Processamento";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
class serviceFaturamentoContratoProcessarApurar {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                /*Se for passado o número do contrato ou Faturamento Controle, será processado e apurado o contrato específico */
                if (parametro.contrato_seq && Number(parametro.contrato_seq) > 0) {
                    yield this.processarContrato(parametro);
                    yield this.apurarContratoOUCompetencia(parametro);
                }
                else {
                    const contratos = yield this.apurarListaContratosDaCompetencia(parametro);
                    /*Processando os contratos do tipo 1 e 3 da competência */
                    for (const contrato of contratos) {
                        yield this.processarContrato({
                            competencia_cd: parametro.competencia_cd,
                            contrato_seq: Number(contrato.contrato_seq),
                            data_val_ini: contrato.contrato_data_val_ini,
                            data_val_fim: contrato.contrato_data_val_fim,
                        });
                    }
                    /*fazendo a apuração geral dos contratos */
                    yield this.apurarContratoOUCompetencia(parametro);
                }
            }
            catch (e) {
                throw new Error(`serviceFaturamento | processarFaturamento \n Error ${e}`);
            }
        });
    }
    static apurarListaContratosDaCompetencia(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = `
                          SELECT  contrato_seq 
                            ,   contrato_data_val_ini
                            ,   contrato_data_val_fim
                        FROM    tbfaturamentocontrato 
                        where   1 = 1 
                        AND     COMPETENCIA_CD = ${parametro.competencia_cd}
                        and     contrato_tipo_cd in (1,3)

                `;
                return yield this._dbGet(sql);
            }
            catch (e) {
                yield this._log(`Error ${e}`);
                throw e;
            }
        });
    }
    static processarContrato(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = pg_f0070_25_faturamentocontrato_processar_1.default.get(parametro);
                yield this._dbExecute(sql);
            }
            catch (e) {
                yield this._log(`Error ${e}`);
                throw e;
            }
        });
    }
    static apurarContratoOUCompetencia(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = pg_f0070_25_faturamentocontrato_apuracao_1.default.get(parametro);
                yield this._dbExecute(sql);
            }
            catch (e) {
                yield this._log(`Error ${e}`);
                throw e;
            }
        });
    }
    static _log(message) {
        return __awaiter(this, void 0, void 0, function* () {
            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | ${message}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
        });
    }
    static _dbGet(sql) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myBase = new modelbase_1.clsBase();
                return yield myBase.myDataBase.pag.DataGet(sql);
            }
            catch (e) {
                yield this._log(`Error ${e}`);
                throw e;
            }
        });
    }
    static _dbExecute(sql) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myBase = new modelbase_1.clsBase();
                yield myBase.myDataBase.pag.Execute(sql);
            }
            catch (e) {
                yield this._log(`Error ${e}`);
                throw e;
            }
        });
    }
}
exports.default = serviceFaturamentoContratoProcessarApurar;
