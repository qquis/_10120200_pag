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
const FLG_MODULO = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ TABTIPOVENDA (JS ServiceAtualizacao.tabMercadoria)";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE = ``;
/*  ____________________________________________________________________________________________*/
const modelbase_1 = require("../../../model/modelbase");
const tbZanthusTabMercadoriaTipoVenda_1 = __importDefault(require("../tbs/tbZanthusTabMercadoriaTipoVenda"));
class serviceZanthusAtualizacaoDadosTipoVenda {
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
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Iniciando processamento ${(parametro === null || parametro === void 0 ? void 0 : parametro.carga_uuid) !== '' ? `| Código da Carga ${parametro.carga_uuid}` : ''}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let listTabTipoVenda = yield this.getList(parametro);
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabTipoVenda Total de itens para processamento: ${listTabTipoVenda.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                i = 0;
                icount = 0;
                icountTotal = listTabTipoVenda.length;
                ilimite_reg_bloq_update = myclsBase.myDataBase.MAX_UPDATE_DEFAULT;
                sql = ``;
                /*
                let listCodMercadoria : string[] = []
                for (const item of listTabTipoVenda) {
                    if (item.tab_pre_cd == 2) {
                        listCodMercadoria.push(`'${item.cod_mercadoria}'`)
                    }
                }
                let stringListCodMercadoria = listCodMercadoria.join(',')
                this.LimpaDadosTipoVendaPromocional({ ListMercadoriaEmPromocao: stringListCodMercadoria })
                */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualização TabMercadoria MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                try {
                    for (var _d = true, listTabTipoVenda_1 = __asyncValues(listTabTipoVenda), listTabTipoVenda_1_1; listTabTipoVenda_1_1 = yield listTabTipoVenda_1.next(), _a = listTabTipoVenda_1_1.done, !_a; _d = true) {
                        _c = listTabTipoVenda_1_1.value;
                        _d = false;
                        const item = _c;
                        sql += item.ZanthusPostGre_CRUD();
                        i++;
                        icount++;
                        if (i >= ilimite_reg_bloq_update) {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabTipoVenda - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                            sql = ``;
                            i = 0;
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listTabTipoVenda_1.return)) yield _b.call(listTabTipoVenda_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql !== ``) {
                    yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO atualizaTabTipoVenda', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizacao TabTipoVenda finalizada - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static LimpaDadosTipoVendaPromocional(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myclsBase = new modelbase_1.clsBase();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Limpando dados de TipoVenda Promocional...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let sql_delete_1 = `delete from tab_mercadoria_tipo_venda where cod_tipo_venda = 2; `;
                let sql_delete_2 = `delete from tab_mercadoria_tipo_venda_qtde where cod_tipo_venda = 2; `;
                if (parametro.ListMercadoriaEmPromocao && parametro.ListMercadoriaEmPromocao.length > 0) {
                    sql_delete_1 = `delete from tab_mercadoria_tipo_venda where cod_tipo_venda = 2 and cod_mercadoria not in(${parametro.ListMercadoriaEmPromocao}); `;
                    sql_delete_2 = `delete from tab_mercadoria_tipo_venda_qtde where cod_tipo_venda = 2 and cod_mercadoria not in(${parametro.ListMercadoriaEmPromocao}); `;
                    yield myclsBase.myDataBase.zanthusPostgre.Execute(sql_delete_1);
                    yield myclsBase.myDataBase.zanthusPostgre.Execute(sql_delete_2);
                }
                yield myclsBase.myDataBase.zanthusPostgre.Execute(sql_delete_1);
                yield myclsBase.myDataBase.zanthusPostgre.Execute(sql_delete_2);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO LimpaDadosTipoVendaPromocional', e);
            }
        });
    }
    static getList(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_2, _b, _c;
            let listTabTipoVenda = [];
            try {
                let myClsBase = new modelbase_1.clsBase();
                let result = yield myClsBase.myDataBase.pag.DataGet(this.scriptSql(parametro));
                try {
                    for (var _d = true, _e = __asyncValues(Object.entries(result)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [key, value] = _c;
                        let itemTbZanthusTabMercadoriaTipoVenda = new tbZanthusTabMercadoriaTipoVenda_1.default();
                        itemTbZanthusTabMercadoriaTipoVenda.binding(value);
                        listTabTipoVenda.push(itemTbZanthusTabMercadoriaTipoVenda);
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
                yield modelbase_1.clsTools.PagErrorException(`M0085_Zanthus`, `serviceAtualizacao.Dados.TipoVenda | getList`, e);
            }
            finally {
                return listTabTipoVenda;
            }
            return listTabTipoVenda;
        });
    }
    static scriptSql(parametro) {
        let sqlscript = ``;
        sqlscript =
            `select 	a.tab_pre_cd 
                        ,	a.pr_cdproduto				
                        ,	a.prb_cdprodutobluesoft						
                        ,	a.preg_cdbarra								
                        ,	a.cod_loja 									
                        ,	a.controle 									
                        ,	a.cod_mercadoria
                        ,	a.cod_tipo_venda 
                        ,	a.usuario 
                        ,	a.data_cadastro 
                        ,	coalesce(a.data_ultima_alteracao, current_timestamp) as data_ultima_alteracao
                        ,	a.preco_unitario 
                        ,	a.percentual_comissao_vendedor
                        ,   coalesce(a.preco_anterior,0) as preco_anterior
                from 		tbzanthustab_mercadoria_tipo_venda a
                inner join  tbzanthustab_mercadoria  		   me on me.pr_cdproduto = a.pr_cdproduto 
                                                                 and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                                                                 and me.cod_mercadoria = a.cod_mercadoria
                inner join  tbproduto 						   pr on pr.pr_cdproduto = me.pr_cdproduto 												
                where		1 = 1 
                `;
        if (parametro.cod_mercadoria && parametro.cod_mercadoria != '') {
            sqlscript += ` and me.cod_mercadoria = '${parametro.cod_mercadoria}' `;
        }
        if (parametro.carga_uuid && parametro.carga_uuid != '') {
            sqlscript += ` and ( 
                                            me.cod_mercadoria in (select cod_mercadoria from tbzanthus_carga_produto where carga_uuid = '${parametro.carga_uuid}') 
                                         or a.tab_pre_cd = 2  
                                        )
                                            `;
        }
        return sqlscript;
    }
}
exports.default = serviceZanthusAtualizacaoDadosTipoVenda;
