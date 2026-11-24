import { clsBase, clsTools } from "../../../model/modelbase";


const FLG_INFO : any = clsTools.pagLogSet(
    {       SISTEMA_NUCLEO_PRC_CD: 0
        ,   FLG_DEBUG_CONSOLE_LOG: true
        ,   FLG_MODULO: "M0071_INTERFACE MTRIX "
        ,   FLG_DEBUG_FILE_CONSOLE_LOG: ``
})


export default class modelInterfaceMTRIX {
    static get(parametros: any) {

    }

    private static __log(message: string)
    {
        if (FLG_INFO.FLG_DEBUG_CONSOLE_LOG) {
            clsTools.pagLogInfo(message, FLG_INFO);
        }
    }

    private static __logError(ex: any)
    {
        if (FLG_INFO.FLG_DEBUG_CONSOLE_LOG) {
            clsTools.PagErrorException(FLG_INFO.FLG_MODULO, "MTRIX", ex,false,"", FLG_INFO.FLG_DEBUG_CONSOLE_LOG)
        }
    }
}