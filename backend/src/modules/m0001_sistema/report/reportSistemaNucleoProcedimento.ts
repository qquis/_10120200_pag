import { clsTools, clsBase} from '../../../model/modelbase';



export default class reportSistemaNucleoProcedimento{
    static sql (parametros: any = {}) : string { 
        try { 
            return `    select 		p.sis_nucleo_cd_fk                          as sis_nucleo_cd
                                ,	n.sis_nucleo_descricao                      as sis_nucleo_descricao         
                                ,	p.sis_nucleo_prc_cd                         as sis_nucleo_prc_cd
                                ,	coalesce(sis_nucleo_prc_descritivo, '')     as sis_nucleo_prc_descritivo
                                ,	coalesce(sis_nucleo_prc_tipo,0)             as sis_nucleo_prc_tipo
                                ,	p.data_default_ini                          as data_default_ini
                                ,	p.data_default_ini                          as data_default_fim
                                ,	p.dateadd_ini                               as dateadd_ini
                                ,	p.dateadd_fim                               as dateadd_fim
                                ,   p.data_reprocessamento_default              as data_reprocessamento_ini
                                ,   p.data_reprocessamento_default_fim          as data_reprocessamento_fim
                                ,	p.permite_execucao_manual                   as permite_execucao_manual
                                ,   coalesce(p.limite_reg_bloq_update, 0)       as limite_reg_bloq_update
                        from 		tbsistema_nucleo_procedimento p
                        left join   tbsistema_nucleo n on n.sis_nucleo_cd_pk = p.sis_nucleo_cd_fk
                        where       1 = 1
                        ${parametros.sis_nucleo_cd? ` and p.sis_nucleo_cd_fk = '${parametros.sis_nucleo_cd}'` : '' }
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
            clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemaNucleoProcedimento', e);
        }
    }

}