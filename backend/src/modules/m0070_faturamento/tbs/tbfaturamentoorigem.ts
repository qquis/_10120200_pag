import { clsBase } from '../../../model/modelbase';
export default class tbfaturamentoorigem extends clsBase {
        seqfaturamento: number
        seqfaturamentoorigem: number
        cupomfiscalcancelador: number
        cupomfiscal: number
        df_nf_seq_blue: number
        dtlog_insert: Date
        dtlog_update: Date
        nfeseq: number
        numeronfedevolucao: number
        numeronfe: number
        numeropedido: number
        prazopgtomedio: number
        sat_ecf: number

        constructor() {
            super()
            this.seqfaturamento= 0
            this.seqfaturamentoorigem = 0
            this.cupomfiscal= 0
            this.cupomfiscalcancelador= 0
            this.df_nf_seq_blue= 0
            this.dtlog_insert= this.__defaultDateNow 
            this.dtlog_update= this.__defaultDateNow 
            this.nfeseq= 0
            this.numeronfe= 0
            this.numeronfedevolucao= 0
            this.numeropedido= 0
            this.prazopgtomedio= 0
            this.sat_ecf= 0 

        }
        async binding(item: any): Promise<void> {
            if (item) {
                this.seqfaturamento = item?.seqfaturamento
                this.seqfaturamentoorigem = item?.seqfaturamentoorigem
                this.cupomfiscalcancelador = item?.cupomfiscalcancelador
                this.cupomfiscal = item?.cupomfiscal
                this.df_nf_seq_blue = item?.df_nf_seq_blue
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item?.dtlog_insert,`YYYY-MM-DD HH:mm:ss`)
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item?.dtlog_update,`YYYY-MM-DD HH:mm:ss`)
                this.nfeseq = item?.nfeseq
                this.numeronfedevolucao = item?.numeronfedevolucao
                this.numeronfe = item?.numeronfe
                this.numeropedido = item?.numeropedido
                this.prazopgtomedio = item?.prazopgtomedio
                this.sat_ecf = item?.sat_ecf

        }
    }
}