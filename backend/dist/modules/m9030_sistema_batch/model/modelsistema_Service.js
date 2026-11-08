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
const modelbase_1 = require("../../../model/modelbase");
const tbsistema_batch_service_1 = __importDefault(require("../tbs/tbsistema_batch_service"));
const tbsistema_batch_service_run_1 = __importDefault(require("../tbs/tbsistema_batch_service_run"));
const f9030_50_sistema_batch_service_processar_1 = __importDefault(require("../scriptpg/f9030_50_sistema_batch_service_processar"));
/*Reutilização de Reports */
const report_ServiceList_1 = __importDefault(require("../report/report.ServiceList"));
const report_ServiceBathList_1 = __importDefault(require("../report/report.ServiceBathList"));
const report_1 = __importDefault(require("../report/report"));
const myClsBase = new modelbase_1.clsBase();
class modelsistema_Service extends tbsistema_batch_service_1.default {
    constructor(sis_batch_service_cd) {
        super(sis_batch_service_cd);
        this.item_batch_service_run = new tbsistema_batch_service_run_1.default(0);
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
    GetDataQueyAny(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let ItemAny = {};
            try {
                const modeldb = new modelbase_1.clsBase();
                let resultQuery = yield report_ServiceList_1.default.get({ sis_batch_service_cd: parametros.sis_batch_service_cd });
                if (resultQuery !== undefined) {
                    ItemAny = resultQuery[0];
                    if (ItemAny) {
                        let itemAnyListBatchs = yield this.GetDataQueryAny_Batchs();
                        if (itemAnyListBatchs !== undefined) {
                            ItemAny.batchs = itemAnyListBatchs;
                        }
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modelsistema_batch_service.GetDataQueyAny`, `GetDataQueyAny`, e);
            }
            finally {
                return ItemAny;
            }
        });
    }
    GetDataQueryAny_Batchs() {
        return __awaiter(this, void 0, void 0, function* () {
            let itemAnyListBatchs = {};
            try {
                itemAnyListBatchs = yield report_ServiceBathList_1.default.get({ sis_batch_service_cd: this.sis_batch_service_cd });
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modelsistema_batch_service.GetDataQueryAny_Batchs`, `GetDataQueryAny_Batchs`, e);
            }
            finally {
                return itemAnyListBatchs;
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
    modelBindingRequest(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item !== undefined) {
                    //console.log(`Código do Serviço ${item.query.sis_batch_service_cd} Shedule indicado ${item.query.sis_batch_service_run_status_shedule}`)
                    this.sis_batch_service_cd = parseInt(`${item.query.sis_batch_service_cd}`);
                    this.sis_batch_service_ult_run_host = `localhost`;
                    this.item_batch_service_run.sis_batch_service_cd = this.sis_batch_service_cd;
                    if (item.query.sis_batch_service_run_status_shedule !== undefined) {
                        this.item_batch_service_run.sis_batch_service_run_status_shedule = parseInt(`${item.query.sis_batch_service_run_status_shedule}`);
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modelsistema_batch_service.modelBindingRequest`, `modelBindingRequest`, e);
            }
        });
    }
    obterSistemaBatchListPendentes(sis_batch_service_cd) {
        return __awaiter(this, void 0, void 0, function* () {
            let listaSistemaBatch = [];
            try {
                listaSistemaBatch = yield report_1.default.SistemaBatchRunListPendentes(sis_batch_service_cd);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modelsistema_batch_service.obterSistemaBatchListPendentes`, `obterSistemaBatchListPendentes`, e);
            }
            finally {
                return listaSistemaBatch;
            }
        });
    }
    modelProcessarBatch() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (this.sis_batch_service_cd == 0)
                    throw Error(`Código do Batch Serviço não especificado`);
                let scriptExecutarBatchServiceRun = this._Db_Pg_script_Update()
                    + this.item_batch_service_run._Db_Pg_script_Insert();
                yield this._Db_Pg_DataPost(scriptExecutarBatchServiceRun);
                yield myClsBase.myDataBase.pag.Execute(f9030_50_sistema_batch_service_processar_1.default.SELECT(parseInt(`${this.sis_batch_service_cd}`)));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modelsistema_batch_service.modelProcessarBatch`, `modelProcessarBatch`, e);
            }
        });
    }
}
exports.default = modelsistema_Service;
