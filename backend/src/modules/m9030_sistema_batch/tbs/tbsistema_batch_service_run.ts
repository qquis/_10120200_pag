import f9030_01_sistema_batch_run_crud from '../scriptpg/f9030_01_sistema_batch_run_crud'
import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'



export default class tbsistema_batch_service_run extends modelTb {
            dtlog_insert: Date
			dtlog_update: Date 
            sis_batch_service_run_seq: number	
            sis_batch_service_cd: number	
            sis_batch_service_run_status_shedule: number
            

        public constructor(sis_batch_service_cd: number) 
        {
            super()
            const _dataInitial : Date = myTools.pagDateTime_getDate();
            this.dtlog_insert = _dataInitial
            this.dtlog_update = _dataInitial
            this.sis_batch_service_cd = sis_batch_service_cd; 
            this.sis_batch_service_run_seq = 0 
            this.sis_batch_service_run_status_shedule = 0 
      
        }

        _Db_Pg_script_Insert() {

            return `
            
            insert into tbsistema_batch_service_run 
                    (
                             id_insert 
                        ,    sis_batch_service_cd
                        ,    sis_batch_service_run_status_shedule
                    )
                    VALUES (
                             '${this.id_insert}'
                            , ${this.sis_batch_service_cd}
                            , ${this.sis_batch_service_run_status_shedule}
                        );
                     `
        }

        _Db_Pg_script_Select() { return ``}        
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