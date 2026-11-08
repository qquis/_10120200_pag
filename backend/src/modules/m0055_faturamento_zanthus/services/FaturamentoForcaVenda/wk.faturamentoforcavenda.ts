import bluesoft_api from '../../../Apis/bluesoftApi/url/bluesoftApiUrl'

class FaturamentoForcaVendaItem
{
    produtoKey: number
    constructor() {
        this.produtoKey = 0;
    }  
}

class FaturamentoForcaVenda {
    pedidoForcaVendaKey: number 
    itens: FaturamentoForcaVendaItem[]
    constructor() {
        this.pedidoForcaVendaKey = 0;
        this.itens = []
    }
}

export default class faturamentoforcavenda {
    public static async Obter() : Promise<object> {

        let dados =  await bluesoft_api.api_get(`https://erp.bluesoft.com.br/oxan/api/forca-de-vendas/pedidos?dataEmissaoInicial=18/01/2024`)
        let dadosResulta = dados.data.data;
        console.log(dadosResulta)
        let resultado : faturamentoforcavenda[] = Array.from(dadosResulta).map((item: any) =>
            {
                return {
                    pedidoForcaVendaKey: item.pedidoForcaVendaKey
                }
            }
        )

        console.log(resultado);

        


        return []
    }
}