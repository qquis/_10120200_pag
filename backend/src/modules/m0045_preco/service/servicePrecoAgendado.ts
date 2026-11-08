import modelsistema_ServiceBatch from "../../m9030_sistema_batch/model/modelsistema_ServiceBatch";
import modelprecoagendado from "../model/modelprecoagendado";
import myTools from "../../../tools/Tools";
import reportPreco from "../report/report";

const myReportPreco : reportPreco = new reportPreco();

export default class servicePrecoAgendado  {
    constructor()  {
        
    }
    async bluesoftIntegrar(sis_batch_run_seq: number) {
        return await this.BlueSoftIntegrar(await myReportPreco.PrecoAgendadoIntegracaoBlueSoftPendente() , sis_batch_run_seq)
    }

    private async BlueSoftIntegrar(mylist : object, sis_batch_run_seq: number) : Promise<Array<modelprecoagendado>> {

        try {

            let imodelsistema_batch: modelsistema_ServiceBatch = new modelsistema_ServiceBatch(0); 
            await imodelsistema_batch.modelConsultar(0, parseInt(`${sis_batch_run_seq}`))


            let list: Array<modelprecoagendado> = []
            try {
                for (const[key, value] of Object.entries(mylist)) {
                    let i = new modelprecoagendado(); 
                    await i.modelBindind(value); 
                    await list.push(i)
                }

                console.log(`Número de Itens processados: ${list.length}`)
    
                let icount : number = 0
                let for_count = 0; 
                let for_max_batch = 50; 
    
                for (const item of list) {
                    if (sis_batch_run_seq >= 0) {
    
                        icount++
                        for_count++
                        if (for_count >= for_max_batch) {
                            let status : boolean = await imodelsistema_batch.ModelStatus(parseInt(`${sis_batch_run_seq}`))
                            imodelsistema_batch.ModelRegistrarLog(`M0045_PRECO_${sis_batch_run_seq}`, `${icount}/${list.length}` )
    
                            if (!status) 
                            {
                                myTools.pagConsoleLog("MM45 PREÇO - Agendamento")
                                imodelsistema_batch.ModelRegistrarLog(`M0045_PRECO_${sis_batch_run_seq}`, `Sisbatch está inativo e portando a execução será encerrada`)
                                return list
                            }
                            for_count = 0;
                        }
                    }
                    //await console.log(`Atualizando o item ${item.pr_cdproduto} - ${item.pr_descricao} _ PREÇO PROMOCIONAL: ${item.prc_valor}`)
                    item.BlueSoftIntegrar()
                }

                return list; 
    
            } catch (e) {
                myTools.pagConsoleLog(`Reports | Error \n ${e}`)
                return list;
            }

        } catch (e) {

            throw new Error("BindingPrecosAplicados")
            
        }

    }
}