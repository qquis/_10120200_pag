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
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const model_1 = require("../../../model/model");
class tbfaturamentovip extends model_1.modelTb {
    constructor() {
        super();
        this.cdpessoabluesoft_cliente = 0;
        this.id = 0;
        this.centro_distribuicao_id = 0;
        this.filial_id = 0;
        this.compra_status_id = 0;
        this.tipo_entrega_id = 0;
        this.cliente_id = 0;
        this.endereco_id = 0;
        this.usuario_id = 0;
        this.api_usuario_id = 0;
        this.external_compra_id = '';
        this.cnpj_gerador_pedido = '';
        this.foreign_key = '';
        this.parent_id = 0;
        this.data_entrega = new Date();
        this.data_entregue = new Date();
        this.data_faturamento = new Date();
        this.faturamento = false;
        this.tipo_fiscal = '';
        this.numero_fiscal = '';
        this.prevenda = false;
        this.numero_prevenda = '';
        this.frete = 0;
        this.taxa_de_servico = 0;
        this.valor_inicial = 0;
        this.valor_desconto = 0;
        this.observacoes_do_cliente = '';
        this.observacoes_do_atendimento = '';
        this.observacoes_na_entrega = '';
        this.intervalo = 0;
        this.qtd_itens = 0;
        this.qtd_produtos = 0;
        this.valor_produtos = 0;
        this.retirada_loja = false;
        this.notificacao_retirada = 0;
        this.antifraude_session_id = '';
        this.score_priorizacao = 0;
        this.informacoes_cashback = '';
        this.desconto_aplicado = false;
        this.fonte_compra = '';
        this.marketplace = 0;
        this.loja_autonoma = false;
        this.livre_do_represamento = false;
        this.valida = false;
        this.created = new Date();
        this.modified = new Date();
        this.uuid = '';
        this.codigo = '';
        this.status = '';
        this.valor_final = 0;
        this.tipo_pedido = '';
        this.volumes_frios = 0;
        this.volumes_comuns = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.cdpessoabluesoft_cliente = item === null || item === void 0 ? void 0 : item.cdpessoabluesoft_cliente;
                this.id = item === null || item === void 0 ? void 0 : item.id;
                this.centro_distribuicao_id = (item === null || item === void 0 ? void 0 : item.centro_distribuicao_id) ? item.centro_distribuicao_id : 0;
                this.filial_id = (item === null || item === void 0 ? void 0 : item.filial_id) ? item.filial_id : 0;
                this.compra_status_id = (item === null || item === void 0 ? void 0 : item.compra_status_id) ? item.compra_status_id : 0;
                this.tipo_entrega_id = (item === null || item === void 0 ? void 0 : item.tipo_entrega_id) ? item.tipo_entrega_id : 0;
                this.cliente_id = (item === null || item === void 0 ? void 0 : item.cliente_id) ? item.cliente_id : 0;
                this.endereco_id = (item === null || item === void 0 ? void 0 : item.endereco_id) ? item.endereco_id : 0;
                this.usuario_id = (item === null || item === void 0 ? void 0 : item.usuario_id) ? item.usuario_id : 0;
                this.api_usuario_id = (item === null || item === void 0 ? void 0 : item.api_usuario_id) ? item.api_usuario_id : 0;
                this.external_compra_id = (item === null || item === void 0 ? void 0 : item.external_compra_id) ? item.external_compra_id : '';
                this.cnpj_gerador_pedido = (item === null || item === void 0 ? void 0 : item.cnpj_gerador_pedido) ? item.cnpj_gerador_pedido : '';
                this.foreign_key = (item === null || item === void 0 ? void 0 : item.foreign_key) ? item.foreign_key : '';
                this.parent_id = (item === null || item === void 0 ? void 0 : item.parent_id) ? item.parent_id : 0;
                this.data_entrega = (item === null || item === void 0 ? void 0 : item.data_entrega) ? modelbase_1.clsTools._datemomentDatStrToDate(item.data_entrega, "YYYY-MM-DDTH:mm:ss") : modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01 00:00:00", "YYYY-MM-DDTH:mm:ss");
                this.data_entregue = (item === null || item === void 0 ? void 0 : item.data_entregue) ? modelbase_1.clsTools._datemomentDatStrToDate(item.data_entregue, "YYYY-MM-DDTH:mm:ss") : modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01 00:00:00", "YYYY-MM-DDTH:mm:ss");
                this.data_faturamento = (item === null || item === void 0 ? void 0 : item.data_faturamento) ? modelbase_1.clsTools._datemomentDatStrToDate(item.data_faturamento, "YYYY-MM-DDTH:mm:ss") : modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01 00:00:00", "YYYY-MM-DDTH:mm:ss");
                this.faturamento = (item === null || item === void 0 ? void 0 : item.faturamento) ? item.faturamento : 0;
                this.tipo_fiscal = (item === null || item === void 0 ? void 0 : item.tipo_fiscal) ? item.tipo_fiscal : '';
                this.numero_fiscal = (item === null || item === void 0 ? void 0 : item.numero_fiscal) ? item.numero_fiscal : '';
                this.prevenda = (item === null || item === void 0 ? void 0 : item.prevenda) ? item.prevenda : 0;
                this.numero_prevenda = (item === null || item === void 0 ? void 0 : item.numero_prevenda) ? item.numero_prevenda : '';
                this.frete = (item === null || item === void 0 ? void 0 : item.frete) ? item.frete : 0;
                this.taxa_de_servico = (item === null || item === void 0 ? void 0 : item.taxa_de_servico) ? item.taxa_de_servico : 0;
                this.valor_inicial = (item === null || item === void 0 ? void 0 : item.valor_inicial) ? item.valor_inicial : 0;
                this.valor_desconto = (item === null || item === void 0 ? void 0 : item.valor_desconto) ? item.valor_desconto : 0;
                this.observacoes_do_cliente = (item === null || item === void 0 ? void 0 : item.observacoes_do_cliente) ? item.observacoes_do_cliente : '';
                this.observacoes_do_atendimento = (item === null || item === void 0 ? void 0 : item.observacoes_do_atendimento) ? item.observacoes_do_atendimento : '';
                this.observacoes_na_entrega = (item === null || item === void 0 ? void 0 : item.observacoes_na_entrega) ? item.observacoes_na_entrega : '';
                this.intervalo = (item === null || item === void 0 ? void 0 : item.intervalo) ? item.intervalo : 0;
                this.qtd_itens = (item === null || item === void 0 ? void 0 : item.qtd_itens) ? item.qtd_itens : 0;
                this.qtd_produtos = (item === null || item === void 0 ? void 0 : item.qtd_produtos) ? item.qtd_produtos : 0;
                this.valor_produtos = (item === null || item === void 0 ? void 0 : item.valor_produtos) ? item.valor_produtos : 0;
                this.retirada_loja = (item === null || item === void 0 ? void 0 : item.retirada_loja) ? item.retirada_loja : 0;
                this.notificacao_retirada = (item === null || item === void 0 ? void 0 : item.notificacao_retirada) ? item.notificacao_retirada : 0;
                this.antifraude_session_id = (item === null || item === void 0 ? void 0 : item.antifraude_session_id) ? item.antifraude_session_id : '';
                this.score_priorizacao = (item === null || item === void 0 ? void 0 : item.score_priorizacao) ? item.score_priorizacao : 0;
                this.informacoes_cashback = (item === null || item === void 0 ? void 0 : item.informacoes_cashback) ? item.informacoes_cashback : '';
                this.desconto_aplicado = (item === null || item === void 0 ? void 0 : item.desconto_aplicado) ? item.desconto_aplicado : 0;
                this.fonte_compra = (item === null || item === void 0 ? void 0 : item.fonte_compra) ? item.fonte_compra : '';
                this.marketplace = (item === null || item === void 0 ? void 0 : item.marketplace) ? item.marketplace : 0;
                this.loja_autonoma = (item === null || item === void 0 ? void 0 : item.loja_autonoma) ? item.loja_autonoma : 0;
                this.livre_do_represamento = (item === null || item === void 0 ? void 0 : item.livre_do_represamento) ? item.livre_do_represamento : 0;
                this.valida = (item === null || item === void 0 ? void 0 : item.valida) ? item.valida : 0;
                this.created = modelbase_1.clsTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.created, "YYYY-MM-DDTH:mm:ss");
                this.modified = modelbase_1.clsTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.modified, "YYYY-MM-DDTH:mm:ss");
                this.uuid = (item === null || item === void 0 ? void 0 : item.uuid) ? item.uuid : '';
                this.codigo = (item === null || item === void 0 ? void 0 : item.codigo) ? item.codigo : '';
                this.status = (item === null || item === void 0 ? void 0 : item.status) ? item.status : '';
                this.valor_final = (item === null || item === void 0 ? void 0 : item.valor_final) ? item.valor_final : 0;
                this.tipo_pedido = (item === null || item === void 0 ? void 0 : item.tipo_pedido) ? item.tipo_pedido : '';
                this.volumes_frios = (item === null || item === void 0 ? void 0 : item.volumes_frios) ? item.volumes_frios : 0;
                this.volumes_comuns = (item === null || item === void 0 ? void 0 : item.volumes_comuns) ? item.volumes_comuns : 0;
            }
        });
    }
}
exports.default = tbfaturamentovip;
