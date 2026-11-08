import { clsTools } from '../../../model/modelbase'
export default class f0080_02_movimento_caixa_bluesoft_integ {
    public static sqlScript_VERSION(): string {return `f0080_02_1012014_movimento_caixa_bluesoft_integ`} 
    public static get(par: any) : string { 
       
        /*
            Data de Criação: 20/08/2025
            Data de Atualização: 20/08/2025
            Versão: 20.14
            Objetivo: Script para integração da base Bluesfot com a base Pag tabela de "Movimento Caixa"
        */
       
       
       
        return `
            SELECT ${f0080_02_movimento_caixa_bluesoft_integ.sqlScript_VERSION()}(
                    sqlcommand:= 'INSERT'
                ,   v_mv_caixa_seq:= ${par?.mv_caixa_seq || 0} 				        
                ,	v_em_cdempresa:= ${par?.em_cdempresa || 0} 				        
                ,	v_mv_caixa_bluesoft_tipo_cd:= ${par?.mv_caixa_bluesoft_tipo_cd || 0}	        
                ,	v_caixa_bluesoft_cd:= ${par?.caixa_bluesoft_cd || 0} 			    
                ,	v_administradora_cdpessoabluesoft:= ${par?.administradora_cdpessoabluesoft || 0}   
                ,	v_mv_caixa_data:= '${clsTools._datemomentDateToStr(par?.mv_caixa_data, 'YYYY-MM-DD') || '1900-01-01'}'				        
                ,	v_mv_caixa_descricao:= '${par?.mv_caixa_descricao || ''}'			    
                ,	v_sat_ecf:= ${par?.sat_ecf || 0} 					        
                ,	v_mv_caixa_valor:= ${par?.mv_caixa_valor || 0}   				    
                ,	v_mv_caixa_vl_parcela:= ${par?.mv_caixa_vl_parcela || 0}			    
                ,   v_mv_caixa_vl_taxa:= ${par?.mv_caixa_vl_taxa || 0} 			        
                ,   v_mv_caixa_vl_taxa_operacao:= ${par?.mv_caixa_vl_taxa_operacao || 0} 	    
                ,   v_mv_caixa_vl_juros:= ${par?.mv_caixa_vl_juros || 0} 			    
                ,   v_mv_caixa_data_deposito:= '${clsTools._datemomentDateToStr(par?.mv_caixa_data_deposito, 'YYYY-MM-DD') || '1900-01-01'}' 		    
                ,   v_mv_caixa_data_entrega:= '${clsTools._datemomentDateToStr(par?.mv_caixa_data_deposito, 'YYYY-MM-DD') || '1900-01-01'}' 		     		    
                ,   v_mv_caixa_data_previsao_credito:= '${clsTools._datemomentDateToStr(par?.mv_caixa_data_deposito, 'YYYY-MM-DD') || '1900-01-01'}' 		        
                ,   v_mv_caixa_autorizacao_cd:= '${par?.mv_caixa_autorizacao_cd || 0}' 	        
                ,   v_mv_caixa_nsu:= '${par?.mv_caixa_nsu || ''}'        				        
                ,   v_mv_caixa_updated_at:= '${clsTools._datemomentDateToStr(par?.mv_caixa_updated_at, 'YYYY-MM-DD') || '1900-01-01'}'			    
                ,   v_mv_caixa_cpf:= '${par?.mv_caixa_cpf || ''}' 
                ,   v_debitocredito:= ${par?.debitocredito || -1}				        
            );
        `
    }
}