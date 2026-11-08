
import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfc_pis extends clsBase {
        pis_cd: number
        pis_descricao: string
        cst: number
        pisAliquota: number
        pisReducao: number
        cofinsRelacionado: number
        tipo_entrada: number


        constructor() {
            super()
            this.pis_cd = 0
            this.pis_descricao = ''
            this.cst = 0
            this.pisAliquota = 0
            this.pisReducao = 0
            this.cofinsRelacionado = 0
            this.tipo_entrada = 0

        }
        async binding(item: any): Promise<void> {
                if (item) {
                    this.pis_cd = item?.pis_cd
                    this.cst = item?.cst
                    this.pisAliquota = item?.pisAliquota
                    this.pisReducao = item?.pisReducao
                    this.pis_descricao = item?.pis_descricao
                    this.cofinsRelacionado = item?.cofinsRelacionado
                }
        }
    }
                  