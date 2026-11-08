import { Console } from 'console';
import { clsTools, clsBase} from '../../../model/modelbase';



export default class reportFuncaolist{
    static sql (parametros: any = {}) : string { 
        try { 
            
            let sql =  `   SELECT   sis_fc_cd
                                ,	sis_fc_descricao 
                            FROM 	TBSISTEMA_FUNCAO 
                            order by sis_fc_descricao
        `

        return sql

        } catch (e) { 
            clsTools.PagErrorException(`reportPermissaolist`, 'sql', e);   
            return ''       
        }
    }
    static async get(parametros: any = {}) {
            const myTools = new clsBase();
        try {
            let result = await myTools.myDataBase.pag.DataGet(this.sql(parametros));

            return result //await myTools.myDataBase.pag.DataGet(this.sql(parametros));
        } catch (e) {
            clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemalist', e);
        }
    }

}