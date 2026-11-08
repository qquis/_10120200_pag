import {clsBase} from '../../../model/modelbase'
import { ifilter } from '../interfaces'
import mdNotificacaoSendMessage from '../model/mdNotificacaoSend'
import f0210_03_notificacao_send_message_list  from '../scriptdb/f0210_03_notificacao_send_message_list'


export default class rptNotificacaoSendMessage extends clsBase{ 
    list: mdNotificacaoSendMessage[]
    data: object
    constructor(){
        super()
        this.list = []
        this.data = {}
    }
    public async dataBinding(result: object) : Promise<void>{
        this.list = []
        try {
            for (const [Key, value] of Object.entries(result)) {
                let i = new mdNotificacaoSendMessage(0); 
                await i.bindingMd(value)
                this.list.push(i)
            }
        } catch (e) {
            this.myTools.PagErrorException('rptNotificacaoSendMessage', 'dataBinding', e)            
        }
    }
        
    public sql(filter : ifilter) : string {
        let sql = ``

        try {
            sql = `Select * from ${f0210_03_notificacao_send_message_list.sqlScript_VERSION()}
            (       ${filter.notificacao_send_seq}, 
                   '${this.myTools._datemomentDateToStr(filter.notificacao_send_data_ini, `YYYY-MM-DD`)}', 
                   '${this.myTools._datemomentDateToStr(filter.notificacao_send_data_fim, `YYYY-MM-DD`)}', 
                   ${filter.notificacao_send_status_cd}, 
                   ${filter.notificacao_send_tipo_cd}, 
                  '${filter.notificacao_celular_dd_numero}', 
                  '${filter.notificacao_email}',
                   ${filter.notificacao_whatsapp}, 
                   ${filter.notificacao_mail},
                   ${filter.notificacao_whatsapp_gp}
            )`

         } catch (e){
            this.myTools.PagErrorException('rptNotificacaoSendMessage', 'sql', e)
        } finally { 
            return sql
        }
    }
}