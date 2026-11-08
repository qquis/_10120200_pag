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
const serviceIntegracao_1 = __importDefault(require("./service/serviceIntegracao"));
const myService = new serviceIntegracao_1.default();
class batch_module_m0095 {
    static start(sis_batch_run_seq_1) {
        return __awaiter(this, arguments, void 0, function* (sis_batch_run_seq, uuid_start = ``) {
            try {
                yield myService.processar(0, sis_batch_run_seq, uuid_start);
                return true;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0095_INTEGRACAO`, `batch_module_m0095.start Error`, e);
                throw new Error(`M0095_INTEGRACAO | ERROR \n ${e}`);
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
                    case 95101:
                        yield myService.processar(0, 0, '', nucleo_procedimento.sis_nucleo_prc_cd);
                        break;
                    case 85002:
                        yield myService.processar(0, 0, '', nucleo_procedimento.sis_nucleo_prc_cd);
                        break;
                    case 95011:
                        yield myService.processar(0, 0, '', nucleo_procedimento.sis_nucleo_prc_cd);
                        break;
                }
                status = true;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0080`, `batch_module_m0080.start Error`, e);
                nucleo_procedimento.ErrorMessage = `ERROR ${e}`;
                status = false;
            }
            finally {
                return status;
            }
        });
    }
}
exports.default = batch_module_m0095;
