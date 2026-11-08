import { clsTools, clsBase} from '../../../model/modelbase';


export default class reportFormaPgtoBlueSoft{
    static sql (parametros: any = {}) : string { 
        try { 

    
            let sql = `SELECT forma_pgto_cd, forma_pgto_descricao, forma_pgto_ref_blue  FROM tbforma_pgto_bluesoft WHERE 1 = 1 order by forma_pgto_descricao asc`

                            
            return sql 
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