import tbprecoaplicacao from "../tbs/tbprecoaplicacao"
import myTools from "../../../tools/Tools";
import modelprecoaplicacao from "../model/modelprecoaplicacao";
import modelsistema_ServiceBatch from "../../m9030_sistema_batch/model/modelsistema_ServiceBatch";
import reportPreco from "../report/report";

const myReportPreco : reportPreco = new reportPreco();


export default class servicePrecoAplicacao  {
    constructor() {
        
    }
    async bluesoftIntegrarPrecosPendentes(sis_batch_run_seq: number) : Promise<Array<modelprecoaplicacao>>  {
        return await this.BlueSoftIntegrarPrecos(await myReportPreco.PrecosAplicadosIntegracaoBlueSoftPendente(), sis_batch_run_seq)
    }
    async bluesoftIntegrarPrecos(sis_batch_run_seq: number) {
        return await this.BlueSoftIntegrarPrecos(await myReportPreco.PrecosAplicadosIntegracaoBlueSoftPendente(), sis_batch_run_seq)
    }

    private async BlueSoftIntegrarPrecos(mylist : object, sis_batch_run_seq: number) : Promise<Array<modelprecoaplicacao>> {

        try {

            let imodelsistema_batch: modelsistema_ServiceBatch = new modelsistema_ServiceBatch(0); 
            await imodelsistema_batch.modelConsultar(0, parseInt(`${sis_batch_run_seq}`))


            let list: Array<modelprecoaplicacao> = []
            try {
                for (const[key, value] of Object.entries(mylist)) {
                    let i = new modelprecoaplicacao(0); 
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
                                myTools.pagConsoleLog("M0045_PRECO - Sisbatch está inativo e portando a execução será encerrada")
                                imodelsistema_batch.ModelRegistrarLog(`M0045_PRECO_${sis_batch_run_seq}`, `Sisbatch está inativo e portando a execução será encerrada`)
                                return list
                            }
                            for_count = 0;
                        }
                    }
                    await console.log(`Atualizando o item ${item.pr_cdproduto} - ${item.pr_descricao}`)
                    //await item.modelBlueSoftAtualizar()
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