import { clsBase, clsTools } from "../../../model/modelbase";

import servicePrecoAgendado from "./servicePrecoAgendado";
import servicePrecoAplicacao from "./servicePrecoAplicado";
import serviceAplicacao from "./serviceAplicacao";

export default class service {

    static async integrarBlueSoftPrecoAplicado() { 
        try { 
            
            let PrecoAplicado : servicePrecoAplicacao = new servicePrecoAplicacao();
            await PrecoAplicado.bluesoftIntegrarPrecos(0)

        } catch (e) { 
            clsTools.PagErrorException(`M0045`, `integrarBlueSoftPrecoAplicado.start Error`, e)
        }
    }



    static async integrarBlueSoftPrecoAgedando() { 
        try { 
            
            let PrecoAgedando : servicePrecoAgendado = new servicePrecoAgendado();
            await PrecoAgedando.bluesoftIntegrar(0)

        } catch (e) { 
            clsTools.PagErrorException(`M0045`, `integrarBlueSoftPrecoAgedando.start Error`, e)
        }
    }

    static async AplicarPrecos(parametros: any = {}) : Promise<boolean> { 
        let statusExecucao : boolean = false;
        try { 
            statusExecucao = await serviceAplicacao.start(parametros)

        } catch (e) { 
            clsTools.PagErrorException(`M0045`, `serviceAplicacao.start Error`, e)
        }
        finally { 
            return statusExecucao;
        }
    }
}