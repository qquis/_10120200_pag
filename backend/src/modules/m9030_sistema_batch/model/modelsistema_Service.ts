import { Request, Response } from 'express';
import { clsBase, clsTools } from "../../../model/modelbase";

import tbsistema_batch_service from '../tbs/tbsistema_batch_service';
import tbsistema_batch_service_run from '../tbs/tbsistema_batch_service_run';
import modelsistema_ServiceBatch from './modelsistema_ServiceBatch';


import f9030_50_sistema_batch_service_processar from '../scriptpg/f9030_50_sistema_batch_service_processar';


/*Reutilização de Reports */
import reportServiceList from '../report/report.ServiceList';
import reportServiceBathList from '../report/report.ServiceBathList';

import reportSistemaBatch from '../report/report';





const myClsBase = new clsBase();

import f9030_05_sistema_batch_service_run_processar from '../scriptpg/f9030_05_sistema_batch_service_run_processar';


class modelsistema_Service extends tbsistema_batch_service {


  
    item_batch_service_run: tbsistema_batch_service_run 
    item_model_sistema_batch : modelsistema_ServiceBatch[]
    


    constructor(sis_batch_service_cd : number) 
    {
        super(sis_batch_service_cd)
        this.item_batch_service_run = new tbsistema_batch_service_run(0);
        this.item_model_sistema_batch = []; 
    }

     /* Data Query Any
    ----------------------------------------------------------------------------------------------------------------------
    ----------------------------------------------------------------------------------------------------------------------
    ----------------------------------------------------------------------------------------------------------------------
    ----------------------------------------------------------------------------------------------------------------------
    ----------------------------------------------------------------------------------------------------------------------
    ----------------------------------------------------------------------------------------------------------------------
    ----------------------------------------------------------------------------------------------------------------------
    --------------------------------------------------------------------------------------------------------------------*/
    

    public async GetDataQueyAny (parametros: any) : Promise<any> {
        let ItemAny : any = {}
    
        try { 
            const modeldb = new clsBase(); 
            let resultQuery = await reportServiceList.get({sis_batch_service_cd: parametros.sis_batch_service_cd});
            


            if (resultQuery !== undefined) {

                ItemAny = resultQuery[0]

                if (ItemAny) {
                    let itemAnyListBatchs = await this.GetDataQueryAny_Batchs();
                    if (itemAnyListBatchs !== undefined) {
                        ItemAny.batchs = itemAnyListBatchs;
                    }
                }
        

            }
            

        } catch (e) {
              clsTools.PagErrorException(`modelsistema_batch_service.GetDataQueyAny`,`GetDataQueyAny`, e);
 
        } finally { 
                return ItemAny;
        }

    }

    

    public async GetDataQueryAny_Batchs() : Promise<any> {
        let itemAnyListBatchs : any = {}
    
        try {   
            itemAnyListBatchs = await reportServiceBathList.get({sis_batch_service_cd: this.sis_batch_service_cd});


        }
        catch (e) {
              clsTools.PagErrorException(`modelsistema_batch_service.GetDataQueryAny_Batchs`,`GetDataQueryAny_Batchs`, e);
 
        } finally { 
                return itemAnyListBatchs;
        }

    }







    /* Funções de Atendimento 
    ----------------------------------------------------------------------------------------------------------------------
    ----------------------------------------------------------------------------------------------------------------------
    ----------------------------------------------------------------------------------------------------------------------
    ----------------------------------------------------------------------------------------------------------------------
    ----------------------------------------------------------------------------------------------------------------------
    ----------------------------------------------------------------------------------------------------------------------
    ----------------------------------------------------------------------------------------------------------------------
    --------------------------------------------------------------------------------------------------------------------*/

    public async modelBindingRequest(item: Request)
    {
        try {

            if (item !== undefined)
            {
                                                                                                                
                //console.log(`Código do Serviço ${item.query.sis_batch_service_cd} Shedule indicado ${item.query.sis_batch_service_run_status_shedule}`)
                
                this.sis_batch_service_cd = parseInt(`${item.query.sis_batch_service_cd}`)
                this.sis_batch_service_ult_run_host = `localhost`
                this.item_batch_service_run.sis_batch_service_cd = this.sis_batch_service_cd
               
                if (item.query.sis_batch_service_run_status_shedule !== undefined) {
                    this.item_batch_service_run.sis_batch_service_run_status_shedule = parseInt(`${item.query.sis_batch_service_run_status_shedule}`) 
                }

            }
        } catch(e) {
            clsTools.PagErrorException(`modelsistema_batch_service.modelBindingRequest`,`modelBindingRequest`, e);
        }
    }


    public async obterSistemaBatchListPendentes(sis_batch_service_cd: number) : Promise<Array<modelsistema_ServiceBatch>> {
        let listaSistemaBatch : modelsistema_ServiceBatch[] = []
        try {
            listaSistemaBatch =  await reportSistemaBatch.SistemaBatchRunListPendentes(sis_batch_service_cd); 
        } catch (e) {
            clsTools.PagErrorException(`modelsistema_batch_service.obterSistemaBatchListPendentes`,`obterSistemaBatchListPendentes`, e);
        }
        finally {
            return listaSistemaBatch;
        }
    }


    public async modelProcessarBatch() {
        try {
            if (this.sis_batch_service_cd == 0) 
                 throw Error(`Código do Batch Serviço não especificado`); 
            let scriptExecutarBatchServiceRun = 
                      this._Db_Pg_script_Update() 
                    + this.item_batch_service_run._Db_Pg_script_Insert() 
            await this._Db_Pg_DataPost(scriptExecutarBatchServiceRun); 

            await myClsBase.myDataBase.pag.Execute(f9030_50_sistema_batch_service_processar.SELECT(parseInt(`${this.sis_batch_service_cd}`)))
                    


         } catch (e) {
             clsTools.PagErrorException(`modelsistema_batch_service.modelProcessarBatch`,`modelProcessarBatch`, e);
         }
    }


}

export default modelsistema_Service