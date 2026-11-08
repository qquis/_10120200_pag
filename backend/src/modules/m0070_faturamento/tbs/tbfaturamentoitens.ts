import { clsBase } from '../../../model/modelbase';
export default class tbfaturamentoitens extends clsBase {
        dtlog_insert: Date
        dtlog_update: Date
        ec_valorcusto_faturamento_total: number
        ec_valorcusto_precificacao_total: number
        embalagemcompraqtde: number
        embalagemestoqueqtde: number
        pr_cdproduto: number
        seqfaturamentoorigem: number
        seqitem: number
        statusfaturamentoitem: number
        valortotaldescontofinanceiro: number
        valortotalfaturamentobase: number
        valortotalfaturamentobruto: number
        valortotalfaturamentoliquido: number
        valortotalfaturamento: number
        valortotalsubsidiosaplicados: number
        valortotalsubsidioscorrentes: number

        constructor() {
            super()
            this.dtlog_insert= this.__defaultDateNow 
            this.dtlog_update= this.__defaultDateNow 
            this.ec_valorcusto_faturamento_total= 0 
            this.ec_valorcusto_precificacao_total= 0 
            this.embalagemcompraqtde= 0 
            this.embalagemestoqueqtde= 0 
            this.pr_cdproduto= 0
            this.seqfaturamentoorigem= 0
            this.seqitem= 0
            this.statusfaturamentoitem= 0 
            this.valortotaldescontofinanceiro= 0 
            this.valortotalfaturamento= 0 
            this.valortotalfaturamentobase= 0 
            this.valortotalfaturamentobruto= 0 
            this.valortotalfaturamentoliquido= 0 
            this.valortotalsubsidiosaplicados= 0 
            this.valortotalsubsidioscorrentes= 0 

        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item?.dtlog_insert,`YYYY-MM-DD HH:mm:ss`)
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item?.dtlog_update,`YYYY-MM-DD HH:mm:ss`)
                this.ec_valorcusto_faturamento_total = item?.ec_valorcusto_faturamento_total
                this.ec_valorcusto_precificacao_total = item?.ec_valorcusto_precificacao_total
                this.embalagemcompraqtde = item?.embalagemcompraqtde
                this.embalagemestoqueqtde = item?.embalagemestoqueqtde
                this.pr_cdproduto = item?.pr_cdproduto
                this.seqfaturamentoorigem = item?.seqfaturamentoorigem
                this.seqitem = item?.seqitem
                this.statusfaturamentoitem = item?.statusfaturamentoitem
                this.valortotaldescontofinanceiro = item?.valortotaldescontofinanceiro
                this.valortotalfaturamentobase = item?.valortotalfaturamentobase
                this.valortotalfaturamentobruto = item?.valortotalfaturamentobruto
                this.valortotalfaturamento = item?.valortotalfaturamento
                this.valortotalfaturamentoliquido = item?.valortotalfaturamentoliquido
                this.valortotalsubsidiosaplicados = item?.valortotalsubsidiosaplicados
                this.valortotalsubsidioscorrentes = item?.valortotalsubsidioscorrentes

        }
    }
}