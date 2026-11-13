import { modelTb } from "../../../model/model"
import myTools from "../../../tools/Tools";

export default class tbZanthusTabMercadoria extends modelTb {
        pr_cdproduto: number
        prb_cdprodutobluesoft: number	
        prb_cdprodutobluesoftunitario: number	
        preg_cdbarra: string 
        cod_loja: number
        controle: string  									
        cod_mercadoria: string
        descricao: string 									
        descricao_abr: string									    
        cod_departamento: number 							
        cod_tributacao_mercadoria: number					
        cod_tecla: number 									
        percentual_desc_venda: number						
        permissao_venda: string  							
        percentual_reduz_b_calculo: number					
        indica_merc_peso_variavel: string					
        custo_unitario: number 								
        grupo_garantia: number								
        fator_seguranca_venda_estoque: number				
        unidade_venda: string								
        data_modo_preco: Date 							
        margem_mercadoria: number 							
        quantidade_embalagem: number 						
        cod_fornecedor: string								
        custo_moeda_estavel: number							
        aliquota_icms: number 								
        quantidade_bonus_venda: number						
        quantidade_max_preco_promo: number 					
        valor_total_preco_promocao: number 					
        custo_contabil: number 								
        quantidade_maxima_venda: number 					
        multiplica_pontos_valor_liq: number 				
        quantidade_pontos_venda: number 					
        cod_situacao_tributaria: string 					
        data_cadastro: Date 								
        data_ultima_alteracao: Date 						
        cod_ncm: number										
        cod_produto_pai: string 	
        cest: number
        cfop: number
        cod_sit_trib_pis: string
        cod_sit_trib_cofins: string
        aliquota_pis: number
        aliquota_cofins: number
        codigo_beneficio_fiscal: string
        flginativo: string
        constructor() {
            super();
            this.pr_cdproduto= 0
            this.prb_cdprodutobluesoft= 0	
            this.prb_cdprodutobluesoftunitario = 0	
            this.preg_cdbarra= `` 
            this.cod_loja= 0
            this.controle= ``  									
            this.cod_mercadoria= ``
            this.descricao= `` 									
            this.descricao_abr= ``									    
            this.cod_departamento= 0 							
            this.cod_tributacao_mercadoria= 0					
            this.cod_tecla= 0 									
            this.percentual_desc_venda= 0						
            this.permissao_venda= ``  							
            this.percentual_reduz_b_calculo= 0					
            this.indica_merc_peso_variavel= ``					
            this.custo_unitario= 0 								
            this.grupo_garantia= 0								
            this.fator_seguranca_venda_estoque= 0				
            this.unidade_venda= ``								
            this.data_modo_preco = this.__defaultDateNow;
            this.margem_mercadoria= 0 							
            this.quantidade_embalagem= 0 						
            this.cod_fornecedor= ``								
            this.custo_moeda_estavel= 0							
            this.aliquota_icms= 0 								
            this.quantidade_bonus_venda= 0						
            this.quantidade_max_preco_promo= 0 					
            this.valor_total_preco_promocao= 0 					
            this.custo_contabil= 0 								
            this.quantidade_maxima_venda= 0 					
            this.multiplica_pontos_valor_liq= 0 				
            this.quantidade_pontos_venda= 0 					
            this.cod_situacao_tributaria= `` 					
            this.data_cadastro = this.__defaultDateNow;							
            this.data_ultima_alteracao = this.__defaultDateNow;			
            this.cod_ncm= 0										
            this.cod_produto_pai= `` 	
            this.cest= 0
            this.cfop= 0
            this.cod_sit_trib_pis= ``
            this.cod_sit_trib_cofins= ``
            this.aliquota_pis= 0
            this.aliquota_cofins= 0
            this.codigo_beneficio_fiscal = ``
            this.flginativo= `N`
            
        } 

        async binding(item: any): Promise<void> {
            try { 

                this.pr_cdproduto = parseInt(item?.pr_cdproduto)
                this.prb_cdprodutobluesoft = parseInt(item?.prb_cdprodutobluesoft)	
                this.prb_cdprodutobluesoftunitario  = parseInt(item?.prb_cdprodutobluesoftunitario)	
                this.preg_cdbarra = item?.preg_cdbarra
                this.cod_loja = parseInt(item?.cod_loja)
                this.controle = item?.controle 									
                this.cod_mercadoria = item?.cod_mercadoria
                this.descricao = item?.descricao
                this.descricao_abr = item?.descricao_abr
                this.cod_departamento = parseInt(item?.cod_departamento) 							
                this.cod_tributacao_mercadoria = parseInt(item?.cod_tributacao_mercadoria)					
                this.cod_tecla = parseInt(item?.cod_tecla) 									
                this.percentual_desc_venda = parseFloat(item?.percentual_desc_venda)						
                this.permissao_venda = item?.permissao_venda
                this.percentual_reduz_b_calculo = parseFloat(item?.percentual_reduz_b_calculo)					
                this.indica_merc_peso_variavel = item?.indica_merc_peso_variavel			
                this.custo_unitario = parseFloat(item?.custo_unitario) 								
                this.grupo_garantia = parseInt(item?.grupo_garantia)								
                this.fator_seguranca_venda_estoque = parseInt(item?.fator_seguranca_venda_estoque)				
                this.unidade_venda = item?.unidade_venda
                this.data_modo_preco = this.__defaultDateNow;
                this.margem_mercadoria = parseInt(item?.margem_mercadoria) 							
                this.quantidade_embalagem = parseFloat(item?.quantidade_embalagem) 						
                this.cod_fornecedor = item?.cod_fornecedor								
                this.custo_moeda_estavel = parseFloat(item?.custo_moeda_estavel)							
                this.aliquota_icms = parseFloat(item?.aliquota_icms) 								
                this.quantidade_bonus_venda = parseFloat(item?.quantidade_bonus_venda)						
                this.quantidade_max_preco_promo = parseFloat(item?.quantidade_max_preco_promo) 					
                this.valor_total_preco_promocao = parseInt(item?.pr_cdproduto) 					
                this.custo_contabil = parseFloat(item?.custo_contabil) 								
                this.quantidade_maxima_venda = parseFloat(item?.quantidade_maxima_venda) 					
                this.multiplica_pontos_valor_liq = parseFloat(item?.multiplica_pontos_valor_liq) 				
                this.quantidade_pontos_venda = parseFloat(item?.quantidade_pontos_venda) 					
                this.cod_situacao_tributaria = item?.cod_situacao_tributaria ? String(item.cod_situacao_tributaria).trim().padStart(3, '0') : ''		
                this.data_cadastro = this.__defaultDateNow;							
                this.data_ultima_alteracao = this.__defaultDateNow;			
                this.cod_ncm = parseInt(item?.cod_ncm)										
                this.cod_produto_pai= `` 	
                this.cest = parseInt(item?.cest)
                this.cfop = parseInt(item?.cfop)
                this.cod_sit_trib_pis = item?.cod_sit_trib_pis ? String(item.cod_sit_trib_pis).trim().padStart(3, '0') : ''
                this.cod_sit_trib_cofins = item?.cod_sit_trib_cofins ? String(item.cod_sit_trib_cofins).trim().padStart(3, '0') : ''
                this.aliquota_pis = parseFloat(item?.aliquota_pis)
                this.aliquota_cofins = parseFloat(item?.aliquota_cofins)
                this.codigo_beneficio_fiscal = item?.codigo_beneficio_fiscal
                this.flginativo = item?.flginativo ? String(item.flginativo).trim() : 'N'
                    


            } catch (e) { 
                myTools.pagConsole(`M0085 _ Zanthus | tbZanthusTab_Mercadoria.binding 
                    Error: 
                    ${e}    
                    `)
            }
        }

        ZanthusPostGre_CRUD(): string {
            try { 

                let script_SQL_TAB_MERCADORIA = `
                INSERT INTO		Tab_MERCADORIA
                                    (		cod_loja													
                                        ,	controle 													
                                        ,	cod_mercadoria 												
                                        ,	descricao 	
                                        ,   descricao_abr												
                                        ,	cod_departamento 											
                                        ,	cod_tributacao_mercadoria									
                                        ,	cod_tecla 													
                                        ,	percentual_desc_venda										
                                        ,	permissao_venda  											
                                        ,	percentual_reduz_b_calculo									
                                        ,	indica_merc_peso_variavel									
                                        ,	custo_unitario 												
                                        ,	grupo_garantia												
                                        ,	fator_seguranca_venda_estoque								
                                        ,	unidade_venda												
                                        ,	margem_mercadoria 											
                                        ,	quantidade_embalagem 										
                                        ,	cod_fornecedor												
                                        ,	custo_moeda_estavel											
                                        ,	aliquota_icms
                                        ,   aliquota_interna_icms 												
                                        ,	quantidade_bonus_venda										
                                        ,	quantidade_max_preco_promo 									
                                        ,	valor_total_preco_promocao 									
                                        ,	custo_contabil 												
                                        ,	quantidade_maxima_venda 									
                                        ,	multiplica_pontos_valor_liq 								
                                        ,	quantidade_pontos_venda 									
                                        ,	cod_situacao_tributaria 									
                                        ,   data_cadastro 												
                                        ,	data_ultima_alteracao 										
                                        ,	cod_ncm														
                                        ,	flg_troca_reembolso											
                                        ,	fator_preco_etiqueta										
                                        ,	texto_fator_preco_etiqueta									
                                        ,	qtd_etiqueta												
                                        ,	flag_serie_pdv
                                        ,	flag_controle_consumidor
                                        ,	flg_confere_kit
                                        ,	imprime_codigo_barras
                                        ,	flg_confere_peso
                                        ,	flg_venda_exclusiva
                                        ,	flg_duplo_check
                                        ,	flg_mobile
                                        ,	flg_item_premiado
                                        ,	flg_prod_patrocinado
                                        ,	flg_rastrear
                                        ,	flg_integracao_01
                                        ,	flg_integracao_02
                                        ,	alternativo_especial
                                        ,	flg_proibe_fidelizacao_selo
                                        ,	flg_fidelizacao_patrocinado
                                        ,	flg_fidelizacao_marca_propria
                                        ,	flg_artigos_promocionais
                                        ,	flg_proibe_selfcheckout
                                        ,	flg_converte_estoque
                                        ,	flg_forma_decomposicao
                                        ,	flg_combustivel
                                        ,	flg_rastreamento
                                        ,	indice_vinculado_finalizadora
                                        ,	flg_premiacao
                                        ,	flg_webstore
                                        ,	flg_sem_gtin
                                        ,	flg_venda_totem
                                        ,	flg_comanda
                                        ,	flg_certificado
                                        ,	data_modo_preco 		
                                        ,	modo_preco 
                                        ,	CEST 
                                        ,   cfop 
                                        ,   cod_sit_trib_pis
                                        ,   aliquota_pis
                                        ,   cod_sit_trib_cofins
                                        ,   aliquota_cofins
                                        ,   codigo_beneficio_fiscal
                                        )
    
                            SELECT			DISTINCT
                                            ${this.cod_loja}
                                        ,	'${this.controle}'
                                        ,	'${this.cod_mercadoria}'
                                        ,	'${this.descricao.replace(`'`, '')}'
                                        ,	'${this.descricao_abr.replace(`'`, '')}'
                                        ,	${this.cod_departamento}
                                        ,	${this.cod_tributacao_mercadoria}
                                        ,	${this.cod_tecla}
                                        ,	${this.percentual_desc_venda}
                                        ,	'${this.permissao_venda}'
                                        ,	${this.percentual_reduz_b_calculo}
                                        ,	'${this.indica_merc_peso_variavel}'
                                        ,	${this.custo_unitario}
                                        ,	${this.grupo_garantia}
                                        ,	${this.fator_seguranca_venda_estoque} 
                                        ,	'${this.unidade_venda}'
                                        ,	${this.margem_mercadoria}
                                        ,	${this.quantidade_embalagem}
                                        ,	'${this.cod_fornecedor}'
                                        ,	${this.custo_moeda_estavel}
                                        ,   ${this.aliquota_icms}
                                        ,   ${this.aliquota_icms} as aliquota_interna_icms
                                        ,	${this.quantidade_bonus_venda}
                                        ,	${this.quantidade_max_preco_promo}
                                        ,	${this.valor_total_preco_promocao}
                                        ,	${this.custo_contabil}
                                        ,	${this.quantidade_maxima_venda}
                                        ,	${this.multiplica_pontos_valor_liq}
                                        ,	${this.quantidade_pontos_venda} 
                                        ,  '${this.cod_situacao_tributaria}'
                                        ,  ('${this.data_cadastro}'::timestamp)
                                        ,  ('${this.data_ultima_alteracao}'::timestamp)
                                        ,	${this.cod_ncm}
                                        ,		   'S' as  flg_troca_reembolso				   
                                        ,			1  as  fator_preco_etiqueta			
                                        ,			1  as  texto_fator_preco_etiqueta		
                                        ,			1  as  qtd_etiqueta					
                                        ,			0  as  flag_serie_pdv						
                                        ,			0  as  flag_controle_consumidor		
                                        ,			0  as  flg_confere_kit					
                                        ,			0  as  imprime_codigo_barras			
                                        ,			0  as  flg_confere_peso				
                                        ,			0  as  flg_venda_exclusiva				
                                        ,			0  as  flg_duplo_check					
                                        ,			0  as  flg_mobile						
                                        ,			0  as  flg_item_premiado				
                                        ,			0  as  flg_prod_patrocinado			
                                        ,			0  as  flg_rastrear					
                                        ,			0  as  flg_integracao_01				
                                        ,			0  as  flg_integracao_02				
                                        ,			0  as  alternativo_especial			
                                        ,			0  as  flg_proibe_fidelizacao_selo		
                                        ,			0  as  flg_fidelizacao_patrocinado		
                                        ,			0  as  flg_fidelizacao_marca_propria	
                                        ,			0  as  flg_artigos_promocionais		
                                        ,			0  as  flg_proibe_selfcheckout			
                                        ,			0  as  flg_converte_estoque			
                                        ,			0  as  flg_forma_decomposicao			
                                        ,			0  as  flg_combustivel					
                                        ,			0  as  flg_rastreamento				
                                        ,			0  as  indice_vinculado_finalizadora	
                                        ,			0  as  flg_premiacao					
                                        ,			0  as  flg_webstore					
                                        ,			0  as  flg_sem_gtin					
                                        ,		  'N'  as  flg_venda_totem					
                                        ,		  'N'  as  flg_comanda						
                                        ,		  'N'  as  flg_certificado					
                                        ,		 ('1900-01-01'::DATE)  as  DATA_MODO_PRECO					  
                                        ,		  '1'  as  modo_preco						
                                        ,	      ${this.cest}
                                        ,         ${this.cfop}
                                        ,        '${this.cod_sit_trib_pis}'
                                        ,         ${this.aliquota_pis}
                                        ,        '${this.cod_sit_trib_cofins}'
                                        ,         ${this.aliquota_cofins}
                                        ,        '${this.codigo_beneficio_fiscal}'
                            WHERE  1 = 1
                              AND  NOT EXISTS ( SELECT 1 FROM tab_mercadoria a 
                                                WHERE  a.cod_mercadoria = '${this.cod_mercadoria}'
                                              ); 

                            UPDATE  tab_mercadoria x
                               SET  descricao                   = '${this.descricao.replace(`'`, '')}'
                                ,   descricao_abr               = '${this.descricao_abr.replace(`'`, '')}'
                                ,   cod_tributacao_mercadoria   = ${this.cod_tributacao_mercadoria}
                                ,   cod_situacao_tributaria     = '${this.cod_situacao_tributaria}'
                                ,   percentual_reduz_b_calculo  = ${this.percentual_reduz_b_calculo}
                                ,   indica_merc_peso_variavel   = '${this.indica_merc_peso_variavel}'
                                ,   unidade_venda               = '${this.unidade_venda}'
                                ,   quantidade_embalagem        = ${this.quantidade_embalagem}
                                ,   aliquota_icms               = ${this.aliquota_icms}
                                ,   aliquota_interna_icms       = ${this.aliquota_icms}
                                ,   cod_ncm                     = ${this.cod_ncm}
                                ,   cest                        = ${this.cest}
                                ,   data_ultima_alteracao       = current_timestamp
                                ,   cfop                        = ${this.cfop}
                                ,   cod_sit_trib_pis            = '${this.cod_sit_trib_pis}'
                                ,   aliquota_pis                = ${this.aliquota_pis}
                                ,   cod_sit_trib_cofins         = '${this.cod_sit_trib_cofins}'
                                ,   aliquota_cofins             = ${this.aliquota_cofins}
                                ,   codigo_beneficio_fiscal     = '${this.codigo_beneficio_fiscal}'
                                ,   flginativo                  = '${this.flginativo}'
                            WHERE   x.cod_mercadoria = '${this.cod_mercadoria}'
                            
                            ;   
                `
            


                return script_SQL_TAB_MERCADORIA; 


            } catch (e) {
                myTools.pagConsole(`M0085_ZANTHUS | tbZanthusTabMercadoria - _Db_Pg_script_CRUD
                                    Item ${this.pr_cdproduto} / ${this.descricao} 
                                    Error \n ${e}
                                   `)
                return ``
            }
        }



}

