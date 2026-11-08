import 'dotenv/config'
import { Request } from "express";
import modelsistema_ServiceBatch from '../model/modelsistema_ServiceBatch';
import modelsistema_Service from "../model/modelsistema_Service";
import myTools from "../../../tools/Tools";
import { clsBase, clsTools } from "../../../model/modelbase";
import DataBase from '../../../database/DataBase';



import batch_module_m0055 from '../../m0055_faturamento_zanthus/batch'
import batch_module_m0051 from '../../m0051_faturamento_vip/batch';
import batch_module_m0080 from '../../m0080_financeiro/batch' 
import batch_module_m0095 from '../../m0095_integracao/batch'
import batch_module_m0001 from '../../m0001_sistema/batch';
import batch_module_m0040 from '../../m0040_fiscal/batch';
import batch_module_m0090 from '../../m0090_crm/batch';
import batch_module_m0021 from '../../m0021_produtobluesoft/batch';
import batch_module_m0050 from '../../m0050_faturamento_bluesoft/batch';
import batch_module_m0150 from '../../m0150_estatistica/batch';

import modelService_OLD from "../../../model/model.service-OLD";
import serviceNotificacao from '../../m0210_notificacao/service/_serviceNotificacao';
import sistemaServiceProcedimento from '../service/serviceSistemaProcedimento';
import ServiceSistemaBatchInicializacaoDiaria from './serviceSistemaBatchInicializacaoDiaria'

export default class servicePatch extends modelService_OLD{

    constructor() {
        super()
    }

    public async ServiceProcessar(request: Request) :  Promise<modelsistema_Service>  {
        

        let item: modelsistema_Service = new modelsistema_Service(0)
        try {
                await item.modelBindingRequest(request); 

                /*  Processamento do SERVICE BATCH
                __________________________________________________________________________________________
                    01/01/1900 Neste ponto o serviço batch será executado e os runs serão gerados
                    09/09/2025 Alterado para que o processamento do serviço batch considere o campo sis_batch_time_seq
                
                */
                await item.modelProcessarBatch()


                return item; 
        } catch (e) {
            myTools.pagConsoleLog(`Batch (M9030) | ExecuFinalizarRunErrortarRun \n ${e}`)
            return item; 
        }

    }
    public async ServiceRun (request: Request) : Promise<modelsistema_Service> {
        this.serviceLogTAG = "Batch (M9030)"
        let item : modelsistema_Service = new modelsistema_Service(0) 
        
        try {
                //await this._serviceLogRegister(`Batch (M9030) Start ...`) 
            
                await item.modelBindingRequest(request)
                let list_modelsistema_batch_pendentes : modelsistema_ServiceBatch[]



                /* OBTER OS BATCHS PENDENTES */
                list_modelsistema_batch_pendentes = await item.obterSistemaBatchListPendentes(item.sis_batch_service_cd)

                

                /* PROCESSAR BATCHS */
                if (list_modelsistema_batch_pendentes.length > 0 ) {
                    //await this._serviceLogRegister(`Batch (M9030) sis_batch_service_cd ${item.sis_batch_service_cd} - Número de Serviços a executar ${list_modelsistema_batch_pendentes.length}`)
                    
                    for await (const itemModelSistemBatchPendente of list_modelsistema_batch_pendentes) {
                            
                            itemModelSistemBatchPendente.modelConsultar(0,itemModelSistemBatchPendente.sistema_batch_run.sis_batch_run_seq)

                            /*
                             * Alterando o status do serviço para Em Execução
                            */
                            try {
                                await itemModelSistemBatchPendente._modelStatusAtualizar_emExecucao();
                            } catch(e) {
                                await this._serviceLogRegister(`Batch (M9030) Service CD (ERROR) ${item.sis_batch_service_cd} - ${e}`)
                                throw Error(`Batch (M9030) | ServiceRun _ Alterando status para Em execução \n ${e}`)
                            }
                            /*
                             * Executando o serviço
                            */
                            try {

                                //await this._serviceLogRegister(`Batch Service CD ${item.sis_batch_service_cd} - Executando`)
                                
                                // __ EXECUÇÃO DO BATCH SERVIÇO ____________________________________________________________

                                await this.ServiceModuleRun(itemModelSistemBatchPendente); 
                                

                            } catch (e) {
                                await this._serviceLogRegister(`Batch ERROR CD: ${item.sis_batch_service_cd} - ${e}`)
                                await itemModelSistemBatchPendente._modelStatusAtualizar_ComERRO();
                                return item;
                            }

                            /*
                             * Atualizando o status do serviço para Finalizado
                            */
                            try {
                                await itemModelSistemBatchPendente._modelStatusAtualizar_Finalizar(); 
                            } catch (e) {
                                await this._serviceLogRegister(`Batch ERROR CD:  ${item.sis_batch_service_cd} - ${e}`)
                                throw Error(`Batch (M9030) | ServiceRun _ Alterando status para finalizado \n ${e}`)
                            }
                            
                        }
                }
                else {
                    await this._serviceLogRegister(`Batch Service CD ${item.sis_batch_service_cd} - NENHUM Service Path Run Pendente a executar `);
                }
                await this._serviceLogRegister(`Batch (M9030) Service CD ${item.sis_batch_service_cd} - Finalizando`)

                return item 
        } catch(e) {
            myTools.pagConsoleLog(`Batch (M9030) | \n ${e}`)
            return item; 
        }
    }


    public async ServiceModuleRun(modelsistema_batch_select : modelsistema_ServiceBatch) {
        try {
            this.serviceSis_Batch_Run_Seq = modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq

            console.log(`Batch (M9030) | ServiceModuleRun | Serviço: ${modelsistema_batch_select.sistema_batch.module_cd} - ${modelsistema_batch_select.sistema_batch.sis_batch_cd} - Seq: ${modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq} - Iniciando execução do módulo...`)

            switch (modelsistema_batch_select.sistema_batch.module_cd)
            {

                
                case 'M0040': 
                    await batch_module_m0040.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq)
                    break;

                case `F0055`: // __ Processamento de Vendas __________________________________ 
                    

                    /* OBS 16/10/2026 
                    **** VAS VENDAS VIP SERÃO IMPORTADAS DUAS VEZES: NO INICIO E NO FINAL PARA AGILIZAR O PROCESSAMENTO, ATÉ QUE UMA NOVA ABORDAGEM SEJA IMPLEMENTADA ****
                    */

                    /*  VIP 1
                        Importa as vendas VIP    
                    */
                    await batch_module_m0051.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq) 
                    
                    
                    /*  BLUE
                        Importa as vendas Bluesoft    
                    */
                    //await batch_module_m0050.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq)



                    
                    
                    
                    /*  ZANTHUS Importa as vendas ZANTHUS e já processa a venda PAG
                        - Futuramento será desmembrado em dois serviços distintos, um para importar e outro para processar a venda PAG
                    */
                    await batch_module_m0055.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq) 


                    /*  Atualiza os dados estatísticos de venda

                    */                    
                    await batch_module_m0150.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq)




                    
                    
                    break;       
                
                case `F0080`: // __ Processamento de dados Financeiros _______________________
                    await batch_module_m0080.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq)
                    break; 
                
                case `F0095`: // __ Integrações diversas _____________________________________





                    switch (modelsistema_batch_select.sistema_batch.sis_batch_cd) {
                        case 95100:
                            await batch_module_m0021.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq)
                            break;

                        case 95101:
                            await batch_module_m0021.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq)
                            break;
                        case 95102:
                            await batch_module_m0021.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq)
                            break;
                        default:
                            /*MODELO ANTIGO*/
                            await batch_module_m0095.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq, this.serviceLoguuidStart)
                            break; 
                    }
                    break;
                case `F0001`: // __ Processamento de dados do sistema _______________________
                    await batch_module_m0001.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq)
                    break;  

                case `M9030`: // SISTEMA DE BATCHS / PROCEDIMENTOS _______________________
                    await this.serviceBatchProcedimentosParametrizaveis(modelsistema_batch_select)
                    break;                        
                default: 
                    myTools.pagConsoleLog(`ERROR (modelsistema_batch | ModelExecutar): Código do Serviço NÃO INDICADO para a EXECUÇÃO \ n 
                                           Serviço (sis_batch_cd) indicado: ${modelsistema_batch_select.sistema_batch_run.sis_batch_cd}
                        `)                  
            }
            
            if (modelsistema_batch_select.sistema_batch_time.notificacao_cd !== 0) { 
                if (modelsistema_batch_select.sistema_batch.module_cd !== 'F0001')
                    //Enviar notificação de sucesso apenas para serviços que não sejam do sistema (F0001 - Mensagens do sistema)
                await serviceNotificacao.Criar({notificacao_cd : modelsistema_batch_select.sistema_batch_time.notificacao_cd
                                        , notificacao_send_tipo_cd : 100
                                        , notificacao_send_message : `Módulo ${modelsistema_batch_select.sistema_batch.module_cd} Cod ${modelsistema_batch_select.sistema_batch.sis_batch_cd} *Seq ${modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq}* _ ${modelsistema_batch_select.sistema_batch.sis_batch_descricao} -> Executado com sucesso`}) 
            }

        } catch (e) {
            await this._serviceLogRegister(`M0930 | ServiceModuleRun \n ERROR: \n ${e}`)
            myTools.pagConsoleLog(`M0930 | ServiceModuleRun \n ERROR: \n ${e}`)
            throw new Error(`M0095_INTEGRACAO | ERROR \n ${e}`) 
        }
    }
    
    public async serviceBatchStartBackEnd() : Promise<void> {
        try {

            /*Este método irá fazer alguns procedimentos que posteriomente serão transformados em classes/metodos separados*/
            this.serviceLogTAG = "BackEnd_START"
            await super._serviceLogRegister(`Start BackEnd`)


            let myDATABASE : DataBase = new DataBase();
            
            //-------------------------------------------------------------------------------------------------------------------------------//
            //-------------------------------------------------------------------------------------------------------------------------------//
            //-------------------------------------------------------------------------------------------------------------------------------//
            /* TESTE CONEXÃO COM O SQL SERVER */
            if (process.env.BASE_ZANTHUS_SQL == '1') {
                let strDataBaseTeste : string = await myDATABASE.test()
                await super._serviceLogRegister(strDataBaseTeste);
                myTools.pagConsoleLog( `SsqlServer ${strDataBaseTeste}`, true)
            }
            //-------------------------------------------------------------------------------------------------------------------------------//
            //-------------------------------------------------------------------------------------------------------------------------------//
            //-------------------------------------------------------------------------------------------------------------------------------//
            /* Na inicialização Ler o número de registros de batchs pendentes e já fazer a limpeza */
            let result : any =  await super.DataGet(`SELECT count(*) as QtdeRegistroPendente 
                                                     FROM   tbsistema_batch_run 
                                                     where  sis_batch_run_status_cd in (10, 20)
                                                     `)
            if (result) {
                if (  parseInt(`${result[0].qtderegistropendente}`) > 0 ) {
                    await super._serviceLogRegister(`ServicePatchs Pendentes Excluídos: ${result[0].qtderegistropendente}`)
                    await super.DataExecute(`UPDATE tbsistema_batch_run set sis_batch_run_status_cd = 90 where sis_batch_run_status_cd in (10, 20)`) 
                }
            }



        } catch (e) {
            throw new Error(`Error | servicePatch _ Exluir todas as pendências 
                             Descricao do Errro 
                             ${e} 
                            `)
        }
    }


    public async serviceBatchProcedimentosParametrizaveis(modelsistema_batch_select : modelsistema_ServiceBatch) : Promise<void> {
        try {


            switch (modelsistema_batch_select.sistema_batch.sis_batch_cd)
            {
                case 90301: // Inicialização DIÁRIA
                    
                    await serviceNotificacao.Criar({notificacao_cd : modelsistema_batch_select.sistema_batch_time.notificacao_cd
                                            , notificacao_send_tipo_cd : 100
                                            , notificacao_send_message : `🔄 ${modelsistema_batch_select.sistema_batch.module_cd} / ${modelsistema_batch_select.sistema_batch.sis_batch_cd} *Seq ${modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq}* _ *INICIALIZAÇÃO DIÁRIA* (N. de Procedimentos ${modelsistema_batch_select.listProcedimentos.length})`})

                    await ServiceSistemaBatchInicializacaoDiaria.start()
                    break;       
                case 90302: // FINALIZAÇÃO DIÁRIA
                    await serviceNotificacao.Criar({notificacao_cd : modelsistema_batch_select.sistema_batch_time.notificacao_cd
                                            , notificacao_send_tipo_cd : 100
                                            , notificacao_send_message : `🔄 ${modelsistema_batch_select.sistema_batch.module_cd} / ${modelsistema_batch_select.sistema_batch.sis_batch_cd} *Seq ${modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq}* _ *Finalização* (N. de Procedimentos ${modelsistema_batch_select.listProcedimentos.length})`})
                    
                                            //Execução da finalização diária ainda via execução de list
                    await sistemaServiceProcedimento.startlist(modelsistema_batch_select)
                    break;                           
            }
            
            await clsTools._wait(600)
        } catch (e) {
            clsTools.PagErrorException(`M9030`, `serviceBatchLocal Error`, e)
        }
    }
}