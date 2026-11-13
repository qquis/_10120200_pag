



select * from tbprodutobluesoft


SELECT lpad(i.prbg_cdbarra_pk, 14, '0') as cod_mercadoria
from   tbprodutobluesoft_gtins  i
inner join  tbprodutobluesoft        prb on prb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
inner join  tbproduto_subgrupo       sb on sb.prg_cdgrupo = prb.prb_cdsubgrupo 
inner join  tbproduto_grupo          gr on gr.prg_cdgrupo = sb.prg_cdgrupo
inner join  tbproduto_secao          sc on sc.prs_cdsecao = gr.prs_cdsecao
inner join  tbproduto_departamento    dp on dp.prd_cddepartamento = sc.prd_cddepartamento
where       1 = 1
and         prb.prb_status = 'false'
and         dp.prd_habilita_integracao_zanthus = 'true'

