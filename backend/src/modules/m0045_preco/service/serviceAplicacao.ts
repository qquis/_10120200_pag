import { clsBase, clsTools } from "../../../model/modelbase";
import serviceNotificacao from '../../m0210_notificacao/service/_serviceNotificacao';
import f0045_60_aplicacao from "../pgscripts/f0045_60_aplicacao";

let myDATABASE : clsBase = new clsBase();

export default class serviceAplicacao { 
    static async start (parametros: any = {}) : Promise<boolean> {
        let precoAplicadoComSucesso : boolean = false
        try { 
            await myDATABASE.myDataBase.pag.Execute(f0045_60_aplicacao.SELECT())
            precoAplicadoComSucesso = true; 
        } catch (e) { 
            clsTools.PagErrorException(`M0045`, `servicePrecoAplicacao.start Error`, e)
            precoAplicadoComSucesso = false

        } finally { 

            await serviceNotificacao.Criar({notificacao_cd : 1000030010
                                        , notificacao_send_tipo_cd : 100
                                        , notificacao_send_message : `🏷️ M0045 | A *Aplicação de Preço* ${parametros.user_name? `realizada pelo Usuario: *` + parametros.user_name + "*, ": "" } foi concluída com ${precoAplicadoComSucesso? 'SUCESSO ✅' : 'FALHA ❌ (CONSULTAR LOG)' }`
            })

            return precoAplicadoComSucesso
        }
    }
}


