select  prb_cdprodutobluesoft 
	,	prb_descrica
	from tbfc_regrafiscal_nfce_produto
	where nfce_produto_tipo_cd = 3


select 	prb_cdprodutobluesoft_pk as cd
,		prb_descricao 
, 		prb_cdprodutobluesoftunitario as unit
, 		prb_ncm
, 		prb_cest
, 		dtlog_insert as ins
, 		dtlog_update as up 
from tbprodutobluesoft
where dtlog_update >= '2026-09-01 01:01:01'
and prb_cdprodutobluesoft_pk = 229404


select * from tbprodutobluesoft limit 10
select * from tbprodutobluesoft where prb_cdprodutobluesoft_pk = 90764
select * from tbproduto_subgrupo
select * from tbproduto_secao
select * from tbproduto_departamento


select prb_cdprodutobluesoft, nfce_produto_tipo_cd, * from tbfc_regrafiscal_nfce_produto where prb_cdprodutobluesoft = 90764
select prb_cdprodutobluesoft, nfce_produto_tipo_cd, * from tbfc_regrafiscal_nfce_produto where prb_cdprodutobluesoft = 80086
limit 10


select nfce_produto_tipo_cd, count(*) from tbfc_regrafiscal_nfce_produto group by nfce_produto_tipo_cd
select * from tbzanthus_tributacao_produto limit 10
select * from tbzanthus_tributacao_icms_pdv


insert into 	tbfc_regrafiscal_nfce_produto 
		(		pr_cdproduto 
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
select  pr.pr_cdproduto 
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
				 



























INSERT INTO tbfc_regrafiscal_nfce_produto (
                nfce_produto_tipo_cd,
                prb_cdprodutobluesoft,
                prb_cdprodutobluesoftunitario, 
                pr_cdproduto, 
                cfop,
                

                icms_codigo_origem,
                icms_codigo_tributacao,
                icms_codigo_tributacao_final,
                icms_percentual_diferimento,
                icms_aliquota_interna,
                icms_fcp_agregado,
                icms_fcp_segregado,
                icms_codigo_icms,
                icms_reducao_aliquota_efetiva,
                icms_aliquota_efetiva,
                icms_aliquota,
                icms_reducao,
                icms_aliquota_final,
                icms_csosn,
                icms_aliquota_desoneracao,
                icms_decreto_de_lei,
                icms_desconto_icms_desonerado,
                
                cofins_aliquota,
                cofins_cst,
                
                pis_aliquota,
                pis_cst,
                
                ipi_aliquota,
                ipi_cst,
                
                ncm_codigo,
                ncm_excecao,
                ncm_variacao,
                
                data_hora_geracao,
                data_referencia,
                codigo_figura_regra_fiscal,
                codigo_regra_fiscal,
                
                rt_codigo_cst_ibs_cbs,
                rt_codigo_class_trib_ibs_cbs,

                
                ibs_cd,
                ibs_aliquota,
                ibs_aliquota_efetiva,
                ibs_percentual_credito_presumido,
                ibs_percentual_diferimento,
                ibs_percentual_reducao,
                ibs_aliquota_desoneracao,
                ibs_aliquota_ad_rem,
                ibs_percentual_credito_presumido_monofasico,
                ibs_percentual_diferimento_monofasico,

               
                ibs_mun_cd,
                ibs_mun_aliquota,
                ibs_mun_aliquota_efetiva,
                ibs_mun_percentual_credito_presumido,
                ibs_mun_percentual_diferimento,
                ibs_mun_percentual_reducao,
                ibs_mun_aliquota_desoneracao,
                ibs_mun_aliquota_ad_rem,
                ibs_mun_percentual_credito_presumido_monofasico,
                ibs_mun_percentual_diferimento_monofasico,                
                
                cbs_cd,
                cbs_aliquota,
                cbs_aliquota_efetiva,
                cbs_percentual_credito_presumido,
                cbs_percentual_diferimento,
                cbs_percentual_reducao,
                cbs_aliquota_desoneracao,
                cbs_aliquota_ad_rem,
                cbs_percentual_credito_presumido_monofasico,
                cbs_percentual_diferimento_monofasico
            ) 
            SELECT 
                1,
                90764,
                coalesce(prb.prb_cdprodutobluesoftunitario,0), 
                coalesce(pr.pr_cdproduto,0),
                5102,
                
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                3,
                0,
                0,
                18,
                0,
                18,
                '',
                0,
                '',
                '',
                
                7.6,
                1,
                
                1.65,
                1,
                
                0,
                -1,
                '10059010',
                0,
                0,
                '2025-11-29 18:00:00',
                'D_0',
                281,
                4685,
                ' ',

                ' ',

                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0
            FROM        tbprodutobluesoft       prb 
            LEFT JOIN   tbproduto               pr ON pr.prb_cdprodutobluesoft = prb.prb_cdprodutobluesoftunitario 
            WHERE       PRB.prb_cdprodutobluesoft_pk = 90764
            AND NOT EXISTS (
                    SELECT 1 
                    FROM tbfc_regrafiscal_nfce_produto 
                    WHERE prb_cdprodutobluesoft = 90764 
                    and nfce_produto_tipo_cd = 1
                    )
            ;