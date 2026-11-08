import { modelTb } from "../../../model/model"
import myTools from "../../../tools/Tools";

export default class tbZanthusTabProdutoDecomposicaoInsum extends modelTb {
    pr_cdproduto: number
    prb_cdprodutobluesoft: number	
    preg_cdbarra_insumo: string 
    cod_loja: number
    controle: string  									
    cod_mercadoria: string
    cod_insumo: string 
    percentual_insumo: number
    quantidade_insumo: number 
    usuario: string 
    data_cadastro: Date 								
    data_ultima_alteracao: Date
   	


    constructor() {
        super();
        this.pr_cdproduto= 0
        this.prb_cdprodutobluesoft= 0	
        this.preg_cdbarra_insumo= `` 
        this.cod_loja= 0
        this.controle= `000`  									
        this.cod_mercadoria= ``
        this.cod_insumo =  `` 
        this.percentual_insumo = 0
        this.quantidade_insumo = 0 
        this.usuario = `` 
        this.data_cadastro = this.__defaultDateNow;							
        this.data_ultima_alteracao = this.__defaultDateNow;		
	

    } 

    async binding(item: any): Promise<void> {
        try { 
            
            this.pr_cdproduto = parseInt(item?.pr_cdproduto)
            this.prb_cdprodutobluesoft = parseInt(item?.prb_cdprodutobluesoft)	
            this.preg_cdbarra_insumo = item?.preg_cdbarra_insumo
            this.cod_loja = parseInt(item?.cod_loja)
            this.controle = item?.controle 								
            this.cod_mercadoria = item?.cod_mercadoria
            this.cod_insumo =  item?.cod_insumo
            this.percentual_insumo = parseFloat(item?.percentual_insumo)
            this.quantidade_insumo = parseFloat(item?.quantidade_insumo)
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
              		INSERT INTO		TAB_produto_decomposicao_insum
                        (	
                                cod_loja 
                            ,	controle 
                            ,	cod_mercadoria 
                            ,	cod_insumo
                            ,   percentual_insumo 
                            ,	quantidade_insumo 
                            ,	usuario 
                            ,	data_cadastro 
                            ,	data_ultima_alteracao 
			            )
                        SELECT			DISTINCT
                                         ${this.cod_loja}
                                    ,	'${this.controle}'
                                    ,	'${this.cod_mercadoria}'
                                    ,	'${this.cod_insumo}'                                    
                                    ,	 ${this.percentual_insumo}
                                    ,	 ${this.quantidade_insumo}
                                    ,	'${this.usuario}' 
                                    ,  ('${this.data_cadastro}'::timestamp)
                                    ,  ('${this.data_ultima_alteracao}'::timestamp)
                        WHERE NOT EXISTS ( SELECT 1 
                                           FROM   TAB_produto_decomposicao_insum a
                                           WHERE  a.cod_mercadoria = '${this.cod_mercadoria}' 
                                             and  a.cod_insumo = '${this.cod_insumo}'
                                          )

                        ;
                        UPDATE TAB_produto_decomposicao_insum x 
                        SET    percentual_insumo = ${this.percentual_insumo}
                           ,   quantidade_insumo = ${this.quantidade_insumo}
                           ,   data_ultima_alteracao = current_timestamp
                        WHERE  1 = 1
                          AND  x.cod_mercadoria = '${this.cod_mercadoria}'
                          AND  x.cod_insumo = '${this.cod_insumo}'
                        
                        ;
                `

        


            return script; 


        } catch (e) {
            myTools.pagConsole(`M0085_ZANTHUS | tbZanthusTabProdutoDecomposicaoInsum - ZanthusPostGre_CRUD
                                Item ${this.pr_cdproduto} | Cod insumo ${this.cod_insumo} | Cod mercadoria ${this.cod_mercadoria}
                                Error \n ${e}
                               `)
            return ``
        }
    }



}

