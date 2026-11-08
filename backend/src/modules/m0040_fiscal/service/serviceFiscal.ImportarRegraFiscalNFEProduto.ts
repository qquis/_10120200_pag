
import { clsBase, clsTools } from "../../../model/modelbase";
import modelfc_regrafiscalNfceProduto from "../model/modelfc_regrafiscalNfceProduto";
import modelfc_regrafiscalNfceProdutoNCM from "../model/modelfc_regrafiscalNfceProdutoNCM";




/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 10050011
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0040-Fiscal | ServiceFiscalImportarRegraNfceProduto"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    



export default class serviceFiscalImportarRegraNfeProduto { 
    static async start(parametro: any) : Promise<void> { 

        try { 

            await serviceFiscalImportarRegraNfeProduto.serviceFiscalImportarRelacaoRegraNfeProduto();
            await serviceFiscalImportarRegraNfeProduto.serviceFiscalImportarRegraNfe();

        } catch(e) {
            clsTools.PagErrorException(FLG_MODULO, "start", e)
        }


    }

    static async serviceFiscalImportarRelacaoRegraNfeProduto() {
        try { 
            const myBase = new clsBase();



            let ipagCount: number = 10000;

            let i : number = 0;
            let iNumeroMaximoRegistorsPorUpdate: number = 100;
            let sql : string = ``;

            /* limpa a identificação de produtos com nfe encontrados 
            ------------------------------------------------------------------------------------------------------------------------
            ------------------------------------------------------------------------------------------------------------------------
            ------------------------------------------------------------------------------------------------------------------------
            ------------------------------------------------------------------------------------------------------------------------

            */
            await clsTools.pagConsole(`${FLG_MODULO} | Processando limpeza de registros com nfe registrada na tabela tbfc_figurafiscal_produto`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            let sqlLimpa = `
                UPDATE tbfc_figurafiscal_produto
                SET   regrafiscal_nfe = 0
                    , regrafiscal_nfe_ncm = ''
                WHERE regrafiscal_nfe = 1
            `;
            await myBase.myDataBase.pag.Execute(sqlLimpa);
            await clsTools.pagConsole(`${FLG_MODULO} | Processando limpeza de registros com nfe registrada na tabela tbfc_figurafiscal_produto - Concluído`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
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
            await clsTools.pagConsole(`${FLG_MODULO} | RELACIONAMENTO NFE/PRODUTO - processando importação de relacionamento nfe/produto que será armazenado na tabela tbfc_figurafiscal_produto (api service/figurafiscal/atualizar-figura-produto-nfe?)`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            for (let ipag : number = 1; ipag <= ipagCount; ipag++) {
                let report = await myBase.blueSoftApi.api_get(myBase.apiUrlMape.bluesoft.fiscal_regrafiscal_pdv_nfes_produto(ipag));
                if (report.data && report.data.length > 0)
                {
                    await clsTools.pagConsole(`${FLG_MODULO}  | RELACIONAMENTO NFE/PRODUTO - Processando página ${ipag}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    for await (const registroInfoFiscalNFE of report.data as any[]) { 

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
                        `

                        sql += sqlUpdateInsert;

                        if (i >= iNumeroMaximoRegistorsPorUpdate) {
                            await myBase.myDataBase.pag.Execute(sql);
                            i = 0;
                            sql = ``;
                        }
                        i++;
                    }
                    
                    if (sql !== ``) {
                        await myBase.myDataBase.pag.Execute(sql);
                        sql = ``;
                    }
                }
                else {
                    /*Sair do for se não for encontrado nenhum registro no '.data'*/
                    break;
                }

            }


            
        } catch(e) {
            await clsTools.PagErrorException(FLG_MODULO, "serviceFiscalImportarRelacaoRegraNfeProduto (NFE/PRODUTO)", e)
        }
        finally {
            await clsTools.pagConsole(`${FLG_MODULO} | Finalizando serviceFiscalImportarRelacaoRegraNfeProduto (NFE/PRODUTO)`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
        }
    }

    static async serviceFiscalImportarRegraNfe() {
                try  { 
            const myBase = new clsBase();
            let isql : string = ``
            
            let ipagCount : number = 10000;
            /*
            if (parametro.prb_cdprodutobluesoft && parametro.prb_cdprodutobluesoft != '') { 
                ipagCount = 1;
            }*/



            let listmodelfc_regraNfceProduto: modelfc_regrafiscalNfceProduto[] = [];
            let listmodelfc_regraNfceProdutoNCM: modelfc_regrafiscalNfceProdutoNCM[] = [];

            await clsTools.pagConsole(`${FLG_MODULO} | Lendo todos os Blocos API/NF (Por item)..`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);

            /*  ------------------------------------------------------------------------------------------
                ------------------------------------------------------------------------------------------ 
                ------------------------------------------------------------------------------------------ 
                ------------------------------------------------------------------------------------------ 
                API | LEITURA DA API (POR NCM E POR PRODUTO)                                
                    - So aceita PAGES >= 1
            */
            for (let ipag : number = 1; ipag <= ipagCount; ipag++) {
                await clsTools.pagConsole(`${FLG_MODULO} | Processando Bloco ${ipag}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);

                let report = await myBase.blueSoftApi.api_get(myBase.apiUrlMape.bluesoft.fiscal_regrafiscal_pdv_nfes(2, true, ipag))

                if (report.data && report.data.length > 0) {
                    
                    for await (const registroInfoFiscalNFE of report.data as any[]) { 
                        if (registroInfoFiscalNFE.tipoRegistro == 'POR_NCM') { 
                            await clsTools.pagConsole(`${FLG_MODULO} | NCM ${registroInfoFiscalNFE.ncm.codigo}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            let modelItemNCM = new modelfc_regrafiscalNfceProdutoNCM();
                            modelItemNCM.LerDadosDaAPI(registroInfoFiscalNFE, 3);
                            listmodelfc_regraNfceProdutoNCM.push(modelItemNCM);
                        }


                        if (registroInfoFiscalNFE.tipoRegistro == 'POR_PRODUTO') { 

                            if (registroInfoFiscalNFE.produtoKeys) {
                                for await (const produtokey of registroInfoFiscalNFE.produtoKeys as number[]) { 
                                    let modelItem = new modelfc_regrafiscalNfceProduto();
                                    modelItem.LerDadosDaAPI(registroInfoFiscalNFE, 3);
                                    modelItem.prb_cdprodutobluesoft = produtokey;
                                    modelItem.codigo_regra_fiscal = 0;
                                    listmodelfc_regraNfceProduto.push(modelItem);
                                }
                            }
                        }
                    }




                } else {
                    await clsTools.pagConsole(`${FLG_MODULO} | Nenhum dado encontrado no Bloco ${ipag}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
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



            let sql = ``
            let iupdate : number = 0;
            let iupdateRegistroPorBloco: number = 50;
            let blocoi: number = 1;
            let blocoiTotal: number = Math.ceil(listmodelfc_regraNfceProduto.length / iupdateRegistroPorBloco);





            /*  ------------------------------------------------------------------------------------------
                ------------------------------------------------------------------------------------------ 
                ------------------------------------------------------------------------------------------ 
                ------------------------------------------------------------------------------------------ 
                PROCESSANDO OS DADOS LIDOS DA API - PROCESSANDO OS REGISTROS POR PRODUTO                  
                    - Os registros por produto serão armazenados diretamente na tabela tbfc_regrafiscal_nfce_produto
            */

            await clsTools.pagConsole(`${FLG_MODULO} | Processando os registros de Tributação NFE/PDV por produto | Total de Registros a processar (${listmodelfc_regraNfceProduto.length})`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);

            sql = ``
            iupdate = 0;
            iupdateRegistroPorBloco = 50;
            blocoi = 1;
            blocoiTotal = Math.ceil(listmodelfc_regraNfceProduto.length / iupdateRegistroPorBloco);


            for await (const ifc_regranfceProduto of listmodelfc_regraNfceProduto) {
                
                sql += ifc_regranfceProduto.sql_CRUD();
                iupdate++;

                if (iupdate >= iupdateRegistroPorBloco) {
                    await clsTools.pagConsole(`${FLG_MODULO} | Processando NFE/PRODUTO (Tab tbfc_regrafiscal_nfce_produto) ${blocoi} de ${blocoiTotal}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    await myBase.myDataBase.pag.Execute(sql)
                    sql = ``;
                    iupdate = 0;
                    blocoi++;
                }

            }

            if (sql.length > 0) {
                await clsTools.pagConsole(`${FLG_MODULO} | Processando NFE/PRODUTO (Tab tbfc_regrafiscal_nfce_produto) ${blocoi} de ${blocoiTotal}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                await myBase.myDataBase.pag.Execute(sql)
            }

            /*  ------------------------------------------------------------------------------------------
                ------------------------------------------------------------------------------------------ 
                ------------------------------------------------------------------------------------------ 
                ------------------------------------------------------------------------------------------ 
                PROCESSANDO OS DADOS LIDOS DA API - PROCESSANDO OS REGISTROS POR NCM
                    - Os registros por produto serão armazenados diretamente na tabela tbfc_regrafiscal_nfce_ncm
            */

            await clsTools.pagConsole(`${FLG_MODULO} | Processando os registros de Tributação NFE/PDV por NCM | Total de Registros a processar (${listmodelfc_regraNfceProdutoNCM.length})`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);

            sql = ``
            iupdate = 0;
            iupdateRegistroPorBloco = 50;
            blocoi = 1;
            blocoiTotal = Math.ceil(listmodelfc_regraNfceProdutoNCM.length / iupdateRegistroPorBloco);


            for await (const ifc_regranfceNCM of listmodelfc_regraNfceProdutoNCM) {
                
                sql += ifc_regranfceNCM.sql_CRUD();
                iupdate++;

                if (iupdate >= iupdateRegistroPorBloco) {
                    await clsTools.pagConsole(`${FLG_MODULO} | Processando os registros de Tributação NFE/PDV por NCM ${blocoi} de ${blocoiTotal}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    await myBase.myDataBase.pag.Execute(sql)
                    sql = ``;
                    iupdate = 0;
                    blocoi++;
                }

            }

            if (sql.length > 0) {
                await clsTools.pagConsole(`${FLG_MODULO} | Processando os registros de Tributação NFE/PDV por NCM ${blocoi} de ${blocoiTotal}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                await myBase.myDataBase.pag.Execute(sql)
            }

            /* Atualizando a tabela tbfc_regrafiscal_nfce_produto dos produtos orindos da api por ncm*/
            await this.serviceFiscalImportarRegraNfe_ProcessarNCMProduto();


        } catch (e) { 
            await clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfeProduto', e,false,"",FLG_DEBUG_FILE_CONSOLE_LOG);
        }

        finally {
           await clsTools.pagConsole(`${FLG_MODULO} - Importação NFCE FINALIZADA`,FLG_DEBUG_CONSOLE_LOG,false, FLG_DEBUG_FILE_CONSOLE_LOG);
        }

    }


    private static async serviceFiscalImportarRegraNfe_ProcessarNCMProduto() { 
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


				 `

            



            const myBase = new clsBase();
            await myBase.myDataBase.pag.Execute(sql)
        
                
        } catch (e) { 
            await clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfeProduto', e,false,"",FLG_DEBUG_FILE_CONSOLE_LOG);
        }
    }

            

}