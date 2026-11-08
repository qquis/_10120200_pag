import integracaoProdutoService_default from "./integracao.produto.service_default";
import bluesoftapi from "../../../Apis/bluesoftApi/api";
import myTools from "../../../../tools/Tools";
import modelintegracao_produto from "../../model/modelintegracao_produto";
import modelService_OLD from "../../../../model/model.service-OLD";

let myBlueSoftApi : bluesoftapi = new bluesoftapi()

export default class integracaoProdutoService_20004502_Api_PrecoPromocional extends integracaoProdutoService_default {

    constructor(item : any) {
        super(item)
    }
  
    async ApiItemProcessar(item: modelintegracao_produto) {
        try {
                 await myTools.pagConsole(`integracaoProdutoService_20004502_Api_Preco PROMOCIONAL - ENV ${process.env.ENVIRONMENT} ITEM ${item.prb_cdprodutobluesoftunitario} / ${item.prb_cdprodutobluesoft}`, false)
                 if (!process.env.ENVIRONMENT || process.env.ENVIRONMENT !== `DES`) { 
                    await myBlueSoftApi.preco.apiPrecoPromocional.post(item)
                } else {
                    await myTools.pagConsole(`Ambiente de Desenvolvimento (Produto não lançado na API) ${item.prb_cdprodutobluesoftunitario} / ${item.prb_cdprodutobluesoft}`, false)
                    //await myBlueSoftApi.preco.apiPrecoPromocional.post(item)
                }

        } catch (e) {
            await myTools.pagConsole(`(ERROR) integracaoProdutoService_20004502_Api_Preco PROMOCIONAL Item : ${item.prb_cdprodutobluesoftunitario} `)
            throw new Error(`Error ${e}`)
        }
    }
    async ApiItemValidar(item: modelintegracao_produto): Promise<boolean> {
        let validacao : boolean = false;
        try {
            if (item.prb_cdprodutobluesoft && item.ItemObjectIntegracao.prc_valor && item.ItemObjectIntegracao.prca_dt_aplicacao) {
                validacao = true;
            }
        }
        catch (e) {
            validacao = false;
        }
        finally {
            item.ApiValidacao = validacao;
            return validacao
        }

    }


}
