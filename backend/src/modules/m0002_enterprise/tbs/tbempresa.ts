import { clsBase } from '../../../model/modelbase'
export default class TbEmpresa extends clsBase {
        em_cdempresa : number
        em_descricao : string
        em_cdpessoabluesoft: number

        constructor() {
            super()
            this.em_cdempresa = 0
            this.em_descricao = ''
            this.em_cdpessoabluesoft = 0
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.em_cdempresa = item?.em_cdempresa
                this.em_descricao = item?.em_descricao
                this.em_cdpessoabluesoft = item?.em_cdpessoabluesoft
        }
    }
}