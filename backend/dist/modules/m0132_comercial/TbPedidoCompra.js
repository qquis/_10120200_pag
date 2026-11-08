"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class TbPedidoCompra {
    constructor(cm_pre_ped_seq, cm_pre_ped_seq_cd, cm_pre_ped_data, fabricante_cdpessoabluesoft, nome_razao, proc_log_seq, controle_reg_seq, controle_status_descricao, controle_etapa_descricao) {
        this.cm_pre_ped_seq = cm_pre_ped_seq;
        this.cm_pre_ped_seq_cd = cm_pre_ped_seq_cd;
        this.cm_pre_ped_data = cm_pre_ped_data;
        this.fabricante_cdpessoabluesoft = fabricante_cdpessoabluesoft;
        this.nome_razao = nome_razao;
        this.proc_log_seq = proc_log_seq;
        this.controle_reg_seq = controle_reg_seq;
        this.controle_etapa_descricao = controle_etapa_descricao;
        this.controle_status_descricao = controle_status_descricao;
    }
}
exports.default = TbPedidoCompra;
