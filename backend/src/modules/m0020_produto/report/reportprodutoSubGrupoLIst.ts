import { clsBase, clsTools } from "../../../model/modelbase";

const myBase = new clsBase();

export default class reportProdutoSubGrupo { 
    static sql (parametro: any) : string {
        let sql = ` 
           select	    dp.prd_descricao 
                    ,   sc.prs_descricao 
                    ,   gr.prg_descricao
                    , 	sb.prsg_cdsubgrupo 
                    , 	sb.prsg_descricao
                    ,   prodCount.qtdeproduto as qtdeproduto
                    ,   countCST.cst_20
                    ,   countCST.cst_40
                    ,	gr.prg_cdgrupo
                    ,   sb.fc_cbenef_cd
                    ,   cben.fc_cbenef_objetivo 
            from 		tbproduto_subgrupo sb 
            left join   tbproduto_grupo gr on gr.prg_cdgrupo = sb.prg_cdgrupo 
            left join   tbproduto_secao sc on sc.prs_cdsecao = gr.prs_cdsecao
            left join   tbproduto_departamento dp on dp.prd_cddepartamento = sc.prd_cddepartamento
            left join   tbfc_cbenef cben on cben.fc_cbenef_cd = sb.fc_cbenef_cd
            left join   (select   count(distinct(pr.pr_cdproduto)) qtdeproduto
                                , pr.prsg_cdsubgrupo
                        from tbproduto pr 
                        group by pr.prsg_cdsubgrupo
                        ) prodCount on prodCount.prsg_cdsubgrupo = sb.prsg_cdsubgrupo
                left join (			select xs.prsg_cdsubgrupo 
                                        , count(distinct(case when icms_codigo_tributacao = 20 then  aa.prb_cdprodutobluesoft else null end)) as cst_20
                                        , count(distinct(case when icms_codigo_tributacao = 40 then  aa.prb_cdprodutobluesoft else null end )) as cst_40 
                                    from 			tbfc_regrafiscal_nfce_produto aa
                                    inner join 		tbproduto xp on xp.prb_cdprodutobluesoft = aa.prb_cdprodutobluesoft
                                    inner join      tbproduto_subgrupo xs on xs.prsg_cdsubgrupo = xp.prsg_cdsubgrupo
                                    group by xs.prsg_cdsubgrupo
                            ) countCST on countCST.prsg_cdsubgrupo  = sb.prsg_cdsubgrupo
            where 1 = 1 `

        if (parametro.prd_cddepartamento && parametro.prd_cddepartamento !== 0) {
            sql += ` and dp.prd_cddepartamento = ${parametro.prd_cddepartamento}`
        }

        if (parametro.prs_cdsecao && parametro.prs_cdsecao !== 0) {
            sql += ` and sc.prs_cdsecao = ${parametro.prs_cdsecao}`
        }

        if (parametro.prg_cdgrupo && parametro.prg_cdgrupo !== 0) {
            sql += ` and gr.prg_cdgrupo = ${parametro.prg_cdgrupo}`
        }

        if (parametro.comCbenefFilter && parametro.comCbenefFilter == 1) {
            sql += ` and coalesce(sb.fc_cbenef_cd, '') != '' `
        }

        sql += `    
            order by sb.prsg_descricao
                    
        `


        return sql 
    }
    static async get(parametro: any) : Promise<object> { 
        let sql = this.sql(parametro);
        let result = await myBase.myDataBase.pag.DataGet(this.sql(parametro));
        return result;
    }
}