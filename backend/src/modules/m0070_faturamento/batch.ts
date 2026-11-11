import { clsTools } from '../../model/modelbase';

import reportSistema from '../m0001_sistema/report/report';

import serviceFaturamentoBluesoftProcessar from "./service/serviceFaturamentoBluesoftProcessar";
import serviceFaturamentoContratoProcessarApurar from "./service/serviceFaturamentoContratoProcessarApurar";


/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = true
    const FLG_MODULO : string = "M0070-FATURAMENTO __ batch_module_m0070 PROCEDIMENTOS __ | Faturamento "
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    



export default class batch_module_m0070 { 
    
    static async Procedimento(nucleo_procedimento: any) : Promise<boolean> {
        try {
            await this.AtualizacaoDiaria();
            return true;
        } catch (e) {
            return false;
        }
        finally {
            return true
        }
    }

    static async AtualizacaoDiaria() : Promise<boolean> {
        try {


            this.__log("Coletando os dados do processamento atual tbsistema_operacional sis_operacional_default = 1 ")

            let DadosProcessamento : any = await reportSistema.Operacional.getDefault();
            

            const _hoje = clsTools._datemomentDateToStr(new Date(), "YYYY-MM-DD");
            

            const dataLimite = DadosProcessamento.faturamento_data_limite;

            if (_hoje > dataLimite) {
                await this.__log(`Data limite de faturamento ultrapassada: ${dataLimite}`);
            } else { 
                await this.__log(`Data limite de faturamento ainda não atingida - O Processamento será realizado: ${dataLimite}`);
            }


            let dataInicial = clsTools._datemomentDatStrToDate(DadosProcessamento.data_competencia_ini, "YYYY-MM-DD");
            const dataFinal = clsTools._datemomentDatStrToDate(DadosProcessamento.data_competencia_fim, "YYYY-MM-DD");

            const faturamento_numero_dias_qtde = DadosProcessamento.faturamento_numero_dias_qtde || 0;

            // Calcula a diferença em dias (milissegundos convertidos para dias)
            const diffTime = dataFinal.getTime() - dataInicial.getTime();
            const diffDays = diffTime / (1000 * 60 * 60 * 24);

            // Se a distância for menor que a quantidade de dias exigida
            if (diffDays < faturamento_numero_dias_qtde) {
                dataInicial = new Date(dataFinal);
                dataInicial.setDate(dataInicial.getDate() - faturamento_numero_dias_qtde);
            }


            await this.__log(`Processamento iniciado para o período de ${clsTools._datemomentDateToStr(dataInicial, "YYYY-MM-DD")} até ${clsTools._datemomentDateToStr(dataFinal, "YYYY-MM-DD")}`);


            if (Number.isNaN(dataInicial.getTime()) || Number.isNaN(dataFinal.getTime()) || dataInicial > dataFinal) {
                await this.__log("Período de processamento inválido.");
                return false;
            }

            for (let data = new Date(dataInicial); data <= dataFinal; data.setUTCDate(data.getUTCDate() + 1)) {
                
                const dataProcessamento = clsTools._datemomentDateToStr(data, "YYYY-MM-DD");

                if (dataProcessamento >= _hoje) {
                    await this.__log(
                        `Data de processamento ${dataProcessamento} é maior ou igual a hoje ${_hoje}`
                    );
                    break;
                }

                const dataprocessamento = clsTools._datemomentDateToStr(data, "YYYY-MM-DD");
                const parametro: any = { data_processamento: dataprocessamento };
                await this.__log(`Processando a data: ${dataprocessamento}`);
                await serviceFaturamentoBluesoftProcessar.start(parametro);
                await this.__log(`Processando concluído para a data: ${dataprocessamento}`);

                
            }


            await this.__log(`Iniciando processamento do faturamento contrato para a competência ${DadosProcessamento.competencia_cd}`);

                let dadosContrato = { 
                        op_cdoperacao: 4
                    ,   dataFaturamento_filter: 1
                    ,   faturamento_controle_seq: 0
                    ,   competencia_cd: DadosProcessamento.competencia_cd
                    ,   contrato_seq: 0
                    ,   data_val_ini: clsTools._datemomentDatStrToDate(DadosProcessamento.data_competencia_ini, "YYYY-MM-DD")
                    ,   data_val_fim: clsTools._datemomentDatStrToDate(DadosProcessamento.data_competencia_fim, "YYYY-MM-DD")
                }
                    
  
                await serviceFaturamentoContratoProcessarApurar.start(dadosContrato);

                return true 

                
        } catch (e) {
            return false;
        }
    }   

    private static async __log(message: string) {
        await clsTools.pagConsole(message, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG, FLG_MODULO);
    }
}