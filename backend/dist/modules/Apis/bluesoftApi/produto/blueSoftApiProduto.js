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
const modelbase_1 = require("../../../../model/modelbase");
const bluesoftApiUrl_1 = __importDefault(require("../url/bluesoftApiUrl"));
const moduleLog = 'blueApi';
class blueSoftApiProduto {
    constructor() {
        this.dataUltimaAlteracao = modelbase_1.clsTools._datemomentDatStrToDate("01/01/1900", "DD/MM/YYYY");
    }
    listall() {
        return __awaiter(this, void 0, void 0, function* () {
            return yield this.list();
        });
    }
    listUltAlteracaoD1() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield this.listalteracaoDX(1);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`Modules APIS _ BluesoftAPI`, ` bluesoftApiProduto - listUltAlteracaoD1`, e, false, ``, moduleLog);
            }
        });
    }
    listUltAlteracao15() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield this.listalteracaoDX(15);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`Modules APIS _ BluesoftAPI`, ` bluesoftApiProduto - listUltAlteracao15`, e, false, ``, moduleLog);
            }
        });
    }
    listalteracaoDX(NumDia) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const dataOntem = new Date();
                if (NumDia - 1 > 0) {
                    NumDia = NumDia - 1;
                    dataOntem.setDate(((new Date()).getDate() - NumDia));
                }
                return yield this.list(true, modelbase_1.clsTools._datemomentDateToStr(dataOntem, "DD/MM/YYYY"));
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`Modules APIS _ BluesoftAPI`, ` bluesoftApiProduto - listalteracaoDX`, e, false, ``, moduleLog);
            }
        });
    }
    listPendenteHoje() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const dataHoje = new Date();
                return yield this.list(true, modelbase_1.clsTools._datemomentDateToStr(dataHoje, "DD/MM/YYYY"));
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`Modules APIS _ BluesoftAPI`, ` bluesoftApiProduto - listPendenteHoje`, e, false, ``, moduleLog);
            }
        });
    }
    list() {
        return __awaiter(this, arguments, void 0, function* (UltimaAlteracao = false, data_alteracao = "") {
            var _a, e_1, _b, _c;
            try {
                let resultobject = [];
                let result;
                let numPag = 0;
                let numPagMax = 10000;
                const pagSize = 200;
                /*
                if (UltimaAlteracao)
                    numPagMax = 5;
                */
                for (numPag = 0; numPag <= numPagMax; numPag++) {
                    //console.log(`processando a pagina ${numPag}`)
                    yield modelbase_1.clsTools.pagConsole(`ser.Prd.blue.imp _ list | Processando a página ${numPag}`, false, false, moduleLog);
                    result = {};
                    let url = ``;
                    if (UltimaAlteracao) {
                        url = `/comercial/produtos?pageSize=${pagSize}&currentPage=${numPag}&ultimaAlteracao=${data_alteracao}`;
                    }
                    else {
                        url = `/comercial/produtos?pageSize=${pagSize}&currentPage=${numPag}`;
                    }
                    yield modelbase_1.clsTools.pagConsole(`ser.Prd.blue.imp _ list | Buscando produtos ${UltimaAlteracao ? `a partir de ${data_alteracao}` : '(sem filtro de última alteracao) url ' + url} `, false, false, moduleLog);
                    result = yield bluesoftApiUrl_1.default.api_get(url);
                    if (result.data && result.data.data.length > 0) {
                        try {
                            for (var _d = true, _e = (e_1 = void 0, __asyncValues(Object.entries(result.data.data))), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                                _c = _f.value;
                                _d = false;
                                const [key, value] = _c;
                                resultobject.push(value);
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
                    else {
                        break;
                    }
                }
                yield modelbase_1.clsTools.pagConsole(`ser.Prd.blue.imp _ list | Finalizando listagem de produtos`, false, false, moduleLog);
                return resultobject;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`Modules APIS _ BluesoftAPI`, ` bluesoftApiProduto - list`, e, false, ``, moduleLog);
            }
        });
    }
    getProduto(produtoKey) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let url = `/comercial/produtos?produtoKey=${produtoKey}`;
                const result = yield bluesoftApiUrl_1.default.api_get(url);
                return result;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`Modules APIS _ BluesoftAPI`, ` bluesoftApiProduto - getProduto`, e, false, ``, moduleLog);
            }
        });
    }
}
exports.default = blueSoftApiProduto;
