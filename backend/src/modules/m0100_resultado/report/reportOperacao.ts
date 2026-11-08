import { clsTools, clsBase} from '../../../model/modelbase';
import scriptdbResultadoOperacao from '../scriptdb/scriptdbResultadoOperacao'
export default class reportOperacaoList{
    static sql (parametros: any = {}) : string { return scriptdbResultadoOperacao.get(parametros)}
    static async get(parametros: any = {}) {
        const myTools = new clsBase();
        try {
                let result = await myTools.myDataBase.pag.DataGet(this.sql(parametros))
                    return result
                
        } catch (e) {
            clsTools.PagErrorException(`reportDREOperacaoList`, 'sql', e);
        }
    }

}