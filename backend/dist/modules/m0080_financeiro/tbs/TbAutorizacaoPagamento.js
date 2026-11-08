"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const model_1 = require("../../../model/model");
const modelbase_1 = require("../../../model/modelbase");
class tbAutorizacaoPagamento extends model_1.modelTb {
    constructor() {
        super();
        this.em_cdempresa = 0;
        this.autpgto_seq_pk = 0;
        this.autpgto_cdpessoabluesoft = 0;
        this.autpgto_tipo = "R";
        this.descritivo = "";
        this.autpgto_dataemissao = this.__defaultDateNow;
        this.autpgto_datavencimento = modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        this.autpgto_dataquitacao = modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        this.autpgto_valorfatura = 0;
        this.autpgto_valortotal = 0;
        this.autpgto_valorpago = 0;
        this.autpgto_nf_numero = `0`;
        this.autpgto_valorDescontoFinanceiro = 0;
        this.autpgto_numeroparcela = 0;
        this.autpgto_datapagamento = modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        this.autpgto_nf_dataemissao = modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        this.autpgto_valorliquido = 0;
        this.autpgto_datacriacao = modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        this.autpgto_datacancelamento = modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        this.autpgto_DtLog_update_redshift = modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        this.autpgto_status_cd = 0;
        this.autpgto_cancelada = 0;
        this.autpgto_codigobarra = "";
        this.competencia_cd = 0;
        this.plc_conta_cd = 0;
        this.plc_conta_cd_destino = 0;
        this.bordero_seq = 0;
        this.autpgto_juro_diario = 0;
        this.autpgto_valor_multa = 0;
        this.autpgto_valor_abatimento = 0;
        this.autpgto_valor_juros = 0;
        this.autpgto_valor_juros_fixo = 0;
        this.contrato_bluesoft_seq = 0;
        this.em_cdpessoabluesoft = 0;
    }
}
exports.default = tbAutorizacaoPagamento;
