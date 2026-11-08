
import { clsBase, clsTools } from "../../../model/modelbase";



export default class reportServiceBathTimeList {
        public static sql(parametros: any) : string { 
                let sql = `
                            
                                select 	        t.sis_batch_cd 
                                        ,	t.sis_batch_recorrencia_cd
                                        ,	r.sis_batch_recorrencia_descricao
                                        ,	t.sis_batch_dt_ini
                                        ,	t.sis_batch_dt_fim
                                        ,	t.sis_batch_hm_ini
                                        ,	t.sis_batch_hm_fim
                                        ,	t.sis_batch_wk_ini
                                        ,	t.sis_batch_wk_fim
                                        ,	t.sis_batch_time_seq 
                                from  tbsistema_batch_time t
                                left join tbsistema_batch b on b.sis_batch_cd = t.sis_batch_cd
                                left join tbsistema_batch_recorrencia r on r.sis_batch_recorrencia_cd = t.sis_batch_recorrencia_cd
                                left join tbsistema_batch_service s on s.sis_batch_service_cd = b.sis_batch_service_cd
                                                        where 1 = 1 
                                ${parametros.sis_batch_cd ? ` and t.sis_batch_cd = ${parametros.sis_batch_cd}` : ''}
                                ${parametros.sis_batch_service_cd ? ` and s.sis_batch_service_cd = ${parametros.sis_batch_service_cd}` : ''}


                `;

                return sql;
        }

        static async get(parametros: any) : Promise <any> { 
                let result : any = {}
            
                try { 
                    const modeldb = new clsBase(); 
                    result = await modeldb.myDataBase.pag.DataGet(this.sql(parametros));
                    

                } catch (e) {
                      clsTools.PagErrorException(`reportSistemaBatchTimeList.get`,`get`, e);
         
                } finally { 
                        return result;
                }

        }
}