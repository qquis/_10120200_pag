import { clsTools } from "../../../model/modelbase";

import {modelTb} from '../../../model/model'
import myTools from "src/tools/Tools";

export default class tbfaturamentovipnotificacao extends modelTb {
            faturamento_vip_notificacao_seq: number
	        id : number
			notificacao_cd : number
            compra_status_id : number
            notificado: number


    constructor() {
        super()

        this.id = 0
        this.notificacao_cd = 0
        this.compra_status_id = 0
        this.notificado = 0
        this.faturamento_vip_notificacao_seq = 0


    }
    async binding(item: any): Promise<void> {
            if (item) {
                this.faturamento_vip_notificacao_seq = item.faturamento_vip_notificacao_seq
                this.id = item.id   
                this.notificacao_cd = item.notificacao_cd
                this.compra_status_id = item.compra_status_id
                this.notificado = item.notificado
            }                
        }       

    
}
