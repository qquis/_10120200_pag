import { clsTools, clsBase } from "../../../model/modelbase";



export default class reportExternalZanthusTabFinalizadora { 

    static sql (parametro: any) : string { 

        let sql = ``
        try { 

        
        sql = `
           select cod_finalizadora as finalizadora_cd, descricao as finalizadora_descricao from tab_finalizadora
            WHERE 1 = 1
        
           order by 2 asc



            `

        

        } catch(e) {
            
            clsTools.PagErrorException("External.Zanthus", "reportExternalZanthusTabFinalizadora - sql", e)
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
            await clsTools.PagErrorException("External.Zanthus", "reportExternalZanthusTabFinalizadora - get", e)
        } finally { 
            return mylist
        }
    }

    

}