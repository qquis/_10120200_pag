"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class f0080_02_movimento_caixa_bluesoft_integ {
    static sqlScript_VERSION() { return `f0080_02_1012014_movimento_caixa_bluesoft_integ`; }
    static get(par) {
        /*
            Data de Criação: 20/08/2025
            Data de Atualização: 20/08/2025
            Versão: 20.14
            Objetivo: Script para integração da base Bluesfot com a base Pag tabela de "Movimento Caixa"
        */
        return `
            SELECT ${f0080_02_movimento_caixa_bluesoft_integ.sqlScript_VERSION()}(
                    sqlcommand:= 'INSERT'
                ,   v_mv_caixa_seq:= ${(par === null || par === void 0 ? void 0 : par.mv_caixa_seq) || 0} 				        
                ,	v_em_cdempresa:= ${(par === null || par === void 0 ? void 0 : par.em_cdempresa) || 0} 				        
                ,	v_mv_caixa_bluesoft_tipo_cd:= ${(par === null || par === void 0 ? void 0 : par.mv_caixa_bluesoft_tipo_cd) || 0}	        
                ,	v_caixa_bluesoft_cd:= ${(par === null || par === void 0 ? void 0 : par.caixa_bluesoft_cd) || 0} 			    
                ,	v_administradora_cdpessoabluesoft:= ${(par === null || par === void 0 ? void 0 : par.administradora_cdpessoabluesoft) || 0}   
                ,	v_mv_caixa_data:= '${modelbase_1.clsTools._datemomentDateToStr(par === null || par === void 0 ? void 0 : par.mv_caixa_data, 'YYYY-MM-DD') || '1900-01-01'}'				        
                ,	v_mv_caixa_descricao:= '${(par === null || par === void 0 ? void 0 : par.mv_caixa_descricao) || ''}'			    
                ,	v_sat_ecf:= ${(par === null || par === void 0 ? void 0 : par.sat_ecf) || 0} 					        
                ,	v_mv_caixa_valor:= ${(par === null || par === void 0 ? void 0 : par.mv_caixa_valor) || 0}   				    
                ,	v_mv_caixa_vl_parcela:= ${(par === null || par === void 0 ? void 0 : par.mv_caixa_vl_parcela) || 0}			    
                ,   v_mv_caixa_vl_taxa:= ${(par === null || par === void 0 ? void 0 : par.mv_caixa_vl_taxa) || 0} 			        
                ,   v_mv_caixa_vl_taxa_operacao:= ${(par === null || par === void 0 ? void 0 : par.mv_caixa_vl_taxa_operacao) || 0} 	    
                ,   v_mv_caixa_vl_juros:= ${(par === null || par === void 0 ? void 0 : par.mv_caixa_vl_juros) || 0} 			    
                ,   v_mv_caixa_data_deposito:= '${modelbase_1.clsTools._datemomentDateToStr(par === null || par === void 0 ? void 0 : par.mv_caixa_data_deposito, 'YYYY-MM-DD') || '1900-01-01'}' 		    
                ,   v_mv_caixa_data_entrega:= '${modelbase_1.clsTools._datemomentDateToStr(par === null || par === void 0 ? void 0 : par.mv_caixa_data_deposito, 'YYYY-MM-DD') || '1900-01-01'}' 		     		    
                ,   v_mv_caixa_data_previsao_credito:= '${modelbase_1.clsTools._datemomentDateToStr(par === null || par === void 0 ? void 0 : par.mv_caixa_data_deposito, 'YYYY-MM-DD') || '1900-01-01'}' 		        
                ,   v_mv_caixa_autorizacao_cd:= '${(par === null || par === void 0 ? void 0 : par.mv_caixa_autorizacao_cd) || 0}' 	        
                ,   v_mv_caixa_nsu:= '${(par === null || par === void 0 ? void 0 : par.mv_caixa_nsu) || ''}'        				        
                ,   v_mv_caixa_updated_at:= '${modelbase_1.clsTools._datemomentDateToStr(par === null || par === void 0 ? void 0 : par.mv_caixa_updated_at, 'YYYY-MM-DD') || '1900-01-01'}'			    
                ,   v_mv_caixa_cpf:= '${(par === null || par === void 0 ? void 0 : par.mv_caixa_cpf) || ''}' 
                ,   v_debitocredito:= ${(par === null || par === void 0 ? void 0 : par.debitocredito) || -1}				        
            );
        `;
    }
}
exports.default = f0080_02_movimento_caixa_bluesoft_integ;
