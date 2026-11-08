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
var __asyncValues = (this && this.__asyncValues) || function (o) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var m = o[Symbol.asyncIterator], i;
    return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i);
    function verb(n) { i[n] = o[n] && function (v) { return new Promise(function (resolve, reject) { v = o[n](v), settle(resolve, reject, v.done, v.value); }); }; }
    function settle(resolve, reject, d, v) { Promise.resolve(v).then(function(v) { resolve({ value: v, done: d }); }, reject); }
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
/*  CONSTANTES _________________________________________________________________________________*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0085 ZANTHUS - Service | Atualização Geral Mercadoria/Fiscal";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE = ``;
/*  ____________________________________________________________________________________________*/
const modelbase_1 = require("../../../model/modelbase");
const service_1 = __importDefault(require("./service"));
const modelintegracao_tipo_1 = __importDefault(require("../../m0095_integracao/model/modelintegracao_tipo"));
const report_ZanthusTabMercadoria_Select_1 = __importDefault(require("../report/report.ZanthusTabMercadoria_Select"));
const report_ZanthusTabRegrasIcms_Select_1 = __importDefault(require("../report/report.ZanthusTabRegrasIcms_Select"));
class serviceAtualizacaoGeralFiscal {
    static start(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualização Zanthus (TAB MERCADORIA E TAB REGRAS ICMS) GERAL iniciada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                /*Instancia do Módulo ZANTHUS*/
                let myZanthusService = new service_1.default();
                /*  Preparando dados Zanthus na base Pag
                    - Implica na preparação geral dos dados.
                */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Preparando dados Zanthus na base Pag`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield myZanthusService.PrepararDadosZanthusNaBasePag(true);
                /*  Processa a leitura dos dados
    
                */
                let reportZanthusType = {
                    Base: 'Zanthus',
                    ProdutosPendentesDeIntegracao: parametros.ProdutosPendentesDeIntegracao ? true : false,
                    AlteracaoTributaria: "0",
                    integracao_tipo_cd: parametros.integracao_tipo_cd || 20008501
                };
                yield this.atualizaTabMercadoria(reportZanthusType);
                yield this.atualizaTabRegrasIcms(reportZanthusType);
                if (parametros.integracao_tipo_cd && parametros.integracao_tipo_cd > 0) {
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Finalizando pendências de integração de produtos para integracao_tipo_cd: ${parametros.integracao_tipo_cd}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    let myModelIntegracaoTipo = new modelintegracao_tipo_1.default();
                    myModelIntegracaoTipo.integracao_tipo.integracao_tipo_cd = parametros.integracao_tipo_cd;
                    yield myModelIntegracaoTipo.FinalizarTodosIntegracaoDeProdutoPendentes();
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Finalização pendências de integração de produtos para integracao_tipo_cd: ${parametros.integracao_tipo_cd} concluída`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                }
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualização fiscal concluída com sucesso!`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`serviceAtualizacaoGeral`, 'start', e);
                throw new Error(`F0085 | serviceAtualizacaoGeral ${e} `);
            }
        });
    }
    static atualizaTabMercadoria(reportZanthusType) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let i = 0;
            let icount = 0;
            let icountTotal = 0;
            let ilimite_reg_bloq_update = 200;
            let sql = ``;
            try {
                let myclsBase = new modelbase_1.clsBase();
                let myReportZanthusTabMercadoria_Select = new report_ZanthusTabMercadoria_Select_1.default(reportZanthusType);
                let listTabMercadoria = yield myReportZanthusTabMercadoria_Select.tblist_Get();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabMercadoria Total de itens para processamento: ${listTabMercadoria.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                i = 0;
                icount = 0;
                icountTotal = listTabMercadoria.length;
                ilimite_reg_bloq_update = myclsBase.myDataBase.MAX_UPDATE_DEFAULT;
                sql = ``;
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualização TabMercadoria MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                try {
                    for (var _d = true, listTabMercadoria_1 = __asyncValues(listTabMercadoria), listTabMercadoria_1_1; listTabMercadoria_1_1 = yield listTabMercadoria_1.next(), _a = listTabMercadoria_1_1.done, !_a; _d = true) {
                        _c = listTabMercadoria_1_1.value;
                        _d = false;
                        const item = _c;
                        sql += item.ZanthusPostGre_CRUD();
                        i++;
                        icount++;
                        if (i >= ilimite_reg_bloq_update) {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabMercadoria - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                            sql = ``;
                            i = 0;
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listTabMercadoria_1.return)) yield _b.call(listTabMercadoria_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql !== ``) {
                    yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO atualizaTabMercadoria', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizacao TabMercadoria finalizada - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static atualizaTabRegrasIcms(reportZanthusType) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_2, _b, _c;
            let i = 0;
            let icount = 0;
            let icountTotal = 0;
            let ilimite_reg_bloq_update = 0;
            let sql = ``;
            try {
                let myclsBase = new modelbase_1.clsBase();
                let myreportZanthusTabRegrasIcms_Select = new report_ZanthusTabRegrasIcms_Select_1.default(reportZanthusType);
                let listTabRegrasIcms = yield myreportZanthusTabRegrasIcms_Select.tblist_Get();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando  atualizaTabRegrasIcms | Total de itens para processamento: ${listTabRegrasIcms.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                i = 0;
                icount = 0;
                icountTotal = listTabRegrasIcms.length;
                ilimite_reg_bloq_update = myclsBase.myDataBase.MAX_UPDATE_DEFAULT;
                sql = ``;
                modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualização TabRegrasIcms MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                try {
                    for (var _d = true, listTabRegrasIcms_1 = __asyncValues(listTabRegrasIcms), listTabRegrasIcms_1_1; listTabRegrasIcms_1_1 = yield listTabRegrasIcms_1.next(), _a = listTabRegrasIcms_1_1.done, !_a; _d = true) {
                        _c = listTabRegrasIcms_1_1.value;
                        _d = false;
                        const item = _c;
                        sql += item.ZanthusPostGre_CRUD();
                        i++;
                        icount++;
                        if (i >= ilimite_reg_bloq_update) {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando  atualizaTabRegrasIcms | - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                            sql = ``;
                            i = 0;
                        }
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listTabRegrasIcms_1.return)) yield _b.call(listTabRegrasIcms_1);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
                if (sql !== ``) {
                    yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO atualizaTabRegrasIcms', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizacao TabRegrasIcms finalizada - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
}
exports.default = serviceAtualizacaoGeralFiscal;
