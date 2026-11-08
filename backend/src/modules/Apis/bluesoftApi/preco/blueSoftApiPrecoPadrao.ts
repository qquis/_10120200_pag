import myTools from "../../../../tools/Tools"
import typeApi from "../type/typeApi"
import bluesoftApi from "../url/bluesoftApiUrl"



export default class blueSoftApiPrecoPadrao {

    constructor() {
        
    }
    async post (item: any) {
        let dados = {}
        try {
            if (item) {
                const myTypeApi : typeApi = this.getType(item)
                
                dados = myTypeApi.dados;
                
                //console.log("TESTE 04/12/2024 ------------")
                //console.log(JSON.stringify(myTypeApi.dados))
                
                let ResultadoBlue = {}
                
                ResultadoBlue = await bluesoftApi.api_post(myTypeApi.url, myTypeApi.dados )

                

                if (ResultadoBlue)
                    await myTools.pagConsole(`BlueSoftApi | Preco COMUM _ post | Item : ${item.prb_cdprodutobluesoftunitario} Processado com sucesso `)
                else 
                    await myTools.pagConsole(`(NULL) BlueSoftApi | Preco COMUM _ post | Item : ${item.prb_cdprodutobluesoftunitario} NÃO PROCESSADO`)
            }

        } catch (e) {
                await myTools.pagConsole(`(ERROR) BlueSoftApi | Preco _ post_preco Item : ${item.prb_cdprodutobluesoftunitario} 
                            \n ${e} 
                            \n Dados informados na API da Bluesoft
                            \n -----------------------------------
                            \n ${JSON.stringify(dados, null, 2)}
                            `
                        )
        }
    }

    getType(item: any) : typeApi {
        let myTypeApi : typeApi = { url : "vendas/precos", dados : {} }

        let dados = {}

        try {
            dados = {
                "produtoKey": item.prb_cdprodutobluesoft,
                "dataInicialAVigorar":  `${(new Date()).toLocaleString("pt-br").substring(0,10)} 08:01:01`,
                "aplicarPrecoParaCaixa": true,
                "aplicarEquivalentes": true,
                "regioes": [
                                {
                                "precoAPartirDe": 0,
                                "precoAtacado": 0,
                                "precoFidelidade": 0,
                                "precoVenda": item.prc_valor,
                                "quantidadeAPartirDe": 0,
                                "regiaoKey": 1
                                }
                            ]           
                }
                const ItemProcessamento = {
                    prb_cdprodutobluesoft: item.prb_cdprodutobluesoft, 
                    dados: dados
                } 
                myTypeApi = { url: "vendas/precos", dados : ItemProcessamento.dados}
                return myTypeApi;
        } catch (e) {
            return myTypeApi;
        }
        

    }
}