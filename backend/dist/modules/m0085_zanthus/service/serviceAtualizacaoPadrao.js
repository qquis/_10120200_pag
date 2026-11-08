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
const FLG_MODULO = "M0085 ZANTHUS - Service | CARGA PADRÃO";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE = ``;
/*  ____________________________________________________________________________________________*/
const modelbase_1 = require("../../../model/modelbase");
const service_1 = __importDefault(require("./service"));
const service_SistemaLog_1 = __importDefault(require("../../m9020_sistema_log/service/service.SistemaLog"));
const model_zanthus_produto_1 = __importDefault(require("../model/model_zanthus_produto"));
const report_ZanthusTab_1 = __importDefault(require("../report/report.ZanthusTab"));
class serviceAtualizacaoGeral {
    static start(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let resultadoCarga = {
                    integracao_tipo_cd: 0,
                    integracao_tipo_descricao: "NÃO IDENTIFICADA",
                    tipoCarga: parametros.TipoCompleta ? `COMPLETA` : `PARCIAL`,
                    integracao_pendente_qtde: 0,
                    integracao_qtde_promocional: 0,
                    numero_voucher_atual: 0
                };
                /*Chamando o metodo de Preparação dos dados
                -------------------------------------------------------------------------------------
                -------------------------------------------------------------------------------------
                */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Chamando o método PrepararDadosZanthusNaBasePag`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let myZanthusService = new service_1.default();
                yield myZanthusService.PrepararDadosZanthusNaBasePag();
                /*Obtendo os produtos Pendentes
                -------------------------------------------------------------------------------------
                -------------------------------------------------------------------------------------
                */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Chamando o método ObterProdutosPendentesDeIntegracao`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let ListaDeProdutosPendentesDeIntegracao = yield this.ObterProdutosPendentesDeIntegracao();
                resultadoCarga.integracao_pendente_qtde = ListaDeProdutosPendentesDeIntegracao.length;
                /*Processando os produtos Pendentes
                -------------------------------------------------------------------------------------
                -------------------------------------------------------------------------------------
                */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Chamando o método ProcessarProdutosPendentesDeIntegracao`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield this.ProcessarProdutosPendentesDeIntegracao(ListaDeProdutosPendentesDeIntegracao);
                /*Finalização da CARGA - METODO FINALIZAR
                -------------------------------------------------------------------------------------
                -------------------------------------------------------------------------------------
                */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Chamando o método finalizar`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield this.finalizar();
                /*Conferindo o Voucher
                -------------------------------------------------------------------------------------
                -------------------------------------------------------------------------------------
                */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Conferindo o Voucher`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let numeroVoucherAtual = parseInt(modelbase_1.clsTools._datemomentDateToStr(new Date(), `YYYYMMDD`));
                let qtdePromocional = yield myZanthusService.ZeusRetailConferirVoucher({ cod_voucher: numeroVoucherAtual });
                resultadoCarga.integracao_qtde_promocional = qtdePromocional;
                resultadoCarga.numero_voucher_atual = numeroVoucherAtual;
                /*Retornando o resultado da carga
                -------------------------------------------------------------------------------------
                -------------------------------------------------------------------------------------
                */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - FINALIZANDO CARGA -Retornando o resultado da carga`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                return resultadoCarga;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`${FLG_MODULO}`, 'start', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static ObterProdutosPendentesDeIntegracao() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let mylistZanthusProdutoPendenteIntegracao = [];
            try {
                let myDATABASE = new modelbase_1.clsBase();
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
                        where 1 = 1 
                                and coalesce(ix.integracao_produto_seq, 0) <> 0 
                                and ix.integracao_status_cd = 2
                                `;
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
                            where 1 = 1 
                                and coalesce(ix.integracao_produto_seq, 0) <> 0 
                                and ix.integracao_status_cd = 2
                            `;
                script_PRODUTOS += `
                            group by  pr.pr_cdproduto
                                    ,   pr.prb_cdprodutobluesoft 
                                    ,   pr.prb_cdprodutobluesoft  
                                    ,   pr.pr_descricao 
                                    ,   coalesce(ix.integracao_produto_seq, 0)
                                    ,   cast(20008501 as int) 

                `;
                script_PRODUTOS += " order by 1 asc ";
                let myreportZanthusProduto = new report_ZanthusTab_1.default();
                /*OBTENDO OS EANS PENDENTES POR TABELA ZANTHUS
                -------------------------------------------------------------------------------------
                -------------------------------------------------------------------------------------
                */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Obtendo os EANS pendentes de integração | codigo integração = 20008501 (Método: ObterProdutosPendentesDeIntegracao)`, false, false);
                yield myreportZanthusProduto.Select({
                    ProdutosPendentesDeIntegracao: true,
                    integracao_tipo_cd: 20008501
                });
                /*OBTENDO OS CODIGOS PENDENTES
                -------------------------------------------------------------------------------------
                -------------------------------------------------------------------------------------
                */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Obtendo os CODIGOS pendentes de integração | codigo integração = 20008501 (Método: ObterProdutosPendentesDeIntegracao)`, false, false);
                let ProdutosPendentesDeIntegracao = yield myDATABASE.myDataBase.pag.DataGet(script_PRODUTOS);
                /*PROCESSANDO OS PRODUTOS PENDENTES DE INTEGRAÇÃO
                -------------------------------------------------------------------------------------
                -------------------------------------------------------------------------------------
                */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Processando Códigos/EANS | codigo integração = 20008501 (Método: ObterProdutosPendentesDeIntegracao)`, false, false);
                if (myreportZanthusProduto.listTabMercadoria.length > 0) {
                    try {
                        for (var _d = true, _e = __asyncValues(Object.entries(ProdutosPendentesDeIntegracao)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                            _c = _f.value;
                            _d = false;
                            const [key, value] = _c;
                            let myitem = new model_zanthus_produto_1.default();
                            yield myitem.binding(value);
                            yield myitem.binding_mercadoria(myreportZanthusProduto.listTabMercadoria, myreportZanthusProduto.listTabRegrasIcms, myreportZanthusProduto.listTabMercadoriaTipoVenda, myreportZanthusProduto.listTabMercadoriaTipoVendaQtde, myreportZanthusProduto.listTabProdutoDecomposicao, myreportZanthusProduto.listTabProdutoDecomposicaoInsum);
                            if (myitem.ListTabMercadoria.length > 0) {
                                mylistZanthusProdutoPendenteIntegracao.push(myitem);
                            }
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
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`${FLG_MODULO}`, 'serviceAtualizacaoPadrao', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
            }
            finally {
                return mylistZanthusProdutoPendenteIntegracao;
            }
        });
    }
    static ProcessarProdutosPendentesDeIntegracao(ListaDeProdutosPendentesDeIntegracao) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, ListaDeProdutosPendentesDeIntegracao_1, ListaDeProdutosPendentesDeIntegracao_1_1;
            var _b, e_2, _c, _d;
            let ZANTHUS_TIPO_CARGA_LOG = false;
            if (process.env.ZANTHUS_TIPO_CARGA_LOG && process.env.ZANTHUS_TIPO_CARGA_LOG == "1") {
                ZANTHUS_TIPO_CARGA_LOG = true;
                modelbase_1.clsTools.pagConsole(`_ Carga ZANTHUS(POSTGRE) | Tipo de Log de Carga Ativado: ${ZANTHUS_TIPO_CARGA_LOG} `);
            }
            let myDATABASE = new modelbase_1.clsBase();
            let sqlScript = ``;
            let numeroMaximo = 100;
            let numeroCONTROLE_ITEM = 0;
            let numeroBloco = 1;
            let numeroTotalBloco = Math.ceil(ListaDeProdutosPendentesDeIntegracao.length / numeroMaximo);
            try {
                try {
                    for (_a = true, ListaDeProdutosPendentesDeIntegracao_1 = __asyncValues(ListaDeProdutosPendentesDeIntegracao); ListaDeProdutosPendentesDeIntegracao_1_1 = yield ListaDeProdutosPendentesDeIntegracao_1.next(), _b = ListaDeProdutosPendentesDeIntegracao_1_1.done, !_b; _a = true) {
                        _d = ListaDeProdutosPendentesDeIntegracao_1_1.value;
                        _a = false;
                        let myitem = _d;
                        if (ZANTHUS_TIPO_CARGA_LOG) {
                            yield modelbase_1.clsTools.pagConsole(`_ Carga ZANTHUS(POSTGRE) [Pendente] Processando _ Produto ${myitem.prb_cdprodutobluesoft}`);
                        }
                        if (myitem.PostGreSqlScriptUpdate.trim() !== ``) {
                            sqlScript += myitem.PostGreSqlScriptUpdate;
                        }
                        else {
                            yield modelbase_1.clsTools.pagConsole(`_ Carga ZANTHUS(POSTGRE) [Pendente] Processando _ Produto ${myitem.prb_cdprodutobluesoft} NÃO POSSUI DADOS PARA ATUALIZAR`);
                        }
                        numeroCONTROLE_ITEM += 1;
                        if (numeroCONTROLE_ITEM >= numeroMaximo) {
                            yield service_SistemaLog_1.default.Registrar.registrarLogResumido(0, "CARGA-NEW", `_ Carga ZANTHUS(POSTGRE) Proc Bloco ${numeroBloco}/${numeroTotalBloco} `, 0, 0);
                            if (sqlScript.trim() !== ``) {
                                yield myDATABASE.myDataBase.zanthusPostgre.Execute(sqlScript);
                            }
                            sqlScript = ``;
                            numeroCONTROLE_ITEM = 0;
                            numeroBloco += 1;
                        }
                        modelbase_1.clsTools._wait(15);
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_a && !_b && (_c = ListaDeProdutosPendentesDeIntegracao_1.return)) yield _c.call(ListaDeProdutosPendentesDeIntegracao_1);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
                if (sqlScript.trim() !== ``) {
                    yield service_SistemaLog_1.default.Registrar.registrarLogResumido(0, "CARGA-NEW", `_ Carga ZANTHUS(POSTGRE) Proc Bloco ${numeroBloco}/${numeroTotalBloco} `, 0, 0);
                    yield myDATABASE.myDataBase.zanthusPostgre.Execute(sqlScript);
                    sqlScript = ``;
                    numeroCONTROLE_ITEM = 0;
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`${FLG_MODULO}`, 'serviceAtualizacaoPadrao', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static finalizar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myZanthuService = new service_1.default();
                myZanthuService.serviceLogTAG = "M0095_INT_PROD_20008501";
                yield modelbase_1.clsTools.pagConsole(`Atualizando TAB VOUCHERS`);
                yield myZanthuService.AtualizarVoucherPromocionais();
                yield modelbase_1.clsTools.pagConsole(`zanthus.carga loja`);
                yield myZanthuService.ZeusRetailCargaOxan();
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`${FLG_MODULO}`, 'finalizar', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
}
exports.default = serviceAtualizacaoGeral;
