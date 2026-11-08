import { clsBase } from '../../../model/modelbase'
export default class TbOperacao extends clsBase {
        op_cdoperacao : number
        op_descricao : string
        em_cdempresa : number

        constructor() {
            super()
            this.op_cdoperacao = 0
            this.op_descricao = ''
            this.em_cdempresa = 0
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.op_cdoperacao = item?.op_cdoperacao
                this.op_descricao = item?.op_descricao
                this.em_cdempresa = item?.em_cdempresa
        }
    }
}