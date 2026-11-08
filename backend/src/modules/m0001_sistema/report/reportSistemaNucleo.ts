import { clsTools, clsBase} from '../../../model/modelbase';



export default class reportSistemaNucleo{
    static sql (parametros: any = {}) : string { 
        try { 

            return `    select  n.sis_cd_fk                     as sis_cd 
                            ,   s.sis_descricao                 as sis_descricao
                            ,   n.sis_nucleo_cd_pk              as sis_nucleo_cd
                            ,   n.sis_nucleo_descricao          as sis_nucleo_descricao
                            ,   n.sis_nucleo_grupo_id           as sis_nucleo_grupo_id
                            ,   g.sis_nucleo_grupo_descricao    as sis_nucleo_grupo_descricao
                        from        tbsistema_nucleo        n 
                        left join   tbsistema               s on s.sis_cd_pk = n.sis_cd_fk
                        left join   tbsistema_nucleo_grupo  g on g.sis_nucleo_grupo_id = n.sis_nucleo_grupo_id
                        where 1=1
            `

        } catch (e) { 
            clsTools.PagErrorException(`reportFinanceiroPagList`, 'sql', e);   
            return ''       
        }
    }
    static async get(parametros: any = {}) {
            const myTools = new clsBase();
        try {
            let result = await myTools.myDataBase.pag.DataGet(this.sql(parametros));

            return result //await myTools.myDataBase.pag.DataGet(this.sql(parametros));
        } catch (e) {
            clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemaNucleo', e);
        }
    }

}