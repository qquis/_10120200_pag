import { clsTools } from "../../../model/modelbase";
import modelfc_cbenef from "./modelfc_cbenef";
import modelfc_cofins from "./modelfc_cofins";
import modelfc_icms from "./modelfc_icms";
import modelfc_pis from "./modelfc_pis";
import modelfc_regrafiscal from "./modelfc_regrafiscal";






/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 10050011
    const FLG_DEBUG_CONSOLE_LOG : boolean = true
    const FLG_MODULO : string = "M0040-Fiscal | MODEL BASE"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    

export default class model0040_fiscal { 
    static fc_cbenef() { return new modelfc_cbenef() }
    static fc_cofins() { return new modelfc_cofins() }
    static fc_icms() { return new modelfc_icms() }
    static fc_pis() { return new modelfc_pis() }
    static fc_regrafiscal() { return new modelfc_regrafiscal() }
   static async scriptAtualizarListaCbenefDoProdutoBluesoft(prb_cdprodutobluesoftunitario: string, listCBENEF: string[]) : Promise<string> {
        let sql = ` `
        try {
                


        } catch (e) {
            await clsTools.PagErrorException(`model0021_ProdutoBluesoft`,`scriptAtualizarListaCbenefDoProdutoBluesoft`,e)
        } finally {
            return sql;
        }
    } 
    
    static sqlDELETE_tbfc_cbenef_produtobluesoft_porPRODUTO(prb_cdprodutobluesoftunitario: string) : string {
        return `delete from tbfc_cbenef_produtobluesoft where prb_cdprodutobluesoft = ${prb_cdprodutobluesoftunitario};`
    }
    
    static sqlUPDATE_tbprodutobluesoft_CBENEF_NULL_PorCBENEF(fc_cbenef_cd: string) : string {
        return `update tbprodutobluesoft x 
                    set prb_blue_fc_cbenef_cd = a.fc_cbenef_cd
                      , dtlog_update = current_timestamp
                    from ( 
                                select 		prb.prb_cdprodutobluesoftunitario 
                                    ,  		prn.fc_cbenef_cd 
                                from   		tbfc_cbenef_produtobluesoft prn
                                inner join  tbprodutobluesoft prb on prb.prb_cdprodutobluesoft_pk = prn.prb_cdprodutobluesoft
                                inner join 	tbfc_cbenef_cst cst on cst.fc_cbenef_cd = prn.fc_cbenef_cd
                                inner join  tbzanthus_tributacao_nfce   n on n.prb_cdprodutobluesoft = prn.prb_cdprodutobluesoft 
                                    and cast(n.icms_cst as varchar(2)) = cast(cst.icms_codigo_tributacao as varchar(2))
                                where       prb.prb_cdprodutobluesoftunitario = prn.prb_cdprodutobluesoft	
                                order by 	prb.prb_cdprodutobluesoftunitario 
                                    ,		prn.prb_cdprodutobluesoft
                            ) a 
                    where 1 = 1
                    and   a.prb_cdprodutobluesoftunitario = x.prb_cdprodutobluesoftunitario 
                    and   a.fc_cbenef_cd =  '${fc_cbenef_cd}'
                    and   a.fc_cbenef_cd != 'SP099999'
                ;`

    }
 
    static sqlUPDATE_tbprodutobluesoft_NULL_porCBENEF(fc_cbenef_cd: string) : string {
        return `update tbprodutobluesoft set prb_blue_fc_cbenef_cd = null where prb_blue_fc_cbenef_cd = '${fc_cbenef_cd}';`
    }


    static async sqlINSERT_TbFC_CBENEF_PRODUTO_FromList_PorCBENEF(fc_cbenef_cd: string, arrayListaProdutos: number[]) : Promise<string> { 
        let sql = ` `
       
        try{ 

                if (arrayListaProdutos && arrayListaProdutos.length > 0) {
                    const listaProdutosUnica =[...new Set(arrayListaProdutos)];
                
                    let liststringproduto = listaProdutosUnica.join(',');


                    sql += `insert into tbfc_cbenef_produtobluesoft (fc_cbenef_cd, prb_cdprodutobluesoft)
                            select '${fc_cbenef_cd}', t.prb_cdprodutobluesoft
                            from unnest(array[${liststringproduto}]) as t(prb_cdprodutobluesoft);`
                    }
                else { 
                    throw new Error(`Lista de produtos vazia para o Cbenef ${fc_cbenef_cd}`)
                }

        } catch (e) {
            await clsTools.PagErrorException(`modelfc_cbenef`,`sqlINSERT_TbFC_CBENEF_PRODUTO_FromList_PorCBENEF`,e)
        }
        finally {
            return sql
        }
    }

    static async sqlINSERT_TbFC_CBENEF_PRODUTO_FromList_PorProduto(fc_cbenef_list: string[], prb_cdprodutobluesoft : number) : Promise<string> {
        let sql = ``
        try { 
            if (fc_cbenef_list && fc_cbenef_list.length > 0) {

                const listCbenefUnica =[...new Set(fc_cbenef_list)];
                
                let listCbenef = listCbenefUnica.join(`','`) 
                
                sql += `insert into tbfc_cbenef_produtobluesoft (fc_cbenef_cd, prb_cdprodutobluesoft)
                        select t.fc_cbenef_cd, ${prb_cdprodutobluesoft}
                        from unnest(array['${listCbenef}']) as t(fc_cbenef_cd)

                        ;`        
            }
        }
        catch (e) {
            await clsTools.PagErrorException(`modelfc_cbenef`,`sqlAtualizarList_TabCbenefProdutoBluesoft`,e)
        }
        finally {
            return sql
        }
        
    }
    static sqlDELETE_tbfc_cbenef_produtobluesoft_PorCbenef(fc_cbenef_cd: string) : string {
        let sql = `delete from tbfc_cbenef_produtobluesoft where fc_cbenef_cd = '${fc_cbenef_cd}';`
        return sql
    }
    static sqlDELETE_tbfc_cbenef_produtobluesoft_PorProduto(prb_cdprodutobluesoft: number) : string {
        let sql = `delete from tbfc_cbenef_produtobluesoft where prb_cdprodutobluesoft = ${prb_cdprodutobluesoft};`
        return sql
    }

    static sqlUpdateALL_CBENEF_TbProduto_ComTbProdutoBluesoft() : string {
            return ` 
                                update tbproduto  x
                                set    pr_pag_fc_cbenef_cd = a.prb_blue_fc_cbenef_cd
                                from   tbprodutobluesoft a 
                                where  a.prb_cdprodutobluesoftunitario = x.prb_cdprodutobluesoft 
                                and  coalesce(x.pr_pag_fc_cbenef_cd, '') = ''
                                and  coalesce(a.prb_blue_fc_cbenef_cd, '') != coalesce(x.pr_pag_fc_cbenef_cd, '')
            
                        `

    }

}



    