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
const mdo_1 = __importDefault(require("../../m0001_sistema/mdo"));
const model_zanthus_carga_1 = __importDefault(require("../model/model_zanthus_carga"));
const serviceAtualizacao_Carga_Dados_PrepararBasePrime_1 = __importDefault(require("./serviceAtualizacao.Carga.Dados.PrepararBasePrime"));
const serviceAtualizacao_Carga_Dados_Mercadoria_1 = __importDefault(require("./serviceAtualizacao.Carga.Dados.Mercadoria"));
const serviceAtualizacao_Carga_Dados_RegrasFiscais_1 = __importDefault(require("./serviceAtualizacao.Carga.Dados.RegrasFiscais"));
const serviceAtualizacao_Carga_Dados_Decomposicao_1 = __importDefault(require("./serviceAtualizacao.Carga.Dados.Decomposicao"));
const serviceAtualizacao_Carga_Dados_TipoVenda_1 = __importDefault(require("./serviceAtualizacao.Carga.Dados.TipoVenda"));
const serviceAtualizacao_Carga_Dados_TipoVendaQtde_1 = __importDefault(require("./serviceAtualizacao.Carga.Dados.TipoVendaQtde"));
const serviceAtualizacao_Carga_Dados_VoucherPromocional_1 = __importDefault(require("./serviceAtualizacao.Carga.Dados.VoucherPromocional"));
const serviceAtualizacao_Carga_Dados_ZeusRetailCargaOxan_1 = __importDefault(require("./serviceAtualizacao.Carga.Dados.ZeusRetailCargaOxan"));
const report_1 = __importDefault(require("../report/report"));
class serviceZanthusCarga {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let resultadoCarga = parametro;
            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processamento Iniciando...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            try {
                /* Cria uma nova carga */
                let CARGA = yield this.cargaDadosZanthusCriar(parametro);
                /* Inicia a carga */
                yield this.cargaBaseZanthusPrepararBasePrime(CARGA);
                /* Inicia a carga */
                yield this.cargaDadosZanthusIniciar(CARGA);
                /* Gera os produtos pendentes para a carga */
                yield this.cargaDadosZanthusGerarProdutosPendentes(CARGA);
                /* Executa a carga criada */
                yield this.cargaDadosZanthusProcessar(CARGA);
                /* Finaliza a carga */
                yield this.cargaDadosZanthusFinalizar(CARGA);
                /*CONFERÊNCIAS*/
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Conferindo o Voucher`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let numeroVoucherAtual = parseInt(modelbase_1.clsTools._datemomentDateToStr(new Date(), `YYYYMMDD`));
                let result = yield report_1.default.ZeusVoucherQtdeProdutos({ cod_voucher: numeroVoucherAtual });
                let qtdePromocional = Array.isArray(result) ? result[0].qtde_voucher_promocional_prd : 0;
                resultadoCarga.integracao_qtde_promocional = qtdePromocional;
                resultadoCarga.numero_voucher_atual = numeroVoucherAtual;
                let infoCarga = yield report_1.default.ZanthusCarga.get({ carga_uuid: CARGA.carga_uuid });
                if (infoCarga.length > 0) {
                    resultadoCarga.integracao_pendente_qtde = parseInt(infoCarga[0].qtd_unitario);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO start', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processamento finalizado`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                return resultadoCarga;
            }
        });
    }
    static cargaDadosZanthusCriar(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let NovaCarga = new model_zanthus_carga_1.default();
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Gerando Registro de Carga`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                NovaCarga.carga_uuid = modelbase_1.clsTools.uuid(15, true);
                NovaCarga.carga_tipo_cd = parametro === null || parametro === void 0 ? void 0 : parametro.carga_tipo_cd;
                let user_name = parametro.__systemUserConnect.user_name;
                if (!user_name) {
                    user_name = "sistema";
                }
                let usuario_sistema = yield mdo_1.default.Report.Usuario.getByUserName(user_name);
                let sis_us_seq = usuario_sistema.sis_us_seq;
                if (!sis_us_seq || sis_us_seq <= 0) {
                    sis_us_seq = 3;
                }
                NovaCarga.carga_usr_seq_create = sis_us_seq;
                yield this.__dataPrimeExecute(NovaCarga._Db_Pg_script_Insert());
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
    static cargaBaseZanthusPrepararBasePrime(carga) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Preparando Base Prime para Carga UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield serviceAtualizacao_Carga_Dados_PrepararBasePrime_1.default.start({ carga_uuid: carga.carga_uuid });
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO PrepararBasePrime', e);
            }
        });
    }
    static cargaDadosZanthusIniciar(carga) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Iniciando Carga UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield this.__dataPrimeExecute(carga.scriptAtualizarStatusIniciar());
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO IniciarCarga', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Iniciar Carga finalizada UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static cargaDadosZanthusGerarProdutosPendentes(carga) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Gerando Produtos Pendentes para Carga UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield this.__dataPrimeExecute(carga.zanthusCargaProduto.scriptProdutosPendente(carga.carga_uuid, carga.carga_tipo_cd));
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO GerarProdutosPendentes', e);
            }
        });
    }
    static cargaDadosZanthusProcessar(carga) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando Carga UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                if (carga.carga_tipo_cd == 1) {
                    yield serviceAtualizacao_Carga_Dados_Mercadoria_1.default.start({ carga_uuid: carga.carga_uuid });
                    yield serviceAtualizacao_Carga_Dados_RegrasFiscais_1.default.start({ carga_uuid: carga.carga_uuid });
                    yield serviceAtualizacao_Carga_Dados_Decomposicao_1.default.start({ carga_uuid: carga.carga_uuid });
                    yield serviceAtualizacao_Carga_Dados_TipoVenda_1.default.start({ carga_uuid: carga.carga_uuid });
                    yield serviceAtualizacao_Carga_Dados_TipoVendaQtde_1.default.start({ carga_uuid: carga.carga_uuid });
                    yield serviceAtualizacao_Carga_Dados_VoucherPromocional_1.default.start({ carga_uuid: carga.carga_uuid });
                    yield serviceAtualizacao_Carga_Dados_ZeusRetailCargaOxan_1.default.start({ carga_uuid: carga.carga_uuid });
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO ProcessarCarga', e);
            }
        });
    }
    static cargaDadosZanthusFinalizar(carga) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Finalizando Carga UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield this.__dataPrimeExecute(carga.scriptAtualizarStatusFinalizar());
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO FinalizarCarga', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Finalizar Carga finalizada UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static __dataPrimeExecute(scriptSql) {
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
