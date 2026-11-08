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
const modelbase_1 = require("../../../model/modelbase");
const modelsistema_nucleo_procedimento_1 = __importDefault(require("../model/modelsistema_nucleo_procedimento"));
const _serviceNotificacao_1 = __importDefault(require("../../../modules/m0210_notificacao/service/_serviceNotificacao"));
/* Serviços */
const batch_1 = __importDefault(require("../../m0080_financeiro/batch"));
const batch_2 = __importDefault(require("../../m0095_integracao/batch"));
const batch_3 = __importDefault(require("../../../modules/m0045_preco/batch"));
const batch_4 = __importDefault(require("../../m0011_participante/batch"));
const batch_5 = __importDefault(require("../../m0004_forcavenda/batch"));
const batch_6 = __importDefault(require("../../m0150_estatistica/batch"));
const batch_7 = __importDefault(require("../../m0085_zanthus/batch"));
class sistemaServiceProcedimento {
    static startlist(modelsistema_batch_select) {
        return __awaiter(this, void 0, void 0, function* () {
            yield _serviceNotificacao_1.default.CriarMailBasico('eliassilva@oxan.com.br', `Batch (Com procedimentos)`, `Início da execução do Batch - ${modelsistema_batch_select.sistema_batch.sis_batch_descricao}`, `Número de Procedimentos - ${modelsistema_batch_select.listProcedimentos.length}`);
            try {
                //console.log(modelsistema_batch_select.listProcedimentos)
                for (const item of modelsistema_batch_select.listProcedimentos) {
                    yield this.start(item);
                    yield modelbase_1.clsTools._wait(4000);
                }
                let message = modelsistema_batch_select.listProcedimentos.map((item) => {
                    return `Procedimento: ${item.sis_nucleo_prc_cd} - ${item.sis_nucleo_prc_descricao} - Error: ${item.ErrorMessage} \n`;
                });
                yield _serviceNotificacao_1.default.CriarMailBasico('eliassilva@oxan.com.br', `Batch (Com procedimentos)`, `Finalização do Batch - ${modelsistema_batch_select.sistema_batch.sis_batch_descricao}`, `Número de Procedimentos - ${message}`);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M9030`, `sistemaServiceProcedimento.start Error`, e);
            }
            finally {
                yield modelbase_1.clsTools._wait(2000);
                return;
            }
        });
    }
    static start(nucleo_procedimento) {
        return __awaiter(this, void 0, void 0, function* () {
            let statusExecucao = false;
            try {
                if (!nucleo_procedimento.__atualizado)
                    yield nucleo_procedimento.consultar();
                yield nucleo_procedimento.iniciarExecucao();
                switch (nucleo_procedimento.sis_nucleo_prc_cd) {
                    //INTEGRAÇÃO _ IMPORTAÇÃO GERAL DE PRODUTOS
                    case 95101:
                        yield this.localConsole(`Procedimento 95101 | Executando IMPORTAÇÃO GERAL DE PRODUTOS`);
                        statusExecucao = yield batch_2.default.Procedimento(nucleo_procedimento);
                        break;
                    //APLICAÇÃO DE PREÇOS 
                    case 45060:
                        yield this.localConsole(`Procedimento 45060 | Executando APLICAÇÃO DE PREÇOS`);
                        statusExecucao = yield batch_3.default.Procedimento(nucleo_procedimento);
                        break;
                    //INTEGRAÇÃO _ EXPORTAÇÃO DE PRODUTOS PENDENTES PARA A ZANTHUS
                    case 85002:
                        yield this.localConsole(`Procedimento 85002 | Executando EXPORTAÇÃO DE PRODUTOS PENDENTES PARA A ZANTHUS`);
                        statusExecucao = yield batch_7.default.Procedimento(nucleo_procedimento);
                        break;
                    //INTEGRAÇÃO _ EXPORTAÇÃO DE PRODUTOS PENDENTES PARA A BLUESOFT _ API 
                    case 95011:
                        yield this.localConsole(`Procedimento 95011 | Executando EXPORTAÇÃO DE PRODUTOS PENDENTES PARA A BLUESOFT _ API`);
                        statusExecucao = yield batch_2.default.Procedimento(nucleo_procedimento);
                        break;
                    //FINANCEIRO _ IMPORTAÇÃO DO MOVIMENTO CAIXA/FINANCEIRO DIÁRIO
                    case 8002:
                        yield this.localConsole(`Procedimento 8002 | Executando IMPORTAÇÃO DO MOVIMENTO CAIXA/FINANCEIRO`);
                        statusExecucao = yield batch_1.default.Procedimento(nucleo_procedimento);
                        break;
                    /*Importação de Participantes*/
                    case 1105:
                        yield this.localConsole(`Procedimento 1105 | Executando IMPORTAÇÃO DE PARTICIPANTES`);
                        statusExecucao = yield batch_4.default.Procedimento(nucleo_procedimento);
                        break;
                    case 10004001:
                        yield this.localConsole(`Procedimento 10004001| Executando IMPORTAÇÃO DE DADOS DO FORÇA DE VENDA`);
                        statusExecucao = yield batch_5.default.Procedimento(nucleo_procedimento);
                        break;
                    case 10150010:
                        yield this.localConsole(`Procedimento 10150010 - DADOS ESTATÍSTICOS`);
                        statusExecucao = yield batch_6.default.startProcedimento(nucleo_procedimento);
                        break;
                }
                if (!statusExecucao) {
                    nucleo_procedimento.ErrorMessage = `Erro na execução do procedimento! Contate a equipe de suporte.`;
                }
                else {
                    nucleo_procedimento.ErrorMessage = ``;
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M9030`, `sistemaServiceProcedimento.start Error`, e);
            }
            finally {
                yield modelbase_1.clsTools._wait(2000);
                yield nucleo_procedimento.finalizarExecucao();
                yield modelbase_1.clsTools._wait(4000);
                return;
            }
        });
    }
    static startProcedimento(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let nucleo_procedimento = new modelsistema_nucleo_procedimento_1.default();
                nucleo_procedimento.sis_nucleo_prc_cd = parametro.sis_nucleo_prc_cd;
                yield nucleo_procedimento.consultar();
                yield this.start(nucleo_procedimento);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M9030`, `sistemaServiceProcedimento.startProcedimento Error`, e);
            }
        });
    }
    static localConsole(message) {
        return __awaiter(this, void 0, void 0, function* () {
            modelbase_1.clsTools.pagConsole(`M9030 Sistema Batch (Execução de Procedimento via M9030) _ Procedimento:  ${message}`, false, false);
        });
    }
}
exports.default = sistemaServiceProcedimento;
