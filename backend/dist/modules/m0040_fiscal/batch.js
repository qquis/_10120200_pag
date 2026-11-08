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
const modelsistema_ServiceBatch_1 = __importDefault(require("../m9030_sistema_batch/model/modelsistema_ServiceBatch"));
const service_1 = __importDefault(require("./service/service"));
class batch_module_m0040 {
    static start(sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            let mymodelsistema_batch = new modelsistema_ServiceBatch_1.default(0);
            yield mymodelsistema_batch.modelConsultar(0, sis_batch_run_seq);
            let status = false;
            try {
                switch (mymodelsistema_batch.sistema_batch.sis_batch_cd) {
                    case 40005:
                        yield service_1.default.FiguraFiscalRegraFiscal.start();
                        break;
                    case 40010:
                        yield service_1.default.FiguraFiscalPorProdutoUnitario.start({});
                        /*A atualização da figura nfce ja esta dentro do "atualizarBasePag" */
                        //await service.regraFiscalNfceProduto.start({});
                        yield service_1.default.atualizaMapeamentoFiscal.start();
                        break;
                }
                status = true;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0040`, `batch_module_m0040 - FISCAL | Error`, e);
                status = false;
            }
            finally {
                return status;
            }
        });
    }
    static Procedimento(nucleo_procedimento) {
        return __awaiter(this, void 0, void 0, function* () {
            if (!nucleo_procedimento.__atualizado)
                nucleo_procedimento.consultar();
            let status = false;
            try {
                switch (nucleo_procedimento.sis_nucleo_prc_cd) {
                    case 40005:
                        yield service_1.default.FiguraFiscalRegraFiscal.start();
                        break;
                    case 40010:
                        yield service_1.default.FiguraFiscalPorProdutoUnitario.start({});
                        break;
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0040`, `batch_module_m0040 - FISCAL | Error`, e);
                status = false;
            }
            finally {
                return status;
            }
        });
    }
    static AtualizacaoDiaria() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield service_1.default.FiguraFiscalRegraFiscal.start();
                yield service_1.default.FiguraFiscalPorProdutoNfce.start({});
                yield service_1.default.FiguraFiscalPorProdutoNfe.start({});
                yield service_1.default.atualizaMapeamentoFiscal.start();
                return true;
            }
            catch (e) {
                return false;
            }
        });
    }
}
exports.default = batch_module_m0040;
