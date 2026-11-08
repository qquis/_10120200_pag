import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfc_figurafiscal_produto extends clsBase {
        fc_figurafiscal_cd: number
        fc_figurafiscal_versao: number
        prb_cdprodutobluesoft: number
        constructor() {
            super()
            this.fc_figurafiscal_cd= 0
            this.fc_figurafiscal_versao= 0
            this.prb_cdprodutobluesoft= 0
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.fc_figurafiscal_cd = item?.fc_figurafiscal_cd
                this.fc_figurafiscal_versao = item?.fc_figurafiscal_versao
                this.prb_cdprodutobluesoft = item?.prb_cdprodutobluesoft
        }
    }
}