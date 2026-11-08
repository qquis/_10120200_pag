


/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = true
    const FLG_MODULO : string = "M0070-FATURAMENTO | Faturamento Bluesoft Processamento"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
import { promises } from 'dns';
/*  ------------------------------------------------------------------------------------------- */    


import { clsBase, clsTools } from '../../../model/modelbase';
import scriptsqlInterface from '../sql/scriptsql'

export default class serviceInterfaceFaturamentoProcessar {

    static async start(parametros : any) : Promise<any> { 
        let result : any = {}
        try { 

            let myDataBase : clsBase = new clsBase();            
            
            let sql = scriptsqlInterface.functions.f0071_10_interface_faturamento_processar.get(parametros)

            
            await myDataBase.myDataBase.pag.DataGet(sql)
            result.status = true
            result.descricao = `Atualização realizada com sucesso`
        
        } catch (e) { 
            this._log(`serviceInterfaceFaturamentoProcessar | ${e}`)
            result.status = false
            result.info = `Erro ${e}`
        }
        finally { 
            return result;
        }
    }

    static async _log(message: string): Promise<void> {
            await clsTools.pagConsole(`${FLG_MODULO} | ${message}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
    }
}