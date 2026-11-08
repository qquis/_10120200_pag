import { clsTools, clsBase } from "../../../model/modelbase";
import tbforca_venda_pedido from "../tbs/tbfaturamento_bluesoft_fv";
import tbfaturamento_bluesoft_fv_cliente from "../tbs/tbfaturamento_bluesoft_fv_cliente";
import tbforca_venda_pedido_nf from "../tbs/tbfaturamento_bluesoft_fv_nf";


export default class modelFaturamentoBluesoft_Fv extends tbforca_venda_pedido {
    list_pedido_cliente : tbfaturamento_bluesoft_fv_cliente[]
    list_pedido_nf : tbforca_venda_pedido_nf[]
    constructor() { 
        super()
        this.list_pedido_cliente = []
        this.list_pedido_nf = []
    }


    async bindingRedhisft_FaturamentoBluesoft_fv(item: any) : Promise<void> {
        try { 
                if (item) { 
                    Object.assign(this, item);
                }


        } catch (e) { 

        }
    
    
    }

    async bindingApiForcaVenda(dadosPedidoForca: any) : Promise<void> {
        try { 

            if (dadosPedidoForca) { 
                this.numeropedido_fv = dadosPedidoForca?.pedidoForcaVendaKey
                this.cdpessoabluesoft_vendedor = dadosPedidoForca?.vendedorExternoKey
                this.tabelapreco_cd = dadosPedidoForca?.tabelaPrecoVendaKey
                this.tabelapreco_versao_cd = dadosPedidoForca?.tabelaPrecoVersao
                this.data_emissao = clsTools._datemomentDatStrToDate(dadosPedidoForca.dataEmissao, "DD/MM/YYYY HH:mm")
                this.cdgrupoeconomico = dadosPedidoForca?.grupoEconomicoKey


                let listPedidoCliente : tbfaturamento_bluesoft_fv_cliente[] = []

                if (dadosPedidoForca?.clientes && Array.isArray(dadosPedidoForca.clientes)) { 
                    for await (const cliente of dadosPedidoForca.clientes) { 
                        let itemCliente : tbfaturamento_bluesoft_fv_cliente = new tbfaturamento_bluesoft_fv_cliente()
                        itemCliente.cdpessoabluesoft_cliente = cliente?.clienteKey
                        itemCliente.numeropedido_fv = dadosPedidoForca?.pedidoForcaVendaKey
                        itemCliente.numeropedido = cliente?.pedidoForcaVendaClienteKey
                        itemCliente.pedido_status_cd = cliente?.pedidoVendaStatusKey
                        listPedidoCliente.push(itemCliente)
                    }
                }
                this.list_pedido_cliente = listPedidoCliente

            }

            


        } catch (e) { 
            await clsTools.PagErrorException("modelFaturamentoBluesoft_Fv", "bindingApiForcaVenda", e)
        }

    }

    async scriptSqlInsert() : Promise<string> {
        let sql = ``
        try { 

            sql = `INSERT INTO tbfaturamento_bluesoft_fv (
                    numeropedido_fv			
				,	cdpessoabluesoft_vendedor	
				,	tabelapreco_cd				
				,	tabelapreco_versao_cd		
				,	data_emissao		
                ,   cdgrupoeconomico		
                ,   fv_prazopgto_cd
            
                ) SELECT 
                    ${this.numeropedido_fv}
                ,   ${this.cdpessoabluesoft_vendedor}
                ,   ${this.tabelapreco_cd}
                ,   ${this.tabelapreco_versao_cd}
                ,   '${clsTools._datemomentDateToStr(this.data_emissao, "YYYY-MM-DD HH:mm:ss")}'
                ,   ${this.cdgrupoeconomico}
                ,   ${this.fv_prazopgto_cd}
                    WHERE NOT EXISTS (SELECT 1 
                                FROM tbfaturamento_bluesoft_fv 
                                WHERE numeropedido_fv = ${this.numeropedido_fv}


                ); 
                
                UPDATE tbfaturamento_bluesoft_fv SET
                    cdpessoabluesoft_vendedor = ${this.cdpessoabluesoft_vendedor}
                ,   tabelapreco_cd = ${this.tabelapreco_cd}
                ,   tabelapreco_versao_cd = ${this.tabelapreco_versao_cd}
                ,   cdgrupoeconomico = ${this.cdgrupoeconomico}
                ,   fv_prazopgto_cd = case when ${this.fv_prazopgto_cd} > 0 then fv_prazopgto_cd else ${this.fv_prazopgto_cd} end
                ,   dtlog_update  = current_timestamp
                WHERE numeropedido_fv = ${this.numeropedido_fv};
                
                `

                for await (const cliente of this.list_pedido_cliente) { 
                    sql += ` 
                            INSERT INTO tbfaturamento_bluesoft_fv_cliente (
                                numeropedido_fv
                            ,   numeropedido
                            ,   cdpessoabluesoft_cliente
                            ,   pedido_status_cd
                        ) SELECT 
                                ${cliente.numeropedido_fv}
                            ,   ${cliente.numeropedido}
                            ,   ${cliente.cdpessoabluesoft_cliente}
                            ,   ${cliente.pedido_status_cd}
                        WHERE NOT EXISTS 
                            (   SELECT 1 
                                FROM    tbfaturamento_bluesoft_fv_cliente 
                                WHERE   numeropedido_fv = ${cliente.numeropedido_fv}
                                AND     numeropedido = ${cliente.numeropedido}
                            )
                            ;

                            `
                }

        } catch (e) {
            await clsTools.PagErrorException("modelforca_venda_prazopgto", "scriptSqlInsert", e)
        }
        finally {
            return sql 
        }
    }


}
    