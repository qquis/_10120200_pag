import F0021_01_ProdutoBlueSoft_CRUD from 'src/modules/m0021_produtobluesoft/scriptpg/F0021_01_ProdutoBlueSoft_CRUD'
import {modelTb} from '../../../model/model'


export default 
  class tbautorizacaopagamento_abatimento extends modelTb {
    autpgto_seq_pk: number     
    autpgto_ab_seq: number
    autpgto_seq_pk_origem: number
    autpgto_ab_valor: number
    constructor() {   
        super()
        this.autpgto_seq_pk = 0
        this.autpgto_ab_seq = 0
        this.autpgto_seq_pk_origem = 0
        this.autpgto_ab_valor = 0
      }
    }