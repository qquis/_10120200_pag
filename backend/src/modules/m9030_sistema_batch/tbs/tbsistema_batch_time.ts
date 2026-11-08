//import f0210_01_notificacao_send_crud from '../scriptspg/f0210_01_notificacao_send_crud'
import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'

export default class tbsistema_batch_time extends modelTb {
            dtlog_insert: Date
			dtlog_update: Date 
            sis_batch_cd: number
            sis_batch_recorrencia_cd: number
            sis_batch_dt_ini: Date 			
            sis_batch_dt_fim: Date 			 			
            sis_batch_hm_ini: string  			
            sis_batch_hm_fim: string  			
            sis_batch_wk_ini: number 			
            sis_batch_wk_fim: number 	
            notificacao_cd: number	
            sis_batch_time_seq: number	 			
           
            

        public constructor(sis_batch_cd: number) 
        {
            super()

                
                this.dtlog_insert = this.__defaultDateNow; 
                this.dtlog_update = this.__defaultDateNow; 
                this.sis_batch_cd = sis_batch_cd; 
                this.sis_batch_recorrencia_cd = 0; 
                this.sis_batch_dt_ini =  this.__defaultDateNow; 		
                this.sis_batch_dt_fim =  this.__defaultDateNow; 	 			
                this.sis_batch_hm_ini =  `00:00`  			
                this.sis_batch_hm_fim =  `00:00`  			
                this.sis_batch_wk_ini =  0 			
                this.sis_batch_wk_fim =  0 
                this.notificacao_cd = 0;
                this.sis_batch_time_seq = 0;
           
        }


        _Db_Pg_script(_stringCommand: string): string{
            
            const script: string = ``
                return script; 
        }
        
        async binding(item: any)
        {
           
        }
}