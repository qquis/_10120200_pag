import myTools from '../../../../tools/Tools';
import { ifilter_faturamento } from '../../wk'
import FaturamentoZanthus from '../faturamentozanthus/faturamentozanthus';
import Zanthus from '../Zanthus/Zanthus'
import modelFaturamentozanthus_Ctrl from '../../model/modelfaturamentozanthusctrl';




export default class integrateZanthusCtrl {
    public static async start(filter: ifilter_faturamento): Promise<Array<modelFaturamentozanthus_Ctrl>> {
        try {
                    myTools.pagConsole("Integracao Zanthus CTRL - Start");
                    await this._ECF_Atualizar_Integracao(filter)
                    return await this._ECF_Obter_Pendentes(filter)
        } catch (e) {
            myTools.PagErrorException(`integrateZanthusCtrl`, `start`, e, false, "Atualização dos registros de Zanthus/Ctrl")
            throw new Error(`integrateZanthusCtrl - start - ${e}`)
        }
    }
    public static async _ECF_Atualizar_Integracao(filter: ifilter_faturamento) {
        try {

            // __ 06/09/2025 _ desabiliar acesso ao SQL Server __ 
            //await FaturamentoZanthus.Ctrl_List(await Zanthus.Ctrl_Get(filter, "ZANTHUSSQLSERVER"), true)
            
            
            await FaturamentoZanthus.Ctrl_List(await Zanthus.Ctrl_Get(filter, "ZANTHUSPOSTGRE"), true)

        } catch (e){
            await myTools.pagConsoleLog(`_ECF_Atualizar_Integracao \n ${e}`)
        }
    }

  
    public static async CtrlUpdatePagFaturamento (filter: ifilter_faturamento): Promise<void>{ 
        try {
                await FaturamentoZanthus.Ctrl_FaturamentoUpdate(filter)
                
        } catch(e) {
            await myTools.pagConsoleLog(`_ECF_Obter_Pendentes ${e}`)
        }
    }

    public static async _ECF_Obter_Pendentes(filter: ifilter_faturamento): Promise<Array<modelFaturamentozanthus_Ctrl>>{
        try {
                let list: Array<modelFaturamentozanthus_Ctrl> = await FaturamentoZanthus.Report_Ctrl_Get(filter)
                return Promise.resolve(list);
        } catch(e) {
            await myTools.pagConsoleLog(`_ECF_Obter_Pendentes ${e}`)
            return Promise.reject([])
        }
    }


}