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
const FLG_MODULO = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ TABREGRASFISCAIS (JS ServiceAtualizacao.tabRegrasFiscais)";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE = ``;
/*  ____________________________________________________________________________________________*/
const modelbase_1 = require("../../../model/modelbase");
const tbZanthusTabRegraIcms_1 = __importDefault(require("../tbs/tbZanthusTabRegraIcms"));
class serviceZanthusAtualizacaoDadosRegraFiscal {
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
                let listTabREGRAICMS = yield this.getList(parametro);
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabRegrasIcms Total de itens para processamento: ${listTabREGRAICMS.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                i = 0;
                icount = 0;
                icountTotal = listTabREGRAICMS.length;
                ilimite_reg_bloq_update = myclsBase.myDataBase.MAX_UPDATE_DEFAULT;
                sql = ``;
                modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualização TabRegrasIcms MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                try {
                    for (var _d = true, listTabREGRAICMS_1 = __asyncValues(listTabREGRAICMS), listTabREGRAICMS_1_1; listTabREGRAICMS_1_1 = yield listTabREGRAICMS_1.next(), _a = listTabREGRAICMS_1_1.done, !_a; _d = true) {
                        _c = listTabREGRAICMS_1_1.value;
                        _d = false;
                        const item = _c;
                        sql += item.ZanthusPostGre_CRUD();
                        i++;
                        icount++;
                        if (i >= ilimite_reg_bloq_update) {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando  atualizaTabRegrasIcms | - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                            sql = ``;
                            i = 0;
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listTabREGRAICMS_1.return)) yield _b.call(listTabREGRAICMS_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql !== ``) {
                    yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                }
                if (sql !== ``) {
                    yield myclsBase.myDataBase.zanthusPostgre.Execute(sql);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'MÉTODO Tab Regra ICMS', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizacao Tab Regra ICMS finalizada - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static getList(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_2, _b, _c;
            let listTAB_REGRA_ICMS = [];
            try {
                let myDataBase = new modelbase_1.clsBase();
                let resultTabRegraIcms = yield myDataBase.myDataBase.pag.DataGet(this.scriptSql(parametro));
                try {
                    for (var _d = true, _e = __asyncValues(Object.entries(resultTabRegraIcms)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [key, value] = _c;
                        let itemTbZanthusTab_Mercadoria = new tbZanthusTabRegraIcms_1.default();
                        itemTbZanthusTab_Mercadoria.binding(value);
                        listTAB_REGRA_ICMS.push(itemTbZanthusTab_Mercadoria);
                        if (process.env.ZANTHUS_TIPO_CARGA_LOG && process.env.ZANTHUS_TIPO_CARGA_LOG == "1") {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Produto: ${itemTbZanthusTab_Mercadoria.pr_cdproduto} - ${itemTbZanthusTab_Mercadoria.descricao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG_TESTE);
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
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizacao - ${listTAB_REGRA_ICMS.length} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                return listTAB_REGRA_ICMS;
            }
        });
    }
    static scriptSql(parametro) {
        let sqlscript = ``;
        sqlscript = ` select     a.pr_cdproduto
                                ,   a.prb_cdprodutobluesoft
                                ,   a.cod_regras_icms             as  cod_regras_icms
                                ,	a.cod_loja 
                                ,	a.descricao 
                                ,	a.prioridade 
                                ,	a.flg_registro 
                                ,	a.cod_ncm_ini                 as  cod_ncm_ini
                                ,	a.cod_ncm_fim                 as  cod_ncm_final
                                ,	a.cod_mercadoria 
                                ,	a.uf_origem 
                                ,	a.uf_destino 
                                ,	coalesce(a.aliquota,0) as aliquota
                                ,	a.cst
                                ,	a.perc_substituicao 
                                ,	coalesce(a.perc_reducao,0) as perc_reducao 
                                ,	a.flg_tipo_imposto 
                                ,	a.flg_revenda 
                                ,	a.dta_val_inicial 
                                ,	a.dta_val_final 
                                ,	a.cst_orig
                                ,	a.usuario 
                                ,	a.data_cadastro 
                                ,	a.data_ultima_alteracao 
                                ,	a.aliquota_interestadual 
                                ,	a.valor_imposto 
                                ,	a.tipo_lista_st 
                                ,	a.perc_reducao_st 
                                ,	a.perc_diferimento 
                                ,	a.exigibilidade_iss 
                                ,	a.flg_incentivo_fiscal_iss 
                                ,	a.tipo_documento
                                ,   a.codigo_beneficio_fiscal
                                ,   coalesce(a.cod_class_tributaria,0) as cod_class_tributaria
                                ,   coalesce(a.per_cred_presumido_ibs_mono,0) as per_cred_presumido_ibs_mono
                                ,   coalesce(a.per_cred_presumido_cbs_mono,0) as per_cred_presumido_cbs_mono
                from 		tbzanthustab_regra_icms            a
                inner join  tbzanthustab_mercadoria  		   me on me.pr_cdproduto = a.pr_cdproduto 
                                                                 and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                                                                 and me.cod_mercadoria = a.cod_mercadoria
                inner join  tbproduto 						   pr on pr.pr_cdproduto = me.pr_cdproduto 												
                where		1 = 1 `;
        if (parametro.cod_mercadoria && parametro.cod_mercadoria != '') {
            sqlscript += ` and me.cod_mercadoria = '${parametro.cod_mercadoria}' `;
        }
        if (parametro.carga_uuid && parametro.carga_uuid != '') {
            sqlscript += ` and  me.cod_mercadoria in (select cod_mercadoria from tbzanthus_carga_produto where carga_uuid = '${parametro.carga_uuid}') `;
        }
        sqlscript += ` UNION `;
        /* PRODUTOS CESTA */
        sqlscript += `select     a.pr_cdproduto
                                ,   a.prb_cdprodutobluesoft
                                ,   a.cod_regras_icms             as  cod_regras_icms
                                ,	a.cod_loja 
                                ,	a.descricao 
                                ,	a.prioridade 
                                ,	a.flg_registro 
                                ,	a.cod_ncm_ini                 as  cod_ncm_ini
                                ,	a.cod_ncm_fim                 as  cod_ncm_final
                                ,	a.cod_mercadoria 
                                ,	a.uf_origem 
                                ,	a.uf_destino 
                                ,	coalesce(a.aliquota,0) as aliquota
                                ,	a.cst
                                ,	a.perc_substituicao 
                                ,	coalesce(a.perc_reducao,0) as perc_reducao 
                                ,	a.flg_tipo_imposto 
                                ,	a.flg_revenda 
                                ,	a.dta_val_inicial 
                                ,	a.dta_val_final 
                                ,	a.cst_orig
                                ,	a.usuario 
                                ,	a.data_cadastro 
                                ,	a.data_ultima_alteracao 
                                ,	a.aliquota_interestadual 
                                ,	a.valor_imposto 
                                ,	a.tipo_lista_st 
                                ,	a.perc_reducao_st 
                                ,	a.perc_diferimento 
                                ,	a.exigibilidade_iss 
                                ,	a.flg_incentivo_fiscal_iss 
                                ,	a.tipo_documento
                                ,   a.codigo_beneficio_fiscal
                                ,   coalesce(a.cod_class_tributaria,0) as cod_class_tributaria
                                ,   coalesce(a.per_cred_presumido_ibs_mono,0) as per_cred_presumido_ibs_mono
                                ,   coalesce(a.per_cred_presumido_cbs_mono,0) as per_cred_presumido_cbs_mono
                from 		tbzanthustab_regra_icms            a
										
                where		1 = 1 
                  and       a.cod_mercadoria in (select cod_insumo from TbZanthustab_produto_decomposicao_insum)
                
                `;
        return sqlscript;
    }
}
exports.default = serviceZanthusAtualizacaoDadosRegraFiscal;
