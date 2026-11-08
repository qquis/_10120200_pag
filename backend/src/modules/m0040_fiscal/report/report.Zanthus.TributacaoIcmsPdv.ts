import { clsBase, clsTools } from '../../../model/modelbase';


export default class reportFiscalZanthusTributacaoIcmsPdv {
    static sql (parametro: any) : string {

        let sql = ` select 	i.icms_cd
                    ,	i.aliquota
                    ,	i.reducao 
                    ,	lpad(cast(i.codigotributacao as varchar(2)), 2, '0') as codigotributacao
                    ,	i.icms_descricao 
                    ,	i.aliquota
                    ,   i.reducao 
                    ,	i.codigoorigem 
                    ,	i.codigotributacao 
                    ,   x.tributacao_icms_pdv_descricao 
                    ,	coalesce(x.cod_tributacao_pdv,-1) as cod_tributacao_pdv
                    ,   coalesce(count_produto.qtde_produto,0) as qtde_produto
                from 		tbfc_icms i
                left join 	tbzanthus_tributacao_icms_pdv x on i.icms_cd = x.icms_cd 
                left join   (select x.icms_codigo_icms 
                                ,   count(distinct(pb.prb_cdprodutobluesoftunitario)) as qtde_produto
                            from 	tbfc_regrafiscal_nfce_produto x
                            left join tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = x.prb_cdprodutobluesoft
                            group by x.icms_codigo_icms
                            ) count_produto on count_produto.icms_codigo_icms = x.icms_cd
                where 1 = 1`

        if (parametro.ComProdutos === "1") {
            sql += ` and count_produto.qtde_produto > 0 `
        }
        if (parametro.SemTributacaoPDV === "1") {
            sql += ` and ( x.cod_tributacao_pdv is null  or x.cod_tributacao_pdv = 999) `
        }
        if (parametro.cod_tributacao_pdv && parametro.cod_tributacao_pdv > 0) {
            sql += ` and x.cod_tributacao_pdv = ${parametro.cod_tributacao_pdv} `
        }



        sql += ` order by i.icms_descricao  asc `

        return sql;
    }

    static async get(parametro: any) : Promise<any> {
        let result : any = { }
        try {
            console.log(parametro)
            let myBase : clsBase = new clsBase();
            result = await myBase.myDataBase.pag.DataGet( this.sql(parametro));

        } catch (e) {
            await clsTools.pagConsole(`reportFiscalZanthusTributacaoIcmsPdv | get \n Error: ${e}`);
        
        } finally {
            
            return result
        }   
    }   

}

