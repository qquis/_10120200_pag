import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbcrm_sorteio_tipo extends clsBase {
        crm_so_tipo_cd: number
        crm_so_tipo_descricao: string
        dtlog_insert: Date
        dtlog_update: Date
        constructor() {
            super()
            this.crm_so_tipo_cd= 0
            this.crm_so_tipo_descricao= ''
            this.dtlog_insert= this.__defaultDateNow 
            this.dtlog_update= this.__defaultDateNow 
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.crm_so_tipo_cd = item?.crm_so_tipo_cd
                this.crm_so_tipo_descricao = item?.crm_so_tipo_descricao
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item?.dtlog_insert,`YYYY-MM-DD HH:mm:ss`)
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item?.dtlog_update,`YYYY-MM-DD HH:mm:ss`)
        }
    }
}