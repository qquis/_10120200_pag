import myTools from "../../../../tools/Tools"
import typeApi from "../type/typeApi"
import bluesoftApi from "../url/bluesoftApiUrl"
export default class blueSoftApiPrecoPromocional  {
    constructor() {
        
    }
    async post (item: any) {
        let dados = {}
        
        try {
            if (item) {
                let ResultadoBlue = {}
                const myTypeApi : typeApi = this.getType(item);



                dados = myTypeApi.dados;

                ResultadoBlue = await bluesoftApi.api_post( myTypeApi.url, myTypeApi.dados )

                
                


                if (ResultadoBlue)
                    await myTools.pagConsole(`BlueSoftApi | Preco PROMOCIONAL _ post | Item : ${item.prb_cdprodutobluesoftunitario} Processado com sucesso `)
                else 
                    await myTools.pagConsole(`(NULL) BlueSoftApi | Preco PROMOCIONAL _ post | Item : ${item.prb_cdprodutobluesoftunitario} NÃO PROCESSADO`)

            }
        } catch (e) {
            await myTools.pagConsole(`(ERROR) BlueSoftApi | Preco PROMOCIONAL _ post | Item : ${item.prb_cdprodutobluesoftunitario} 
                \n ${e} 
                \n Dados informados na API da Bluesoft
                \n -----------------------------------
                \n ${dados}
                `
            )
        }
    }

    getType(item : any) : typeApi {

        let myTypeApi : typeApi = { url : "vendas/precos/ofertas", dados : {} }

        let dados = {}
        try {
            if (item) {

                dados = {
                "produtoKey": item.prb_cdprodutobluesoft,
                "dataInicialOferta": `${myTools._dataformatgetstr(item.prca_dt_aplicacao, "DD/MM/yyyy")} 08:00:00`,
                "dataFinalOferta": `${myTools._dataformatgetstr(item.prca_dt_aplicacao, "DD/MM/yyyy")} 23:00:00`,
                "lojasKeys": [
                  1
                ],
                "aplicarAosEquivalentes": false,
                "precoOferta": item.prc_valor
                }

                const ItemProcessamento = {
                    prb_cdprodutobluesoft: item.prb_cdprodutobluesoft, 
                    dados: dados
                }

                myTypeApi  = { url : "vendas/precos/ofertas", dados : ItemProcessamento.dados }


                //console.log("--- TESTE API BLUESOFR PROMOCIONAL --- ")
                //console.log(myTypeApi)

                return myTypeApi;
                

                /*
                let ResultadoBlue = {}
                ResultadoBlue = await bluesoftApi.api_post("vendas/precos/ofertas", ItemProcessamento.dados )
                await myTools.pagConsole(`BlueSoftApi | Preco _ post | Item : ${item.prb_cdprodutobluesoftunitario} `)
                */


            }
            else {
                return myTypeApi;
            }
            
        } catch (e) {
            return myTypeApi

        }
    }
}