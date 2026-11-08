import { Console } from 'console';
import { clsTools, clsBase} from '../../../model/modelbase';



export default class reportSistemaUsuario{
    static sql (parametros: any = {}) : string { 
        try { 
            
            let sql =  `   SELECT 		
                                us.sis_us_seq 
                            ,	us.cdpessoabluesoft 
                            ,   us.user_name
                FROM 		tbsistema_usuario us
                WHERE 1=1
        `
        if (parametros.user_name) {
            sql += ` AND us.user_name = '${parametros.user_name}' `
        }


        return sql

        } catch (e) { 
            clsTools.PagErrorException(`reportSistemaUsuario`, 'sql', e);   
            return ''       
        }
    }
    static async get(parametros: any = {}) {
            const myTools = new clsBase();
        try {
            let result = await myTools.myDataBase.pag.DataGet(this.sql(parametros));

            return result //await myTools.myDataBase.pag.DataGet(this.sql(parametros));
        } catch (e) {
            await clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemaUsuario.get', e);
        }
    }

    static async getByUserName(user_name: string) {
        try { 
            const myTools = new clsBase();
            let result = await this.get({ user_name }) as object[];
            let item = await myTools.myDataBase.RecordItem(result,0);  
            return item;
        } catch (e) {
            await clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemaUsuario.getByUserName', e);
        }
    }

}