/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS REPORT _ tab_mercadoria_select"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
    const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE : string = `LOG_TESTE`
/*  ____________________________________________________________________________________________*/    



/*
-------------------------------------------------------------------------------------------------------------------------------------
B18.15 _ 18/08/2026, terça feira - 09:00 
-------------------------------------------------------------------------------------------------------------------------------------
- Alteração no scriptSelect() para obter os produtos pendentes. Os produtos pendentes eram selecionados de acordo com o pr_cdproduto
e agora passarão a ser selecionados pelo prb_cdprodutobluesoftUNITARIO.
a) Esta tabela/campo será alimentada em várias etapas na execução das
    - f0021_01_1012018_produtobluesoft_crud  
    - f0021_90_1012018_produtobluesoft_processamento

    Código anterior ________________________________________________________________________________________
                             + (this.filter.ProdutosPendentesDeIntegracao?
                  ` and ( 			pr.pr_cdproduto in (
		                                               select x.pr_cdproduto 
		                                               from   tbintegracao_produto x 
		                                               where  1 = 1
		                                                 and  x.integracao_tipo_cd = 20008501
		                                                 and  x.integracao_status_cd = 2
		                  
		                                            )
    Código atual ___________________________________________________________________________________________
                             + (this.filter.ProdutosPendentesDeIntegracao?
                  ` and ( 			pr.prb_cdprodutobluesoft in (
		                                               select x.prb_cdprodutobluesoftunitario 
		                                               from   tbintegracao_produto x 
		                                               where  1 = 1
		                                                 and  x.integracao_tipo_cd = 20008501
		                                                 and  x.integracao_status_cd = 2
		                  
		                                            )
-------------------------------------------------------------------------------------------------------------------------------------

*/



import 'dotenv/config'
import tbZanthusTabMercadoria from "../tbs/tbZanthusTabMercadoria";
import reportZanthusType from "./ReportFilterType";
import { clsTools, clsBase } from "../../../model/modelbase";




export default class reportZanthusTabMercadoria_Select {
    filter : reportZanthusType
    constructor(filter : Partial<reportZanthusType>) {
        
     
        this.filter = filter;
    }

    async tblist_Get() : Promise<Array<tbZanthusTabMercadoria>> {
        let listTabMercadoria : tbZanthusTabMercadoria[] = []
        try {


            let myClsBase : clsBase = new clsBase()
            let result : any = await myClsBase.myDataBase.pag.DataGet(this.scriptSelect())



            for await ( const[key, value] of Object.entries(result)) {
                let itemTbZanthusTab_Mercadoria : tbZanthusTabMercadoria = new tbZanthusTabMercadoria()
                itemTbZanthusTab_Mercadoria.binding(value)
                listTabMercadoria.push(itemTbZanthusTab_Mercadoria)

                if (process.env.ZANTHUS_TIPO_CARGA_LOG && process.env.ZANTHUS_TIPO_CARGA_LOG == "1") {
                   await clsTools.pagConsole(`${FLG_MODULO} | Produto: ${itemTbZanthusTab_Mercadoria.pr_cdproduto} - ${itemTbZanthusTab_Mercadoria.descricao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG_TESTE)
                }
                
            }



        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, `report.tab_mercadoria_select | tblist_Get`, e);
        }
        finally {
            await clsTools.pagConsole(`${FLG_MODULO} | Total de produtos selecionados: ${listTabMercadoria.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG_TESTE)
            return listTabMercadoria
        }
    }
    




    private scriptSelect() : string {

        let sqlscript : string = `` 
        sqlscript =   `SELECT	me.pr_cdproduto				
                            ,   pr.prb_cdprodutobluesoft as prb_cdprodutobluesoftunitario 				
                            ,	me.prb_cdprodutobluesoft						
                            ,	me.preg_cdbarra								
                            ,	me.cod_loja 									
                            ,	me.controle 									
                            ,	me.cod_mercadoria 								
                            ,	me.descricao 									
                            ,	me.desc_abr             as descricao_abr								
                            ,	me.cod_departamento 							
                            ,	me.cod_tributacao_mercadoria					
                            ,	me.cod_tecla 									
                            ,	me.percentual_desc_venda						
                            ,	me.permissao_venda  							
                            ,	me.percentual_reduz_b_calculo					
                            ,	me.indica_merc_peso_variavel					
                            ,	me.custo_unitario 								
                            ,	me.grupo_garantia								
                            ,	me.fator_seguranca_venda_estoque				
                            ,	me.unidade_venda								
                            ,	me.data_modo_preco 							
                            ,	me.margem_mercadoria 							
                            ,	me.quantidade_embalagem 						
                            ,	me.cod_fornecedor								
                            ,	me.custo_moeda_estavel							
                            ,	me.aliquota_icms 								
                            ,	me.quantidade_bonus_venda						
                            ,	me.quantidade_max_preco_promo 					
                            ,	me.valor_total_preco_promocao 					
                            ,	me.custo_contabil 								
                            ,	me.quantidade_maxima_venda 					
                            ,	me.multiplica_pontos_valor_liq 				
                            ,	me.quantidade_pontos_venda 					
                            ,	me.cod_situacao_tributaria 					
                            ,   me.data_cadastro 								
                            ,	me.data_ultima_alteracao 						
                            ,	me.cod_ncm										
                            ,	me.cod_produto_pai	
                            ,	me.cest 
                            ,   me.cfop
                            ,   me.cod_sit_trib_pis
                            ,   me.aliquota_pis
                            ,   me.cod_sit_trib_cofins
                            ,   me.aliquota_cofins
                            ,   coalesce(me.codigo_beneficio_fiscal, '') as codigo_beneficio_fiscal
                FROM            tbzanthustab_mercadoria me
                inner join      tbproduto pr on pr.pr_cdproduto = me.pr_cdproduto
                WHERE   1 = 1 
                `

                if (this.filter.ProdutosPendentesDeIntegracao 
                    && this.filter.ProdutosPendentesDeIntegracao == true
                    && this.filter.integracao_tipo_cd
                    && this.filter.integracao_tipo_cd > 0
                ) {

                 sqlscript +=
                  ` and ( 	   pr.prb_cdprodutobluesoft in (
		                                               select x.prb_cdprodutobluesoftunitario
		                                               from   tbintegracao_produto x 
		                                               where  1 = 1
		                                                 and  x.integracao_tipo_cd = ${this.filter.integracao_tipo_cd || 20008501}
		                                                 and  x.integracao_status_cd = 2
		                  
		                                            )
					 or 
							   pr.prb_cdprodutobluesoft in (select xx.prb_cdprodutobluesoft 
							                       from   TbZanthustab_produto_decomposicao_insum xx
		                                            where xx.pr_cdproduto in (select ax.pr_cdproduto 
							                                               from   tbintegracao_produto ax 
							                                               where  1 = 1
							                                                 and  ax.integracao_tipo_cd = ${this.filter.integracao_tipo_cd || 20008501}
							                                                 and  ax.integracao_status_cd = 2
																			group by ax.pr_cdproduto 
																		  )
													group by  xx.prb_cdprodutobluesoft 
												)
					)
                            `
                 }

                 if (this.filter.AlteracaoTributaria === "1") { 
                                sqlscript += ` and (    pr.prb_cdprodutobluesoft in ( select prb_cdprodutobluesoft_pk from tbprodutobluesoft where prb_dt_ultimaalteracao >= current_date - interval '5 day' ) 
                                                     or pr.prb_cdprodutobluesoft in ( select prb_cdprodutobluesoft from tbfc_regrafiscal_nfce_produto where dtlog_update >=  current_date - interval '1 day')
                                                    )
                                               and pr.pr_status = 'true'
                                `
                    }
        
 
        return sqlscript;
    }
}