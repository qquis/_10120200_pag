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
const FLG_MODULO = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ TABTIPOVENDAQTDE (JS ServiceAtualizacao.tabTipoVendaQtde)";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE = ``;
/*  ____________________________________________________________________________________________*/
const modelbase_1 = require("../../../model/modelbase");
const tbZanthusTabMercadoriaTipoVendaQtde_1 = __importDefault(require("../tbs/tbZanthusTabMercadoriaTipoVendaQtde"));
class serviceZanthusAtualizacaoDadosTipoVendaQtde {
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
                let listTabTipoVendaQtde = yield this.getList(parametro);
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabTipoVendaQtde Total de itens para processamento: ${listTabTipoVendaQtde.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                i = 0;
                icount = 0;
                icountTotal = listTabTipoVendaQtde.length;
                ilimite_reg_bloq_update = myclsBase.myDataBase.MAX_UPDATE_DEFAULT;
                sql = ``;
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualização TabTipoVendaQtde MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                try {
                    for (var _d = true, listTabTipoVendaQtde_1 = __asyncValues(listTabTipoVendaQtde), listTabTipoVendaQtde_1_1; listTabTipoVendaQtde_1_1 = yield listTabTipoVendaQtde_1.next(), _a = listTabTipoVendaQtde_1_1.done, !_a; _d = true) {
                        _c = listTabTipoVendaQtde_1_1.value;
                        _d = false;
                        const item = _c;
                        sql += item.ZanthusPostGre_CRUD();
                        i++;
                        icount++;
                        if (i >= ilimite_reg_bloq_update) {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabTipoVendaQtde - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                            sql = ``;
                            i = 0;
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listTabTipoVendaQtde_1.return)) yield _b.call(listTabTipoVendaQtde_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql !== ``) {
                    yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO atualizaTabTipoVendaQtde', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizacao TabTipoVendaQtde finalizada - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static getList(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_2, _b, _c;
            let listTabTipoVendaQtde = [];
            try {
                let myClsBase = new modelbase_1.clsBase();
                let result = yield myClsBase.myDataBase.pag.DataGet(this.scriptSql(parametro));
                try {
                    for (var _d = true, _e = __asyncValues(Object.entries(result)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [key, value] = _c;
                        let itemTbZanthusTabTipoVendaQtde = new tbZanthusTabMercadoriaTipoVendaQtde_1.default();
                        itemTbZanthusTabTipoVendaQtde.binding(value);
                        listTabTipoVendaQtde.push(itemTbZanthusTabTipoVendaQtde);
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
                yield modelbase_1.clsTools.PagErrorException(`M0085_Zanthus`, `serviceAtualizacao.Dados.TipoVendaQtde | getList`, e);
            }
            finally {
                return listTabTipoVendaQtde;
            }
        });
    }
    static scriptSql(parametro) {
        let sqlscript = ``;
        sqlscript =
            `select 		a.pr_cdproduto
                                        ,	a.prb_cdprodutobluesoft 
                                        ,	a.preg_cdbarra 
                                        ,	a.cod_loja
                                        ,	a.cod_mercadoria
                                        ,	a.cod_tipo_venda
                                        ,	a.qtde_venda
                                        --,	a.flag_geral
                                        ,	a.preco_unitario
                                        ,	a.perc_desconto
                                        --,	a.flag_ativo
                                        ,	a.Dth_inclusao
                                        ,	a.Dth_alteracao
                                        ,	a.Idt_usuario_alteracao
                            from   		tbzanthustab_mercadoria_tipo_venda_qtde a
                            inner join  tbzanthustab_mercadoria  		   me on me.pr_cdproduto = a.pr_cdproduto 
                                                                            and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                            inner join  tbproduto 						   pr on pr.pr_cdproduto = me.pr_cdproduto 												
                            where		1 = 1 
                            `;
        if (parametro.cod_mercadoria && parametro.cod_mercadoria != '') {
            sqlscript += ` and me.cod_mercadoria = '${parametro.cod_mercadoria}' `;
        }
        if (parametro.carga_uuid && parametro.carga_uuid != '') {
            sqlscript += ` and me.cod_mercadoria in (select cod_mercadoria from tbzanthus_carga_produto where carga_uuid = '${parametro.carga_uuid}') `;
        }
        return sqlscript;
    }
}
exports.default = serviceZanthusAtualizacaoDadosTipoVendaQtde;
