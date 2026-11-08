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
//import {ApiGet, ApiPost} from '../api/pag'
const pag_1 = __importDefault(require("../api/pag"));
class ServicePatch {
    serviceRun(sis_batch_service_cd, sis_batch_service_run_status_shedule) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                //console.log(`FRONT/API/INDEX/m9030cmdservicerun`)
                //console.log(`sis_batch_service_cd =${sis_batch_service_cd}`)
                //console.log(`sis_batch_service_run_status_shedule =${sis_batch_service_run_status_shedule}`)
                return yield pag_1.default.post(`/sistema_batch/service/servicerun?sis_batch_service_cd=${sis_batch_service_cd}&sis_batch_service_run_status_shedule=${sis_batch_service_run_status_shedule}`, {});
                //return await ApiPost(`/sistema_batch/service/servicerun?sis_batch_service_cd=${sis_batch_service_cd}&sis_batch_service_run_status_shedule=${sis_batch_service_run_status_shedule}`, {}) 
            }
            catch (e) {
                console.log("erro na chamda da api", e.data);
                throw new Error(`ServicePath ${e}`);
            }
        });
    }
    serviceProcess(sis_batch_service_cd, sis_batch_service_run_status_shedule) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield pag_1.default.post(`/sistema_batch/service/serviceprocessar?sis_batch_service_cd=${sis_batch_service_cd}&sis_batch_service_run_status_shedule=${sis_batch_service_run_status_shedule}`, {});
                //return await ApiPost(`/sistema_batch/service/serviceprocessar?sis_batch_service_cd=${sis_batch_service_cd}&sis_batch_service_run_status_shedule=${sis_batch_service_run_status_shedule}`, {})
            }
            catch (e) {
                console.log("erro na chamda da api", e.data);
                throw new Error(`ServicePath ${e}`);
            }
        });
    }
    /* ---- M9030 - BATCHS | /CMD/ServiceRUN ---- */
    status() {
        console.log("ativo");
    }
}
exports.default = ServicePatch;
