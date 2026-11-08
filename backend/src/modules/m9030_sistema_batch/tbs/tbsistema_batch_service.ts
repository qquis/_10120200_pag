import f9030_01_sistema_batch_run_crud from '../scriptpg/f9030_01_sistema_batch_run_crud'
import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'



export default class tbsistema_batch_service extends modelTb {
            dtlog_insert: Date
			dtlog_update: Date 
            sis_batch_service_cd: number	
            sis_batch_service_descricao: string 
            sis_batch_service_ult_run_host: string 			
            sis_batch_service_ult_run_date: Date 	
            

        public constructor(sis_batch_service_cd: number) 
        {
            super()
            const _dataInitial : Date = myTools.pagDateTime_getDate();
            this.dtlog_insert = _dataInitial
            this.dtlog_update = _dataInitial
            this.sis_batch_service_cd = sis_batch_service_cd; 
            this.sis_batch_service_descricao = `` 
            this.sis_batch_service_ult_run_date = _dataInitial 
            this.sis_batch_service_ult_run_host = `` 
      
        }

        _Db_Pg_script_Update() {
            return `UPDATE tbsistema_batch_service 
                    SET sis_batch_service_ult_run_date = current_timestamp 
                    ,   sis_batch_service_ult_run_host = 'localhost'
                    where 1 = 1
                      and sis_batch_service_cd = ${this.sis_batch_service_cd}
                    ;

            `
        }  
        
        async binding(item: any)
        {
            try {
                
                if ( item !== undefined) {

                    this.dtlog_insert = this.__defaultDateNow

                }
            } catch(e){
                throw `tbsistema_batch_run | ${e}`        
            }
        }
}