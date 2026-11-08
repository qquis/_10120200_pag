/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - Service CARGA | PREPARACAO NA BASE PRIME/PAG "
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    




import 'dotenv/config'
import { clsBase, clsTools } from "../../../model/modelbase";





import f0085_50_zanthus_carga_decomposicao from "../scriptsPg/f0085_50_zanthus_carga_decomposicao";
import f0085_51_zanthus_carga_tributacao from "../scriptsPg/f0085_51_zanthus_carga_basetributaria";
import f0085_52_zanthus_carga_log from "../scriptsPg/f0085_52_zanthus_carga_log";
import f0085_53_zanthus_carga_regra_icms from "../scriptsPg/f0085_53_zanthus_carga_tabregra_icms";
import f0085_54_zanthus_carga_tabmercadoria from "../scriptsPg/f0085_54_zanthus_carga_mercadoria";
import f0085_55_zanthus_carga_preco_voucher from "../scriptsPg/f0085_55_zanthus_carga_preco_voucher";




export default class serviceZanthusAtualizacaoDadosPrepararBasePrime {
    static async  start(parametros: any = {}) : Promise<void> {
        try {
                /* CARGA ANTIGA */




                let myDATABASE : clsBase = new clsBase();

                //CARGA DECOMPOSIÇÃO
                await clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_50_zanthus_carga_decomposicao.sqlScript_VERSION()}`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG);
                await myDATABASE.myDataBase.pag.Execute(f0085_50_zanthus_carga_decomposicao.ScriptExecute())

                //CARGA TRIBUTAÇÃO
                await clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_51_zanthus_carga_tributacao.sqlScript_VERSION()}`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG);
                await myDATABASE.myDataBase.pag.Execute(f0085_51_zanthus_carga_tributacao.ScriptExecute())

                //CARGA LOG
                await clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_52_zanthus_carga_log.sqlScript_VERSION()}`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG);
                await myDATABASE.myDataBase.pag.Execute(f0085_52_zanthus_carga_log.ScriptExecute())

                //CARGA REGRA ICMS
                await clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_53_zanthus_carga_regra_icms.sqlScript_VERSION()}`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG);
                await myDATABASE.myDataBase.pag.Execute(f0085_53_zanthus_carga_regra_icms.ScriptExecute())

                //CARGA TAB MERCADORIA
                await clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_54_zanthus_carga_tabmercadoria.sqlScript_VERSION()}`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG);
                await myDATABASE.myDataBase.pag.Execute(f0085_54_zanthus_carga_tabmercadoria.ScriptExecute())
                
                /*  DADOS BASICOS (Padrão FALSE)
                    Não sendo atualização de dados básicos será atualizado preços também.
                */
                if (!parametros.AtualizacaDadosBasicos || parametros.AtualizacaDadosBasicos === false) {
                    //CARGA PREÇO VOUCHER
                    await clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_55_zanthus_carga_preco_voucher.sqlScript_VERSION()}`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG);
                    await myDATABASE.myDataBase.pag.Execute(f0085_55_zanthus_carga_preco_voucher.ScriptExecute())
                }
     
        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'start', e);
            throw new Error( `F0085 | zanthusService Metodo: start() ${e}`)
        }

    }


}