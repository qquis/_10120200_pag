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
const FLG_MODULO = "M0085 ZANTHUS - Service | CARGA NEW 2026)";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE = ``;
/*  ____________________________________________________________________________________________*/
const modelbase_1 = require("../../../model/modelbase");
const model_zanthus_carga_1 = __importDefault(require("../model/model_zanthus_carga"));
const serviceAtualizacao_Dados_Mercadoria_1 = __importDefault(require("./serviceAtualizacao.Dados.Mercadoria"));
const serviceAtualizacao_Dados_RegrasFiscais_1 = __importDefault(require("./serviceAtualizacao.Dados.RegrasFiscais"));
const serviceAtualizacao_Dados_Decomposicao_1 = __importDefault(require("./serviceAtualizacao.Dados.Decomposicao"));
class serviceZanthusCarga {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processamento Iniciando...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            try {
                /* Cria uma nova carga */
                let CARGA = yield this.criarCarga(parametro);
                /* Inicia a carga */
                yield this.IniciarCarga(CARGA);
                /* Gera os produtos pendentes para a carga */
                yield this.GerarProdutosPendentes(CARGA);
                /* Executa a carga criada */
                yield this.ProcessarCarga(CARGA);
                /* Finaliza a carga */
                yield this.FinalizarCarga(CARGA);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO start', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processamento finalizado`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static criarCarga(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let NovaCarga = new model_zanthus_carga_1.default();
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Gerando Registro de Carga`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                NovaCarga.carga_uuid = modelbase_1.clsTools.uuid(15, true);
                NovaCarga.carga_tipo_cd = parametro === null || parametro === void 0 ? void 0 : parametro.carga_tipo_cd;
                yield this.dataBase(NovaCarga._Db_Pg_script_Insert());
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Registro de Carga gerado com sucesso UUID ${NovaCarga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO criarCarga', e);
            }
            finally {
                return NovaCarga;
            }
        });
    }
    static IniciarCarga(carga) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Iniciando Carga UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield this.dataBase(carga.scriptAtualizarStatusIniciar());
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO IniciarCarga', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Iniciar Carga finalizada UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static GerarProdutosPendentes(carga) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Gerando Produtos Pendentes para Carga UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield this.dataBase(carga.zanthusCargaProduto.scriptProdutosPendente(carga.carga_uuid, carga.carga_tipo_cd));
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO GerarProdutosPendentes', e);
            }
        });
    }
    static ProcessarCarga(carga) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando Carga UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                if (carga.carga_tipo_cd == 1) {
                    yield serviceAtualizacao_Dados_Mercadoria_1.default.start({ carga_uuid: carga.carga_uuid });
                    yield serviceAtualizacao_Dados_RegrasFiscais_1.default.start({ carga_uuid: carga.carga_uuid });
                    yield serviceAtualizacao_Dados_Decomposicao_1.default.start({ carga_uuid: carga.carga_uuid });
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO ProcessarCarga', e);
            }
        });
    }
    static FinalizarCarga(carga) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Finalizando Carga UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield this.dataBase(carga.scriptAtualizarStatusFinalizar());
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO FinalizarCarga', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Finalizar Carga finalizada UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static dataBase(scriptSql) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myDataBase = new modelbase_1.clsBase();
                yield myDataBase.myDataBase.pag.Execute(scriptSql);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO dataBase', e);
            }
        });
    }
}
exports.default = serviceZanthusCarga;
