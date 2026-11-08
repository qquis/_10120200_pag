import { clsTools, clsBase} from '../../../model/modelbase';
import ModelUserPermissao from '../model/modelUserPermissao';
import reportPermissaolist from '../report/reportSistemaPermissaoList';


export default class serviceSistemaPermissao {

    static async getFindPermissaoTarefa(parametros: any = {}, sis_ta_cd_find: number) : Promise<boolean> { 
        
        let find : boolean = false
        try {
            
            
            let list : ModelUserPermissao[] = await reportPermissaolist.getModel(parametros)
            
            if (list && list.length > 0) {
                list.find((item) => {
                    if (item.sis_ta_cd == sis_ta_cd_find) {
                        find = true
                        return true
                    }
                })
            }
        } catch (e) { 
            clsTools.PagErrorException(`serviceSistemaPermissao`, 'getFindPermissaoTarefa', e);   
            throw new Error(`serviceSistemaPermissao.getFindPermissaoTarefa`)       
        }

        finally { 
            return find
        }
    }  
}