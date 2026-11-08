import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbforca_venda_pedido extends clsBase {
		numeropedido_fv: number
		cdpessoabluesoft_vendedor: number
		data_emissao: Date
        tabelapreco_cd: number
        tabelapreco_versao_cd: number    
        cdgrupoeconomico: number    
        fv_prazopgto_cd: number
        pedido_tipo_cd: number
        descontoFinanceiro: number

        constructor() {
            super()

            this.numeropedido_fv = 0
            this.cdpessoabluesoft_vendedor = 0
            this.data_emissao = new Date()
            this.tabelapreco_cd = 0
            this.tabelapreco_versao_cd = 0
            this.cdgrupoeconomico = 0
            this.fv_prazopgto_cd = 0
            this.pedido_tipo_cd = 0
            this.descontoFinanceiro = 0
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.numeropedido_fv = item?.numeropedido_fv
                this.cdpessoabluesoft_vendedor = item?.cdpessoabluesoft_vendedor
                this.data_emissao = clsTools._datemomentDatStrToDate(item?.data_emissao, "YYYY-MM-DD HH:mm")
                this.tabelapreco_cd = item?.tabelapreco_cd
                this.tabelapreco_versao_cd = item?.tabelapreco_versao_cd
                this.cdgrupoeconomico = item?.cdgrupoeconomico
                this.fv_prazopgto_cd = item?.fv_prazopgto_cd
                this.pedido_tipo_cd = item?.pedido_tipo_cd
                this.descontoFinanceiro = item?.descontoFinanceiro
            }
        }
        async bindingFromRedShift(item: any): Promise<void> {
            if (item) {
                if (item) { 
                    Object.assign(this, item);
                }
            }
        }
        async bindingFromApiForcaVenda(item: any) : Promise<void> {
            if (item) {
                this.numeropedido_fv = item?.pedidoForcaVendaKey
                this.cdpessoabluesoft_vendedor = item?.vendedorExternoKey
                this.tabelapreco_cd = item?.tabelaPrecoVendaKey
                this.tabelapreco_versao_cd = item?.tabelaPrecoVersao
                this.data_emissao = clsTools._datemomentDatStrToDate(item.dataEmissao, "DD/MM/YYYY HH:mm")
                this.cdgrupoeconomico = item?.grupoEconomicoKey
                this.fv_prazopgto_cd = item?.prazoPagamentoFvKey
                this.pedido_tipo_cd = item?.tipoPedidoVendaKey
                this.descontoFinanceiro = item?.descontoFinanceiro
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
                    ,   pedido_tipo_cd
                    ,   descontoFinanceiro
                
                    ) SELECT 
                        ${this.numeropedido_fv}
                    ,   ${this.cdpessoabluesoft_vendedor}
                    ,   ${this.tabelapreco_cd}
                    ,   ${this.tabelapreco_versao_cd}
                    ,   '${clsTools._datemomentDateToStr(this.data_emissao, "YYYY-MM-DD HH:mm:ss")}'
                    ,   ${this.cdgrupoeconomico}
                    ,   ${this.fv_prazopgto_cd}
                    ,   ${this.pedido_tipo_cd}
                    ,   ${this.descontoFinanceiro}
                        WHERE NOT EXISTS (SELECT 1 
                                    FROM tbfaturamento_bluesoft_fv 
                                    WHERE numeropedido_fv = ${this.numeropedido_fv}


                    ); 
                    
                    UPDATE tbfaturamento_bluesoft_fv SET
                        cdpessoabluesoft_vendedor = ${this.cdpessoabluesoft_vendedor}
                    ,   tabelapreco_cd = ${this.tabelapreco_cd}
                    ,   tabelapreco_versao_cd = ${this.tabelapreco_versao_cd}
                    ,   cdgrupoeconomico = ${this.cdgrupoeconomico}
                    ,   fv_prazopgto_cd = case when ${this.fv_prazopgto_cd} > 0 then ${this.fv_prazopgto_cd} else fv_prazopgto_cd end
                    ,   pedido_tipo_cd = ${this.pedido_tipo_cd}
                    ,   descontoFinanceiro = ${this.descontoFinanceiro}
                    ,   dtlog_update  = current_timestamp
                    WHERE numeropedido_fv = ${this.numeropedido_fv};
                    
                    `
                } catch (e) {
                    await clsTools.PagErrorException("modelFaturamentoBluesoft_fv", "scriptSqlInsert", e);
                }
                finally {
                    return sql
                }
        }
}