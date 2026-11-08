
import { clsTools, clsBase} from '../../../model/modelbase'

let myBase = new clsBase()

import modelParticipanteBase from '../model/model';
import modelParticipante from '../model/modelparticipante';
import reportParticipante from '../report/report'
import modelSistema from '../../m0001_sistema/model/model'

/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 10050011
    const FLG_DEBUG_CONSOLE_LOG : boolean = true
    const FLG_MODULO : string = "M0011-Service | ServiceParticipanteBlueSoftImport"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    

export default class serviceParticipanteBlueSoftRedShiftImport { 
    static async start(parametros: any): Promise<void> {
        await clsTools.pagConsole(`${FLG_MODULO}.start() - Iniciando importação de participante Redshift`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
        try { 
                const result = await reportParticipante.Redshift.get(parametros);
                const DataList: any[] = Array.isArray(result)
                ? result
                : (result != null ? [result] : []);




            let sqlInsert : string = ""
            let imaxUpdate : number = await modelSistema.resources.Sistema.limiteRegBloqUpdateGet(SISTEMA_NUCLEO_PRC_CD)

            if (imaxUpdate == 0)
                imaxUpdate = 100
            let i : number = 0
            let iBlocoTotal : number = Math.ceil(DataList.length / imaxUpdate)
            let iBloco: number = 0
            await clsTools.pagConsole(`${FLG_MODULO}.start() - Número de Registros / Blocos: ${DataList.length} / Número de Blocos: ${iBlocoTotal}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)


            for await (const item of DataList) {
                let itemParticipanteBluesoft: modelParticipante = new modelParticipante({})
                await itemParticipanteBluesoft.ObterDadosRedShift(item)

                sqlInsert += await itemParticipanteBluesoft.ScriptIncluirParticipanteFromRedShift(item)
                i++;

                if (i >= imaxUpdate) {
                    await myBase.myDataBase.pag.Execute(sqlInsert);
                    sqlInsert = ""
                    i = 0
                    iBloco++
                    await clsTools.pagConsole(`${FLG_MODULO}.start() - Bloco de ${iBloco} / ${iBlocoTotal}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                }
            }

            
            if (sqlInsert.length > 0) {
                await myBase.myDataBase.pag.Execute(sqlInsert);
                await clsTools.pagConsole(`${FLG_MODULO}.start() - Último Bloco Processado`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            }



        } catch (e: any) {
            await clsTools.PagErrorException(`F0011 - Participante`, `serviceParticipanteBlueSoftImport.start()`, e, true);
            throw new Error(`modules | Participante | Error ${e.message}`);
        }

        finally {
            await clsTools.pagConsole(`${FLG_MODULO}.start() - Importação de participante Redshift finalizada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
        }
    }

   

}