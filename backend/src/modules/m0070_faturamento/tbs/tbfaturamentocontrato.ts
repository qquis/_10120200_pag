import { clsBase, clsTools } from '../../../model/modelbase';

export default class tbfaturamentocontrato extends clsBase {

    contrato_seq: number              
    contrato_descricao: string        
    contrato_data: Date             
    contrato_tipo_cd: number          
    contrato_data_val_ini: Date     
    contrato_data_val_fim: Date     
    op_cdoperacao: number             
    cdparticipante_contratante: number
    seqfaturamento: number            
    seqfaturamentoorigem: number      
    faturamento_controle_seq: number  
    contrato_valor: number            
    contrato_uuid: string

    constructor () {
        super()
        this.contrato_seq = 0
        this.contrato_descricao = ''
        this.contrato_data = new Date()
        this.contrato_tipo_cd = 0
        this.contrato_data_val_ini = new Date()
        this.contrato_data_val_fim = new Date()
        this.op_cdoperacao = 0
        this.cdparticipante_contratante = 0
        this.seqfaturamento = 0
        this.seqfaturamentoorigem = 0
        this.faturamento_controle_seq = 0
        this.contrato_valor = 0
        this.contrato_uuid = ''

    }

    async binding(item: any): Promise<void> {
        try { 
        if (item) {
            this.contrato_seq = item?.contrato_seq
            this.contrato_descricao = item?.contrato_descricao
            this.contrato_data = item?.contrato_data
            this.contrato_tipo_cd = item?.contrato_tipo_cd
            this.contrato_data_val_ini = item?.contrato_data_val_ini
            this.contrato_data_val_fim = item?.contrato_data_val_fim
            this.op_cdoperacao = item?.op_cdoperacao
            this.cdparticipante_contratante = item?.cdparticipante_contratante
            this.seqfaturamento = item?.seqfaturamento
            this.seqfaturamentoorigem = item?.seqfaturamentoorigem
            this.faturamento_controle_seq = item?.faturamento_controle_seq
            this.contrato_valor = item?.contrato_valor
            this.contrato_uuid = item?.contrato_uuid
        } 
        } catch (e) {
            this.myTools.pagConsole(`tbfaturamentocontrato | binding \n Error: ${e}`);
            throw new Error(`tbfaturamentocontrato | binding \n Error: ${e}`);
        }
    }
    async scriptInsert(): Promise<void> {
        try {
            let sql = `
                        insert into tbfaturamentocontrato (
                            contrato_seq,
                            contrato_descricao,
                            contrato_data,
                            contrato_tipo_cd,
                            contrato_data_val_ini,
                            contrato_data_val_fim,
                            op_cdoperacao,
                            cdparticipante_contratante,
                            seqfaturamento,
                            seqfaturamentoorigem,
                            faturamento_controle_seq,
                            contrato_valor,
                            contrato_uuid
                        ) values (
                            ${this.contrato_seq},
                            '${this.contrato_descricao}',
                            '${this.contrato_data.toISOString()}',
                            ${this.contrato_tipo_cd},
                            '${ clsTools._datemomentDateToStr(this.contrato_data_val_ini, "YYYY-MM-DD") }',
                            '${ clsTools._datemomentDateToStr(this.contrato_data_val_fim, "YYYY-MM-DD") }',
                            ${this.op_cdoperacao},
                            ${this.cdparticipante_contratante},
                            ${this.seqfaturamento},
                            ${this.seqfaturamentoorigem},
                            ${this.faturamento_controle_seq},
                            ${this.contrato_valor},
                            '${this.contrato_uuid}'
                        )
            
            `




        } catch (e) {
            this.myTools.pagConsole(`tbfaturamentocontrato | insert \n Error: ${e}`);
            throw new Error(`tbfaturamentocontrato | insert \n Error: ${e}`);
        }
    }

    
}