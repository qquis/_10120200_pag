import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfc_figurafiscal extends clsBase {
        fc_figurafiscal_base: number
        fc_figurafiscal_cd: number
        fc_figurafiscal_codigo: string
        fc_figurafiscal_descricao: string
        fc_figurafiscal_versao: number
        constructor() {
            super()
            this.fc_figurafiscal_base= 0 
            this.fc_figurafiscal_cd= 0
            this.fc_figurafiscal_codigo= ''
            this.fc_figurafiscal_descricao= ''
            this.fc_figurafiscal_versao= 0 
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.fc_figurafiscal_cd = item?.fc_figurafiscal_cd
                this.fc_figurafiscal_codigo = item?.fc_figurafiscal_codigo
                this.fc_figurafiscal_base = item?.fc_figurafiscal_base
                this.fc_figurafiscal_descricao = item?.fc_figurafiscal_descricao
                this.fc_figurafiscal_versao = item?.fc_figurafiscal_versao


        }
    }
}