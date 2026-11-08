/*  CONSTANTES ___________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS _ tbZanthusTabRegrasIcms"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*________________________________________________________________________________________________*/    



import { modelTb } from "../../../model/model"
import myTools from "../../../tools/Tools";

export default class tbZanthusTabRegrasIcms extends modelTb {
        pr_cdproduto: number
        prb_cdprodutobluesoft: number	
        preg_cdbarra: string 
        cod_loja: number
        cod_mercadoria: string
        cod_regras_icms: Number
        descricao: string 
        prioridade: number 
        flg_registro: string 
        cod_ncm_ini: number 
        cod_ncm_final: number 
        uf_origem: string 
        uf_destino: string 
        aliquota: number
        cst: string
        perc_substituicao: number 
        perc_reducao: number 
        flg_tipo_imposto: string 
        flg_revenda: string 
        dta_val_inicial: Date 
        dta_val_final: Date 
        cst_orig: string
        usuario: string 
        data_cadastro: Date 
        data_ultima_alteracao: Date 
        aliquota_interestadual: number 
        valor_imposto: number 
        tipo_lista_st: number 
        perc_reducao_st: number 
        perc_diferimento: number 
        exigibilidade_iss: string 
        flg_incentivo_fiscal_iss: string 
        tipo_documento: string
        codigo_beneficio_fiscal: string
        cod_class_tributaria: number
        per_cred_presumido_ibs_mono: number
        per_cred_presumido_cbs_mono: number


        constructor() {
            super();
            this.pr_cdproduto = 0
            this.prb_cdprodutobluesoft = 0	
            this.preg_cdbarra = `` 
            this.cod_loja = 0
            this.cod_mercadoria = ``
            this.cod_regras_icms = 0
            this.descricao = `` 	
            this.prioridade = 0
            this.flg_registro = `` 
            this.cod_ncm_ini = 0
            this.cod_ncm_final = 0
            this.uf_origem = `SP` 
            this.uf_destino = `SP` 
            this.aliquota = 0
            this.cst = `` 
            this.perc_substituicao = 0
            this.perc_reducao = 0
            this.flg_tipo_imposto = `` 
            this.flg_revenda = `` 
            this.dta_val_inicial = this.__defaultDateNow;							
            this.dta_val_final = this.__defaultDateNow;							
            this.cst_orig = `` 
            this.usuario = ``             								
            this.data_cadastro = this.__defaultDateNow;							
            this.data_ultima_alteracao = this.__defaultDateNow;	
            this.aliquota_interestadual = 0
            this.valor_imposto = 0
            this.tipo_lista_st = 0
            this.perc_reducao_st = 0
            this.perc_diferimento = 0
            this.exigibilidade_iss = ``  
            this.flg_incentivo_fiscal_iss = ``  
            this.tipo_documento = `01` 		
            this.codigo_beneficio_fiscal = ``
            this.cod_class_tributaria = 0
            this.per_cred_presumido_ibs_mono = 0
            this.per_cred_presumido_cbs_mono = 0
        } 

        async binding(item: any): Promise<void> {
            try { 

                this.pr_cdproduto = parseInt(item?.pr_cdproduto)
                this.prb_cdprodutobluesoft = parseInt(item?.prb_cdprodutobluesoft)	
                this.preg_cdbarra = item?.preg_cdbarra
                this.cod_loja = parseInt(item?.cod_loja)
                this.cod_mercadoria = item?.cod_mercadoria
                this.cod_regras_icms = item?.cod_regras_icms
                this.descricao = item?.descricao 	
                this.prioridade = parseInt(item?.prioridade)
                this.flg_registro = item?.flg_registro 
                this.cod_ncm_ini = parseInt(item?.cod_ncm_ini)
                this.cod_ncm_final = parseInt(item?.cod_ncm_final)
                this.uf_origem = item?.uf_origem
                this.uf_destino = item?.uf_destino 
                this.aliquota = parseFloat(item?.aliquota)
                this.cst = item?.cst ? item?.cst.trim().padStart(3, '0') : ``
                this.perc_substituicao = item?.perc_substituicao
                this.perc_reducao =  item?.perc_reducao
                this.flg_tipo_imposto =  item?.flg_tipo_imposto
                this.flg_revenda =  item?.flg_revenda
                this.dta_val_inicial =  item?.dta_val_inicial						
                this.dta_val_final = item?.dta_val_final			
                this.cst_orig =  item?.cst_orig 
                this.usuario =  item?.usuario  
                this.data_cadastro = this.__defaultDateNow;							
                this.data_ultima_alteracao = this.__defaultDateNow;			
                this.codigo_beneficio_fiscal = item?.codigo_beneficio_fiscal
                this.cod_class_tributaria = parseInt(item?.cod_class_tributaria)
                this.per_cred_presumido_ibs_mono = parseFloat(item?.per_cred_presumido_ibs_mono)
                this.per_cred_presumido_cbs_mono = parseFloat(item?.per_cred_presumido_cbs_mono)


            } catch (e) { 
                myTools.pagConsole(`${FLG_MODULO} Error: ${e} `)
            }
        }

        ZanthusPostGre_CRUD(): string {
            try { 

                let script_SQL_TAB_MERCADORIA = `
                	INSERT INTO tab_regras_icms 
                                (		
                                        cod_regras_icms
                                    ,	cod_mercadoria 
                                    ,	cod_loja 
                                    ,	descricao 
                                    ,	prioridade 
                                    ,	flg_registro 
                                    ,	cod_ncm_ini 
                                    ,	cod_ncm_final 
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
                                    ,   codigo_beneficio_fiscal
                                    ,   cod_class_tributaria
                                    ,   per_cred_presumido_ibs_mono
                                    ,   per_cred_presumido_cbs_mono
                                        )

                            SELECT	     ${this.cod_regras_icms}
                                    ,	'${this.cod_mercadoria}' 
                                    ,	 ${this.cod_loja} 
                                    ,	'${this.descricao}' 
                                    ,	 ${this.prioridade} 
                                    ,	'${this.flg_registro}' 
                                    ,	 ${this.cod_ncm_ini} 
                                    ,	 ${this.cod_ncm_final} 
                                    ,	'${this.uf_origem}' 
                                    ,	'${this.uf_destino}' 
                                    ,	 ${this.aliquota}
                                    ,	'${this.cst.trim().padStart(3, '0')}'
                                    ,	 ${this.perc_substituicao} 
                                    ,	 ${this.perc_reducao} 
                                    ,	'${this.flg_tipo_imposto}' 
                                    ,	'${this.flg_revenda}' 
                                    ,	('1900-01-01'::date )
                                    ,	('2099-12-31'::date) 
                                    ,	'${this.cst_orig}'
                                    ,	'${this.usuario}' 
                                    ,	('${this.data_cadastro}'::timestamp)
                                    ,	('${this.data_ultima_alteracao}'::timestamp) 
                                    ,	 ${this.aliquota_interestadual} 
                                    ,	 ${this.valor_imposto} 
                                    ,	 ${this.tipo_lista_st} 
                                    ,	 ${this.perc_reducao_st} 
                                    ,	 ${this.perc_diferimento} 
                                    ,	'${this.exigibilidade_iss}' 
                                    ,	'${this.flg_incentivo_fiscal_iss}'
                                    ,   '${this.tipo_documento}' 
                                    ,   '${this.codigo_beneficio_fiscal}'
                                    ,   ${this.cod_class_tributaria}
                                    ,   ${this.per_cred_presumido_ibs_mono}
                                    ,   ${this.per_cred_presumido_cbs_mono}
                            WHERE  1 = 1
                              AND  NOT EXISTS ( SELECT 1 FROM tab_regras_icms a 
                                                WHERE  1 = 1
                                                  and  a.cod_mercadoria = '${this.cod_mercadoria}'
                                                  and  a.flg_tipo_imposto = '${this.flg_tipo_imposto}' 
                                                  and  a.flg_revenda = '${this.flg_revenda}'
                                              ); 
                            UPDATE  tab_regras_icms x
                               SET  cod_ncm_ini = ${this.cod_ncm_ini}
                                ,   cod_ncm_final = ${this.cod_ncm_final}
                                ,   aliquota = ${this.aliquota}
                                ,   cst = '${this.cst.trim().padStart(3, '0')}'
                                ,   perc_reducao = ${this.perc_reducao}
                                ,   data_ultima_alteracao  = ('${this.data_ultima_alteracao}'::timestamp)
                                ,   codigo_beneficio_fiscal = ${this.codigo_beneficio_fiscal == null ? null : `'${this.codigo_beneficio_fiscal}'`}
                                ,   cod_class_tributaria = ${this.cod_class_tributaria}
                                ,   per_cred_presumido_ibs_mono = ${this.per_cred_presumido_ibs_mono}
                                ,   per_cred_presumido_cbs_mono = ${this.per_cred_presumido_cbs_mono}
                            WHERE   x.cod_mercadoria = '${this.cod_mercadoria}'
                              AND   x.flg_tipo_imposto = '${this.flg_tipo_imposto}'
                              and   x.flg_revenda = '${this.flg_revenda}'
                            ;   
                `
            


                return script_SQL_TAB_MERCADORIA; 


            } catch (e) {
                myTools.pagConsole(`${FLG_MODULO} Error: ${e} `)
                return ``
            }
        }

}

