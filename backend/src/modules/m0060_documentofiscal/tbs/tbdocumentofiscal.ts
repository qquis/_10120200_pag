import { modelTb } from "../../../model/model"

export default class tbdocumentofiscal extends modelTb {
    df_nf_seq_blue : number
    df_nf_numero: number

    constructor () {
        super()
        this.df_nf_seq_blue = 0
        this.df_nf_numero = 0;

    }

    
}