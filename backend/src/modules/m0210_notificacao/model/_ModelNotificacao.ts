//import DataBase from "../../../database/DataBase";
//import myTools from "../../../tools/Tools";
import {clsBase} from "../../../model/modelbase";
import mdNotificacao from "./mdNotificacao";
import mdNotificacaoParticipante from "./mdNotificacaoParticipante";
import mdNotificacaoSendMessage from "./mdNotificacaoSend";
//const myDataBase = new DataBase()


export default class modelNotificacao extends clsBase { 
    notificacao : mdNotificacao
    Participantes : mdNotificacaoParticipante[] 
    NotificacaoSendMessage : mdNotificacaoSendMessage[]

    public static NotificacaoSendProcessStatus = {
        start: 10, 
        send: 30,
    } as const
    
    
    constructor() {
        super()
        this.notificacao = new mdNotificacao()
        this.NotificacaoSendMessage = []
        this.Participantes = []
    }
    async NotificacaoAddParticipante(cdparticipante: number): Promise<void> {
        let sql = `INSERT INTO tbnotificacao_participante (notificacao_cd, cdparticipante) 
                        SELECT ${this.notificacao.notificacao_cd}, ${cdparticipante}
                    where not exists (
                            SELECT 1 FROM tbnotificacao_participante 
                            WHERE notificacao_cd = ${this.notificacao.notificacao_cd}
                            AND cdparticipante = ${cdparticipante}
                        )    
                `

        try {
                
                await this.myDataBase.pag.Execute(sql)
         } catch (e) {
            this.myTools.PagErrorException('model_notificacao', 'addParticipante', e)
         }
    }

    async NotificaoDelParticipante(cdparticipante: number): Promise<void> {
        let sql = `DELETE FROM tbnotificacao_participante 
                        WHERE notificacao_cd = ${this.notificacao.notificacao_cd}
                        AND cdparticipante = ${cdparticipante}`

        try {
                await this.myDataBase.pag.Execute(sql)
         } catch (e) {
            this.myTools.PagErrorException('model_notificacao', 'delParticipante', e)
         }
    }

    async NotificacaoParticipantesBinding(): Promise<void> { 
        try { 
            this.Participantes = []
            let sql = `SELECT   p.cdparticipante
                        ,    p.nome_razao 
                        ,    coalesce(p.email_main, '') as email_main
                        ,    cast(coalesce(p.celular_dd,'0') as varchar(2)) as celular_dd
                        ,    cast(coalesce(p.celular_numero,0) as varchar(20)) as celular_numero
                        ,    cast(0 as int) as isGroup
                  FROM          tbnotificacao_participante i 
                  INNER JOIN    tbparticipante p on p.cdparticipante = i.cdparticipante
                    WHERE       i.notificacao_cd = ${this.notificacao.notificacao_cd}
                    
                    UNION
                SELECT		0 as cdparticipante
                        ,	'GRUPO' as nome_razao
                        ,	'suporte@oxan.com.br' as email_main
                        ,	cast('' as varchar(2))  as celular_dd
                        ,	cast(notificacao_gp_whats as varchar(20)) as celular_numero
                        ,	cast(1 as int) as isGroup
                from 		tbnotificacao_grupo g
                where		g.notificacao_cd  = ${this.notificacao.notificacao_cd}
                    
                    
                    
                    
                    `
                    

            let result = await this.myDataBase.pag.DataGet(sql)
            for ( const [key, value ] of Object.entries(result)) {
                let item = new mdNotificacaoParticipante()
                item.bindingMd(value)
                this.Participantes.push(item)
            }
        } catch (e) {
            this.myTools.PagErrorException('model_notificacao', 'NotificacaoGetParticipantes', e)
        }
    }


    async Notificar(itemNotificacaoSendMessage : mdNotificacaoSendMessage): Promise<void> { 
        try {
            let PROCESSOLOG = await this.ProcessoLogGerar(99901, 1)
            itemNotificacaoSendMessage.notificacao_cd = this.notificacao.notificacao_cd
            itemNotificacaoSendMessage.notificacao_send_status_cd = 1
            itemNotificacaoSendMessage.proc_log_seq = PROCESSOLOG
            await itemNotificacaoSendMessage.__CRUD();


        await this.myDataBase.pag.Execute(`
                                INSERT INTO tbnotificacao_send_message (notificacao_send_seq, notificacao_send_message) 
                                VALUES (    ${itemNotificacaoSendMessage.notificacao_send_seq}
                                        ,   '${itemNotificacaoSendMessage.notificacao_send_message?.notificacao_send_message}'
                                        )`
                                    )
        if (!itemNotificacaoSendMessage.notificacao_celular_dd_numero && !itemNotificacaoSendMessage.notificacao_email) {
                    await itemNotificacaoSendMessage.MessageSetError()
                }


        } catch (e) {  
            this.myTools.PagErrorException('model_notificacao', 'Notificar', e)
        }
    
    }

    async ProcessNotificacaoSend(notificacao_send_seq: number, 
            process: typeof 
                modelNotificacao.NotificacaoSendProcessStatus[keyof typeof modelNotificacao.NotificacaoSendProcessStatus]): Promise<void> { 
        try {
            let itemNotificacaoSendMessage : mdNotificacaoSendMessage = new mdNotificacaoSendMessage(notificacao_send_seq)

            switch (process) {
                case modelNotificacao.NotificacaoSendProcessStatus.start:
                    await itemNotificacaoSendMessage.MessageStart()
                    break
                case modelNotificacao.NotificacaoSendProcessStatus.send:
                    await itemNotificacaoSendMessage.MessageSend()
                    break
            }

        } catch (e) {
            
            this.myTools.PagErrorException('model_notificacao', 'NotificacaoSendStart', e)
        }
    
    }


    
}