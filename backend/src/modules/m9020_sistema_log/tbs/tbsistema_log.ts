import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'

export default class tbsistema_log extends modelTb {

            sis_log_seq: number				
            proc_log_seq: number		
            sis_nucleo_prc_cd: number 		
            sis_log_tag: string
            sis_log_info: string 
            sis_batch_run_seq: number
            uuid: string 
            uuid_start: string 
        public constructor() 
        {
            super()
            this.dtlog_insert = this.__defaultDateNow;
            this.sis_log_seq = 0
            this.proc_log_seq = 0
            this.sis_nucleo_prc_cd = 0 
            this.sis_log_tag = `` 
            this.sis_log_info = ``
            this.sis_batch_run_seq = 0
            this.uuid = ``; 
            this.uuid_start = `` 
        }



        _Db_Pg_script_DBCRUD() {

            let sql: string =   ///this._Db_Pg_script_Insert() + 
                                this._Db_Pg_script_Select() 
                              

            return sql; 
        }


         _Db_Pg_script_Insert() {

            try {

                    let sql: string =  `INSERT INTO TbSistema_Log 
                            (
                                    proc_log_seq 
                                ,   sis_nucleo_prc_cd 
                                ,   sis_log_tag 
                                ,   sis_log_info 
                                ,   sis_batch_run_seq
                                ,   uuid 
                                ,   uuid_start 
                            )
                            VALUES (
                                    ${this.proc_log_seq}
                                ,   ${this.sis_nucleo_prc_cd}
                                ,  '${this.sis_log_tag}'
                                ,  '${this.sis_log_info.length > 120? this.sis_log_info.substring(0, 120) : this.sis_log_info}'
                                ,   ${this.sis_batch_run_seq}
                                ,  '${this.uuid}'
                                ,  '${this.uuid_start}'
                            );
                        `
                        return sql
            } catch (e) {
                return ``
            }


        }

        _Db_Pg_script_Select(): string {
              let sql : string = `Select    dtlog_insert
                                        ,   sis_log_seq 
                                        ,   proc_log_seq 
                                        ,   sis_nucleo_prc_cd 
                                        ,   sis_log_tag 
                                        ,   sis_log_info 
                                        ,   sis_batch_run_seq
                                        ,   uuid 
                                  FROM      tbsistema_log 
                                  WHERE     1 = 1
                                  AND       uuid = '${this.uuid}'        
                                ` 

              return sql 
        }

        async binding(item: any)
        {
            try {
                
                if ( item !== undefined) {
                    const _dataDefault : Date = myTools.pagDateTime_getDate();
                    this.dtlog_insert = item.dtlog_insert
                    this.sis_log_seq = item.sis_log_seq;
                    this.proc_log_seq = item.proc_log_seq; 
                    this.sis_nucleo_prc_cd = item.sis_nucleo_prc_cd
                    this.sis_log_tag = `${item.sis_log_tag}`.replace("'", "").trimEnd()
                    this.sis_log_info = `${item.sis_log_info}`.replace("'", "").trimEnd()
                    this.sis_batch_run_seq = item.sis_batch_run_seq
                }
            } catch(e) {
                throw new Error(`TbSistema_Log Error:  ${e}`)        
            }
        }
}