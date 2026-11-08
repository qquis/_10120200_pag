CREATE OR REPLACE FUNCTION public.f0055_61_1012018_faturamento_cupom_cancelamento(vdata_processamento date)
 RETURNS void
 LANGUAGE plpgsql
AS $function$
BEGIN 



	/* Ajuste em 12/08/2022 */
	update 	tbfaturamentozanthus a
	set		fat_zanthus_status_cancelado = 1
	from 	( 
				select 	
							fat_zanthus_data_m00af 					as fat_zanthus_data_m00af
						,	fat_zanthus_sat_ecf_m00ac 				as fat_zanthus_sat_ecf_m00ac
						,	fat_zanthus_cupomfiscal_cancelado_m45bo as fat_zanthus_cupomfiscal_m00ad
				from 	tbfaturamentozanthus
				where	fat_zanthus_cupomfiscal_m00ad <> fat_zanthus_cupomfiscal_cancelado_m45bo 
		          
			) b 
	where b.fat_zanthus_cupomfiscal_m00ad = a.fat_zanthus_cupomfiscal_m00ad
	  and b.fat_zanthus_data_m00af = a.fat_zanthus_data_m00af
	  and b.fat_zanthus_sat_ecf_m00ac = a.fat_zanthus_sat_ecf_m00ac
	  and a.fat_zanthus_data_m00af = vdata_processamento 
	  and coalesce(fat_zanthus_status_cancelado,0) = 0
	
	;
	

	
	update 	tbfaturamento
	set		statusfaturamento = 9
	where 	seqfaturamento 
			in ( 
					select 		fa.seqfaturamento
					from	 	tbfaturamentoorigem 				o 	
					inner join  tbfaturamento						fa 	on fa.seqfaturamento = o.seqfaturamento 
					inner join  tbfaturamentozanthus				z   on z.fat_zanthus_sat_ecf_m00ac = o.sat_ecf 
									   and z.fat_zanthus_cupomfiscal_m00ad = o.cupomfiscal 
					where		1 = 1 
					  and       fa.em_cdempresa = 1
					  and 		fa.op_cdoperacao = 2 
					  and		fa.datafaturamento = vdata_processamento
					  and		z.fat_zanthus_status_cancelado = 1
					group by 	fa.seqfaturamento
				)
	;

	delete 
	from 		tbfaturamentoitensembalagem_comp 	ic 
	where		ic.seqfaturamentoorigem 
		in 
			(	select 		o.seqfaturamentoorigem
				from	 	tbfaturamentoorigem 				o 	
				inner join  tbfaturamento						fa 	on fa.seqfaturamento = o.seqfaturamento 
				inner join  tbfaturamentozanthus				z   on z.fat_zanthus_sat_ecf_m00ac = o.sat_ecf 
								   and z.fat_zanthus_cupomfiscal_m00ad = o.cupomfiscal 
				where		1 = 1 
				  and       fa.em_cdempresa = 1
				  and 		fa.op_cdoperacao = 2
				  and		fa.datafaturamento = vdata_processamento 
				  and		z.fat_zanthus_status_cancelado = 1
			    group by 	o.seqfaturamentoorigem
			)   
	;
	
	delete 
	from 		tbfaturamentoitensembalagem 	ic 
	where		ic.seqfaturamentoorigem 
		in 
			(	select 		o.seqfaturamentoorigem
				from	 	tbfaturamentoorigem 				o 	
				inner join  tbfaturamento						fa 	on fa.seqfaturamento = o.seqfaturamento 
				inner join  tbfaturamentozanthus				z   on z.fat_zanthus_sat_ecf_m00ac = o.sat_ecf 
								   and z.fat_zanthus_cupomfiscal_m00ad = o.cupomfiscal 
				where		1 = 1 
				  and       fa.em_cdempresa = 1
				  and 		fa.op_cdoperacao = 2
				  and		fa.datafaturamento = vdata_processamento 
				  and		z.fat_zanthus_status_cancelado = 1
			    group by 	o.seqfaturamentoorigem
			)   
	;
	
	delete 
	from 		tbfaturamentoitens		 	ic 
	where		ic.seqfaturamentoorigem 
		in 
			(	select 		o.seqfaturamentoorigem
				from	 	tbfaturamentoorigem 				o 	
				inner join  tbfaturamento						fa 	on fa.seqfaturamento = o.seqfaturamento 
				inner join  tbfaturamentozanthus				z   on z.fat_zanthus_sat_ecf_m00ac = o.sat_ecf 
								   and z.fat_zanthus_cupomfiscal_m00ad = o.cupomfiscal 
				where		1 = 1 
				  and       fa.em_cdempresa = 1
				  and 		fa.op_cdoperacao = 2
				  and		fa.datafaturamento = vdata_processamento 
				  and		z.fat_zanthus_status_cancelado = 1
			    group by 	o.seqfaturamentoorigem
			) 	
		;

    update  tbfaturamento f
        set statusfaturamento = 2
    from        tbfaturamentoorigem     o
	inner join  tbfaturamentozanthus	z   on z.fat_zanthus_sat_ecf_m00ac = o.sat_ecf 
                                      and z.fat_zanthus_cupomfiscal_m00ad = o.cupomfiscal
    where   1 = 1
      and   o.seqfaturamento = f.seqfaturamento
      and   f.em_cdempresa = 1
      and   f.op_cdoperacao = 2
      and   z.fat_zanthus_data_m00af = vdata_processamento
      and   z.tiponota = 99
    ;
end;
$function$
