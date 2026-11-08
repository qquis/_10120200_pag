import f9030_01_sistema_batch_run_crud from '../scriptpg/f9030_01_sistema_batch_run_crud'
import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'



export default class tbsistema_batch_run extends modelTb {
            dtlog_insert: Date
			dtlog_update: Date 
            sis_batch_cd: number				
            sis_batch_run_seq: number		
            sis_batch_run_status_cd: number 		
            sis_batch_run_dtlog_start: Date 	
            sis_batch_run_dtlog_end: Date 	
            

        public constructor(sis_batch_run_seq: number) 
        {
            super()
            const _dataInitial : Date = myTools.pagDateTime_getDate();
            this.dtlog_insert = _dataInitial
            this.dtlog_update = _dataInitial
            this.sis_batch_cd = 0; 
            this.sis_batch_run_seq = sis_batch_run_seq
            this.sis_batch_run_status_cd = 0; 
            this.sis_batch_run_dtlog_start = _dataInitial
            this.sis_batch_run_dtlog_end = _dataInitial
      
        }


        _Db_Pg_script(_stringCommand: string): string{
            
            const script: string = `Select * from ${f9030_01_sistema_batch_run_crud.sqlScript_VERSION()}
            (     vcommand_db:=                     '${_stringCommand}', 
                  vsis_batch_cd:=                    ${this.sis_batch_cd},
                  vsis_batch_run_seq:=               ${this.sis_batch_run_seq},
                  vsis_batch_run_status_cd:=         ${this.sis_batch_run_status_cd},
                  vsis_batch_run_dtlog_start:=       '${myTools.format_Date_toStr_ShortDataBase(this.sis_batch_run_dtlog_start)}',
                  vsis_batch_run_dtlog_end:=         '${myTools.format_Date_toStr_ShortDataBase(this.sis_batch_run_dtlog_end)}'
                )`
                return script; 
        }
        
        async binding(item: any)
        {
            try {
                
                if ( item !== undefined) {

                    const _dataDefault : Date = myTools.pagDateTime_getDate();

                    this.sis_batch_cd = item.sis_batch_cd; 
                    this.sis_batch_run_seq = item.sis_batch_run_seq;
                    this.sis_batch_run_status_cd = item.sis_batch_run_status_cd; 
                    this.sis_batch_run_dtlog_start = myTools.pagDateTime_getDate(item.sis_batch_run_dtlog_start?item.sis_batch_run_dtlog_start:_dataDefault); 
                    this.sis_batch_run_dtlog_end = myTools.pagDateTime_getDate(item.sis_batch_run_dtlog_end?item.sis_batch_run_dtlog_end:_dataDefault); 

                }
            } catch(e){
                throw `tbsistema_batch_run | ${e}`        
            }
        }
}