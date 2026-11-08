import serviceProdutoBluesoft from "src/modules/m0021_produtobluesoft/service/service";
import serviceFiscal_Cbenef_ImportarBluesoft from "./serviceFiscal.Cbenef.ImportarBluesoft";
import { clsBase, clsTools } from "../../../model/modelbase";

const myBase = new clsBase();

export default class serviceFiscal_Cbenef_ExportarProdutoBluesoft { 
    static async start(parametro: any) : Promise<void> { 
        try  { 

            clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.Cbenef_ExportarProdutoBluesoft.start - Iniciando...',false, false);
            let myDataBase : clsBase = new clsBase();

            
            

            if (parametro.fc_cbenef_cd == null || parametro.fc_cbenef_cd.trim() === '') {
                throw new Error('Código do Cbenef é obrigatório')
            }

            if (parametro.lista_produtos == null || parametro.lista_produtos.length === 0) {
                throw new Error('Lista de produtos é obrigatória')
            }



            let sqlCBENEF_CONSULTA_BLUE = `Select fc_cbenef_bluesoft_cd from tbfc_cbenef where fc_cbenef_cd = '${parametro.fc_cbenef_cd}' `

            let resultCBENEF_CONSULTA_BLUE = await myDataBase.myDataBase.RecordItem(await myDataBase.myDataBase.pag.DataGet(sqlCBENEF_CONSULTA_BLUE),0) as any

            let fc_cbenef_bluesoft_cd : number = 0

            if (resultCBENEF_CONSULTA_BLUE.fc_cbenef_bluesoft_cd && resultCBENEF_CONSULTA_BLUE.fc_cbenef_bluesoft_cd !== 0) {
                fc_cbenef_bluesoft_cd = resultCBENEF_CONSULTA_BLUE.fc_cbenef_bluesoft_cd
            } else {
                clsTools.pagConsole(`Nenhum código do ambiente Bluesoft encontrado para o CBENEF ${parametro.fc_cbenef_cd}. Realize a importação dos dados do ambiente Bluesoft para o sistema antes de realizar a exportação.`, true, false)
                throw new Error(`Nenhum código do ambiente Bluesoft encontrado para o CBENEF ${parametro.fc_cbenef_cd}. Realize a importação dos dados do ambiente Bluesoft para o sistema antes de realizar a exportação.`)
            }
            

            let sql = `SELECT prb_cdprodutobluesoftunitario, prb_cdprodutobluesoft_pk 
                       FROM tbprodutobluesoft 
                       where prb_cdprodutobluesoftunitario in (${parametro.lista_produtos})
                       
                       `

            let listaProdutos : number[] = []
            let resultProduto = await myDataBase.myDataBase.pag.DataGet(sql)


            let iexportCount = 0
            let iExportMax = 10

            for await (const item of (resultProduto as any[])) {
                listaProdutos.push(item.prb_cdprodutobluesoft_pk)
                iexportCount ++
                if (iexportCount >= iExportMax) {
                    clsTools.pagConsole(`Exportando produtos para o CBENEF ${parametro.fc_cbenef_cd}. Exportação em andamento | Inserindo bloco`, true, false)
                    await this.exportList(parametro, fc_cbenef_bluesoft_cd, listaProdutos)
                    listaProdutos = []
                    iexportCount = 0

                }
            }

            
            if (listaProdutos.length > 0) {
                clsTools.pagConsole(`Exportando produtos para o CBENEF ${parametro.fc_cbenef_cd}. Exportação em andamento | Inserindo bloco final`, true, false)
                await this.exportList(parametro, fc_cbenef_bluesoft_cd, listaProdutos)
            }

            /*
            let listToAPI = { 
                produtoKeys: listaProdutos


            }

            if (parametro.vincular && parametro.vincular === 1) {
                await myBase.blueSoftApi.api_put(`/fiscal/beneficio-uf/${fc_cbenef_bluesoft_cd}/vincular-produtos`, listToAPI)
            } else { parametro.vincular === 0
                await myBase.blueSoftApi.api_post(`/fiscal/beneficio-uf/${fc_cbenef_bluesoft_cd}/desvincular-produtos`, listToAPI)
            }*/

          
            /*ATUALIZANDO DADOS DO CADASTRO DE PRODUTO BLUESOFT*/
            //Atualiza os dados do cbenef e dos produtos relacionados ao cbenef específico que foi atualizado na Bluesoft, para garantir que os dados estejam atualizados para a consulta de exportação.
            await serviceFiscal_Cbenef_ImportarBluesoft.start({fc_cbenef_cd: parametro.fc_cbenef_cd}) 
            

        } catch (e) { 

            clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscal_Cbenef_ExportarProdutoBluesoft', e);
        }

        finally {
            clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.Cbenef_ExportarProdutoBluesoft.start - Finalizado',false, false);
        }

    }

    static async exportList(parametro: any,  fc_cbenef_bluesoft_cd: number, lista_produtos: number[]) : Promise<void> { 
        try  {

            let listToAPI = { 
                produtoKeys: lista_produtos
            }
            if (parametro.vincular && parametro.vincular === 1) {
                await myBase.blueSoftApi.api_put(`/fiscal/beneficio-uf/${fc_cbenef_bluesoft_cd}/vincular-produtos`, listToAPI)
            } else { parametro.vincular === 0
                await myBase.blueSoftApi.api_post(`/fiscal/beneficio-uf/${fc_cbenef_bluesoft_cd}/desvincular-produtos`, listToAPI)
            }
        } catch (e) {
            clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscal_Cbenef_ExportarProdutoBluesoft_exportList', e);
        }

    }

  
}