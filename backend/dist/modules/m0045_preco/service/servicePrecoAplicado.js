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
const modelprecoaplicacao_1 = __importDefault(require("../model/modelprecoaplicacao"));
const modelsistema_ServiceBatch_1 = __importDefault(require("../../m9030_sistema_batch/model/modelsistema_ServiceBatch"));
const report_1 = __importDefault(require("../report/report"));
const myReportPreco = new report_1.default();
class servicePrecoAplicacao {
    constructor() {
    }
    bluesoftIntegrarPrecosPendentes(sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            return yield this.BlueSoftIntegrarPrecos(yield myReportPreco.PrecosAplicadosIntegracaoBlueSoftPendente(), sis_batch_run_seq);
        });
    }
    bluesoftIntegrarPrecos(sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            return yield this.BlueSoftIntegrarPrecos(yield myReportPreco.PrecosAplicadosIntegracaoBlueSoftPendente(), sis_batch_run_seq);
        });
    }
    BlueSoftIntegrarPrecos(mylist, sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let imodelsistema_batch = new modelsistema_ServiceBatch_1.default(0);
                yield imodelsistema_batch.modelConsultar(0, parseInt(`${sis_batch_run_seq}`));
                let list = [];
                try {
                    for (const [key, value] of Object.entries(mylist)) {
                        let i = new modelprecoaplicacao_1.default(0);
                        yield i.modelBindind(value);
                        yield list.push(i);
                    }
                    console.log(`Número de Itens processados: ${list.length}`);
                    let icount = 0;
                    let for_count = 0;
                    let for_max_batch = 50;
                    for (const item of list) {
                        if (sis_batch_run_seq >= 0) {
                            icount++;
                            for_count++;
                            if (for_count >= for_max_batch) {
                                let status = yield imodelsistema_batch.ModelStatus(parseInt(`${sis_batch_run_seq}`));
                                imodelsistema_batch.ModelRegistrarLog(`M0045_PRECO_${sis_batch_run_seq}`, `${icount}/${list.length}`);
                                if (!status) {
                                    Tools_1.default.pagConsoleLog("M0045_PRECO - Sisbatch está inativo e portando a execução será encerrada");
                                    imodelsistema_batch.ModelRegistrarLog(`M0045_PRECO_${sis_batch_run_seq}`, `Sisbatch está inativo e portando a execução será encerrada`);
                                    return list;
                                }
                                for_count = 0;
                            }
                        }
                        yield console.log(`Atualizando o item ${item.pr_cdproduto} - ${item.pr_descricao}`);
                        //await item.modelBlueSoftAtualizar()
                    }
                    return list;
                }
                catch (e) {
                    Tools_1.default.pagConsoleLog(`Reports | Error \n ${e}`);
                    return list;
                }
            }
            catch (e) {
                throw new Error("BindingPrecosAplicados");
            }
        });
    }
}
exports.default = servicePrecoAplicacao;
