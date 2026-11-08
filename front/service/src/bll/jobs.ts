import myTools from "../tools/Tools";
//import m0055_faturamento from "./m0055_faturamento";
const  PagApi = require("../../../Api")

const API = new PagApi(); 

async function jobs(sis_batch_service_cd: number) {
    
    myTools.pagConsoleLog("Lista de Batchs em Execução")
    try {
        if (sis_batch_service_cd == 1)
        {
            const resultado : Object = await API.m9030.ObterRunListPendente()
            for (const [Key, value] of Object.entries(resultado)) {
                
                let itembatch = value; 
                
                myTools.pagConsoleLog(`Seq: ${itembatch.sistema_batch_run.sis_batch_run_seq} - Batch: ${itembatch.sis_batch_cd}`, true)
                await jobsBatchExecutar(value)
            }
        }

        if (sis_batch_service_cd == 2)
        {
            await API.m0045.bluesoftintegrarprodutospendentes() 
            console.log("servico 2 executado")
        }

    }
    catch(e){
        throw new Error(`Job ${e}`)
    }
    finally {
        myTools.pagConsoleLog("Batchs finalizados")
    }
}


async function jobsBatchExecutar(itembatch: any) {

    try {
        itembatch = await API.m9030.executarRun(itembatch)

        if (itembatch !== undefined){
            
            switch (itembatch.sis_batch_cd) {
            case 55001: 
                    console.log(`Executando 55001`)
                    await API.m0055.faturamento_zanthus_integrate_pendente();
                    break; 
            case 45001: 
                console.log(`Executando 45001`)
                await API.m0045.bluesoftintegrarprodutospendentes() 
                break; 
            case 45002: 
                console.log(`Executando 45002`)
                await API.m0045.bluesoftintegrarprodutosall() 
                break; 
            }
    
        }
        itembatch = await API.m9030.FinalizarRun(itembatch)
    } catch(e) {
        await API.m9030.FinalizarRunError(itembatch)
        myTools.pagConsoleLog(`Batch - Execução com erro no batch Seq: ${itembatch.sistema_batch_run.sis_batch_run_seq} - Batch: ${itembatch.sis_batch_cd} \n ${e}`)
        
    }



}
export default jobs 