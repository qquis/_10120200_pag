import { clsTools, clsBase} from '../../../model/modelbase';



export default class reportSistemaParametro{
    static sql (parametros: any = {}) : string { 
        try { 
            
            let sql =  `    select      s.sis_pr_cd
                                ,   s.sis_pr_descricao
                                ,   s.sis_pr_value
                        from    tbsistema_parametro s
                        WHERE       1 = 1

        `
            if (parametros.sis_pr_cd) {
                sql += ` and s.sis_pr_cd = ${parametros.sis_pr_cd} `
            }

            return sql

        } catch (e) { 
            clsTools.PagErrorException(`reportSistemaTarefa`, 'sql', e);   
            return ''       
        }
    }
    static async get(parametros: any = {}) {
            const myTools = new clsBase();
        try {
            let result = await myTools.myDataBase.pag.DataGet(this.sql(parametros));

            return result //await myTools.myDataBase.pag.DataGet(this.sql(parametros));
        } catch (e) {
            clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemaTarefa', e);
        }
    }

    static async getParametroValue(sis_pr_cd: number) : Promise<string> {
        let result = await this.get({ sis_pr_cd })
        if (result && result.length > 0) {
            return result[0].sis_pr_value
        } else {
            return ''
        }
    }

}