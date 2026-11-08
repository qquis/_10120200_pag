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
require("dotenv/config");
const modelbase_1 = require("../../../../model/modelbase");
const integracao_produto_service_default_1 = __importDefault(require("./integracao.produto.service_default"));
const Tools_1 = __importDefault(require("../../../../tools/Tools"));
const modelintegracao_produto_1 = __importDefault(require("../../model/modelintegracao_produto"));
const DataBase_1 = __importDefault(require("../../../../database/DataBase"));
const report_ZanthusTab_1 = __importDefault(require("../../../m0085_zanthus/report/report.ZanthusTab"));
const service_1 = __importDefault(require("../../../../modules/m0085_zanthus/service/service"));
const myDATABASE = new DataBase_1.default();
let myZanthuService = new service_1.default();
class integracaoProdutoService_20008501_Zanthus extends integracao_produto_service_default_1.default {
    constructor(item) {
        super(item);
    }
    openstart(service) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield service._serviceLogRegister(`_ Carga OpenStart | Carga de Banco Iniciando... `);
                yield myZanthuService.PrepararDadosZanthusNaBasePag();
            }
            catch (e) {
                Tools_1.default.pagConsole(`(ERROR) M0095 - Integracao | integracaoProdutoService_20008501_Zanthus 
                               Método: Inicializar
                               ${e}
                             `);
                throw new Error(`(ERROR) M0095 - Integracao | integracaoProdutoService_20008501_Zanthus 
                               Método: Inicializar
                               ${e}
                             `);
            }
        });
    }
    Inicializar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                Tools_1.default.pagConsole(`integracaoProdutoService_20008501_Zanthus inicializado `);
            }
            catch (e) {
                Tools_1.default.pagConsole(`(ERROR) M0095 - Integracao | integracaoProdutoService_20008501_Zanthus 
                                Método: Inicializar
                                ${e}
                              `);
                throw new Error(`(ERROR) M0095 - Integracao | integracaoProdutoService_20008501_Zanthus 
                                Método: Inicializar
                                ${e}
                              `);
            }
        });
    }
    obterProdutosPendentes(service) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let mylist = [];
            try {
                let myreportZanthusProduto = new report_ZanthusTab_1.default();
                //console.log(`Tipo de processo de carga escolhido ${this.integracao_tipo.sis_batch_cd}`)
                /*
                    Definindo o Select de Produtos Pendentes ou não de acordo com o código da carga
                    Carga Completa........... Cod. 85001
                    
                    Carga Produto Pendente... Cod. 85002
                */
                let myProdutosPendentes = false;
                if (this.integracao_tipo.sis_batch_cd == 85001)
                    myProdutosPendentes = false;
                if (this.integracao_tipo.sis_batch_cd == 85002)
                    myProdutosPendentes = true;
                yield myreportZanthusProduto.Select({ ProdutosPendentesDeIntegracao: myProdutosPendentes });
                let script_PRODUTOS = `
                        SELECT      pr.pr_cdproduto
                                ,   pr.prb_cdprodutobluesoft 
                                ,   pr.prb_cdprodutobluesoft  as prb_cdprodutobluesoftunitario
                                ,   pr.pr_descricao 
                                ,   coalesce(ix.integracao_produto_seq, 0) as integracao_produto_seq
                                ,   cast(20008501 as int) as integracao_tipo_cd 
                        from tbproduto pr
                        left join  tbintegracao_produto ix on ix.pr_cdproduto = pr.pr_cdproduto 
                                                          and ix.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
                                                          and ix.prb_cdprodutobluesoftunitario = pr.prb_cdprodutobluesoft
                                                          and ix.integracao_tipo_cd = 20008501
                        where 1 = 1 `;
                if (this.integracao_tipo.sis_batch_cd == 85001) {
                    // selects any product regardless of whether it is in the "integration table"
                    script_PRODUTOS += `
                                    and pr.pr_cdproduto > 0  `;
                }
                if (this.integracao_tipo.sis_batch_cd == 85002) {
                    // select only the products that are in the integration table
                    script_PRODUTOS += `
                                and coalesce(ix.integracao_produto_seq, 0) <> 0 
                                and ix.integracao_status_cd = 2
                                `;
                }
                script_PRODUTOS += `union 



                         select 	  pr.pr_cdproduto
                                    ,   pr.prb_cdprodutobluesoft 
                                    ,   pr.prb_cdprodutobluesoft  as prb_cdprodutobluesoftunitario
                                    ,   pr.pr_descricao 
                                    ,   coalesce(ix.integracao_produto_seq, 0) as integracao_produto_seq
                                    ,   cast(20008501 as int) as integracao_tipo_cd 
                            from 		tbproduto_composicao cp 
                            inner join 	tbproduto pr on pr.prb_cdprodutobluesoft = cp.prb_cdprodutobluesoft_unitario
                            left join  tbintegracao_produto ix on ix.pr_cdproduto = pr.pr_cdproduto 
                                    and ix.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
                                    and ix.prb_cdprodutobluesoftunitario = pr.prb_cdprodutobluesoft
                                    and ix.integracao_tipo_cd = 20008501
                            where 1 = 1 `;
                if (this.integracao_tipo.sis_batch_cd == 85002) {
                    // select only the products that are in the integration table
                    script_PRODUTOS += `
                                and coalesce(ix.integracao_produto_seq, 0) <> 0 
                                and ix.integracao_status_cd = 2
                                `;
                }
                script_PRODUTOS += `
                            group by  pr.pr_cdproduto
                                    ,   pr.prb_cdprodutobluesoft 
                                    ,   pr.prb_cdprodutobluesoft  
                                    ,   pr.pr_descricao 
                                    ,   coalesce(ix.integracao_produto_seq, 0)
                                    ,   cast(20008501 as int) 

                `;
                script_PRODUTOS += " order by 1 asc ";
                //console.log(script_PRODUTOS)
                let resultPRODUTO = yield myDATABASE.pag.DataGet(script_PRODUTOS);
                if (myreportZanthusProduto.listTabMercadoria.length > 0) {
                    try {
                        for (var _d = true, _e = __asyncValues(Object.entries(resultPRODUTO)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                            _c = _f.value;
                            _d = false;
                            const [key, value] = _c;
                            let myitem = new modelintegracao_produto_1.default(value);
                            yield myitem.model_zanthus_produto.binding_mercadoria(myreportZanthusProduto.listTabMercadoria, myreportZanthusProduto.listTabRegrasIcms, myreportZanthusProduto.listTabMercadoriaTipoVenda, myreportZanthusProduto.listTabMercadoriaTipoVendaQtde, myreportZanthusProduto.listTabProdutoDecomposicao, myreportZanthusProduto.listTabProdutoDecomposicaoInsum);
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
                yield Tools_1.default._wait(15);
                return mylist;
            }
            catch (e) {
                Tools_1.default.pagConsole(`(ERROR) m0095 | integracao.produto.service_20008501
                                Metodo..: obterProdutosPendentes
                                Message.: \n ${e}
                                `);
                return mylist;
            }
        });
    }
    processamentoLocal(ProdutosAProcessar, service) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                service.serviceRegistroTotal = ProdutosAProcessar.length;
                service.serviceContadorNumeroMaxUpdate = 100;
                // Carga Banco de dados Postgre
                yield service._serviceLogRegister(`_ Carga ZANTHUS(POSTGRE) Inicializando... `);
                yield this.processamentoCargaPostGre(ProdutosAProcessar, service);
            }
            catch (e) {
                Tools_1.default.PagErrorException("F0095/integracao.produto.service_2000851", "processamentoLocal", e, false, "Processamento dos Registros");
            }
        });
    }
    Finalizar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                myZanthuService.serviceLogTAG = "M0095_INT_PROD_20008501";
                yield Tools_1.default.pagConsole(`Atualizando TAB VOUCHERS`);
                yield myZanthuService.AtualizarVoucherPromocionais();
                yield Tools_1.default.pagConsole(`zanthus.carga loja`);
                yield myZanthuService.ZeusRetailCargaOxan();
                Tools_1.default.pagConsole(`Finalizando produtos pendentes`);
                yield this.FinalizarTodosIntegracaoDeProdutoPendentes();
            }
            catch (e) {
                yield Tools_1.default.pagConsole(`(ERROR) M0095 - Integracao | integracaoProdutoService_20008501_Zanthus ${e}`);
            }
        });
    }
    Event(message) {
        return __awaiter(this, void 0, void 0, function* () {
            this.emit('processamentoLocal', (message));
        });
    }
    processamentoCargaPostGre(ProdutosAProcessar, service) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, ProdutosAProcessar_1, ProdutosAProcessar_1_1;
            var _b, e_2, _c, _d;
            try {
                let ZANTHUS_TIPO_CARGA_LOG = false;
                if (process.env.ZANTHUS_TIPO_CARGA_LOG && process.env.ZANTHUS_TIPO_CARGA_LOG == "1") {
                    ZANTHUS_TIPO_CARGA_LOG = true;
                    modelbase_1.clsTools.pagConsole(`_ Carga ZANTHUS(POSTGRE) | Tipo de Log de Carga Ativado: ${ZANTHUS_TIPO_CARGA_LOG} `);
                }
                //CARGA POSTGRE COMPLETA
                if (this.integracao_tipo.sis_batch_cd == 85001) {
                    // CARGA COMPLETA BATCH 85001
                    yield service._serviceLogRegister(`_ Carga ZANTHUS(POSTGRE) [Completa] Excluindo Registros `);
                    let scriptExclusaoDadosPOST = `
                       delete from tab_mercadoria; 
                       delete from tab_mercadoria_tipo_venda; 
                       delete from tab_mercadoria_tipo_venda_qtde; 
                       delete from tab_regras_icms;
                       `;
                    yield myDATABASE.zanthusPostgre.Execute(scriptExclusaoDadosPOST);
                    yield service._serviceLogRegister(`_ Carga ZANTHUS(POSTGRE) [Completa] Processando`);
                }
                //CARGA POSTGRE PENDENTE
                if (this.integracao_tipo.sis_batch_cd == 85002) {
                    // CARGA COMPLETA BATCH 85001
                    yield service._serviceLogRegister(`_ Carga ZANTHUS(POSTGRE) [PENDENTE] Excluindo Promocionais `);
                    let scriptExclusaoDadosPOST = `
                       delete from tab_mercadoria_tipo_venda where cod_tipo_venda = 2; 
                       delete from tab_mercadoria_tipo_venda_qtde where cod_tipo_venda = 2; 
                       `;
                    yield myDATABASE.zanthusPostgre.Execute(scriptExclusaoDadosPOST);
                    yield service._serviceLogRegister(`_ Carga ZANTHUS(POSTGRE) [Pendente] Processando`);
                }
                service.myDataBase_SERVER = "ZANTHUSPOSTGRE";
                service.serviceRegistroAtual = 0;
                service.serviceContadorNumeroLinhaAtual = 0;
                let sqlScript = ``;
                let numeroMaximo = 100;
                let numeroCONTROLE_ITEM = 0;
                let numeroBloco = 1;
                let numeroTotalBloco = Math.ceil(ProdutosAProcessar.length / numeroMaximo);
                try {
                    for (_a = true, ProdutosAProcessar_1 = __asyncValues(ProdutosAProcessar); ProdutosAProcessar_1_1 = yield ProdutosAProcessar_1.next(), _b = ProdutosAProcessar_1_1.done, !_b; _a = true) {
                        _d = ProdutosAProcessar_1_1.value;
                        _a = false;
                        let myitem = _d;
                        if (this.integracao_tipo.sis_batch_cd == 85002) {
                            if (ZANTHUS_TIPO_CARGA_LOG) {
                                yield modelbase_1.clsTools.pagConsole(`_ Carga ZANTHUS(POSTGRE) [Pendente] Processando _ Produto ${myitem.model_zanthus_produto.pr_cdproduto}`);
                            }
                        }
                        if (myitem.model_zanthus_produto.PostGreSqlScriptUpdate.trim() !== ``) {
                            sqlScript += myitem.model_zanthus_produto.PostGreSqlScriptUpdate;
                        }
                        else {
                            yield modelbase_1.clsTools.pagConsole(`_ Carga ZANTHUS(POSTGRE) [Pendente] Processando _ Produto ${myitem.model_zanthus_produto.pr_cdproduto} NÃO POSSUI DADOS PARA ATUALIZAR`);
                        }
                        numeroCONTROLE_ITEM += 1;
                        if (numeroCONTROLE_ITEM >= numeroMaximo) {
                            yield service._serviceLogRegister(`_ Carga ZANTHUS(POSTGRE) Proc Bloco ${numeroBloco}/${numeroTotalBloco} `, true);
                            if (sqlScript.trim() !== ``) {
                                yield myDATABASE.zanthusPostgre.Execute(sqlScript);
                            }
                            sqlScript = ``;
                            numeroCONTROLE_ITEM = 0;
                            numeroBloco += 1;
                        }
                        yield Tools_1.default._wait(1);
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_a && !_b && (_c = ProdutosAProcessar_1.return)) yield _c.call(ProdutosAProcessar_1);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
                if (sqlScript.trim() !== ``) {
                    yield service._serviceLogRegister(`_ Carga ZANTHUS(POSTGRE) Proc Bloco (REST...) ${numeroBloco}/${numeroTotalBloco} `, true);
                    yield myDATABASE.zanthusPostgre.Execute(sqlScript);
                    sqlScript = ``;
                    numeroCONTROLE_ITEM = 0;
                }
                yield service._processCheck(true);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("F0095/integracao.produto.service_2000851", "processamentoCargaPostGre", e, false, "Processamento dos Registros");
                throw new Error(`(ERROR) M0095 - Integracao | integracaoProdutoService_20008501_Zanthus 
                                    Método: processamentoCargaPostGre
                                    ${e}
                                  `);
            }
        });
    }
}
exports.default = integracaoProdutoService_20008501_Zanthus;
