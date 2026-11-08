import { clsTools, clsBase} from '../../../model/modelbase';



export default class reportSistemaTarefa{
    static sql (parametros: any = {}) : string { 
        try { 
            
            return `    SELECT 		ta.sis_ta_seq
                            ,		ta.sis_ta_cd 
                            ,		ta.sis_ta_descricao 
                            ,		ta.sis_ta_tipo_cd 
                            ,		ac.sistemas
                            ,		ac.funcoes
                            ,		ac.acessos
                            ,     tp.sis_ta_tipo_descricao  
                        FROM   		tbsistema_tarefa ta
                        LEFT JOIN	tbsistema_tarefa_tipo tp on tp.sis_ta_tipo_cd = ta.sis_ta_tipo_cd
                        LEFT JOIN   (
                                        select pm.sis_ta_cd
                                            ,	count(distinct(pm.sis_cd)) sistemas 
                                            ,	count(distinct(pm.sis_fc_cd)) funcoes
                                            ,	count(distinct(pm.sis_ac_cd)) acessos
                                        from tbsistema_permissao pm
                                        group by  pm.sis_ta_cd	
                                    ) ac on ac.sis_ta_cd = ta.sis_ta_Cd 
                        WHERE       1= 1

                        ${parametros.sis_ta_cd ? `and ta.sis_ta_cd = ${parametros.sis_ta_cd}` : '' }
                        ${parametros.sis_ta_descricao ? `and UPPER(ta.sis_ta_descricao) like UPPER('%${parametros.sis_ta_descricao}%')` : '' }
                        ${parametros.sis_ta_tipo_descricao ? `and UPPER(tp.sis_ta_tipo_descricao) like UPPER('%${parametros.sis_ta_tipo_descricao}%')` : '' }
        `
        

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

}