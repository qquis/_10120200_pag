import serviceNotificacao from "../../../modules/m0210_notificacao/service/_serviceNotificacao";
import { clsTools, clsBase } from "../../../model/modelbase";
import tbfaturamentovipnotificacao from "../tbs/tbfaturamentoVipNotificacao";




export default class modelfaturamentovipNotificacao extends tbfaturamentovipnotificacao {
    data_entrega : Date
    qtd_itens : number
    qtd_produtos: number
    valor_final : number
    compra_status_descricao : string
    vip_nome : string
    cliente_id : number
    constructor() { 
        super()
        this.data_entrega = new Date()
        this.qtd_itens = 0
        this.qtd_produtos = 0
        this.valor_final = 0
        this.compra_status_descricao = ""
        this.vip_nome = ""
        this.cliente_id = 0
    }

    modelBinding(item: any) {
        if (item) {
            super.binding(item)
            this.data_entrega = item.data_entrega
            this.qtd_itens = item.qtd_itens
            this.qtd_produtos = item.qtd_produtos
            this.valor_final = item.valor_final
            this.compra_status_descricao = item.compra_status_descricao
            this.vip_nome = item.vip_nome
            this.cliente_id = item.cliente_id
            
        }
    }

    async notificar() : Promise<void> {
        try {

            
            let myDataBase: clsBase = new clsBase()
        
            let message: string =  ``
                switch (this.compra_status_id) {
                    case 13:
                        message += `*VIP/E-commerce | Pedido Aguardando Separação* 📦 \n`
                        break;
                    case 11:
                        message += `*VIP/E-commerce | Pedido Em atendimento* 🧑‍💼 \n`
                        break;   
                    case 38:
                        message += `*VIP/E-commerce | Pedido em Análise de antifraude* ❌🔍 \n`
                        break; 
                    default:
                        message += `*VIP/E-commerce* \n`
                        break;
                }
                message += `Numero do Pedido *${this.id}* \n`
                message += `Cliente *${this.cliente_id} - ${this.vip_nome}* \n`
                message += `Data de Entrega *${clsTools._datemomentDateToStr(this.data_entrega, "dddd, DD/MM/YYYY HH:mm")}* \n`
                message += `Quantidade de Itens *${this.qtd_itens}* \n `
                message += `Quantidade de Produtos *${this.qtd_produtos}* \n`
                message += `Status do Pedido *${this.compra_status_descricao}* \n`
                message += `Valor Final *${this.valor_final}* \n`
                                    
                        
            
            await serviceNotificacao.Criar({notificacao_cd : 1000510010 , notificacao_send_tipo_cd : 100, notificacao_send_message : message}) 


            let sqlAtualizarPendenciaNotificacao = `UPDATE tbfaturamento_vip_notificacao set notificado = 1 where faturamento_vip_notificacao_seq = ${this.faturamento_vip_notificacao_seq}`
            await myDataBase.myDataBase.pag.Execute(sqlAtualizarPendenciaNotificacao)
            

        } catch (e: any) {
            clsTools.PagErrorException(`F0051 - Faturamento VIP`, `modelfaturamentovip.notificar()`, e, true);
            throw new Error(`modules | Faturamento VIP | Error ${e.message}`);
    
        }
    }
}