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
const modelGrupoEconomico_1 = __importDefault(require("../model/modelGrupoEconomico"));
const model_1 = __importDefault(require("../../m0001_sistema/model/model"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 10050011;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0011-Service | ServiceGrupoEconomicoImport";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
class serviceGrupoEconomicoImport {
    static start(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (parametros.cdgrupoeconomico) {
                    //await this.importItem(parametros)
                    this.__log(`Importação por item EM DESENVOLVIMENTO...`);
                }
                else {
                    yield this.importList(parametros);
                }
            }
            catch (e) {
                yield this.__error(`serviceGrupoEconomicoImport.start()`, e);
                throw new Error(`modules | Participante | Error ${e.message}`);
            }
        });
    }
    static importList(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            yield this.__log(`Iniciando importação de lista de grupos econômicos`);
            try {
                let myclsBase = new modelbase_1.clsBase();
                let totalPage = 10000;
                let pageSize = 60;
                yield this.__log(`Inicializando | Total pages: ${totalPage}, Page size: ${pageSize}`);
                let imaxUpdate = yield model_1.default.resources.Sistema.limiteRegBloqUpdateGet(SISTEMA_NUCLEO_PRC_CD);
                for (let currentPage = 0; currentPage <= totalPage; currentPage++) {
                    let url = `/forca-de-vendas/grupos-economicos?currentPage=${currentPage}&pageSize=${pageSize}`;
                    let result = yield myclsBase.blueSoftApi.api_get(url);
                    if (result && result.data && result.data.data) {
                        yield this.__log(`Página ${currentPage} retornou dados`);
                        let dados = result.data.data;
                        if (dados.length > 0) {
                            let scriptSQL = ``;
                            try {
                                for (var _d = true, dados_1 = (e_1 = void 0, __asyncValues(dados)), dados_1_1; dados_1_1 = yield dados_1.next(), _a = dados_1_1.done, !_a; _d = true) {
                                    _c = dados_1_1.value;
                                    _d = false;
                                    let item = _c;
                                    let itemGrupoeconomico = new modelGrupoEconomico_1.default({});
                                    yield itemGrupoeconomico.lerApiBluesoft(item);
                                    if (itemGrupoeconomico.dadosApi.cdgrupoeconomico) {
                                        scriptSQL += itemGrupoeconomico.script_update_from_api() + `\n`;
                                    }
                                }
                            }
                            catch (e_1_1) { e_1 = { error: e_1_1 }; }
                            finally {
                                try {
                                    if (!_d && !_a && (_b = dados_1.return)) yield _b.call(dados_1);
                                }
                                finally { if (e_1) throw e_1.error; }
                            }
                            if (scriptSQL) {
                                yield this.__log(`Executando script SQL para atualização de grupos econômicos`);
                                yield this.__dbExecute(scriptSQL);
                                scriptSQL = ``;
                            }
                        }
                        else {
                            yield this.__log(`Nenhum dado retornado na página ${currentPage}`);
                            break;
                        }
                    }
                    else {
                        yield this.__log(`Nenhum dado retornado na página ${currentPage}`);
                        break;
                    }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, `serviceGrupoEconomicoImport.importList()`, e, true);
                throw new Error(`modules | Participante | Error ${e.message}`);
            }
        });
    }
    static __log(message) {
        return __awaiter(this, void 0, void 0, function* () {
            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} ${message}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
        });
    }
    static __error(message, e) {
        return __awaiter(this, void 0, void 0, function* () {
            yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, message, e, true);
        });
    }
    static __dbExecute(scriptSQL) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myDatabase = new modelbase_1.clsBase();
                yield myDatabase.myDataBase.pag.Execute(scriptSQL);
            }
            catch (e) {
                this.__error(`serviceGrupoEconomicoImport.__dbExecute()`, e);
                throw new Error(`modules | Participante | Error ${e.message}`);
            }
        });
    }
}
exports.default = serviceGrupoEconomicoImport;
