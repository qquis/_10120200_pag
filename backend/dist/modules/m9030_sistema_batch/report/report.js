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
const model_1 = require("../../../model/model");
const modelsistema_ServiceBatch_1 = __importDefault(require("../model/modelsistema_ServiceBatch"));
const f9030_60_sistema_batch_runs_list_1 = __importDefault(require("../scriptpg/f9030_60_sistema_batch_runs_list"));
const report_ServiceList_1 = __importDefault(require("./report.ServiceList"));
class reportSistemaBatch extends model_1.modelReport {
    static batchServiceList(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = [];
            try {
                result = yield report_ServiceList_1.default.get(parametro);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`reportSistemaBatch.batchServiceList`, `batchServiceList`, e);
            }
            finally {
                return result;
            }
        });
    }
    static filter_Get(request_1) {
        return __awaiter(this, arguments, void 0, function* (request, Pendentes = true, sis_batch_service_cd) {
            try {
                let sis_batch_cd = 0;
                let sis_batch_run_status_cd = 0;
                let sis_batch_run_seq = 0;
                if (Pendentes)
                    sis_batch_run_status_cd = 10;
                if (request) {
                    sis_batch_cd = parseInt(`${request.body.sis_batch_cd}`);
                    sis_batch_run_status_cd = parseInt(`${request.body.sis_batch_run_status_cd}`);
                    sis_batch_run_seq = parseInt(`${request.body.sis_batch_run_seq}`);
                }
                let filter = {
                    sis_batch_cd,
                    sis_batch_run_status_cd,
                    sis_batch_run_seq,
                    sis_batch_service_cd
                };
                return filter;
            }
            catch (e) {
                throw Error(`Report | Filter_Get Error ${e}`);
            }
        });
    }
    static SistemaBatchRunListPendentes(sis_batch_service_cd) {
        return __awaiter(this, void 0, void 0, function* () {
            return yield this.SistemaBatchRunList(yield this.filter_Get(null, true, sis_batch_service_cd));
        });
    }
    static SistemaBatchRunList(_filtro) {
        const _super = Object.create(null, {
            Get: { get: () => super.Get }
        });
        return __awaiter(this, void 0, void 0, function* () {
            let list = [];
            try {
                let result = yield _super.Get.call(this, f9030_60_sistema_batch_runs_list_1.default.SELECT(_filtro));
                for (const [Key, value] of Object.entries(result)) {
                    let i = new modelsistema_ServiceBatch_1.default(0);
                    yield i.modelBinding(value);
                    yield list.push(i);
                }
                return list;
            }
            catch (e) {
                Tools_1.default.pagConsoleLog(`Reports | SistemaBatchRunList \n ${e}`, true);
                return list;
            }
            //return await  this.sistema_batch_processar(await super.Get(f9030_60_sistema_batch_runs_list.SELECT(await this.filter_Get(null, true, sis_batch_service_cd))))
        });
    }
    static ConsultarRegistroSisBath(sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            let item = new modelsistema_ServiceBatch_1.default(0);
            try {
                yield item.modelConsultar(0, sis_batch_run_seq);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M9020`, `Report | batchGet Error`, e);
            }
            finally {
                return item;
            }
        });
    }
}
exports.default = reportSistemaBatch;
