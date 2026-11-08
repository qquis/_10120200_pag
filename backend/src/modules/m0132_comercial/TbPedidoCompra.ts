
export default class TbPedidoCompra {
    cm_pre_ped_seq: number
    cm_pre_ped_seq_cd: number 
    cm_pre_ped_data: number 
    fabricante_cdpessoabluesoft: number 
    nome_razao: string 
    proc_log_seq: number 
    controle_reg_seq: number 
    controle_status_descricao: number 
    controle_etapa_descricao: string 
    constructor (
        cm_pre_ped_seq: number,
        cm_pre_ped_seq_cd: number ,
        cm_pre_ped_data: number, 
        fabricante_cdpessoabluesoft: number, 
        nome_razao: string ,
        proc_log_seq: number, 
        controle_reg_seq: number ,
        controle_status_descricao: number ,
        controle_etapa_descricao: string ,
    ) {
        this.cm_pre_ped_seq = cm_pre_ped_seq
        this.cm_pre_ped_seq_cd = cm_pre_ped_seq_cd
        this.cm_pre_ped_data = cm_pre_ped_data
        this.fabricante_cdpessoabluesoft = fabricante_cdpessoabluesoft
        this.nome_razao = nome_razao
        this.proc_log_seq = proc_log_seq
        this.controle_reg_seq = controle_reg_seq
        this.controle_etapa_descricao = controle_etapa_descricao
        this.controle_status_descricao = controle_status_descricao
    }
}

