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
const modelProdutoBluesoft_1 = __importDefault(require("../model/modelProdutoBluesoft"));
const serviceProdutoBluesoftProcessarImportacoes_1 = __importDefault(require("./serviceProdutoBluesoftProcessarImportacoes"));
const api_1 = __importDefault(require("../../Apis/bluesoftApi/api"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = true;
const FLG_MODULO = "M0021-ProdutoBluesoft | IMPORT PRODUTO BLUESOFT";
const FLG_DEBUG_FILE_CONSOLE_LOG = `IMPORTACAO_PRODUTO_BLUESOFT`;
/*  ------------------------------------------------------------------------------------------- */
const moduleLog = 'M0021';
class serviceProdutoBluesoftApiImportar {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = { result: false, message: 'Erro desconhecido' };
            try {
                /*PROCESSANDO LISTA / ITEM */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Importacao Inicializada (ARQUIVO DE LOG ${FLG_DEBUG_FILE_CONSOLE_LOG})`, FLG_DEBUG_CONSOLE_LOG, false, "");
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Importacao Inicializada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Buscando informacao da API`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                if (parametro.produtoKey && parametro.produtoKey !== '') {
                    /*
                        IMPORTAÇÃO DE UM PRODUTO
                    */
                    let myDataBase = new modelbase_1.clsBase();
                    let sql = yield this.ImportarProduto(null, null, parametro.produtoKey, parametro);
                    yield myDataBase.myDataBase.pag.Execute(sql);
                }
                else {
                    /*
                    
                        IMPORTAÇÃO DE LISTA DE PRODUTOS
                    
                    */
                    modelbase_1.clsTools.pagConsole(`ser.Prd.blue.imp _ start | Lista de Produtos`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    result = yield this.importarProdutosList(parametro);
                }
                /*PROCESSANDO A IMPORTAÇÃO */
                if (parametro.NaoProcessarBasePag && parametro.NaoProcessarBasePag === 1) {
                    yield modelbase_1.clsTools.pagConsole(`Backend foi acionado para atualizar o produto porém NÃO processar a base PAG. (LOG backend.txt.${FLG_DEBUG_FILE_CONSOLE_LOG})`, false, false);
                }
                if (!parametro.NaoProcessarBasePag || parametro.NaoProcessarBasePag === 0) {
                    yield serviceProdutoBluesoftProcessarImportacoes_1.default.start({});
                    yield modelbase_1.clsTools.pagConsole(`Backend o Serviço serviceProdutoBluesoftImportar está processando a importação (LOG backend.txt.${FLG_DEBUG_FILE_CONSOLE_LOG})`, false, false);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException('M0021', 'serviceProdutoBluesoftImportar.start', e, false, JSON.stringify(parametro), FLG_DEBUG_FILE_CONSOLE_LOG);
                return { result: false, message: `Erro ao importar produto(s): ${e}` };
            }
            finally {
                return result;
            }
        });
    }
    static importarProdutosList(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let resultService = { result: false, message: 'Erro desconhecido' };
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando API tipo LIST`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let myDataBase = new modelbase_1.clsBase();
                let myBlueSoftApi = new api_1.default();
                let result = {};
                if (parametro.numeroDiasUltimaAlteracao && parametro.numeroDiasUltimaAlteracao > 0) {
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando API tipo LIST -> Importando produtos com última alteração de até ${parametro.numeroDiasUltimaAlteracao} dias`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    result = yield myBlueSoftApi.produto.listalteracaoDX(parametro.numeroDiasUltimaAlteracao);
                }
                else {
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} |  Processando API tipo LIST -> Parâmetro de Número de dias NÃO definido - LISTA GERAL`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    result = yield myBlueSoftApi.produto.listall();
                }
                let listProdutos = result;
                let sqlScript = ``;
                let iUpdateSqlCount = 0;
                let icountprocesso = 0;
                let iUpdateSqlCountMax = 100;
                let ibloc = 0;
                let icountBloc = Math.round(listProdutos.length / iUpdateSqlCountMax);
                let linhaCodigoProduto = "";
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando produtos obtidos da API - NUMERO DE PRODUTOS: ${listProdutos.length} / N DE BLOCOS: ${icountBloc}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                try {
                    for (var _d = true, listProdutos_1 = __asyncValues(listProdutos), listProdutos_1_1; listProdutos_1_1 = yield listProdutos_1.next(), _a = listProdutos_1_1.done, !_a; _d = true) {
                        _c = listProdutos_1_1.value;
                        _d = false;
                        const item = _c;
                        /*Classe de ProdutoBluesoft */
                        let myitem = new modelProdutoBluesoft_1.default();
                        /*Preenche a classe com os dados da API Bluesoft */
                        yield myitem.LerOsDadosDaAPI(item);
                        /*Obter o sqlscript da atualização
                            DBUPDATE - Atualização completa do produto (Fará a chamada a api de regra fiscal)
                            DBINSERT_API - Apenas produto bluesoft, sem a regra fiscal
                        
                        */
                        sqlScript += yield myitem.SqlDeAtualizacaoGeralProdutoBluesoftApi(`DBUPDATE`, parametro);
                        linhaCodigoProduto += myitem.prb_cdprodutobluesoft_pk + ", ";
                        icountprocesso++;
                        if (iUpdateSqlCount >= iUpdateSqlCountMax) {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Inserindo produtos importados Bloco ${ibloc}/${icountBloc} de 100 itens cada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Produtos do bloco ${ibloc}/${icountBloc} ${linhaCodigoProduto}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            linhaCodigoProduto = "";
                            yield myDataBase.myDataBase.pag.Execute(sqlScript);
                            iUpdateSqlCount = 0;
                            sqlScript = "";
                            ibloc++;
                        }
                        iUpdateSqlCount++;
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listProdutos_1.return)) yield _b.call(listProdutos_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sqlScript.trim() != "") {
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processamento fina ULTIMO BLOCO ${ibloc}/${icountBloc} de 100 itens cada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Produtos do bloco ${ibloc}/${icountBloc} ${linhaCodigoProduto}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    yield myDataBase.myDataBase.pag.Execute(sqlScript);
                    iUpdateSqlCount = 0;
                    sqlScript = "";
                    linhaCodigoProduto = "";
                }
                resultService.result = true;
                resultService.message = `${result.length} produtos importados com sucesso`;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException('M0021', FLG_MODULO, e, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
            finally {
                return resultService;
            }
        });
    }
    static ImportarProduto(myModelProdutoBluesoft_1, itemApi_1) {
        return __awaiter(this, arguments, void 0, function* (myModelProdutoBluesoft, itemApi, produtoKey = 0, parametro = {}) {
            let sql = ``;
            try {
                if (myModelProdutoBluesoft && myModelProdutoBluesoft.prb_cdprodutobluesoft_pk !== 0) {
                    /*model ja preenchido devolver apenas o script sql*/
                    sql = yield myModelProdutoBluesoft.SqlDeAtualizacaoGeralProdutoBluesoftApi(`DBUPDATE`, parametro);
                }
                if (myModelProdutoBluesoft && myModelProdutoBluesoft.prb_cdprodutobluesoft_pk === 0 && itemApi) {
                    /*model vazio, preencher com dados da api e devolver o script sql*/
                    let myitem = new modelProdutoBluesoft_1.default();
                    yield myitem.LerOsDadosDaAPI(itemApi);
                    sql = yield myitem.SqlDeAtualizacaoGeralProdutoBluesoftApi(`DBUPDATE`, parametro);
                }
                if ((myModelProdutoBluesoft === null || myModelProdutoBluesoft.prb_cdprodutobluesoft_pk === 0) && !itemApi && produtoKey !== 0) {
                    /*model vazio, preencher com dados da api usando o produtoKey e devolver o script sql*/
                    let myBlueSoftApi = new api_1.default();
                    let result = yield myBlueSoftApi.produto.getProduto(produtoKey);
                    let itemAProcessar = result.data.data[0];
                    if (itemAProcessar) {
                        let myitem = new modelProdutoBluesoft_1.default();
                        yield myitem.LerOsDadosDaAPI(itemAProcessar);
                        sql = yield myitem.SqlDeAtualizacaoGeralProdutoBluesoftApi(`DBUPDATE`, parametro);
                    }
                    else {
                        throw new Error(`Produto não encontrado na API Bluesoft para o produtoKey ${produtoKey}`);
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0021', 'serviceProdutoBluesoftImportar.getScriptImportacaoProduto', e, false, `ProdutoKey: ${produtoKey}`, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
            finally {
                return sql;
            }
        });
    }
}
exports.default = serviceProdutoBluesoftApiImportar;
