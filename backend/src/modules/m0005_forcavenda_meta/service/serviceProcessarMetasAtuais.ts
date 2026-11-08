
import { clsBase, clsTools } from "../../../model/modelbase";


import serviceForcaVendaMetaFabricanteProcessar from "./serviceForcaVendaMeta.Fabricante.Processar"
import serviceForcaVendaMetaProcessar from "./serviceForcaVendaMeta.Processar"


/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "ForcaVenda Meta ATUAL | serviceProcessarMetasAtuais.ts "
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    

export default class serviceProcessarMetasAtuais {
    static async start(parametro: any) : Promise<any> {
        try {
            

            await clsTools.pagConsole(` ${FLG_MODULO} - Processando Meta FABRICANTE (Obtendo o Seq da Meta FAB atual)`, FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
            let sql_max = `select max(fv_fab_meta_cd) as fv_fab_meta_cd from tbforca_venda_fab_meta`
            let result_max = await this.__db(sql_max)
            parametro.fv_fab_meta_cd = result_max[0]?.fv_fab_meta_cd || 0
            await clsTools.pagConsole(` ${FLG_MODULO} - Processando Meta FABRICANTE Sequência Obtida: ${parametro.fv_fab_meta_cd}`, FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
            await serviceForcaVendaMetaFabricanteProcessar.start(parametro)
            await clsTools.pagConsole(` ${FLG_MODULO} - Processando Meta FABRICANTE (Obtendo o Seq da Meta FAB atual) - Concluído`, FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)



            const dataAtual = new Date()
            const competencia_cd_atual: string =
                `${dataAtual.getFullYear()}${String(dataAtual.getMonth() + 1).padStart(2, "0")}`
            let parametroserviceForcaVendaMetaProcessar = parametro
                parametroserviceForcaVendaMetaProcessar.competencia_cd = competencia_cd_atual

            await clsTools.pagConsole(` ${FLG_MODULO} - Processando META FORÇA DE VENDA _ Competência: ${competencia_cd_atual} - Início`, FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
            await serviceForcaVendaMetaProcessar.start(parametroserviceForcaVendaMetaProcessar)
            await clsTools.pagConsole(` ${FLG_MODULO} - Processando META FORÇA DE VENDA _ Competência: ${competencia_cd_atual} - Concluído`, FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
            




        } catch (e) {
            console.error("Error in serviceProcessarMetasAtuais.start:", e);
        }



    }


    private static async __db(string_sql: string) : Promise<any> {
        try {
            let __db : clsBase = new clsBase()
            let result = __db.myDataBase.pag.DataGet(string_sql)
            return result
        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "__db (Service.if0017)", e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG)
        }
    }
}