import { modelTb } from "../../../model/model"

export default class tbnotificacao extends modelTb {
    notificacao_cd: number
    notificacao_descricao: string
    notificacao_mail: number
    notificacao_origem_sis_nucleo_prc_cd: number
    notificacao_send_tipo_cd: number
    notificacao_whatsapp: number
    notificacao_tipo_body_cd: number 
    notificacao_sql: string
    notificacao_whats_user_show: number
    constructor() {
        super()
        this.notificacao_cd= 0
        this.notificacao_descricao= ''
        this.notificacao_mail= 0 
        this.notificacao_origem_sis_nucleo_prc_cd= 0
        this.notificacao_send_tipo_cd= 0
        this.notificacao_whatsapp= 0 
        this.notificacao_tipo_body_cd= 0
        this.notificacao_sql= ''
        this.notificacao_whats_user_show = 0 
    }
    async binding(item: any): Promise<void> {
            if (item) {
            this.notificacao_cd = item?.notificacao_cd
            this.notificacao_descricao = item?.notificacao_descricao
            this.notificacao_mail = item?.notificacao_mail
            this.notificacao_origem_sis_nucleo_prc_cd = item?.notificacao_origem_sis_nucleo_prc_cd
            this.notificacao_send_tipo_cd = item?.notificacao_send_tipo_cd
            this.notificacao_whatsapp = item?.notificacao_whatsapp
            this.notificacao_tipo_body_cd = item?.notificacao_tipo_body_cd
            this.notificacao_sql = item?.notificacao_sql
            this.notificacao_whats_user_show = item?.notificacao_whats_user_show
    }
}
}