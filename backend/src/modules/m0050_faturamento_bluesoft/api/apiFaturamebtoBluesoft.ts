import { AnyARecord } from "dns";
import { clsBase, clsTools } from "../../../model/modelbase";

const myClsBase = new clsBase();

export default class apiFaturamentoBluesoft { 
    static async obterPedidosBluesoft(parametro: any): Promise<any> {
        let result : any = {}
        try { 
            if ( parametro.numeropedido_fv && parametro.numeropedido_fv != "") {
                result = await myClsBase.blueSoftApi.api_get(`forca-de-vendas/pedidos/${ parametro.numeropedido_fv}`)
            } else { 
                console.log("consultou pela data")
                result =  await myClsBase.blueSoftApi.api_get(`forca-de-vendas/pedidos?dataEmissaoInicial=01/02/2026 00:01&dataEmissaoFinal=02/02/2026 23:59`)
            }
            
            
            console.log(result.data.data.length)

            for (let pedido of result.data.data) {
                if (pedido.pedidoForcaVendaKey == 329846) { 
                    console.log(`Numero do pedido ${pedido.pedidoForcaVendaKey}`)
                    console.log(pedido)
                    for (let item of pedido.itens)
                    {
                        console.log(`Produto: ${item.produtoKey} | Quantidade: ${item.quantidadePedida} | Valor Unitário: ${item.preco}`)
                    }
                }
            }
            

            
        } catch (e) {
            clsTools.pagConsole(`apiFaturamentoBluesoft | obterPedidoBlueSoft \n Error: ${e}`);
            return {}
        }
    }
}