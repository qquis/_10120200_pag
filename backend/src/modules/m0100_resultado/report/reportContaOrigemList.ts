import { clsTools, clsBase} from '../../../model/modelbase';
import scriptdbResultadoContaOrigem from '../scriptdb/scriptdbResultadoContaOrigem';
export default class reportContaOrigemList{
    static sql (parametros: any = {}) : string { return scriptdbResultadoContaOrigem.get(parametros)}
    static async get(parametros: any = {}) : Promise<any> {
        const myTools = new clsBase();
        try {
            return await myTools.myDataBase.pag.DataGet(this.sql(parametros));
        } catch (e) {
            clsTools.PagErrorException(`reportDREContaList`, 'sql', e);
        }
    }

}