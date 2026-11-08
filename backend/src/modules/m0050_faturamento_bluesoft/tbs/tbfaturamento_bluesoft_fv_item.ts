import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfaturamento_bluesoft_fv_item extends clsBase {
        numeropedido: number 				
		numeropedido_fv: number 			
		cdpessoabluesoft_cliente: number	
		prb_cdprodutobluesoft: number	
		qtde_pedida: number				
		qtde_bonificada: number 		
		qtde_separada: number			
        valor_preco: number
		valor_preco_final: number		
		valor_total: number				
		valor_total_separado: number	

        constructor() {
            super()
            this.numeropedido = 0
            this.numeropedido_fv = 0
            this.cdpessoabluesoft_cliente = 0
            this.prb_cdprodutobluesoft = 0
            this.qtde_pedida = 0
            this.qtde_bonificada = 0
            this.qtde_separada = 0
            this.valor_preco = 0
            this.valor_preco_final = 0
            this.valor_total = 0
            this.valor_total_separado = 0
            
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.numeropedido = item?.numeropedido
                this.numeropedido_fv = item?.numeropedido_fv
                this.cdpessoabluesoft_cliente = item?.cdpessoabluesoft_cliente
                this.prb_cdprodutobluesoft = item?.prb_cdprodutobluesoft
                this.qtde_pedida = item?.qtde_pedida
                this.qtde_bonificada = item?.qtde_bonificada
                this.qtde_separada = item?.qtde_separada
                this.valor_preco = item?.valor_preco
                this.valor_preco_final = item?.valor_preco_final
                this.valor_total = item?.valor_total
                this.valor_total_separado = item?.valor_total_separado
            
            }
        }
        async bindingFromRedShift(item: any): Promise<void> {
            if (item) {
                if (item) { 
                    Object.assign(this, item);
                }
            }
        }
        async bindingFromApiForcaVenda(item: any, numeropedido_fv: number = 0) : Promise<void> {
            if (item) {
                this.numeropedido_fv = item?.pedidoForcaVendaKey || numeropedido_fv
                this.numeropedido = item?.pedidoForcaVendaClienteKey
                this.cdpessoabluesoft_cliente = item?.clienteKey
                this.numeropedido = item?.pedidoForcaVendaClienteKey
                this.prb_cdprodutobluesoft = item?.produtoKey
                
                
                this.valor_preco = item?.preco
                this.valor_preco_final = item?.precoFinalEmbalagem || item?.precoFinal || 0
                this.valor_total = item?.valorTotal
                this.valor_total_separado = item?.valorTotalSeparado || 0
                
                this.qtde_pedida = item?.quantidadePedida || item?.quantidade || 0
                this.qtde_bonificada = item?.quantidadeBonificada
                this.qtde_separada = item?.quantidadeSeparada || 0

/*
					"produtoKey": 228677,
					"preco": 4.748,
					"quantidadePedida": 12,
					"quantidadeBonificada": 0,
					"clienteKey": 4953,
					"precoFinalEmbalagem": 4.890,
					"valorTotal": 58.680000,
					"valorTotalSeparado": 0

                    "pedidoForcaVendaItemKey": 2384965,
                    "quantidade": 12.000,
                    "quantidadeBonificada": 0.000,
                    "origemVerba": "FUNCIONARIO",
                    "descricaoProduto": "SUCO MARATA NECTAR UVA TP 1LT",
                    "produtoKey": 228677,
                    "fabricanteKey": 125224,
                    "estoque": 3369.0000000000000000,
                    "fatorPreco": 1.0,
                    "fatorEstoque": 1.0,
                    "itemFatorEstoque": 1.0,
                    "clienteKey": 4953,
                    "preco": 4.748,
                    "precoVariacao": 0.00,
                    "precoFinal": 4.89,
                    "valorTotal": 58.68000
            
*/





            }
        }
        async scriptSqlInsert() : Promise<string> {
            let sql = ``
            try { 
                sql = ` 
                          
                        INSERT INTO tbfaturamento_bluesoft_fv_item (
                                numeropedido_fv
                            ,   numeropedido
                            ,   cdpessoabluesoft_cliente
                            ,   prb_cdprodutobluesoft
                            ,   qtde_pedida
                            ,   qtde_bonificada
                            ,   qtde_separada
                            ,   valor_preco
                            ,   valor_preco_final
                            ,   valor_total
                            ,   valor_total_separado
                        ) SELECT
                                ${this.numeropedido_fv}
                            ,   ${this.numeropedido}
                            ,   ${this.cdpessoabluesoft_cliente}
                            ,   ${this.prb_cdprodutobluesoft}
                            ,   ${this.qtde_pedida}
                            ,   ${this.qtde_bonificada}
                            ,   ${this.qtde_separada}
                            ,   ${this.valor_preco}
                            ,   ${this.valor_preco_final}
                            ,   ${this.valor_total}
                            ,   ${this.valor_total_separado}
                        WHERE NOT EXISTS
                            (   SELECT 1 
                                FROM    tbfaturamento_bluesoft_fv_item
                                WHERE   numeropedido_fv = ${this.numeropedido_fv}
                                AND     numeropedido = ${this.numeropedido}
                                AND     prb_cdprodutobluesoft = ${this.prb_cdprodutobluesoft}

                            );

                            UPDATE tbfaturamento_bluesoft_fv_item SET
                                    qtde_pedida = ${this.qtde_pedida}
                                ,   qtde_bonificada = ${this.qtde_bonificada}
                                ,   qtde_separada = ${this.qtde_separada}
                                ,   valor_preco = ${this.valor_preco}
                                ,   valor_preco_final = ${this.valor_preco_final}
                                ,   valor_total = ${this.valor_total}
                                ,   valor_total_separado = ${this.valor_total_separado}
                            WHERE numeropedido_fv = ${this.numeropedido_fv}
                                AND numeropedido = ${this.numeropedido}
                                AND prb_cdprodutobluesoft = ${this.prb_cdprodutobluesoft}

                            ;

                        `
            } catch (e) {

            }
            finally {
                return sql;
            }
        }


}