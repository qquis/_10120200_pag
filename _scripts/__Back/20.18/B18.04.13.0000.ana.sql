---SELECT * FROM TBFC_REGRAFISCAL where fc_regrafiscal_cd = 8026 
-- SELECT * FROM tbfc_regrafiscal_operacao where fc_regrafiscal_Cd = 8026

--select * from tbforca_venda_prazopgto
--select * from tbforca_venda_tabpreco_versao

select 	t.fv_tabelapreco_cd 
	,	t.fv_tabelapreco_descricao
	,	coalesce(co.percentual_comissao,0) 						as percentual_comissao
	,	coalesce(v.qtde_versao,0) 								as qtde_versao
	,	coalesce(v.versao_atual,0) 								as versao_atual
	,	coalesce(v.vigencia_inicial_atual, '1900-01-01 00:00') 	as vigencia_inicial_atual
	,	coalesce(v.vigencia_fim_atual, '1900-01-01 00:00') 		as vigencia_fim_atual
from tbforca_venda_tabpreco t
left join tbforca_venda_comis_tabpreco co on co.fv_tabelapreco_cd = t.fv_tabelapreco_cd
left join (
				select 	x.fv_tabelapreco_cd
					,	count(distinct(x.versao)) as qtde_versao 
					,	max(x.versao) as versao_atual 
					,	max(x.datainiciovigencia) as vigencia_inicial_atual 
					,	max(x.datafimvigencia) as vigencia_fim_atual 
				from tbforca_venda_tabpreco_versao x
				group by 	x.fv_tabelapreco_cd
			) v on v.fv_tabelapreco_cd = t.fv_tabelapreco_cd

 Select v.fv_tabelapreco_cd
 	,	t.fv_tabelapreco_descricao  	
	,	v.versao
	,   v.descontomaximo
	,	v.descontopadrao
	,	v.acrescimomaximo
	,	v.datainiciovigencia
	,	v.datafimvigencia 
	,	v.ativo
	,	v.tabelareferencia 
 from 		tbforca_venda_tabpreco_versao v
 left join 	tbforca_venda_tabpreco t on t.fv_tabelapreco_cd = v.fv_tabelapreco_cd
 where v.fv_tabelapreco_cd = 1

 select i.fv_tabelapreco_cd 
 	,	t.fv_tabelapreco_descricao 
 	,	i.versao 
 	,	i.dtlog_update 
 	,	i.prb_cdprodutobluesoft 
	,	pb.prb_descricao 
	,	i.precoembalagem 
	,	i.precounitario 
	,	i.descontomaximo
	,	i.descontopadrao
	,	i.acrescimomaximo
	, 	i.fatorpreco
	,	i.fatorestoque
	,	i.versao
	,	i.precopromocional
 from 	tbforca_venda_tabprecoprodutobluesoft i
 left join tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
 left join tbforca_venda_tabpreco t on t.fv_tabelapreco_cd = i.fv_tabelapreco_cd
 where 1 =1
 order by t.fv_tabelapreco_descricao 
 		,	pb.prb_descricao    
	

 select * from tbforca_venda_tabprecoprodutobluesoft



           select i.fv_tabelapreco_cd 
                            ,   t.fv_tabelapreco_descricao 
                            ,   i.versao 
                            ,   i.dtlog_update 
                            ,   i.prb_cdprodutobluesoft 
                            ,   pb.prb_descricao 
                            ,   i.precoembalagem 
                            ,   i.precounitario 
                            ,   i.descontomaximo
                            ,   i.descontopadrao
                            ,   i.acrescimomaximo
                            ,   i.fatorpreco
                            ,   i.fatorestoque
                            ,   i.versao
                            ,   i.precopromocional
                            ,   v.datainiciovigencia
                        from    tbforca_venda_tabprecoprodutobluesoft i
                        inner join tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
                        inner join tbforca_venda_tabpreco t on t.fv_tabelapreco_cd = i.fv_tabelapreco_cd
                        inner join tbforca_venda_tabpreco_versao v on v.fv_tabelapreco_cd = i.fv_tabelapreco_cd and v.versao = i.versao
                        where 1 =1
  
                     and v.datainiciovigencia >= '2026-04-17 00:00:00' and upper(pb.prb_descricao) like upper('%ABSORVENTE TENA LADY DISCREET EXTRA COM 8 UNIDADES%') ORDER BY t.fv_tabelapreco_descricao, pb.prb_descricao ASC



select * 
from tbprodutobluesoft limit 10	


	SELECT * FROM tbfc_regrafiscal_operacao where df_nf_tipo = 104
select * from tbdocumentofiscal limit 10
select * from tbdocumentofiscal_tipo where df_nf_tipo = 104
select * from tbfc_icms
select * from tbfc_pis

select * from tbfc_figurafiscal_produto where prb_cdprodutobluesoft = 112680
select 	r.fc_regrafiscal_cd 
      , r.cfop 
	  , r.icms_cd 
	  , o.df_nf_tipo
	  , o.*
	  , r.*
	  , i.*
from 	tbfc_figurafiscal_produto pb
inner join tbfc_regrafiscal r on r.fc_figurafiscal_cd = pb.fc_figurafiscal_cd
inner join tbfc_regrafiscal_operacao o on o.fc_regrafiscal_cd = r.fc_regrafiscal_cd
inner join tbfc_icms i on i.icms_cd = r.icms_cd
where   1 = 1
--and     r.fc_figurafiscal_cd = 605
--and     r.tipo = 'SAIDA'
and     o.df_nf_tipo = 104
and     pb.prb_cdprodutobluesoft = 149799


select versao, * from tbforca_venda_tabprecoprodutobluesoft
where fv_tabelapreco_cd = 1
and   versao = 1553

select current_timestamp
select * from tbforca_venda_tabpreco_versao


                        select i.fv_tabelapreco_cd 
                            ,	t.fv_tabelapreco_descricao 
                            ,	i.versao 
							,   v.datainiciovigencia
							,   v.datafimvigencia
                            ,	pb.prb_descricao
                            ,	i.dtlog_update 
                            ,	i.prb_cdprodutobluesoft 
                            ,	pb.prb_descricao 
                            ,	i.precoembalagem 
                            ,	i.precounitario 
                            ,   cast(i.precounitario * ( SELECT coalesce(coefcustofinanceiro,1) from tbforca_venda_prazopgto where listapadraoorder = 1) as numeric(13,2)) as D07
                            ,   cast(i.precounitario * ( SELECT coalesce(coefcustofinanceiro,1) from tbforca_venda_prazopgto where listapadraoorder = 2) as numeric(13,2)) as D14
                            ,   cast(i.precounitario * ( SELECT coalesce(coefcustofinanceiro,1) from tbforca_venda_prazopgto where listapadraoorder = 3) as numeric(13,2)) as D21	
                            ,   cast(i.precounitario * ( SELECT coalesce(coefcustofinanceiro,1) from tbforca_venda_prazopgto where listapadraoorder = 4) as numeric(13,2)) as D28		
                            ,   pb.prb_cdbarra_principal 
                            ,   im.link_image 
                            ,   f.icms_descricao 
                            ,   f.piscst 
                            ,   f.pisaliquota
                        from 	tbforca_venda_tabprecoprodutobluesoft i
                        inner join tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
                        left join tbgtins_imagem im on lpad(im.cdbarra, 14, '0') = lpad(pb.prb_cdbarra_principal, 14, '0') 
                        inner join tbforca_venda_tabpreco t on t.fv_tabelapreco_cd = i.fv_tabelapreco_cd
                        inner join tbforca_venda_tabpreco_versao v on v.fv_tabelapreco_cd = i.fv_tabelapreco_cd and v.versao = i.versao
						inner join (

							select xx.fv_tabelapreco_cd 
								,  max(xx.versao) as ultima_versao 
								from tbforca_venda_tabpreco_versao xx
								group by fv_tabelapreco_cd 

						) ultima_versao on ultima_versao.fv_tabelapreco_cd = v.fv_tabelapreco_cd and ultima_versao.ultima_versao = v.versao


                        
                        left join (
                        
                                        select 	  pb.prb_cdprodutobluesoft
                                                , r.fc_regrafiscal_cd 
                                                , r.cfop 
                                                , r.pis_cd 
                                                , pis.cst  as piscst
                                                , pis.pisaliquota as pisaliquota
                                                , cofins.cst  as cofinscst
                                                , cofins.cofinsaliquota as cofinsaliquota                                                
                                                , r.cofins_cd
                                                , o.df_nf_tipo
                                                , r.icms_cd 
                                                , i.icms_descricao 
                                                , i.aliquota
                                                , i.reducao 
                                                , i.codigotributacao 

                                            from 	tbfc_figurafiscal_produto pb
                                            inner join tbfc_regrafiscal r on r.fc_figurafiscal_cd = pb.fc_figurafiscal_cd
                                            inner join tbfc_regrafiscal_operacao o on o.fc_regrafiscal_cd = r.fc_regrafiscal_cd
                                            inner join tbfc_icms i on i.icms_cd = r.icms_cd
                                            left join  tbfc_pis pis on pis.pis_cd = r.pis_cd
                                            left join  tbfc_cofins cofins on cofins.cofins_cd = r.cofins_cd
                                            where   1 = 1
                                            and     r.tipo = 'SAIDA'
                                            and     o.df_nf_tipo = 104
                                            and     r.tipocliente = 'X'
                                    ) f on f.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoftunitario 
					where 1= 1
					and i.fv_tabelapreco_cd = 1





select * from tbfc_regrafiscal_operacao limit 10
select * from tbfc_regrafiscal limit 10
select * from tbfc_pis
select * from tbprodutobluesoft_tributacao 
where op_cdoperacao = 2
and prb_cdprodutobluesoft = 43
limit 10

select * from tbprodutobluesoft limit 10

select * from tbsistema_batch_nucleo_procedimento where sis_batch_cd = 90301 order by sis_batch_nucleo_order asc

select * from tbsistema_nucleo

select * from tbsistema_nucleo_procedimento where sis_nucleo_cd_fk = 'F0004'

delete from tbsistema_nucleo_procedimento where sis_nucleo_prc_cd = 10004001 and sis_nucleo_cd_fk = 'F0004';
insert into tbsistema_nucleo_procedimento 
    (
            sis_nucleo_cd_fk
        ,   sis_nucleo_prc_cd
        ,   sis_nucleo_prc_descritivo
        ,   sis_nucleo_prc_tipo 
        ,   data_reprocessamento_default 
        ,   data_reprocessamento_default_fim 
        ,   permite_execucao_manual
        ,   sis_nucleo_prc_descricao
        ,   notificacao_cd
    ) select 'F0004', 10004001, 'Força de Venda (JS) - Integração Geral', 1, '1900-01-01', '1900-01-01', 0, 'Força de Venda (JS) - Integração Geral', 1009030001
    where not exists (
        select 1 from tbsistema_nucleo_procedimento where sis_nucleo_prc_cd = 10004001 and sis_nucleo_cd_fk = 'F0004'
    )

insert into tbsistema_batch_nucleo_procedimento (sis_batch_cd, sis_nucleo_prc_cd, sis_batch_nucleo_order)
    select 90301, 10004001, 150
    where not exists (
        select 1 from tbsistema_batch_nucleo_procedimento where sis_batch_cd = 90301 and sis_nucleo_prc_cd = 10004001
    );