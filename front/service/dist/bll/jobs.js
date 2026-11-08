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
const Tools_1 = __importDefault(require("../tools/Tools"));
//import m0055_faturamento from "./m0055_faturamento";
const PagApi = require("../../../Api");
const API = new PagApi();
function jobs(sis_batch_service_cd) {
    return __awaiter(this, void 0, void 0, function* () {
        Tools_1.default.pagConsoleLog("Lista de Batchs em Execução");
        try {
            if (sis_batch_service_cd == 1) {
                const resultado = yield API.m9030.ObterRunListPendente();
                for (const [Key, value] of Object.entries(resultado)) {
                    let itembatch = value;
                    Tools_1.default.pagConsoleLog(`Seq: ${itembatch.sistema_batch_run.sis_batch_run_seq} - Batch: ${itembatch.sis_batch_cd}`, true);
                    yield jobsBatchExecutar(value);
                }
            }
            if (sis_batch_service_cd == 2) {
                yield API.m0045.bluesoftintegrarprodutospendentes();
                console.log("servico 2 executado");
            }
        }
        catch (e) {
            throw new Error(`Job ${e}`);
        }
        finally {
            Tools_1.default.pagConsoleLog("Batchs finalizados");
        }
    });
}
function jobsBatchExecutar(itembatch) {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            itembatch = yield API.m9030.executarRun(itembatch);
            if (itembatch !== undefined) {
                switch (itembatch.sis_batch_cd) {
                    case 55001:
                        console.log(`Executando 55001`);
                        yield API.m0055.faturamento_zanthus_integrate_pendente();
                        break;
                    case 45001:
                        console.log(`Executando 45001`);
                        yield API.m0045.bluesoftintegrarprodutospendentes();
                        break;
                    case 45002:
                        console.log(`Executando 45002`);
                        yield API.m0045.bluesoftintegrarprodutosall();
                        break;
                }
            }
            itembatch = yield API.m9030.FinalizarRun(itembatch);
        }
        catch (e) {
            yield API.m9030.FinalizarRunError(itembatch);
            Tools_1.default.pagConsoleLog(`Batch - Execução com erro no batch Seq: ${itembatch.sistema_batch_run.sis_batch_run_seq} - Batch: ${itembatch.sis_batch_cd} \n ${e}`);
        }
    });
}
exports.default = jobs;
