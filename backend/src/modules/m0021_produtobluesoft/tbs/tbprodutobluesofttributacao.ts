import { modelTb } from "../../../model/model";
import myTools from "../../../tools/Tools";
import F0021_04_ProdutoBlueSoft_Tributacao_CRUD from "../scriptpg/F0021_04_ProdutoBlueSoft_Tributacao_CRUD";


export default class tbprodutobluesof_tributacao {
    op_cdoperacao: number 
    prb_cdprodutobluesoft: number 
    prbt_regrafiscal: number
    prbt_regrafiscal_versao: number
    prbt_regimetributario: string
    prbt_cfop: string 
    
    prbt_pis_entrada_cst: string 
    prbt_pis_entrada_aliquida: number
    prbt_pis_saida_cst: string         
	prbt_pis_saida_aliquota: number	
    
    prbt_cofins_entrada_cst: string 
    prbt_cofins_entrada_aliquida: number
	prbt_cofins_saida_cst: string     
	prbt_cofins_saida_aliquota: number
	
    prbt_icms_saida_cst: string 
    prbt_icms_entrada_cst: string        
	prbt_icms_aliquota_interna: number
	prbt_icms_reducao: number		
    prbt_st_iva: number 
    prbt_icms_entrada_aliquota_interna: number
    prbt_icms_entrada_reducao: number
    prbt_icms_revenda_cst: string 
    prbt_icms_revenda_aliquota_interna: number
    prbt_icms_revenda_reducao: number


	prbt_ncm: string                  
	prbt_cest: string 
    constructor() {
        this.op_cdoperacao = 0 
        this.prb_cdprodutobluesoft = 0 
        this.prbt_regrafiscal = 0
        this.prbt_regrafiscal_versao = 0
        this.prbt_regimetributario = ``
        this.prbt_cfop = `` 
        
        this.prbt_pis_entrada_cst = `` 
        this.prbt_pis_entrada_aliquida = 0
        this.prbt_pis_saida_cst = ``         
        this.prbt_pis_saida_aliquota = 0	
        
        this.prbt_cofins_entrada_cst = `` 
        this.prbt_cofins_entrada_aliquida = 0
        this.prbt_cofins_saida_cst = ``     
        this.prbt_cofins_saida_aliquota = 0
        
        this.prbt_icms_saida_cst = `` 
        this.prbt_icms_entrada_cst = ``        
        this.prbt_icms_aliquota_interna = 0
        this.prbt_icms_reducao = 0		
        this.prbt_st_iva = 0 
        this.prbt_icms_entrada_aliquota_interna = 0
        this.prbt_icms_entrada_reducao = 0
        this.prbt_icms_revenda_cst = `` 
        this.prbt_icms_revenda_aliquota_interna = 0
        this.prbt_icms_revenda_reducao = 0

        this.prbt_ncm = ``                   
	    this.prbt_cest = ``  
    }  
    async _Db_Pg_script(_stringCommand: string): Promise<string> {
        let sqlScriptTributacao : string = `` 
        try {
            sqlScriptTributacao =  `SELECT ${F0021_04_ProdutoBlueSoft_Tributacao_CRUD.sqlScript_VERSION()}
                        (   '${_stringCommand}',
                            2,
                            ${this.prb_cdprodutobluesoft},
                            99999,
                            99999,
                            'X',
                            '5102',
                            '000',
                            0.00,
                            '${this.prbt_pis_saida_cst}',
                            ${this.prbt_pis_saida_aliquota},
                            '000',
                            0.00,
                            '${this.prbt_cofins_saida_cst}',
                            ${this.prbt_cofins_saida_aliquota},
                            '000',
                            0.00,
                            0.00,
                            '${this.prbt_icms_saida_cst}', 
                            ${this.prbt_icms_aliquota_interna},
                            ${this.prbt_icms_reducao},
                            '000',
                            0.00,
                            0.00,
                            '${this.prbt_ncm}', 
                            '${this.prbt_cest}',              
                            0.00,
                            'true'
                                ); `             
               return sqlScriptTributacao;                                
            }
        catch(e) {
            throw new Error(` Classe modelProdutoBluesoft
                Método: getApiBluesoftSqlCRUD
                -----------------------------------------------------------
                Script SQL 
                -----------------------------------------------------------
                ${sqlScriptTributacao}
                -----------------------------------------------------------
                Error ${e} \n 
              `)
        }
    }    
}