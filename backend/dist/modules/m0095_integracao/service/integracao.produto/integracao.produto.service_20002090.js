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
const api_1 = __importDefault(require("../../../Apis/bluesoftApi/api"));
const modelintegracao_produto_1 = __importDefault(require("../../model/modelintegracao_produto"));
const modelProdutoBluesoft_1 = __importDefault(require("../../../m0021_produtobluesoft/model/modelProdutoBluesoft"));
const integracao_produto_service_default_1 = __importDefault(require("./integracao.produto.service_default"));
const service_1 = __importDefault(require("../../../../modules/m0021_produtobluesoft/service/service"));
const modelbase_1 = require("../../../../model/modelbase");
let myBlueSoftApi = new api_1.default();
class integracaoProdutoService_20002090_ImporteAPI_Produto extends integracao_produto_service_default_1.default {
    constructor(item) {
        super(item);
    }
    obterProdutosPendentes(service) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let mylist = [];
            try {
                let result = {};
                yield modelbase_1.clsTools.pagConsole(`Integração de Produtos | Tipo: ${this.integracao_tipo.sis_batch_cd}`, false, false, "M0095");
                switch (this.integracao_tipo.sis_batch_cd) {
                    case 95100: //PRODUTOS GERAIS
                        result = yield myBlueSoftApi.produto.listall();
                        break;
                    case 95101: //PRODUTOS GERAIS
                        result = yield myBlueSoftApi.produto.listall();
                        break;
                    case 95102: //PRODUTOS PENDENTES -- AJUSTADO EM 03/07/2026
                        result = yield myBlueSoftApi.produto.listPendenteHoje();
                        break;
                    default:
                        result = yield myBlueSoftApi.produto.listUltAlteracaoD1();
                        break;
                }
                try {
                    for (var _d = true, _e = __asyncValues(Object.entries(result)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [key, value] = _c;
                        let myitem = new modelintegracao_produto_1.default();
                        myitem.ItemObjectIntegracao = value;
                        myitem.pr_cdproduto = 0;
                        myitem.prb_cdprodutobluesoftunitario = value.produtoUnitarioKey;
                        myitem.prb_cdprodutobluesoft = value.produtoKey;
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
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0095', 'integracao..obterProdutosPendentes', e, false, "", "M0095");
            }
            finally {
                return mylist;
            }
        });
    }
    getStrCRUDPostGre(item) {
        return __awaiter(this, void 0, void 0, function* () {
            let mprodutobluesoft = new modelProdutoBluesoft_1.default();
            mprodutobluesoft.LerOsDadosDaAPI(item);
            let sqlX = ``;
            try {
                switch (this.integracao_tipo.sis_batch_cd) {
                    case 95100: //PRODUTOS GERAIS
                        sqlX = yield mprodutobluesoft.SqlDeAtualizacaoGeralProdutoBluesoftApi("DBINSERT");
                        break;
                    case 95101: //PRODUTOS GERAIS
                        sqlX = yield mprodutobluesoft.SqlDeAtualizacaoGeralProdutoBluesoftApi("DBINSERT");
                        break;
                    case 95102: //PRODUTOS PENDENTES
                        sqlX = yield mprodutobluesoft.SqlDeAtualizacaoGeralProdutoBluesoftApi("DBUPDATE");
                        break;
                    default:
                        sqlX = yield mprodutobluesoft.SqlDeAtualizacaoGeralProdutoBluesoftApi();
                        break;
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0095', 'integracao..getStrCRUDPostGre', e, false, "", "M0095");
            }
            finally {
                return sqlX;
            }
        });
    }
    Finalizar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield service_1.default.ProcessarImportacoes.start({});
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0095', 'integracao..Finalizar', e, false, "", "M0095");
            }
        });
    }
}
exports.default = integracaoProdutoService_20002090_ImporteAPI_Produto;
