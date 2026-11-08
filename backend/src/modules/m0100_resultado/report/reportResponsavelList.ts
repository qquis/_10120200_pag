import { clsTools, clsBase} from '../../../model/modelbase';
import scriptdbResultadoResponvael from '../scriptdb/scriptdbResultadoResponsavel'
export default class reportResponsavelList{
    static sql (parametros: any = {}) : string { return scriptdbResultadoResponvael.get(parametros)}
    static async get(parametros: any = {}) {
        const myTools = new clsBase();
        try {
                let result = await myTools.myDataBase.pag.DataGet(this.sql(parametros))
                    return result
                
        } catch (e) {
            clsTools.PagErrorException(`reportDREResponsavelList`, 'sql', e);
        }
    }

}