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
const modelfc_regrafiscalNfceProduto_1 = __importDefault(require("../model/modelfc_regrafiscalNfceProduto"));
const modelfc_regrafiscalNfceProdutoNCM_1 = __importDefault(require("../model/modelfc_regrafiscalNfceProdutoNCM"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 10050011;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0040-Fiscal | ServiceFiscalImportarRegraNfceProduto";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
class serviceFiscalImportarRegraNfeProduto {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield serviceFiscalImportarRegraNfeProduto.serviceFiscalImportarRelacaoRegraNfeProduto();
                yield serviceFiscalImportarRegraNfeProduto.serviceFiscalImportarRegraNfe();
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(FLG_MODULO, "start", e);
            }
        });
    }
    static serviceFiscalImportarRelacaoRegraNfeProduto() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            try {
                const myBase = new modelbase_1.clsBase();
                let ipagCount = 10000;
                let i = 0;
                let iNumeroMaximoRegistorsPorUpdate = 100;
                let sql = ``;
                /* limpa a identificação de produtos com nfe encontrados
                ------------------------------------------------------------------------------------------------------------------------
                ------------------------------------------------------------------------------------------------------------------------
                ------------------------------------------------------------------------------------------------------------------------
                ------------------------------------------------------------------------------------------------------------------------
    
                */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando limpeza de registros com nfe registrada na tabela tbfc_figurafiscal_produto`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let sqlLimpa = `
                UPDATE tbfc_figurafiscal_produto
                SET   regrafiscal_nfe = 0
                    , regrafiscal_nfe_ncm = ''
                WHERE regrafiscal_nfe = 1
            `;
                yield myBase.myDataBase.pag.Execute(sqlLimpa);
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando limpeza de registros com nfe registrada na tabela tbfc_figurafiscal_produto - Concluído`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                /*
                 ------------------------------------------------------------------------------------------------------------------------
                 ------------------------------------------------------------------------------------------------------------------------
                 ------------------------------------------------------------------------------------------------------------------------
    
                */
                /* Importação do relacionamento REGRA NFE COM PRODUTO que será armazenado na tabela tbfc_figurafiscal_produto
                ------------------------------------------------------------------------------------------------------------------------
                ------------------------------------------------------------------------------------------------------------------------
                ------------------------------------------------------------------------------------------------------------------------
                ------------------------------------------------------------------------------------------------------------------------
    
                */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | RELACIONAMENTO NFE/PRODUTO - processando importação de relacionamento nfe/produto que será armazenado na tabela tbfc_figurafiscal_produto (api service/figurafiscal/atualizar-figura-produto-nfe?)`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                for (let ipag = 1; ipag <= ipagCount; ipag++) {
                    let report = yield myBase.blueSoftApi.api_get(myBase.apiUrlMape.bluesoft.fiscal_regrafiscal_pdv_nfes_produto(ipag));
                    if (report.data && report.data.length > 0) {
                        yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO}  | RELACIONAMENTO NFE/PRODUTO - Processando página ${ipag}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                        try {
                            for (var _d = true, _e = (e_1 = void 0, __asyncValues(report.data)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                                _c = _f.value;
                                _d = false;
                                const registroInfoFiscalNFE = _c;
                                let prb_cdprodutobluesoft = registroInfoFiscalNFE.produtoKey;
                                let fc_figurafiscal_cd = registroInfoFiscalNFE.codigoFiguraRegraFiscal;
                                let regrafiscal_nfe_ncm = registroInfoFiscalNFE.codigoNcm;
                                let sqlUpdateInsert = `
                                insert into tbfc_figurafiscal_produto (prb_cdprodutobluesoft, fc_figurafiscal_cd, regrafiscal_nfe_ncm,fc_figurafiscal_versao)
                                SELECT      ${prb_cdprodutobluesoft}
                                        ,   ${fc_figurafiscal_cd}
                                        ,   '${regrafiscal_nfe_ncm}'
                                        ,   0
                                WHERE NOT EXISTS (SELECT 1 FROM tbfc_figurafiscal_produto WHERE prb_cdprodutobluesoft = ${prb_cdprodutobluesoft} )
                                ;
                                UPDATE  tbfc_figurafiscal_produto
                                SET     regrafiscal_nfe = 1
                                    ,   regrafiscal_nfe_ncm = '${regrafiscal_nfe_ncm}'
                                    ,   dtlog_update = NOW()
                                WHERE prb_cdprodutobluesoft = ${prb_cdprodutobluesoft}
                                AND fc_figurafiscal_cd = ${fc_figurafiscal_cd}
                                ;
                        `;
                                sql += sqlUpdateInsert;
                                if (i >= iNumeroMaximoRegistorsPorUpdate) {
                                    yield myBase.myDataBase.pag.Execute(sql);
                                    i = 0;
                                    sql = ``;
                                }
                                i++;
                            }
                        }
                        catch (e_1_1) { e_1 = { error: e_1_1 }; }
                        finally {
                            try {
                                if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                            }
                            finally { if (e_1) throw e_1.error; }
                        }
                        if (sql !== ``) {
                            yield myBase.myDataBase.pag.Execute(sql);
                            sql = ``;
                        }
                    }
                    else {
                        /*Sair do for se não for encontrado nenhum registro no '.data'*/
                        break;
                    }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "serviceFiscalImportarRelacaoRegraNfeProduto (NFE/PRODUTO)", e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Finalizando serviceFiscalImportarRelacaoRegraNfeProduto (NFE/PRODUTO)`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static serviceFiscalImportarRegraNfe() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_2, _b, _c, _d, e_3, _e, _f, _g, e_4, _h, _j, _k, e_5, _l, _m;
            try {
                const myBase = new modelbase_1.clsBase();
                let isql = ``;
                let ipagCount = 10000;
                /*
                if (parametro.prb_cdprodutobluesoft && parametro.prb_cdprodutobluesoft != '') {
                    ipagCount = 1;
                }*/
                let listmodelfc_regraNfceProduto = [];
                let listmodelfc_regraNfceProdutoNCM = [];
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Lendo todos os Blocos API/NF (Por item)..`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                /*  ------------------------------------------------------------------------------------------
                    ------------------------------------------------------------------------------------------
                    ------------------------------------------------------------------------------------------
                    ------------------------------------------------------------------------------------------
                    API | LEITURA DA API (POR NCM E POR PRODUTO)
                        - So aceita PAGES >= 1
                */
                for (let ipag = 1; ipag <= ipagCount; ipag++) {
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando Bloco ${ipag}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    let report = yield myBase.blueSoftApi.api_get(myBase.apiUrlMape.bluesoft.fiscal_regrafiscal_pdv_nfes(2, true, ipag));
                    if (report.data && report.data.length > 0) {
                        try {
                            for (var _o = true, _p = (e_2 = void 0, __asyncValues(report.data)), _q; _q = yield _p.next(), _a = _q.done, !_a; _o = true) {
                                _c = _q.value;
                                _o = false;
                                const registroInfoFiscalNFE = _c;
                                if (registroInfoFiscalNFE.tipoRegistro == 'POR_NCM') {
                                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | NCM ${registroInfoFiscalNFE.ncm.codigo}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                                    let modelItemNCM = new modelfc_regrafiscalNfceProdutoNCM_1.default();
                                    modelItemNCM.LerDadosDaAPI(registroInfoFiscalNFE, 3);
                                    listmodelfc_regraNfceProdutoNCM.push(modelItemNCM);
                                }
                                if (registroInfoFiscalNFE.tipoRegistro == 'POR_PRODUTO') {
                                    if (registroInfoFiscalNFE.produtoKeys) {
                                        try {
                                            for (var _r = true, _s = (e_3 = void 0, __asyncValues(registroInfoFiscalNFE.produtoKeys)), _t; _t = yield _s.next(), _d = _t.done, !_d; _r = true) {
                                                _f = _t.value;
                                                _r = false;
                                                const produtokey = _f;
                                                let modelItem = new modelfc_regrafiscalNfceProduto_1.default();
                                                modelItem.LerDadosDaAPI(registroInfoFiscalNFE, 3);
                                                modelItem.prb_cdprodutobluesoft = produtokey;
                                                modelItem.codigo_regra_fiscal = 0;
                                                listmodelfc_regraNfceProduto.push(modelItem);
                                            }
                                        }
                                        catch (e_3_1) { e_3 = { error: e_3_1 }; }
                                        finally {
                                            try {
                                                if (!_r && !_d && (_e = _s.return)) yield _e.call(_s);
                                            }
                                            finally { if (e_3) throw e_3.error; }
                                        }
                                    }
                                }
                            }
                        }
                        catch (e_2_1) { e_2 = { error: e_2_1 }; }
                        finally {
                            try {
                                if (!_o && !_a && (_b = _p.return)) yield _b.call(_p);
                            }
                            finally { if (e_2) throw e_2.error; }
                        }
                    }
                    else {
                        yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Nenhum dado encontrado no Bloco ${ipag}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                        break;
                    }
                }
                /*  ------------------------------------------------------------------------------------------
                    ------------------------------------------------------------------------------------------
                    ------------------------------------------------------------------------------------------
                    ------------------------------------------------------------------------------------------
                    PROCESSANDO DOS DADOS LIDOS DA API - VÁRIAVEIS DE CONTROLE
                        - Os registros por produto serão armazenados diretamente na tabela tbfc_regrafiscal_nfce_produto
                */
                let sql = ``;
                let iupdate = 0;
                let iupdateRegistroPorBloco = 50;
                let blocoi = 1;
                let blocoiTotal = Math.ceil(listmodelfc_regraNfceProduto.length / iupdateRegistroPorBloco);
                /*  ------------------------------------------------------------------------------------------
                    ------------------------------------------------------------------------------------------
                    ------------------------------------------------------------------------------------------
                    ------------------------------------------------------------------------------------------
                    PROCESSANDO OS DADOS LIDOS DA API - PROCESSANDO OS REGISTROS POR PRODUTO
                        - Os registros por produto serão armazenados diretamente na tabela tbfc_regrafiscal_nfce_produto
                */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando os registros de Tributação NFE/PDV por produto | Total de Registros a processar (${listmodelfc_regraNfceProduto.length})`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                sql = ``;
                iupdate = 0;
                iupdateRegistroPorBloco = 50;
                blocoi = 1;
                blocoiTotal = Math.ceil(listmodelfc_regraNfceProduto.length / iupdateRegistroPorBloco);
                try {
                    for (var _u = true, listmodelfc_regraNfceProduto_1 = __asyncValues(listmodelfc_regraNfceProduto), listmodelfc_regraNfceProduto_1_1; listmodelfc_regraNfceProduto_1_1 = yield listmodelfc_regraNfceProduto_1.next(), _g = listmodelfc_regraNfceProduto_1_1.done, !_g; _u = true) {
                        _j = listmodelfc_regraNfceProduto_1_1.value;
                        _u = false;
                        const ifc_regranfceProduto = _j;
                        sql += ifc_regranfceProduto.sql_CRUD();
                        iupdate++;
                        if (iupdate >= iupdateRegistroPorBloco) {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando NFE/PRODUTO (Tab tbfc_regrafiscal_nfce_produto) ${blocoi} de ${blocoiTotal}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            yield myBase.myDataBase.pag.Execute(sql);
                            sql = ``;
                            iupdate = 0;
                            blocoi++;
                        }
                    }
                }
                catch (e_4_1) { e_4 = { error: e_4_1 }; }
                finally {
                    try {
                        if (!_u && !_g && (_h = listmodelfc_regraNfceProduto_1.return)) yield _h.call(listmodelfc_regraNfceProduto_1);
                    }
                    finally { if (e_4) throw e_4.error; }
                }
                if (sql.length > 0) {
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando NFE/PRODUTO (Tab tbfc_regrafiscal_nfce_produto) ${blocoi} de ${blocoiTotal}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    yield myBase.myDataBase.pag.Execute(sql);
                }
                /*  ------------------------------------------------------------------------------------------
                    ------------------------------------------------------------------------------------------
                    ------------------------------------------------------------------------------------------
                    ------------------------------------------------------------------------------------------
                    PROCESSANDO OS DADOS LIDOS DA API - PROCESSANDO OS REGISTROS POR NCM
                        - Os registros por produto serão armazenados diretamente na tabela tbfc_regrafiscal_nfce_ncm
                */
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando os registros de Tributação NFE/PDV por NCM | Total de Registros a processar (${listmodelfc_regraNfceProdutoNCM.length})`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                sql = ``;
                iupdate = 0;
                iupdateRegistroPorBloco = 50;
                blocoi = 1;
                blocoiTotal = Math.ceil(listmodelfc_regraNfceProdutoNCM.length / iupdateRegistroPorBloco);
                try {
                    for (var _v = true, listmodelfc_regraNfceProdutoNCM_1 = __asyncValues(listmodelfc_regraNfceProdutoNCM), listmodelfc_regraNfceProdutoNCM_1_1; listmodelfc_regraNfceProdutoNCM_1_1 = yield listmodelfc_regraNfceProdutoNCM_1.next(), _k = listmodelfc_regraNfceProdutoNCM_1_1.done, !_k; _v = true) {
                        _m = listmodelfc_regraNfceProdutoNCM_1_1.value;
                        _v = false;
                        const ifc_regranfceNCM = _m;
                        sql += ifc_regranfceNCM.sql_CRUD();
                        iupdate++;
                        if (iupdate >= iupdateRegistroPorBloco) {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando os registros de Tributação NFE/PDV por NCM ${blocoi} de ${blocoiTotal}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            yield myBase.myDataBase.pag.Execute(sql);
                            sql = ``;
                            iupdate = 0;
                            blocoi++;
                        }
                    }
                }
                catch (e_5_1) { e_5 = { error: e_5_1 }; }
                finally {
                    try {
                        if (!_v && !_k && (_l = listmodelfc_regraNfceProdutoNCM_1.return)) yield _l.call(listmodelfc_regraNfceProdutoNCM_1);
                    }
                    finally { if (e_5) throw e_5.error; }
                }
                if (sql.length > 0) {
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando os registros de Tributação NFE/PDV por NCM ${blocoi} de ${blocoiTotal}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    yield myBase.myDataBase.pag.Execute(sql);
                }
                /* Atualizando a tabela tbfc_regrafiscal_nfce_produto dos produtos orindos da api por ncm*/
                yield this.serviceFiscalImportarRegraNfe_ProcessarNCMProduto();
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfeProduto', e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Importação NFCE FINALIZADA`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static serviceFiscalImportarRegraNfe_ProcessarNCMProduto() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = `insert into 	tbfc_regrafiscal_nfce_produto 
                            (	    api_ncm
                                ,	pr_cdproduto 
                                ,	prb_cdprodutobluesoftunitario
                                ,	prb_cdprodutobluesoft 
                                ,	nfce_produto_tipo_cd                               			
                                ,	ncm_codigo                                        
                                ,	ncm_excecao                                       
                                ,	ncm_variacao                                      
                                ,	codigo_figura_regra_fiscal                        
                                ,	codigo_regra_fiscal                               
                                ,	cfop                                              
                                ,	icms_codigo_origem                                
                                ,	icms_codigo_tributacao                            
                                ,	icms_codigo_tributacao_final                      
                                ,	icms_percentual_diferimento                       
                                ,	icms_aliquota_interna                             
                                ,	icms_fcp_agregado                                 
                                ,	icms_fcp_segregado                                
                                ,	icms_codigo_icms                                  
                                ,	icms_reducao_aliquota_efetiva                     
                                ,	icms_aliquota_efetiva                             
                                ,	icms_aliquota                                     
                                ,	icms_reducao                                      
                                ,	icms_aliquota_final                               
                                ,	icms_csosn                                        
                                ,	icms_aliquota_desoneracao                         
                                ,	icms_decreto_de_lei                               
                                ,	icms_desconto_icms_desonerado                     
                                ,	cofins_aliquota                                   
                                ,	cofins_cst                                        
                                ,	pis_aliquota                                      
                                ,	pis_cst                                           
                                ,	ipi_aliquota                                      
                                ,	ipi_cst                                           
                                ,	data_hora_geracao                                 
                                ,	data_referencia                                   
                                ,	rt_codigo_cst_ibs_cbs                             
                                ,	rt_codigo_class_trib_ibs_cbs                      
                                ,	ibs_cd                                            
                                ,	ibs_aliquota                                      
                                ,	ibs_aliquota_efetiva                              
                                ,	ibs_percentual_credito_presumido                  
                                ,	ibs_percentual_diferimento                        
                                ,	ibs_percentual_reducao                            
                                ,	ibs_aliquota_desoneracao                          
                                ,	ibs_aliquota_ad_rem                               
                                ,	ibs_percentual_credito_presumido_monofasico       
                                ,	ibs_percentual_diferimento_monofasico             
                                ,	cbs_cd                                            
                                ,	cbs_aliquota                                      
                                ,	cbs_aliquota_efetiva                              
                                ,	cbs_percentual_credito_presumido                  
                                ,	cbs_percentual_diferimento                        
                                ,	cbs_percentual_reducao                            
                                ,	cbs_aliquota_desoneracao                          
                                ,	cbs_aliquota_ad_rem                               
                                ,	cbs_percentual_credito_presumido_monofasico       
                                ,	cbs_percentual_diferimento_monofasico             

                                ,	ibs_mun_cd                                        
                                ,	ibs_mun_aliquota                                  
                                ,	ibs_mun_aliquota_efetiva                          
                                ,	ibs_mun_percentual_credito_presumido              
                                ,	ibs_mun_percentual_diferimento                    
                                ,	ibs_mun_percentual_reducao                        
                                ,	ibs_mun_aliquota_desoneracao                      
                                ,	ibs_mun_aliquota_ad_rem                           
                                ,	ibs_mun_percentual_credito_presumido_monofasico   
                                ,	ibs_mun_percentual_diferimento_monofasico   
                        ) 
                    select  1
                        ,   pr.pr_cdproduto 
                        ,	prb.prb_cdprodutobluesoftunitario
                        ,	prb.prb_cdprodutobluesoft_pk  
                        ,	ncm.nfce_produto_tipo_cd                           	
                        ,	ncm.ncm_codigo                                     
                        ,	ncm.ncm_excecao                                    
                        ,	ncm.ncm_variacao                                   
                        ,	ncm.codigo_figura_regra_fiscal                     
                        ,	ncm.codigo_regra_fiscal                            
                        ,	ncm.cfop                                           
                        ,	ncm.icms_codigo_origem                             
                        ,	ncm.icms_codigo_tributacao                         
                        ,	ncm.icms_codigo_tributacao_final                   
                        ,	ncm.icms_percentual_diferimento                    
                        ,	ncm.icms_aliquota_interna                          
                        ,	ncm.icms_fcp_agregado                              
                        ,	ncm.icms_fcp_segregado                             
                        ,	ncm.icms_codigo_icms                               
                        ,	ncm.icms_reducao_aliquota_efetiva                  
                        ,	ncm.icms_aliquota_efetiva                          
                        ,	ncm.icms_aliquota                                  
                        ,	ncm.icms_reducao                                   
                        ,	ncm.icms_aliquota_final                            
                        ,	ncm.icms_csosn                                     
                        ,	ncm.icms_aliquota_desoneracao                      
                        ,	ncm.icms_decreto_de_lei                            
                        ,	ncm.icms_desconto_icms_desonerado                  
                        ,	ncm.cofins_aliquota                                
                        ,	ncm.cofins_cst                                     
                        ,	ncm.pis_aliquota                                   
                        ,	ncm.pis_cst                                        
                        ,	ncm.ipi_aliquota                                   
                        ,	ncm.ipi_cst                                        
                        ,	ncm.data_hora_geracao                              
                        ,	ncm.data_referencia                                
                        ,	ncm.rt_codigo_cst_ibs_cbs                          
                        ,	ncm.rt_codigo_class_trib_ibs_cbs                   
                        ,	ncm.ibs_cd                                         
                        ,	ncm.ibs_aliquota                                   
                        ,	ncm.ibs_aliquota_efetiva                           
                        ,	ncm.ibs_percentual_credito_presumido               
                        ,	ncm.ibs_percentual_diferimento                     
                        ,	ncm.ibs_percentual_reducao                         
                        ,	ncm.ibs_aliquota_desoneracao                       
                        ,	ncm.ibs_aliquota_ad_rem                            
                        ,	ncm.ibs_percentual_credito_presumido_monofasico    
                        ,	ncm.ibs_percentual_diferimento_monofasico          
                        ,	ncm.cbs_cd                                         
                        ,	ncm.cbs_aliquota                                   
                        ,	ncm.cbs_aliquota_efetiva                           
                        ,	ncm.cbs_percentual_credito_presumido               
                        ,	ncm.cbs_percentual_diferimento                     
                        ,	ncm.cbs_percentual_reducao                         
                        ,	ncm.cbs_aliquota_desoneracao                       
                        ,	ncm.cbs_aliquota_ad_rem                            
                        ,	ncm.cbs_percentual_credito_presumido_monofasico    
                        ,	ncm.cbs_percentual_diferimento_monofasico          

                        ,	ncm.ibs_mun_cd                                     
                        ,	ncm.ibs_mun_aliquota                               
                        ,	ncm.ibs_mun_aliquota_efetiva                       
                        ,	ncm.ibs_mun_percentual_credito_presumido           
                        ,	ncm.ibs_mun_percentual_diferimento                 
                        ,	ncm.ibs_mun_percentual_reducao                     
                        ,	ncm.ibs_mun_aliquota_desoneracao                   
                        ,	ncm.ibs_mun_aliquota_ad_rem                        
                        ,	ncm.ibs_mun_percentual_credito_presumido_monofasico
                        ,	ncm.ibs_mun_percentual_diferimento_monofasico   

                    from 		tbfc_regrafiscal_nfce_ncm 	NCM
                    inner join 	tbprodutobluesoft 			prb on cast(prb.prb_ncm as varchar(8)) = cast(ncm.ncm_codigo as varchar(8)) 
                    inner join  tbproduto					pr on pr.prb_cdprodutobluesoft = prb.prb_cdprodutobluesoftunitario 
                    inner join  tbproduto_subgrupo			sg on sg.prsg_cdsubgrupo = prb.prb_cdsubgrupo 
                    inner join  tbproduto_grupo 			g on g.prg_cdgrupo = sg.prg_cdgrupo 
                    inner join  tbproduto_secao             s on  s.prs_cdsecao = g.prs_cdsecao 
                    inner join  tbproduto_departamento 		d on d.prd_cddepartamento = s.prd_cddepartamento 
                    where 1 = 1
                    and   d.prd_habilita_integracao_zanthus = 'true'
                    and   not exists (		select 1 
                                            from   tbfc_regrafiscal_nfce_produto x
                                            where  1 = 1
                                            and    x.nfce_produto_tipo_cd = 3
                                            and    x.prb_cdprodutobluesoft = prb.prb_cdprodutobluesoft_pk 
                                            and    ncm.nfce_produto_tipo_cd = x.nfce_produto_tipo_cd
                                    )
                    ;

                    update tbfc_regrafiscal_nfce_produto a

                    set         dtlog_update = current_timestamp
                            ,   pr_cdproduto = pr.pr_cdproduto
                            ,	prb_cdprodutobluesoftunitario = prb.prb_cdprodutobluesoftunitario
                            ,	nfce_produto_tipo_cd = ncm.nfce_produto_tipo_cd
                            ,	ncm_codigo = ncm.ncm_codigo
                            ,	ncm_excecao = ncm.ncm_excecao
                            ,	ncm_variacao = ncm.ncm_variacao
                            ,	codigo_figura_regra_fiscal = ncm.codigo_figura_regra_fiscal
                            ,	codigo_regra_fiscal = ncm.codigo_regra_fiscal
                            ,	cfop = ncm.cfop                   
                            ,	icms_codigo_origem = ncm.icms_codigo_origem                                
                            ,	icms_codigo_tributacao = ncm.icms_codigo_tributacao                            
                            ,	icms_codigo_tributacao_final = ncm.icms_codigo_tributacao_final                      
                            ,	icms_percentual_diferimento = ncm.icms_percentual_diferimento                       
                            ,	icms_aliquota_interna = ncm.icms_aliquota_interna                             
                            ,	icms_fcp_agregado = ncm.icms_fcp_agregado                                 
                            ,	icms_fcp_segregado = ncm.icms_fcp_segregado                                
                            ,	icms_codigo_icms = ncm.icms_codigo_icms                                  
                            ,	icms_reducao_aliquota_efetiva = ncm.icms_reducao_aliquota_efetiva                     
                            ,	icms_aliquota_efetiva = ncm.icms_aliquota_efetiva                             
                            ,	icms_aliquota = ncm.icms_aliquota                                     
                            ,	icms_reducao = ncm.icms_reducao                                      
                            ,	icms_aliquota_final = ncm.icms_aliquota_final                               
                            ,	icms_csosn = ncm.icms_csosn                                        
                            ,	icms_aliquota_desoneracao = ncm.icms_aliquota_desoneracao                         
                            ,	icms_decreto_de_lei = ncm.icms_decreto_de_lei                               
                            ,	icms_desconto_icms_desonerado = ncm.icms_desconto_icms_desonerado                     
                            ,	cofins_aliquota = ncm.cofins_aliquota                                   
                            ,	cofins_cst = ncm.cofins_cst                                        
                            ,	pis_aliquota = ncm.pis_aliquota                                             
                            ,	pis_cst  = ncm.pis_cst                                        
                            ,	ipi_aliquota = ncm.ipi_aliquota                                      
                            ,	ipi_cst = ncm.ipi_cst                                           
                            ,	data_hora_geracao = ncm.data_hora_geracao                                 
                            ,	data_referencia = ncm.data_referencia                                   
                            ,	rt_codigo_cst_ibs_cbs = ncm.rt_codigo_cst_ibs_cbs                             
                            ,	rt_codigo_class_trib_ibs_cbs = ncm.rt_codigo_class_trib_ibs_cbs                      
                            ,	ibs_cd = ncm.ibs_cd                                            
                            ,	ibs_aliquota = ncm.ibs_aliquota                                      
                            ,	ibs_aliquota_efetiva = ncm.ibs_aliquota_efetiva                              
                            ,	ibs_percentual_credito_presumido = ncm.ibs_percentual_credito_presumido                  
                            ,	ibs_percentual_diferimento = ncm.ibs_percentual_diferimento                        
                            ,	ibs_percentual_reducao = ncm.ibs_percentual_reducao                            
                            ,	ibs_aliquota_desoneracao = ncm.ibs_aliquota_desoneracao                          
                            ,	ibs_aliquota_ad_rem = ncm.ibs_aliquota_ad_rem                               
                            ,	ibs_percentual_credito_presumido_monofasico = ncm.ibs_percentual_credito_presumido_monofasico      
                            ,	ibs_percentual_diferimento_monofasico = ncm.ibs_percentual_diferimento_monofasico             
                            ,	cbs_cd = ncm.cbs_cd                                            
                            ,	cbs_aliquota = ncm.cbs_aliquota                                      
                            ,	cbs_aliquota_efetiva = ncm.cbs_aliquota_efetiva                              
                            ,	cbs_percentual_credito_presumido = ncm.cbs_percentual_credito_presumido                  
                            ,	cbs_percentual_diferimento = ncm.cbs_percentual_diferimento                             
                            ,	cbs_percentual_reducao = ncm.cbs_percentual_reducao                            
                            ,	cbs_aliquota_desoneracao = ncm.cbs_aliquota_desoneracao                          
                            ,	cbs_aliquota_ad_rem = ncm.cbs_aliquota_ad_rem                               
                            ,	cbs_percentual_credito_presumido_monofasico = ncm.cbs_percentual_credito_presumido_monofasico       
                            ,	cbs_percentual_diferimento_monofasico = ncm.cbs_percentual_diferimento_monofasico               
                            ,	ibs_mun_cd  = ncm.ibs_mun_cd                                      
                            ,	ibs_mun_aliquota = ncm.ibs_mun_aliquota                                 
                            ,	ibs_mun_aliquota_efetiva = ncm.ibs_mun_aliquota_efetiva                          
                            ,	ibs_mun_percentual_credito_presumido = ncm.ibs_mun_percentual_credito_presumido              
                            ,	ibs_mun_percentual_diferimento = ncm.ibs_mun_percentual_diferimento                    
                            ,	ibs_mun_percentual_reducao = ncm.ibs_mun_percentual_reducao                        
                            ,	ibs_mun_aliquota_desoneracao = ncm.ibs_mun_aliquota_desoneracao                      
                            ,	ibs_mun_aliquota_ad_rem = ncm.ibs_mun_aliquota_ad_rem                           
                            ,	ibs_mun_percentual_credito_presumido_monofasico = ncm.ibs_mun_percentual_credito_presumido_monofasico   
                            ,	ibs_mun_percentual_diferimento_monofasico   = ncm.ibs_mun_percentual_diferimento_monofasico
                    from 		tbfc_regrafiscal_nfce_ncm 	NCM
                    inner join 	tbprodutobluesoft 			prb on cast(prb.prb_ncm as varchar(8)) = cast(ncm.ncm_codigo as varchar(8)) 
                    inner join  tbproduto					pr on pr.prb_cdprodutobluesoft = prb.prb_cdprodutobluesoftunitario 
                    inner join  tbproduto_subgrupo			sg on sg.prsg_cdsubgrupo = prb.prb_cdsubgrupo 
                    inner join  tbproduto_grupo 			g on g.prg_cdgrupo = sg.prg_cdgrupo 
                    inner join  tbproduto_secao             s on  s.prs_cdsecao = g.prs_cdsecao 
                    inner join  tbproduto_departamento 		d on d.prd_cddepartamento = s.prd_cddepartamento 
                    where 1 = 1
                      and a.prb_cdprodutobluesoft = prb.prb_cdprodutobluesoft_pk
                      and a.api_ncm = 1
                      and d.prd_habilita_integracao_zanthus = 'true'
                    ;


				 `;
                const myBase = new modelbase_1.clsBase();
                yield myBase.myDataBase.pag.Execute(sql);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfeProduto', e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
}
exports.default = serviceFiscalImportarRegraNfeProduto;
