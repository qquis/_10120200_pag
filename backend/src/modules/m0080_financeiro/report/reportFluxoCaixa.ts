import { clsTools, clsBase} from '../../../model/modelbase';
import scriptSQLSelectFluxoCaixa from '../scriptpg/scriptFluxoCaixa';


export default class reportFluxoCaixa{
    static sql (parametros: any = {}) : string { 
        try { 

            return scriptSQLSelectFluxoCaixa.sql(parametros, true);

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
            clsTools.PagErrorException(`report Fluxo de Caixa`, 'sql', e);
        }
    }

}