import { clsTools, clsBase} from '../../../model/modelbase';
import scriptdbResultadoRateio from '../scriptdb/scriptdbResultadoRateio';
export default class reportRateioList{
    static sql (parametros: any = {}) : string { return scriptdbResultadoRateio.get(parametros)}
    static async get(parametros: any = {}) {
        const myTools = new clsBase();
        try {
                let result = await myTools.myDataBase.pag.DataGet(this.sql(parametros))
                    return result
                
        } catch (e) {
            clsTools.PagErrorException(`reportDREContaList`, 'sql', e);
        }
    }

}