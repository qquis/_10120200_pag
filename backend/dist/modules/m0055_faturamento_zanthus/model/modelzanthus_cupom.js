"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class modelzanthus_cupom {
    constructor() {
        this.data = new Date('1900-01-01');
        this.ecf = 0;
        this.numero_cupom = 0;
        this.id = 0;
        this.numero_cupom_cancelador = 0;
        this.nf_numero = 0;
        this.nf_serie = ``;
        this.nf_chave = ``;
        this.status_cancelado = 0;
        this.valor = 0;
        this.cpf_cnpj = ``;
        this.hora_ini = new Date('1900-01-01');
        this.hora_fim = new Date('1900-01-01');
        this.operador_codigo = 0;
        this.operador_nome = ``;
        this.voucher = ``;
        this.voucher_valor = 0;
        this.voucher_numero_itens = 0;
        this.tiponota_codigo = 0;
        this.tiponota_descricao = ``;
        this.valor_efetivo = 0;
        this.status_cancelado_descricao = ``;
        this.item_qtde = 0;
        this.item_valor = 0;
        this.item_desconto = 0;
        this.item_valor_liquido = 0;
    }
}
exports.default = modelzanthus_cupom;
