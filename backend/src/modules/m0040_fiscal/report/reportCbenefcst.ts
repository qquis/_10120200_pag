import { clsBase, clsTools } from '../../../model/modelbase';


export default class reportCbenefCst {
    static sql (parametro: any) : string {

        let sql = ` select 	fc_cbenef_cd 
                        ,	icms_codigo_tributacao
                    from tbfc_cbenef_cst
                    where 1 = 1
                `
        if (parametro.fc_cbenef_cd && parametro.fc_cbenef_cd.trim() !== '') {
            sql += ` and fc_cbenef_cd like '%${parametro.fc_cbenef_cd}%'`
        }
        if (parametro.icms_codigo_tributacao && parametro.icms_codigo_tributacao.trim() !== '') {
            sql += ` and icms_codigo_tributacao = %${parametro.icms_codigo_tributacao}%`
        }   


        return sql;
    }

    static async get(parametro: any) : Promise<any> {
        let result : any = { }
        try {
            let myBase : clsBase = new clsBase();
            result = await myBase.myDataBase.pag.DataGet( this.sql(parametro));

        } catch (e) {
            clsTools.pagConsole(`reportCbenefProduto | get \n Error: ${e}`);
        
        } finally {
            
            return result
        }   
    }   

}

