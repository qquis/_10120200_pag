import { clsBase, clsTools } from "../../../model/modelbase";


const myBase : clsBase = new clsBase();

export default class reportSistemaLogList {
    public static sql(parametro : any) : string {

        try { 
         let sql = 
        
         `  select 		a.dtlog_insert 
                ,		a.sis_log_seq
                ,		coalesce(a.proc_log_seq,0) as proc_log_seq
                ,		coalesce(a.sis_nucleo_prc_cd, 0) as sis_nucleo_prc_cd
                ,		a.sis_log_tag
                ,		a.sis_log_info
                ,		coalesce(a.sis_batch_run_seq,0) as sis_batch_run_seq
                ,		a.uuid 
                ,		a.uuid_start 
                ,		coalesce(b.sis_nucleo_prc_descritivo,'') as sis_nucleo_prc_descritivo
                ,		coalesce(b.sis_nucleo_prc_descricao, '') as sis_nucleo_prc_descricao
            from 		tbsistema_log a
            left join 	tbsistema_nucleo_procedimento b on b.sis_nucleo_prc_cd = a.sis_nucleo_prc_cd 

         where		1 = 1 

         `

         if (parametro.dtlog_insert_inicial) { 
            sql += ` and a.dtlog_insert >= '${parametro.dtlog_insert_inicial}'`
         }

         if (parametro.dtlog_insert_final) { 
            sql += ` and a.dtlog_insert <= '${parametro.dtlog_insert_final}'`
         }
 
         if (parametro.sis_nucleo_prc_cd && parametro.sis_nucleo_prc_cd > 0) {
            sql += ` and a.sis_nucleo_prc_cd = ${parametro.sis_nucleo_prc_cd}`
         }

                 
        if (parametro.list_sis_nucleo_prc_cd && parametro.list_sis_nucleo_prc_cd.length > 0) {
            sql += ` and a.sis_nucleo_prc_cd in (${parametro.list_sis_nucleo_prc_cd.split(",").join(",")})`
         }

         sql += ` order by a.sis_log_seq desc `

         return sql 
        } catch (e) {
            clsTools.PagErrorException(`reportSistemaLogList`, `sql`, e)
            return ``
        }

    }

    public static async get(parametro: any) : Promise<object> {
        let result = { }
        try {
         

            result = await myBase.myDataBase.pag.DataGet(this.sql(parametro));

        } catch (e) {
            clsTools.pagConsole(`reportSistemaLog | get \n Error: ${e}`);
        
        } finally {
            
            return result
        }
    } 

    public static async LogNucleoProcedimentoToday(sis_nucleo_prc_cd: number) : Promise<boolean> {
        
        let executed = false

        try {

            let parametro = { 
                dtlog_insert_inicial: clsTools._datemomentDateToStr(new Date(), `YYYY-MM-DD 01:01:01`),
                dtlog_insert_final: clsTools._datemomentDateToStr(new Date(), `YYYY-MM-DD 23:59:59`),
                sis_nucleo_prc_cd
            }

            let result = await myBase.myDataBase.pag.DataGet( this.sql(parametro));


            
            if (result && Array.isArray(result) && result.length > 0) {
                executed = true
            } 


        } catch (e) {
            clsTools.pagConsole(`reportSistemaLog | LogNucleoProcedimentoToday \n Error: ${e}`);
        
        } finally {
            
            return executed
        }
    }

}