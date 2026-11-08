/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ ZEUSRETAIL.CARGAOXAN() (JS ServiceAtualizacao.tabMercadoria)"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
    const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE : string = ``
/*  ____________________________________________________________________________________________*/    




import { clsBase, clsTools } from "../../../model/modelbase";
import script from "../scriptsPg/script"

export default class serviceAtualizacaoDadosZeusRetailCargaOxan {
    static async start(parametros: any = {}) : Promise<void> {
        try {
            
            let myData : clsBase = new clsBase()
            
            await clsTools.pagConsole(`${FLG_MODULO} - Iniciando o processamento de Voucher Promocional`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            let data_hoje : Date = new Date()
            let cod_voucher : string = clsTools._datemomentDateToStr(data_hoje,  "YYYYMMDD")
            parametros.cod_voucher = cod_voucher
            await myData.myDataBase.zanthusPostgre.Execute(script.zeusRetailCargaOxan.ScriptExecute())
            
        }
        catch (e) {
            await clsTools.PagErrorException(`${FLG_MODULO}`, 'start', e, false, "CARGA NEW 2026 - ZEUSRETAIL.CARGAOXAN()", FLG_DEBUG_FILE_CONSOLE_LOG);
        }
    }


}

