import { clsBase } from '../../../model/modelbase';
export default class tbrh_tipo_contrato extends clsBase {
        dtlog_insert: Date
        dtlog_update: Date
        rh_tipo_contrato_cd: number
        rh_tipo_contrato_descricao: string
        rh_tipo_contrato_legal: number
        constructor() {
            super()
            this.dtlog_insert= this.__defaultDateNow 
            this.dtlog_update= this.__defaultDateNow 
            this.rh_tipo_contrato_cd= 0
            this.rh_tipo_contrato_descricao= ''
            this.rh_tipo_contrato_legal= 0 
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item?.dtlog_insert,`YYYY-MM-DD HH:mm:ss`)
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item?.dtlog_update,`YYYY-MM-DD HH:mm:ss`)
                this.rh_tipo_contrato_cd = item?.rh_tipo_contrato_cd
                this.rh_tipo_contrato_descricao = item?.rh_tipo_contrato_descricao
                this.rh_tipo_contrato_legal = item?.rh_tipo_contrato_legal
        }
    }
}

