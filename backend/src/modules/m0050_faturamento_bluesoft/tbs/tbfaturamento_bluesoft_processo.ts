
import { de } from 'date-fns/locale';
import { clsTools, clsBase } from '../../../model/modelbase';


export default class tbfaturamento_bluesoft_processo extends clsBase {

		fat_blue_processo_seq: number 		
		op_cdoperacao: number				
		numeropedido: number 	 			
		numeropedido_fv: number 			
		fat_blue_status_cd: number			
		notificacao_cd: number             
		notificado: number

        constructor() 
        {
            super()
            this.fat_blue_processo_seq = 0
            this.op_cdoperacao = 0
            this.numeropedido = 0
            this.numeropedido_fv = 0
            this.fat_blue_status_cd = 0
            this.notificacao_cd = 0
            this.notificado = 0
        }
        async binding(item: any): Promise<void> {
        if (item) {
            this.fat_blue_processo_seq = item?.fat_blue_processo_seq
            this.op_cdoperacao = item?.op_cdoperacao
            this.numeropedido = item?.numeropedido
            this.numeropedido_fv = item?.numeropedido_fv
            this.fat_blue_status_cd = item?.fat_blue_status_cd
            this.notificacao_cd = item?.notificacao_cd
            this.notificado = item?.notificado

        }

    }       

}