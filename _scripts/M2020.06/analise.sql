select 	fv_fab_meta_cd
	,	case seqinterface
			when 0 then 'DADOS OXAN'
			when 1 then 'DADOS JOHNSON'
			end
	,	cdparticipantevendedor 
	,	sum(case when fv_fab_meta_mix_cd = 2 then qtde_positivacao else 0 end ) as MIX02
	,	sum(case when fv_fab_meta_mix_cd = 7 then qtde_positivacao else 0 end ) as MIX07	
	,	sum(case when fv_fab_meta_mix_cd = 17 then qtde_positivacao else 0 end ) as MIX17		
	,	sum(case when fv_fab_meta_mix_cd = 17 then qtde_positivacao else 0 end ) as MIX28			

from   tbforca_venda_fab_meta_res_vendedor
group by fv_fab_meta_cd
	,	case seqinterface
			when 0 then 'DADOS OXAN'
			when 1 then 'DADOS JOHNSON'
			end
	,	cdparticipantevendedor 
order by 1,2	


select 	x.fv_fabricante_cdpessoabluesoft 
	,	b.nome_razao 
	,	x.fv_fab_meta_cd
	,	x.fv_fab_meta_descricao 
	,	x.fv_fab_meta_tipo
	,	a.fv_fab_meta_tipo_descricao 
	,	x.fv_fab_data_ini
	,	x.fv_fab_data_fim 
from 	tbforca_venda_fab_meta X
LEFT JOIN tbforca_venda_fab_meta_tipo A ON A.fv_fab_meta_tipo_cd = x.fv_fab_meta_tipo
LEFT JOIN tbparticipante_bluesoft b on b.cdpessoabluesoft = x.fv_fabricante_cdpessoabluesoft
order by x.fv_fab_meta_cd

select * from tbforca_venda_fab_meta_tipo


select * from tbforca_venda_fab_meta_mix
