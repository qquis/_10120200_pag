import { clsBase } from '../../../model/modelbase'

export default class tbautorizacaopagamentopag extends clsBase {
        aut_pgto_pag_uuid: string 
        aut_pgto_pag_data: Date
        aut_pgto_pag_data_pgto: Date
        aut_pgto_pag_seq: number
        aut_pgto_pag_valor: number
        cdparticipante: number
        competencia_cd: number
        dtlog_insert: Date
        em_cdempresa: number
        sis_us_seq: number
        r_conta_cd: number
        aut_pgto_pag_cancelado: number 
        aut_pgto_pag_cancelado_data: Date 
        aut_pgto_pag_cancelado_sis_us_seq : number
        aut_pgto_pag_obs: string 
        debitocredito: number
        aut_pgto_pag_tipo_cd : number
        constructor() {
            super()
            this.aut_pgto_pag_uuid = `` 
            this.aut_pgto_pag_data_pgto= this.__defaultDateNow 
            this.aut_pgto_pag_data= this.__defaultDateNow 
            this.aut_pgto_pag_seq= 0
            this.aut_pgto_pag_valor= 0 
            this.cdparticipante= 0
            this.competencia_cd= 0
            this.dtlog_insert= this.__defaultDateNow 
            this.em_cdempresa= 0
            this.sis_us_seq= 0
            this.r_conta_cd = 0
            this.aut_pgto_pag_cancelado = 0
            this.aut_pgto_pag_cancelado_data = this.__defaultDateNow 
            this.aut_pgto_pag_cancelado_sis_us_seq = 0
            this.aut_pgto_pag_obs = `` 
            this.debitocredito = -1
            this.aut_pgto_pag_tipo_cd = 1
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.aut_pgto_pag_uuid = item?.aut_pgto_pag_uuid
                this.aut_pgto_pag_data = item?.aut_pgto_pag_data
                this.aut_pgto_pag_data_pgto = item?.aut_pgto_pag_data_pgto
                this.aut_pgto_pag_seq = item?.aut_pgto_pag_seq
                this.aut_pgto_pag_valor = item?.aut_pgto_pag_valor
                this.cdparticipante = item?.cdparticipante
                this.competencia_cd = item?.competencia_cd
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item?.dtlog_insert,`YYYY-MM-DD HH:mm:ss`)
                this.em_cdempresa = item?.em_cdempresa
                this.sis_us_seq = item?.sis_us_seq
                this.r_conta_cd = item?.r_conta_cd
                this.aut_pgto_pag_cancelado = item?.aut_pgto_pag_cancelado
                this.aut_pgto_pag_cancelado_data =  this.myTools._datemomentDatStrToDate(item?.aut_pgto_pag_cancelado_data)
                this.aut_pgto_pag_cancelado_sis_us_seq = item?.aut_pgto_pag_cancelado_sis_us_seq
                this.aut_pgto_pag_obs = item?.aut_pgto_pag_obs
                this.debitocredito = item?.debitocredito
                this.aut_pgto_pag_tipo_cd = item?.aut_pgto_pag_tipo_cd
        }
    }
}