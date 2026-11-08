import { clsBase, clsTools } from '../../../model/modelbase'

import serviceNotificacao from '../../m0210_notificacao/service/_serviceNotificacao';
export default class serviceSistemaNotificacao {
    public static async notificar(mensagem: string) : Promise<void> {
        try {
                await serviceNotificacao.Criar({notificacao_cd : 1009030001 , notificacao_send_tipo_cd : 100, notificacao_send_message : mensagem}) 
        } catch (e) {
            clsTools.PagErrorException('serviceSistema', 'notificar', e)
            throw new Error('serviceSistema.notificar')
        }
    }
}