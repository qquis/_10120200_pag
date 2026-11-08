import myTools from "../../../tools/Tools"




export default class scriptAtualizaCargaCompletaTabRegraIcms {
    public static ScriptExecute(myDataBase_SERVER: string) : string {
         let sqlscript = `` 


         if (myDataBase_SERVER == 'ZANTHUSSQLSERVER') {
            sqlscript = this.ZanthusSQLServer_CRUD()
         }            


         return sqlscript;
    }



    private static ZanthusSQLServer_CRUD() : string {

        let data_hoje : Date = new Date()

        let cod_voucher : string = myTools._datemomentDateToStr(data_hoje,  "YYYYMMDD")

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
                
                `
    }    
}