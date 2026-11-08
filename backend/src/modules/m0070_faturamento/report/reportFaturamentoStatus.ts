import { clsBase, clsTools } from '../../../model/modelbase';

export default class reportFaturamentoStatus {
    public static sql(filter : any) : string {
        let sql = 
        
         `	SELECT 		sf.statusfaturamento
                    ,	sf.statusfaturamento_descricao 
            FROM         tbfaturamentostatus sf
            WHERE 1 = 1
            ORDER BY sf.statusfaturamento_descricao
        `
            return sql
    }

    public static async get(filter : any) : Promise<object> {
        let result = { }
        try {
            result = await new clsBase().myDataBase.pag.DataGet( this.sql(filter));
            
        } catch (e) {
            clsTools.pagConsole(`reportFaturamentoStatus | get \n Error: ${e}`);
        
        } finally {
            
            return result
        }
    }   

}
