import { clsTools, clsBase} from '../../../model/modelbase';
import scriptdbResultado from '../scriptdb/scriptdbResultado'
export default class reportResultado{
    static sql (parametros: any = {}) : string { return scriptdbResultado.get(parametros)}
    static async get(parametros: any = {}) {
        const myTools = new clsBase();
        try {
                let result = await myTools.myDataBase.pag.DataGet(this.sql(parametros))
                    return result
                
        } catch (e) {
            clsTools.PagErrorException(`reportDRresultado`, 'sql', e);
        }
    }

}