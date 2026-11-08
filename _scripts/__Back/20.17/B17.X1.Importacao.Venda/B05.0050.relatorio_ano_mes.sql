drop table if exists tbtempfaturamentoresumo_mesano;
CREATE TEMPORARY TABLE  tbtempfaturamentoresumo_mesano
	(
				referencia char(10)
			,	descricao  varchar(60)
			,	ano int
			,	mes int
			,	valortotalfaturamentoliquido 		numeric(17,2)
			,	ec_valorcusto_faturamento_total		numeric(17,2)
			,	embalagemestoqueqtde				numeric(13,2)
			,	embalagemcompraqtde					numeric(13,2)
			,	margem								numeric(13,2)
			,	ticket								numeric(7,0)
			,	participacao 						numeric(13,2)
			,	constraint pktempfaturamentoresumo_mesano primary key (referencia, ano, mes)
	)
;

 INSERT INTO tbtempfaturamentoresumo_mesano
 		(		referencia 
			,	descricao 
			,	ano 
			,	mes 
			,	valortotalfaturamentoliquido 		
			,	ec_valorcusto_faturamento_total		
			,	embalagemestoqueqtde				
			,	embalagemcompraqtde	
			,	ticket
		)


 SELECT  				COALESCE(pb.prb_cdpessoabluesoft_fornecedor,0)
 					,	COALESCE(pt.nome_razao, 'AAA * FORNECEDOR NAO DEFINIDO * AAA' )
                    ,	CAST(to_char(f.datafaturamento, 'YYYY') AS INT)
					,	CAST(to_char(f.datafaturamento, 'MM') AS INT)
					,   sum(i.valortotalfaturamentoliquido) as valor
                    ,   sum(i.ec_valorcusto_faturamento_total) as custo 
                    ,   sum(i.embalagemestoqueqtde) as volume
                    ,   sum(i.embalagemcompraqtde) as caixa
					,	count(f.cdparticipantecliente) as ticket 
					

                FROM    	tbfaturamentoitens i
				INNER JOIN 	tbproduto p on p.pr_cdproduto = i.pr_cdproduto 
				LEFT JOIN   tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft 
				LEFT JOIN   tbparticipante_bluesoft pt on pt.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fornecedor
                INNER JOIN 	tbfaturamentoorigem o on o.seqfaturamentoorigem = i.seqfaturamentoorigem
                INNER JOIN 	tbfaturamento f on f.seqfaturamento = o.seqfaturamento 
                WHERE 1 = 1
                AND  f.statusfaturamento = 1 
                AND  i.statusfaturamentoitem = 1 
                AND  f.op_cdoperacao = 1
                AND  f.em_cdempresa = 1 
                AND  f.datafaturamento >= '2023-01-01'
                AND  f.datafaturamento <= '2026-01-31'
                group by 		pb.prb_cdpessoabluesoft_fornecedor
 					,	pt.nome_razao 
                    ,	CAST(to_char(f.datafaturamento, 'YYYY') AS INT)
					,	CAST(to_char(f.datafaturamento, 'MM') AS INT)


;
update tbtempfaturamentoresumo_mesano x
	set participacao = valortotalfaturamentoliquido / total_ano * 100
from (
SELECT 		mes
		,	ano
		, 	sum(valortotalfaturamentoliquido) as total_ano
FROM 	tbtempfaturamentoresumo_mesano group by mes, ano 
) a where 1 = 1
and   x.mes = a.mes 
and   x.ano = a.ano 

;



UPDATE tbtempfaturamentoresumo_mesano SET margem = (valortotalfaturamentoliquido - ec_valorcusto_faturamento_total) /  valortotalfaturamentoliquido * 100


;


SELECT  A.REFERENCIA
	,	A.DESCRICAO 
	,	COALESCE(M01.valortotalfaturamentoliquido,0) 		
	,	COALESCE(M01.participacao,0)
	,	COALESCE(M01.MARGEM,0)
	,	COALESCE(M02.valortotalfaturamentoliquido,0)
	,	COALESCE(M02.participacao,0)
	,	COALESCE(M02.MARGEM,0)
	,	COALESCE(M03.valortotalfaturamentoliquido,0)
	,	COALESCE(M03.participacao,0)
	,	COALESCE(M03.MARGEM,0)	
	,	COALESCE(M04.valortotalfaturamentoliquido,0) 		
	,	COALESCE(M04.participacao,0)
	,	COALESCE(M04.MARGEM,0)		
	,	COALESCE(M05.valortotalfaturamentoliquido,0) 		
	,	COALESCE(M05.participacao,0)
	,	COALESCE(M05.MARGEM,0)			
	,	COALESCE(M06.valortotalfaturamentoliquido,0)
	,	COALESCE(M06.participacao,0)
	,	COALESCE(M06.MARGEM,0)				
	,	COALESCE(M07.valortotalfaturamentoliquido,0)
	,	COALESCE(M07.participacao,0)
	,	COALESCE(M07.MARGEM,0)					
	,	COALESCE(M08.valortotalfaturamentoliquido,0) 		
	,	COALESCE(M08.participacao,0)
	,	COALESCE(M08.MARGEM,0)						
	,	COALESCE(M09.valortotalfaturamentoliquido,0)
	,	COALESCE(M09.participacao,0)
	,	COALESCE(M09.MARGEM,0)							
	,	COALESCE(M10.valortotalfaturamentoliquido,0)
	,	COALESCE(M10.participacao,0)
	,	COALESCE(M10.MARGEM,0)								
	,	COALESCE(M11.valortotalfaturamentoliquido,0)
	,	COALESCE(M11.participacao,0)
	,	COALESCE(M11.MARGEM,0)									
	,	COALESCE(M12.valortotalfaturamentoliquido,0)
	,	COALESCE(M12.participacao,0)
	,	COALESCE(M12.MARGEM,0)										
FROM (	select 	referencia
			,	descricao 
		from 	tbtempfaturamentoresumo_mesano A
		group by referencia
			,	 descricao 
	) A 

left join  (select  	referencia 
					,	valortotalfaturamentoliquido 		
					,	ec_valorcusto_faturamento_total		
					,	embalagemestoqueqtde				
					,	embalagemcompraqtde			
					,	ticket 
					,	participacao
					,	margem
			from 	tbtempfaturamentoresumo_mesano  
			WHERE   ANO = 2025
			  AND   MES = 1
			) M01 ON M01.REFERENCIA =  A.REFERENCIA 
left join  (select  	referencia 
					,	valortotalfaturamentoliquido 		
					,	ec_valorcusto_faturamento_total		
					,	embalagemestoqueqtde				
					,	embalagemcompraqtde			
					,	ticket 
					,	participacao
					,	margem					
			from 	tbtempfaturamentoresumo_mesano  
			WHERE   ANO = 2025
			  AND   MES = 2
			) M02 ON M02.REFERENCIA =  A.REFERENCIA 	
left join  (select  	referencia 
					,	valortotalfaturamentoliquido 		
					,	ec_valorcusto_faturamento_total		
					,	embalagemestoqueqtde				
					,	embalagemcompraqtde			
					,	ticket 
					,	participacao
					,	margem					
			from 	tbtempfaturamentoresumo_mesano  
			WHERE   ANO = 2025
			  AND   MES = 3
			) M03 ON M03.REFERENCIA =  A.REFERENCIA 	
left join  (select  	referencia 
					,	valortotalfaturamentoliquido 		
					,	ec_valorcusto_faturamento_total		
					,	embalagemestoqueqtde				
					,	embalagemcompraqtde			
					,	ticket 
					,	participacao
					,	margem					
			from 	tbtempfaturamentoresumo_mesano  
			WHERE   ANO = 2025
			  AND   MES = 4
			) M04 ON M04.REFERENCIA =  A.REFERENCIA 	
left join  (select  	referencia 
					,	valortotalfaturamentoliquido 		
					,	ec_valorcusto_faturamento_total		
					,	embalagemestoqueqtde				
					,	embalagemcompraqtde			
					,	ticket 
					,	participacao
					,	margem					
			from 	tbtempfaturamentoresumo_mesano  
			WHERE   ANO = 2025
			  AND   MES = 5
			) M05 ON M05.REFERENCIA =  A.REFERENCIA 
left join  (select  	referencia 
					,	valortotalfaturamentoliquido 		
					,	ec_valorcusto_faturamento_total		
					,	embalagemestoqueqtde				
					,	embalagemcompraqtde			
					,	ticket 
					,	participacao
					,	margem					
			from 	tbtempfaturamentoresumo_mesano  
			WHERE   ANO = 2025
			  AND   MES = 6
			) M06 ON M06.REFERENCIA =  A.REFERENCIA 	
left join  (select  	referencia 
					,	valortotalfaturamentoliquido 		
					,	ec_valorcusto_faturamento_total		
					,	embalagemestoqueqtde				
					,	embalagemcompraqtde			
					,	ticket 
					,	participacao
					,	margem					
			from 	tbtempfaturamentoresumo_mesano  
			WHERE   ANO = 2025
			  AND   MES = 7
			) M07 ON M07.REFERENCIA =  A.REFERENCIA 			
						
			
left join  (select  	referencia 
					,	valortotalfaturamentoliquido 		
					,	ec_valorcusto_faturamento_total		
					,	embalagemestoqueqtde				
					,	embalagemcompraqtde			
					,	ticket 
					,	participacao
					,	margem					
			from 	tbtempfaturamentoresumo_mesano  
			WHERE   ANO = 2025
			  AND   MES = 8
			) M08 ON M08.REFERENCIA =  A.REFERENCIA 	

left join  (select  	referencia 
					,	valortotalfaturamentoliquido 		
					,	ec_valorcusto_faturamento_total		
					,	embalagemestoqueqtde				
					,	embalagemcompraqtde			
					,	ticket 
					,	participacao
					,	margem					
			from 	tbtempfaturamentoresumo_mesano  
			WHERE   ANO = 2025
			  AND   MES = 9
			) M09 ON M09.REFERENCIA =  A.REFERENCIA 

left join  (select  	referencia 
					,	valortotalfaturamentoliquido 		
					,	ec_valorcusto_faturamento_total		
					,	embalagemestoqueqtde				
					,	embalagemcompraqtde			
					,	ticket 
					,	participacao
					,	margem					
			from 	tbtempfaturamentoresumo_mesano  
			WHERE   ANO = 2025
			  AND   MES = 10
			) M10 ON M10.REFERENCIA =  A.REFERENCIA 

left join  (select  	referencia 
					,	valortotalfaturamentoliquido 		
					,	ec_valorcusto_faturamento_total		
					,	embalagemestoqueqtde				
					,	embalagemcompraqtde			
					,	ticket 
					,	participacao
					,	margem					
			from 	tbtempfaturamentoresumo_mesano  
			WHERE   ANO = 2025
			  AND   MES = 11
			) M11 ON M11.REFERENCIA =  A.REFERENCIA 
left join  (select  	referencia 
					,	valortotalfaturamentoliquido 		
					,	ec_valorcusto_faturamento_total		
					,	embalagemestoqueqtde				
					,	embalagemcompraqtde			
					,	ticket 
					,	participacao
					,	margem					
			from 	tbtempfaturamentoresumo_mesano 
			WHERE   ANO = 2025
			  AND   MES = 12
			) M12 ON M12.REFERENCIA =  A.REFERENCIA 
						


				SELECT  OP_CDOPERACAO 
					,	SUM(CASE WHEN MES = 1 THEN VALOR  ELSE 0 END) AS MES01_VALOR
					,	''
					,	SUM(CASE WHEN MES = 1 THEN ticket ELSE 0 END) AS MES01_ticket			
					,	SUM(CASE WHEN MES = 2 THEN VALOR  ELSE 0 END) AS MES02_VALOR
					,	''					
					,	SUM(CASE WHEN MES = 2 THEN ticket ELSE 0 END) AS MES02_ticket	
					,	SUM(CASE WHEN MES = 3 THEN VALOR  ELSE 0 END) AS MES03_VALOR
					,	''					
					,	SUM(CASE WHEN MES = 3 THEN ticket ELSE 0 END) AS MES03_ticket	
					,	SUM(CASE WHEN MES = 4 THEN VALOR  ELSE 0 END) AS MES04_VALOR
					,	''					
					,	SUM(CASE WHEN MES = 4 THEN ticket ELSE 0 END) AS MES04_ticket
					,	SUM(CASE WHEN MES = 5 THEN VALOR  ELSE 0 END) AS MES05_VALOR
					,	''					
					,	SUM(CASE WHEN MES = 5 THEN ticket ELSE 0 END) AS MES05_ticket
					,	SUM(CASE WHEN MES = 6 THEN VALOR  ELSE 0 END) AS MES06_VALOR
					,	''					
					,	SUM(CASE WHEN MES = 6 THEN ticket ELSE 0 END) AS MES06_ticket					
					,	SUM(CASE WHEN MES = 7 THEN VALOR  ELSE 0 END) AS MES07_VALOR
					,	''					
					,	SUM(CASE WHEN MES = 7 THEN ticket ELSE 0 END) AS MES07_ticket
					,	SUM(CASE WHEN MES = 8 THEN VALOR  ELSE 0 END) AS MES08_VALOR
					,	''					
					,	SUM(CASE WHEN MES = 8 THEN ticket ELSE 0 END) AS MES08_ticket
					,	SUM(CASE WHEN MES = 9 THEN VALOR  ELSE 0 END) AS MES09_VALOR
					,	''					
					,	SUM(CASE WHEN MES = 9 THEN ticket ELSE 0 END) AS MES09_ticket
					,	SUM(CASE WHEN MES = 10 THEN VALOR  ELSE 0 END) AS MES10_VALOR
					,	''					
					,	SUM(CASE WHEN MES = 10 THEN ticket ELSE 0 END) AS MES10_ticket
					,	SUM(CASE WHEN MES = 11 THEN VALOR  ELSE 0 END) AS MES11_VALOR
					,	''					
					,	SUM(CASE WHEN MES = 11 THEN ticket ELSE 0 END) AS MES11_ticket					
					,	SUM(CASE WHEN MES = 12 THEN VALOR  ELSE 0 END) AS MES12_VALOR
					,	''					
					,	SUM(CASE WHEN MES = 12 THEN ticket ELSE 0 END) AS MES12_ticket										
				FROM    (


							SELECT  F.op_cdoperacao 	
			                    ,	CAST(to_char(f.datafaturamento, 'YYYY') AS INT) AS ANO
								,	CAST(to_char(f.datafaturamento, 'MM') AS INT) AS MES
								,   sum(i.valortotalfaturamentoliquido) as valor 
								,	count(DISTINCT(f.CDPARTICIPANTECLIENTE)) as ticket
			
			                FROM    	tbfaturamentoitens i
							INNER JOIN 	tbproduto p on p.pr_cdproduto = i.pr_cdproduto 
							LEFT JOIN   tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft 
							LEFT JOIN   tbparticipante_bluesoft pt on pt.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fornecedor
			                INNER JOIN 	tbfaturamentoorigem o on o.seqfaturamentoorigem = i.seqfaturamentoorigem
			                INNER JOIN 	tbfaturamento f on f.seqfaturamento = o.seqfaturamento 
			                WHERE 1 = 1
			                AND  f.statusfaturamento = 1 
			                AND  i.statusfaturamentoitem = 1 
			                AND  f.op_cdoperacao = 1
			                AND  f.em_cdempresa = 1 
			                AND  f.datafaturamento >= '2025-01-01'
			                AND  f.datafaturamento <= '2025-12-31'
			                group by 	F.op_cdoperacao 
			                    ,	CAST(to_char(f.datafaturamento, 'YYYY') AS INT)
								,	CAST(to_char(f.datafaturamento, 'MM') AS INT)

					)

					GROUP BY  OP_CDOPERACAO 
