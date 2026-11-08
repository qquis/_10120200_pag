import bluesoftapi from "../../../Apis/bluesoftApi/api";

import modelintegracao_produto from "../../model/modelintegracao_produto";
import modelProdutoBluesoft from "../../../m0021_produtobluesoft/model/modelProdutoBluesoft";
import integracaoProdutoService_default from "./integracao.produto.service_default";
import serviceProdutoBluesoft from "../../../../modules/m0021_produtobluesoft/service/service";
import modelService_OLD from "../../../../model/model.service-OLD";
import { clsBase, clsTools } from "../../../../model/modelbase";

let myBlueSoftApi : bluesoftapi = new bluesoftapi()

export default class integracaoProdutoService_20002090_ImporteAPI_Produto extends integracaoProdutoService_default {

    constructor(item : any) {
        super(item)
    }

    async obterProdutosPendentes(service : modelService_OLD): Promise<modelintegracao_produto[]> {
        let mylist : modelintegracao_produto[] = []

        try {

            let result : object = {}
            await clsTools.pagConsole(`Integração de Produtos | Tipo: ${this.integracao_tipo.sis_batch_cd}`, false, false, "M0095")

            switch (this.integracao_tipo.sis_batch_cd) {
                case 95100: //PRODUTOS GERAIS
                    result  = await myBlueSoftApi.produto.listall()
                    break;
                case 95101: //PRODUTOS GERAIS
                    result  = await myBlueSoftApi.produto.listall()
                    break;
                case 95102: //PRODUTOS PENDENTES -- AJUSTADO EM 03/07/2026
                    result  = await myBlueSoftApi.produto.listPendenteHoje()
                    break;     
                default:            
                    result  = await myBlueSoftApi.produto.listUltAlteracaoD1()
                    break;     
            }
            for await ( const[key, value] of Object.entries(result)) {
                    let myitem : modelintegracao_produto = new modelintegracao_produto()        
                    
                 

                    myitem.ItemObjectIntegracao = value; 
                    myitem.pr_cdproduto = 0; 
                    myitem.prb_cdprodutobluesoftunitario = value.produtoUnitarioKey;
                    myitem.prb_cdprodutobluesoft = value.produtoKey
                    mylist.push(myitem)
                }
        }
        catch(e) {
            clsTools.PagErrorException('M0095', 'integracao..obterProdutosPendentes', e, false, "", "M0095");
        }

        finally {
            return mylist
        }
    }

    async getStrCRUDPostGre(item: any ) : Promise<string> {
        let mprodutobluesoft : modelProdutoBluesoft = new modelProdutoBluesoft(); 
        
        mprodutobluesoft.LerOsDadosDaAPI(item)

        let sqlX : string = ``; 
        try {
            
            switch (this.integracao_tipo.sis_batch_cd) {
                case 95100: //PRODUTOS GERAIS
                    sqlX = await mprodutobluesoft.SqlDeAtualizacaoGeralProdutoBluesoftApi("DBINSERT");
                    break;
                case 95101: //PRODUTOS GERAIS
                    sqlX = await mprodutobluesoft.SqlDeAtualizacaoGeralProdutoBluesoftApi("DBINSERT");
                    break;
                case 95102: //PRODUTOS PENDENTES
                    sqlX = await mprodutobluesoft.SqlDeAtualizacaoGeralProdutoBluesoftApi("DBUPDATE");
                    break;     
                default:            
                    sqlX = await mprodutobluesoft.SqlDeAtualizacaoGeralProdutoBluesoftApi();
                    break;     
            }



            

        } catch(e) {
            clsTools.PagErrorException('M0095', 'integracao..getStrCRUDPostGre', e, false, "", "M0095");

        }
        finally {
            return  sqlX;
        }

    }
    
    async Finalizar(): Promise<void> {
        try {

            await serviceProdutoBluesoft.ProcessarImportacoes.start({})

        } catch (e) {
            clsTools.PagErrorException('M0095', 'integracao..Finalizar', e, false, "", "M0095");
        }
    }
    

}
