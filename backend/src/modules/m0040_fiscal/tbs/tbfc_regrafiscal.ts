import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfc_regrafiscal extends clsBase {
	    tipo: string
		fc_regrafiscal_cd: number
		cfop: number
		fc_figurafiscal_cd: number
		vigenciainicial: Date
		fc_regrafiscal_status: number
        icms_cd: number
        pis_cd: number
        cofins_cd: number
        regimeincidenciapiscofins: string
        tipocliente: string
        constructor() {
            super()
            this.tipo= '' 
            this.fc_regrafiscal_cd= 0
            this.cfop= 0
            this.fc_figurafiscal_cd= 0
            this.vigenciainicial= new Date(0)
            this.fc_regrafiscal_status= 0 
            this.icms_cd= 0
            this.pis_cd= 0
            this.cofins_cd= 0
            this.regimeincidenciapiscofins = ''
            this.tipocliente = ''

        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.tipo = item?.tipo
                this.fc_regrafiscal_cd = item?.fc_regrafiscal_cd
                this.cfop = item?.cfop
                this.fc_figurafiscal_cd = item?.fc_figurafiscal_cd
                this.vigenciainicial = item?.vigenciainicial
                this.fc_regrafiscal_status = item?.fc_regrafiscal_status
                this.icms_cd = item?.icms_cd
                this.regimeincidenciapiscofins = item?.regimeincidenciapiscofins
                this.tipocliente = item?.tipocliente
                this.pis_cd = item?.pis_cd
                this.cofins_cd = item?.cofins_cd
            }

        }
    }
