import { clsBase, clsTools } from '../../../model/modelbase';

export default class reportForcaVendaMetaFabricante {
    public static sql(filter : any) : string {
        let sql = 
        
         `	select 	x.fv_fabricante_cdpessoabluesoft 
                ,	b.nome_razao 
                ,	x.fv_fab_meta_cd
                ,	x.fv_fab_meta_descricao 
                ,	x.fv_fab_meta_tipo
                ,	a.fv_fab_meta_tipo_descricao 
                ,	x.fv_fab_data_ini
                ,	x.fv_fab_data_fim 
            from 	tbforca_venda_fab_meta X
            LEFT JOIN tbforca_venda_fab_meta_tipo A ON A.fv_fab_meta_tipo_cd = x.fv_fab_meta_tipo
            LEFT JOIN tbparticipante_bluesoft b on b.cdpessoabluesoft = x.fv_fabricante_cdpessoabluesoft
            order by x.fv_fab_meta_cd

        `
            return sql
    }

    public static async get(filter : any) : Promise<object> {
        let result = { }
        try {
            result = await new clsBase().myDataBase.pag.DataGet( this.sql(filter));
            
        } catch (e) {
            clsTools.pagConsole(`reportForcaVendaMetaFabricante | get \n Error: ${e}`);
        
        } finally {
            
            return result
        }
    }   

}
