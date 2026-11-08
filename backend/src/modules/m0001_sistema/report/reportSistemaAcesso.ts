import { Console } from 'console';
import { clsTools, clsBase} from '../../../model/modelbase';



export default class reportAcessolist{
    static sql (parametros: any = {}) : string { 
        try { 
            
            let sql =  `   SELECT 		ac.sis_cd 
                    ,		S.SIS_DESCRICAO 
                    ,		ac.sis_ac_cd
                    ,		ac.sis_ac_descricao 
                    ,		ac.sis_ac_menu 
                    ,		ac.sis_ac_status 
                    ,		ac.sis_ac_gmenu_cd 
                    ,		ac.sis_ac_href 
                    ,		ac.dtlog_insert
                FROM 		TBSISTEMA_ACESSO ac
                LEFT JOIN   TBSISTEMA S ON S.SIS_CD_PK = AC.SIS_CD 
                ORDER BY    S.SIS_DESCRICAO , AC.SIS_AC_DESCRICAO ASC 
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