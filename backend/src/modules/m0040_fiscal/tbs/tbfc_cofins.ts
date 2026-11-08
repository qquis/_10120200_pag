
import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfc_cofins extends clsBase {
        cofins_cd: number
        cofins_descricao: string
        cst: number
        cofinsAliquota: number
        cofinsReducao: number
        pisrelacionado: number
        tipo_entrada: number

        constructor() {
            super()
            this.cofins_cd = 0
            this.cofins_descricao = ''
            this.cst = 0
            this.cofinsAliquota = 0
            this.cofinsReducao = 0
            this.pisrelacionado = 0
            this.tipo_entrada = 0


        }
        async binding(item: any): Promise<void> {
                if (item) {
                    this.cofins_cd = item?.cofins_cd
                    this.cst = item?.cst
                    this.cofinsAliquota = item?.cofinsAliquota
                    this.cofinsReducao = item?.cofinsReducao
                    this.cofins_descricao = item?.cofins_descricao
                    this.pisrelacionado = item?.pisrelacionado

                }
        }
    }
                 