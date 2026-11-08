import { clsTools, clsBase } from '../../../model/modelbase';


/*Imports*/

import scriptdbEstatistica from '../scriptdb/scriptdbEstatistica';
import serviceSistemaLog from "../../m9020_sistema_log/service/service.SistemaLog";


/*Codigos de Procedimentos utilizados*/
const SIS_NUCLEO_PRC_CD_ATUALIZAR_ESTATISTICA = 10150010





export default class serviceEstatisticaFaturamentoProcessar { 

    static async start(parametro: any) { 
        try {
            let myDataBase : clsBase = new clsBase();
            const result = await myDataBase.myDataBase.pag.Execute(scriptdbEstatistica.f0150_01_estatistica_processamento.get(parametro));
        } catch (e) {
            clsTools.PagErrorException("serviceEstatisticaFaturamentoProcessar", "start", e);
        }
    }

    static async onLineExec() { 
        try { 

                let dataHoje = new Date();
                await this.start({dataFaturamento_ini: dataHoje, dataFaturamento_fim: dataHoje, vprocessamento_parcial: 1});

        } catch (e) {
            clsTools.PagErrorException("serviceEstatisticaFaturamentoProcessar", "onLineExec", e);
        }
    }

    static async dailyExec() { 
        try { 
            let dataInicial = clsTools._datemomentSubtractDays(new Date(), 45)
            let dataFinal = new Date();

            if(!await serviceSistemaLog.Registrar.LogNucleoProcedimentoToday(SIS_NUCLEO_PRC_CD_ATUALIZAR_ESTATISTICA)) {
                await this.start({dataFaturamento_ini: dataInicial, dataFaturamento_fim: dataFinal, vprocessamento_parcial: 0});
            }

            
        } catch (e) {
            clsTools.PagErrorException("serviceEstatisticaFaturamentoProcessar", "dailyExec", e);
        }
    }
    
}