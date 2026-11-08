import { clsTools, clsBase} from '../../../model/modelbase';
import scriptSQLSelectAutorizacaoPgto from '../scriptpg/scriptSelectAutorizacaoPgto';


export default class reportAutorizacaoPgto{
    static sql (parametros: any = {}) : string { 
        try { 

            return scriptSQLSelectAutorizacaoPgto.sql(parametros, true);

        } catch (e) { 
            clsTools.PagErrorException(`reportFinanceiroPagList`, 'sql', e);   
            return ''       
        }
    }
    static async get(parametros: any = {}) {
            const myTools = new clsBase();
        try {
            let result = await myTools.myDataBase.pag.DataGet(this.sql(parametros));

            return result //await myTools.myDataBase.pag.DataGet(this.sql(parametros));
        } catch (e) {
            clsTools.PagErrorException(`reportFinanceiroPagList`, 'sql', e);
        }
    }

}