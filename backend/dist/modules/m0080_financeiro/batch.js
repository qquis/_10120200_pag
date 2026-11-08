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
/*Controles de Baths */
const report_1 = __importDefault(require("../m9030_sistema_batch/report/report"));
const modelsistema_nucleo_procedimento_1 = __importDefault(require("../m9030_sistema_batch/model/modelsistema_nucleo_procedimento"));
/*-----------------------------------------------------*/
/* Serviços */
const serviceAutorizacaoPgto_1 = __importDefault(require("./service/serviceAutorizacaoPgto"));
const serviceMovimentoCaixaBluesoft_1 = __importDefault(require("./service/serviceMovimentoCaixaBluesoft"));
class batch_module_m0080 {
    static start(sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let item = yield report_1.default.ConsultarRegistroSisBath(sis_batch_run_seq);
                switch (item.sistema_batch.sis_batch_cd) {
                    case 80011:
                        yield serviceAutorizacaoPgto_1.default.Atualizar(sis_batch_run_seq);
                        break;
                    case 80021:
                        yield this.executeListProcedimentos(item);
                        break;
                    default:
                        modelbase_1.clsTools.pagConsole(`Batch M0080 não implementado para o código ${item.sistema_batch.sis_batch_cd}`, true);
                }
                return true;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`M0080`, `batch_module_m0080.start Error`, e);
                return false;
            }
        });
    }
    static executeListProcedimentos(modelsistema_batch) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                for (let i = 0; i <= modelsistema_batch.listProcedimentos.length; i++) {
                    yield modelsistema_batch.listProcedimentos[i].iniciarExecucao();
                    yield this.Procedimento(modelsistema_batch.listProcedimentos[i]);
                    yield modelsistema_batch.listProcedimentos[i].finalizarExecucao();
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`M0080`, `serviceMovimentoCaixaBluesoft.execute Error`, e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`Service Movimento Caixa Bluesoft finalizado`, true);
                return modelsistema_batch.listProcedimentos;
            }
        });
    }
    static Procedimento(sistema_nucleo_procedimento) {
        return __awaiter(this, void 0, void 0, function* () {
            if (!sistema_nucleo_procedimento.__atualizado)
                sistema_nucleo_procedimento.consultar();
            let status = false;
            try {
                switch (sistema_nucleo_procedimento.sis_nucleo_prc_cd) {
                    case 8002:
                        status = false;
                        let result = yield serviceMovimentoCaixaBluesoft_1.default.start(sistema_nucleo_procedimento);
                        if (result)
                            status = true;
                        break;
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`M0080`, `batch_module_m0080.start Error`, e);
                status = false;
            }
            finally {
                return status;
            }
        });
    }
    static AtualizacaoDiaria() {
        return __awaiter(this, void 0, void 0, function* () {
            let status = false;
            try {
                let nucleo_procedimento = new modelsistema_nucleo_procedimento_1.default();
                nucleo_procedimento.sis_nucleo_prc_cd = 8002;
                yield nucleo_procedimento.consultar();
                yield serviceMovimentoCaixaBluesoft_1.default.start(nucleo_procedimento);
                status = true;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`M0080`, `batch_module_m0080.AtualizacaoDiaria Error`, e);
                status = false;
            }
            finally {
                return status;
            }
        });
    }
}
exports.default = batch_module_m0080;
