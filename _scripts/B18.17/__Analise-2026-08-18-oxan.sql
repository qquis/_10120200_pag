-- Active: 1773758617277@@127.0.0.1@5432@oxan
select * from tbintegracao_status
-- 2 = pendente 
-- 1 = atualizado



select 		prb_cdprodutobluesoft_pk
		, 	prb_descricao
		, 	prb_pesobruto
		, 	prb_pesoliquido 
		, 	prb_comprimento
		,   prb_largura
		,   prb_altura
		,   prb_pesoaproximado
from tbprodutobluesoft
where 1= 1
and coalesce(prb_altura,99999) = 0

select * from tbprodutobluesoft where prb_cdprodutobluesoftunitario = 234386
update tbprodutobluesoft set prb_descricao = 'TESTE' where prb_cdprodutobluesoft_pk = 234387

SELECT f0021_01_1012018_produtobluesoft_crud
                    ( sqlcommand:= 'DBINSERT_API',
                      vprb_cdprodutobluesoft_pk:= 115021,
                      vprb_cdprodutobluesoftunitario:= 1206,
                      vprb_descricao:= 'SAB. PROTEX BALANCE 85G CX 72.0',
                      vprb_embalagemestoque:= 'CX',
                      vprb_fatorestoque:= 72,
                      vprb_status_embalagemcaixa:= 'true',
                      vprb_embalagemcompra:= 'XX',
                      vprb_embalagemcompra_qtdeunitaria:= 0.00,
                      vprb_cdbarra_principal:= '11029',
                      vprb_cdprodutobluesoft_controleestoque:= 0,
                      vprb_cdprodutobluesoft_controlepreco:= 0,
                      vprb_cdsubgrupo:= 131,
                      vprb_dt_cadastro:= '2016-06-29',
                      vprb_dt_ultimaalteracao:= '2026-08-10',
                      vprb_cdpessoabluesoft_fabricante:= 0,
                      vprb_vendaexterna:= '0',
                      vprb_descricao_fiscal:= '',
                      vprb_cdproduto_compra_padrao:= 0,
                      vprbf_seq:= 0,
                      vprb_status:= '1', 
                      vprb_tipo_composicao_cd:= 0, 
                      vprb_descricao_gondola:= 'SAB. PROTEX BALANCE 90G CX/ 72.0', 
                      vprb_descricao_cupom:= 'SAB. PROTEX BALANCE', 
                      vprb_descricao_balanca:= 'SAB. PROTEX BALANCE', 
                      vprb_cdpessoabluesoft_fornecedor:= 0,
                      vprb_cdpessoabluesoft_fornecedor_troca:= 0,
                      vprb_pesobruto:= 1,
                      vprb_pesoliquido:= 1,
                      vprb_largura:= 0,
                      vprb_altura:= 0,
                      vprb_pesoaproximado:= 0,
                      vprb_comprimento:= 0,
                      vprb_blue_fc_cbenef_cd:= 'SP099999',                      
                      vcommand_api:= 'true',
                      vatualizalogpendenciazanthus:= 1
                      ) ;


234386


SELECT f0021_01_1012018_produtobluesoft_crud
                    ( sqlcommand:= 'DBINSERT_API',
                      vprb_cdprodutobluesoft_pk:= 234386,
                      vprb_cdprodutobluesoftunitario:= 234386,
                      vprb_descricao:= 'CHOC. BOMBOM FERRERO ROCHER 50G',
                      vprb_embalagemestoque:= 'UN',
                      vprb_fatorestoque:= 1,
                      vprb_status_embalagemcaixa:= 'false',
                      vprb_embalagemcompra:= 'XX',
                      vprb_embalagemcompra_qtdeunitaria:= 0.00,
                      vprb_cdbarra_principal:= '7898024397861',
                      vprb_cdprodutobluesoft_controleestoque:= 0,
                      vprb_cdprodutobluesoft_controlepreco:= 0,
                      vprb_cdsubgrupo:= 44,
                      vprb_dt_cadastro:= '2026-08-18',
                      vprb_dt_ultimaalteracao:= '2026-08-18',
                      vprb_cdpessoabluesoft_fabricante:= 19413,
                      vprb_vendaexterna:= '0',
                      vprb_descricao_fiscal:= '',
                      vprb_cdproduto_compra_padrao:= 0,
                      vprbf_seq:= 0,
                      vprb_status:= '1', 
                      vprb_tipo_composicao_cd:= 0, 
                      vprb_descricao_gondola:= 'CHOC. BOMBOM FERRERO ROCHER 50G', 
                      vprb_descricao_cupom:= 'CHOC. BOMBOM FERRERO', 
                      vprb_descricao_balanca:= 'CHOC. BOMBOM FERRERO', 
                      vprb_cdpessoabluesoft_fornecedor:= 0,
                      vprb_cdpessoabluesoft_fornecedor_troca:= 0,
                      vprb_pesobruto:= 1.69,
                      vprb_pesoliquido:= 1.69,
                      vprb_largura:= 0,
                      vprb_altura:= 0,
                      vprb_pesoaproximado:= 0,
                      vprb_comprimento:= 0,
                      vprb_blue_fc_cbenef_cd:= '',                      
                      vcommand_api:= 'true',
                      vatualizalogpendenciazanthus:= 0
                      )



				Insert into tbintegracao_produto 
					(
							pr_cdproduto
						,	prb_cdprodutobluesoftunitario 
						,	prb_cdprodutobluesoft 
						,	integracao_tipo_cd 
						,	integracao_status_cd 
					)
				
				Select 		coalesce(B.pr_cdproduto,0)
						,	A.prb_cdprodutobluesoftunitario
						,	A.prb_cdprodutobluesoftunitario
						,	20004501
						,	2
				FROM		tbprodutobluesoft A
				INNER join 	tbproduto         B ON B.prb_cdprodutobluesoft = a.prb_cdprodutobluesoftunitario 
				WHERE 1 = 1
				  and a.prb_cdprodutobluesoft_pk = 234386
				  and (			 a.prb_descricao != vprb_descricao
				  			or   a.prb_embalagemestoque != vprb_embalagemestoque		
							or   a.prb_fatorestoque != vprb_fatorestoque
							or   a.prb_cdbarra_principal != vprb_cdbarra_principal
							or   a.prb_status != vprb_status
							or   a.prb_descricao_cupom != vprb_descricao_cupom
							or   a.prb_descricao_balanca != vprb_descricao_balanca
							or   a.prb_pesobruto != vprb_pesobruto
							or   a.prb_pesoliquido != vprb_pesoliquido
							or   a.prb_altura != vprb_altura
							or   a.prb_largura != vprb_largura
							or   a.prb_pesoaproximado != vprb_pesoaproximado
							or   a.prb_comprimento != vprb_comprimento
						)

	  			and       not exists ( 	select 1 
								from   tbintegracao_produto x
								where  x.pr_cdproduto = B.pr_cdproduto 
								  and  x.prb_cdprodutobluesoftunitario  = A.prb_cdprodutobluesoftunitario 
								  and  x.integracao_tipo_cd = 20008501
						   )						
				;   









SELECT f0021_01_1012018_produtobluesoft_crud ( sqlcommand:= 'DBINSERT'  
, vprb_cdprodutobluesoft_pk:= 1  
, vprb_cdprodutobluesoftunitario:= 1 
, vprb_descricao:= 'LAMP. FLC LED TUBULAR GLASS 18W BIVOLT'  
, vprb_embalagemestoque:= 'UN'  
, vprb_fatorestoque:= 1.00  
, vprb_status_embalagemcaixa:= false
, vprb_embalagemcompra:= 'UN'  
, vprb_embalagemcompra_qtdeunitaria:= 1.00  
, vprb_cdbarra_principal:= '10100'  
, vprb_cdprodutobluesoft_controleestoque:= 0  
, vprb_cdprodutobluesoft_controlepreco:=    0  
, vprb_cdsubgrupo:= 4  
, vprb_dt_cadastro:= '2015-12-07'  
, vprb_dt_ultimaalteracao:= '2015-12-07'  
, vprb_cdpessoabluesoft_fabricante:= 0  
, vprb_vendaexterna:= false
, vprb_descricao_fiscal:= ' - '  
, vprb_cdproduto_compra_padrao:= 0  
, vprbf_seq:= 0  
, vprb_status:= false  
, vprb_tipo_composicao_cd:= 1  
, vprb_descricao_gondola:= 'LAMP. FLC LED TUBULAR GLASS 18W BIV'  
, vprb_descricao_cupom:= 'LAMP. FLC LED TUBULA'  
, vprb_descricao_balanca:= 'LAMP. FLC LED TUBULA'  
, vprb_cdpessoabluesoft_fornecedor:= 24999  
, vprb_cdpessoabluesoft_fornecedor_troca:= 24999  
, vprb_pesobruto:= 1.0000  
, vprb_pesoliquido:= 1.0000  
, vprb_largura:= 0  
, vprb_altura:= 0  
, vprb_pesoaproximado:= 0  
, vprb_comprimento:= 0  
, vprb_blue_fc_cbenef_cd:= ''  
, vcommand_api:= false  ) 






SELECT f0021_01_1012018_produtobluesoft_crud ( 
  sqlcommand:= 'DBINSERT'  
, vprb_cdprodutobluesoft_pk:= 1  
, vprb_cdprodutobluesoftunitario:= 1 
, vprb_descricao:= 'LAMP. FLC LED TUBULAR GLASS 18W BIVOLT'  
, vprb_embalagemestoque:= 'UN'  
, vprb_fatorestoque:= 1.00  
, vprb_status_embalagemcaixa:= false
, vprb_embalagemcompra:= 'UN'  
, vprb_embalagemcompra_qtdeunitaria:= 1.00  
, vprb_cdbarra_principal:= '10100'  
, vprb_cdprodutobluesoft_controleestoque:= 0  
, vprb_cdprodutobluesoft_controlepreco:=    0  
, vprb_cdsubgrupo:= 4  
, vprb_dt_cadastro:= '2015-12-07'  
, vprb_dt_ultimaalteracao:= '2015-12-07'  
, vprb_cdpessoabluesoft_fabricante:= 0  
, vprb_vendaexterna:= 'false'
, vprb_descricao_fiscal:= ' - '  
, vprb_cdproduto_compra_padrao:= 0  
, vprbf_seq:= 0  
, vprb_status:= 'false'  
, vprb_tipo_composicao_cd:= 1  
, vprb_descricao_gondola:= 'LAMP. FLC LED TUBULAR GLASS 18W BIV'  
, vprb_descricao_cupom:= 'LAMP. FLC LED TUBULA'  
, vprb_descricao_balanca:= 'LAMP. FLC LED TUBULA'  
, vprb_cdpessoabluesoft_fornecedor:= 24999  
, vprb_cdpessoabluesoft_fornecedor_troca:= 24999  
, vprb_pesobruto:= 1.0000  
, vprb_pesoliquido:= 1.0000  
, vprb_largura:= 0  
, vprb_altura:= 0  
, vprb_pesoaproximado:= 0  
, vprb_comprimento:= 0  
, vprb_blue_fc_cbenef_cd:= ''  
, vcommand_api:= 'false'  ) 

SELECT f0021_01_1012018_produtobluesoft_crud ( sqlcommand:='DBINSERT'  
, vprb_cdprodutobluesoft_pk:= 25  
, vprb_cdprodutobluesoftunitario:= 25 
, vprb_descricao:= 'ACHOCOLATADO EM PO TODDY ORIGINAL 400G'  
, vprb_embalagemestoque:= 'UN'  
, vprb_fatorestoque:= 1.00  
, vprb_status_embalagemcaixa:= False  
, vprb_embalagemcompra:= 'CX' 
 , vprb_embalagemcompra_qtdeunitaria:= 24.00  
 , vprb_cdbarra_principal:= '7894321711263'  
 , vprb_cdprodutobluesoft_controleestoque:= 0  
 , vprb_cdprodutobluesoft_controlepreco:=    0  
 , vprb_cdsubgrupo:= 142  
 , vprb_dt_cadastro:= '2015-11-27'  
 , vprb_dt_ultimaalteracao:= '2026-07-14'  
 , vprb_cdpessoabluesoft_fabricante:= 12423  
 , vprb_vendaexterna:= False  
 , vprb_descricao_fiscal:= ' - '  
 , vprb_cdproduto_compra_padrao:= 80025  
 , vprbf_seq:= 826  
 , vprb_status:= True  
 , vprb_tipo_composicao_cd:= 1 
  , vprb_descricao_gondola:= 'ACHOC EM PO TODDY ORI 400G'  
  , vprb_descricao_cupom:= 'ACHOC EM PO TODDY O'  
  , vprb_descricao_balanca:= 'ACHOCOLATADO EM PO TODDY ORIGINAL 400G' 
   , vprb_cdpessoabluesoft_fornecedor:= 19413  
   , vprb_cdpessoabluesoft_fornecedor_troca:= 19413  
   , vprb_pesobruto:= 9.6000  
   , vprb_pesoliquido:= 9.6000  
   , vprb_largura:= 0  
   , vprb_altura:= 0  
   , vprb_pesoaproximado:= 0 
    , vprb_comprimento:= 0  
	, vprb_blue_fc_cbenef_cd:= '' 
	 , vcommand_api:= false  
	 , vatualizalog:= 0 )  



select * from tbintegracao_produto where prb_cdprodutobluesoftunitario = 233860 and integracao_tipo_cd = 20008590
delete from tbintegracao_produto where integracao_tipo_cd = 20008590


select pb.prb_cdprodutobluesoftunitario
  ,    un.prb_descricao 
  ,    pb.prb_cdprodutobluesoft_pk 
  ,    coalesce(pb.prb_descricao,'') as prb_descricao
  ,    coalesce(pb.prb_pesobruto,0) as prb_pesobruto
  ,    coalesce(pb.prb_pesoliquido,0) as prb_pesoliquido
  ,    coalesce(pb.prb_comprimento,0) as prb_comprimento
  ,    coalesce(pb.prb_largura,0) as prb_largura
  ,    coalesce(pb.prb_altura,0) as prb_altura
  ,    coalesce(pb.prb_pesoaproximado,0) as prb_pesoaproximado
  ,    pb.prb_status 
  ,    pb.dtlog_insert 
  ,    pb.dtlog_update 
  ,    pb.prb_dtupdate_from_api 
  ,    pb.prb_descricao_gondola
  ,    pb.prb_descricao_cupom
  ,    pb.prb_descricao_balanca
  ,    pb.prb_cdpessoabluesoft_fornecedor
  ,    p.nome_razao 
  ,    pb.prb_cdsubgrupo
  ,    sb.prsg_descricao
  ,    g.prg_descricao 
  ,    s.prs_descricao
  ,    d.prd_descricao
  ,    pb.prb_cdbarra_principal
  ,    pb.prb_dt_cadastro 
  ,    pb.prb_dt_ultimaalteracao
from        tbprodutobluesoft pb 
inner join  tbprodutobluesoft un on un.prb_cdprodutobluesoft_pk = pb.prb_cdprodutobluesoftunitario
inner join  tbparticipante_bluesoft p on p.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fornecedor
left join   tbproduto_subgrupo sb on sb.prsg_cdsubgrupo = pb.prb_cdsubgrupo
left join   tbproduto_grupo g on g.prg_cdgrupo = sb.prg_cdgrupo
left join   tbproduto_secao s on s.prs_cdsecao = g.prs_cdsecao 
left join   tbproduto_departamento d on d.prd_cddepartamento = s.prd_cddepartamento
where 1=1
order by un.prb_descricao, pb.prb_descricao  asc



select * from tbproduto_grupo
