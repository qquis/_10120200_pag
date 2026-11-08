select * from tbinterfacefaturamentoinfoitem limit 10



select * from tbinterfacefaturamentoagendamentosimuladoinfoitem limit 10
select * from tbproduto limit 10

select  
                              i.seqinterface  AS  seqinterface
                    ,       count(distinct(i.cdoperacao)) as cdoperacao 
                    ,       count(distinct(i.seqfaturamento)) as seqfaturamento
                    ,       count(distinct(i.seqfaturamentoorigem)) as seqfaturamentoorigem
                    ,       count(distinct(i.sat_ecf)) as sat_ecf
                    ,       count(distinct(i.cupomfiscal)) as cupomfiscal
                    ,       count(distinct(i.numeropedido)) as numeropedido
                    ,       count(distinct(i.pr_cdproduto)) as pr_cdproduto 
                    ,       count(distinct(i.embalagemestoque)) as embalagemestoque
                    ,       sum(i.embalagemestoqueqtde) as embalagemestoqueqtde 
                    ,       count(distinct(i.embalagemcompra)) as embalagemcompra 
                    ,       sum(cast(i.embalagemcompraqtde as numeric(13,1))) as embalagemcompraqtde 
                    ,       count(distinct(i.cdparticipantecliente)) as cdparticipantecliente 
                    ,       count(distinct(i.cdparticipantecliente_original)) as cdparticipantecliente_original
                    ,       count(distinct(c.nome_razao)) as nome_razao 
                    ,       count(distinct(g.cdgrupoeconomico)) as cdgrupoeconomico 
                    ,       count(distinct(g.descricao)) as descricao 
                    ,       count(distinct(i.cdparticipantevendedor)) as cdparticipantevendedor
                    ,       count(distinct(i.cdparticipantevendedor_original)) as cdparticipantevendedor_original
                    ,       count(distinct(i.seqprocessamentoitemdocumento)) as   seqprocessamentoitemdocumento 
                    ,       sum(i.valortotalfaturamento) as valortotalfaturamento
                    
                    ,       sum(case when  i.seqinterfacefaturamentoagendamentosimuladoinfoitem > 0 then cast(i.embalagemcompraqtde as numeric(13,1)) else 0 end ) as simulado_embalagemcompraqtde 
                    ,       count(case when i.seqinterfacefaturamentoagendamentosimuladoinfoitem > 0 then i.cdparticipantecliente else null end) as simulado_cdparticipantecliente 
                   

                    from        tbinterfacefaturamentoinfoitem i
                    inner join  tbproduto pr on pr.pr_cdproduto = i.pr_cdproduto

                    left join   tbparticipante_bluesoft c on c.cdparticipante = i.cdparticipantecliente
                    left join   tbgrupoeconomico        g on g.cdgrupoeconomico = c.cdgrupoeconomico

                    where       1 = 1
                    and		    i.datafaturamento	>=	'2026-07-01'
                    and		    i.datafaturamento	<=	'2026-07-31'
                    and		    i.seqinterface	=	1
                    group by  i.seqinterface

SELECT TO_CHAR(datafaturamento, 'YYYYMM') AS anomes from tbinterfacefaturamentoinfoitem limit 10                    

SELECT * FROM TBCOMPETENCIA

select * from tbfaturamentoitem limit 10