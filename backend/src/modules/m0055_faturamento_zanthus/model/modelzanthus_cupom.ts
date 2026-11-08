import { clsBase, clsTools } from "../../../model/modelbase";


export default class modelzanthus_cupom { 

        data: Date
        ecf: number
        numero_cupom: number
        id: number
        numero_cupom_cancelador: number
        nf_numero: number
        nf_serie: string
        nf_chave: string
        status_cancelado: number
        status_cancelado_descricao: string
        valor: number
        valor_efetivo: number
        cpf_cnpj: string
        hora_ini: Date
        hora_fim: Date
        operador_codigo: number
        operador_nome: string
        voucher: string
        voucher_valor: number
        voucher_numero_itens: number
        tiponota_codigo: number
        tiponota_descricao: string
        item_qtde: number
        item_valor: number
        item_desconto: number
        item_valor_liquido: number
        constructor() {
                this.data = new Date('1900-01-01')
                this.ecf = 0
                this.numero_cupom = 0
                this.id = 0
                this.numero_cupom_cancelador = 0
                this.nf_numero = 0
                this.nf_serie = ``
                this.nf_chave = ``
                this.status_cancelado = 0
                this.valor = 0
                this.cpf_cnpj = ``
                this.hora_ini = new Date('1900-01-01')
                this.hora_fim = new Date('1900-01-01')
                this.operador_codigo = 0
                this.operador_nome = ``
                this.voucher = ``
                this.voucher_valor = 0
                this.voucher_numero_itens = 0
                this.tiponota_codigo = 0
                this.tiponota_descricao = ``
                this.valor_efetivo = 0
                this.status_cancelado_descricao = ``
                this.item_qtde = 0
                this.item_valor = 0
                this.item_desconto = 0
                this.item_valor_liquido = 0
        }


        

}