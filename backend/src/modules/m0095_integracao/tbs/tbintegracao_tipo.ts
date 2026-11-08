import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'

export default class tbintegracao_tipo extends modelTb  {
    integracao_tipo_cd: number 
    integracao_cd: number
    integracao_tipo_descricao: string
    zanthus: number
    bluesoft_redshift: number
    bluesoft_api: number  
    tipo_export: number
    sis_batch_cd: number 

    constructor () {
        super()
        this.integracao_tipo_cd = 0; 
        this.integracao_cd = 0;
        this.integracao_tipo_descricao = `` 
        this.zanthus= 0
        this.bluesoft_redshift= 0
        this.bluesoft_api= 0  
        this.tipo_export= 0

        this.sis_batch_cd= 0 
    }

    async binding(item: any): Promise<void> {
        try {
            if (item) {
                this.integracao_tipo_cd = item?.integracao_tipo_cd;
                this.integracao_cd = item?.integracao_cd
                this.integracao_tipo_descricao = item?.integracao_tipo_cd
                this.zanthus = item?.zanthus
                this.bluesoft_redshift = item?.bluesoft_redshift
                this.bluesoft_api = item?.bluesoft_api
                this.tipo_export = item?.tipo_export
                this.sis_batch_cd = item?.sis_batch_cd
            }
        } catch (e) {
            myTools.pagConsole(`tbintegracao_tipo binding | \n ${e}`, true)
        }
    }
}