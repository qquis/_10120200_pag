select * from tbparticipante_bluesoft limit 10
select cdparticipante, nome_razao, inscricaoestadual 
from tbparticipante where coalesce(inscricaoestadual, '') != ''



select 		i.fc_figurafiscal_cd 
	,		f.fc_figurafiscal_descricao 
	,		count(distinct(i.prb_cdprodutobluesoft))
from 		tbfc_figurafiscal_produto i
inner join  tbfc_figurafiscal f on f.fc_figurafiscal_cd  = i.fc_figurafiscal_cd 
group by   i.fc_figurafiscal_cd 
	,		f.fc_figurafiscal_descricao 
order by fc_figurafiscal_descricao 	asc

select * from tbparticipante_bluesoft limit 10

		select 	b.cdpessoabluesoft
			,	b.dtlog_update 
			,	b.bluesoftclientestatus
			,	p.inscricaoestadual
        from 		tbparticipante p
        inner join 	tbparticipante_bluesoft b on p.cdparticipante = b.cdparticipante
        inner join  tbparticipante_endereco e on e.cdparticipante = p.cdparticipante and e.endereco_tipo_cd = 1
        left  join  tbparticipante_contato  c on c.cdparticipante = p.cdparticipante and c.contato_tipo_cd = 3
        WHERE 1 = 1
        and   b.bluesoftclientestatus = 1