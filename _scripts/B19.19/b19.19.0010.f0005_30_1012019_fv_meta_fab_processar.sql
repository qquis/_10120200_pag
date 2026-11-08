-- FUNCTION: public.f0021_90_1012019_produtobluesoft_processamento()

-- DROP FUNCTION IF EXISTS public.f0021_90_1012019_produtobluesoft_processamento();

CREATE OR REPLACE 
-- drop 
FUNCTION public.f0005_30_1012019_fv_meta_fab_processar(vfv_fab_meta_cd int)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
	declare vvfv_fab_meta_cd int;
	declare vvdata_faturamento_ini date;
	declare vvdata_faturamento_fim date;
BEGIN 	
    if (vfv_fab_meta_cd =0) 
    then
        vvfv_fab_meta_cd := (select max(fv_fab_meta_cd) from tbforca_venda_fab_meta);
    else
        vvfv_fab_meta_cd := vfv_fab_meta_cd;
    end if;
    

	vvdata_faturamento_ini := (select fv_fab_data_ini from tbforca_venda_fab_meta where fv_fab_meta_cd = vvfv_fab_meta_cd);
	vvdata_faturamento_fim := (select fv_fab_data_fim from tbforca_venda_fab_meta where fv_fab_meta_cd = vvfv_fab_meta_cd);
    






/*  ********************************************* DADOS ANALITICOS ********************************************** 
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************

*/

	drop table if exists tmp_forca_venda_fab_meta_res_item;

	create temporary table tmp_forca_venda_fab_meta_res_item
	(
		
			seqinterface 					int
		,   datafaturamento         		date
		,   op_cdoperacao           		int
		,   seqfaturamento          		int
		,   seqfaturamentoorigem    		int
		,   seqprocessamentoitemdocumento	int
		,   cdparticipantecliente           INT
		,   pr_cdproduto            		int
		,	fv_fab_meta_cd					int 
		,	fv_fab_meta_grupo_cd			int
		,   embalagemestoqueqtde            int
		,   embalagemcompraqtde             int

	)
	;
		insert into tmp_forca_venda_fab_meta_res_item
		(
			seqinterface
		,   datafaturamento
		,   op_cdoperacao
		,   seqfaturamento
		,   seqfaturamentoorigem
		,   seqprocessamentoitemdocumento
		,   pr_cdproduto
		,	fv_fab_meta_cd
		,	fv_fab_meta_grupo_cd
		,   cdparticipantecliente
		,   embalagemestoqueqtde
		,   embalagemcompraqtde
		)





     	Select		0
		        ,   f.datafaturamento
				,   f.op_cdoperacao
				,   f.seqfaturamento
				,   o.seqfaturamentoorigem
				,   0
				,   pr.pr_cdproduto
				,	ix.fv_fab_meta_cd
				,   ix.fv_fab_meta_grupo_cd
				,	f.cdparticipantecliente
				,	sum(I.EmbalagemEstoqueQtde)
				,	sum(i.EmbalagemCompraQtde)

		From		tbfaturamento						f
		inner join  tbfaturamentoorigem 				o	on o.SeqFaturamento = f.SeqFaturamento 
		inner join  tbfaturamentoitens					i	on i.SeqFaturamentoOrigem = o.SeqFaturamentoOrigem 
        inner join  tbproduto							pr  on pr.pr_cdproduto = i.pr_cdproduto
        inner join  tbforca_venda_fab_meta_grupo_item	ix  on ix.pr_cdproduto = i.pr_cdproduto
		WHERE		1 = 1
		and         ix.fv_fab_meta_cd = vvfv_fab_meta_cd
		and			f.StatusFaturamento = 1
		and			i.StatusFaturamentoItem = 1
		and			f.DataFaturamento >= vvdata_faturamento_ini
		and			f.DataFaturamento <= vvdata_faturamento_fim
		and			f.em_cdempresa = 1
		and         f.op_cdoperacao = 1
        group by    
		           f.datafaturamento
				,   f.op_cdoperacao
				,   f.seqfaturamento
				,   o.seqfaturamentoorigem

				,   pr.pr_cdproduto
				,	ix.fv_fab_meta_cd
				,   ix.fv_fab_meta_grupo_cd
				,	f.cdparticipantecliente

	;


	delete from tbforca_venda_fab_meta_res_item a
	where not exists ( 
			select 1 from tmp_forca_venda_fab_meta_res_item b
			where a.seqinterface = b.seqinterface
			and   a.datafaturamento = b.datafaturamento
			and   a.op_cdoperacao = b.op_cdoperacao
			and   a.seqfaturamento = b.seqfaturamento
			and   a.seqfaturamentoorigem = b.seqfaturamentoorigem
			and   a.seqprocessamentoitemdocumento = b.seqprocessamentoitemdocumento
			and   a.pr_cdproduto = b.pr_cdproduto
			and   a.fv_fab_meta_cd = b.fv_fab_meta_cd
			and   a.fv_fab_meta_grupo_cd = b.fv_fab_meta_grupo_cd
			and   a.cdparticipantecliente = b.cdparticipantecliente
	)
	;


	insert into tbforca_venda_fab_meta_res_item
	(
		seqinterface
	,   datafaturamento
	,   op_cdoperacao
	,   seqfaturamento
	,   seqfaturamentoorigem
	,   seqprocessamentoitemdocumento
	,   pr_cdproduto
	,	fv_fab_meta_cd
	,	fv_fab_meta_grupo_cd
	,   cdparticipantecliente
	,   embalagemestoqueqtde
	,   embalagemcompraqtde
	)
	select
				seqinterface
			,   datafaturamento
			,   op_cdoperacao
			,   seqfaturamento
			,   seqfaturamentoorigem
			,   seqprocessamentoitemdocumento
			,   pr_cdproduto
			,	fv_fab_meta_cd
			,	fv_fab_meta_grupo_cd
			,   cdparticipantecliente
			,   embalagemestoqueqtde
			,   embalagemcompraqtde
			from tmp_forca_venda_fab_meta_res_item a
			where not exists (
				select 1
				from tbforca_venda_fab_meta_res_item b
				where a.seqinterface = b.seqinterface
				and a.datafaturamento = b.datafaturamento
				and a.op_cdoperacao = b.op_cdoperacao
				and a.seqfaturamento = b.seqfaturamento
				and a.seqfaturamentoorigem = b.seqfaturamentoorigem
				and a.seqprocessamentoitemdocumento = b.seqprocessamentoitemdocumento
				and a.pr_cdproduto = b.pr_cdproduto
				and a.fv_fab_meta_cd = b.fv_fab_meta_cd
				and a.fv_fab_meta_grupo_cd = b.fv_fab_meta_grupo_cd
				and a.cdparticipantecliente = b.cdparticipantecliente
			)


	;

	update tbforca_venda_fab_meta_res_item a
	set   
		embalagemestoqueqtde = b.embalagemestoqueqtde,
		embalagemcompraqtde = b.embalagemcompraqtde
	from 	tmp_forca_venda_fab_meta_res_item b
	where 	a.seqinterface = b.seqinterface
	and 	a.datafaturamento = b.datafaturamento
	and 	a.op_cdoperacao = b.op_cdoperacao
	and 	a.seqfaturamento = b.seqfaturamento
	and 	a.seqfaturamentoorigem = b.seqfaturamentoorigem
	and 	a.seqprocessamentoitemdocumento = b.seqprocessamentoitemdocumento
	and 	a.pr_cdproduto = b.pr_cdproduto
	and 	a.fv_fab_meta_cd = b.fv_fab_meta_cd
	and 	a.fv_fab_meta_grupo_cd = b.fv_fab_meta_grupo_cd
	and     a.cdparticipantecliente = b.cdparticipantecliente;




























/*  ********************************************* RESULTADO CLIENTE ********************************************** 
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************

*/



	drop table if exists tmp_forca_venda_fab_meta_cliente_grupo;
	create temporary table tmp_forca_venda_fab_meta_cliente_grupo 
	(
			seqinterface int			
		,	fv_fab_meta_cd	int		
		,	fv_fab_meta_grupo_cd int	
		,	cdparticipantecliente 	int	
		,	embalagemestoqueqtde		numeric (17,4)	
		,	embalagemcompraqtde		numeric (17,4)

	)

	;



	create temporary table tmp_forca_venda_fab_meta_item
	(
			seqinterface int			
		,	fv_fab_meta_cd	int		
		,	fv_fab_meta_grupo_cd int	
		,	pr_cdproduto 	int	
		,	embalagemestoqueqtde		numeric (17,4)	
		,	embalagemcompraqtde		numeric (17,4)

	)
	;

    
    insert into tmp_forca_venda_fab_meta_cliente_grupo
	 (

			seqinterface 			
		,	fv_fab_meta_cd			
		,	fv_fab_meta_grupo_cd	
		,	cdparticipantecliente	
		,	embalagemestoqueqtde	
		,	embalagemcompraqtde		

     )

     	Select		0
				,	ix.fv_fab_meta_cd
				,   ix.fv_fab_meta_grupo_cd
				,	f.cdparticipantecliente
				--,	f.cdparticipantevendedor
				,	sum(I.EmbalagemEstoqueQtde)
				,	sum(i.EmbalagemCompraQtde)

		From		tbfaturamento						f
		inner join  tbfaturamentoorigem 				o	on o.SeqFaturamento = f.SeqFaturamento 
		inner join  tbfaturamentoitens					i	on i.SeqFaturamentoOrigem = o.SeqFaturamentoOrigem 
        inner join  tbproduto							pr  on pr.pr_cdproduto = i.pr_cdproduto
        inner join  tbforca_venda_fab_meta_grupo_item	ix  on ix.pr_cdproduto = i.pr_cdproduto
		WHERE		1 = 1
		and         ix.fv_fab_meta_cd = vvfv_fab_meta_cd
		and			f.StatusFaturamento = 1
		and			i.StatusFaturamentoItem = 1
		and			f.DataFaturamento >= vvdata_faturamento_ini
		and			f.DataFaturamento <= vvdata_faturamento_fim
		and			f.em_cdempresa = 1
		and         f.op_cdoperacao = 1
        group by    ix.fv_fab_meta_cd
                   , ix.fv_fab_meta_grupo_cd
                   , f.cdparticipantecliente

	;


	insert into tmp_forca_venda_fab_meta_cliente_grupo
		(

				seqinterface 			
			,	fv_fab_meta_cd			
			,	fv_fab_meta_grupo_cd	
			,	cdparticipantecliente	
			--,	cdparticipantevendedor	
			,	embalagemestoqueqtde	
			,	embalagemcompraqtde		

		)

		select 		i.seqinterface
				, 	ix.fv_fab_meta_cd
				,   ix.fv_fab_meta_grupo_cd
				,	i.cdparticipantecliente
				,	sum(i.EmbalagemEstoqueQtde)
				,	sum(i.EmbalagemCompraQtde)
		from 		tbinterfacefaturamentoinfoitem i
		inner join  tbforca_venda_fab_meta_grupo_item	ix  on ix.pr_cdproduto = i.pr_cdproduto
		where		1 = 1
			and         ix.fv_fab_meta_cd = vvfv_fab_meta_cd	
			and			i.DataFaturamento >= vvdata_faturamento_ini
			and			i.DataFaturamento <= vvdata_faturamento_fim
		group by    i.seqinterface
				, 	ix.fv_fab_meta_cd
				,   ix.fv_fab_meta_grupo_cd
				,	i.cdparticipantecliente
	;



	insert into tbforca_venda_fab_meta_res_cliente_grupo
	(
				seqinterface 			
			,	fv_fab_meta_cd			
			,	fv_fab_meta_grupo_cd	
			,	cdparticipantecliente	
			,	embalagemestoqueqtde	
			,	embalagemcompraqtde		
		
	)
	select		 seqinterface 			
			,	fv_fab_meta_cd			
			,	fv_fab_meta_grupo_cd	
			,	cdparticipantecliente	
			,	embalagemestoqueqtde	
			,	embalagemcompraqtde	
	from tmp_forca_venda_fab_meta_cliente_grupo x
	where not exists (
		select 1
		from tbforca_venda_fab_meta_res_cliente_grupo r
		where r.seqinterface = x.seqinterface
		and   r.fv_fab_meta_cd = x.fv_fab_meta_cd
		and   r.fv_fab_meta_grupo_cd = x.fv_fab_meta_grupo_cd
		and   r.cdparticipantecliente = x.cdparticipantecliente
	);


	update  tbforca_venda_fab_meta_res_cliente_grupo r
	set 	embalagemestoqueqtde = t.embalagemestoqueqtde,
			embalagemcompraqtde = t.embalagemcompraqtde,
			dtlog_update = current_timestamp
	from 	tmp_forca_venda_fab_meta_cliente_grupo t
	where   r.seqinterface = t.seqinterface
	and     r.fv_fab_meta_cd = t.fv_fab_meta_cd
	and     r.fv_fab_meta_grupo_cd = t.fv_fab_meta_grupo_cd
	and     r.cdparticipantecliente = t.cdparticipantecliente
	and     (		r.embalagemestoqueqtde <> t.embalagemestoqueqtde
				or  r.embalagemcompraqtde <> t.embalagemcompraqtde
			)
	;








	/* CALCULANDO O RESULTADO CLIENTE MIX *******************************************************************************************************************/
	/* ******************************************************************************************************************************************************/
	/* ******************************************************************************************************************************************************/
	/* ******************************************************************************************************************************************************/
	/* ******************************************************************************************************************************************************/
	/* ******************************************************************************************************************************************************/
	/* ******************************************************************************************************************************************************/

	create temporary table tmp_forca_venda_fab_meta_res_cliente_mix
	(
				seqinterface INT			
			,	fv_fab_meta_cd	INT		
			,	cdparticipantecliente INT	
			,	fv_fab_meta_mix_cd	INT	
			,	fv_fab_meta_grupo_cd_qtde	INT
	);

	insert into tmp_forca_venda_fab_meta_res_cliente_mix
	(
				seqinterface 			
			,	fv_fab_meta_cd			
			,	cdparticipantecliente	
			,	fv_fab_meta_mix_cd	
			,	fv_fab_meta_grupo_cd_qtde
	)
	select 	
			i.seqinterface
		,	i.fv_fab_meta_cd
		,	i.cdparticipantecliente 
		,   m.fv_fab_meta_mix_cd 
		,   count(distinct i.fv_fab_meta_grupo_cd)
		--,   embalagemestoqueqtde

	from 		tbforca_venda_fab_meta_res_cliente_grupo i
	inner join  tbforca_venda_fab_meta_mix_grupo m on m.fv_fab_meta_grupo_cd = i.fv_fab_meta_grupo_cd
	where   1 = 1
	and     embalagemestoqueqtde >= 3
	group by 
			i.seqinterface
		,	i.fv_fab_meta_cd
		,	i.cdparticipantecliente 
		,   m.fv_fab_meta_mix_cd 
	;
	/* INSERINDO NOVOS REGISTROS A PARTIR DA TABELA TEMPORARIA */
			INSERT INTO tbforca_venda_fab_meta_res_cliente_mix
			(
						seqinterface 			
					,	fv_fab_meta_cd			
					,	cdparticipantecliente	
					,	fv_fab_meta_mix_cd	
					,	fv_fab_meta_grupo_cd_qtde
			)
			select 
					seqinterface
				,	fv_fab_meta_cd
				,	cdparticipantecliente
				,	fv_fab_meta_mix_cd
				,	fv_fab_meta_grupo_cd_qtde
			from 	tmp_forca_venda_fab_meta_res_cliente_mix A
			where not exists (select 1
							from 	tbforca_venda_fab_meta_res_cliente_mix r
							where 	r.seqinterface = A.seqinterface
							and 	r.fv_fab_meta_cd = A.fv_fab_meta_cd
							and 	r.cdparticipantecliente = A.cdparticipantecliente
							and 	r.fv_fab_meta_mix_cd = A.fv_fab_meta_mix_cd
							)
	;

	/* ATUALIZANDO A PARTIR DA TABELA TEMPORARIA  */
			update tbforca_venda_fab_meta_res_cliente_mix r
			set 	fv_fab_meta_grupo_cd_qtde = t.fv_fab_meta_grupo_cd_qtde
				,   dtlog_update = current_timestamp
			from  tmp_forca_venda_fab_meta_res_cliente_mix t
			where 	r.seqinterface = t.seqinterface
			and 	r.fv_fab_meta_cd = t.fv_fab_meta_cd
			and 	r.cdparticipantecliente = t.cdparticipantecliente
			and 	r.fv_fab_meta_mix_cd = t.fv_fab_meta_mix_cd
			and	 	r.fv_fab_meta_grupo_cd_qtde <> t.fv_fab_meta_grupo_cd_qtde


	;



/*  ********************************************* RESULTADO VENDEDOR ********************************************* 
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************

*/

	drop table if exists tmp_forca_venda_fab_meta_res_vendedor;
	create temporary table tmp_forca_venda_fab_meta_res_vendedor
	(
						seqinterface 				int
					,	fv_fab_meta_cd				int 
					,	cdparticipantevendedor		int
					,	fv_fab_meta_mix_cd	    	int
					,	qtde_positivacao			int

	)



;
	/*	MIX JA CONTABILIZADO
		------------------------------------------------------------------------------------------------------
	*/
	insert into tmp_forca_venda_fab_meta_res_vendedor
	(
						seqinterface 				
					,	fv_fab_meta_cd				
					,	cdparticipantevendedor		
					,	fv_fab_meta_mix_cd	    	
					,	qtde_positivacao			

	)


	select     a.seqinterface
			,  a.fv_fab_meta_cd
			,  v.cdparticipante as cdparticipantevendedor
			,  a.fv_fab_meta_mix_cd
			,  count(DISTINCT(a.cdparticipantecliente))
	from 		tbforca_venda_fab_meta_res_cliente_mix A
	inner join 	tbforca_venda_fab_meta_mix b on b.fv_fab_meta_cd = A.fv_fab_meta_cd and b.fv_fab_meta_mix_cd = A.fv_fab_meta_mix_cd
	inner join  tbparticipante	        	c on c.cdparticipante = a.cdparticipantecliente
	INNER JOIN	tbparticipante_bluesoft		ps on ps.cdpessoabluesoft = c.cdpessoabluesoft
	INNER join  tbparticipante_bluesoft		v on v.cdpessoabluesoft = ps.cdpessoabluesoft_vendedor
	WHERE       1 = 1
	AND         a.fv_fab_meta_cd = 2026001
	AND         a.fv_fab_meta_grupo_cd_qtde >= b.fv_fab_meta_mix_grupo_qtde_minima
	group by 
	a.fv_fab_meta_cd
			, a.seqinterface
			, a.fv_fab_meta_mix_cd
			, v.cdparticipante

	;
	/*	POSITIVACAO GERAL
		------------------------------------------------------------------------------------------------------
	*/	

	insert into tmp_forca_venda_fab_meta_res_vendedor
	(
						seqinterface 				
					,	fv_fab_meta_cd				
					,	cdparticipantevendedor		
					,	fv_fab_meta_mix_cd	    	
					,	qtde_positivacao			

	)

		Select		0
				,	m.fv_fab_meta_cd
				,	f.cdparticipantevendedor
				,	99
				,   count(distinct f.cdparticipantecliente)
			From		tbfaturamento						f
			inner join  tbfaturamentoorigem 				o	on o.SeqFaturamento = f.SeqFaturamento 
			inner join  tbfaturamentoitens					i	on i.SeqFaturamentoOrigem = o.SeqFaturamentoOrigem 
			inner join  tbproduto							pr  on pr.pr_cdproduto = i.pr_cdproduto
			inner join  tbprodutobluesoft                   pb  on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
			inner join  tbforca_venda_fab_meta              m   on m.fv_fabricante_cdpessoabluesoft = pb.prb_cdpessoabluesoft_fabricante 
			WHERE		1 = 1
			and         m.fv_fab_meta_cd = vvfv_fab_meta_cd
			and			f.StatusFaturamento = 1
			and			i.StatusFaturamentoItem = 1
			and			f.DataFaturamento >= vvdata_faturamento_ini
			and			f.DataFaturamento <= vvdata_faturamento_fim
			and			f.em_cdempresa = 1
			and         f.op_cdoperacao = 1

			group by    m.fv_fab_meta_cd
					, f.cdparticipantevendedor

	;

		insert into tmp_forca_venda_fab_meta_res_vendedor
	(
						seqinterface 				
					,	fv_fab_meta_cd				
					,	cdparticipantevendedor		
					,	fv_fab_meta_mix_cd	    	
					,	qtde_positivacao			

	)



			Select	i.seqinterface
				,	m.fv_fab_meta_cd
				,	I.cdparticipantevendedor
				,	99
				,   count(distinct I.cdparticipantecliente)

			From		tbinterfacefaturamentoinfoitem					i	
			inner join  tbproduto							pr  on pr.pr_cdproduto = i.pr_cdproduto
			inner join  tbprodutobluesoft                   pb  on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
			inner join  tbforca_venda_fab_meta              m   on m.fv_fabricante_cdpessoabluesoft = pb.prb_cdpessoabluesoft_fabricante 
			WHERE		1 = 1
			and         m.fv_fab_meta_cd = vvfv_fab_meta_cd
			and			i.DataFaturamento >= vvdata_faturamento_ini
			and			i.DataFaturamento <= vvdata_faturamento_fim
			group by  i.seqinterface
				,	m.fv_fab_meta_cd
				,	I.cdparticipantevendedor
	;

	/*	ATUALIZACAO 
		------------------------------------------------------------------------------------------------------
	*/	

	insert into tbforca_venda_fab_meta_res_vendedor
	(
			seqinterface 				
		,	fv_fab_meta_cd				
		,	cdparticipantevendedor		
		,	fv_fab_meta_mix_cd	    	
		,	qtde_positivacao			
	)

	select 		x.seqinterface 				
			,	x.fv_fab_meta_cd				
			,	x.cdparticipantevendedor		
			,	x.fv_fab_meta_mix_cd	    	
			,	x.qtde_positivacao			
	from tmp_forca_venda_fab_meta_res_vendedor x
	where not exists (
			select 1
			from tbforca_venda_fab_meta_res_vendedor y
			where y.seqinterface = x.seqinterface
			and y.fv_fab_meta_cd = x.fv_fab_meta_cd
			and y.cdparticipantevendedor = x.cdparticipantevendedor
			and y.fv_fab_meta_mix_cd = x.fv_fab_meta_mix_cd
		)


	;


	update 	tbforca_venda_fab_meta_res_vendedor a
	set 	qtde_positivacao = x.qtde_positivacao
	from 	tmp_forca_venda_fab_meta_res_vendedor x
	where 	a.seqinterface = x.seqinterface
	and 	a.fv_fab_meta_cd = x.fv_fab_meta_cd
	and 	a.cdparticipantevendedor = x.cdparticipantevendedor
	and 	a.fv_fab_meta_mix_cd = x.fv_fab_meta_mix_cd;







	end;
	$BODY$;

SELECT f0005_30_1012019_fv_meta_fab_processar(2026001)

/*
SELECT * FROM tbforca_venda_fab_meta_res_vendedor


SELECT 		cdparticipantevendedor
	   ,    v.cdpessoabluesoft
	   ,    v.nome_razao
	   ,	sum(case when fv_fab_meta_mix_cd = 99 then qtde_positivacao else 0 end ) as pos
	   ,	sum(case when fv_fab_meta_mix_cd = 2 then qtde_positivacao else 0 end )  as mix02	   
	   ,	sum(case when fv_fab_meta_mix_cd = 7 then qtde_positivacao else 0 end )  as mix07
	   ,	sum(case when fv_fab_meta_mix_cd = 17 then qtde_positivacao else 0 end ) as mix17
	   ,	sum(case when fv_fab_meta_mix_cd = 28 then qtde_positivacao else 0 end ) as mix28
from   	tbforca_venda_fab_meta_res_vendedor
inner join tbparticipante_bluesoft v on v.cdparticipante = cdparticipantevendedor
where   1 = 1
and     fv_fab_meta_cd = 2026001
and     seqinterface = 0
group by cdparticipantevendedor, v.cdpessoabluesoft, v.nome_razao


select * from tbforca_venda_meta_tipo
select * from tbforca_venda_fab_meta_grupo_item
select * from tbforca_venda_fab_meta_grupo
select * from tbforca_venda_fab_meta_mix where fv_fab_meta_cd = 2026001
select * from tbforca_venda_fab_meta_mix_grupo  where fv_fab_meta_cd = 2026001



	Select		0
				,	ix.fv_fab_meta_cd
				,   ix.fv_fab_meta_grupo_cd
				,	f.cdparticipantecliente
				,	f.cdparticipantevendedor
				,	sum(I.EmbalagemEstoqueQtde)
				,	sum(i.EmbalagemCompraQtde)

		From		tbfaturamento						f
		inner join  tbfaturamentoorigem 				o	on o.SeqFaturamento = f.SeqFaturamento 
		inner join  tbfaturamentoitens					i	on i.SeqFaturamentoOrigem = o.SeqFaturamentoOrigem 
        inner join  tbproduto							pr  on pr.pr_cdproduto = i.pr_cdproduto
        inner join  tbforca_venda_fab_meta_grupo_item	ix  on ix.pr_cdproduto = i.pr_cdproduto
		WHERE		1 = 1
		and         ix.fv_fab_meta_cd = 2026001
		and			f.StatusFaturamento = 1
		and			i.StatusFaturamentoItem = 1
		and			f.DataFaturamento >= '2026-07-01'
		and			f.DataFaturamento <= '2026-07-31'
		and			f.em_cdempresa = 1
		and         f.op_cdoperacao = 1
        group by    ix.fv_fab_meta_cd
                   , ix.fv_fab_meta_grupo_cd
                   , f.cdparticipantecliente
                   , f.cdparticipantevendedor



select * from tbforca_venda_fab_meta_res_cliente_mix






SELECT cdparticipantecliente, fv_fab_meta_grupo_cd, count(cdparticipantevendedor) 
FROM tbforca_venda_fab_meta_resultado_cliente
GROUP BY cdparticipantecliente, fv_fab_meta_grupo_cd
having count(cdparticipantevendedor) > 1;


select * from tbparticipante_bluesoft where cdparticipante = 18807


SELECT cdparticipantecliente, fv_fab_meta_grupo_cd, cdparticipantevendedor
FROM tbforca_venda_fab_meta_resultado_cliente
WHERE cdparticipantecliente = 18807
and   fv_fab_meta_cd = 2026001
and fv_fab_meta_grupo_cd = 12
GROUP BY cdparticipantecliente, fv_fab_meta_grupo_cd



select * from tbparticipante_bluesoft where cdparticipante in( 19, 124692)


SELECT * FROM tb	


select * from tbforca_venda_fab_meta_resultado_cliente

select * from tbparticipante_bluesoft limit 10



 SELECT		c.cdparticipante                as cdparticipantecliente
                                    ,	ps.cdpessoabluesoft             as cdpessoabluesoftcliente
                                    ,	ps.nome_razao                   as nomecliente
                                    ,   ps.cpf_cnpj                     as cpf_cnpj
                                    ,	ps.cdpessoabluesoft_vendedor    as cdpessoabluesoftvendedor
                                    ,	v.cdparticipante                as cdparticipantevendedor
                                    ,   v.nome_razao                    as nomevendedor
                                    ,	ps.cdgrupoeconomico             as cdgrupoeconomico
                                    ,	gr.descricao                    as grupoeconomico
                                    ,	ps.cpf_cnpj 
									
									,   coalesce(mix.mix02, 0) as mix02
									,   coalesce(mix.mix07, 0) as mix07
									,   coalesce(mix.mix17, 0) as mix17
									,   coalesce(mix.mix28, 0) as mix28

									,   coalesce(grupo.G01, 0) as G01
									,   coalesce(grupo.G02, 0) as G02
									,   coalesce(grupo.G03, 0) as G03
									,   coalesce(grupo.G04, 0) as G04
									,   coalesce(grupo.G05, 0) as G05
									,   coalesce(grupo.G06, 0) as G06
									,   coalesce(grupo.G07, 0) as G07
									,   coalesce(grupo.G08, 0) as G08
									,   coalesce(grupo.G09, 0) as G09
									,   coalesce(grupo.G10, 0) as G10
									,   coalesce(grupo.G11, 0) as G11
									,   coalesce(grupo.G12, 0) as G12
									,   coalesce(grupo.G13, 0) as G13
									,   coalesce(grupo.G14, 0) as G14
									,   coalesce(grupo.G15, 0) as G15
									,   coalesce(grupo.G16, 0) as G16
									,   coalesce(grupo.G17, 0) as G17
									,   coalesce(grupo.G18, 0) as G18
									,   coalesce(grupo.G19, 0) as G19
									,   coalesce(grupo.G20, 0) as G20
									,   coalesce(grupo.G21, 0) as G21
									,   coalesce(grupo.G22, 0) as G22
									,   coalesce(grupo.G23, 0) as G23
									,   coalesce(grupo.G24, 0) as G24
									,   coalesce(grupo.G25, 0) as G25
									,   coalesce(grupo.G26, 0) as G26
									,   coalesce(grupo.G27, 0) as G27
									,   coalesce(grupo.G28, 0) as G28
									





                            FROM		tbparticipante	        c
                            INNER JOIN	tbparticipante_bluesoft	ps on ps.cdpessoabluesoft = c.cdpessoabluesoft
                            INNER JOIN  tbgrupoeconomico          gr on gr.cdgrupoeconomico = ps.cdgrupoeconomico
                            INNER join  tbparticipante_bluesoft	v on v.cdpessoabluesoft = ps.cdpessoabluesoft_vendedor
							LEFT JOIN   ( SELECT cdparticipantecliente
										  	,	 case when fv_fab_meta_mix_cd =  2 then fv_fab_meta_grupo_cd_qtde else 0 end as mix02
											,	 case when fv_fab_meta_mix_cd =  7 then fv_fab_meta_grupo_cd_qtde else 0 end as mix07
											,	 case when fv_fab_meta_mix_cd = 17 then fv_fab_meta_grupo_cd_qtde else 0 end as mix17
											,	 case when fv_fab_meta_mix_cd = 28 then fv_fab_meta_grupo_cd_qtde else 0 end as mix28
										  
										  FROM tbforca_venda_fab_meta_res_cliente_mix
										  where seqinterface = 0
										) as mix on mix.cdparticipantecliente = c.cdparticipante
							LEFT JOIN   (
											SELECT cdparticipantecliente
												,  case when fv_fab_meta_grupo_cd = 1 then embalagemestoqueqtde else 0 end as G01
												,  case when fv_fab_meta_grupo_cd = 2 then embalagemestoqueqtde else 0 end as G02
												,  case when fv_fab_meta_grupo_cd = 3 then embalagemestoqueqtde else 0 end as G03
												,  case when fv_fab_meta_grupo_cd = 4 then embalagemestoqueqtde else 0 end as G04
												,  case when fv_fab_meta_grupo_cd = 5 then embalagemestoqueqtde else 0 end as G05
												,  case when fv_fab_meta_grupo_cd = 6 then embalagemestoqueqtde else 0 end as G06
												,  case when fv_fab_meta_grupo_cd = 7 then embalagemestoqueqtde else 0 end as G07
												,  case when fv_fab_meta_grupo_cd = 8 then embalagemestoqueqtde else 0 end as G08
												,  case when fv_fab_meta_grupo_cd = 9 then embalagemestoqueqtde else 0 end as G09
												,  case when fv_fab_meta_grupo_cd = 10 then embalagemestoqueqtde else 0 end as G10
												,  case when fv_fab_meta_grupo_cd = 11 then embalagemestoqueqtde else 0 end as G11
												,  case when fv_fab_meta_grupo_cd = 12 then embalagemestoqueqtde else 0 end as G12
												,  case when fv_fab_meta_grupo_cd = 13 then embalagemestoqueqtde else 0 end as G13
												,  case when fv_fab_meta_grupo_cd = 14 then embalagemestoqueqtde else 0 end as G14
												,  case when fv_fab_meta_grupo_cd = 15 then embalagemestoqueqtde else 0 end as G15
												,  case when fv_fab_meta_grupo_cd = 16 then embalagemestoqueqtde else 0 end as G16
												,  case when fv_fab_meta_grupo_cd = 17 then embalagemestoqueqtde else 0 end as G17
												,  case when fv_fab_meta_grupo_cd = 18 then embalagemestoqueqtde else 0 end as G18
												,  case when fv_fab_meta_grupo_cd = 19 then embalagemestoqueqtde else 0 end as G19
												,  case when fv_fab_meta_grupo_cd = 20 then embalagemestoqueqtde else 0 end as G20
												,  case when fv_fab_meta_grupo_cd = 21 then embalagemestoqueqtde else 0 end as G21
												,  case when fv_fab_meta_grupo_cd = 22 then embalagemestoqueqtde else 0 end as G22
												,  case when fv_fab_meta_grupo_cd = 23 then embalagemestoqueqtde else 0 end as G23
												,  case when fv_fab_meta_grupo_cd = 24 then embalagemestoqueqtde else 0 end as G24
												,  case when fv_fab_meta_grupo_cd = 25 then embalagemestoqueqtde else 0 end as G25
												,  case when fv_fab_meta_grupo_cd = 26 then embalagemestoqueqtde else 0 end as G26
												,  case when fv_fab_meta_grupo_cd = 27 then embalagemestoqueqtde else 0 end as G27
												,  case when fv_fab_meta_grupo_cd = 28 then embalagemestoqueqtde else 0 end as G28
											from tbforca_venda_fab_meta_res_cliente_grupo
											where seqinterface = 0
							
										) as grupo on grupo.cdparticipantecliente = c.cdparticipante
	
                            where		1 = 1
                            and			gr.cdgrupoeconomico <> 0 
                            and         ps.cdpessoabluesoft_vendedor <> 0 
                            and         ps.bluesoftclientestatus = 1


select * from tbforca_venda_fab_meta_res_cliente_mix


*/				   


