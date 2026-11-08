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
//import serviceSistema from './service/serviceSistema'
/*Controles de Baths */
const report_1 = __importDefault(require("../m9030_sistema_batch/report/report"));
const serviceSistemaNotificarFuncionamento_1 = __importDefault(require("./service/serviceSistemaNotificarFuncionamento"));
class batch_module_m0001 {
    static start(sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sistema_batch = yield report_1.default.ConsultarRegistroSisBath(sis_batch_run_seq);
                switch (sistema_batch.sistema_batch.sis_batch_cd) {
                    case 11:
                        yield serviceSistemaNotificarFuncionamento_1.default.start();
                        break;
                }
                return true;
            }
            catch (e) {
                return false;
            }
        });
    }
}
exports.default = batch_module_m0001;
