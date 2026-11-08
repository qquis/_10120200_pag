import f0210_01_notificacao_send_crud from '../scriptdb/f0210_01_notificacao_send_crud'
import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'

import tbnotificacao_send_message from "./tbnotificacao_send_message"
import { Console } from 'console';
export default class tbnotificacao_send extends modelTb {
            dtlog_insert: Date
			dtlog_update: Date 
            notificacao_cd: number
            notificacao_send_seq: number
            notificacao_send_data: Date  				
            notificacao_send_tipo_cd: number 			
            notificacao_send_status_cd: number			
            proc_log_seq: number 						
            notificacao_whatsapp: number				
            notificacao_mail: number
            notificacao_celular_dd_numero: string  							
            notificacao_email: string
            notificacao_email_cc: string
            notificacao_email_co: string
            notificacao_email_subject: string
            notificacao_email_title: string
            notificacao_whatsapp_gp?: number
            notificacao_mk_cd?: number 
            //notificacao_send_message?: tbnotificacao_send_message
            

        public constructor(notificacao_send_seq: number) 
        {
            super()
            try {
                this.dtlog_insert = new Date(); 
                this.dtlog_update = new Date(); 
                this.proc_log_seq = 0; 
                this.notificacao_cd = 0;
                this.notificacao_send_seq = notificacao_send_seq;
                this.notificacao_send_data = new Date(); 
                this.notificacao_send_tipo_cd = 0;
                this.notificacao_send_status_cd = 0; 
                this.notificacao_whatsapp = 0;
                this.notificacao_mail = 0; 
                this.notificacao_celular_dd_numero = "";
                this.notificacao_email = "";
                this.notificacao_email_cc = ''
                this.notificacao_email_co = ''
                this.notificacao_email_subject = ''
                this.notificacao_email_title = ''
                this.notificacao_whatsapp_gp = 0;
                this.notificacao_mk_cd = 0;
                //this.notificacao_send_message = new tbnotificacao_send_message(new Date('1900-01-01'), 0, 0, '')
            }
            catch (e)
            {
                this.dtlog_insert = new Date(); 
                this.dtlog_update = new Date(); 
                this.proc_log_seq = 0; 
                this.notificacao_cd = 0;
                this.notificacao_send_seq = 0;
                this.notificacao_send_data = new Date(); 
                this.notificacao_send_tipo_cd = 0;
                this.notificacao_send_status_cd = 0; 
                this.notificacao_whatsapp = 0;
                this.notificacao_mail = 0; 
                this.notificacao_celular_dd_numero = "";
                this.notificacao_email = `suporte@oxan.com.br`
                //this.notificacao_send_message = new tbnotificacao_send_message(new Date("1900-01-01"),0,0,"");
                this.notificacao_email_cc = ''
                this.notificacao_email_co = ''
                this.notificacao_email_subject = ''
                this.notificacao_email_title = ''
                this.notificacao_whatsapp_gp = 0;
                this.notificacao_mk_cd = 0;
            }
        }


        _Db_Pg_script(_stringCommand: string): string{

            
            const script: string = `Select * from ${f0210_01_notificacao_send_crud.sqlScript_VERSION()}
            (     vcommand_db:=                     '${_stringCommand}', 
                  vnotificacao_cd:=                 ${this.notificacao_cd},
                  vnotificacao_send_seq:=            ${this.notificacao_send_seq},
                  vnotificacao_send_data:=           '${myTools.format_Date_toStr_ShortDataBase(this.notificacao_send_data)}',
                  vnotificacao_send_tipo_cd:=        ${this.notificacao_send_tipo_cd? this.notificacao_send_tipo_cd : 0},
                  vnotificacao_send_status_cd:=      ${this.notificacao_send_status_cd? this.notificacao_send_status_cd : 1},
                  vproc_log_seq:=                    ${this.proc_log_seq? this.proc_log_seq : 0},
                  vnotificacao_whatsapp:=            ${this.notificacao_whatsapp? this.notificacao_whatsapp : 0},
                  vnotificacao_mail:=                ${this.notificacao_mail? this.notificacao_mail : 0},
                  vnotificacao_celular_dd_numero:=   '${this.notificacao_celular_dd_numero? this.notificacao_celular_dd_numero : '1127825227'}',
                  vnotificacao_email:=               '${this.notificacao_email? this.notificacao_email : 'comunicacao@oxan.com.br'}',
                  vnotificacao_email_cc:=            '${this.notificacao_email_cc? this.notificacao_email_cc : ''}',
                  vnotificacao_email_co:=            '${this.notificacao_email_co? this.notificacao_email_co : ''}',
                  vnotificacao_email_subject:=       '${this.notificacao_email_subject? this.notificacao_email_subject : ''}',
                  vnotificacao_email_title:=         '${this.notificacao_email_title? this.notificacao_email_title : ''}',
                  vnotificacao_whatsapp_gp:=         ${this.notificacao_whatsapp_gp? this.notificacao_whatsapp_gp : 0}, 
                  vnotificacao_mk_cd:=               ${this.notificacao_mk_cd? this.notificacao_mk_cd : 0}
                )`

                return script; 
        }
        
        async binding(item: any)
        {
            try {
                if ( item !== undefined) {
                    this.notificacao_send_seq = item.notificacao_send_seq
                    this.proc_log_seq =  item.proc_log_seq
                    this.notificacao_cd = item.notificacao_cd
                    this.notificacao_send_data = item.notificacao_send_data
                    this.notificacao_whatsapp = item.notificacao_whatsapp
                    this.notificacao_whatsapp_gp = item.notificacao_whatsapp_gp                    
                    this.notificacao_email = item.notificacao_email
                    this.notificacao_send_status_cd = item.notificacao_send_status_cd;
                    this.notificacao_send_tipo_cd = item.notificacao_send_tipo_cd;
                    this.notificacao_celular_dd_numero = item.notificacao_celular_dd_numero;
                    this.notificacao_email = item.notificacao_email;
                    this.notificacao_email_subject = item.notificacao_email_subject
                    this.notificacao_email_cc = item.notificacao_email_cc
                    this.notificacao_email_co = item.notificacao_email_co
                    this.notificacao_email_title = item.notificacao_email_title
                    this.notificacao_mk_cd = item.notificacao_mk_cd;
                    //this.notificacao_send_message?.binding(item)
                }
            } catch(e){
                throw `tbnotificacao_send | ${e}`        
            }
        }
}