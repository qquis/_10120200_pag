import { modelTb } from "../../../model/model"
import myTools from "../../../tools/Tools";

export default class tbZanthusTabProdutoDecomposicao extends modelTb {
    pr_cdproduto: number
    prb_cdprodutobluesoft: number	
    preg_cdbarra: string 
    cod_loja: number
    controle: string  									
    cod_mercadoria: string
    forma_decomposicao: string 
    tipo_decomposicao: string 
    usuario: string 
    data_cadastro: Date 								
    data_ultima_alteracao: Date
   	


    constructor() {
        super();
        this.pr_cdproduto= 0
        this.prb_cdprodutobluesoft= 0	
        this.preg_cdbarra= `` 
        this.cod_loja= 0
        this.controle= `000`  									
        this.cod_mercadoria= ``
        this.forma_decomposicao = `` 
        this.tipo_decomposicao = `` 
        this.usuario = `` 
        this.data_cadastro = this.__defaultDateNow;							
        this.data_ultima_alteracao = this.__defaultDateNow;		
	

    } 

    async binding(item: any): Promise<void> {
        try { 
            
            this.pr_cdproduto = parseInt(item?.pr_cdproduto)
            this.prb_cdprodutobluesoft = parseInt(item?.prb_cdprodutobluesoft)	
            this.preg_cdbarra = item?.preg_cdbarra
            this.cod_loja = parseInt(item?.cod_loja)
            this.controle = item?.controle 								
            this.cod_mercadoria = item?.cod_mercadoria
            this.forma_decomposicao = `${item?.forma_decomposicao}`.trim()
            this.tipo_decomposicao = `${item?.tipo_decomposicao}`.trim()
            this.usuario = item?.usuario	
            this.data_cadastro = this.__defaultDateNow;							
            this.data_ultima_alteracao = this.__defaultDateNow;			


        } catch (e) { 
            myTools.pagConsole(`M0085 _ Zanthus | tbZanthusTab_Mercadoria_Tipo_Venda.binding 
                Error: 
                ${e}    
                `)
        }
        
    }

    ZanthusPostGre_CRUD(): string {
        try { 

            let script = `
              		INSERT INTO		TAB_produto_decomposicao
                        (	
                                cod_loja 
                            ,	controle 
                            ,	cod_mercadoria 
                            ,	forma_decomposicao 
                            ,	tipo_decomposicao 
                            ,	usuario 
                            ,	data_cadastro 
                            ,	data_ultima_alteracao 
			            )
                        SELECT			DISTINCT
                                        ${this.cod_loja}
                                    ,	'${this.controle}'
                                    ,	'${this.cod_mercadoria}'
                                    ,	'${this.forma_decomposicao}'
                                    ,	'${this.tipo_decomposicao}'
                                    ,	'${this.usuario}' 
                                    ,	('${this.data_cadastro}'::timestamp)
                                    ,	('${this.data_ultima_alteracao}'::timestamp)
                        WHERE NOT EXISTS ( SELECT 1 
                                           FROM   TAB_produto_decomposicao a
                                           WHERE  a.cod_mercadoria = '${this.cod_mercadoria}' 
                                          )

                        ;
                        UPDATE TAB_produto_decomposicao x 
                        SET    forma_decomposicao = '${this.forma_decomposicao}' 
                           ,   tipo_decomposicao = '${this.tipo_decomposicao}'
                           ,   data_ultima_alteracao = current_timestamp
                        WHERE  1 = 1
                          AND  x.cod_mercadoria = '${this.cod_mercadoria}'
                        
                        ;
            `
        


            return script; 


        } catch (e) {
            myTools.pagConsole(`M0085_ZANTHUS | tbZanthusTabMercadoria - _Db_Pg_script_CRUD
                                Item ${this.pr_cdproduto} | Cod cod_mercadoria ${this.cod_mercadoria}
                                Error \n ${e}
                               `)
            return ``
        }
    }

    ZanthusSQLServer_CRUD(): string {
        try { 

            let script = `
              		INSERT INTO	ZeusRetail.dbo.TAB_produto_decomposicao
                        (	
                                cod_loja 
                            ,	controle 
                            ,	cod_mercadoria 
                            ,	forma_decomposicao 
                            ,	tipo_decomposicao 
                            ,	usuario 
                            ,	data_cadastro 
                            ,	data_ultima_alteracao 
			            )
                        SELECT			DISTINCT
                                        ${this.cod_loja}
                                    ,	'${this.controle}'
                                    ,	'${this.cod_mercadoria}'
                                    ,	'${this.forma_decomposicao}'
                                    ,	'${this.tipo_decomposicao}'
                                    ,	'${this.usuario}' 
                                    ,  '${myTools._datemomentDateToStr(this.data_cadastro, "yyyy-MM-DD hh:mm:ss")}'
                                    ,  '${myTools._datemomentDateToStr(this.data_ultima_alteracao, "yyyy-MM-DD hh:mm:ss")}'                                        
                        WHERE NOT EXISTS ( SELECT 1 
                                           FROM   ZeusRetail.dbo.TAB_produto_decomposicao a
                                           WHERE  a.cod_mercadoria = '${this.cod_mercadoria}' 
                                          )

                        ;
                        UPDATE x 
                        SET    forma_decomposicao = '${this.forma_decomposicao}' 
                           ,   tipo_decomposicao = '${this.tipo_decomposicao}'
                           ,   data_ultima_alteracao = '${myTools._datemomentDateToStr(this.data_ultima_alteracao, "yyyy-MM-DD hh:mm:ss")}'                                        
                        FROM   ZeusRetail.dbo.TAB_produto_decomposicao x
                        WHERE  1 = 1
                          AND  x.cod_mercadoria = '${this.cod_mercadoria}'
                        
                        ;
            `
        


            return script; 


        } catch (e) {
            myTools.pagConsole(`M0085_ZANTHUS | tbZanthusTabMercadoria - _Db_Pg_script_CRUD
                                Item ${this.pr_cdproduto} | Cod cod_mercadoria ${this.cod_mercadoria}
                                Error \n ${e}
                               `)
            return ``
        }
    }


}

