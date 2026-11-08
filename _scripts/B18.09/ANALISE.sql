SELECT * FROM tbfaturamento_bluesoft where numeropedido = 240378
select * from tbfaturamento_bluesoft_item where numeropedido = 240378



select 		c.faturamento_controle_Seq 
		,	c.seqfaturamento
		,	c.seqfaturamentoorigem
		,	c.numeropedido 
		,	c.df_nf_seq_blue 
		
		,	f.seqfaturamento
		,	o.seqfaturamentoorigem
		,	o.numeropedido 
		,	f.op_cdoperacao 
		,	f.em_cdempresa
		,	f.dataemissao 
		,	f.datafaturamento
		,	o.df_nf_seq_blue 
from 		tbfaturamento_controle 	c 
inner join  tbfaturamento 			f on f.faturamento_controle_Seq = c.faturamento_controle_Seq
inner join 	tbfaturamentoorigem 	o on o.faturamento_controle_Seq = f.faturamento_controle_Seq
where		o.numeropedido 			= 240378

select 		c.faturamento_controle_Seq 
		,	c.seqfaturamento
		,	c.seqfaturamentoorigem
		,	c.dtlog_insert 
		,	f.faturamento_controle_Seq
		,	o.faturamento_controle_Seq
		,	f.seqfaturamento
		,	o.seqfaturamentoorigem
		,	i.pr_cdproduto
		,	p.prb_cdprodutobluesoft 
		,	p.pr_descricao 
		,	i.valortotalfaturamento
from 		tbfaturamentoitens i 
inner join 	tbfaturamentoorigem o on o.seqfaturamentoorigem = i.seqfaturamentoorigem
inner join  tbfaturamento f on f.faturamento_controle_Seq = o.faturamento_controle_Seq
inner  join  tbproduto 	p on p.pr_cdproduto = i.pr_cdproduto 
inner join  tbfaturamento_controle c  on c.faturamento_controle_Seq = f.faturamento_controle_Seq
where		o.numeropedido = 240378


select * from tbfaturamentoitens where seqfaturamentoorigem = 9765965

	select 		o.seqfaturamentoorigem 
			,	i.fat_blue_item_seq 
			,	case when FA.FAT_BLUE_TIPO_CD = 20 then 1 else 0 end as item_bonificado
			,	pr.pr_cdproduto 
			,	pr.prb_cdprodutobluesoft 
			,	i.valor_custo_com_icm  			as	ec_valor_custo_precificacao 
			,	i.valor_custo_com_icm 			as  ec_valor_custo_faturamento
			,	i.prb_cdprodutobluesoft 		as  embalagem_prb_cdproduto
			,	pb.prb_cdbarra_principal 		as  embalahem_cdbarra
			,	i.qtde_unitaria_faturada		as  embalagem_qtde
			,	i.prb_fatorestoque 				as  embalagem_fatorestoque
			,	cast( i.valor_custo_com_icm / coalesce(i.prb_fatorestoque,1)  as numeric(13,2)) embalagem_ec_valor_custo_precificacao
			,	cast( i.valor_custo_com_icm / coalesce(i.prb_fatorestoque,1)  as numeric(13,2)) embalagem_ec_valor_custo_faturamento
			,	i.qtde_unitaria_faturada as embalagemestoque_qtde
			,	cast(i.valor_preco_tabela * i.qtde_faturada as numeric(13,2)) as valortotal_faturamentobase
			,	cast(i.valor_preco * i.qtde_faturada as numeric(13,2)) as valortotal_faturamento
			,	cast(i.valor_preco_aplicado * i.qtde_faturada as numeric(13,2)) as valortotal_faturamentofiscal
			,	cast(i.valor_verba as numeric(13,2)) as valortotal_subsidioscorrente
			, 	f.faturamento_controle_seq
	from 		tbfaturamento_bluesoft_item 	i
	inner join  tbfaturamento_bluesoft 	 		fa 
												on 	fa.fat_blue_seq = i.fat_blue_seq 
												and fa.numeropedido = i.numeropedido 
												and fa.numeropedido_fv = i.numeropedido_fv 
												and fa.op_cdoperacao = i.op_cdoperacao
												and fa.cdpessoabluesoft_cliente = i.cdpessoabluesoft_cliente
	
	inner join  tbfaturamento_controle 	 	ct on ct.numeropedido = fa.numeropedido 
										      and ct.numeropedido_fv = fa.numeropedido_fv 
											  and ct.cdpessoabluesoft_cliente = fa.cdpessoabluesoft_cliente
	inner join  tbfaturamento 				 f on f.faturamento_controle_seq = ct.faturamento_controle_seq
	inner join  tbfaturamentoorigem 		 o on o.faturamento_controle_seq = f.faturamento_controle_seq 
	inner join  tbproduto 					 pr on pr.prb_cdprodutobluesoft = i.prb_cdprodutobluesoft_unitario 
	inner join  tbprodutobluesoft			 pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
	where 		1 = 1
	and			ct.numeropedido = 240378
	and			f.faturamento_controle_seq = 5409486
	and			not exists	( 	select 		1 
								from 		tbfaturamentoitensembalagem xx 
								inner join 	tbfaturamentoorigem 		ox on ox.seqfaturamentoorigem = xx.seqfaturamentoorigem
								inner join  tbfaturamento 				fx on fx.seqfaturamento = ox.seqfaturamento 
								where 	1 = 1
								and 	xx.seqfaturamentoorigem 	= o.seqfaturamentoorigem
								and		xx.seqitem 					= i.fat_blue_item_seq 
								and     fx.faturamento_controle_seq = 5409486
							)

	






select * from tbfaturamento_controle where numeropedido = 240380
seqfaturamento = 9002034
seqfaturamentoorigem = 9773369

select * from tbfaturamento where faturamento_controle_seq = 5416890
select * from tbfaturamentoorigem where faturamento_controle_seq = 5416890
select * from tbfaturamentoitensembalagem where seqfaturamentoorigem = 9773369
select * from tbfaturamentoitens where seqfaturamentoorigem = 9773369



         SELECT * FROM f0070_23_1012018_faturamentoitem_processar 
            (
                    vfat_controle_tipo_cd:= 1
                ,       vseqfaturamento_uuid:= 'f32 0240380' 
                ,       vop_cdoperacao:= 4 
                ,       vnumeropedido:= 240380 
                ,   vnumeropedido_fv:= 10000004
                ,   vdf_nf_seq_blue:= 844384
                ,       vsat_ecf:=  0
                ,       vcupomfiscal:= 0
                ,       vcdpessoabluesoft_cliente:= 98680
                ,   vreprocessaritem:= 0
                ,   vfaturamento_controle_seq:= 5416890
            )




	select 		o.seqfaturamentoorigem 
			,	i.fat_blue_item_seq 
			,	case when nf.df_nf_tipo = 34 then 1 else 0 end as item_bonificado
			,	pr.pr_cdproduto 
			,	pr.prb_cdprodutobluesoft 
			,	i.valor_custo_com_icm  			as	ec_valor_custo_precificacao 
			,	i.valor_custo_com_icm 			as  ec_valor_custo_faturamento
			,	i.prb_cdprodutobluesoft 		as  embalagem_prb_cdproduto
			,	pb.prb_cdbarra_principal 		as  embalahem_cdbarra
			,	i.qtde_unitaria_faturada		as  embalagem_qtde
			,	i.prb_fatorestoque 				as  embalagem_fatorestoque
			,	cast( i.valor_custo_com_icm / coalesce(i.prb_fatorestoque,1)  as numeric(13,2)) embalagem_ec_valor_custo_precificacao
			,	cast( i.valor_custo_com_icm / coalesce(i.prb_fatorestoque,1)  as numeric(13,2)) embalagem_ec_valor_custo_faturamento
			,	i.qtde_unitaria_faturada as embalagemestoque_qtde
			,	cast(i.valor_preco_tabela * i.qtde_faturada as numeric(13,2)) as valortotal_faturamentobase
			,	cast(i.valor_preco * i.qtde_faturada as numeric(13,2)) as valortotal_faturamento
			,	cast(i.valor_preco_aplicado * i.qtde_faturada as numeric(13,2)) as valortotal_faturamentofiscal
			,	cast(i.valor_verba as numeric(13,2)) as valortotal_subsidioscorrente
			
	from 		tbfaturamento_bluesoft_item 	i
	inner join  tbfaturamento_bluesoft 	 		fa 
												on 	fa.fat_blue_seq    = i.fat_blue_seq 
												and fa.numeropedido    = i.numeropedido 
												and fa.numeropedido_fv = i.numeropedido_fv 
												and fa.op_cdoperacao   = i.op_cdoperacao
												and fa.cdpessoabluesoft_cliente = i.cdpessoabluesoft_cliente
	inner join  tbdocumentofiscal 			 	nf 
												on 	nf.df_nf_seq_blue = fa.df_nf_Seq_blue
												and	nf.cdpessoabluesoft = fa.cdpessoabluesoft_cliente 

	
	inner join  tbfaturamento_controle 	 	ct on ct.numeropedido = fa.numeropedido 
										          and ct.numeropedido_fv = fa.numeropedido_fv 
											      and ct.cdpessoabluesoft_cliente = fa.cdpessoabluesoft_cliente
	inner join  tbfaturamento 				 f on f.faturamento_controle_seq = ct.faturamento_controle_seq
	inner join  tbfaturamentoorigem 		 o on o.faturamento_controle_seq = f.faturamento_controle_seq 
	inner join  tbproduto 					 pr on pr.prb_cdprodutobluesoft = i.prb_cdprodutobluesoft_unitario 
	inner join  tbprodutobluesoft			 pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
	where 		1 = 1
	and			fa.numeropedido = 240380
	and			ct.faturamento_controle_seq = 5416890
	and         fa.cdpessoabluesoft_cliente

	and			not exists	( 	select 1 
								from 	tbfaturamentoitensembalagem xx 
								where 	1 = 1
								and 	xx.seqfaturamentoorigem = o.seqfaturamentoorigem
								and		xx.seqitem = i.fat_blue_item_seq 
							)
	;


select * from tbfc_cbenef
SELECT * FROM tbfc_cbenef_produtobluesoft





select 	cdparticipante 
	,	cdpessoabluesoft
	,	cpf_cnpj 
	,	pessoajuridica
	,	bluesoft_pessoa_data_cadastro 
	,	bluesoft_pessoa_status 
	,	nome_razao 
	,	nome_abreviado
	,	bluesoftcliente
	,	bluesoftclientestatus
	,	cdgrupoeconomico
	,	cdpessoabluesoft_vendedor
	,	bluesoftvendedor
	,	bluesoftfornecedor
	,	bluesoftfabricante
	,	bluesoftmotorista 
	,	bluesoftcliente_creditolimite_valor
	,	bluesoftcliente_creditolimite_valor_reservado
	,	bluesoftcliente_creditostatus_cd 
	,	bluesoftcliente_ramoatividade_cd 
from tbparticipante_bluesoft limit 10




SELECT f0011_90_1012018_tbparticipante_bluesoft_integ
                      (    sqlcommand:=  'DBINSERT' 
                           , vcdpessoabluesoft:=  2046
                           , vcpf_cnpj:= '21814585885'
                           , vnome_razao:= 'ELIAS DA SILVA'
                           , vpessoajuridica:= 0
                           , vemail_main:= 'eliassilva@oxan.com.br'
                           , vnome_abreviado:= 'ELIAS DA SILVA'
                           , vpf_sexo:= 'M'
                           , vpf_data_nascimento:= '1980-11-17'
                           , vendereco_cep:= 3453000
                           , vendereco_logradouro:= 'Avenida Rio das Pedras'
                           , vendereco_numero:= 729
                           , vendereco_complemento:= ''
                           , vendereco_bairro:= 'Jardim Aricanduva'
                           , vendereco_municipio:= 'São Paulo'
                           , vendereco_uf:= 'SP'
                           , vendereco_latitude:= -23.5655211
                           , vendereco_longitude:= -46.5125890
                           , vbluesoft_pessoa_status:= 1
                           , vbluesoft_pessoa_data_cadastro:= '2015-11-24'
                           , vbluesoftcliente:= 1
                           , vbluesoftvendedor:= 1
                           , vbluesoftfornecedor:= 0
                           , vbluesoftfabricante:= 0
                           , vbluesoftmotorista:= 0
                           , vcdgrupoeconomico:= 4561
                           , vcdpessoabluesoft_vendedor:= 2036
                           , vbluesoftclientestatus:= 1
                           , vbluesoftcliente_creditolimite_valor:= 50000.00
                           , vbluesoftcliente_creditolimite_valor_reservado:= 0.00
                           , vbluesoftcliente_creditostatus_cd:= 1
                           , vbluesoftcliente_ramoatividade_cd:= 6
                         );
SELECT f0011_90_1012018_tbparticipante_bluesoft_integ
                      (    sqlcommand:=  'DBINSERT' 
                           , vcdpessoabluesoft:=  15586
                           , vcpf_cnpj:= '06813374000102'
                           , vnome_razao:= 'MARIA INES ELIAS DA SILVA ME'
                           , vpessoajuridica:= 1
                           , vemail_main:= ''
                           , vnome_abreviado:= 'BAR E MERC ZE PARANA'
                           , vpf_sexo:= 'M'
                           , vpf_data_nascimento:= '1900-01-01'
                           , vendereco_cep:= 8620050
                           , vendereco_logradouro:= 'ESTRADA KEIDA HARADA'
                           , vendereco_numero:= 9884
                           , vendereco_complemento:= ''
                           , vendereco_bairro:= 'TIJUCO PRETO'
                           , vendereco_municipio:= 'Suzano'
                           , vendereco_uf:= 'SP'
                           , vendereco_latitude:= -23.6744128
                           , vendereco_longitude:= -46.2947673
                           , vbluesoft_pessoa_status:= 0
                           , vbluesoft_pessoa_data_cadastro:= '2006-12-14'
                           , vbluesoftcliente:= 1
                           , vbluesoftvendedor:= 0
                           , vbluesoftfornecedor:= 0
                           , vbluesoftfabricante:= 0
                           , vbluesoftmotorista:= 0
                           , vcdgrupoeconomico:= 0
                           , vcdpessoabluesoft_vendedor:= 0
                           , vbluesoftclientestatus:= 0
                           , vbluesoftcliente_creditolimite_valor:= 500.00
                           , vbluesoftcliente_creditolimite_valor_reservado:= 0.00
                           , vbluesoftcliente_creditostatus_cd:= 1
                           , vbluesoftcliente_ramoatividade_cd:= 6
                         );



select aliquota_pis, aliquota_cofins, data_ultima_alteracao from tab_mercadoria where cod_mercadoria in ('00000000000000001','00000000000000007' )
    7896213004842

select 		cod_mercadoria as cd
		, 	cod_tributacao_mercadoria as trib
		, 	cod_situacao_tributaria as sit_ic
		, 	aliquota_icms as ic
		, 	aliquota_interna_icms as ici
		, 	cod_sit_trib_pis as pis
		, 	aliquota_pis as pisa
		, 	cod_sit_trib_cofins as cof
		, 	aliquota_cofins as cofa
		, 	codigo_beneficio_fiscal as be
from 		tab_mercadoria  
where 		1 = 1 

and         data_ultima_alteracao >= '2026-07-24'

and         cod_mercadoria in ('00000000000718721', '00007891182016261', '00000000000636163', '00007891095002160', '00007896499902955')

select * from tab_mercadoria_tipo_venda where cod_mercadoria in ('00007891910000197')						 





select * from tbfc_cbenef_produtobluesoft