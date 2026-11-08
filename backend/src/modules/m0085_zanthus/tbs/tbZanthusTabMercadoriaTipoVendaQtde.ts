import { modelTb } from "../../../model/model"
import myTools from "../../../tools/Tools";

export default class tbZanthusTabMercadoriaTipoVendaQtde extends modelTb {
    pr_cdproduto: number
    prb_cdprodutobluesoft: number	
    preg_cdbarra: string 
    cod_loja: number
    cod_mercadoria: string
    cod_tipo_venda: number
    qtde_venda: number 
    flag_geral: number
    preco_unitario : number
    perc_desconto: number 
    flg_ativo : string
    dth_inclusao : Date 
    dth_alteracao : Date 
    idt_usuario_alteracao : string 
   	


    constructor() {
        super();
        this.pr_cdproduto= 0
        this.prb_cdprodutobluesoft= 0	
        this.preg_cdbarra= `` 
        this.cod_loja= 0
        this.cod_mercadoria= ``
        this.cod_tipo_venda = 0 
        this.qtde_venda = 0 
        this.flag_geral = 0
        this.preco_unitario = 0
        this.perc_desconto = 0 
        this.flg_ativo = "S"
        this.dth_inclusao = this.__defaultDateNow;							
        this.dth_alteracao = this.__defaultDateNow;		
        this.idt_usuario_alteracao = ``


    } 

    async binding(item: any): Promise<void> {
        try { 
            
            this.pr_cdproduto = parseInt(item?.pr_cdproduto)
            this.prb_cdprodutobluesoft = parseInt(item?.prb_cdprodutobluesoft)	
            this.preg_cdbarra = item?.preg_cdbarra
            this.cod_loja = parseInt(item?.cod_loja)
            this.cod_mercadoria = item?.cod_mercadoria
            this.cod_tipo_venda = parseInt(item?.cod_tipo_venda)
            this.qtde_venda = parseFloat(item?.qtde_venda)
            this.flag_geral = 0
            this.preco_unitario = parseFloat(item?.preco_unitario)
            this.perc_desconto = parseFloat(item?.perc_desconto)
            this.flg_ativo = "S"
            this.idt_usuario_alteracao = item?.usuario	
            this.dth_inclusao = this.__defaultDateNow;							
            this.dth_alteracao = this.__defaultDateNow;			
        } catch (e) { 
            myTools.pagConsole(`M0085 _ Zanthus | tbZanthusTabMercadoriaTipoVendaQtde.binding 
                Error: 
                ${e}    
                `)
        }
        
    }

    ZanthusPostGre_CRUD(): string {
        try { 

            let script = `
                	INSERT INTO	tab_mercadoria_tipo_venda_qtde 
                            (	    cod_loja
                                ,	cod_mercadoria
                                ,	cod_tipo_venda
                                ,	flag_geral
                                ,	qtde_venda
                                ,	preco_unitario
                                ,	perc_desconto
                                ,	flag_ativo
                                ,	Dth_inclusao
                                ,	Dth_alteracao
                                ,	Idt_usuario_alteracao
                            )
                        SELECT			DISTINCT
                                        ${this.cod_loja}
                                    ,	'${this.cod_mercadoria}'
                                    ,	${this.cod_tipo_venda}
                                    ,   ${this.flag_geral}
                                    ,   ${this.qtde_venda}
                                    ,	${this.preco_unitario} 
                                    ,	${this.perc_desconto} 
                                    ,   '${this.flg_ativo}'
                                    ,	('${this.dth_inclusao}'::timestamp)
                                    ,	('${this.dth_alteracao}'::timestamp)
                                    ,	'${this.idt_usuario_alteracao}' 
                        WHERE NOT EXISTS ( SELECT 1 
                                           FROM   tab_mercadoria_tipo_venda_qtde a
                                           WHERE  a.cod_mercadoria = '${this.cod_mercadoria}' 
                                             AND  a.cod_tipo_venda = ${this.cod_tipo_venda}
                                          )
                        ;
                        UPDATE tab_mercadoria_tipo_venda_qtde x 
                        SET    preco_unitario = ${this.preco_unitario} 
                           ,   Dth_alteracao = ('${this.dth_alteracao}'::timestamp)
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

    ZanthusSQLServer_CRUD(): string {
        try { 

            let script = `
                	INSERT INTO	ZeusRetail.dbo.tab_mercadoria_tipo_venda_qtde 
                            (	    cod_loja
                                ,	cod_mercadoria
                                ,	cod_tipo_venda
                                ,	flag_geral
                                ,	qtde_venda
                                ,	preco_unitario
                                ,	perc_desconto
                                ,	flag_ativo
                                ,	Dth_inclusao
                                ,	Dth_alteracao
                                ,	Idt_usuario_alteracao
                            )
                        SELECT			DISTINCT
                                        ${this.cod_loja}
                                    ,	'${this.cod_mercadoria}'
                                    ,	${this.cod_tipo_venda}
                                    ,   ${this.flag_geral}
                                    ,   ${this.qtde_venda}
                                    ,	${this.preco_unitario} 
                                    ,	${this.perc_desconto} 
                                    ,   '${this.flg_ativo}'
                                    ,	'${myTools._datemomentDateToStr(this.dth_inclusao, "yyyy-MM-DD hh:mm:ss")}'
                                    ,	'${myTools._datemomentDateToStr(this.dth_alteracao, "yyyy-MM-DD hh:mm:ss")}'
                                    ,	'${this.idt_usuario_alteracao}' 
                        WHERE NOT EXISTS ( SELECT 1 
                                           FROM   ZeusRetail.dbo.tab_mercadoria_tipo_venda_qtde a
                                           WHERE  a.cod_mercadoria = '${this.cod_mercadoria}' 
                                             AND  a.cod_tipo_venda = ${this.cod_tipo_venda}
                                          )
                        ;
                        UPDATE  x 
                        SET    preco_unitario = ${this.preco_unitario} 
                           ,   Dth_alteracao = '${myTools._datemomentDateToStr(this.dth_alteracao, "yyyy-MM-DD hh:mm:ss")}'
                        FROM   ZeusRetail.dbo.tab_mercadoria_tipo_venda_qtde x 
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

