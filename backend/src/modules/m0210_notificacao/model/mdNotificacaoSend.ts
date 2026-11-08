
import { Request, Response } from 'express';
import tbnotificacao_send from '../tbs/tbnotificacao_send'
import tbnotificacao_send_message from "../tbs/tbnotificacao_send_message"
import myTools from "../../../tools/Tools";
import tbnotificacao_participante from '../tbs/tbnotificacao_participante';



class mdNotificacaoSendMessage extends tbnotificacao_send {
    notificacao_send_message: tbnotificacao_send_message
    constructor(notificacao_send_seq: number)
    {
        super(notificacao_send_seq)
        this.notificacao_send_message = new tbnotificacao_send_message(new Date('1900-01-01'), 0, 0, '')
    }


    public async bindingMd(item: any): Promise<void> {
        try {
                await super.binding(item)
                this.notificacao_send_message.binding(item)


        } catch (e) {
            myTools.PagErrorException('mdNotificacaoSendMessage', 'bindingMd', e)
        }
    }

    public async NotificacaoSendGet (request: Request) {
        try {
            if (request !== undefined) {
                    this.notificacao_send_seq = parseInt(`${request.query.notificacao_send_seq}`)
            }
        } catch(e) {
            console.log(`ModelTbNoficiacao getNotificacaoSendSeqFromQuery Get error \n ${e}`)
        }

    }

    public SetMessage(message : any ) {
        this.notificacao_send_message = new tbnotificacao_send_message(new Date('1900-01-01'), 0, 0, `${message}`)
    }

    public async getModelFromRequest(request: Request) {
        try {
            if ( request !== undefined) {
                this.notificacao_send_seq = parseInt(`${request.body.notificacao_send_seq}`)
                this.notificacao_cd =  parseInt(`${request.body.notificacao_cd}`)
                this.notificacao_send_data =  myTools.Date_br_new(`${request.body.notificacao_send_data}`)
                this.notificacao_send_tipo_cd =  parseInt(`${request.body.notificacao_send_tipo_cd}`)
                this.notificacao_send_status_cd =  parseInt(`${request.body.notificacao_send_status_cd}`)
                this.proc_log_seq = parseInt(`${request.body.proc_log_seq}`)
                this.notificacao_whatsapp = parseInt(`${request.body.notificacao_whatsapp}`)
                this.notificacao_whatsapp_gp = parseInt(`${request.body.notificacao_whatsapp_gp}`)        
                this.notificacao_mail =  parseInt(`${request.body.notificacao_mail}`)
                this.notificacao_celular_dd_numero =  `${request.body.notificacao_celular_dd_numero}`
                this.notificacao_email =  `${request.body.notificacao_email}`
                this.notificacao_email_cc =  `${request.body.notificacao_email_cc}`
                this.notificacao_email_co =  `${request.body.notificacao_email_co}`
                this.notificacao_email_subject =   `${request.body.notificacao_email_subject}`
                this.notificacao_email_title =   `${request.body.notificacao_email_title}`
                this.notificacao_send_message = new tbnotificacao_send_message(new Date('1900-01-01'), 0, 0, `${request.body.notificacao_send_message}`)
            }
        } catch(e) {
            console.log(`ModelTbNoficiacao Request Get error \n ${e}`)
        }
        

   }
    public async MessageStart() {
        this.notificacao_send_status_cd = 10
        await super._Db_Pg_UPDATE()
    }
    public async MessageSend() {
        this.notificacao_send_status_cd = 30
        await super._Db_Pg_UPDATE()
    }

    public async MessageSetError() {
        this.notificacao_send_status_cd = 90
        await super._Db_Pg_UPDATE()
    }
    

}


export default mdNotificacaoSendMessage