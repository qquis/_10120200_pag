import { Request } from 'express';
import myTools from "../../../tools/Tools";
import { clsBase, clsTools } from "../../../model/modelbase";


let myClsBase = new clsBase();

import modelsistema_log from '../../m9020_sistema_log/model/modelsistema_log';

/*TABELAS */
import tbsistema_batch from '../tbs/tbsistema_batch';
import tbsistema_batch_time from '../tbs/tbsistema_batch_time';
import tbsistema_batch_run from '../tbs/tbsistema_batch_run';
import modelsistema_nucleo_procedimento from './modelsistema_nucleo_procedimento';

/*Reutilização de reportes */
import reportServiceBathList from '../report/report.ServiceBathList';
import reportServiceBathTimeList from '../report/report.ServiceBathTimeLIst';

enum enumSistema_Batch_Run_Status {
        Inicializado = 10
    ,   EmProcessamento = 20 
    ,   FinalizadoComSucesso = 30 
    ,   FinalizadoComERRO = 99
    ,   FinalizadoManualmente = 90
}

export default class modelsistema_ServiceBatch  {

    sistema_batch: tbsistema_batch
    sistema_batch_time: tbsistema_batch_time
    sistema_batch_run: tbsistema_batch_run
    listProcedimentos: modelsistema_nucleo_procedimento[] = []


    constructor(sis_batch_cd : number) 
    {
        //super(sis_batch_cd)
        this.sistema_batch = new tbsistema_batch(sis_batch_cd)
        this.sistema_batch_time = new tbsistema_batch_time(0)
        this.sistema_batch_run = new tbsistema_batch_run(0)

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
    

    public async GetDataQueyAny() : Promise<any> {
        let ItemAny : any = {}
    
        try { 

            let listBatch = await reportServiceBathList.get({sis_batch_cd: this.sistema_batch.sis_batch_cd});
            if (listBatch !== undefined) {
                ItemAny = listBatch[0]

                let listTime = await this.GetDataQueryAny_BatchsTimes();
                if (listTime !== undefined) {
                    ItemAny.times = listTime
                }
                
            }

            
        } catch (e) { 
            clsTools.PagErrorException(`modelsistema_ServiceBatch.GetDataQueyAny`,`GetDataQueyAny`, e);
        } finally { 
                return ItemAny;
        }

    }


    public async GetDataQueryAny_BatchsTimes() : Promise<any> {

        let ItemAnyList : any

        try {
            let listBatchTimes = await reportServiceBathTimeList.get({sis_batch_cd: this.sistema_batch.sis_batch_cd});
            if (listBatchTimes !== undefined) {
                ItemAnyList = listBatchTimes
                
            }   
        } catch (e) {
            clsTools.PagErrorException(`modelsistema_ServiceBatch.GetDataQueryAny_BatchsTimes`,`GetDataQueryAny_BatchsTimes`, e);
        } finally {
            return ItemAnyList;
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

    public async modelBinding(item : any) {
        if (item !== undefined) {
            //super.binding(item);
            //this.sis_batch_cd = item.sis_batch_cd; 
            //this.sis_batch_descricao = item.sis_batch_descricao;

            this.sistema_batch.binding(item);
            this.sistema_batch.sis_batch_cd = item.sis_batch_cd; 
            this.sistema_batch.sis_batch_descricao = item.sis_batch_descricao;


            this.sistema_batch_run.binding(item); 


            this.sistema_batch_time.sis_batch_cd = item.sis_batch_cd;
            this.sistema_batch_time.sis_batch_dt_ini = myTools.pagDateTime_getDate(item.sis_batch_dt_ini?item.sis_batch_dt_ini:'1900-01-01')
            this.sistema_batch_time.sis_batch_dt_fim = myTools.pagDateTime_getDate(item.sis_batch_dt_fim?item.sis_batch_dt_fim:'1900-01-01')
            this.sistema_batch_time.sis_batch_hm_ini = item.sis_batch_hm_ini?"00:00":item.sis_batch_hm_ini
            this.sistema_batch_time.sis_batch_hm_fim = item.sis_batch_hm_ini?"00:00":item.sis_batch_hm_fim
            this.sistema_batch_time.sis_batch_recorrencia_cd = item.sis_batch_recorrencia_cd?0:item.sis_batch_recorrencia_cd
            this.sistema_batch_time.sis_batch_wk_ini = item.sis_batch_wk_ini?item.sis_batch_wk_ini:0
            this.sistema_batch_time.sis_batch_wk_fim = item.sis_batch_wk_fim?item.sis_batch_wk_fim:0
            this.sistema_batch_time.notificacao_cd = item?.notificacao_cd
            this.sistema_batch_time.sis_batch_time_seq = item?.sis_batch_time_seq
            
            //this.module_cd = item?.module_cd;
            this.sistema_batch.module_cd = item?.module_cd;
        }
    }

    public async modelBindingRequest(item: Request)
    {
        try {
            if (item !== undefined)
            {
                let mySis_batch_run_seq : number = parseInt(`${item.query.sis_batch_run_seq}`) 
                this.sistema_batch_run.sis_batch_run_seq = mySis_batch_run_seq 
                await this.sistema_batch_run.__Consultar() 
                
                //this.sis_batch_cd = this.sistema_batch_run.sis_batch_cd
                this.sistema_batch.sis_batch_cd = this.sistema_batch_run.sis_batch_cd
                

            }
        } catch(e) {
            clsTools.pagConsole(`ERROR modelsistema_batch_run.modelBindingRequest Seq. ${this.sistema_batch_run.sis_batch_run_seq} | Batch Run NÃO está com STATUS = 10 para ser executado (status = 20)`, true)
        }
    }

    public async modelConsultar(__sis_batch_cd: number, __sis_batch_run_seq: number) {
        try {
                let sqlstring = `
                        SELECT      b.sis_batch_cd 
                                ,   b.sis_batch_descricao
                                ,   b.sis_batch_status 
                                ,   b.sis_batch_service_cd 
                                ,   t.sis_batch_cd
                                ,   t.sis_batch_recorrencia_cd
                                ,   t.sis_batch_dt_ini
                                ,   t.sis_batch_dt_fim 
                                ,   t.sis_batch_hm_ini
                                ,   t.sis_batch_hm_fim
                                ,   t.sis_batch_wk_ini
                                ,   t.sis_batch_wk_fim
                                ,   r.sis_batch_run_seq 
                                ,   r.sis_batch_run_dtlog_start 
                                ,   r.sis_batch_run_dtlog_end 
                                ,   r.sis_batch_run_status_cd	
                                ,   coalesce(b.module_cd, 'XXXXX') as module_cd
                                ,   t.sis_batch_time_seq

                        FROM        tbsistema_batch b
                        INNER JOIN  tbsistema_batch_time t ON t.sis_batch_cd = b.sis_batch_cd 
                        LEFT  JOIN  tbsistema_batch_run  r ON r.sis_batch_cd = t.sis_batch_cd 
                        WHERE 1 = 1
                        ${__sis_batch_cd !== 0? `
                            AND b.sis_batch_cd = ${__sis_batch_cd}` : ''}
                        ${__sis_batch_run_seq !== 0? `
                            AND r.sis_batch_run_seq  = ${__sis_batch_run_seq}` : ''}                             
                `

                //let item = await this._Db_Pg_DataGetResult(sqlstring)
                let item = await this.sistema_batch._Db_Pg_DataGetResult(sqlstring)

                //await this.binding(item); 
                await this.sistema_batch.binding(item); 
                await this.sistema_batch_run.binding(item); 
                await this.sistema_batch_time.binding(item)

                /*Consultar procedimentos vinculados ao batch */

                let sqlProcedimentos = `
                        SELECT      m.sis_nucleo_cd_fk
                                ,   m.sis_nucleo_prc_cd
                                ,   m.sis_nucleo_prc_descricao
                                ,   m.sis_nucleo_prc_descritivo
                                ,   m.sis_nucleo_prc_tipo
                                ,   m.dateadd_ini
                                ,   m.dateadd_fim
                                ,   m.permite_execucao_manual
                                ,   p.sis_batch_cd
                                ,   p.sis_batch_nucleo_order
                        FROM        tbsistema_nucleo_procedimento m
                        inner join  tbsistema_batch_nucleo_procedimento p ON p.sis_nucleo_prc_cd = m.sis_nucleo_prc_cd
                        WHERE       1 = 1 
                        and         coalesce(p.sis_batch_cd,0) = ${this.sistema_batch.sis_batch_cd}
                        ORDER BY    p.sis_batch_nucleo_order asc 
                `

                let result = await myClsBase.myDataBase.pag.DataGet(sqlProcedimentos)
                if (result) {
                    for ( const [key, value] of Object.entries(result)) {
                        let itemProcedimento: modelsistema_nucleo_procedimento = new modelsistema_nucleo_procedimento();
                        itemProcedimento.binding(value);
                        this.listProcedimentos.push(itemProcedimento);
                    }
                }


        } catch(e) {
            clsTools.pagConsole(`M9030 ModelSistemaBATCH.modelConsultar ${e}`, true)
        }

    }
    
    public async ModelStatus(sis_batch_run_seq : number ) : Promise<boolean> {
        let statusRun : boolean = false

        try {
                await this.modelConsultar(0, sis_batch_run_seq)
                if (this.sistema_batch_run.sis_batch_run_seq !== 0) 
                {
                    if (this.sistema_batch_run.sis_batch_run_status_cd == 20)
                        statusRun = true;

                }

                return statusRun


        } catch (e) {
            clsTools.pagConsole(`M9030 ModelSistemaBATCH.ModelStatus ${e}`, true)
        }
            return statusRun
    }

    public async ModelRegistrarLog(sis_log_tag: string, sis_log_info: string, uuid_start: string = ``, sis_batch_run_seq : number = 0 ) {
        try {

            sis_log_info = sis_log_info.replace("'","")

            let mymodelsistema_log: modelsistema_log = new modelsistema_log() 
            mymodelsistema_log.sis_batch_run_seq = sis_batch_run_seq
            mymodelsistema_log.sis_log_tag = sis_log_tag.length > 60? sis_log_tag.substring(0,59) : sis_log_tag;
            mymodelsistema_log.sis_log_info = sis_log_info.length > 120? sis_log_info.substring(0,119): sis_log_info ; 
            mymodelsistema_log.uuid_start = uuid_start.length > 30? uuid_start.substring(0,29): uuid_start;
            await mymodelsistema_log.ProcessarLog();

        } catch(e) {
            clsTools.PagErrorException(`M0930`,`modelsistema_batch | ModelRegistrarLog`, e)    
        }
    }

    public async _modelStatusAtualizar_emExecucao() : Promise<boolean> {
        try {
           return await this._modelStatusAtualizar(enumSistema_Batch_Run_Status.EmProcessamento) 
        } catch (e) {
            clsTools.PagErrorException(`M0930`,`modelsistema_batch | ModelRegistrarLog`, e)    
            throw Error(`{e}`)
        }

    }

    public async _modelStatusAtualizar_Finalizar() : Promise<boolean> {
        try {
            return await this._modelStatusAtualizar(enumSistema_Batch_Run_Status.FinalizadoComSucesso)
        } catch (e) {
            clsTools.PagErrorException(`M0930`,`modelsistema_batch | ModelRegistrarLog`, e)    
            throw Error(`{e}`)
        }
    }

    public async _modelStatusAtualizar_ComERRO() : Promise<boolean> {
        try {
            return await this._modelStatusAtualizar(enumSistema_Batch_Run_Status.FinalizadoComERRO)
        } catch (e) {
            clsTools.PagErrorException(`M0930`,`modelsistema_batch | ModelRegistrarLog`, e)    
            throw Error(`{e}`)
        }
    }
    
    private async _modelStatusAtualizar(enumSistema_Batch_Run_Status_selecionar : enumSistema_Batch_Run_Status) {
        let statusAtualizar_emExecucao :  boolean = false;
        try {
                await this.sistema_batch_run.__Consultar()

                if ( enumSistema_Batch_Run_Status_selecionar == enumSistema_Batch_Run_Status.EmProcessamento
                     && this.sistema_batch_run.sis_batch_run_status_cd == 10) {
                    this.sistema_batch_run.sis_batch_run_status_cd = 20;  
                    statusAtualizar_emExecucao = true  
                }

                if ( enumSistema_Batch_Run_Status_selecionar == enumSistema_Batch_Run_Status.FinalizadoComSucesso
                    && this.sistema_batch_run.sis_batch_run_status_cd == 20) {
                   this.sistema_batch_run.sis_batch_run_status_cd = 30;  
                   statusAtualizar_emExecucao = true  
               }

               if ( enumSistema_Batch_Run_Status_selecionar == enumSistema_Batch_Run_Status.FinalizadoComERRO) {
               this.sistema_batch_run.sis_batch_run_status_cd = 99;  
               statusAtualizar_emExecucao = true  
           }


                    await this.sistema_batch_run.__Atualizar();
                    statusAtualizar_emExecucao = true  



        } catch(e) {
            clsTools.pagConsole(`modelsistema_batch | Atualização de Status \n
                                sis_batch_run_seq: ${this.sistema_batch_run.sis_batch_run_seq} \n
                                A opção de status a ser atualizada pode não está de acordo com a opção atual \n 
                                Error: \n ${e} 
                                `, true)
        }
        finally {
            return statusAtualizar_emExecucao;
        }
    }
}
