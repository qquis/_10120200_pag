import reportZanthusType from "./ReportFilterType";
import tbZanthusTabMercadoriaTipoVendaQtde from "../tbs/tbZanthusTabMercadoriaTipoVendaQtde";
import { clsTools, clsBase } from "../../../model/modelbase";



export default class reportZanthusTabMercadoriaTipoVendaQtde_Select {
    filter : reportZanthusType
    constructor(filter : Partial<reportZanthusType>) {

     
        this.filter = filter;
    }
    async tblist_Get() : Promise<Array<tbZanthusTabMercadoriaTipoVendaQtde>> {
        let listTabMercadoriaTipoVenda : tbZanthusTabMercadoriaTipoVendaQtde[] = []
        try {

            let myClsBase : clsBase = new clsBase()

            let result : any = await myClsBase.myDataBase.pag.DataGet(this.scriptSelect())

            for await ( const[key, value] of Object.entries(result)) {
                let itemTbZanthusTabMercadoriaTipoVenda : tbZanthusTabMercadoriaTipoVendaQtde = new tbZanthusTabMercadoriaTipoVendaQtde()
                itemTbZanthusTabMercadoriaTipoVenda.binding(value)
                listTabMercadoriaTipoVenda.push(itemTbZanthusTabMercadoriaTipoVenda)
                
            }

        } catch (e) {

            await clsTools.PagErrorException(`M0085_Zanthus`, `report.tab_mercadoria_tipo_venda_qtde_select | tblist_Get`, e);

        }
        finally {
            return listTabMercadoriaTipoVenda
        }
    }
    private scriptSelect() : string {
        let sqlscript : string = `` 
        sqlscript =   
                `select 		a.pr_cdproduto
                            ,	a.prb_cdprodutobluesoft 
                            ,	a.preg_cdbarra 
                            ,	a.cod_loja
                            ,	a.cod_mercadoria
                            ,	a.cod_tipo_venda
                            ,	a.qtde_venda
                            --,	a.flag_geral
                            ,	a.preco_unitario
                            ,	a.perc_desconto
                            --,	a.flag_ativo
                            ,	a.Dth_inclusao
                            ,	a.Dth_alteracao
                            ,	a.Idt_usuario_alteracao
                from   		tbzanthustab_mercadoria_tipo_venda_qtde a
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