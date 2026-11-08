
import { clsBase, clsTools } from "../../../model/modelbase";



export default class reportServiceList {
        public static sql(parametros: any) : string { 
                let sql = `
                        select s.sis_batch_service_cd
                             , s.sis_batch_service_tipo_cd
                             , t.sis_batch_service_tipo_descricao
                             , s.sis_batch_service_descricao 
                             , sis_batch_service_host
                        from        tbsistema_batch_service s
                        left join   tbsis_batch_service_tipo t on s.sis_batch_service_tipo_cd = t.sis_batch_service_tipo_cd
                        ${parametros.sis_batch_service_cd ? ` where s.sis_batch_service_cd = ${parametros.sis_batch_service_cd}` : ''}
                        ORDER BY   s.sis_batch_service_cd ASC 

  

                `;

                return sql;
        }

        static async get(parametros: any) : Promise <any> { 
                let result : any = {}
            
                try { 
                    const modeldb = new clsBase(); 
                    result = await modeldb.myDataBase.pag.DataGet(this.sql(parametros));
                    

                } catch (e) {
                      clsTools.PagErrorException(`reportListService.get`,`get`, e);
         
                } finally { 
                        return result;
                }

        }
}