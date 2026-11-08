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
const modelsistema_log_1 = __importDefault(require("../model/modelsistema_log"));
const reportSistemaLog_1 = __importDefault(require("../report/reportSistemaLog"));
class serviceSistemaLogRegistrar {
    static submit() {
        return __awaiter(this, arguments, void 0, function* (item = { sis_nucleo_prc_cd: 0, sis_log_tag: "", sis_log_info: "", sis_batch_run_seq: 0, proc_log_seq: 0, sis_log_seq: 0, uuid_start: "", uuid: "" }) {
            try {
                let modelLog = new modelsistema_log_1.default();
                yield modelLog.registrarLog(item);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("serviceSistemaLogRegistrar", "submit", e);
            }
        });
    }
    static LogNucleoProcedimentoToday(sis_nucleo_prc_cd) {
        return __awaiter(this, void 0, void 0, function* () {
            return yield reportSistemaLog_1.default.LogNucleoProcedimentoToday(sis_nucleo_prc_cd);
        });
    }
    static registrarLogResumido(sis_nucleo_prc_cd_1, sis_log_tag_1, sis_log_info_1) {
        return __awaiter(this, arguments, void 0, function* (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, sis_batch_run_seq = 0, proc_log_seq = 0) {
            try {
                let modelLog = new modelsistema_log_1.default();
                yield modelLog.registrarLog({ sis_nucleo_prc_cd, sis_log_tag, sis_log_info, sis_batch_run_seq, proc_log_seq, sis_log_seq: 0, uuid_start: "", uuid: "" });
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("serviceSistemaLogRegistrar", "registrarLogResumido", e);
            }
        });
    }
}
exports.default = serviceSistemaLogRegistrar;
