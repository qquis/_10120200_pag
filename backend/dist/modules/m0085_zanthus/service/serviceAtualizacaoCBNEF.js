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
const service_1 = __importDefault(require("./service"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 10050011;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0085-ZANTHUS-Service | Atualizacao CBENEF CODIGO BENEFICIO FISCAL";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
class serviceAtualizacaoCbenef {
    static start() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            try {
                /* PREPARANDO BASE ZANTHUS */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - START (Preparando BASE ZANTHUS)`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let myZanthusService = new service_1.default();
                yield myZanthusService.PrepararDadosZanthusNaBasePag(true);
                /* TAB MERCADORIA */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - START Iniciando Atualização CBENEF - TAB MERCADORIA`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield this.AtualizarCbenefTabMercadoria(parametros);
                /* TAB REGRA ICMS */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - START Iniciando Atualização CBENEF - TAB REGRA ICMS`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield this.AtualizarCbenefTabRegraIcms(parametros);
                /* AJUSTE CST SEM CBENEF */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - START Iniciando Atualização AJUSTE CST SEM CBENEF`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield this.AjusteCstSemCbenef(parametros);
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Finalizado com SUCESSO - AJUSTE CBENEF`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`${FLG_MODULO}`, 'start', e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);
                throw new Error(`F0085 | ${FLG_MODULO}  ${e} `);
            }
        });
    }
    static AtualizarCbenefTabMercadoria(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Finalizado com SUCESSO - TAB MERCADORIA (LENDO BASE PAG)`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let mydatabase = new modelbase_1.clsBase();
                let ScriptCbenefTabMercadoria = `

                                    SELECT  pr_cdproduto, 
                                            prb_cdprodutobluesoft, 
                                            cod_mercadoria,
                                            descricao, 
                                            coalesce(codigo_beneficio_fiscal,'') as codigo_beneficio_fiscal, 
                                            cod_situacao_tributaria as cod_situacao_tributaria
                                        FROM   tbzanthustab_mercadoria 
                                    where  cod_situacao_tributaria in ('40','20')

            `;
                let resultCbenefTabMercadoria = yield mydatabase.myDataBase.pag.DataGet(ScriptCbenefTabMercadoria);
                let i = 0;
                let totalBlocoInsert = 50;
                let blocoInsert = 0;
                let scriptInsertCbenef = ``;
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Iniciando atualização de TAB MERCADORIA`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                try {
                    for (var _d = true, resultCbenefTabMercadoria_1 = __asyncValues(resultCbenefTabMercadoria), resultCbenefTabMercadoria_1_1; resultCbenefTabMercadoria_1_1 = yield resultCbenefTabMercadoria_1.next(), _a = resultCbenefTabMercadoria_1_1.done, !_a; _d = true) {
                        _c = resultCbenefTabMercadoria_1_1.value;
                        _d = false;
                        const item = _c;
                        scriptInsertCbenef +=
                            ` UPDATE tab_mercadoria
                    SET codigo_beneficio_fiscal = '${item.codigo_beneficio_fiscal}'
                    where  cod_mercadoria = '${item.cod_mercadoria}' ; 
                  
                  `;
                        i++;
                        if (i >= totalBlocoInsert) {
                            blocoInsert++;
                            modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - (TAB_MERCADORIA) Executando bloco de atualização de Cbenef. Total de registros no bloco: ${blocoInsert}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            yield mydatabase.myDataBase.zanthusPostgre.Execute(scriptInsertCbenef);
                            scriptInsertCbenef = ``;
                            i = 0;
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = resultCbenefTabMercadoria_1.return)) yield _b.call(resultCbenefTabMercadoria_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                scriptInsertCbenef = scriptInsertCbenef + ` 
            
                        UPDATE tab_mercadoria set codigo_beneficio_fiscal = ''
                        where lpad(cod_situacao_tributaria, 3, '0') not in ('040','020')
                        and coalesce(codigo_beneficio_fiscal,'') != '' ; 
                                                               
                        UPDATE tab_regras_icms set codigo_beneficio_fiscal = ''
                        where flg_tipo_imposto = '0'
                        and lpad(cst,3,'0') not in ('040','020')	
                                                        `;
                if (scriptInsertCbenef != ``) {
                    modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Executando bloco final e ajuste final de outras csts: ${blocoInsert}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    yield mydatabase.myDataBase.zanthusPostgre.Execute(scriptInsertCbenef);
                    scriptInsertCbenef = ``;
                    i = 0;
                }
                modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Processamento de atualização de Cbenef concluído.`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`serviceAtualizacaoCbenef`, 'start', e);
                throw new Error(`F0085 | serviceAtualizacaoCbenef  ${e} `);
            }
        });
    }
    static AtualizarCbenefTabRegraIcms(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_2, _b, _c;
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Iniciando atualização de TAB_REGRAS_ICMS`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let mydatabase = new modelbase_1.clsBase();
                let ScriptCbenefTabRegraIcms = `

                                    select cod_mercadoria
                                         , flg_revenda
                                         , flg_tipo_imposto
                                         , CST 
                                         , codigo_beneficio_fiscal
                                    from tbzanthustab_regra_icms  
                                    where  lpad(cst,3,'0') in ('040','020')
                                      and  flg_tipo_imposto = '0'

            `;
                let resultCbenefTabRegraIcms = yield mydatabase.myDataBase.pag.DataGet(ScriptCbenefTabRegraIcms);
                let i = 0;
                let totalBlocoInsert = 50;
                let blocoInsert = 0;
                let scriptInsertCbenef = ``;
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Preparando atualização de TAB_REGRAS_ICMS`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                try {
                    for (var _d = true, resultCbenefTabRegraIcms_1 = __asyncValues(resultCbenefTabRegraIcms), resultCbenefTabRegraIcms_1_1; resultCbenefTabRegraIcms_1_1 = yield resultCbenefTabRegraIcms_1.next(), _a = resultCbenefTabRegraIcms_1_1.done, !_a; _d = true) {
                        _c = resultCbenefTabRegraIcms_1_1.value;
                        _d = false;
                        const item = _c;
                        scriptInsertCbenef +=
                            ` UPDATE tab_regras_icms
                    SET    codigo_beneficio_fiscal = '${item.codigo_beneficio_fiscal}'
                    where  cod_mercadoria = '${item.cod_mercadoria}' 
                      and  flg_revenda = '${item.flg_revenda}'
                      and  flg_tipo_imposto = '${item.flg_tipo_imposto}'
                      ;
                  `;
                        i++;
                        if (i >= totalBlocoInsert) {
                            blocoInsert++;
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Executando bloco de atualização de Cbenef (TAB_REGRAS_ICMS). Total de registros no bloco: ${blocoInsert}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            yield mydatabase.myDataBase.zanthusPostgre.Execute(scriptInsertCbenef);
                            scriptInsertCbenef = ``;
                            i = 0;
                        }
                        yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Finalizando atualização de TAB_REGRAS_ICMS`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = resultCbenefTabRegraIcms_1.return)) yield _b.call(resultCbenefTabRegraIcms_1);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`serviceAtualizacaoCbenef`, 'start', e);
                throw new Error(`F0085 | serviceAtualizacaoCbenef  ${e} `);
            }
        });
    }
    static AjusteCstSemCbenef(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | AjusteCstSemCbenef - Iniciando ajuste de CST sem Cbenef`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let sql = `
            
                        UPDATE tab_mercadoria set codigo_beneficio_fiscal = ''
                        where lpad(cod_situacao_tributaria, 3, '0') not in ('040','020')
                        and coalesce(codigo_beneficio_fiscal,'') != '' ; 
                                                               
                        UPDATE tab_regras_icms set codigo_beneficio_fiscal = ''
                        where flg_tipo_imposto = '0'
                        and lpad(cst,3,'0') not in ('040','020')	
                                                        `;
                let mydatabase = new modelbase_1.clsBase();
                yield mydatabase.myDataBase.zanthusPostgre.Execute(sql);
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | AjusteCstSemCbenef - Ajuste de CST sem Cbenef concluído.`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`${FLG_MODULO}`, 'AjusteCstSemCbenef', e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
}
exports.default = serviceAtualizacaoCbenef;
