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
const modelbase_1 = require("../../../model/modelbase");
let myBase = new modelbase_1.clsBase();
const modelparticipante_1 = __importDefault(require("../model/modelparticipante"));
const model_1 = __importDefault(require("../../m0001_sistema/model/model"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 10050011;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0011-Service | ServiceParticipanteBlueSoftImport";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
class serviceParticipanteBlueSoftAPIImport {
    static start(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (parametros.cdpessoabluesoft) {
                    yield this.importItem(parametros);
                }
                else {
                    yield this.importList(parametros);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, `serviceParticipanteBlueSoftAPIImport.start()`, e, true);
                throw new Error(`modules | Participante | Error ${e.message}`);
            }
        });
    }
    static importList(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO}.start() - Iniciando importação de participante API`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            try {
                let myclsBase = new modelbase_1.clsBase();
                let listaGeral = true;
                let dataInicial = new Date(Date.now() - 1 * 24 * 60 * 60 * 1000);
                if (parametros.numeroDiasUltimaAlteracao && parametros.numeroDiasUltimaAlteracao > 0) {
                    dataInicial = new Date(Date.now() - parametros.numeroDiasUltimaAlteracao * 24 * 60 * 60 * 1000);
                    listaGeral = false;
                }
                let totalPage = 10000;
                let pageSize = 60;
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Inicializando | Total pages: ${totalPage}, Page size: ${pageSize}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let imaxUpdate = yield model_1.default.resources.Sistema.limiteRegBloqUpdateGet(SISTEMA_NUCLEO_PRC_CD);
                for (let currentPage = 0; currentPage <= totalPage; currentPage++) {
                    let url = `/clientes?currentPage=${currentPage}&pageSize=${pageSize}`;
                    if (!listaGeral) {
                        url += `&dataUltimaAlteracao=${modelbase_1.clsTools._datemomentDateToStr(dataInicial, "DD/MM/YYYY")}`;
                    }
                    let result = yield myclsBase.blueSoftApi.api_get(url);
                    if (result.data.data && result.data.data.length > 0) {
                        let listCliente = result.data.data;
                        let sql = "";
                        yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Importação Cliente Bluesoft via API | Proc. página ${currentPage}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                        if (imaxUpdate == 0)
                            imaxUpdate = 100;
                        let i = 0;
                        let iBlocoTotal = Math.ceil(listCliente.length / imaxUpdate);
                        let iBloco = 0;
                        try {
                            for (var _d = true, listCliente_1 = (e_1 = void 0, __asyncValues(listCliente)), listCliente_1_1; listCliente_1_1 = yield listCliente_1.next(), _a = listCliente_1_1.done, !_a; _d = true) {
                                _c = listCliente_1_1.value;
                                _d = false;
                                const item = _c;
                                let itemModelParticipante = new modelparticipante_1.default({});
                                yield itemModelParticipante.ObterDadosAPIBlueSoft(item);
                                sql += yield itemModelParticipante.ScriptIncluirParticipanteFromAPI();
                            }
                        }
                        catch (e_1_1) { e_1 = { error: e_1_1 }; }
                        finally {
                            try {
                                if (!_d && !_a && (_b = listCliente_1.return)) yield _b.call(listCliente_1);
                            }
                            finally { if (e_1) throw e_1.error; }
                        }
                        yield myclsBase.myDataBase.pag.Execute(sql);
                    }
                    else {
                        break;
                    }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, `serviceParticipanteBlueSoftAPIImport.start()`, e, true);
                throw new Error(`modules | Participante | Error ${e.message}`);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO}.start() - Importação de participante BlueSoft API finalizada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static importItem(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO}.start() - Iniciando importação de participante API (ITEM)`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            try {
                let myclsBase = new modelbase_1.clsBase();
                let url = `/clientes/${parametros.cdpessoabluesoft}`;
                let result = yield myclsBase.blueSoftApi.api_get(url);
                let item = result.data;
                let itemModelParticipante = new modelparticipante_1.default({});
                yield itemModelParticipante.ObterDadosAPIBlueSoft(item);
                let sql = yield itemModelParticipante.ScriptIncluirParticipanteFromAPI();
                yield myclsBase.myDataBase.pag.Execute(sql);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, `serviceParticipanteBlueSoftAPIImport.start()`, e, true);
                throw new Error(`modules | Participante | Error ${e.message}`);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO}.start() - Importação de participante BlueSoft API finalizada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
}
exports.default = serviceParticipanteBlueSoftAPIImport;
