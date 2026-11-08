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
const modelbase_1 = require("../../model/modelbase");
const Service_1 = __importDefault(require("../m0150_estatistica/service/Service"));
const modelsistema_nucleo_procedimento_1 = __importDefault(require("../m9030_sistema_batch/model/modelsistema_nucleo_procedimento"));
class batch_module_m0150 {
    static start(sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                /*Atualiza os dados estatísticos com base no parâmetro (default 45 dias) */
                yield Service_1.default.Faturamento.processar.dailyExec();
                yield Service_1.default.Faturamento.processar.onLineExec();
                return true;
            }
            catch (e) {
                return false;
            }
        });
    }
    static startProcedimento(modelsistemanucleoprocedimento) {
        return __awaiter(this, void 0, void 0, function* () {
            let statusExecucao = false;
            try {
                if (modelsistemanucleoprocedimento.sis_nucleo_prc_cd == 10150010) {
                    yield Service_1.default.Faturamento.processar.dailyExec();
                    yield Service_1.default.Faturamento.processar.onLineExec();
                    statusExecucao = true;
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M9030`, `sistemaServiceProcedimento.startProcedimento Error`, e);
            }
            finally {
                return statusExecucao;
            }
        });
    }
    static AtualizacaoDiaria() {
        return __awaiter(this, void 0, void 0, function* () {
            let statusExecucao = false;
            try {
                let modelsistemanucleoprocedimento = new modelsistema_nucleo_procedimento_1.default();
                modelsistemanucleoprocedimento.sis_nucleo_prc_cd = 10150010;
                modelsistemanucleoprocedimento.consultar();
                if (modelsistemanucleoprocedimento.sis_nucleo_prc_cd == 10150010) {
                    yield Service_1.default.Faturamento.processar.dailyExec();
                    yield Service_1.default.Faturamento.processar.onLineExec();
                    statusExecucao = true;
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M9030`, `sistemaServiceProcedimento.startProcedimento Error`, e);
            }
            finally {
                return statusExecucao;
            }
        });
    }
}
exports.default = batch_module_m0150;
