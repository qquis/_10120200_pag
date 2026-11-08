import { modelTb } from "../../../model/model"
import myTools from "../../../tools/Tools";

export default class tbZanthusTabMercadoriaTipoVenda extends modelTb {
    tab_pre_cd : number 
    pr_cdproduto: number
    prb_cdprodutobluesoft: number	
    preg_cdbarra: string 
    cod_loja: number
    controle: string  									
    cod_mercadoria: string
    cod_tipo_venda: number
    usuario: string 
    data_cadastro: Date 								
    data_ultima_alteracao: Date
    preco_unitario : number
    percentual_comissao_vendedor: number
    preco_anterior: number
   	


    constructor() {
        super();
        this.tab_pre_cd = 1
        this.pr_cdproduto= 0
        this.prb_cdprodutobluesoft= 0	
        this.preg_cdbarra= `` 
        this.cod_loja= 0
        this.controle= ``  									
        this.cod_mercadoria= ``
        this.cod_tipo_venda = 0 
        this.usuario = `` 
        this.data_cadastro = this.__defaultDateNow;							
        this.data_ultima_alteracao = this.__defaultDateNow;		
        this.preco_unitario = 0
        this.percentual_comissao_vendedor = 0
        this.preco_anterior = 0
	

    } 

    async binding(item: any): Promise<void> {
        try { 
            
            this.tab_pre_cd = parseInt(item?.tab_pre_cd)
            this.pr_cdproduto = parseInt(item?.pr_cdproduto)
            this.prb_cdprodutobluesoft = parseInt(item?.prb_cdprodutobluesoft)	
            this.preg_cdbarra = item?.preg_cdbarra
            this.cod_loja = parseInt(item?.cod_loja)
            this.controle = item?.controle 									
            this.cod_mercadoria = item?.cod_mercadoria
            this.cod_tipo_venda = parseInt(item?.cod_tipo_venda)
            this.usuario = item?.usuario	
            this.data_cadastro = this.__defaultDateNow;							
            this.data_ultima_alteracao = this.__defaultDateNow;			
            this.preco_unitario = parseFloat(item?.preco_unitario)
            this.percentual_comissao_vendedor = parseFloat(item?.percentual_comissao_vendedor)    
            this.preco_anterior = parseFloat(item?.preco_anterior)

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
                	INSERT INTO	TAB_MERCADORIA_TIPO_VENDA 
                            (	cod_loja,
                                controle,
                                cod_mercadoria,
                                cod_tipo_venda,
                                preco_unitario,
                                percentual_comissao_vendedor,
                                usuario,
                                data_cadastro,
                                data_ultima_alteracao )
                        SELECT			DISTINCT
                                        ${this.cod_loja}
                                    ,	'${this.controle}'
                                    ,	'${this.cod_mercadoria}'
                                    ,	${this.cod_tipo_venda}
                                    ,	${this.preco_unitario} 
                                    ,	${this.percentual_comissao_vendedor}
                                    ,	'${this.usuario}' 
                                    ,  ('${this.data_cadastro}'::timestamp)
                                    ,  ('${this.data_ultima_alteracao}'::timestamp)
                        WHERE NOT EXISTS ( SELECT 1 
                                           FROM   TAB_MERCADORIA_TIPO_VENDA a
                                           WHERE  a.cod_mercadoria = '${this.cod_mercadoria}' 
                                             AND  a.cod_tipo_venda = ${this.cod_tipo_venda}
                                          )

                        ;
                        
                        UPDATE TAB_MERCADORIA_TIPO_VENDA x 
                        SET    preco_unitario = ${this.preco_unitario} 
                           ,   percentual_comissao_vendedor = ${this.percentual_comissao_vendedor}
                           ,   data_ultima_alteracao = ('${this.data_ultima_alteracao}'::timestamp)
                        WHERE  1 = 1
                          AND  x.cod_mercadoria = '${this.cod_mercadoria}'
                          AND  x.cod_tipo_venda = ${this.cod_tipo_venda}
                        
                        ;
            `
        


            return script; 


        } catch (e) {
            myTools.pagConsole(`M0085_ZANTHUS | tbZanthusTabMercadoria - _Db_Pg_script_CRUD
                                Item ${this.pr_cdproduto} | cod_tipo_venda ${this.cod_tipo_venda} | preço : ${this.preco_unitario}
                                Error \n ${e}
                               `)
            return ``
        }
    }

    

}

