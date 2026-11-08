import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbcrm_sorteio_temporada extends clsBase {
        crm_so_temp_cd: number
        crm_so_temp_descricao: string
        crm_so_temp_valor_minimo: number
        crm_so_temp_data_ini: Date
        crm_so_temp_data_fim: Date
        crm_so_temp_status: number
        constructor() {
            super()
            this.crm_so_temp_cd= 0
            this.crm_so_temp_descricao= ''
            this.crm_so_temp_valor_minimo= 0 
            this.crm_so_temp_status = 0 
            this.crm_so_temp_data_ini = this.__dataZERO
            this.crm_so_temp_data_fim = this.__dataZERO
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.crm_so_temp_cd = item?.crm_so_temp_cd
                this.crm_so_temp_descricao = item?.crm_so_temp_descricao
                this.crm_so_temp_valor_minimo = item?.crm_so_temp_valor_minimo
                this.crm_so_temp_status = item?.crm_so_temp_status
                this.crm_so_temp_data_ini = item?.crm_so_temp_data_ini
                this.crm_so_temp_data_fim = item?.crm_so_temp_data_fim

        }
    }
}