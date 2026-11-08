

import { clsTools, clsBase } from '../../../model/modelbase';


export default class tbfaturamento_bluesoft_item extends clsBase {
    dtlog_insert: Date
    dtlog_update: Date
    op_cdoperacao: number
    embalagem_descricao: string
    df_nf_seq_blue: number
    fat_blue_item_seq: number
    fat_blue_origem_seq: number
    item_nf_bonificado: number
    numeropedido_fv: number
    numeropedido: number
    prb_cdprodutobluesoft: number
    prb_cdprodutobluesoft_unitario: number
    prb_embalagem
    prb_fatorestoque: number
    qtde_faturada: number
    qtde_solicitada: number
    qtde_unitaria_faturada: number
    qtde_unitaria_solicitada: number
    valor_custo_com_icm: number
    valor_custo_com_icm_unit: number
    valor_custo: number
    valor_desconto_financeiro: number
    valor_nf_item_bruto: number
    valor_nf_item: number
    valor_preco_aplicado: number
    valor_preco: number
    valor_preco_tabela: number
    valor_verba_calculada: number
    valor_verba_gerencia: number
    valor_verba: number
    valor_verba_supervisao: number
    percentual_desconto_financeiro: number
    cdpessoabluesoft_cliente: number
    
    constructor() {
        super()
        this.op_cdoperacao = 0
        this.dtlog_insert= this.__defaultDateNow 
        this.dtlog_update= this.__defaultDateNow 
        this.embalagem_descricao= ''
        this.df_nf_seq_blue= 0
        this.fat_blue_item_seq= 0
        this.fat_blue_origem_seq= 0
        this.item_nf_bonificado= 0 
        this.numeropedido= 0
        this.numeropedido_fv= 0
        this.prb_cdprodutobluesoft= 0
        this.prb_cdprodutobluesoft_unitario= 0
        this.prb_embalagem= ''
        this.prb_fatorestoque= 0 
        this.qtde_faturada= 0 
        this.qtde_solicitada= 0 
        this.qtde_unitaria_faturada= 0 
        this.qtde_unitaria_solicitada= 0 
        this.valor_custo= 0 
        this.valor_custo_com_icm= 0 
        this.valor_custo_com_icm_unit= 0 
        this.valor_desconto_financeiro= 0 
        this.valor_nf_item= 0 
        this.valor_nf_item_bruto= 0 
        this.valor_preco= 0 
        this.valor_preco_aplicado= 0 
        this.valor_preco_tabela= 0 
        this.valor_verba= 0 
        this.valor_verba_calculada= 0 
        this.valor_verba_gerencia= 0 
        this.valor_verba_supervisao= 0 
        this.percentual_desconto_financeiro= 0
        this.cdpessoabluesoft_cliente= 0
    }
    async binding(item: any): Promise<void> {
        try { 
            if (item) {
                this.dtlog_insert = clsTools._datemomentDatStrToDate(item?.dtlog_insert,`YYYY-MM-DD HH:mm:ss`)
                this.dtlog_update = clsTools._datemomentDatStrToDate(item?.dtlog_update,`YYYY-MM-DD HH:mm:ss`)
                this.embalagem_descricao = item?.embalagem_descricao || ''
                this.df_nf_seq_blue = item?.df_nf_seq_blue || 0
                this.fat_blue_item_seq = item?.fat_blue_item_seq || 0
                this.fat_blue_origem_seq = item?.fat_blue_origem_seq || 0
                this.item_nf_bonificado = item?.item_nf_bonificado || 0
                this.numeropedido_fv = item?.numeropedido_fv || 0
                this.numeropedido = item?.numeropedido || 0 
                this.prb_cdprodutobluesoft = item?.prb_cdprodutobluesoft || 0
                this.prb_cdprodutobluesoft_unitario = item?.prb_cdprodutobluesoft_unitario || 0
                this.prb_embalagem = item?.prb_embalagem || ''
                this.prb_fatorestoque = item?.prb_fatorestoque || 0
                this.qtde_faturada = item?.qtde_faturada || 0
                this.qtde_solicitada = item?.qtde_solicitada || 0
                this.qtde_unitaria_faturada = item?.qtde_unitaria_faturada || 0
                this.qtde_unitaria_solicitada = item?.qtde_unitaria_solicitada || 0
                this.valor_custo_com_icm = item?.valor_custo_com_icm || 0
                this.valor_custo_com_icm_unit = item?.valor_custo_com_icm_unit || 0
                this.valor_custo = item?.valor_custo || 0
                this.valor_desconto_financeiro = item?.valor_desconto_financeiro || 0
                this.valor_nf_item_bruto = item?.valor_nf_item_bruto || 0
                this.valor_nf_item = item?.valor_nf_item || 0
                this.valor_preco_aplicado = item?.valor_preco_aplicado || 0
                this.valor_preco = item?.valor_preco || 0
                this.valor_preco_tabela = item?.valor_preco_tabela || 0
                this.valor_verba_calculada = item?.valor_verba_calculada || 0
                this.valor_verba_gerencia = item?.valor_verba_gerencia || 0
                this.valor_verba = item?.valor_verba || 0
                this.valor_verba_supervisao = item?.valor_verba_supervisao || 0
                this.cdpessoabluesoft_cliente = item?.cdpessoabluesoft_cliente || 0
                this.op_cdoperacao = item?.op_cdoperacao || 0
            }
        } catch (e) {
            await clsTools.PagErrorException("tbfaturamento_bluesoft_item", "binding", e);
        }
    }


    async scriptFaturamentoBlueSoft_Update() : Promise<string> { 
        let sql = ``        

        try { 
          sql = `	UPDATE 		tbfaturamento_bluesoft_item				i	
                    set 		dtlog_update								= current_timestamp 

                            ,	df_nf_seq_blue								= ${this.df_nf_seq_blue}

                            ,	prb_embalagem 								= '${this.prb_embalagem}' 					
                            ,	prb_fatorestoque 							= ${this.prb_fatorestoque} 				
                            ,	embalagem_descricao 						= '${this.embalagem_descricao}' 			

                            ,	qtde_unitaria_solicitada					= ${this.qtde_unitaria_solicitada}	
                            ,	qtde_unitaria_faturada						= ${this.qtde_unitaria_faturada}			
                            ,	qtde_solicitada								= ${this.qtde_solicitada}				
                            ,	qtde_faturada								= ${this.qtde_faturada}					

                            ,	valor_custo_com_icm_unit					= ${this.valor_custo_com_icm_unit}		
                            ,	valor_custo_com_icm							= ${this.valor_custo_com_icm}			
                            ,	valor_custo									= ${this.valor_custo}					

                            ,	valor_preco_tabela							= ${this.valor_preco_tabela}				
                            ,	valor_preco									= ${this.valor_preco}					
                            ,	valor_preco_aplicado						= ${this.valor_preco_aplicado}			

                            ,	valor_verba									= ${this.valor_verba}					
                            ,	valor_verba_gerencia						= ${this.valor_verba_gerencia}			
                            ,	valor_verba_supervisao						= ${this.valor_verba_supervisao}			
                            ,	valor_verba_calculada						= ${this.valor_verba_calculada}			

                            ,	percentual_desconto_financeiro				= ${this.percentual_desconto_financeiro}

                            ,	valor_nf_item_bruto							= ${this.valor_nf_item_bruto}			
                            ,	valor_nf_item								= ${this.valor_nf_item}					
                            ,	item_nf_bonificado							= ${this.item_nf_bonificado}				
                    FROM    		tbfaturamento_bluesoft X
                    WHERE	1 = 1
                    AND    x.fat_blue_seq = i.fat_blue_seq
                    AND	x.numeropedido 				 = ${this.numeropedido}
                    AND   x.numeropedido_fv			 = ${this.numeropedido_fv}
                    AND 	x.cdpessoabluesoft_cliente  = ${this.cdpessoabluesoft_cliente}
                    AND   x.op_cdoperacao 			= ${this.op_cdoperacao}
                    AND   i.prb_cdprodutobluesoft 	 = ${this.prb_cdprodutobluesoft}
			
			
			;
        `

        } catch (e) {
            await clsTools.PagErrorException("modelFaturamentoBluesoft", "script_update", e);
        } finally { 
            return sql;
        }
        
    }

    async ScriptFaturamentoBluesoft_Insert() : Promise<string> { 
        let sql = ``; 
        try { 
            sql = `
			INSERT INTO tbfaturamento_bluesoft_item
					(			fat_blue_seq 
							,	op_cdoperacao 
							, 	numeropedido 								
							,	numeropedido_fv			
							,	df_nf_seq_blue
							,	cdpessoabluesoft_cliente

							,	prb_cdprodutobluesoft			
							,	prb_cdprodutobluesoft_unitario 	
							,	prb_embalagem 					
							,	prb_fatorestoque 				
							,	embalagem_descricao 			

							,	qtde_unitaria_solicitada		
							,	qtde_unitaria_faturada			
							,	qtde_solicitada					
							,	qtde_faturada					

							,	valor_custo_com_icm_unit		
							,	valor_custo_com_icm				
							,	valor_custo						

							,	valor_preco_tabela				
							,	valor_preco						
							,	valor_preco_aplicado			

							,	valor_verba						
							,	valor_verba_gerencia			
							,	valor_verba_supervisao			
							,	valor_verba_calculada			

							,	percentual_desconto_financeiro		

							,	valor_nf_item_bruto 			
							,	valor_nf_item					
							,	item_nf_bonificado							
		
				)
			SELECT 				f.fat_blue_seq
							,	f.op_cdoperacao
							,	f.numeropedido 								
							,	f.numeropedido_fv	
							,	f.df_nf_seq_blue 
							,	f.cdpessoabluesoft_cliente

							,	${this.prb_cdprodutobluesoft}
							,	${this.prb_cdprodutobluesoft_unitario}
							,	'${this.prb_embalagem}'
							,	${this.prb_fatorestoque} 			
							,	'${this.embalagem_descricao}'		

							,	${this.qtde_unitaria_solicitada}	
							,	${this.qtde_unitaria_faturada}		
							,	${this.qtde_solicitada}				
							,	${this.qtde_faturada}				

							,	${this.valor_custo_com_icm_unit}	
							,	${this.valor_custo_com_icm}			
							,	${this.valor_custo}					

                            ,	${this.valor_preco_tabela}			
							,	${this.valor_preco}					
							,	${this.valor_preco_aplicado}		

                            ,	${this.valor_verba}					
							,	${this.valor_verba_gerencia}		
							,	${this.valor_verba_supervisao}		
							,	${this.valor_verba_calculada}		

                            ,	${this.percentual_desconto_financeiro}

                            ,	${this.valor_nf_item_bruto} 		
							,	${this.valor_nf_item}				
							,	${this.item_nf_bonificado}		
			FROM 				tbfaturamento_bluesoft f
			WHERE				1 = 1
			AND				f.numeropedido 				 = ${this.numeropedido}
			AND   			f.numeropedido_fv			 = ${this.numeropedido_fv}
			AND 			f.cdpessoabluesoft_cliente  = ${this.cdpessoabluesoft_cliente}
			AND				f.op_cdoperacao 			= ${this.op_cdoperacao} 
			AND	 NOT EXISTS ( 	SELECT 			1 
								FROM 			tbfaturamento_bluesoft_item 	i
								INNER JOIN 		tbfaturamento_bluesoft 		x on x.fat_blue_seq = i.fat_blue_seq
								WHERE 	1 = 1
								  AND	x.numeropedido 				 = ${this.numeropedido}
							      AND   x.numeropedido_fv			 = ${this.numeropedido_fv}
								  AND 	x.cdpessoabluesoft_cliente  = ${this.cdpessoabluesoft_cliente}
								  AND   i.prb_cdprodutobluesoft 	 = ${this.prb_cdprodutobluesoft}
								  AND   f.op_cdoperacao 			= ${this.op_cdoperacao}
								 )
                 
             ;            
            `
        }
        catch(e) { 
            await clsTools.PagErrorException("modelFaturamentoBluesoft", "script_insert", e);
        } finally { 
            return sql;
        }
    }
}