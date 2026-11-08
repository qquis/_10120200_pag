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
const tbsistema_log_1 = __importDefault(require("../tbs/tbsistema_log"));
///import dataStore from '../dataStore';
class modelsistema_log extends tbsistema_log_1.default {
    constructor() {
        super();
    }
    ProcessarLog() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.uuid = yield this._uuid();
                yield this.__INSERT();
            }
            catch (e) {
                Tools_1.default.pagConsoleLog(`M9020 | modelsistema_log ERROR ${e}`, true);
            }
        });
    }
    registrarLog(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let modelLog = new modelsistema_log();
                if (item) {
                    modelLog.sis_nucleo_prc_cd = (item === null || item === void 0 ? void 0 : item.sis_nucleo_prc_cd) ? parseInt(`${item.sis_nucleo_prc_cd}`) : 0;
                    modelLog.sis_log_tag = (item === null || item === void 0 ? void 0 : item.sis_log_tag) ? `${item.sis_log_tag}` : ``;
                    modelLog.sis_log_info = (item === null || item === void 0 ? void 0 : item.sis_log_info) ? `${item.sis_log_info}` : ``;
                    modelLog.sis_batch_run_seq = (item === null || item === void 0 ? void 0 : item.sis_batch_run_seq) ? parseInt(`${item.sis_batch_run_seq}`) : 0;
                    modelLog.proc_log_seq = (item === null || item === void 0 ? void 0 : item.proc_log_seq) ? parseInt(`${item.proc_log_seq}`) : 0;
                    modelLog.sis_log_seq = (item === null || item === void 0 ? void 0 : item.sis_log_seq) ? parseInt(`${item.sis_log_seq}`) : 0;
                    modelLog.uuid_start = (item === null || item === void 0 ? void 0 : item.uuid_start) ? `${item.uuid_start}` : ``;
                    modelLog.uuid = (item === null || item === void 0 ? void 0 : item.uuid) ? `${item.uuid}` : ``;
                    yield modelLog.ProcessarLog();
                }
            }
            catch (e) {
                Tools_1.default.PagErrorException(`modelsistema_log`, `registrarLog`, e);
            }
        });
    }
}
exports.default = modelsistema_log;
