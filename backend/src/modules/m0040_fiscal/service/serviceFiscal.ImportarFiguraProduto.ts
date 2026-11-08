import { clsBase, clsTools } from "../../../model/modelbase";
import reportProduto from "../../m0020_produto/report/report";




import modelfc_figurafiscal_produto from "../model/modelfc_figura_produto";


const CONSOLE_LOG : boolean = true;
const DEBUG_ITEM: Boolean = false;

const myBase = new clsBase();

export default class serviceAtualizarFiguraFiscalPorProdutoUnitario { 
    static async start(parametro: any) : Promise<void> { 



        try  { 

            let report = await reportProduto.list.get(parametro)
            
            let listaProdutos = report as any[]
            if (listaProdutos.length === 0) {
                await clsTools.pagConsole(`M0040_FISCAL - Importar Figura Produto: *NENHUM PRODUTO ENCONTRADO*`,CONSOLE_LOG, false);
                return;
            }

            let sql = ``
            let iControl = 0;
            let numeroRegistros = listaProdutos.length;
            
            let iControlMax = 70;
            let BlocoTotal = Math.ceil(numeroRegistros / iControlMax);
            let BlocoAtual = 1;

            for await (let itemProduto of listaProdutos) {
                let itemmodelfc_figurafiscal_produto : modelfc_figurafiscal_produto = new modelfc_figurafiscal_produto();
                itemmodelfc_figurafiscal_produto.prb_cdprodutobluesoft = itemProduto.prb_cdprodutobluesoft;
                sql += await itemmodelfc_figurafiscal_produto.getInsertScriptByProdutoBluesoft(itemProduto.prb_cdprodutobluesoft);
                
                if (CONSOLE_LOG && DEBUG_ITEM) {
                    await clsTools.pagConsole(`M0040_FISCAL - Importar Figura Produto: ${itemProduto.prb_cdprodutobluesoft} - ${itemProduto.prb_descricao}`,CONSOLE_LOG, false);
                }

                if (iControl >= iControlMax) {
                    await clsTools.pagConsole(`M0040_FISCAL - Importar Figura Produto: Executando bloco ${BlocoAtual} de ${BlocoTotal}`,CONSOLE_LOG, false);
                    await myBase.myDataBase.pag.Execute(sql);
                    sql = ``;
                    iControl = 0;
                    BlocoAtual++;
                }
                iControl++;

            }


            if (sql != '') { 
                await clsTools.pagConsole(`M0040_FISCAL - Executando último bloco`,CONSOLE_LOG, false);
                await myBase.myDataBase.pag.Execute(sql);
            }
            

        } catch (e) { 
            clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscal_Figura', e);
        }

        finally {
            clsTools.pagConsole('M0040_FISCAL - Importação de Figura Produto finalizada',CONSOLE_LOG, false);

        }

    }
}