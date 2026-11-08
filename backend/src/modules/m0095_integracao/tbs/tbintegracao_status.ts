import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'

export default class tbintegracao_status extends modelTb  {
    integracao_status_cd: number 
    integracao_status_descricao: string

    constructor () {
        super()
        this.integracao_status_cd = 0; 
        this.integracao_status_descricao = `` 
    }
}