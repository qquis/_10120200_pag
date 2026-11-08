import { clsTools } from "../../../model/modelbase";

import {modelTb} from '../../../model/model'
import myTools from "src/tools/Tools";

export default class tbfaturamentovipcomprastatus extends modelTb {
            compra_status_id : number
            compra_status_descricao: string
            notificacao_cd : number


    constructor() {
        super()
        this.compra_status_id = 0
        this.compra_status_descricao = ""
        this.notificacao_cd = 0


    }
    async binding(item: any): Promise<void> {
            if (item) {
                this.compra_status_id = item.compra_status_id
                this.compra_status_descricao = item.compra_status_descricao
                this.notificacao_cd = item.notificacao_cd
            }                
        }       

    
}
