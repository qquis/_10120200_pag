import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbforca_venda_tabpreco extends clsBase {
            fv_tabelapreco_cd: number
            fv_tabelapreco_descricao: string


        constructor() {
            super()

            this.fv_tabelapreco_cd= 0
            this.fv_tabelapreco_descricao= ''
            
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.fv_tabelapreco_cd = item?.fv_tabelapreco_cd
                this.fv_tabelapreco_descricao = item?.fv_tabelapreco_descricao
            
            }
    }
}