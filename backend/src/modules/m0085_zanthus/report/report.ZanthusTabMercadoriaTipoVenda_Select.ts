import reportZanthusType from "./ReportFilterType";
import tbZanthusTabMercadoriaTipoVenda from "../tbs/tbZanthusTabMercadoriaTipoVenda";
import { clsTools, clsBase } from "../../../model/modelbase";




export default class reportZanthusTabMercadoriaTipoVenda_Select {
    filter : reportZanthusType
    constructor(filter : Partial<reportZanthusType>) {
     
        this.filter = filter;
    }


    async tblist_Get() : Promise<Array<tbZanthusTabMercadoriaTipoVenda>> {
        let listTabMercadoria : tbZanthusTabMercadoriaTipoVenda[] = []
        try {

            let myClsBase : clsBase = new clsBase()

            let result : any = await myClsBase.myDataBase.pag.DataGet(this.scriptSelect())

            for await ( const[key, value] of Object.entries(result)) {
                let itemTbZanthusTabMercadoriaTipoVenda : tbZanthusTabMercadoriaTipoVenda = new tbZanthusTabMercadoriaTipoVenda()
                itemTbZanthusTabMercadoriaTipoVenda.binding(value)
                listTabMercadoria.push(itemTbZanthusTabMercadoriaTipoVenda)
                
            }
        } catch (e) {
            await clsTools.PagErrorException(`M0085_Zanthus`, `report.tab_mercadoria_tipo_venda_select | tblist_Get`, e);
        }
        finally {
            return listTabMercadoria
        }
    }


    private scriptSelect() : string {
        let sqlscript : string = `` 
        sqlscript =   
                `select 	a.tab_pre_cd 
                        ,	a.pr_cdproduto				
                        ,	a.prb_cdprodutobluesoft						
                        ,	a.preg_cdbarra								
                        ,	a.cod_loja 									
                        ,	a.controle 									
                        ,	a.cod_mercadoria
                        ,	a.cod_tipo_venda 
                        ,	a.usuario 
                        ,	a.data_cadastro 
                        ,	coalesce(a.data_ultima_alteracao, current_timestamp) as data_ultima_alteracao
                        ,	a.preco_unitario 
                        ,	a.percentual_comissao_vendedor
                        ,   coalesce(a.preco_anterior,0) as preco_anterior
                from 		tbzanthustab_mercadoria_tipo_venda a
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