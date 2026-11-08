import { ca } from 'date-fns/locale';
import { clsTools, clsBase } from '../../../model/modelbase';

import tbfaturamento_bluesoft from "../tbs/tbfaturamento_bluesoft";
import tbfaturamento_bluesoft_item from "../tbs/tbfaturamento_bluesoft_item";


import reportFaturamentoBluesoft from "../report/report";
import reportFaturamentoBluesoftItemList from "../report/reportFaturamentoBluesoftItemList";


export default class modelFaturamentoBluesoft extends tbfaturamento_bluesoft {
    
    itens : tbfaturamento_bluesoft_item[]

    

    constructor() { 
        super();
        this.itens = [];
    }


    static async Consultar(filtro: any) : Promise<any> { 
        let faturamento : any = { }
        try { 
            
            if (!filtro.op_cdoperacao || filtro.op_cdoperacao == 0) {
                throw new Error("O filtro de código de operação é obrigatório para consulta de faturamento bluesoft")
            }



            if (!filtro.numeropedido_fv || filtro.numeropedido_fv == 0) {
                throw new Error("O filtro de número do pedido fv é obrigatório para consulta de faturamento bluesoft")
            }



            if (!filtro.numeropedido || filtro.numeropedido == 0) {
                throw new Error("O filtro de número do pedido é obrigatório para consulta de faturamento bluesoft")
            }

            
            let dadosFaturamento = await reportFaturamentoBluesoft.list.get(filtro)

            if (dadosFaturamento && Array.isArray(dadosFaturamento) && dadosFaturamento.length > 0) {
            
                faturamento = (dadosFaturamento as any[])[0]
                faturamento.itens = await reportFaturamentoBluesoftItemList.get(filtro)
            
            }
            




        } catch (e) {
            clsTools.PagErrorException("modelFaturamentoBluesoft.Consultar", "Error: ", e)
        }

        finally {
            return faturamento
        }
    }
    model_binding(item : any) {
        try {
                if (item) {
                    // Mapeamento automático de propriedades com mesmo nome
                    Object.assign(this, item);
                }
        } catch (e) {
            clsTools.PagErrorException("modelFaturamentoBluesoft", "model_binding", e); 
        }
    }

    bindingRedshift(item : any) { 
        try { 
                if (item) {
                    // Mapeamento automático de propriedades com mesmo nome
                    Object.assign(this, item);
                }

        } catch (e) { 
            clsTools.PagErrorException("modelFaturamentoBluesoft", "bindingRedshift", e);
        }


    }

  async bindingApiForcaVenda (dadosPedidoCliente: any, dadosPedidoForca: any) : Promise<void> { 
        try { 

            /*
                pedido 369045 venda 414046
                pedido 369045 venda 414067
	"clientes": [
				{
					"pedidoForcaVendaClienteKey": 397078,
					"clienteKey": 19182,
					"numeroPedidoCliente": "",
					"quantidadeTotal": 204,
					"valorTotal": 2331.960000,
					"pedidoVendaStatusKey": 18,
					"pedidoVendaStatus": "CANCELADO",
					"statusNfe": "Autorizada",
					"valorNf": 2331.96,
					"nfKey": 885868,
					"nfNumero": 168040,
					"nfSerie": "3",
					"nfChave": "35260357895328000130550030001680401747530636",
					"nfDataEmissao": "12/03/2026",
					"nfTipo": {
						"notaFiscalTipoKey": 104,
						"descricao": "Nota fiscal de venda a cliente do força de venda"
					}
				},
				{
					"pedidoForcaVendaClienteKey": 397078,
					"clienteKey": 19182,
					"numeroPedidoCliente": "",
					"quantidadeTotal": 204,
					"valorTotal": 2331.960000,
					"pedidoVendaStatusKey": 18,
					"pedidoVendaStatus": "CANCELADO",
					"statusNfe": "Autorizada",
					"valorNf": 2331.96,
					"nfKey": 886467,
					"nfNumero": 168097,
					"nfSerie": "3",
					"nfChave": "35260357895328000130550030001680971305173806",
					"nfDataEmissao": "13/03/2026",
					"nfTipo": {
						"notaFiscalTipoKey": 27,
						"descricao": "Nota fiscal de Recusa de Entrada"
					}
				}


                pedidoForcaVendaKey": 376376,
			"tipoFormaPagamentoKey": 3,
			"prazoPagamentoFvKey": 125,
			"filialKey": 1,
"numeroPedidoExterno": "105883",
			"pedidoVendaStatusKey": 2,
			"pedidoVendaStatus": "FECHADO",
			"grupoEconomicoKey": 3867,
			"tabelaPrecoVersao": 653,
			"tabelaPrecoVendaKey": 841,
			"vendedorExternoKey": 22413,
			"tipoFreteKey": 3,
			"prazoPagamentoVersao": 1,
			"clientes": [
				{
					"pedidoForcaVendaClienteKey": 420555,
					"clienteKey": 9270,
					"numeroPedidoCliente": "",
					"quantidadeTotal": 74,
					"valorTotal": 987.940000,
					"pedidoVendaStatusKey": 19,
					"pedidoVendaStatus": "EM_ANALISE_DE_CREDITO"
				}
			],
			"origemPedidoForcaVenda": "MOBILE",
			"dataEmissao": "28/04/2026 14:54",
			"canalVendaKey": 1,
			"descontoFinanceiro": 0.00,
			"custoFinanceiro": 1.0307736925,
			"usuarioKey": 22413,
			"vigenciaInicial": "28/04/2026 00:00",
			"vigenciaFinal": "03/05/2026 00:00",
			"motivoClienteBloqueado": "",
			"tipoPedidoVenda": "Venda",
			"tipoPedidoVendaKey": 1

                */

            if (dadosPedidoCliente) { 
                this.op_cdoperacao = 1

                let tipoVenda : number = dadosPedidoForca?.tipoPedidoVendaKey
                switch (tipoVenda) {
                    case 1:
                        this.fat_blue_tipo_cd = 10
                        break;
                    case 2:
                        this.fat_blue_tipo_cd = 20
                        break;                        
                
                    default:
                        this.fat_blue_tipo_cd = 10
                        break;
                }



                let numero_itens : number = 0

                for await (const itemProduto of dadosPedidoForca.itens as any[])
                {
                    if (itemProduto.clienteKey ==  dadosPedidoCliente?.clienteKey)
                        numero_itens ++
                }

                this.numero_itens = numero_itens


                this.numeropedido_fv = dadosPedidoForca?.pedidoForcaVendaKey
                this.numeropedido = dadosPedidoCliente?.pedidoForcaVendaClienteKey
                this.cdpessoabluesoft_cliente = dadosPedidoCliente?.clienteKey
                this.cdpessoabluesoft_vendedor = dadosPedidoForca?.vendedorExternoKey
                this.tabelapreco_cd = dadosPedidoForca?.tabelaPrecoVendaKey
                this.tabelapreco_versao_cd = dadosPedidoForca?.tabelaPrecoVersao
                this.data_emissao = clsTools._datemomentDatStrToDate(dadosPedidoForca.dataEmissao, "DD/MM/YYYY HH:mm")
                this.data_solicitacao = clsTools._datemomentDatStrToDate(dadosPedidoForca.dataEmissao, "DD/MM/YYYY HH:mm")
                this.fv_prazopgto_cd = dadosPedidoForca?.prazoPagamentoFvKey
                this.descontofinanceiro = dadosPedidoCliente?.descontoFinanceiro? dadosPedidoCliente.descontoFinanceiro : 0
                this.valor_pedido = dadosPedidoCliente?.valorTotal
                this.origem_pedido = dadosPedidoForca?.origemPedidoForcaVenda
                

                if (dadosPedidoCliente?.nfKey)
                { 
                    if (dadosPedidoCliente?.nfTipo?.notaFiscalTipoKey == 27) { 
                        this.df_nf_seq_blue_dev = dadosPedidoCliente.nfKey
                        this.valor_faturamento = 0
                    } else { 
                        this.df_nf_seq_blue_dev = 0
                        this.df_nf_seq_blue = dadosPedidoCliente.nfKey
                        this.data_faturamento = clsTools._datemomentDatStrToDate(dadosPedidoCliente.nfDataEmissao, "DD/MM/YYYY")
                        this.valor_faturamento = dadosPedidoCliente?.valorNf? dadosPedidoCliente.valorNf : 0
                    }
                    
                }
                
            }


        } catch (e) { 
            await clsTools.PagErrorException(`modelfaturamentobluesoft`, `bindingapi`, e, false, ``)
        }
    }

    async scriptFaturamentoBlueSoft_Update() : Promise<string> { 
        let sql = `` 
        
        try { 
            sql = ` update tbfaturamento_bluesoft
                    set df_nf_seq_blue = case when ${parseInt(this.df_nf_seq_blue.toString())} = 0 then df_nf_seq_blue else ${parseInt(this.df_nf_seq_blue.toString())} end
                    ,   df_nf_seq_blue_dev = case when ${parseInt(this.df_nf_seq_blue_dev.toString())} = 0 then df_nf_seq_blue_dev else ${parseInt(this.df_nf_seq_blue_dev.toString())} end
                    ,	cdpessoabluesoft_cliente = ${this.cdpessoabluesoft_cliente}
                    ,	cdpessoabluesoft_vendedor = ${this.cdpessoabluesoft_vendedor}	
                    ,	tabelapreco_cd = ${this.tabelapreco_cd}				
                    ,	tabelapreco_versao_cd = ${this.tabelapreco_versao_cd}		
                    ,	fv_prazopgto_cd	= ${this.fv_prazopgto_cd}			
                    ,	tipo_entrega_descricao = '${this.tipo_entrega_descricao}'		
                    ,	origem_pedido = '${this.origem_pedido}'				
                    ,	data_solicitacao = '${clsTools._datemomentDateToStr(this.data_solicitacao, "YYYY-MM-DD")}'			
                    ,	data_emissao = '${clsTools._datemomentDateToStr(this.data_emissao, "YYYY-MM-DD")}'				
                    ,	data_faturamento = case when  ${parseInt(this.df_nf_seq_blue.toString())} > 0 then '${clsTools._datemomentDateToStr(this.data_faturamento, "YYYY-MM-DD")}' else data_faturamento end
                    ,	numero_itens = ${this.numero_itens}				
                    ,	valor_pedido = ${this.valor_pedido}
                    ,	valor_faturamento = ${this.valor_faturamento}
                    ,   descontofinanceiro = ${this.descontofinanceiro}
                    ,   dtlog_update = current_timestamp 
                    where numeropedido = ${this.numeropedido} 
                      and numeropedido_fv = ${this.numeropedido_fv}
                      and op_cdoperacao = ${this.op_cdoperacao}
                      ;
                 `

            } catch (e) {
                await clsTools.PagErrorException("modelFaturamentoBluesoft", "script_update", e);
            } finally { 
                return sql;
            }
        
    }

    async ScriptFaturamentoBluesoft_RedSfhit() : Promise<string> { 
        let sql = ``; 
        try { 
            sql = `
                        INSERT INTO tbfaturamento_bluesoft
                        (			op_cdoperacao 
                                ,	numeropedido 				
                                ,	numeropedido_fv
                                ,	df_nf_seq_blue
                                ,	df_nf_seq_blue_dev 
                                ,	fat_blue_status_cd 			
                                ,	fat_blue_tipo_cd			
                                ,	cdpessoabluesoft_cliente	
                                ,	cdpessoabluesoft_vendedor	
                                ,	tabelapreco_cd				
                                ,	tabelapreco_versao_cd		
                                ,	fv_prazopgto_cd				
                                ,	tipo_entrega_descricao 		
                                ,	origem_pedido 				
                                ,	data_solicitacao 			
                                ,	data_emissao 				
                                ,	data_faturamento			
                                ,	numero_itens				
                                ,	valor_pedido				
                                ,	valor_faturamento
                                ,   descontofinanceiro 
                        )
                        SELECT      ${this.op_cdoperacao} AS op_cdoperacao
                                ,   ${this.numeropedido} AS numeropedido
                                ,   ${this.numeropedido_fv} AS numeropedido_fv
                                ,   ${parseInt(this.df_nf_seq_blue.toString())} AS df_nf_seq_blue
                                ,   ${parseInt(this.df_nf_seq_blue_dev.toString())} AS df_nf_seq_blue_dev
                                ,   ${this.fat_blue_status_cd} AS fat_blue_status_cd
                                ,   ${this.fat_blue_tipo_cd} AS fat_blue_tipo_cd
                                ,   ${this.cdpessoabluesoft_cliente} AS cdpessoabluesoft_cliente
                                ,   ${this.cdpessoabluesoft_vendedor} AS cdpessoabluesoft_vendedor
                                ,   ${this.tabelapreco_cd} AS tabelapreco_cd
                                ,   ${this.tabelapreco_versao_cd} AS tabelapreco_versao_cd
                                ,   ${this.fv_prazopgto_cd} AS fv_prazopgto_cd
                                ,   '${this.tipo_entrega_descricao}' AS tipo_entrega_descricao
                                ,   '${this.origem_pedido}' AS origem_pedido
                                ,   '${clsTools._datemomentDateToStr(this.data_solicitacao, "YYYY-MM-DD HH:mm")}' AS data_solicitacao
                                ,   '${clsTools._datemomentDateToStr(this.data_emissao, "YYYY-MM-DD")}' AS data_emissao
                                ,   '${clsTools._datemomentDateToStr(this.data_faturamento, "YYYY-MM-DD")}' AS data_faturamento
                                ,   ${this.numero_itens} AS numero_itens
                                ,   ${this.valor_pedido} AS valor_pedido
                                ,   ${this.valor_faturamento} AS valor_faturamento
                                ,   ${this.descontofinanceiro} as descontofinanceiro 
                        WHERE NOT EXISTS (
                            SELECT 1 FROM tbfaturamento_bluesoft 
                            WHERE numeropedido = ${this.numeropedido} 
                            AND numeropedido_fv = ${this.numeropedido_fv}
                            AND op_cdoperacao = ${this.op_cdoperacao}
                        ) ; 
                         
            `; 
        }
        catch(e) { 
            await clsTools.PagErrorException("modelFaturamentoBluesoft", "script_insert", e);
        } finally { 
            return sql;
        }
        
        
    }

    async scriptForcaVendaPedido_insert() : Promise<string> {
        let sql = ``;
        try { 
                sql = `INSERT INTO tbforca_venda_pedido
                                (
                                    numeropedido 				
                                ,	numeropedido_fv 			
                                ,	cdpessoabluesoft_cliente	
                                ,	cdpessoabluesoft_vendedor	
                                ,	data_emissao				
                                ,	data_faturamento			
                                ,	pedido_status_cd			
                                )

                        SELECT      ${this.numeropedido} AS numeropedido
                                ,   ${this.numeropedido_fv} AS numeropedido_fv
                                ,   ${this.cdpessoabluesoft_cliente} AS cdpessoabluesoft_cliente
                                ,   ${this.cdpessoabluesoft_vendedor} AS cdpessoabluesoft_vendedor
                                ,   '${clsTools._datemomentDateToStr(this.data_emissao, "YYYY-MM-DD")}' AS data_emissao
                                ,   '${clsTools._datemomentDateToStr(this.data_faturamento, "YYYY-MM-DD")}' AS data_faturamento
                                ,   ${this.fat_blue_status_cd} AS pedido_status_cd
                        WHERE NOT EXISTS (
                            SELECT 1 FROM tbforca_venda_pedido 
                            WHERE numeropedido = ${this.numeropedido}
                            AND numeropedido_fv = ${this.numeropedido_fv}
                        ) ; 
                 
                 `


        } catch (e) {
            await clsTools.PagErrorException("modelFaturamentoBluesoft", "scriptForcaVendaPedido_insert", e);

        }
        finally {
            return sql;
        }
        
    }
}