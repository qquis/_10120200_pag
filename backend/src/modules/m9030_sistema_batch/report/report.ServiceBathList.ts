
import { clsBase, clsTools } from "../../../model/modelbase";



export default class reportServiceBathList {
        public static sql(parametros: any) : string { 
                let sql = `
                            select 	b.sis_batch_cd 
                                ,	b.sis_batch_descricao 
                                ,	b.sis_batch_status 
                                ,	b.sis_batch_service_cd 
                                ,	b.module_cd 
                            from 	tbsistema_batch b
                            where 1 = 1 
                            ${parametros.sis_batch_service_cd ? ` and b.sis_batch_service_cd = ${parametros.sis_batch_service_cd}` : ''}
                            ${parametros.sis_batch_cd ? ` and b.sis_batch_cd = ${parametros.sis_batch_cd}` : ''}

                `;

                return sql;
        }

        static async get(parametros: any) : Promise <any> { 
                let result : any = {}
            
                try { 
                    const modeldb = new clsBase(); 
                    result = await modeldb.myDataBase.pag.DataGet(this.sql(parametros));
                    

                } catch (e) {
                      clsTools.PagErrorException(`reportSistemaBatch.get`,`get`, e);
         
                } finally { 
                        return result;
                }

        }
}