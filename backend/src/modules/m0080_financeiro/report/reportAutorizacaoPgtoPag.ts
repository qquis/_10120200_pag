import { clsTools, clsBase} from '../../../model/modelbase';


export default class reportAutorizacaoPgtoPag{
    static sql (parametros: any = {}) : string { 
        try { 

    

            let data_pgto_ini = new Date(parametros.data_pgto_ini)
            let data_pgto_fim = new Date(parametros.data_pgto_fim)

            if (parametros.filtrar_data_pgto) {
                if (isNaN(data_pgto_ini.getDate())) data_pgto_ini = new Date()
                if (isNaN(data_pgto_fim.getDate())) data_pgto_fim = new Date()
            }



            let sql = `SELECT   x.sis_us_seq	
                            ,   ul.user_name as user_name
                            ,   x.aut_pgto_pag_seq
                            ,   x.aut_pgto_pag_uuid	
                            ,	x.competencia_cd 
                            ,   c.competencia_descricao			
                            ,	x.em_cdempresa		
                            ,   x.r_conta_cd
                            ,   r.r_conta_descricao  	
                            ,	x.aut_pgto_pag_data 		
                            ,	x.cdparticipante			
                            ,	x.aut_pgto_pag_data_pgto  
                            ,	x.aut_pgto_pag_valor	
                            ,   x.aut_pgto_pag_obs
                            ,   x.aut_pgto_pag_cancelado
                            ,   x.aut_pgto_pag_cancelado_data
                            ,   x.aut_pgto_pag_cancelado_sis_us_seq
                            ,   uc.user_name as user_name_cancelador
                        FROM tbautorizacaopagamentopag x 
                        left join tbresultado_conta r on r.r_conta_cd = x.r_conta_cd
                        left join tbsistema_usuario ul on ul.sis_us_seq = x.sis_us_seq
                        left join tbsistema_usuario uc on uc.sis_us_seq = x.aut_pgto_pag_cancelado_sis_us_seq
                        left join tbcompetencia c on c.competencia_cd = x.competencia_cd 
                        where 1 = 1
                          
                        ${(parametros.filtrar_data_pgto == 1 && parametros.data_pgto_ini)? 
                            " and x.aut_pgto_pag_data_pgto >= '" + clsTools._datemomentDateToStr(data_pgto_ini, "YYYY-MM-DD") + "'" : ""  } 
                        ${(parametros.filtrar_data_pgto == 1 && parametros.data_pgto_fim)? 
                            " and x.aut_pgto_pag_data_pgto <= '" + clsTools._datemomentDateToStr(data_pgto_fim, "YYYY-MM-DD") + "'" : ""  } 

                        ${(parametros.r_conta_cd && parseInt(parametros.r_conta_cd) > 0)? "and r.r_conta_cd=" + parametros.r_conta_cd : ""}

                        ${(parametros.competencia_cd && parseInt(parametros.competencia_cd) > 0)? "and x.competencia_cd=" + parametros.competencia_cd : ""}

                        ${(parametros.cancelado && parseInt(parametros.cancelado) == 1)? "and x.aut_pgto_pag_cancelado in (1,0) ": "and x.aut_pgto_pag_cancelado = 0"}

                        ${(parametros.competencia_cd && parseInt(parametros.competencia_cd) > 0)? "and x.competencia_cd=" + parametros.competencia_cd : ""}

                     ORDER BY x.aut_pgto_pag_data desc 
                     `

                            
            return sql 
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
            clsTools.PagErrorException(`reportFinanceiroPagList`, 'sql', e);
        }
    }

}