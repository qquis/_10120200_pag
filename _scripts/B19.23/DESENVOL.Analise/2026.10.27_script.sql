--delete from tbfaturamentocontrato_produto where contrato_seq in (select contrato_seq from tbfaturamentocontrato WHERE contrato_data = '2026-10-01' and   op_cdoperacao = 1)
--DELETE FROM tbfaturamentocontrato WHERE contrato_data = '2026-10-01' and   op_cdoperacao = 1

SELECT * FROM tbfaturamentocontrato 
WHERE contrato_data = '2026-10-01'
and   op_cdoperacao = 1

SELECT * FROM tbfaturamentocontrato_produto WHERE CONTRATO_SEQ = 6821

SELECT * FROM tbforca_venda_fabricante



            SELECT 0 as contrato_seq
            ,    pr.pr_cdproduto
            ,    pb.prb_cdprodutobluesoft_pk 
            ,    un.prb_descricao as prb_descricaounitaria 
            ,    pb.prb_embalagemestoque
            ,    cast(0 as numeric(13,2)) as valor_unitario

            from        tbprodutobluesoft pb 
            inner join  tbprodutobluesoft un on un.prb_cdprodutobluesoft_pk = pb.prb_cdprodutobluesoftunitario
            left join   tbparticipante_bluesoft p on p.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fornecedor
            left join   tbproduto_subgrupo sb on sb.prsg_cdsubgrupo = pb.prb_cdsubgrupo
            left join   tbproduto_grupo g on g.prg_cdgrupo = sb.prg_cdgrupo
            left join   tbproduto_secao s on s.prs_cdsecao = g.prs_cdsecao 
            left join   tbproduto_departamento d on d.prd_cddepartamento = s.prd_cddepartamento
            left join   tbproduto pr on pr.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoftunitario
            where 1 = 1
            AND  pb.prb_cdpessoabluesoft_fornecedor = 13752
            and  pb.prb_cdprodutobluesoft_pk = pb.prb_cdprodutobluesoftunitario


            UNION 

            SELECT  i.contrato_seq
               ,    i.pr_cdproduto
               ,    i.prb_cdprodutobluesoft
               ,    pb.prb_descricao as prb_descricaounitaria
               ,    pb.prb_embalagemestoque               
               ,    i.valor_unitario 
             FROM tbfaturamentocontrato_produto i
             inner join  tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
            left join   tbproduto pr on pr.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoftunitario             
             WHERE CONTRATO_SEQ = 6821

select * from tbfaturamentocontrato limit 10

	DELETE FROM TBFATURAMENTOITENSCONTRATOS X
		WHERE EXISTS (

			SELECT 1
			FROM   tbfaturamentocontrato_produto i 
			inner join tbfaturamentocontrato     f on f.contrato_seq = i.contrato_seq
			WHERE F.CONTRATO_SEQ = X.CONTRATO_SEQ
			and f.contrato_tipo_cd in (1,3)
			and f.contrato_data_val_ini >= '2026-10-01'
			and f.contrato_data_val_fim <= '2026-10-31'
			and f.contrato_seq =6822
			and i.pr_cdproduto = x.pr_cdproduto

		)