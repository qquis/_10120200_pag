import { clsTools, clsBase } from "../../../model/modelbase";



export default class reportExternalZanthusVoucher { 

    static sql (parametro: any) : string { 

        let sql = ``
        try { 

        
        sql = `
            select a.cod_voucher 
                ,  a.descricao_parceiro 
                ,  a.validade_inicial
                ,  a.validade_final
                ,  a.dth_inclusao 
                ,  a.dth_alteracao 
                ,  i.qtde as qtde_itens
            from   tab_voucher_promocional a 
            left join (  select cod_voucher
                                , count(distinct(cod_produto)) as qtde 
                        from tab_voucher_promocional_prod 
                        group by cod_voucher 
                        ) i on i.cod_voucher = a.cod_voucher 
            WHERE 1 = 1
            `

            if (parametro.cod_voucher && parametro.cod_voucher !== "") {
                sql += ` AND a.cod_voucher = '${parametro.cod_voucher}' `
            }
            if (parametro.descricao_parceiro && parametro.descricao_parceiro !== "") {
                sql += ` AND a.descricao_parceiro LIKE '%${parametro.descricao_parceiro}%' `
            }
            if (parametro.validade_inicial && parametro.validade_inicial !== "") {
                sql += ` AND a.validade_inicial >= '${parametro.validade_inicial}' `
            }
            if (parametro.validade_final && parametro.validade_final !== "") {
                sql += ` AND a.validade_final <= '${parametro.validade_final}' `
            }
           
            if (parametro.voucheratual && parametro.voucheratual !== "") {
                let data_hoje : Date = new Date()
                let cod_voucher : string = clsTools._datemomentDateToStr(data_hoje,  "YYYYMMDD")
                sql += ` AND a.cod_voucher = '${cod_voucher}' `
            }

       

        } catch(e) {
            
            clsTools.PagErrorException("External.Zanthus", "reportExternalZanthusVoucher - sql", e)
        } finally {

            return sql 
        }
    }

    static async get(parametro: any) : Promise<any[]> {
        let mylist : any = []
        try { 
          
            let myBase = new clsBase()
            mylist = await myBase.myDataBase.zanthusPostgre.DataGet( this.sql(parametro) )
        } 
         catch(e) { 
            await clsTools.PagErrorException("External.Zanthus", "reportExternalZanthusVoucher - get", e)
        } finally { 
            return mylist
        }
    }

    

}