//import f0210_01_notificacao_send_crud from '../scriptspg/f0210_01_notificacao_send_crud'
import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'

export default class tbsistema_batch extends modelTb {
            dtlog_insert: Date
			dtlog_update: Date 
            sis_batch_cd: number
            sis_batch_descricao: string
            sis_batch_service_cd: number 
            module_cd: string 
            

        public constructor(sis_batch_cd: number) 
        {
            super()

                const _dataInitial : Date = myTools.pagDateTime_getDate();
                this.dtlog_insert = _dataInitial; 
                this.dtlog_update = _dataInitial; 
                this.sis_batch_cd = sis_batch_cd; 
                this.sis_batch_descricao = ``
                this.sis_batch_service_cd = 0;
                this.module_cd = ``
        }

        _Db_Pg_script_Select(): string {
            let stringsql = `` 


            if (this.sis_batch_cd !== 0 ) {
                stringsql =  `   SELECT      sis_batch_cd            
                                        ,   sis_batch_descricao
                                        ,   sis_batch_status 
                                        ,   sis_batch_service_cd 
                                FROM        tbsistema_batch   
                                WHERRE      sis_batch_cd = ${this.sis_batch_cd}
                    `
            }

            return stringsql; 

        }


        _Db_Pg_script(_stringCommand: string): string{
            
            const script: string = ``
                return script; 
        }
        
        async binding(item: any)
        {
            if (item != undefined) {
                this.sis_batch_cd = parseInt(item?.sis_batch_cd) 
                this.sis_batch_descricao = item?.sis_batch_descricao
                this.sis_batch_service_cd = parseInt(item?.sis_batch_service_cd) 
                this.module_cd = item?.module_cd
            }
           
        }
}