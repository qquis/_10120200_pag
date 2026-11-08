import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbforca_venda_prazopgto extends clsBase {
        fv_prazopgto_cd: number
        fv_prazopgto_descricao: string
        custofinanceiro: number
        coefcustofinanceiro: number
        tipo: string 
        tipocusto: string 
        status: number
        versao: number
        listapadraoorder: number
        constructor() {
            super()
            this.fv_prazopgto_cd= 0
            this.fv_prazopgto_descricao= ''
            this.custofinanceiro= 0
            this.coefcustofinanceiro= 0
            this.tipo= ''
            this.tipocusto= ''
            this.status= 0
            this.versao= 0
            this.listapadraoorder = 0
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.fv_prazopgto_cd = item?.fv_prazopgto_cd
                this.fv_prazopgto_descricao = item?.fv_prazopgto_descricao
                this.custofinanceiro = item?.custofinanceiro
                this.coefcustofinanceiro = item?.coefcustofinanceiro
                this.tipo = item?.tipo
                this.tipocusto = item?.tipocusto
                this.status = item?.status
                this.versao = item?.versao
                this.listapadraoorder = item?.listapadraoorder
            }
    }
}