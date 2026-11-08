import DataBase from "../../../database/DataBase";
import myTools from "../../../tools/Tools";

//tbs
import tbnotificacao from "../tbs/tbnotificacao";

//submodels
import mdNotificacaoSendMessage from './mdNotificacaoSend';


const myDataBase = new DataBase()

export default class mdNotificacao extends tbnotificacao { 
    constructor() {
        super()

    }

    async NotificacaoGet(notificacao_cd: number): Promise<void> {
        if (notificacao_cd !== undefined) {
            let sql = ` SELECT  notificacao_cd
                            ,   notificacao_descricao
                            ,   notificacao_whatsapp
                            ,   notificacao_mail 
                            ,   notificacao_send_tipo_cd
                            ,   coalesce(notificacao_tipo_body_cd, 0) as notificacao_tipo_body_cd
                            ,   coalesce(notificacao_sql, '') as notificacao_sql
                            ,   coalesce(notificacao_whats_user_show, 0) as notificacao_whats_user_show
                        FROM    tbnotificacao WHERE notificacao_cd = ${notificacao_cd}`
            let result = await myDataBase.pag.DataGet(sql)
            this.binding(result[0])
        }
    }


}