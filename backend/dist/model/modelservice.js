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
require("dotenv/config");
const Tools_1 = __importDefault(require("../tools/Tools"));
const DataBase_1 = __importDefault(require("../database/DataBase"));
const modelsistema_ServiceBatch_1 = __importDefault(require("../modules/m9030_sistema_batch/model/modelsistema_ServiceBatch"));
const crypto_1 = require("crypto");
const modelbase_1 = require("../model/modelbase");
//const myDataBase : DataBase = new DataBase();
class modelService {
    constructor() {
        this.myDataBase_SERVER = "PAG";
        this.serviceRegistroTotal = 0;
        this.serviceRegistroAtual = 0;
        this.serviceContadorNumeroLinhaAtual = 0;
        this.serviceScriptUpdateAll = ``;
        this.serviceContadorNumeroMaxUpdate = 30;
        this.serviceSis_Batch_Run_Seq = 0;
        this.serviceModelSistem_Batch = new modelsistema_ServiceBatch_1.default(0);
        this.serviceLogTAG = `NOT_INFO`;
        this.myDataBase = new DataBase_1.default();
        this.serviceLoguuidStart = ``;
        this.serviceLoguuidStart = Tools_1.default._datemomentDateToStr(new Date(), "yyyyMMDD_HH:MM:SS") + (0, crypto_1.randomUUID)().substring(0, 12);
    }
    _processPushContador() {
        return __awaiter(this, void 0, void 0, function* () {
            this.serviceContadorNumeroLinhaAtual += 1;
            this.serviceRegistroAtual += 1;
        });
    }
    _processPushScript(sqlScript) {
        return __awaiter(this, void 0, void 0, function* () {
            let statusReturnProcess = true;
            try {
                this.serviceScriptUpdateAll += sqlScript;
                yield this._processPushContador();
                statusReturnProcess = yield this._processCheck();
            }
            catch (e) {
                throw new Error(`${e}`);
            }
            finally {
                return statusReturnProcess;
            }
        });
    }
    _processCheck() {
        return __awaiter(this, arguments, void 0, function* (ProcessFinish = false) {
            let statusReturnProcess = true;
            try {
                if (this.serviceContadorNumeroLinhaAtual >= this.serviceContadorNumeroMaxUpdate && !ProcessFinish) {
                    this.serviceContadorNumeroLinhaAtual = 0;
                    // EXECUÇÃO NO BANCO DE DADOS */
                    // ---------------------------------------------------
                    yield this.DataExecute();
                    // Conferir BATCH caso tenha sido informado */
                    // ---------------------------------------------------
                    statusReturnProcess = yield this._serviceBatchStatus();
                    // Gerar log 
                    yield this._serviceLogRegister(`Atualização Bloco _ ${this.serviceRegistroAtual} / ${this.serviceRegistroTotal}`);
                }
                if (ProcessFinish) {
                    yield this._processPushContador();
                    yield this.DataExecute();
                }
            }
            catch (e) {
                throw new Error(`${e}`);
            }
            finally {
                // Retornar status batch caso tenha sido informado ou positivo de modo geral
                // ---------------------------------------------------
                return statusReturnProcess;
            }
        });
    }
    DataExecute() {
        return __awaiter(this, arguments, void 0, function* (script = ``) {
            try {
                if (script !== ``) {
                    this.serviceScriptUpdateAll = script;
                }
                if (this.serviceScriptUpdateAll !== ``) {
                    if (this.myDataBase_SERVER == 'PAG' || this.myDataBase_SERVER == '')
                        yield this.myDataBase.pag.Execute(this.serviceScriptUpdateAll);
                    if (this.myDataBase_SERVER == 'ZANTHUSPOSTGRE')
                        yield this.myDataBase.zanthusPostgre.Execute(this.serviceScriptUpdateAll);
                    if (this.myDataBase_SERVER == 'ZANTHUSSQLSERVER')
                        yield this.myDataBase.zanthusSQL.Execute(this.serviceScriptUpdateAll);
                    this.serviceScriptUpdateAll = ``;
                }
            }
            catch (e) {
                throw new Error(`${e}`);
            }
        });
    }
    DataGet(sqlScriptSelect) {
        return __awaiter(this, void 0, void 0, function* () {
            let mylistobject = {};
            try {
                if (this.myDataBase_SERVER == 'PAG')
                    mylistobject = yield this.myDataBase.pag.DataGet(sqlScriptSelect);
                if (this.myDataBase_SERVER == 'ZANTHUSPOSTGRE')
                    mylistobject = yield this.myDataBase.zanthusPostgre.DataGet(sqlScriptSelect);
                if (this.myDataBase_SERVER == 'ZANTHUSSQLSERVER')
                    mylistobject = yield this.myDataBase.zanthusSQL.DataGet(sqlScriptSelect);
                return mylistobject;
            }
            catch (e) {
                throw new Error(`${e}`);
            }
        });
    }
    _serviceBatchStatus() {
        return __awaiter(this, void 0, void 0, function* () {
            let sistembatchstatus = false;
            try {
                if (this.serviceSis_Batch_Run_Seq == 0)
                    sistembatchstatus = true;
                else
                    sistembatchstatus = yield this.serviceModelSistem_Batch.ModelStatus(this.serviceSis_Batch_Run_Seq);
            }
            catch (e) {
                throw new Error(`${e}`);
            }
            finally {
                if (!sistembatchstatus) {
                    this._serviceLogRegister(`Processo Finazado - Status Batch inativo`);
                }
                return sistembatchstatus;
            }
        });
    }
    _serviceLogRegister(sis_log_info_1) {
        return __awaiter(this, arguments, void 0, function* (sis_log_info, copy_to_log_file = false) {
            try {
                yield this._whaitLog();
                yield this.serviceModelSistem_Batch.ModelRegistrarLog(this.serviceLogTAG, sis_log_info, this.serviceLoguuidStart, this.serviceSis_Batch_Run_Seq);
                if (copy_to_log_file) {
                    modelbase_1.clsTools.pagConsole(`modelService | _serviceLogRegister \n 
                                    TAG: ${this.serviceLogTAG} \n 
                                    LOG: ${sis_log_info}
                                `);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modelService`, '_serviceLogRegister', e);
            }
        });
    }
    _whaitLog() {
        return __awaiter(this, void 0, void 0, function* () {
            return new Promise(resolve => setTimeout(resolve, 10));
        });
    }
}
exports.default = modelService;
