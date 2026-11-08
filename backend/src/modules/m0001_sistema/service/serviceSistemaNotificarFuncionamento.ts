import { clsBase, clsTools } from "../../../model/modelbase"
import f0001_01_sistema_backend_start from "../scriptdb/f0001_01_sistema_start"
import serviceNotificacao from '../../m0210_notificacao/service/_serviceNotificacao';


export default class serviceSistemaNotificarFuncionamento { 
    public static async start() : Promise<void> {
        try {
                const hora = new Date().getHours();
                let saudacao = "Bom dia";
                if (hora >= 12 && hora < 18) saudacao = "Boa tarde";
                else if (hora >= 18 || hora < 5) saudacao = "Boa noite";

                let mensagem = `🖥️ ${saudacao}! Backend funcionando normalmente - ${new Date().toLocaleTimeString('pt-BR').slice(0, 8)} \n Fique tranquilo!`
                await serviceNotificacao.Criar({notificacao_cd : 1009030001 , notificacao_send_tipo_cd : 100, notificacao_send_message : mensagem}) 
        } catch (e) {
            clsTools.PagErrorException('serviceSistema', 'notificar', e)
            throw new Error('serviceSistema.notificar')
        }

    }

 


}