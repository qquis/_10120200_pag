import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbcrm_sorteio_numero extends clsBase {
        crm_so_temp_cd: number
        crm_so_numero_seq: number	
        crm_so_numero_ordem: number
        crm_so_cupom_seq: number
        numero: number
        constructor() {
            super()
            this.crm_so_temp_cd= 0
            this.crm_so_numero_seq= 0
            this.crm_so_numero_ordem= 0
            this.crm_so_cupom_seq= 0
            this.numero= 0
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.crm_so_temp_cd = item?.crm_so_temp_cd
                this.crm_so_numero_seq = item?.crm_so_numero_seq
                this.crm_so_numero_ordem = item?.crm_so_numero_ordem
                this.crm_so_cupom_seq = item?.crm_so_cupom_seq
                this.numero = item?.numero
        }
    }
}