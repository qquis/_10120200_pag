import { clsBase, clsTools } from '../../../model/modelbase';
import F0021_90_ProdutoBlueSoft_Processamento from "../scriptpg/F0021_90_ProdutoBlueSoft_Processamento";


/*

    APós a importação de produtos da bluesoft este script postgre faz a inclusão dos produtos importados na base PAG
        tbproduto
        tbprodutoembalagem
        tbprodutogtins

*/

export default class serviceProdutoBluesoftProcessarImportacoes {
    public static async start (parametro: any) : Promise<any> {
        let result : any = { success: false }
        
        try { 

            let myBase : clsBase = new clsBase();
            await myBase.myDataBase.pag.Execute(`SELECT ${F0021_90_ProdutoBlueSoft_Processamento.sqlScript_VERSION()} ()`)

        } catch (e) {
            result.success = false;
            clsTools.pagConsole(`serviceProcessarImportacoes | start \n Error: ${e}`);
        
        } finally {
            return result;
        }
     }  
}