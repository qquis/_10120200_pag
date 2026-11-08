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
const Tools_1 = __importDefault(require("../../../../tools/Tools"));
const modelintegracao_tipo_1 = __importDefault(require("../../model/modelintegracao_tipo"));
const modelintegracao_produto_1 = __importDefault(require("../../model/modelintegracao_produto"));
class integracaoProdutoService_default extends modelintegracao_tipo_1.default {
    constructor(item) {
        super(item);
        if (this.integracao_tipo_info.script_select == ``)
            this.integracao_tipo_info.script_select = item.integracao_tipo_info.script_select;
    }
    openstart(service) {
        return __awaiter(this, void 0, void 0, function* () { });
    }
    Inicializar() {
        return __awaiter(this, void 0, void 0, function* () { });
    }
    obterProdutosPendentes(service) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let mylist = [];
            try {
                /*  Obter produtos pendentes PADRÃO
                
                    TIPO_EXPORT = 1 -> EXPORTAÇÃO PAG PARA OUTROS SISTEMAS
                    TIPO_EXPORT = 0 -> IMPORTACAO DE DADOS DE OUTROS SISTEMA PARA O PAG
                
                */
                if (this.integracao_tipo.tipo_export == 1) {
                    yield service._serviceLogRegister(`M0095_IControl - Produtos pendentes (Consulta Padronizada) Get`);
                    const result = yield this.integracao_tipo._Db_Pg_DataGet(this.integracao_tipo_info.script_select);
                    yield service._serviceLogRegister(`M0095_IControl - Produtos pendentes (Consulta Padronizada) Map`);
                    try {
                        for (var _d = true, _e = __asyncValues(Object.entries(result)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                            _c = _f.value;
                            _d = false;
                            const [key, value] = _c;
                            let myitem = new modelintegracao_produto_1.default(value);
                            mylist.push(myitem);
                        }
                    }
                    catch (e_1_1) { e_1 = { error: e_1_1 }; }
                    finally {
                        try {
                            if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                        }
                        finally { if (e_1) throw e_1.error; }
                    }
                    yield service._serviceLogRegister(`M0095_IControl - Produtos pendentes (Consulta Padronizada) Map ok`);
                }
            }
            catch (e) {
                yield service._serviceLogRegister(`M0095_IControl - Produtos pendentes (Consulta Padronizada) _ Error`);
                Tools_1.default.pagConsole(`M0095_IControl - Produtos pendentes (Consulta Padronizada) _ Error \n ${e}`, true);
            }
            finally {
                return mylist;
            }
        });
    }
    ApiItemProcessar(item) {
        return __awaiter(this, void 0, void 0, function* () {
            Tools_1.default.pagConsole(`Processando Integração de Produto de tipo não definido no case ${this.integracao_tipo.integracao_tipo_cd} - Produto ${item.pr_cdproduto}`, true);
        });
    }
    ApiItemValidar(item) {
        return __awaiter(this, void 0, void 0, function* () {
            return false;
        });
    }
    getStrCRUDPostGre(item) {
        return __awaiter(this, void 0, void 0, function* () { return ``; });
    }
    getStrCRUDZANTHUSPostGre(item) {
        return __awaiter(this, void 0, void 0, function* () { return ``; });
    }
    processamentoLocal(ProdutosAProcessar, service) {
        return __awaiter(this, void 0, void 0, function* () {
        });
    }
    Finalizar() {
        return __awaiter(this, void 0, void 0, function* () { });
    }
}
exports.default = integracaoProdutoService_default;
