CREATE OR REPLACE 
-- drop 
FUNCTION public.f0070_26_1012019_faturamento_recusa_processar(   
	    vfaturamento_controle_seq integer
    ,	vnumeropedido integer
	,   vnumeropedido_fv integer 
	,	vcdpessoabluesoft_cliente integer
	,   vop_cdoperacao integer
	,   vdf_nf_seq_blue integer
	
)
 RETURNS void
 LANGUAGE plpgsql
AS $function$
 declare  valor_total_a_ratear 		numeric(13,2);
 declare  valor_total_diferenca_rateio numeric(13,2);
 declare  valor_total_faturamento 		numeric(13,2);
 declare  vdf_nf_seq_blue_origem int;
begin
	




	/* AJUSTE STATUS NF SAIDA VINCULADA A ESTA NF DE DEVOLUÇÃO. */


	vdf_nf_seq_blue_origem := (select x.df_nf_seq_blue_origem from tbdocumentofiscalorigem x where x.df_nf_seq_blue = vdf_nf_seq_blue);


    update tbfaturamentoitens i
		set
					
				statusfaturamentoitem = 3 --> faturamento com estorno 
	from 		tbfaturamentoorigem 			o 
	inner join  tbfaturamento_controle 	 	   ct  on ct.faturamento_controle_seq = o.faturamento_controle_seq

	where o.seqfaturamentoorigem = i.seqfaturamentoorigem
	  and ct.df_nf_seq_blue = vdf_nf_seq_blue_origem 
	  and ct.fat_controle_tipo_cd = 1
      and ct.numeropedido = vnumeropedido
	  and ct.numeropedido_fv = vnumeropedido_fv
	  and ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente
	  and ct.op_cdoperacao = vop_cdoperacao

		;

	EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Erro capturado: %', SQLERRM
	;
end;
$function$
