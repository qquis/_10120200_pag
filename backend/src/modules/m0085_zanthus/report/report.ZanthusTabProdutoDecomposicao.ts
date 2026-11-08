import DataBase from "../../../database/DataBase";
import reportZanthusType from "./ReportFilterType";
import tbZanthusTabProdutoDecomposicao from "../tbs/tbZanthusTabProdutoDecomposicao";
import { clsTools, clsBase } from "../../../model/modelbase";


let myDATABASE :  DataBase

export default class reportZanthusTabProdutoDecomposicao_Select {
    filter : reportZanthusType
    constructor(filter : Partial<reportZanthusType>) {
        myDATABASE = new DataBase()
     
        this.filter = filter;
    }

    async tblist_Get() : Promise<Array<tbZanthusTabProdutoDecomposicao>> {
        let listTabMercadoria : tbZanthusTabProdutoDecomposicao[] = []
        try {

            let myClsBase : clsBase = new clsBase()

            let result : any = await myClsBase.myDataBase.pag.DataGet(this.scriptSelect())

            for await ( const[key, value] of Object.entries(result)) {
                let itemTbZanthusTabMercadoriaTipoVenda : tbZanthusTabProdutoDecomposicao = new tbZanthusTabProdutoDecomposicao()
                itemTbZanthusTabMercadoriaTipoVenda.binding(value)
                listTabMercadoria.push(itemTbZanthusTabMercadoriaTipoVenda)
                
            }


        } catch (e) {
            await clsTools.PagErrorException(`M0085 _ Zanthus`, `report.tab_produto_decomposicao_select | tblist_Get`, e);
        }
        finally { 
            return listTabMercadoria
        }
    }


    private scriptSelect() : string {
        let sqlscript : string = `` 
        sqlscript =   
                `select 	a.pr_cdproduto				
                        ,	a.prb_cdprodutobluesoft						
                        ,	a.preg_cdbarra								
                        ,	a.cod_loja 	
                        ,   coalesce(a.controle,'000') as controle
                        ,	a.cod_mercadoria
                        ,	forma_decomposicao 
                        ,	tipo_decomposicao 
                        ,	a.usuario 
                        ,	a.data_cadastro 
                        ,	coalesce(a.data_ultima_alteracao, current_timestamp) as data_ultima_alteracao
                from 		TbZanthustab_produto_decomposicao  a
                inner join  tbzanthustab_mercadoria  		   me on me.pr_cdproduto = a.pr_cdproduto 
                                                                 and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                inner join  tbproduto 						   pr on pr.pr_cdproduto = me.pr_cdproduto 												
                where		1 = 1 
                `
                + (this.filter.ProdutosPendentesDeIntegracao?
                    ` and pr.pr_cdproduto in (
                                                 select x.pr_cdproduto 
                                                 from   tbintegracao_produto x 
                                                 where  1 = 1
                                                   and  x.integracao_tipo_cd = ${this.filter.integracao_tipo_cd || 20008501}
                                                   and  x.integracao_status_cd = 2
                    
                                              )`: ``)


                

        return sqlscript;
    }
}