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
const api_1 = __importDefault(require("../../Apis/vipApi/api"));
//import modelParticipante from '../model/model_participante';
const modelparticipanteVip_1 = __importDefault(require("../model/modelparticipanteVip"));
class serviceParticipanteVipImport {
    static start(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let resultSucess = 0;
            try {
                modelbase_1.clsTools.pagConsole(`F0011 - Participante - Service serviceParticipanteVipImport - Inicializado`);
                let parametrosVIP = {
                    page: 1,
                    data_ultima_alteracao_ini: parametros.data_ultima_alteracao_ini,
                    data_ultima_alteracao_fim: parametros.data_ultima_alteracao_fim
                };
                if (parametros.id) {
                    parametrosVIP = {
                        page: 1,
                        id: parametros.id
                    };
                }
                let numeroPaginas = 0;
                if (parametrosVIP.id) {
                    numeroPaginas = 1;
                }
                else {
                    numeroPaginas = yield api_1.default.clientes.pagination(parametrosVIP);
                    modelbase_1.clsTools.pagConsole(`F0011 - Participante - Service serviceParticipanteVipImport - Inicializado _ N de Paginas: ${numeroPaginas}`);
                }
                let i = 0;
                let maxInsert = 1;
                if (parametrosVIP.id) {
                    maxInsert = 50;
                }
                let sqlinsertBlock = '';
                for (let p = 1; p <= numeroPaginas; p++) {
                    parametrosVIP.page = p;
                    if (numeroPaginas > 1) {
                        modelbase_1.clsTools.pagConsole(`F0011 - Participante - Service serviceParticipanteVipImport Processando página ${p} de ${numeroPaginas}`);
                    }
                    let result = yield api_1.default.clientes.get(parametrosVIP);
                    try {
                        for (var _d = true, _e = (e_1 = void 0, __asyncValues(Object.entries(result))), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                            _c = _f.value;
                            _d = false;
                            const [key, value] = _c;
                            let myitem = new modelparticipanteVip_1.default();
                            myitem.vip_binding_api(value);
                            // Monta bloco de insert
                            sqlinsertBlock += myitem.vip_getSqlCrud();
                            if (i >= maxInsert) {
                                i = 0;
                                resultSucess = yield this.updateSqlBlock(sqlinsertBlock);
                                if (resultSucess == 0) {
                                    throw new Error(`Erro ao inserir bloco de Participante VIP`);
                                }
                                sqlinsertBlock = '';
                            }
                            i++;
                        }
                    }
                    catch (e_1_1) { e_1 = { error: e_1_1 }; }
                    finally {
                        try {
                            if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                        }
                        finally { if (e_1) throw e_1.error; }
                    }
                }
                if (sqlinsertBlock !== '') {
                    let resultSucess = yield this.updateSqlBlock(sqlinsertBlock);
                    if (resultSucess == 0) {
                        throw new Error(`Erro ao inserir bloco de Participante VIP`);
                    }
                }
                //list.map(item => { console.log(item.participante_vip.vip_nome) } )
                modelbase_1.clsTools.pagConsole(`F0011 - Participante - Service serviceParticipanteVipImport - Finalizado`);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`F0011 - Participante`, `serviceParticipanteVipImport.start()`, e, true);
                throw new Error(`modules | Participante | Error ${e.message}`);
            }
        });
    }
    static updateSqlBlock(sql) {
        return __awaiter(this, void 0, void 0, function* () {
            let executado = 0;
            try {
                executado = yield myBase.myDataBase.pag.Execute(sql);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modules | Participante`, `serviceParticipanteVipImport.updateSqlBlock()`, e, true);
                throw new Error(`modules | Participante | Error ${e.message}`);
            }
            finally {
                return executado;
            }
        });
    }
}
exports.default = serviceParticipanteVipImport;
