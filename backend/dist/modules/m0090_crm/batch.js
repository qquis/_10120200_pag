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
const serviceCRMSorteioAtualizarBase_1 = __importDefault(require("../../modules/m0090_crm/service/ServiceCRMSorteio/serviceCRMSorteioAtualizarBase"));
class batch_module_m0090 {
    static start(sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                modelbase_1.clsTools.pagConsole("Iniciando o batch M0090 - Atualizar Base de Sorteio CRM");
                yield serviceCRMSorteioAtualizarBase_1.default.start();
                return true;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0090', 'batch_module_m0090.start', e);
                return false;
            }
        });
    }
}
exports.default = batch_module_m0090;
