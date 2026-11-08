import { clsTools, clsBase} from '../../../model/modelbase';



export default class reportSistemalist{
    static sql (parametros: any = {}) : string { 
        try { 
            console.log(`user name ${parametros.user_name}`)
            return `   SELECT 	sis_cd_pk 
                            ,	sis_ref
                            ,	sis_descricao 
                        FROM 	TBSISTEMA
                        WHERE   sis_cd_pk in (1,3,5)
                        order by sis_descricao asc

                        ${parametros.sis_ta_cd ? `and ta.sis_ta_cd = ${parametros.sis_ta_cd}` : '' }
                        ${parametros.sis_ta_descricao ? `and UPPER(ta.sis_ta_descricao) like UPPER('%${parametros.sis_ta_descricao}%')` : '' }
                        ${parametros.sis_ta_tipo_descricao ? `and UPPER(tp.sis_ta_tipo_descricao) like UPPER('%${parametros.sis_ta_tipo_descricao}%')` : '' }
        `
        

        } catch (e) { 
            clsTools.PagErrorException(`reportSistemalist`, 'sql', e);   
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