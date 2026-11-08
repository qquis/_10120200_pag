import { clsTools } from '../../../model/modelbase';




/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = true
    const FLG_MODULO : string = "Faturamento | serviceFaturamento.ts "
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    


import serviceFaturamentoBluesoftProcessar from "./serviceFaturamentoBluesoftProcessar";
import serviceFaturamentoContratoProcessarApurar from "./serviceFaturamentoContratoProcessarApurar";

import serviceForcaVendaMeta from "../../m0005_forcavenda_meta/service/service";

export default class serviceFaturamento {
    static faturamentoBluesoft = serviceFaturamentoBluesoftProcessar; 
    static faturamentoContratoService = serviceFaturamentoContratoProcessarApurar;


    static async FaturamentoProcessar(parametro: any) : Promise<void> {
       try { 
              
        
        
              await clsTools.pagConsole(` ${FLG_MODULO} - Iniciando processamento do faturamento`, FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
              await serviceFaturamentoBluesoftProcessar.start(parametro);
              

              
              

              /** Contratos Processar **/
              await clsTools.pagConsole(` ${FLG_MODULO} - Processamento CONTRATOS`, FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
              parametro.faturamento_controle_seq = 0
              parametro.contrato_seq = 0
              parametro.competencia_cd = Number(parametro.data_processamento.replace(/-/g, '').slice(0, 6))
              parametro.data_val_ini = clsTools._datemomentDatStrToDate(parametro.data_processamento, "YYYY-MM-DD")
              parametro.data_val_fim = clsTools._datemomentDatStrToDate(parametro.data_processamento, "YYYY-MM-DD")
              await serviceFaturamentoContratoProcessarApurar.start(parametro);

              


              /** Processamento META FORÇA DE VENDA **/
              await clsTools.pagConsole(` ${FLG_MODULO} - Processamento META FORÇA DE VENDA (FABRICANTE E DO FORÇA INTERNO)`, FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
              await serviceForcaVendaMeta.metasAtuais.start(parametro);
              




              await clsTools.pagConsole(` ${FLG_MODULO} - Processamento do faturamento concluído`, FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)

       } catch (e) {
           await clsTools.PagErrorException(FLG_MODULO, "FaturamentoProcessar", e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);
       }
    }
}
