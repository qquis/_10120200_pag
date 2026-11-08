import { clsBase } from '../../../model/modelbase'
export default class tbresultado_conta extends clsBase {
        dtlog_insert: Date
        dtlog_update: Date
        r_conta_cd: number
        r_conta_descricao: string
        r_conta_lancamento_manual: number
        debitocredito: number
        r_grupo_cd: number
        r_rateio_cd: number
        constructor() {
            super()
            this.dtlog_insert= this.__defaultDateNow 
            this.dtlog_update= this.__defaultDateNow 
            this.r_conta_cd= 0
            this.r_conta_descricao= ''
            this.r_conta_lancamento_manual= 0 
            this.debitocredito= -1 
            this.r_grupo_cd= 0
            this.r_rateio_cd= 0
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item?.dtlog_insert,`YYYY-MM-DD HH:mm:ss`)
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item?.dtlog_update,`YYYY-MM-DD HH:mm:ss`)
                this.r_conta_cd = item?.r_conta_cd
                this.r_conta_descricao = item?.r_conta_descricao
                this.r_conta_lancamento_manual = item?.r_conta_lancamento_manual
                this.debitocredito = item?.debitocredito
                this.r_grupo_cd = item?.r_grupo_cd
                this.r_rateio_cd = item?.r_rateio_cd
        }
    }
}