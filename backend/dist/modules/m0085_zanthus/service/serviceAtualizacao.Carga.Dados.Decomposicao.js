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
const FLG_MODULO = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ DECOMPOSICAO (JS ServiceAtualizacao.tabDecomposicao e Insumo)";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE = ``;
/*  ____________________________________________________________________________________________*/
const modelbase_1 = require("../../../model/modelbase");
const tbZanthusTabProdutoDecomposicao_1 = __importDefault(require("../tbs/tbZanthusTabProdutoDecomposicao"));
const tbZanthusTabProdutoDecomposicaoInsum_1 = __importDefault(require("../tbs/tbZanthusTabProdutoDecomposicaoInsum"));
class serviceZanthusAtualizacaoDadosDecomposicao {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            yield serviceAtualizacaoDadosDecomposicao.start(parametro);
            yield serviceAtualizacaoDadosDecomposicaoInsum.start(parametro);
        });
    }
}
exports.default = serviceZanthusAtualizacaoDadosDecomposicao;
class serviceAtualizacaoDadosDecomposicao {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let i = 0;
            let icount = 0;
            let icountTotal = 0;
            let ilimite_reg_bloq_update = 200;
            let sql = ``;
            try {
                let myclsBase = new modelbase_1.clsBase();
                let listTabDecomposicao = yield this.getList_Decomposicao(parametro);
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabDecomposicao Total de itens para processamento: ${listTabDecomposicao.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let listTabREGRAICMS = listTabDecomposicao;
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabDecomposicao Total de itens para processamento: ${listTabREGRAICMS.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                i = 0;
                icount = 0;
                icountTotal = listTabREGRAICMS.length;
                ilimite_reg_bloq_update = myclsBase.myDataBase.MAX_UPDATE_DEFAULT;
                sql = ``;
                modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualização TabDecomposicao MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                try {
                    for (var _d = true, listTabDecomposicao_1 = __asyncValues(listTabDecomposicao), listTabDecomposicao_1_1; listTabDecomposicao_1_1 = yield listTabDecomposicao_1.next(), _a = listTabDecomposicao_1_1.done, !_a; _d = true) {
                        _c = listTabDecomposicao_1_1.value;
                        _d = false;
                        const item = _c;
                        sql += item.ZanthusPostGre_CRUD();
                        i++;
                        icount++;
                        if (i >= ilimite_reg_bloq_update) {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando  atualizaTabDecomposicao | - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                            sql = ``;
                            i = 0;
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listTabDecomposicao_1.return)) yield _b.call(listTabDecomposicao_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql !== ``) {
                    yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO Tab Decomposicao', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizacao Tab Decomposicao finalizada - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static getList_Decomposicao(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_2, _b, _c;
            let listTabDecomposicao = [];
            try {
                let myDataBase = new modelbase_1.clsBase();
                let resultTabDecomposicao = yield myDataBase.myDataBase.pag.DataGet(this.scriptSql_Decomposicao(parametro));
                try {
                    for (var _d = true, _e = __asyncValues(Object.entries(resultTabDecomposicao)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [key, value] = _c;
                        let itemTbZanthusTab_Decomposicao = new tbZanthusTabProdutoDecomposicao_1.default();
                        itemTbZanthusTab_Decomposicao.binding(value);
                        listTabDecomposicao.push(itemTbZanthusTab_Decomposicao);
                        if (process.env.ZANTHUS_TIPO_CARGA_LOG && process.env.ZANTHUS_TIPO_CARGA_LOG == "1") {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Produto: ${itemTbZanthusTab_Decomposicao.pr_cdproduto} - ${itemTbZanthusTab_Decomposicao.prb_cdprodutobluesoft}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG_TESTE);
                        }
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO getList', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizacao - ${listTabDecomposicao.length} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                return listTabDecomposicao;
            }
        });
    }
    static scriptSql_Decomposicao(parametro) {
        let sqlscript = ``;
        sqlscript =
            `select 	a.pr_cdproduto				
                        ,	a.prb_cdprodutobluesoft						
                        ,	a.preg_cdbarra								
                        ,	a.cod_loja 	
                        ,   coalesce(a.controle,'000') as controle
                        ,	a.cod_mercadoria
                        ,	forma_decomposicao 
                        ,	tipo_decomposicao 
                        ,	a.usuario 
                        ,	a.data_cadastro 
                        ,	coalesce(a.data_ultima_alteracao, current_timestamp) as data_ultima_alteracao
                from 		TbZanthustab_produto_decomposicao  a
                inner join  tbzanthustab_mercadoria  		   me on me.pr_cdproduto = a.pr_cdproduto 
                                                                 and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                inner join  tbproduto 						   pr on pr.pr_cdproduto = me.pr_cdproduto 												
                where		1 = 1 `;
        if (parametro.cod_mercadoria && parametro.cod_mercadoria != '') {
            sqlscript += ` and me.cod_mercadoria = '${parametro.cod_mercadoria}' `;
        }
        /*
        if (parametro.carga_uuid && parametro.carga_uuid != '') {
            sqlscript += ` and me.cod_mercadoria in (select cod_mercadoria from tbzanthus_carga_produto where carga_uuid = '${parametro.carga_uuid}') `
        }*/
        return sqlscript;
    }
}
class serviceAtualizacaoDadosDecomposicaoInsum {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_3, _b, _c;
            let i = 0;
            let icount = 0;
            let icountTotal = 0;
            let ilimite_reg_bloq_update = 200;
            let sql = ``;
            try {
                let myclsBase = new modelbase_1.clsBase();
                let listTabDecomposicao = yield this.getList_Decomposicao(parametro);
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando DECOMPOSICAO INSUM Total de itens para processamento: ${listTabDecomposicao.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let listTabREGRAICMS = listTabDecomposicao;
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando Tab DECOMPOSICAO INSUM Total de itens para processamento: ${listTabREGRAICMS.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                i = 0;
                icount = 0;
                icountTotal = listTabREGRAICMS.length;
                ilimite_reg_bloq_update = myclsBase.myDataBase.MAX_UPDATE_DEFAULT;
                sql = ``;
                modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualização DECOMPOSICAO INSUM MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                try {
                    for (var _d = true, listTabDecomposicao_2 = __asyncValues(listTabDecomposicao), listTabDecomposicao_2_1; listTabDecomposicao_2_1 = yield listTabDecomposicao_2.next(), _a = listTabDecomposicao_2_1.done, !_a; _d = true) {
                        _c = listTabDecomposicao_2_1.value;
                        _d = false;
                        const item = _c;
                        sql += item.ZanthusPostGre_CRUD();
                        i++;
                        icount++;
                        if (i >= ilimite_reg_bloq_update) {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando  DECOMPOSICAO INSUM | - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                            sql = ``;
                            i = 0;
                        }
                    }
                }
                catch (e_3_1) { e_3 = { error: e_3_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listTabDecomposicao_2.return)) yield _b.call(listTabDecomposicao_2);
                    }
                    finally { if (e_3) throw e_3.error; }
                }
                if (sql !== ``) {
                    yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO Tab DECOMPOSICAO INSUM ATUALIZAÇÃO', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizacao Tab DECOMPOSICAO INSUM finalizada - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static getList_Decomposicao(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_4, _b, _c;
            let listTabDecomposicao = [];
            try {
                let myDataBase = new modelbase_1.clsBase();
                let resultTabDecomposicaoInsum = yield myDataBase.myDataBase.pag.DataGet(this.scriptSql_DecomposicaoInsum(parametro));
                try {
                    for (var _d = true, _e = __asyncValues(Object.entries(resultTabDecomposicaoInsum)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [key, value] = _c;
                        let itemTbZanthusTab_DecomposicaoInsum = new tbZanthusTabProdutoDecomposicaoInsum_1.default();
                        itemTbZanthusTab_DecomposicaoInsum.binding(value);
                        listTabDecomposicao.push(itemTbZanthusTab_DecomposicaoInsum);
                        if (process.env.ZANTHUS_TIPO_CARGA_LOG && process.env.ZANTHUS_TIPO_CARGA_LOG == "1") {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Produto: ${itemTbZanthusTab_DecomposicaoInsum.pr_cdproduto} - ${itemTbZanthusTab_DecomposicaoInsum.prb_cdprodutobluesoft}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG_TESTE);
                        }
                    }
                }
                catch (e_4_1) { e_4 = { error: e_4_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_4) throw e_4.error; }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO getList', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizacao DECOMPOSICAO INSUM - ${listTabDecomposicao.length} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                return listTabDecomposicao;
            }
        });
    }
    static scriptSql_DecomposicaoInsum(parametro) {
        let sqlscript = ``;
        sqlscript =
            `select 	a.pr_cdproduto				
                        ,	a.prb_cdprodutobluesoft						
                        ,	a.preg_cdbarra_insumo							
                        ,	a.cod_loja 	
                        ,   coalesce(a.controle,'000') as controle
                        ,	a.cod_mercadoria
                        ,   a.cod_insumo
                        ,	coalesce(percentual_insumo,0) as percentual_insumo
                        ,	coalesce(quantidade_insumo,0) as quantidade_insumo
                        ,	a.usuario 
                        ,	a.data_cadastro 
                        ,	coalesce(a.data_ultima_alteracao, current_timestamp) as data_ultima_alteracao
                from 		TbZanthustab_produto_decomposicao_insum  a
                inner join  tbzanthustab_mercadoria  		         me on me.pr_cdproduto = a.pr_cdproduto 
                                                                       and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                inner join  tbproduto 						         pr on pr.pr_cdproduto = me.pr_cdproduto 												
                where		1 = 1 `;
        if (parametro.cod_mercadoria && parametro.cod_mercadoria != '') {
            sqlscript += ` and me.cod_mercadoria = '${parametro.cod_mercadoria}' `;
        }
        /*
        if (parametro.carga_uuid && parametro.carga_uuid != '') {
            sqlscript += ` and me.cod_mercadoria in (select cod_mercadoria from tbzanthus_carga_produto where carga_uuid = '${parametro.carga_uuid}') `
        }*/
        return sqlscript;
    }
}
