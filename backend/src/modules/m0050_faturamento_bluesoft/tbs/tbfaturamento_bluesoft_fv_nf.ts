import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfaturamento_bluesoft_fv_nf extends clsBase {
        numeropedido: number 				
		numeropedido_fv: number 			
		cdpessoabluesoft_cliente: number	
		df_nf_seq_blue: number				
		df_nf_numero: number				
		df_nf_tipo: number
		df_valor: number		
        df_data_emissao: Date			 

        constructor() {
            super()
            this.numeropedido = 0
            this.numeropedido_fv = 0
            this.cdpessoabluesoft_cliente = 0
            this.df_nf_seq_blue = 0
            this.df_nf_numero = 0
            this.df_nf_tipo = 0
            this.df_valor = 0
            this.df_data_emissao = new Date()

            
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.numeropedido = item?.numeropedido
                this.numeropedido_fv = item?.numeropedido_fv
                this.cdpessoabluesoft_cliente = item?.cdpessoabluesoft_cliente
                this.df_nf_seq_blue = item?.df_nf_seq_blue
                this.df_nf_numero = item?.df_nf_numero
                this.df_nf_tipo = item?.df_nf_tipo
                this.df_valor = item?.df_valor
                
            
            }
        }
        async bindingFromApiForcaVenda(item: any, numeropedido_fv: number = 0) : Promise<void> {
            if (item) {
                this.numeropedido_fv = item?.pedidoForcaVendaKey || numeropedido_fv
                this.numeropedido = item?.pedidoForcaVendaClienteKey
                this.df_nf_numero = item?.nfNumero
                this.df_nf_seq_blue = item?.nfKey
                if (item?.nfTipo) {
                    this.df_nf_tipo = item?.nfTipo?.notaFiscalTipoKey
                }
                this.df_valor = item?.valorNf
                this.df_data_emissao = clsTools._datemomentDatStrToDate(item.nfDataEmissao, "DD/MM/YYYY")

            }
        }
        async scriptSqlInsert() : Promise<string> {
            let sql = `
            
                insert into tbfaturamento_bluesoft_fv_nf
                    (
                            numeropedido 				
                        ,	numeropedido_fv 			
                        ,	cdpessoabluesoft_cliente	
                        ,	df_nf_seq_blue				
                        ,	df_nf_numero				
                        ,	df_nf_tipo					
                        ,	df_valor		
                        ,   df_data_emissao			
                        )
                    select ${this.numeropedido}
                        ,   ${this.numeropedido_fv}
                        ,   ${this.cdpessoabluesoft_cliente}
                        ,   ${this.df_nf_seq_blue}
                        ,   ${this.df_nf_numero}
                        ,   ${this.df_nf_tipo}
                        ,   ${this.df_valor}
                        ,   '${clsTools._datemomentDateToStr(this.df_data_emissao, "YYYY-MM-DD")}'  
                    where not exists (
                        select 1 from tbfaturamento_bluesoft_fv_nf
                            where numeropedido = ${this.numeropedido}
                                and numeropedido_fv = ${this.numeropedido_fv}
                                and cdpessoabluesoft_cliente = ${this.cdpessoabluesoft_cliente}
                                and df_nf_seq_blue = ${this.df_nf_seq_blue}
                    );
            `

            try { 
            } catch (e) {

            }
            finally {
                return sql;
            }
        }
}