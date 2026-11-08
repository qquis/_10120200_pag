import { clsBase } from '../../../model/modelbase';
export default class tbrh_setor_operacional extends clsBase {
        dtlog_insert: Date
        dtlog_update: Date
        em_cdempresa: number
        op_cdoperacao: number
        rh_setor_operacional_cd: number
        rh_setor_operacional_descricao: string
        setor_operacional_cd: number
        constructor() {
            super()
            this.dtlog_insert= this.__defaultDateNow 
            this.dtlog_update= this.__defaultDateNow 
            this.em_cdempresa= 0
            this.op_cdoperacao= 0
            this.rh_setor_operacional_cd= 0
            this.rh_setor_operacional_descricao= ''
            this.setor_operacional_cd= 0
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item?.dtlog_insert,`YYYY-MM-DD HH:mm:ss`)
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item?.dtlog_update,`YYYY-MM-DD HH:mm:ss`)
                this.em_cdempresa = item?.em_cdempresa
                this.op_cdoperacao = item?.op_cdoperacao
                this.rh_setor_operacional_cd = item?.rh_setor_operacional_cd
                this.rh_setor_operacional_descricao = item?.rh_setor_operacional_descricao
                this.setor_operacional_cd = item?.setor_operacional_cd
        }
    }
}

