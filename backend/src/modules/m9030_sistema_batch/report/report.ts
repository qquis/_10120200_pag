

import myTools from "../../../tools/Tools";
import { clsBase, clsTools } from "../../../model/modelbase";
import {modelReport} from '../../../model/model'
import ifilter from '../interfaces'
import modelsistema_ServiceBatch from '../model/modelsistema_ServiceBatch';
import f9030_60_sistema_batch_runs_list from '../scriptpg/f9030_60_sistema_batch_runs_list';


import reportServiceList from "./report.ServiceList";






export default class reportSistemaBatch extends modelReport {



    public static async batchServiceList(parametro: any) : Promise <any[]> { 
        let result: any[] = []
        try { 
            result = await reportServiceList.get(parametro);
 

        } catch (e) {
            clsTools.PagErrorException(`reportSistemaBatch.batchServiceList`,`batchServiceList`, e);
        }

        finally { 
            return result;
        }
        
    }


    public static async filter_Get(request?: any, Pendentes : boolean = true, sis_batch_service_cd?: number ): Promise<ifilter> {
        try {

            let sis_batch_cd : number = 0 
            let sis_batch_run_status_cd : number = 0;
            let sis_batch_run_seq : number = 0; 

            if (Pendentes)
                sis_batch_run_status_cd = 10; 

            if (request)
            {
                sis_batch_cd = parseInt(`${request.body.sis_batch_cd}`)
                sis_batch_run_status_cd  = parseInt(`${request.body.sis_batch_run_status_cd}`)
                sis_batch_run_seq  = parseInt(`${request.body.sis_batch_run_seq}`)
            }
      
            let filter: ifilter = {
                    sis_batch_cd
                ,   sis_batch_run_status_cd  
                ,   sis_batch_run_seq 
                ,   sis_batch_service_cd
            }
            
            
            return filter 
            
        }
        catch (e) {
            throw Error(`Report | Filter_Get Error ${e}`)
        }
    
    }

    public static async SistemaBatchRunListPendentes(sis_batch_service_cd: number) : Promise<Array<modelsistema_ServiceBatch>> { 
        return await this.SistemaBatchRunList(await this.filter_Get(null, true, sis_batch_service_cd))
    }

    public static async SistemaBatchRunList (_filtro: ifilter): Promise<Array<modelsistema_ServiceBatch>> {

        let list: Array<modelsistema_ServiceBatch> = []
        try {
            let result = await super.Get(f9030_60_sistema_batch_runs_list.SELECT(_filtro))

            for (const [Key, value] of Object.entries(result)) {
                let i = new modelsistema_ServiceBatch(0); 
                await i.modelBinding(value)
                await list.push(i)
            }
            return list
        
        }catch (e) {
            myTools.pagConsoleLog(`Reports | SistemaBatchRunList \n ${e}`, true)
            return list; 
        }
        //return await  this.sistema_batch_processar(await super.Get(f9030_60_sistema_batch_runs_list.SELECT(await this.filter_Get(null, true, sis_batch_service_cd))))



    }   

    public static async ConsultarRegistroSisBath(sis_batch_run_seq: number): Promise<modelsistema_ServiceBatch> {
        let item: modelsistema_ServiceBatch = new modelsistema_ServiceBatch(0);
        try { 
                await item.modelConsultar(0, sis_batch_run_seq);
        } catch (e) {
            clsTools.PagErrorException(`M9020`, `Report | batchGet Error`, e)
        } finally {
            return item;
        }
    
    }

}



