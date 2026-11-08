import { clsBase, clsTools } from "../../../model/modelbase";


/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = true
    const FLG_MODULO : string = "M0050 FaturamentoBluesoft (service.FaturamentoBluesoft.Import.RedShift) |"
    const FLG_DEBUG_CONSOLE_NOPRINT : boolean = false
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    



import serviceSistemaLog from "../../m9020_sistema_log/service/service.SistemaLog";


import reportFaturamentoBluesoftRedshiftList from "../report/report.faturamentoBluesoft.RedShift";
import reportFaturamentoBluesoftRedshiftItemList from "../report/report.faturamentoBluesoft.RedShift.item";
import tbfaturamento_bluesoft from "../tbs/tbfaturamento_bluesoft";
import tbfaturamento_bluesoft_item from "../tbs/tbfaturamento_bluesoft_item";


const SIS_NUCLEO_PRC_CD = 10050011
const myBase = new clsBase();


export default class serviceFaturamentoBluesoftImportRedShift {
   
    static async start(parametros: any = {}) { 
        await this.fromRedShift(parametros);

    }



    static async fromRedShift(parametro: any = {}) { 
        let messageLogNucleoProcedimento = `FaturamentoBluesoft - Importação Redshift ${clsTools._datemomentDateToStr(new Date(), "YYYY-MM-DD HH:mm:ss")}` 
        try {
            let i = 0; 
            let imax = 50;
            let sql = ``


            let ProcedimentoExecutadoHoje : boolean = await serviceSistemaLog.Registrar.LogNucleoProcedimentoToday(SIS_NUCLEO_PRC_CD);

            
            
            if (ProcedimentoExecutadoHoje)
                if ( ProcedimentoExecutadoHoje && parametro.executeoverwrite && parametro.executeoverwrite == "1") {
                    await this.__log("Importação de Venda Bluesoft - RedShift já executada hoje. Mas será executada novamente");
                    messageLogNucleoProcedimento = `FaturamentoBluesoft - Importação Redshift - Reexecutado ${clsTools._datemomentDateToStr(new Date(), "YYYY-MM-DD HH:mm:ss")}`
                }
                else { 
                    await this.__log("Importação de Venda Bluesoft - RedShift já executada hoje. Parametro Overwrite não definido ou diferente de 1. Execução cancelada");
                    messageLogNucleoProcedimento += " - Já executado hoje. Execução cancelada"
                    return
                }
             else { 
                await this.__log("Importação de Venda Bluesoft - RedShift será executado pela primeira vez hoje");
                messageLogNucleoProcedimento += " - Executado pela primeira vez hoje"
            }



            let dataInicial = clsTools._datemomentDatStrToDate(`${parametro.dataInicial}`, `YYYY-MM-DD`)
            let dataFinal = clsTools._datemomentDatStrToDate(`${parametro.dataFinal}`, `YYYY-MM-DD`)

            await this.__log("Iniciando importação do faturamento bluesoft - RedShift")


            
            let resultadoFaturamento = await reportFaturamentoBluesoftRedshiftList.get({tipo_Relatorio: "FATURAMENTO_BLUESOFT", dataProcessamentoIni: dataInicial, dataProcessamentoFim: dataFinal});
            if (!resultadoFaturamento || resultadoFaturamento.length === 0) {
                await this.__log("Nenhum registro de faturamento encontrado no RedShift");
                return;
            }
            
            await this.__log("Importação do faturamento bluesoft - RedShift: " + resultadoFaturamento.length + " registros encontrados")
            for await (const item of resultadoFaturamento as any[]) {
                let itemModel = new tbfaturamento_bluesoft
                await itemModel.binding(item)
                
                sql += await itemModel.ScriptFaturamentoBluesoft_RedSfhit() 
                i++;
                if (i >= imax) {
                    await myBase.myDataBase.pag.Execute(sql);
                    i = 0;
                    sql = ``;
                }
            }
            if (sql) {
                await myBase.myDataBase.pag.Execute(sql);
            }


            i = 0; 
            imax = 60;
            sql = ``
            await this.__log("Iniciando importação do faturamento bluesoft - Itens - RedShift")

            let resultFaturamentoBluesoftItem = await reportFaturamentoBluesoftRedshiftItemList.get(
                {       tipo_Relatorio: "FATURAMENTOBLUESOFT_ITEM"
                    ,   dataProcessamentoIni: dataInicial
                    ,   dataProcessamentoFim: dataFinal});


            await this.__log("Importação do faturamento bluesoft - Itens - RedShift: " + resultFaturamentoBluesoftItem.length + " registros encontrados")
            for await (const item of resultFaturamentoBluesoftItem as any[]) {
                let itemModel = new tbfaturamento_bluesoft_item();
                await itemModel.binding(item)
                sql += await itemModel.ScriptFaturamentoBluesoft_Insert();
                sql += await itemModel.scriptFaturamentoBlueSoft_Update();
                i ++;
                if (i >= imax) {
                    await myBase.myDataBase.pag.Execute(sql);
                    i = 0;
                    sql = ``;
                }
            }
            if (sql) {
                await myBase.myDataBase.pag.Execute(sql);
            }
            messageLogNucleoProcedimento += " - Executado com Sucesso"



        } catch (e) {
            messageLogNucleoProcedimento += ` - Erro: ${e}`
            console.log("-----------------")
            console.log(e)
            console.log("-----------------")
            clsTools.PagErrorException("serviceFaturamentoBluesoftImport", "start", e);
        }

        finally {
            await serviceSistemaLog.Registrar.submit({
                sis_nucleo_prc_cd: SIS_NUCLEO_PRC_CD,
                sis_log_tag: "FAT_BLUE_IMP_REDSHIFT",
                sis_log_info: messageLogNucleoProcedimento,
                sis_batch_run_seq: 0,
                proc_log_seq: 0,
                sis_log_seq: 0,
                uuid_start: "",
                uuid: ""

            })
        }
    }


    static async __log(message: string) {
        await clsTools.pagConsole(message, FLG_DEBUG_CONSOLE_LOG, FLG_DEBUG_CONSOLE_NOPRINT, FLG_DEBUG_FILE_CONSOLE_LOG, FLG_MODULO);
    }

}