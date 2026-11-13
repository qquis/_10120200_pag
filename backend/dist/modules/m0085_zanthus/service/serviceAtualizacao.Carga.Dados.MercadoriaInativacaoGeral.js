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
Object.defineProperty(exports, "__esModule", { value: true });
/*  CONSTANTES _________________________________________________________________________________*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ TABMERCADORIA - INATIVACAO (JS ServiceAtualizacao.tabMercadoria)";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE = ``;
/*  ____________________________________________________________________________________________*/
const modelbase_1 = require("../../../model/modelbase");
class serviceZanthusAtualizacaoDadosMercadoriaInativacaoGeral {
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
                let listTabMercadoria = yield this.getList(parametro);
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabMercadoria Total de itens para processamento: ${listTabMercadoria.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                i = 0;
                icount = 0;
                icountTotal = listTabMercadoria.length;
                ilimite_reg_bloq_update = myclsBase.myDataBase.MAX_UPDATE_DEFAULT;
                sql = ``;
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualização TabMercadoria MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                try {
                    for (var _d = true, listTabMercadoria_1 = __asyncValues(listTabMercadoria), listTabMercadoria_1_1; listTabMercadoria_1_1 = yield listTabMercadoria_1.next(), _a = listTabMercadoria_1_1.done, !_a; _d = true) {
                        _c = listTabMercadoria_1_1.value;
                        _d = false;
                        const item = _c;
                        sql += `UPDATE TAB_MERCADORIA 
                               SET FLGINATIVO = 'S' 
                               ,   DATA_ULTIMA_ALTERACAO = CURRENT_DATE
                            WHERE COD_MERCADORIA = '${item.cod_mercadoria}'; `;
                        i++;
                        icount++;
                        if (i >= ilimite_reg_bloq_update) {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabMercadoria - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                            sql = ``;
                            i = 0;
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listTabMercadoria_1.return)) yield _b.call(listTabMercadoria_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql !== ``) {
                    yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO atualizaTabMercadoria', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizacao TabMercadoria finalizada - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static getList(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let listTabMercadoria = [];
            try {
                let myDataBase = new modelbase_1.clsBase();
                let listMercadoria = yield myDataBase.myDataBase.pag.DataGet(this.scriptSql(parametro));
                listTabMercadoria = Object.keys(listMercadoria);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO getList', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizacao - ${listTabMercadoria.length} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                return listTabMercadoria;
            }
        });
    }
    static scriptSql(parametro) {
        let sqlscript = ``;
        sqlscript = ` SELECT lpad(i.prbg_cdbarra_pk, 14, '0') as cod_mercadoria
                        from   tbprodutobluesoft_gtins  i
                        inner join  tbprodutobluesoft        prb on prb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
                        inner join  tbproduto_subgrupo       sb on sb.prg_cdgrupo = prb.prb_cdsubgrupo 
                        inner join  tbproduto_grupo          gr on gr.prg_cdgrupo = sb.prg_cdgrupo
                        inner join  tbproduto_secao          sc on sc.prs_cdsecao = gr.prs_cdsecao
                        inner join  tbproduto_departamento    dp on dp.prd_cddepartamento = sc.prd_cddepartamento
                        where       1 = 1
                        and         prb.prb_status = 'false'
                        and         dp.prd_habilita_integracao_zanthus = 'true'
                        `;
        return sqlscript;
    }
}
exports.default = serviceZanthusAtualizacaoDadosMercadoriaInativacaoGeral;
