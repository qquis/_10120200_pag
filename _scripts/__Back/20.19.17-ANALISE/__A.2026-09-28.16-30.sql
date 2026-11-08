select prb_cdprodutobluesoft_pk as cd, prb_ncm, prb_descricao 
from tbprodutobluesoft 
where prb_cdprodutobluesoft_pk in( 31465, 228720, 228722, 161397, 236302, 236234 )

SELECT * from tbsistema_nucleo_procedimento where sis_nucleo_prc_cd = 8002
select * from tbnotificacao_send_message



       select   pb.prb_cdprodutobluesoftunitario
            ,    un.prb_descricao as prb_descricaounitaria 
            ,    pb.prb_cdprodutobluesoft_pk 
            ,    coalesce(pb.prb_descricao,'') as prb_descricao
            ,    coalesce(pb.prb_pesobruto,0) as prb_pesobruto
            ,    coalesce(pb.prb_pesoliquido,0) as prb_pesoliquido
            ,    coalesce(pb.prb_comprimento,0) as prb_comprimento
            ,    coalesce(pb.prb_largura,0) as prb_largura
            ,    coalesce(pb.prb_altura,0) as prb_altura
            ,    coalesce(pb.prb_pesoaproximado,0) as prb_pesoaproximado
            ,    case when pb.prb_status then 1 else 0 end as prb_status
            ,    pb.prb_embalagemestoque
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
            ,    pb.dtlog_insert
            ,    pb.dtlog_update
            ,    pb.prb_dtupdate_from_api
            from        tbprodutobluesoft pb 
            inner join  tbprodutobluesoft un on un.prb_cdprodutobluesoft_pk = pb.prb_cdprodutobluesoftunitario
            left join  tbparticipante_bluesoft p on p.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fornecedor
            left join   tbproduto_subgrupo sb on sb.prsg_cdsubgrupo = pb.prb_cdsubgrupo
            left join   tbproduto_grupo g on g.prg_cdgrupo = sb.prg_cdgrupo
            left join   tbproduto_secao s on s.prs_cdsecao = g.prs_cdsecao 
            left join   tbproduto_departamento d on d.prd_cddepartamento = s.prd_cddepartamento
            where 1 = 1

             and pb.prb_cdprodutobluesoft_pk = 236302 

