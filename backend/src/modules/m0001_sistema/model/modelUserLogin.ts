import {clsTools} from "../../../model/modelbase";

export default class modelUserLogin { 
    usuario_login_uuid : string 
    sis_id: number
    sis_us_seq : number
    user_name : string 
    dtlog_insert : Date
    autorizado : number
    email_login: string 
    password : string 
    user_credential: string 
    user_credential_number: string 
    jwtExp: number
    jwtIat: number

    constructor() { 

            this.sis_id = 0 
            this.usuario_login_uuid = `` 
            this.sis_us_seq = 0 
            this.user_name = `` 
            this.dtlog_insert = new Date();
            this.autorizado = 0
            this.email_login = `` 
            this.password = `` 
            this.jwtExp = 0
            this.jwtIat = 0
            this.user_credential = ``
            this.user_credential_number = ``
   

    }
    binding(item : any) { 
        try {
            if (item) { 
                this.usuario_login_uuid = item?.usuario_login_uuid
                this.sis_us_seq = item?.sis_us_seq
                this.user_name = item?.user_name
                this.autorizado = item?.autorizado
                this.email_login = item?.email_login
                this.usuario_login_uuid = item?.usuario_login_uuid
                this.password = `` 
                this.user_credential = item?.user_credential
            }
        } catch (e) {
                clsTools.PagErrorException('model_notificacao', 'NotificacaoGetParticipantes', e)
        }
    }

}