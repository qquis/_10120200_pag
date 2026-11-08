
import 'dotenv/config'
import myTools from '../tools/Tools';
import DataBase from '../database/DataBase';
import modelsistema_ServiceBatch from '../modules/m9030_sistema_batch/model/modelsistema_ServiceBatch';
import { randomUUID } from 'crypto';
import { clsBase, clsTools } from "./modelbase";


//const myDataBase : DataBase = new DataBase();




export default class modelService_OLD {
    serviceContadorNumeroMaxUpdate: number
    serviceContadorNumeroLinhaAtual: number 
    serviceRegistroTotal: number
    serviceRegistroAtual: number

    serviceScriptUpdateAll: string 
    serviceSis_Batch_Run_Seq: number
    serviceModelSistem_Batch : modelsistema_ServiceBatch;

    serviceLogTAG: string 
    myDataBase : DataBase
    myDataBase_SERVER : string = "PAG"

    serviceLoguuidStart: string 


    constructor() {

 

        this.serviceRegistroTotal = 0;
        this.serviceRegistroAtual = 0;
        this.serviceContadorNumeroLinhaAtual = 0;
        this.serviceScriptUpdateAll = `` 
        this.serviceContadorNumeroMaxUpdate = 30;
        this.serviceSis_Batch_Run_Seq = 0;
        this.serviceModelSistem_Batch = new modelsistema_ServiceBatch(0)
        this.serviceLogTAG = `NOT_INFO`
        this.myDataBase = new DataBase();
        this.serviceLoguuidStart = `` 

        this.serviceLoguuidStart = myTools._datemomentDateToStr(new Date(), "yyyyMMDD_HH:MM:SS") + randomUUID().substring(0,12) 
    }


    public async _processPushContador() {
        this.serviceContadorNumeroLinhaAtual += 1;
        this.serviceRegistroAtual += 1;
    }

    public async _processPushScript(sqlScript : string) { 

        let statusReturnProcess : boolean = true; 
        try {

            this.serviceScriptUpdateAll += sqlScript
            await this._processPushContador();
            statusReturnProcess = await this._processCheck(); 


        } catch (e) {

            throw new Error(`${e}`)

        } finally {
            return statusReturnProcess
        }

    }

    public async _processCheck(ProcessFinish : boolean = false) : Promise<boolean> {
        
        let statusReturnProcess = true;

        
        try {
            if (this.serviceContadorNumeroLinhaAtual >= this.serviceContadorNumeroMaxUpdate && !ProcessFinish) {
                this.serviceContadorNumeroLinhaAtual = 0;
               

                // EXECUÇÃO NO BANCO DE DADOS */
                // ---------------------------------------------------
                await this.DataExecute();
                // Conferir BATCH caso tenha sido informado */
                // ---------------------------------------------------
                statusReturnProcess = await this._serviceBatchStatus()

                // Gerar log 
                await this._serviceLogRegister(`Atualização Bloco _ ${this.serviceRegistroAtual} / ${this.serviceRegistroTotal}`)
            } 

            if (ProcessFinish) {
                await this._processPushContador();
                await this.DataExecute();
            }
        } catch (e) {
            throw new Error(`${e}`)
        }
        finally {
            // Retornar status batch caso tenha sido informado ou positivo de modo geral
            // ---------------------------------------------------
            return  statusReturnProcess
        }
    }

    public async DataExecute(script : string = ``) {
        try {

            if (script !== ``) {
                this.serviceScriptUpdateAll = script;
            }

            if (this.serviceScriptUpdateAll !== ``) {
                if (this.myDataBase_SERVER == 'PAG' || this.myDataBase_SERVER == '')
                    await this.myDataBase.pag.Execute(this.serviceScriptUpdateAll)
                if (this.myDataBase_SERVER == 'ZANTHUSPOSTGRE')
                    await this.myDataBase.zanthusPostgre.Execute(this.serviceScriptUpdateAll)
                if (this.myDataBase_SERVER == 'ZANTHUSSQLSERVER')
                    await this.myDataBase.zanthusSQL.Execute(this.serviceScriptUpdateAll)
                this.serviceScriptUpdateAll = `` 
            }
        } catch (e) {
            throw new Error(`${e}`)
        }
    }

    public async DataGet(sqlScriptSelect : string) : Promise<object> {
        let mylistobject: object = {}
        try {
            if (this.myDataBase_SERVER == 'PAG')
                mylistobject = await this.myDataBase.pag.DataGet(sqlScriptSelect)
            if (this.myDataBase_SERVER == 'ZANTHUSPOSTGRE')
                mylistobject = await this.myDataBase.zanthusPostgre.DataGet(sqlScriptSelect)
            if (this.myDataBase_SERVER == 'ZANTHUSSQLSERVER')
                mylistobject = await this.myDataBase.zanthusSQL.DataGet(sqlScriptSelect)            
            
            return mylistobject;
        } catch (e) {
            throw new Error(`${e}`)
        }
    }

    public async _serviceBatchStatus() : Promise<boolean> {
        let sistembatchstatus : boolean = false;
        try {

            if (this.serviceSis_Batch_Run_Seq == 0) 
                sistembatchstatus = true; 
            else 
                sistembatchstatus = await this.serviceModelSistem_Batch.ModelStatus(this.serviceSis_Batch_Run_Seq)
        } catch (e) {
            throw new Error(`${e}`)
        }
        finally {
            if (!sistembatchstatus)
            {
                this._serviceLogRegister(`Processo Finazado - Status Batch inativo`)          
            }
            return sistembatchstatus
        }
    }
    
    public async _serviceLogRegister(sis_log_info: string, copy_to_log_file : boolean = false ) :Promise<void> { 
        try {
            await this._whaitLog()
            await this.serviceModelSistem_Batch.ModelRegistrarLog(this.serviceLogTAG, sis_log_info, this.serviceLoguuidStart, this.serviceSis_Batch_Run_Seq) 
            if (copy_to_log_file) {
                clsTools.pagConsole(`modelService | _serviceLogRegister \n 
                                    TAG: ${this.serviceLogTAG} \n 
                                    LOG: ${sis_log_info}
                                `)
            }
            
        } catch (e) {
                clsTools.PagErrorException(`modelService`, '_serviceLogRegister', e);
        }

    }

    private async _whaitLog() : Promise<void> {
        return new Promise(resolve => setTimeout(resolve, 10));
    }
}