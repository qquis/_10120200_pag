import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'

export default class tbintegracao_tipo_info extends modelTb  {
    integracao_tipo_cd: number 
    sis_batch_cd: number 
    script_select: string 

    constructor () {
        super()
        this.integracao_tipo_cd = 0; 
        this.script_select = `` 

        this.sis_batch_cd= 0 
    }

    async binding(item: any): Promise<void> {
        try {
            if (item) {
                this.integracao_tipo_cd = item?.integracao_tipo_cd;
                this.sis_batch_cd = item?.sis_batch_cd
                this.script_select = item?.script_select
            }
        } catch (e) {
            myTools.pagConsole(`tbintegracao_tipo_info binding | \n ${e}`, true)
        }
    }
}