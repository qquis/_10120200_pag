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
/*-----------------------------------------------------*/
/* Serviços */
const service_1 = __importDefault(require("./service/service"));
const report_1 = __importDefault(require("../m0001_sistema/report/report"));
class batch_module_m0050 {
    static start(sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield service_1.default.processamentoPendente();
                return true;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0050`, `batch_module_m0050.start Error`, e);
                return false;
            }
        });
    }
    static AtualizacaoDiaria() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let dadosSistemaOperacional = yield report_1.default.Operacional.getDefault();
                console.log(dadosSistemaOperacional);
                let parametro = {};
                parametro.dataInicial = dadosSistemaOperacional.data_processamento_venda_ini;
                parametro.dataFinal = dadosSistemaOperacional.data_processamento_venda_fim; // 2026-10-20
                yield service_1.default.ImportFromRedShift.start(parametro);
                return true;
            }
            catch (e) {
                return false;
            }
        });
    }
}
exports.default = batch_module_m0050;
