-- FUNCTION: public.f0005_30_1012019_fv_meta_fab_processar(integer)

-- DROP FUNCTION IF EXISTS public.f0005_30_1012019_fv_meta_fab_processar(integer);

CREATE OR REPLACE 
--DROP 
FUNCTION 
public.f0071_10_1012019_interface_faturamento_processar(
		vdata_faturamento_ini date
	  , vdata_faturamento_fim date
	)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100

AS $BODY$
BEGIN 	
    

	/*  ********************************************* DADOS VENDAS EFETIVAS******************************************* 
		**************************************************************************************************************
		**************************************************************************************************************
		**************************************************************************************************************
		**************************************************************************************************************
		**************************************************************************************************************

	*/


	insert into tbinterfacefaturamentoinfoitem
		(       seqinterface
			,   seqfaturamento
			,   seqfaturamentoorigem
			,   datafaturamento
			,   numeropedido
			,   sat_ecf
			,   cupomfiscal
			,   seqitem
			,   pr_cdproduto
			,   embalagemestoque
			,   embalagemestoqueqtde
			,   embalagemcompra
			,   embalagemcompraqtde
			,   valortotalfaturamento

			,   cdparticipantecliente
			,   cdparticipantevendedor
			,   seqprocessamentoitemdocumento
			,   cdoperacao
			,   cdparticipantecliente_original
			,   cdparticipantevendedor_original

		)
	select

				ic.seqinterface                         as seqinterface
			,   f.seqfaturamento                        as seqfaturamento
			,   o.seqfaturamentoorigem                  as seqfaturamentoorigem
			,   f.datafaturamento                       as datafaturamento
			,   o.numeropedido                          as numeropedido
			,   coalesce(o.sat_ecf,0)                   as sat_ecf
			,   coalesce(o.cupomfiscal,0)               as cupomfiscal
			,   i.seqitem                               as seqitem
			,   pr.pr_cdproduto                         as pr_cdproduto
			,   pr.pr_embalagemestoque                  as embalagemestoque
			,   i.embalagemestoqueqtde                  as embalagemestoqueqtde
			,   pr.pr_embalagemcompra                   as embalagemcompra
			,   i.embalagemcompraqtde                   as embalagemcompraqtde
			,   i.valortotalfaturamento                 as valortotalfaturamento
			,   f.cdparticipantecliente                 as cdparticipantecliente
			,   f.cdparticipantevendedor                as cdparticipantevendedor
	
			,   cast(case f.op_cdoperacao
					when 1 then '1'
						|| repeat('0', greatest(0, 9 - length(o.numeronfe::varchar)))
						|| o.numeronfe::varchar
					when 4 then '1'
						|| repeat('0', greatest(0, 9 - length(o.numeronfe::varchar)))
						|| o.numeronfe::varchar
					when 2 then '2'
						|| repeat('0', greatest(0, 3 - length(o.sat_ecf::varchar)))
						|| o.sat_ecf::varchar
						|| repeat('0', greatest(0, 6 - length(o.cupomfiscal::varchar)))
						|| o.cupomfiscal::varchar
					else '0'
				end as int)                                    as seqprocessamentoitemdocumento
			,   f.op_cdoperacao                         as cdoperacao
			,   f.cdparticipantecliente                 as cdparticipantecliente_original
			,   f.cdparticipantevendedor                as cdparticipantevendedor_original					

	from        tbfaturamentoitens       i
	inner join  tbfaturamentoorigem      o  on o.seqfaturamentoorigem = i.seqfaturamentoorigem
	inner join  tbfaturamento            f  on f.seqfaturamento = o.seqfaturamento
	inner join  tbproduto                pr on pr.pr_cdproduto = i.pr_cdproduto
	inner join  tbprodutobluesoft        pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
	inner join  tbforca_venda_fabricante fv on fv.fv_fabricante_cdpessoabluesoft = pb.prb_cdpessoabluesoft_fabricante
	inner join  tbinterface              ic on ic.cdpessoabluesoft = fv.fv_fabricante_cdpessoabluesoft
	where       1 = 1
	and         f.datafaturamento >= vdata_faturamento_ini
	and         f.datafaturamento <= vdata_faturamento_fim
	and         not exists (	select 1 
								from  tbinterfacefaturamentoinfoitem ii
								where ii.seqfaturamento = f.seqfaturamento
								and  ii.seqfaturamentoorigem = o.seqfaturamentoorigem
								and  ii.pr_cdproduto = i.pr_cdproduto
								and  ii.cdparticipantecliente = f.cdparticipantecliente
								and  ii.datafaturamento = f.datafaturamento
						)
	;
end	

$BODY$;

;
--SELECT f0071_10_1012019_interface_faturamento_processar('2026-10-01')
-- SELECT * FROM f0071_10_1012019_interface_faturamento_processar ( vdata_faturamento_ini:= '2026-10-01', vdata_faturamento_fim:= '2026-10-26')