import { clsBase, clsTools } from '../../../model/modelbase';
import modelProdutoBluesoft from '../model/modelProdutoBluesoft';
import serviceProdutoBluesoftProcessarImportacoes from './serviceProdutoBluesoftProcessarImportacoes';
import bluesoftapi from "../../Apis/bluesoftApi/api";
import model0040_fiscal from '../../m0040_fiscal/model/model';
import modelSistema from '../../m0001_sistema/model/model'

/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 2102
    const FLG_DEBUG_CONSOLE_LOG : boolean = true
    const FLG_MODULO : string = "M0021-ProdutoBluesoft | IMPORT PRODUTO BLUESOFT"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = `IMPORTACAO_PRODUTO_BLUESOFT`
/*  ------------------------------------------------------------------------------------------- */    


import reportProdutoBluesoftRedshift from '../report/report.ProdutoBluesoft.Redshift';

export default class serviceProdutoBluesoftRedShiftImportar  {


    public static async start(parametro: any) : Promise<any> {
        
    }

}


class serviceProdutoBluesoftRedShift {
    static async start(parametros: any): Promise<void> {
        const myBase : clsBase = new clsBase()
        await clsTools.pagConsole(`${FLG_MODULO}.start() - Iniciando importação de participante Redshift`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
        try { 
                const result = await reportProdutoBluesoftRedshift.get(parametros);
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
                let itemProdutoBluesoft: modelProdutoBluesoft = new modelProdutoBluesoft()
                await itemProdutoBluesoft.LerDadosRedShift(item)

                //sqlInsert += await itemProdutoBluesoft.ScriptIncluirParticipanteFromRedShift(item)
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