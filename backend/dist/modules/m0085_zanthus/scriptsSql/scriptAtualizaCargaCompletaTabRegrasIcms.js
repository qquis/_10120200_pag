"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const Tools_1 = __importDefault(require("../../../tools/Tools"));
class scriptAtualizaCargaCompletaTabRegraIcms {
    static ScriptExecute(myDataBase_SERVER) {
        let sqlscript = ``;
        if (myDataBase_SERVER == 'ZANTHUSSQLSERVER') {
            sqlscript = this.ZanthusSQLServer_CRUD();
        }
        return sqlscript;
    }
    static ZanthusSQLServer_CRUD() {
        let data_hoje = new Date();
        let cod_voucher = Tools_1.default._datemomentDateToStr(data_hoje, "YYYYMMDD");
        return `    DELETE FROM ZEUSRETAIL.dbo.tab_regras_icms
                    INSERT INTO ZEUSRETAIL.dbo.tab_regras_icms 
                            (		
                                    cod_regras_icms
                                ,	cod_loja 
                                ,	descricao 
                                ,	prioridade 
                                ,	flg_registro 
                                ,	cod_ncm_ini 
                                ,	cod_ncm_final 
                                ,	cod_mercadoria 
                                ,	uf_origem 
                                ,	uf_destino 
                                ,	aliquota
                                ,	cst
                                ,	perc_substituicao 
                                ,	perc_reducao 
                                ,	flg_tipo_imposto 
                                ,	flg_revenda 
                                ,	dta_val_inicial 
                                ,	dta_val_final 
                                ,	cst_orig
                                ,	usuario 
                                ,	data_cadastro 
                                ,	data_ultima_alteracao 
                                ,	aliquota_interestadual 
                                ,	valor_imposto 
                                ,	tipo_lista_st 
                                ,	perc_reducao_st 
                                ,	perc_diferimento 
                                ,	exigibilidade_iss 
                                ,	flg_incentivo_fiscal_iss 
                                ,	tipo_documento
                            )
                        select			cod_regras_icms
                                    ,	1
                                    ,	descricao						
                                    ,	prioridade						
                                    ,	flg_registro					
                                    ,	cod_ncm_ini						
                                    ,	cod_ncm_FIM				
                                    ,	cod_mercadoria					
                                    ,	uf_origem						
                                    ,	uf_destino						
                                    ,	aliquota						
                                    ,	cst								
                                    ,	perc_substituicao				
                                    ,	perc_reducao					
                                    ,	flg_tipo_imposto				
                                    ,	flg_revenda						
                                    ,	convert(date , '1900-01-01') 
                                    ,	convert(date , '2099-12-31') 					
                                    ,	cst_orig						
                                    ,	usuario							
                                    ,	data_cadastro					
                                    ,	data_ultima_alteracao			
                                    ,	aliquota_interestadual			
                                    ,	valor_imposto					
                                    ,	tipo_lista_st					
                                    ,	perc_reducao_st					
                                    ,	perc_diferimento				
                                    ,	exigibilidade_iss				
                                    ,	flg_incentivo_fiscal_iss	
                                    ,	'01'
                    FROM	POSTSQL.oxan.[public].tbzanthustab_regra_icms
                    where	cod_ncm_ini is not null
                    and     cod_regras_icms not in (select cod_regras_icms from ZEUSRETAIL.dbo.tab_regras_icms )
                
                `;
    }
}
exports.default = scriptAtualizaCargaCompletaTabRegraIcms;
