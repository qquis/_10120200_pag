
import { clsTools, clsBase } from '../../../model/modelbase';

export default class tbfaturamento_bluesoft extends clsBase {
    cdpessoabluesoft_cliente: number
    cdpessoabluesoft_vendedor: number
    df_nf_seq_blue: number
    df_nf_seq_blue_dev: number
    data_emissao: Date
    data_faturamento: Date
    data_solicitacao: Date
    dtlog_insert: Date
    dtlog_update: Date
    fat_blue_seq: number
    fat_blue_status_cd: number
    fat_blue_tipo_cd: number
    fv_prazopgto_cd: number
    numero_itens: number
    numeropedido_fv: number
    numeropedido: number
    op_cdoperacao: number
    origem_pedido: string
    tabelapreco_cd: number
    tabelapreco_versao_cd: number
    tipo_entrega_descricao: string
    transportadora_descricao: string
    transportadora_placaveiculo: string
    valor_faturamento: number
    valor_pedido: number
    descontofinanceiro: number
    constructor() {
        super()
        this.cdpessoabluesoft_cliente= 0
        this.cdpessoabluesoft_vendedor= 0
        this.df_nf_seq_blue= 0
        this.df_nf_seq_blue_dev= 0
        this.data_emissao= this.__defaultDateNow 
        this.data_faturamento= this.__defaultDateNow 
        this.data_solicitacao= this.__defaultDateNow 
        this.dtlog_insert= this.__defaultDateNow 
        this.dtlog_update= this.__defaultDateNow 
        this.fat_blue_seq= 0
        this.fat_blue_status_cd= 0
        this.fat_blue_tipo_cd= 0
        this.fv_prazopgto_cd= 0
        this.numero_itens= 0
        this.numeropedido= 0
        this.numeropedido_fv= 0
        this.op_cdoperacao= 0
        this.origem_pedido= ''
        this.tabelapreco_cd= 0
        this.tabelapreco_versao_cd= 0
        this.tipo_entrega_descricao= ''
        this.transportadora_descricao= ''
        this.transportadora_placaveiculo= ''
        this.valor_faturamento= 0 
        this.valor_pedido= 0 
        this.descontofinanceiro = 0;
    }
    async binding(item: any): Promise<void> {
        if (item) {
            this.cdpessoabluesoft_cliente = item?.cdpessoabluesoft_cliente
            this.cdpessoabluesoft_vendedor = item?.cdpessoabluesoft_vendedor
            this.data_emissao = item?.data_emissao
            this.data_faturamento = item?.data_faturamento
            this.data_solicitacao = item?.data_solicitacao
            this.dtlog_insert = clsTools._datemomentDatStrToDate(item?.dtlog_insert,`YYYY-MM-DD HH:mm:ss`)
            //this.dtlog_update = clsTools._datemomentDatStrToDate(item?.dtlog_update,`YYYY-MM-DD HH:mm:ss`)
            this.df_nf_seq_blue = item?.df_nf_seq_blue
            this.df_nf_seq_blue_dev = item?.df_nf_seq_blue_dev

            this.fat_blue_seq = item?.fat_blue_seq
            this.fat_blue_status_cd = item?.fat_blue_status_cd
            this.fat_blue_tipo_cd = item?.fat_blue_tipo_cd
            this.fv_prazopgto_cd = item?.fv_prazopgto_cd
            this.numero_itens = item?.numero_itens
            this.numeropedido_fv = item?.numeropedido_fv
            this.numeropedido = item?.numeropedido
            this.op_cdoperacao = item?.op_cdoperacao
            this.origem_pedido = item?.origem_pedido
            this.tabelapreco_cd = item?.tabelapreco_cd
            this.tabelapreco_versao_cd = item?.tabelapreco_versao_cd
            this.tipo_entrega_descricao = item?.tipo_entrega_descricao
            this.transportadora_descricao = item?.transportadora_descricao
            this.transportadora_placaveiculo = item?.transportadora_placaveiculo
            this.valor_faturamento = item?.valor_faturamento
            this.valor_pedido = item?.valor_pedido
            this.descontofinanceiro = item?.descontofinanceiro || 0 
        }
    }


    async bindingApiForcaVenda (dadosPedidoCliente: any, dadosPedidoForca: any) : Promise<void> { 
        try { 

        
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
                this.descontofinanceiro = dadosPedidoCliente?.descontofinanceiro? dadosPedidoCliente.descontofinanceiro : 0
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



            sql += ` update tbfaturamento_bluesoft
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
        }
        catch(e) { 
            await clsTools.PagErrorException("modelFaturamentoBluesoft", "script_insert", e);
        } finally { 
            return sql;
        }
    }
}