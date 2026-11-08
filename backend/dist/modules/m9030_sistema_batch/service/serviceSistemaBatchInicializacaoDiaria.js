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
const _serviceNotificacao_1 = __importDefault(require("../../m0210_notificacao/service/_serviceNotificacao"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M9030 - Sistema Batch | INICIALIZAÇÃO DIÁRIA";
const FLG_DEBUG_FILE_CONSOLE_LOG = `inicializacao_diaria`;
/*  ------------------------------------------------------------------------------------------- */
/*MODULOS*/
/* Serviços */
const batch_1 = __importDefault(require("../../m0080_financeiro/batch"));
const batch_2 = __importDefault(require("../../m0011_participante/batch"));
const batch_3 = __importDefault(require("../../m0004_forcavenda/batch"));
const batch_4 = __importDefault(require("../../m0150_estatistica/batch"));
const batch_5 = __importDefault(require("../../m0021_produtobluesoft/batch"));
const batch_6 = __importDefault(require("../../m0040_fiscal/batch"));
const batch_7 = __importDefault(require("../../m0085_zanthus/batch"));
const batch_8 = __importDefault(require("../../m0050_faturamento_bluesoft/batch"));
const batch_9 = __importDefault(require("../../m0005_forcavenda_meta/batch"));
const batch_10 = __importDefault(require("../../m0070_faturamento/batch"));
const batch_11 = __importDefault(require("../../m1000_informe/batch"));
class ServiceSistemaBatchInicializacaoDiaria {
    static start() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            let statusExecucao = true;
            try {
                let messageWhats = [];
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Início da execução`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield _serviceNotificacao_1.default.Criar({ notificacao_cd: 1009030001,
                    notificacao_send_tipo_cd: 100,
                    notificacao_send_message: `🔄 Atualização Diária | Start` });
                /*PRODUTO BLUESOFT*/
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | PRODUTO BLUESOFT - Inicializada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                statusExecucao = yield batch_5.default.AtualizacaoDiaria();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | PRODUTO BLUESOFT - Finalizada | Status    ${statusExecucao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                messageWhats.push(`✅ PRODUTO BLUESOFT - Finalizada | Status    ${statusExecucao}`);
                yield modelbase_1.clsTools._wait(1000);
                /*FISCAL*/
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | FISCAL - Inicializada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                statusExecucao = yield batch_6.default.AtualizacaoDiaria();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | FISCAL - Finalizada | Status    ${statusExecucao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                messageWhats.push(`✅ FISCAL - Finalizada | Status    ${statusExecucao}`);
                yield modelbase_1.clsTools._wait(1000);
                /*IMPORTACAO DE PARTICIPANTES*/
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | PARTICIPANTES - Inicializada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                statusExecucao = yield batch_2.default.AtualizacaoDiaria();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | PARTICIPANTES - Finalizada | Status    ${statusExecucao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                messageWhats.push(`✅ PARTICIPANTES - Finalizada | Status    ${statusExecucao}`);
                yield modelbase_1.clsTools._wait(1000);
                /*ZANTHUS*/
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | ZANTHUS - Inicializada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                statusExecucao = yield batch_7.default.AtualizacaoDiaria();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | ZANTHUS - Finalizada | Status    ${statusExecucao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                messageWhats.push(`✅ ZANTHUS - Finalizada | Status    ${statusExecucao}`);
                yield modelbase_1.clsTools._wait(1000);
                //FINANCEIRO - Importação do Movimento Caixa Diário
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | MOVIMENTO CAIXA - Inicializada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                statusExecucao = yield batch_1.default.AtualizacaoDiaria();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | MOVIMENTO CAIXA - Finalizada | Status    ${statusExecucao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                messageWhats.push(`✅ MOVIMENTO CAIXA - Finalizada | Status    ${statusExecucao}`);
                yield modelbase_1.clsTools._wait(1000);
                /*IMPORTAÇÃO FATURAMENTO BLUESOFT*/
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | FATURAMENTO BLUESOFT - Inicializada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                statusExecucao = yield batch_8.default.AtualizacaoDiaria();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | FATURAMENTO BLUESOFT - Finalizada | Status    ${statusExecucao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                messageWhats.push(`✅ FATURAMENTO BLUESOFT - Finalizada | Status    ${statusExecucao}`);
                yield modelbase_1.clsTools._wait(1000);
                /*IMPORTAÇÃO FATURAMENTO PROCESSAMENTO DE VENDA - FATURAMENTO PAG ---------$ $ $ $ $ $ $*/
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | FATURAMENTO CONTRATO - Inicializada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                statusExecucao = yield batch_10.default.AtualizacaoDiaria();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | FATURAMENTO CONTRATO - Finalizada | Status    ${statusExecucao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                messageWhats.push(`✅ FATURAMENTO CONTRATO - Finalizada | Status    ${statusExecucao}`);
                yield modelbase_1.clsTools._wait(1000);
                /*FORÇA DE VENDA*/
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | FORÇA DE VENDA - Inicializada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                statusExecucao = yield batch_3.default.AtualizacaoDiaria();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | FORÇA DE VENDA - Finalizada | Status    ${statusExecucao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                messageWhats.push(`✅ FORÇA DE VENDA - Finalizada | Status    ${statusExecucao}`);
                yield modelbase_1.clsTools._wait(1000);
                /*FORÇA DE VENDA META*/
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | FORÇA DE VENDA META - Inicializada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                statusExecucao = yield batch_9.default.AtualizacaoDiaria();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | FORÇA DE VENDA META - Finalizada | Status    ${statusExecucao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                messageWhats.push(`✅ FORÇA DE VENDA META - Finalizada | Status    ${statusExecucao}`);
                yield modelbase_1.clsTools._wait(1000);
                /*M1000 INFORME - IFS*/
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | M1000 INFORME - Inicializada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                statusExecucao = yield batch_11.default.AtualizacaoDiaria();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | M1000 INFORME - Finalizada | Status    ${statusExecucao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                messageWhats.push(`✅ M1000 INFORME - Finalizada | Status    ${statusExecucao}`);
                yield modelbase_1.clsTools._wait(1000);
                /*DADOS ESTATÍSTICOS*/
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | DADOS ESTATÍSTICOS - Inicializada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                statusExecucao = yield batch_4.default.AtualizacaoDiaria();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | DADOS ESTATÍSTICOS - Finalizada | Status    ${statusExecucao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                messageWhats.push(`✅ DADOS ESTATÍSTICOS - Finalizada | Status    ${statusExecucao}`);
                yield modelbase_1.clsTools._wait(1000);
                let messageWhatsStr = messageWhats.join('\n');
                yield _serviceNotificacao_1.default.Criar({ notificacao_cd: 1009030001,
                    notificacao_send_tipo_cd: 100,
                    notificacao_send_message: `🔄 Atualização Diária | Concluído\n\n${messageWhatsStr}` });
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M9030`, `ServiceSistemaBatchInicializacaoDiaria.start Error`, e);
                return false;
            }
            finally {
                return statusExecucao;
            }
        });
    }
}
exports.default = ServiceSistemaBatchInicializacaoDiaria;
