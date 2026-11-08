import { clsBase, clsTools } from "../../../model/modelbase";
import modelfc_cbenef from "../model/modelfc_cbenef";
import model0021_ProdutoBluesoft from "../../m0021_produtobluesoft/model/model";
import model0040_fiscal from '../../m0040_fiscal/model/model';

/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0040-FISCAL-Service | Importar CBENEF Bluesoft"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = `IMPORTACAO_CBENEF_BLUESOFT`
/*  ------------------------------------------------------------------------------------------- */  

const myBase = new clsBase();

export default class serviceFiscal_Cbenef_ImportarBluesoft { 
    static async start(parametro:any) : Promise<void> { 
        try  { 


 

            await clsTools.pagConsole(`${FLG_MODULO} | ServiceFiscal.Cbenef_ImportarBluesoft.start - Iniciando...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);

            let maxPAG = 10000

            if (parametro && parametro.fc_cbenef_cd && parametro.fc_cbenef_cd.trim() !== '') {
                maxPAG = 0
            }

           
            let listaCbenefBluesoft: modelfc_cbenef[] = []
            


            await clsTools.pagConsole(`${FLG_MODULO} | ServiceFiscal.Cbenef_ImportarBluesoft.start - Lendo a API DE CBENEF`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            for (let currentPage = 0; currentPage <= maxPAG; currentPage++) {

                let url = `/fiscal/beneficio-uf?uf=SP&currentPage=${currentPage}`

                if (parametro && parametro.fc_cbenef_cd && parametro.fc_cbenef_cd.trim() !== '') {
                    url = `/fiscal/beneficio-uf?uf=SP&codigoBeneficioFiscal=${parametro.fc_cbenef_cd}&currentPage=${currentPage}`
                }



                let result = await myBase.blueSoftApi.api_get(url)
                if ( result.data.data.length && result.data.data.length !== 0) {
                    for await (const item of result.data.data) {
                        let itemCbenef : modelfc_cbenef = new modelfc_cbenef();
                        itemCbenef.getCbenefBLueApi(item)
                        if (itemCbenef.fc_cbenef_cd !== 'SP099999') { /* CBENF GENERICO */
                            listaCbenefBluesoft.push(itemCbenef)
                        }
                    }
                }
                else { 
                    clsTools.pagConsole(`${FLG_MODULO} | Processamento CBENEF - Nenhum registro encontrado na página ${currentPage}. Finalizando a consulta.`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    break;
                }

            }

            
            
            /*Inserindo os cbenefs na base de dados */
            await clsTools.pagConsole(`${FLG_MODULO} | ServiceFiscal.Cbenef_ImportarBluesoft.start - Inserindo os cbenefs na base de dados`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            let scriptCbenef : string = ``

            for await (const itemModelfc_cbenef of listaCbenefBluesoft) {
                scriptCbenef += await itemModelfc_cbenef.sqlInserirDadosDeApi()
            }

            if (scriptCbenef.trim() != "") {
                await myBase.myDataBase.pag.Execute(scriptCbenef)
            }

            /*consultando e gravando os produtos relacionados*/
            await clsTools.pagConsole(`${FLG_MODULO} | ServiceFiscal.Cbenef_ImportarBluesoft.start - Consultando e gravando os produtos relacionados`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);   
            
            let sqlCbenefList : string = ``
            for await (const itemModelfc_cbenef of listaCbenefBluesoft) {

              let resultAPICebenfProdutoBlue = await myBase.blueSoftApi.api_get(`/fiscal/beneficio-uf/${itemModelfc_cbenef.fc_cbenef_bluesoft_cd}/produtos`)

             
              if (resultAPICebenfProdutoBlue.data.data.length && resultAPICebenfProdutoBlue.data.data.length !== 0) {


                  
                  let listaProdutos : number[] = [];



                  let icountMaxPage = 10000

                  
                  for (let ipagProduto = 0; ipagProduto <= icountMaxPage; ipagProduto++) {
                      let urlproduto = `/fiscal/beneficio-uf/${itemModelfc_cbenef.fc_cbenef_bluesoft_cd}/produtos?currentPage=${ipagProduto}`

                      let resultAPICebenfProdutoBlue = await myBase.blueSoftApi.api_get(urlproduto)

                      if (resultAPICebenfProdutoBlue.data.data.length && resultAPICebenfProdutoBlue.data.data.length !== 0) {
                        for await (const itemProduto of resultAPICebenfProdutoBlue.data.data) {
                            listaProdutos.push(itemProduto.produtoKey)
                            }
                      } else {
                        break;
                      } 
                  }

                  clsTools.pagConsole(`${FLG_MODULO} | Numero de produtos encontrado no CBENEF ${itemModelfc_cbenef.fc_cbenef_bluesoft_cd}/${itemModelfc_cbenef.fc_cbenef_cd}: ${listaProdutos.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);

                  if (listaProdutos.length > 0) {
                     /* Se foi encontrado produtos no CBENF será atualizado cada item de acordo com o list */
     
                     

                     sqlCbenefList += model0040_fiscal.sqlDELETE_tbfc_cbenef_produtobluesoft_PorCbenef(itemModelfc_cbenef.fc_cbenef_cd)
                     let liststringproduto = listaProdutos.join(',')
                     sqlCbenefList += await model0040_fiscal.sqlINSERT_TbFC_CBENEF_PRODUTO_FromList_PorCBENEF(itemModelfc_cbenef.fc_cbenef_cd, listaProdutos)

                     sqlCbenefList += model0040_fiscal.sqlUPDATE_tbprodutobluesoft_CBENEF_NULL_PorCBENEF(itemModelfc_cbenef.fc_cbenef_cd)
                     
                
                  } else {
                     /* Se nao foi encontrado, será feito um update null*/
                     sqlCbenefList += model0040_fiscal.sqlUPDATE_tbprodutobluesoft_NULL_porCBENEF(itemModelfc_cbenef.fc_cbenef_cd)
                  }

                } else { 
                  sqlCbenefList += model0040_fiscal.sqlUPDATE_tbprodutobluesoft_NULL_porCBENEF(itemModelfc_cbenef.fc_cbenef_cd)
                }



                /*Processando CBNEF por CBENEF*/
                
                if (sqlCbenefList.trim() != "") {
                    await myBase.myDataBase.pag.Execute(sqlCbenefList)
                    sqlCbenefList = ``
                }


            }   


            /*Atualizar os codigos pag quando for null e quando tiver na bluesoft */
            await clsTools.pagConsole(`${FLG_MODULO} | Atualizar os codigos pag quando for null e quando tiver na bluesoft`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            sqlCbenefList += model0040_fiscal.sqlUpdateALL_CBENEF_TbProduto_ComTbProdutoBluesoft()

            if (sqlCbenefList.trim() != "") {
                await myBase.myDataBase.pag.Execute(sqlCbenefList)
            }

            


        } catch (e) { 
            await clsTools.PagErrorException(`${FLG_MODULO}`, 'start', e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);
        }

        finally {
            await clsTools.pagConsole(`${FLG_MODULO} | ServiceFiscal.Cbenef_ImportarBluesoft.start - Finalizado`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
        }

    }


  
}