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
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const modelbase_1 = require("../../../model/modelbase");
let myClsBase = new modelbase_1.clsBase();
const modelsistema_log_1 = __importDefault(require("../../m9020_sistema_log/model/modelsistema_log"));
/*TABELAS */
const tbsistema_batch_1 = __importDefault(require("../tbs/tbsistema_batch"));
const tbsistema_batch_time_1 = __importDefault(require("../tbs/tbsistema_batch_time"));
const tbsistema_batch_run_1 = __importDefault(require("../tbs/tbsistema_batch_run"));
const modelsistema_nucleo_procedimento_1 = __importDefault(require("./modelsistema_nucleo_procedimento"));
/*Reutilização de reportes */
const report_ServiceBathList_1 = __importDefault(require("../report/report.ServiceBathList"));
const report_ServiceBathTimeLIst_1 = __importDefault(require("../report/report.ServiceBathTimeLIst"));
var enumSistema_Batch_Run_Status;
(function (enumSistema_Batch_Run_Status) {
    enumSistema_Batch_Run_Status[enumSistema_Batch_Run_Status["Inicializado"] = 10] = "Inicializado";
    enumSistema_Batch_Run_Status[enumSistema_Batch_Run_Status["EmProcessamento"] = 20] = "EmProcessamento";
    enumSistema_Batch_Run_Status[enumSistema_Batch_Run_Status["FinalizadoComSucesso"] = 30] = "FinalizadoComSucesso";
    enumSistema_Batch_Run_Status[enumSistema_Batch_Run_Status["FinalizadoComERRO"] = 99] = "FinalizadoComERRO";
    enumSistema_Batch_Run_Status[enumSistema_Batch_Run_Status["FinalizadoManualmente"] = 90] = "FinalizadoManualmente";
})(enumSistema_Batch_Run_Status || (enumSistema_Batch_Run_Status = {}));
class modelsistema_ServiceBatch {
    constructor(sis_batch_cd) {
        this.listProcedimentos = [];
        //super(sis_batch_cd)
        this.sistema_batch = new tbsistema_batch_1.default(sis_batch_cd);
        this.sistema_batch_time = new tbsistema_batch_time_1.default(0);
        this.sistema_batch_run = new tbsistema_batch_run_1.default(0);
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
    GetDataQueyAny() {
        return __awaiter(this, void 0, void 0, function* () {
            let ItemAny = {};
            try {
                let listBatch = yield report_ServiceBathList_1.default.get({ sis_batch_cd: this.sistema_batch.sis_batch_cd });
                if (listBatch !== undefined) {
                    ItemAny = listBatch[0];
                    let listTime = yield this.GetDataQueryAny_BatchsTimes();
                    if (listTime !== undefined) {
                        ItemAny.times = listTime;
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modelsistema_ServiceBatch.GetDataQueyAny`, `GetDataQueyAny`, e);
            }
            finally {
                return ItemAny;
            }
        });
    }
    GetDataQueryAny_BatchsTimes() {
        return __awaiter(this, void 0, void 0, function* () {
            let ItemAnyList;
            try {
                let listBatchTimes = yield report_ServiceBathTimeLIst_1.default.get({ sis_batch_cd: this.sistema_batch.sis_batch_cd });
                if (listBatchTimes !== undefined) {
                    ItemAnyList = listBatchTimes;
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modelsistema_ServiceBatch.GetDataQueryAny_BatchsTimes`, `GetDataQueryAny_BatchsTimes`, e);
            }
            finally {
                return ItemAnyList;
            }
        });
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
    modelBinding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item !== undefined) {
                //super.binding(item);
                //this.sis_batch_cd = item.sis_batch_cd; 
                //this.sis_batch_descricao = item.sis_batch_descricao;
                this.sistema_batch.binding(item);
                this.sistema_batch.sis_batch_cd = item.sis_batch_cd;
                this.sistema_batch.sis_batch_descricao = item.sis_batch_descricao;
                this.sistema_batch_run.binding(item);
                this.sistema_batch_time.sis_batch_cd = item.sis_batch_cd;
                this.sistema_batch_time.sis_batch_dt_ini = Tools_1.default.pagDateTime_getDate(item.sis_batch_dt_ini ? item.sis_batch_dt_ini : '1900-01-01');
                this.sistema_batch_time.sis_batch_dt_fim = Tools_1.default.pagDateTime_getDate(item.sis_batch_dt_fim ? item.sis_batch_dt_fim : '1900-01-01');
                this.sistema_batch_time.sis_batch_hm_ini = item.sis_batch_hm_ini ? "00:00" : item.sis_batch_hm_ini;
                this.sistema_batch_time.sis_batch_hm_fim = item.sis_batch_hm_ini ? "00:00" : item.sis_batch_hm_fim;
                this.sistema_batch_time.sis_batch_recorrencia_cd = item.sis_batch_recorrencia_cd ? 0 : item.sis_batch_recorrencia_cd;
                this.sistema_batch_time.sis_batch_wk_ini = item.sis_batch_wk_ini ? item.sis_batch_wk_ini : 0;
                this.sistema_batch_time.sis_batch_wk_fim = item.sis_batch_wk_fim ? item.sis_batch_wk_fim : 0;
                this.sistema_batch_time.notificacao_cd = item === null || item === void 0 ? void 0 : item.notificacao_cd;
                this.sistema_batch_time.sis_batch_time_seq = item === null || item === void 0 ? void 0 : item.sis_batch_time_seq;
                //this.module_cd = item?.module_cd;
                this.sistema_batch.module_cd = item === null || item === void 0 ? void 0 : item.module_cd;
            }
        });
    }
    modelBindingRequest(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item !== undefined) {
                    let mySis_batch_run_seq = parseInt(`${item.query.sis_batch_run_seq}`);
                    this.sistema_batch_run.sis_batch_run_seq = mySis_batch_run_seq;
                    yield this.sistema_batch_run.__Consultar();
                    //this.sis_batch_cd = this.sistema_batch_run.sis_batch_cd
                    this.sistema_batch.sis_batch_cd = this.sistema_batch_run.sis_batch_cd;
                }
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`ERROR modelsistema_batch_run.modelBindingRequest Seq. ${this.sistema_batch_run.sis_batch_run_seq} | Batch Run NÃO está com STATUS = 10 para ser executado (status = 20)`, true);
            }
        });
    }
    modelConsultar(__sis_batch_cd, __sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
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
                        ${__sis_batch_cd !== 0 ? `
                            AND b.sis_batch_cd = ${__sis_batch_cd}` : ''}
                        ${__sis_batch_run_seq !== 0 ? `
                            AND r.sis_batch_run_seq  = ${__sis_batch_run_seq}` : ''}                             
                `;
                //let item = await this._Db_Pg_DataGetResult(sqlstring)
                let item = yield this.sistema_batch._Db_Pg_DataGetResult(sqlstring);
                //await this.binding(item); 
                yield this.sistema_batch.binding(item);
                yield this.sistema_batch_run.binding(item);
                yield this.sistema_batch_time.binding(item);
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
                `;
                let result = yield myClsBase.myDataBase.pag.DataGet(sqlProcedimentos);
                if (result) {
                    for (const [key, value] of Object.entries(result)) {
                        let itemProcedimento = new modelsistema_nucleo_procedimento_1.default();
                        itemProcedimento.binding(value);
                        this.listProcedimentos.push(itemProcedimento);
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`M9030 ModelSistemaBATCH.modelConsultar ${e}`, true);
            }
        });
    }
    ModelStatus(sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            let statusRun = false;
            try {
                yield this.modelConsultar(0, sis_batch_run_seq);
                if (this.sistema_batch_run.sis_batch_run_seq !== 0) {
                    if (this.sistema_batch_run.sis_batch_run_status_cd == 20)
                        statusRun = true;
                }
                return statusRun;
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`M9030 ModelSistemaBATCH.ModelStatus ${e}`, true);
            }
            return statusRun;
        });
    }
    ModelRegistrarLog(sis_log_tag_1, sis_log_info_1) {
        return __awaiter(this, arguments, void 0, function* (sis_log_tag, sis_log_info, uuid_start = ``, sis_batch_run_seq = 0) {
            try {
                sis_log_info = sis_log_info.replace("'", "");
                let mymodelsistema_log = new modelsistema_log_1.default();
                mymodelsistema_log.sis_batch_run_seq = sis_batch_run_seq;
                mymodelsistema_log.sis_log_tag = sis_log_tag.length > 60 ? sis_log_tag.substring(0, 59) : sis_log_tag;
                mymodelsistema_log.sis_log_info = sis_log_info.length > 120 ? sis_log_info.substring(0, 119) : sis_log_info;
                mymodelsistema_log.uuid_start = uuid_start.length > 30 ? uuid_start.substring(0, 29) : uuid_start;
                yield mymodelsistema_log.ProcessarLog();
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0930`, `modelsistema_batch | ModelRegistrarLog`, e);
            }
        });
    }
    _modelStatusAtualizar_emExecucao() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield this._modelStatusAtualizar(enumSistema_Batch_Run_Status.EmProcessamento);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0930`, `modelsistema_batch | ModelRegistrarLog`, e);
                throw Error(`{e}`);
            }
        });
    }
    _modelStatusAtualizar_Finalizar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield this._modelStatusAtualizar(enumSistema_Batch_Run_Status.FinalizadoComSucesso);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0930`, `modelsistema_batch | ModelRegistrarLog`, e);
                throw Error(`{e}`);
            }
        });
    }
    _modelStatusAtualizar_ComERRO() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield this._modelStatusAtualizar(enumSistema_Batch_Run_Status.FinalizadoComERRO);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0930`, `modelsistema_batch | ModelRegistrarLog`, e);
                throw Error(`{e}`);
            }
        });
    }
    _modelStatusAtualizar(enumSistema_Batch_Run_Status_selecionar) {
        return __awaiter(this, void 0, void 0, function* () {
            let statusAtualizar_emExecucao = false;
            try {
                yield this.sistema_batch_run.__Consultar();
                if (enumSistema_Batch_Run_Status_selecionar == enumSistema_Batch_Run_Status.EmProcessamento
                    && this.sistema_batch_run.sis_batch_run_status_cd == 10) {
                    this.sistema_batch_run.sis_batch_run_status_cd = 20;
                    statusAtualizar_emExecucao = true;
                }
                if (enumSistema_Batch_Run_Status_selecionar == enumSistema_Batch_Run_Status.FinalizadoComSucesso
                    && this.sistema_batch_run.sis_batch_run_status_cd == 20) {
                    this.sistema_batch_run.sis_batch_run_status_cd = 30;
                    statusAtualizar_emExecucao = true;
                }
                if (enumSistema_Batch_Run_Status_selecionar == enumSistema_Batch_Run_Status.FinalizadoComERRO) {
                    this.sistema_batch_run.sis_batch_run_status_cd = 99;
                    statusAtualizar_emExecucao = true;
                }
                yield this.sistema_batch_run.__Atualizar();
                statusAtualizar_emExecucao = true;
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`modelsistema_batch | Atualização de Status \n
                                sis_batch_run_seq: ${this.sistema_batch_run.sis_batch_run_seq} \n
                                A opção de status a ser atualizada pode não está de acordo com a opção atual \n 
                                Error: \n ${e} 
                                `, true);
            }
            finally {
                return statusAtualizar_emExecucao;
            }
        });
    }
}
exports.default = modelsistema_ServiceBatch;
