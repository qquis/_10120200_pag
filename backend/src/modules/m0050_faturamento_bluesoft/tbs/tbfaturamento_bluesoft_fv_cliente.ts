import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfaturamento_bluesoft_fv_cliente extends clsBase {
        numeropedido: number 				
		numeropedido_fv: number 			
		cdpessoabluesoft_cliente: number	
		pedido_status_cd: number		
        pedido_status_descricao_redshift: string	 

        constructor() {
            super()
            this.numeropedido = 0
            this.numeropedido_fv = 0
            this.cdpessoabluesoft_cliente = 0
            this.pedido_status_cd = 0
            this.pedido_status_descricao_redshift = ""
            
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.numeropedido = item?.numeropedido
                this.numeropedido_fv = item?.numeropedido_fv
                this.cdpessoabluesoft_cliente = item?.cdpessoabluesoft_cliente
                this.pedido_status_cd = item?.pedido_status_cd
                this.pedido_status_descricao_redshift = item?.pedido_status_descricao_redshift
            
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
                this.pedido_status_cd = item?.pedidoVendaStatusKey
            }
        }
        async scriptSqlInsert() : Promise<string> {
            let sql = ``
            try { 
                sql = ` 
                            INSERT INTO tbfaturamento_bluesoft_fv_cliente (
                                numeropedido_fv
                            ,   numeropedido
                            ,   cdpessoabluesoft_cliente
                            ,   pedido_status_cd
                        ) SELECT 
                                ${this.numeropedido_fv}
                            ,   ${this.numeropedido}
                            ,   ${this.cdpessoabluesoft_cliente}
                            ,   ${this.pedido_status_cd}
                        WHERE NOT EXISTS 
                            (   SELECT 1 
                                FROM    tbfaturamento_bluesoft_fv_cliente 
                                WHERE   numeropedido_fv = ${this.numeropedido_fv}
                                AND     numeropedido = ${this.numeropedido}
                            )
                            ;

                        update tbfaturamento_bluesoft_fv_cliente set
                            pedido_status_cd = ${this.pedido_status_cd}
                        where numeropedido_fv = ${this.numeropedido_fv}
                        and numeropedido = ${this.numeropedido}
                        ;
                
                        `
            } catch (e) {

            }
            finally {
                return sql;
            }
        }


}