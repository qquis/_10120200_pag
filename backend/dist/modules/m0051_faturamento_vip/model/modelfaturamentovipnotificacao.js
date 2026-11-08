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
const tbfaturamentoVipNotificacao_1 = __importDefault(require("../tbs/tbfaturamentoVipNotificacao"));
class modelfaturamentovipNotificacao extends tbfaturamentoVipNotificacao_1.default {
    constructor() {
        super();
        this.data_entrega = new Date();
        this.qtd_itens = 0;
        this.qtd_produtos = 0;
        this.valor_final = 0;
        this.compra_status_descricao = "";
        this.vip_nome = "";
        this.cliente_id = 0;
    }
    modelBinding(item) {
        if (item) {
            super.binding(item);
            this.data_entrega = item.data_entrega;
            this.qtd_itens = item.qtd_itens;
            this.qtd_produtos = item.qtd_produtos;
            this.valor_final = item.valor_final;
            this.compra_status_descricao = item.compra_status_descricao;
            this.vip_nome = item.vip_nome;
            this.cliente_id = item.cliente_id;
        }
    }
    notificar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myDataBase = new modelbase_1.clsBase();
                let message = ``;
                switch (this.compra_status_id) {
                    case 13:
                        message += `*VIP/E-commerce | Pedido Aguardando Separação* 📦 \n`;
                        break;
                    case 11:
                        message += `*VIP/E-commerce | Pedido Em atendimento* 🧑‍💼 \n`;
                        break;
                    case 38:
                        message += `*VIP/E-commerce | Pedido em Análise de antifraude* ❌🔍 \n`;
                        break;
                    default:
                        message += `*VIP/E-commerce* \n`;
                        break;
                }
                message += `Numero do Pedido *${this.id}* \n`;
                message += `Cliente *${this.cliente_id} - ${this.vip_nome}* \n`;
                message += `Data de Entrega *${modelbase_1.clsTools._datemomentDateToStr(this.data_entrega, "dddd, DD/MM/YYYY HH:mm")}* \n`;
                message += `Quantidade de Itens *${this.qtd_itens}* \n `;
                message += `Quantidade de Produtos *${this.qtd_produtos}* \n`;
                message += `Status do Pedido *${this.compra_status_descricao}* \n`;
                message += `Valor Final *${this.valor_final}* \n`;
                yield _serviceNotificacao_1.default.Criar({ notificacao_cd: 1000510010, notificacao_send_tipo_cd: 100, notificacao_send_message: message });
                let sqlAtualizarPendenciaNotificacao = `UPDATE tbfaturamento_vip_notificacao set notificado = 1 where faturamento_vip_notificacao_seq = ${this.faturamento_vip_notificacao_seq}`;
                yield myDataBase.myDataBase.pag.Execute(sqlAtualizarPendenciaNotificacao);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`F0051 - Faturamento VIP`, `modelfaturamentovip.notificar()`, e, true);
                throw new Error(`modules | Faturamento VIP | Error ${e.message}`);
            }
        });
    }
}
exports.default = modelfaturamentovipNotificacao;
