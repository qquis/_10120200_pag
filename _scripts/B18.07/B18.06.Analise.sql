select * from tbprocesso
select * from tbprocesso_tipo
select * from tbprocesso_log

select * from tbsistema_nucleo_procedimento

select * from tbsistema_batch_nucleo_procedimento

select 	sis_nucleo_prc_cd 
	,	sis_nucleo_prc_descritivo
	,	sis_nucleo_prc_descricao 
	,	notificacao_cd 
	,	data_reprocessamento_default
	,	data_reprocessamento_default_fim 
	,	dateadd_ini 
	,	dateadd_fim 
	,	data_default_ini 
	,	data_default_fim 
from tbsistema_nucleo_procedimento

update tbsistema_nucleo_procedimento set sis_nucleo_prc_descricao = sis_nucleo_prc_descritivo where sis_nucleo_prc_descricao is null

select * from tbsistema_log order by sis_log_seq desc limit 10


select                a.dtlog_insert 
                ,               a.sis_log_seq
                ,               coalesce(a.proc_log_seq,0) as proc_log_seq
                ,               coalesce(a.sis_nucleo_prc_cd, 0) as sis_nucleo_prc_cd
                ,               a.sis_log_tag
                ,               a.sis_log_info
                ,               coalesce(a.sis_batch_run_seq,0) as sis_batch_run_seq
                ,               a.uuid 
                ,               a.uuid_start 
                ,               coalesce(b.sis_nucleo_prc_descritivo,'') as sis_nucleo_prc_descritivo
                ,               coalesce(b.sis_nucleo_prc_descricao, '') as sis_nucleo_prc_descricao
            from                tbsistema_log a
            left join   tbsistema_nucleo_procedimento b on b.sis_nucleo_prc_cd = a.sis_nucleo_prc_cd 

         where          1 = 1 

          and a.dtlog_insert >= '2026-05-29 01:01:01' and a.dtlog_insert <= '2026-05-29 23:59:59' and a.sis_nucleo_prc_cd = 10050001



SELECT 		f.op_cdoperacao 
     ,		f.numeropedido
	 ,		f.numeropedido_fv
	 ,		f.fat_blue_status_cd
 	 ,		S.fat_blue_status_descricao 
	 ,		v.cdpessoabluesoft as cdpessoabluesoft_vendedor
	 ,		vv.nome_razao as nome_razao_cliente 
	 ,		c.cdpessoabluesoft as cdpessoabluesoft_cliente
	 ,		cc.nome_razao as nome_razao_cliente
	 ,		F.VALOR_PEDIDO 
	 ,		F.VALOR_FATURAMENTO 
	 ,	    i.prb_cdprodutobluesoft
	 ,	    prb.prb_descricao 
	 ,	    i.prb_cdprodutobluesoft_unitario 
	 ,	    i.qtde_solicitada
	 ,	    i.qtde_faturada 
	 ,	    i.valor_nf_item_bruto
	 ,	    i.valor_nf_item 
	 ,	    i.item_nf_bonificado 	 
FROM 		tbfaturamento_bluesoft  f
left join   tbfaturamento_bluesoft_item i on i.numeropedido = f.numeropedido and i.numeropedido_fv = f.numeropedido_fv and i.op_cdoperacao = f.op_cdoperacao 
left join   tbprodutobluesoft prb on prb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft 
left join   tbparticipante_bluesoft v on v.cdpessoabluesoft = f.cdpessoabluesoft_vendedor 
left join   tbparticipante vv on vv.cdparticipante = v.cdparticipante 
left join   tbparticipante_bluesoft c on c.cdpessoabluesoft = f.cdpessoabluesoft_cliente
left join   tbparticipante cc on cc.cdparticipante = c.cdparticipante 
left join 	tbfaturamento_bluesoft_status s on s.fat_blue_status_cd = f.fat_blue_status_cd 
where	1 = 1
and		f.data_emissao >= '2026-05-01'
and		f.data_emissao <= '2026-05-29'
and		f.op_cdoperacao = 1
and		s.fat_blue_status_cd in (55, 70)
AND		F.VALOR_PEDIDO > F.VALOR_FATURAMENTO 
and		i.qtde_solicitada > i.qtde_faturada 
order by 			v.cdpessoabluesoft
			,		vv.nome_razao 	
	 		,		c.cdpessoabluesoft 
	 		,		cc.nome_razao 
			,		prb.prb_descricao 
			asc


delete from  tbnotificacao_send
delete from  tbnotificacao_send_message
select * from tbnotificacao_send
select * from tbfaturamento_bluesoft_processo



SELECT  b.cdparticipante
                                                ,       b.cdpessoabluesoft
                                                ,       b.cpf_cnpj 
                                                ,       b.pessoajuridica
                                                ,       b.bluesoft_pessoa_data_cadastro 
                                                ,       b.bluesoft_pessoa_status
                                                ,       b.nome_razao 
                                                ,       b.nome_abreviado
                                                ,       b.bluesoftcliente
                                                ,       b.bluesoftclientestatus
                                                ,       b.cdgrupoeconomico 
                                                ,       ge.descricao 
                                                ,       b.cdpessoabluesoft_vendedor
                                               -- ,   pv.nome_razao as nome_vendedor
                                                ,       b.bluesoftvendedor
                                                ,       b.bluesoftfornecedor
                                                ,       b.bluesoftfabricante
                                                ,       b.bluesoftmotorista
                                        from    tbparticipante_bluesoft b
                                        left join tbgrupoeconomico ge on ge.cdgrupoeconomico = b.cdgrupoeconomico
                                        left join tbparticipante   pv on pv.cdpessoabluesoft = b.cdpessoabluesoft_vendedor AND b.cdpessoabluesoft_vendedor > 0 
                                        where           1 = 1
                        and b.cdparticipante = 25

SELECT * FROM TBPARTICIPANTE WHERE cdpessoabluesoft = 22417
SELECT * FROM tbparticipante_bluesoft WHERE CDPARTICIPANTE = 25

select * from tbsistema_
select * from tbnotificacao_permissao 
SELECT * FROM tbfaturamento_bluesoft_processo




			 