import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'

export default class tbintegracao extends modelTb  {
    integracao_cd: number 
    integracao_descricao: string

    constructor () {
        super()
        this.integracao_cd = 0; 
        this.integracao_descricao = `` 
    }
}