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
const _serviceNotificacao_1 = __importDefault(require("../../../modules/m0210_notificacao/service/_serviceNotificacao"));
const modelbase_1 = require("../../../model/modelbase");
const tbfaturamento_bluesoft_processo_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_processo"));
const myBase = new modelbase_1.clsBase();
class modelFaturamentoBluesoft_Processo extends tbfaturamento_bluesoft_processo_1.default {
    constructor() {
        super();
    }
    notificar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let scriptAtualizaStatusNotificacao = `update tbfaturamento_bluesoft_processo set notificado = 1 where fat_blue_processo_seq = ${this.fat_blue_processo_seq} `;
                yield myBase.myDataBase.pag.Execute(scriptAtualizaStatusNotificacao);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0050`, `modelFaturamentoBluesoft_Processo.notificar Error`, e);
            }
        });
    }
    notificar_bluesoftfaturamento_fv(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.binding(item);
                if (this.fat_blue_processo_seq && this.fat_blue_processo_seq > 0) {
                    let message = ``;
                    message += `*Prime OXAN* 🧑‍💼 \n`;
                    message += `\n`;
                    message += `Ola ${item.vendedor_nome_razao} \n`;
                    message += `*Notificação do processo: ${item.fat_blue_processo_tipo_descricao}* \n`;
                    message += `\n`;
                    message += `O pedido abaixo indicado foi faturado com corte \n`;
                    message += `Pedido: *${this.numeropedido}* \n`;
                    message += `Cliente: ${item.cliente_nome_razao} \n`;
                    message += `Valor Pedido: R$ ${item.valor_pedido} \n`;
                    message += `Valor Faturado: R$ ${item.valor_faturamento} \n`;
                    message += `Qtde Total de Itens: ${item.qtde_itens} \n`;
                    message += `Qtde itens com corte: ${item.qtde_itens_corte} \n`;
                    /*Gera a mensagem WHATS APP (DEFAULT _ CELULAR DO JOCELIO)*/
                    let numeroDD = item.celular_dd ? item.celular_dd : "11";
                    let numeroCelular = item.celular_numero ? item.celular_numero : "947420272";
                    if (numeroDD.length <= 1) {
                        numeroDD = `11`;
                        numeroCelular = `947420272`;
                    }
                    yield _serviceNotificacao_1.default.Criar({
                        notificacao_cd: 1000000009,
                        notificacao_send_tipo_cd: 100,
                        notificacao_email: "",
                        notificacao_email_subject: "",
                        notificacao_email_title: "",
                        notificacao_celular_dd_numero: parseInt(`${numeroDD}${numeroCelular}`),
                        notificacao_send_message: message
                    });
                    /*Atualiza o status da Notificação para enviado */
                    yield this.notificar();
                }
                else {
                    throw new Error(`Processo sem sequencia de processo válida para notificação.`);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0050`, `modelFaturamentoBluesoft.notificar Error`, e);
            }
        });
    }
}
exports.default = modelFaturamentoBluesoft_Processo;
