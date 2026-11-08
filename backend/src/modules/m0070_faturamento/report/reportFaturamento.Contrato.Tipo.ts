import { clsBase, clsTools } from '../../../model/modelbase';

export default class reportFaturamentoContratoTipo {
    public static sql(filter : any) : string {
        let sql = 
        
         `	select  contrato_tipo_cd 
                    , contrato_tipo_descricao
                from    tbfaturamentocontrato_tipo
                order by contrato_tipo_descricao
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
