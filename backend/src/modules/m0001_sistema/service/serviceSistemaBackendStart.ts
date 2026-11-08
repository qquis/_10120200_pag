import { clsBase, clsTools } from '../../../model/modelbase'
import serviceSistemaNotificacao from './serviceSistemaNotificacao'
import f0001_01_sistema_backend_start from "../scriptdb/f0001_01_sistema_start"

let myBase = new clsBase()

export default class serviceSistemaBackendStart {
 
    public static async defaultStartBackEnd(enviroment: string = 'PRD', backend_mirror : string = `0`) : Promise<void> {


        try {
            await this.startbackend(enviroment, backend_mirror)
        } catch (e) {
            clsTools.PagErrorException('serviceSistema', 'defaultStartBackEnd', e)
            throw new Error('Error in serviceSistema.defaultStartBackEnd')
        }

    }

    public static async startbackend(venvironment: string, backend_mirror: string = `0`): Promise<void> {
        try {
            let result : number  = await myBase.myDataBase.pag.Execute(f0001_01_sistema_backend_start.get({venvironment: venvironment, vbackend_mirror: backend_mirror}))
            
            
            if (result !== 0) { 
                if (venvironment == "DES") {
                    clsTools.pagConsole(`------------------------------------------------`, true, true)
                    clsTools.pagConsole(`AMBIENTE DE DESENVOLVIMENTO`, true, true)
                    clsTools.pagConsole(` - Não será enviado WHATS de inicialização`, true, true)
                    clsTools.pagConsole(`------------------------------------------------`, true, true)
                }
                else {
                    await serviceSistemaNotificacao.notificar(`🖥️ Backend inicializado | ENV ${venvironment} TIPO: ${backend_mirror == "0"? "PRINCIPAL": "SECUNDARIO" } - ${new Date().toLocaleTimeString('pt-BR').slice(0, 8)}`)
                }
            } else {
                await serviceSistemaNotificacao.notificar(`Erro na inicialização do Backend  + ${Date.now()}`)
                throw new Error('Error in startbackend')
            }


        } catch (e) {
            clsTools.PagErrorException('serviceSistema', 'startbackend', e)
            throw new Error('serviceSistema.startbackend')
        }
    }

}