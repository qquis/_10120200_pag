import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfc_regrafiscalOperacao extends clsBase {
		fc_regrafiscal_cd: number
        df_nf_tipo: number
        constructor() {
            super()
            this.fc_regrafiscal_cd= 0
            this.df_nf_tipo= 0

        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.fc_regrafiscal_cd = item?.fc_regrafiscal_cd
                this.df_nf_tipo = item?.df_nf_tipo

        }
    }
}