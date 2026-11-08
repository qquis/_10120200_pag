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
const modelbase_1 = require("../../../model/modelbase");
const bluesoftApiUrl_1 = __importDefault(require("../../Apis/bluesoftApi/url/bluesoftApiUrl"));
const modelAutorizacaoPagamento_1 = require("../model/modelAutorizacaoPagamento");
const model_1 = require("../../../model/model");
const modelsistema_ServiceBatch_1 = __importDefault(require("../../m9030_sistema_batch/model/modelsistema_ServiceBatch"));
class serviceAutorizacaoPgto {
    static Atualizar(sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            let listTbAutorizacaoPagamento = [];
            try {
                /*Controle Batch ---------------------------------------------------------------------- */
                let imodelsistema_batch = new modelsistema_ServiceBatch_1.default(0);
                if (sis_batch_run_seq !== 0)
                    yield imodelsistema_batch.modelConsultar(0, parseInt(`${sis_batch_run_seq}`));
                /*--------------------------------------------------------------------------------------*/
                let TipoPagamentoTotal = 1; //0 ate 1
                let TipoPagamentoItem = 0;
                for (TipoPagamentoItem = 0; TipoPagamentoItem <= TipoPagamentoTotal; TipoPagamentoItem++) {
                    let PaginaNumeroTotal = 30;
                    let PaginaNumeroAtual = 0;
                    let stringSqlPostregInteg = ``;
                    for (PaginaNumeroAtual = 0; PaginaNumeroAtual <= PaginaNumeroTotal; PaginaNumeroAtual++) {
                        //console.log(`Processando a pagina de N. ${PaginaNumeroAtual}`)
                        let TipoCobranca = TipoPagamentoItem == 0 ? `COBRANCA` : `PAGAMENTO`;
                        //console.log(`Atualizando a ${TipoCobranca}`)
                        let result = yield bluesoftApiUrl_1.default.api_get(`financeiro/duplicatas?especie=${TipoCobranca}&dataAtualizacaoInicial=${Tools_1.default.pagDateTime_getDateStringShortBrBarra()} 00:01:01&exibirDuplicatasCanceladas=true&currentPage=${PaginaNumeroAtual}`);
                        if (result) {
                            stringSqlPostregInteg = ``;
                            let myObject = Object.entries(result.data.data);
                            for (const [Key, value] of myObject) {
                                let registroAutorizacaoPagamento = new modelAutorizacaoPagamento_1.modelAutorizacaoPagamento();
                                registroAutorizacaoPagamento.bindingBlueSoftApi(value);
                                stringSqlPostregInteg += registroAutorizacaoPagamento.getSqlBlueSoftIntegrar();
                                listTbAutorizacaoPagamento.push(registroAutorizacaoPagamento);
                            }
                            if (stringSqlPostregInteg !== ``) {
                                yield model_1.modelReport.Execute(stringSqlPostregInteg);
                            }
                            if (sis_batch_run_seq !== 0) {
                                let status = yield imodelsistema_batch.ModelStatus(parseInt(`${sis_batch_run_seq}`));
                                imodelsistema_batch.ModelRegistrarLog(`M0080_FIN_IMP`, `M0080_FIN_IMP ${PaginaNumeroAtual}/${PaginaNumeroTotal}`);
                                if (!status) {
                                    modelbase_1.clsTools.pagConsole("M0080_Financeiro - Sisbatch está inativo e portando a execução será encerrada ");
                                    imodelsistema_batch.ModelRegistrarLog(`M0080_Financeiro_${sis_batch_run_seq}`, `Sisbatch está inativo e portando a execução será encerrada`);
                                    return listTbAutorizacaoPagamento;
                                }
                            }
                        }
                    }
                }
                return listTbAutorizacaoPagamento;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0080`, `ServiceFinanceiro | Atualizar`, e);
                return listTbAutorizacaoPagamento;
            }
        });
    }
    static AtualizarDuplicata(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let myDataBase = new modelbase_1.clsBase();
            let registroAutorizacaoPagamento = new modelAutorizacaoPagamento_1.modelAutorizacaoPagamento();
            try {
                let resultBlueSoft = yield bluesoftApiUrl_1.default.api_get(`financeiro/duplicatas?exibirDuplicatasCanceladas=true&duplicataKey=${parametros.autpgto_seq_pk}`);
                let item = yield myDataBase.myDataBase.RecordItem(resultBlueSoft.data.data, 0);
                if (item) {
                    yield registroAutorizacaoPagamento.bindingBlueSoftApi(item);
                    yield myDataBase.myDataBase.pag.Execute(registroAutorizacaoPagamento.getSqlBlueSoftIntegrar());
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0080`, `ServiceFinanceiro | AtualizarDuplicata`, e);
            }
            finally {
                return registroAutorizacaoPagamento;
            }
        });
    }
}
exports.default = serviceAutorizacaoPgto;
