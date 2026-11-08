import { clsBase } from '../../../model/modelbase'
export default class tbcompetencia extends clsBase {
        competencia_ano: number
        competencia_cd_ma: number
        competencia_cd: number
        competencia_data_fim: Date
        competencia_data_ini: Date
        competencia_descricao: string
        competencia_mes: number
        constructor() {
            super()
            this.competencia_ano= 0
            this.competencia_cd= 0
            this.competencia_cd_ma= 0
            this.competencia_data_fim= this.__defaultDateNow 
            this.competencia_data_ini= this.__defaultDateNow 
            this.competencia_descricao= ''
            this.competencia_mes= 0
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.competencia_ano = item?.competencia_ano
                this.competencia_cd = item?.competencia_cd
                this.competencia_cd_ma = item?.competencia_cd_ma
                this.competencia_data_fim = item?.competencia_data_fim
                this.competencia_data_ini = item?.competencia_data_ini
                this.competencia_descricao = item?.competencia_descricao
                this.competencia_mes = item?.competencia_mes
        }
    }
}