import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbcrm_sorteio extends clsBase {
        crm_numero_oficial: number
        crm_so_cd: number
        crm_so_data_fim: Date
        crm_so_data_ini: Date
        crm_so_data_sorteio: Date
        crm_so_descricao: string
        crm_so_seq: number
        crm_so_temp_cd: number
        crm_so_tipo_cd: number
        dtlog_insert: Date
        dtlog_update: Date
        constructor() {
            super()
            this.crm_numero_oficial= 0
            this.crm_so_cd= 0
            this.crm_so_data_fim= this.__defaultDateNow 
            this.crm_so_data_ini= this.__defaultDateNow 
            this.crm_so_data_sorteio= this.__defaultDateNow 
            this.crm_so_descricao= ''
            this.crm_so_seq= 0
            this.crm_so_temp_cd= 0
            this.crm_so_tipo_cd= 0
            this.dtlog_insert= this.__defaultDateNow 
            this.dtlog_update= this.__defaultDateNow 
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.crm_numero_oficial = item?.crm_numero_oficial
                this.crm_so_cd = item?.crm_so_cd
                this.crm_so_data_fim = item?.crm_so_data_fim
                this.crm_so_data_ini = item?.crm_so_data_ini
                this.crm_so_data_sorteio = item?.crm_so_data_sorteio
                this.crm_so_descricao = item?.crm_so_descricao
                this.crm_so_seq = item?.crm_so_seq
                this.crm_so_temp_cd = item?.crm_so_temp_cd
                this.crm_so_tipo_cd = item?.crm_so_tipo_cd
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item?.dtlog_insert,`YYYY-MM-DD HH:mm:ss`)
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item?.dtlog_update,`YYYY-MM-DD HH:mm:ss`)
        }
    }
}