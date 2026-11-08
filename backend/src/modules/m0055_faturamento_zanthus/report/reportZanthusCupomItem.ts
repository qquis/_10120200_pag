import { clsTools, clsBase } from "../../../model/modelbase";



export default class reportZanthusCupom { 

    static sql (parametro: any) : string {
        
        console.log("reportZanthusCupom - parametro: ", parametro)

        let sql = ``
        try { 


        if (!parametro.ecf || !parametro.numero_cupom || parametro.data_cupom_ini == undefined) {
            throw new Error("Parâmetros inválidos para geração do relatório de cupom fiscal Zanthus.")
        }


        
        sql = `
            select 	    i.m00af as data
                    ,	i.m00ad as numero_cupom
                    ,	i.m00ac as ecf
                    ,	i.m43ah as cod_mercadoria
                    ,	m.descricao as descricao 
                    ,	i.m43ap as valor
                    ,	i.m43aq as valor_desconto 
                    ,	i.val_liquido as valor_liquido
                    ,	i.m43ao as qtde
                from 	zan_m43 i
                left join tab_mercadoria m on m.cod_mercadoria = lpad(i.m43ah, 17, '0')
                where	1= 1
                and		i.m00ac = ${parametro.ecf}
                and		i.m00ad = ${parametro.numero_cupom}
                and     i.m00af = '${parametro.data_cupom_ini}'

           order by 1,2,3

            `



        } catch(e) {
            clsTools.PagErrorException("M0055_FaturamentoZanthus", "reportZanthusCupom - sql", e)
        } finally {
            return sql 
        }
    }

    static async get(parametro: any) : Promise<any> { 
        let mylist  : any = []
        try { 


            
            let myBase = new clsBase()

            mylist = await myBase.myDataBase.zanthusPostgre.DataGet( this.sql(parametro) )
            
            let stringListCodMercadoria = mylist.map( (item: any) => { return `'${item.cod_mercadoria}'` } ).join( "," )

            

            let consultaBasePag : string = `
                        select 	g.pre_embalagem
                            ,	g.pr_cdproduto
                            ,	pr.pr_descricao 
                            ,	pr.prb_cdprodutobluesoft as prb_cdprodutobluesoftunitario
                            ,	g.prb_cdprodutobluesoft
                            ,	em.pre_fatorestoque
                            ,	em.pre_fatorpreco
                            ,	em.pre_status
                            ,	em.pre_embalagem_descricao
                            ,   g.preg_cdbarra as preg_cdbarra
                        from  		tbprodutoembalagem_gtins g 
                        left join	tbproduto pr on pr.pr_cdproduto = g.pr_cdproduto
                        left join   tbprodutoembalagem em on em.prb_cdprodutobluesoft = g.prb_cdprodutobluesoft  
                        where 	g.preg_cdbarra in (${stringListCodMercadoria})
                `
            let consultaResultDadosPag : any = [] 
                consultaResultDadosPag = await myBase.myDataBase.pag.DataGet(consultaBasePag)



            for (let i = 0; i < mylist.length; i++) { 
    
                let itemDadosPag = consultaResultDadosPag.find( (item : any) => { 
                    return item.preg_cdbarra.trim() == mylist[i].cod_mercadoria.trim()
                })



                // Verificar se o item foi encontrado antes de processar
                if (itemDadosPag) {
                    Object.keys(itemDadosPag).forEach( key => { 
                        mylist[i][key] = itemDadosPag[key]
                    })
                }
            }
            

        } 
         catch(e) { 
            clsTools.PagErrorException("M0055_FaturamentoZanthus", "reportZanthusCupom - get", e)
        } finally { 
            return mylist
        }
    }

    

}