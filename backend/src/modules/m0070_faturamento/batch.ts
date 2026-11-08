import { clsTools } from '../../model/modelbase';



import serviceFaturamentoBluesoftProcessar from "./service/serviceFaturamentoBluesoftProcessar";
import serviceFaturamentoContratoProcessarApurar from "./service/serviceFaturamentoContratoProcessarApurar";


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

            const fmt = (d: Date) => `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, "0")}-${String(d.getDate()).padStart(2, "0")}`;

                const hoje = new Date();

                for (let i = -4; i <= -1; i++) {

                    let parametro: any = {};
                    

                    const d = new Date(hoje);
                    d.setDate(d.getDate() + i);

                    
                    const dataprocessamento = fmt(d);


                    parametro.data_processamento = dataprocessamento;


                    await serviceFaturamentoBluesoftProcessar.start(parametro);


                    
                    await clsTools.pagConsole(`Processando faturamento contrato para data: ${dataprocessamento}`, true, false, ``);
                    parametro.op_cdoperacao = 4
                    parametro.dataFaturamento_filter=1
                    parametro.faturamento_controle_seq = 0
                    parametro.contrato_seq = 0
                    parametro.data_val_ini = clsTools._datemomentDatStrToDate(parametro.data_processamento, "YYYY-MM-DD")
                    parametro.data_val_fim = clsTools._datemomentDatStrToDate(parametro.data_processamento, "YYYY-MM-DD")
                    await serviceFaturamentoContratoProcessarApurar.start(parametro);
                    
                
                }
            

            return true;
        } catch (e) {
            return false;
        }
    }   

}