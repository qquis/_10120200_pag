import { clsBase } from '../../../model/modelbase'
export default class tbmovimento_caixa_bluesoft extends clsBase {
        administradora_cdpessoabluesoft: number
        caixa_bluesoft_cd: number
        dtlog_insert: Date
        dtlog_update: Date
        em_cdempresa: number
        mv_caixa_autorizacao_cd: number
        mv_caixa_bluesoft_tipo_cd: number
        mv_caixa_cpf: string 
        mv_caixa_data: Date
        mv_caixa_data_deposito: Date
        mv_caixa_data_entrega: Date
        mv_caixa_data_previsao_credito: Date
        mv_caixa_descricao: string
        mv_caixa_nsu: string
        mv_caixa_seq: number
        mv_caixa_updated_at: Date
        mv_caixa_valor: number
        mv_caixa_vl_juros: number
        mv_caixa_vl_parcela: number
        mv_caixa_vl_taxa: number
        mv_caixa_vl_taxa_operacao: number
        sat_ecf: number
        debitocredito: number
        constructor() {
            super()
            this.administradora_cdpessoabluesoft= 0
            this.caixa_bluesoft_cd= 0
            this.dtlog_insert= this.__defaultDateNow 
            this.dtlog_update= this.__defaultDateNow 
            this.em_cdempresa= 0
            this.mv_caixa_autorizacao_cd = 0
            this.mv_caixa_bluesoft_tipo_cd= 0
            this.mv_caixa_cpf= ''
            this.mv_caixa_data_deposito= this.__defaultDateNow 
            this.mv_caixa_data_entrega= this.__defaultDateNow 
            this.mv_caixa_data_previsao_credito= this.__defaultDateNow 
            this.mv_caixa_data= this.__defaultDateNow 
            this.mv_caixa_descricao= ''
            this.mv_caixa_nsu= ''
            this.mv_caixa_seq= 0
            this.mv_caixa_updated_at= this.__defaultDateNow 
            this.mv_caixa_valor= 0 
            this.mv_caixa_vl_juros= 0 
            this.mv_caixa_vl_parcela= 0 
            this.mv_caixa_vl_taxa= 0 
            this.mv_caixa_vl_taxa_operacao= 0 
            this.sat_ecf= 0
            this.debitocredito = 0
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.administradora_cdpessoabluesoft = item?.administradora_cdpessoabluesoft
                this.caixa_bluesoft_cd = item?.caixa_bluesoft_cd
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item?.dtlog_insert,`YYYY-MM-DD HH:mm:ss`)
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item?.dtlog_update,`YYYY-MM-DD HH:mm:ss`)
                this.em_cdempresa = item?.em_cdempresa
                this.mv_caixa_autorizacao_cd = item?.mv_caixa_autorizacao_cd
                this.mv_caixa_bluesoft_tipo_cd = item?.mv_caixa_bluesoft_tipo_cd
                this.mv_caixa_cpf = item?.mv_caixa_cpf
                this.mv_caixa_data_deposito = item?.mv_caixa_data_deposito
                this.mv_caixa_data_entrega = item?.mv_caixa_data_entrega
                this.mv_caixa_data = item?.mv_caixa_data
                this.mv_caixa_data_previsao_credito = item?.mv_caixa_data_previsao_credito
                this.mv_caixa_descricao = item?.mv_caixa_descricao
                this.mv_caixa_nsu = item?.mv_caixa_nsu
                this.mv_caixa_seq = item?.mv_caixa_seq
                this.mv_caixa_updated_at = this.myTools._datemomentDatStrToDate(item?.mv_caixa_updated_at,`YYYY-MM-DD HH:mm:ss`)
                this.mv_caixa_valor = item?.mv_caixa_valor
                this.mv_caixa_vl_juros = item?.mv_caixa_vl_juros
                this.mv_caixa_vl_parcela = item?.mv_caixa_vl_parcela
                this.mv_caixa_vl_taxa = item?.mv_caixa_vl_taxa
                this.mv_caixa_vl_taxa_operacao = item?.mv_caixa_vl_taxa_operacao
                this.sat_ecf = item?.sat_ecf
                this.debitocredito = item?.debitocredito
        }
    }
}