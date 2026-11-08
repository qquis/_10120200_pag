"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __asyncValues = (this && this.__asyncValues) || function (o) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var m = o[Symbol.asyncIterator], i;
    return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i);
    function verb(n) { i[n] = o[n] && function (v) { return new Promise(function (resolve, reject) { v = o[n](v), settle(resolve, reject, v.done, v.value); }); }; }
    function settle(resolve, reject, d, v) { Promise.resolve(v).then(function(v) { resolve({ value: v, done: d }); }, reject); }
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
require("dotenv/config");
const modelsistema_Service_1 = __importDefault(require("../model/modelsistema_Service"));
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const modelbase_1 = require("../../../model/modelbase");
const DataBase_1 = __importDefault(require("../../../database/DataBase"));
const batch_1 = __importDefault(require("../../m0055_faturamento_zanthus/batch"));
const batch_2 = __importDefault(require("../../m0051_faturamento_vip/batch"));
const batch_3 = __importDefault(require("../../m0080_financeiro/batch"));
const batch_4 = __importDefault(require("../../m0095_integracao/batch"));
const batch_5 = __importDefault(require("../../m0001_sistema/batch"));
const batch_6 = __importDefault(require("../../m0040_fiscal/batch"));
const batch_7 = __importDefault(require("../../m0021_produtobluesoft/batch"));
const batch_8 = __importDefault(require("../../m0150_estatistica/batch"));
const model_service_OLD_1 = __importDefault(require("../../../model/model.service-OLD"));
const _serviceNotificacao_1 = __importDefault(require("../../m0210_notificacao/service/_serviceNotificacao"));
const serviceSistemaProcedimento_1 = __importDefault(require("../service/serviceSistemaProcedimento"));
const serviceSistemaBatchInicializacaoDiaria_1 = __importDefault(require("./serviceSistemaBatchInicializacaoDiaria"));
class servicePatch extends model_service_OLD_1.default {
    constructor() {
        super();
    }
    ServiceProcessar(request) {
        return __awaiter(this, void 0, void 0, function* () {
            let item = new modelsistema_Service_1.default(0);
            try {
                yield item.modelBindingRequest(request);
                /*  Processamento do SERVICE BATCH
                __________________________________________________________________________________________
                    01/01/1900 Neste ponto o serviço batch será executado e os runs serão gerados
                    09/09/2025 Alterado para que o processamento do serviço batch considere o campo sis_batch_time_seq
                
                */
                yield item.modelProcessarBatch();
                return item;
            }
            catch (e) {
                Tools_1.default.pagConsoleLog(`Batch (M9030) | ExecuFinalizarRunErrortarRun \n ${e}`);
                return item;
            }
        });
    }
    ServiceRun(request) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            this.serviceLogTAG = "Batch (M9030)";
            let item = new modelsistema_Service_1.default(0);
            try {
                //await this._serviceLogRegister(`Batch (M9030) Start ...`) 
                yield item.modelBindingRequest(request);
                let list_modelsistema_batch_pendentes;
                /* OBTER OS BATCHS PENDENTES */
                list_modelsistema_batch_pendentes = yield item.obterSistemaBatchListPendentes(item.sis_batch_service_cd);
                /* PROCESSAR BATCHS */
                if (list_modelsistema_batch_pendentes.length > 0) {
                    try {
                        //await this._serviceLogRegister(`Batch (M9030) sis_batch_service_cd ${item.sis_batch_service_cd} - Número de Serviços a executar ${list_modelsistema_batch_pendentes.length}`)
                        for (var _d = true, list_modelsistema_batch_pendentes_1 = __asyncValues(list_modelsistema_batch_pendentes), list_modelsistema_batch_pendentes_1_1; list_modelsistema_batch_pendentes_1_1 = yield list_modelsistema_batch_pendentes_1.next(), _a = list_modelsistema_batch_pendentes_1_1.done, !_a; _d = true) {
                            _c = list_modelsistema_batch_pendentes_1_1.value;
                            _d = false;
                            const itemModelSistemBatchPendente = _c;
                            itemModelSistemBatchPendente.modelConsultar(0, itemModelSistemBatchPendente.sistema_batch_run.sis_batch_run_seq);
                            /*
                             * Alterando o status do serviço para Em Execução
                            */
                            try {
                                yield itemModelSistemBatchPendente._modelStatusAtualizar_emExecucao();
                            }
                            catch (e) {
                                yield this._serviceLogRegister(`Batch (M9030) Service CD (ERROR) ${item.sis_batch_service_cd} - ${e}`);
                                throw Error(`Batch (M9030) | ServiceRun _ Alterando status para Em execução \n ${e}`);
                            }
                            /*
                             * Executando o serviço
                            */
                            try {
                                //await this._serviceLogRegister(`Batch Service CD ${item.sis_batch_service_cd} - Executando`)
                                // __ EXECUÇÃO DO BATCH SERVIÇO ____________________________________________________________
                                yield this.ServiceModuleRun(itemModelSistemBatchPendente);
                            }
                            catch (e) {
                                yield this._serviceLogRegister(`Batch ERROR CD: ${item.sis_batch_service_cd} - ${e}`);
                                yield itemModelSistemBatchPendente._modelStatusAtualizar_ComERRO();
                                return item;
                            }
                            /*
                             * Atualizando o status do serviço para Finalizado
                            */
                            try {
                                yield itemModelSistemBatchPendente._modelStatusAtualizar_Finalizar();
                            }
                            catch (e) {
                                yield this._serviceLogRegister(`Batch ERROR CD:  ${item.sis_batch_service_cd} - ${e}`);
                                throw Error(`Batch (M9030) | ServiceRun _ Alterando status para finalizado \n ${e}`);
                            }
                        }
                    }
                    catch (e_1_1) { e_1 = { error: e_1_1 }; }
                    finally {
                        try {
                            if (!_d && !_a && (_b = list_modelsistema_batch_pendentes_1.return)) yield _b.call(list_modelsistema_batch_pendentes_1);
                        }
                        finally { if (e_1) throw e_1.error; }
                    }
                }
                else {
                    yield this._serviceLogRegister(`Batch Service CD ${item.sis_batch_service_cd} - NENHUM Service Path Run Pendente a executar `);
                }
                yield this._serviceLogRegister(`Batch (M9030) Service CD ${item.sis_batch_service_cd} - Finalizando`);
                return item;
            }
            catch (e) {
                Tools_1.default.pagConsoleLog(`Batch (M9030) | \n ${e}`);
                return item;
            }
        });
    }
    ServiceModuleRun(modelsistema_batch_select) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.serviceSis_Batch_Run_Seq = modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq;
                console.log(`Batch (M9030) | ServiceModuleRun | Serviço: ${modelsistema_batch_select.sistema_batch.module_cd} - ${modelsistema_batch_select.sistema_batch.sis_batch_cd} - Seq: ${modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq} - Iniciando execução do módulo...`);
                switch (modelsistema_batch_select.sistema_batch.module_cd) {
                    case 'M0040':
                        yield batch_6.default.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq);
                        break;
                    case `F0055`: // __ Processamento de Vendas __________________________________ 
                        /* OBS 16/10/2026
                        **** VAS VENDAS VIP SERÃO IMPORTADAS DUAS VEZES: NO INICIO E NO FINAL PARA AGILIZAR O PROCESSAMENTO, ATÉ QUE UMA NOVA ABORDAGEM SEJA IMPLEMENTADA ****
                        */
                        /*  VIP 1
                            Importa as vendas VIP
                        */
                        yield batch_2.default.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq);
                        /*  BLUE
                            Importa as vendas Bluesoft
                        */
                        //await batch_module_m0050.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq)
                        /*  ZANTHUS Importa as vendas ZANTHUS e já processa a venda PAG
                            - Futuramento será desmembrado em dois serviços distintos, um para importar e outro para processar a venda PAG
                        */
                        yield batch_1.default.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq);
                        /*  Atualiza os dados estatísticos de venda
    
                        */
                        yield batch_8.default.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq);
                        break;
                    case `F0080`: // __ Processamento de dados Financeiros _______________________
                        yield batch_3.default.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq);
                        break;
                    case `F0095`: // __ Integrações diversas _____________________________________
                        switch (modelsistema_batch_select.sistema_batch.sis_batch_cd) {
                            case 95100:
                                yield batch_7.default.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq);
                                break;
                            case 95101:
                                yield batch_7.default.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq);
                                break;
                            case 95102:
                                yield batch_7.default.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq);
                                break;
                            default:
                                /*MODELO ANTIGO*/
                                yield batch_4.default.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq, this.serviceLoguuidStart);
                                break;
                        }
                        break;
                    case `F0001`: // __ Processamento de dados do sistema _______________________
                        yield batch_5.default.start(modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq);
                        break;
                    case `M9030`: // SISTEMA DE BATCHS / PROCEDIMENTOS _______________________
                        yield this.serviceBatchProcedimentosParametrizaveis(modelsistema_batch_select);
                        break;
                    default:
                        Tools_1.default.pagConsoleLog(`ERROR (modelsistema_batch | ModelExecutar): Código do Serviço NÃO INDICADO para a EXECUÇÃO \ n 
                                           Serviço (sis_batch_cd) indicado: ${modelsistema_batch_select.sistema_batch_run.sis_batch_cd}
                        `);
                }
                if (modelsistema_batch_select.sistema_batch_time.notificacao_cd !== 0) {
                    if (modelsistema_batch_select.sistema_batch.module_cd !== 'F0001')
                        //Enviar notificação de sucesso apenas para serviços que não sejam do sistema (F0001 - Mensagens do sistema)
                        yield _serviceNotificacao_1.default.Criar({ notificacao_cd: modelsistema_batch_select.sistema_batch_time.notificacao_cd,
                            notificacao_send_tipo_cd: 100,
                            notificacao_send_message: `Módulo ${modelsistema_batch_select.sistema_batch.module_cd} Cod ${modelsistema_batch_select.sistema_batch.sis_batch_cd} *Seq ${modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq}* _ ${modelsistema_batch_select.sistema_batch.sis_batch_descricao} -> Executado com sucesso` });
                }
            }
            catch (e) {
                yield this._serviceLogRegister(`M0930 | ServiceModuleRun \n ERROR: \n ${e}`);
                Tools_1.default.pagConsoleLog(`M0930 | ServiceModuleRun \n ERROR: \n ${e}`);
                throw new Error(`M0095_INTEGRACAO | ERROR \n ${e}`);
            }
        });
    }
    serviceBatchStartBackEnd() {
        const _super = Object.create(null, {
            _serviceLogRegister: { get: () => super._serviceLogRegister },
            DataGet: { get: () => super.DataGet },
            DataExecute: { get: () => super.DataExecute }
        });
        return __awaiter(this, void 0, void 0, function* () {
            try {
                /*Este método irá fazer alguns procedimentos que posteriomente serão transformados em classes/metodos separados*/
                this.serviceLogTAG = "BackEnd_START";
                yield _super._serviceLogRegister.call(this, `Start BackEnd`);
                let myDATABASE = new DataBase_1.default();
                //-------------------------------------------------------------------------------------------------------------------------------//
                //-------------------------------------------------------------------------------------------------------------------------------//
                //-------------------------------------------------------------------------------------------------------------------------------//
                /* TESTE CONEXÃO COM O SQL SERVER */
                if (process.env.BASE_ZANTHUS_SQL == '1') {
                    let strDataBaseTeste = yield myDATABASE.test();
                    yield _super._serviceLogRegister.call(this, strDataBaseTeste);
                    Tools_1.default.pagConsoleLog(`SsqlServer ${strDataBaseTeste}`, true);
                }
                //-------------------------------------------------------------------------------------------------------------------------------//
                //-------------------------------------------------------------------------------------------------------------------------------//
                //-------------------------------------------------------------------------------------------------------------------------------//
                /* Na inicialização Ler o número de registros de batchs pendentes e já fazer a limpeza */
                let result = yield _super.DataGet.call(this, `SELECT count(*) as QtdeRegistroPendente 
                                                     FROM   tbsistema_batch_run 
                                                     where  sis_batch_run_status_cd in (10, 20)
                                                     `);
                if (result) {
                    if (parseInt(`${result[0].qtderegistropendente}`) > 0) {
                        yield _super._serviceLogRegister.call(this, `ServicePatchs Pendentes Excluídos: ${result[0].qtderegistropendente}`);
                        yield _super.DataExecute.call(this, `UPDATE tbsistema_batch_run set sis_batch_run_status_cd = 90 where sis_batch_run_status_cd in (10, 20)`);
                    }
                }
            }
            catch (e) {
                throw new Error(`Error | servicePatch _ Exluir todas as pendências 
                             Descricao do Errro 
                             ${e} 
                            `);
            }
        });
    }
    serviceBatchProcedimentosParametrizaveis(modelsistema_batch_select) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                switch (modelsistema_batch_select.sistema_batch.sis_batch_cd) {
                    case 90301: // Inicialização DIÁRIA
                        yield _serviceNotificacao_1.default.Criar({ notificacao_cd: modelsistema_batch_select.sistema_batch_time.notificacao_cd,
                            notificacao_send_tipo_cd: 100,
                            notificacao_send_message: `🔄 ${modelsistema_batch_select.sistema_batch.module_cd} / ${modelsistema_batch_select.sistema_batch.sis_batch_cd} *Seq ${modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq}* _ *INICIALIZAÇÃO DIÁRIA* (N. de Procedimentos ${modelsistema_batch_select.listProcedimentos.length})` });
                        yield serviceSistemaBatchInicializacaoDiaria_1.default.start();
                        break;
                    case 90302: // FINALIZAÇÃO DIÁRIA
                        yield _serviceNotificacao_1.default.Criar({ notificacao_cd: modelsistema_batch_select.sistema_batch_time.notificacao_cd,
                            notificacao_send_tipo_cd: 100,
                            notificacao_send_message: `🔄 ${modelsistema_batch_select.sistema_batch.module_cd} / ${modelsistema_batch_select.sistema_batch.sis_batch_cd} *Seq ${modelsistema_batch_select.sistema_batch_run.sis_batch_run_seq}* _ *Finalização* (N. de Procedimentos ${modelsistema_batch_select.listProcedimentos.length})` });
                        //Execução da finalização diária ainda via execução de list
                        yield serviceSistemaProcedimento_1.default.startlist(modelsistema_batch_select);
                        break;
                }
                yield modelbase_1.clsTools._wait(600);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M9030`, `serviceBatchLocal Error`, e);
            }
        });
    }
}
exports.default = servicePatch;
