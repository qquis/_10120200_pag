
import { clsBase, clsTools } from "../../../model/modelbase";


import serviceForcaVendaMetaFabricanteProcessar from "./serviceForcaVendaMeta.Fabricante.Processar"
import serviceForcaVendaMetaProcessar from "./serviceForcaVendaMeta.Processar"
import reportSistema from "src/modules/m0001_sistema/report/report";


/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = true
    const FLG_MODULO : string = "ForcaVenda Meta ATUAL | serviceProcessarMetasAtuais.ts "
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    

export default class serviceProcessarMetasAtuais {
    static async start(parametro: any) : Promise<any> {
        try {
            

            let dadosOperacionais : any = await reportSistema.Operacional.getDefault();
            console.log(dadosOperacionais)



            if (!dadosOperacionais) {
                await this.__log(`Dados operacionais não encontrados para o Período/Competência atual`)
                return
            }

            

            if (dadosOperacionais.fv_fab_meta_cd) {
                await this.__log(`Processando os dados da Meta Fabricante: ${dadosOperacionais.fv_fab_meta_cd}`) 
                parametro.fv_fab_meta_cd = dadosOperacionais.fv_fab_meta_cd
                await serviceForcaVendaMetaFabricanteProcessar.start(parametro)    
            }

           
            if (dadosOperacionais.competencia_cd) {
                await this.__log(`Processando os dados Meta OXAN: ${dadosOperacionais.competencia_cd}`) 
                parametro.competencia_cd = dadosOperacionais.competencia_cd
                await serviceForcaVendaMetaProcessar.start(parametro)
            }


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

    private static async __log(message: string) : Promise<void> {
        await clsTools.pagConsole(` ${FLG_MODULO} - ${message}`, FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
    }
}