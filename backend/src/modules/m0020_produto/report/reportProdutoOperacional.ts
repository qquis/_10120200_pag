import { clsBase, clsTools } from '../../../model/modelbase';

const myBase = new clsBase();


export class reportProdutoOperacional { 
    static async sql(parametros: any) { 
        let sql = ` `
        
        sql =  ` select      pr.pr_cdproduto 
                ,       pr.pr_descricao 
                ,       pr.prb_cdprodutobluesoft 

                ,       pr.pr_embalagemestoque 
                ,       pr.pr_embalagemcompra 
                ,       pr.pr_embalagemcompra_fator

                ,       pb.prb_descricao 
                ,       pb.prb_cdbarra_principal 
                ,       pb.prb_dt_cadastro 
                ,       pb.prb_dt_ultimaalteracao 
                ,       pb.prb_vendaexterna 
                ,       pb.prb_status
                ,       pb.prb_cdpessoabluesoft_fornecedor

                ,       es.ec_embalagemestoque_qtde 
                ,       es.ec_valor_custo_precificacao 
                ,       es.ec_valor_custo_faturamento 
            from        tbproduto pr
            left join   tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
            left join   tbestoquecusto    es on es.pr_cdproduto = pr.pr_cdproduto 
                    
                    `

        return sql;
    }

    static async get(parametros: any) : Promise<object> { 
        
        let report = {}
        try { 

            report = await myBase.myDataBase.pag.DataGet( await this.sql(parametros) )


        } catch (e) {
            clsTools.PagErrorException('m0020_produto', 'reportProdutoOperacional', e);
        }

        finally {
            return report
        }
    }


}