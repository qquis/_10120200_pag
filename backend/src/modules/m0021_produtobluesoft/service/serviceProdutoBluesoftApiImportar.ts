import { clsBase, clsTools } from '../../../model/modelbase';
import modelProdutoBluesoft from '../model/modelProdutoBluesoft';
import serviceProdutoBluesoftProcessarImportacoes from './serviceProdutoBluesoftProcessarImportacoes';
import bluesoftapi from "../../Apis/bluesoftApi/api";
import model0040_fiscal from '../../m0040_fiscal/model/model';


/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = true
    const FLG_MODULO : string = "M0021-ProdutoBluesoft | IMPORT PRODUTO BLUESOFT"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = `IMPORTACAO_PRODUTO_BLUESOFT`
/*  ------------------------------------------------------------------------------------------- */    


const moduleLog = 'M0021';

export default class serviceProdutoBluesoftApiImportar  {


    public static async start(parametro: any) : Promise<any> {
        
        let result : any = { result: false, message: 'Erro desconhecido' }
        try { 
                

            
                /*PROCESSANDO LISTA / ITEM */
            
                await clsTools.pagConsole(`${FLG_MODULO} | Importacao Inicializada (ARQUIVO DE LOG ${FLG_DEBUG_FILE_CONSOLE_LOG})`, FLG_DEBUG_CONSOLE_LOG, false, "")
                await clsTools.pagConsole(`${FLG_MODULO} | Importacao Inicializada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                


                await clsTools.pagConsole(`${FLG_MODULO} | Buscando informacao da API`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                if (parametro.produtoKey && parametro.produtoKey !== '') {
                    /*
                        IMPORTAÇÃO DE UM PRODUTO
                    */
                    let myDataBase : clsBase = new clsBase();

                    let sql = await this.ImportarProduto(null, null, parametro.produtoKey, parametro)
                    await myDataBase.myDataBase.pag.Execute(sql)
                }
                else { 

                    /*
                    
                        IMPORTAÇÃO DE LISTA DE PRODUTOS
                    
                    */
                    clsTools.pagConsole(`ser.Prd.blue.imp _ start | Lista de Produtos`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                    result = await this.importarProdutosList(parametro)
                }

                
                
                /*PROCESSANDO A IMPORTAÇÃO */
                
                if (parametro.NaoProcessarBasePag && parametro.NaoProcessarBasePag === 1) {
                    await clsTools.pagConsole(`Backend foi acionado para atualizar o produto porém NÃO processar a base PAG. (LOG backend.txt.${FLG_DEBUG_FILE_CONSOLE_LOG})`, false, false)
                }
                
                
                if (!parametro.NaoProcessarBasePag || parametro.NaoProcessarBasePag === 0) {
                    await serviceProdutoBluesoftProcessarImportacoes.start({})
                    await clsTools.pagConsole(`Backend o Serviço serviceProdutoBluesoftImportar está processando a importação (LOG backend.txt.${FLG_DEBUG_FILE_CONSOLE_LOG})`, false, false)
                }

        } catch (e) {
                await clsTools.PagErrorException('M0021', 'serviceProdutoBluesoftImportar.start', e, false, JSON.stringify(parametro), FLG_DEBUG_FILE_CONSOLE_LOG)
                return { result: false, message: `Erro ao importar produto(s): ${e}` }
        } finally {
                return result;
        }



    }


    static async importarProdutosList(parametro: any) : Promise<any> { 

        let resultService : any = { result: false, message: 'Erro desconhecido' }
        try { 
        
                await clsTools.pagConsole(`${FLG_MODULO} | Processando API tipo LIST`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)


                let myDataBase : clsBase = new clsBase();

                let myBlueSoftApi: bluesoftapi = new bluesoftapi()


                let result : any = {}


                if (parametro.numeroDiasUltimaAlteracao && parametro.numeroDiasUltimaAlteracao > 0) {
                    await clsTools.pagConsole(`${FLG_MODULO} | Processando API tipo LIST -> Importando produtos com última alteração de até ${parametro.numeroDiasUltimaAlteracao} dias`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                    result = await myBlueSoftApi.produto.listalteracaoDX(parametro.numeroDiasUltimaAlteracao)
                }
                else { 
                    await clsTools.pagConsole(`${FLG_MODULO} |  Processando API tipo LIST -> Parâmetro de Número de dias NÃO definido - LISTA GERAL`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                    result = await myBlueSoftApi.produto.listall()
                }

                


                let listProdutos = result as any[];

                let sqlScript = ``;
                let iUpdateSqlCount : number = 0;
                let icountprocesso : number = 0;
                let iUpdateSqlCountMax: number = 100;

                let ibloc : number = 0;
                let icountBloc = Math.round(listProdutos.length / iUpdateSqlCountMax);
                let linhaCodigoProduto: string = ""

                await clsTools.pagConsole(`${FLG_MODULO} | Processando produtos obtidos da API - NUMERO DE PRODUTOS: ${listProdutos.length} / N DE BLOCOS: ${icountBloc}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                
                for await (const item of listProdutos) {


                        /*Classe de ProdutoBluesoft */
                        let myitem : modelProdutoBluesoft = new modelProdutoBluesoft()
                        
                        
                        /*Preenche a classe com os dados da API Bluesoft */
                        await myitem.LerOsDadosDaAPI(item)


                        /*Obter o sqlscript da atualização
                            DBUPDATE - Atualização completa do produto (Fará a chamada a api de regra fiscal)
                            DBINSERT_API - Apenas produto bluesoft, sem a regra fiscal
                        
                        */
                        sqlScript += await myitem.SqlDeAtualizacaoGeralProdutoBluesoftApi(`DBUPDATE`, parametro)

                        linhaCodigoProduto += myitem.prb_cdprodutobluesoft_pk + ", "

                        icountprocesso++
    
                    if (iUpdateSqlCount >= iUpdateSqlCountMax) {
                        await clsTools.pagConsole(`${FLG_MODULO} | Inserindo produtos importados Bloco ${ibloc}/${icountBloc} de 100 itens cada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                        await clsTools.pagConsole(`${FLG_MODULO} | Produtos do bloco ${ibloc}/${icountBloc} ${linhaCodigoProduto}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                        linhaCodigoProduto = ""
                        await myDataBase.myDataBase.pag.Execute(sqlScript)
                        iUpdateSqlCount = 0;
                        sqlScript = ""
                        ibloc++;
                    }
                    iUpdateSqlCount++;


                }

                if (sqlScript.trim() != "") {
                    await clsTools.pagConsole(`${FLG_MODULO} | Processamento fina ULTIMO BLOCO ${ibloc}/${icountBloc} de 100 itens cada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                    await clsTools.pagConsole(`${FLG_MODULO} | Produtos do bloco ${ibloc}/${icountBloc} ${linhaCodigoProduto}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                    await myDataBase.myDataBase.pag.Execute(sqlScript)
                    iUpdateSqlCount = 0;
                    sqlScript = ""
                    linhaCodigoProduto = ""
                }

                resultService.result = true;
                resultService.message = `${(result as any[]).length} produtos importados com sucesso`

               

        } catch (e) {
            await clsTools.PagErrorException('M0021', FLG_MODULO, e, false, FLG_DEBUG_FILE_CONSOLE_LOG)
        }
        finally {
            return resultService
        }

    
    
    
    }


    static async ImportarProduto(myModelProdutoBluesoft : modelProdutoBluesoft | null, itemApi: any, produtoKey: number = 0, parametro: any = {}) : Promise<string> {
        let sql = ``
        try {

            if (myModelProdutoBluesoft && myModelProdutoBluesoft.prb_cdprodutobluesoft_pk !== 0) {
                /*model ja preenchido devolver apenas o script sql*/
                sql = await myModelProdutoBluesoft.SqlDeAtualizacaoGeralProdutoBluesoftApi(`DBUPDATE`, parametro)
            }

            if (myModelProdutoBluesoft && myModelProdutoBluesoft.prb_cdprodutobluesoft_pk === 0 && itemApi) {
                /*model vazio, preencher com dados da api e devolver o script sql*/
                let myitem : modelProdutoBluesoft = new modelProdutoBluesoft()
                await myitem.LerOsDadosDaAPI(itemApi)
                sql = await myitem.SqlDeAtualizacaoGeralProdutoBluesoftApi(`DBUPDATE`, parametro)

            }

            if ((myModelProdutoBluesoft === null || myModelProdutoBluesoft.prb_cdprodutobluesoft_pk === 0) && !itemApi && produtoKey !== 0) {
                /*model vazio, preencher com dados da api usando o produtoKey e devolver o script sql*/
                let myBlueSoftApi: bluesoftapi = new bluesoftapi()
                let result = await myBlueSoftApi.produto.getProduto(produtoKey)
                let itemAProcessar = result.data.data[0]
                if (itemAProcessar) {
                    let myitem : modelProdutoBluesoft = new modelProdutoBluesoft()
                    await myitem.LerOsDadosDaAPI(itemAProcessar)
                    sql = await myitem.SqlDeAtualizacaoGeralProdutoBluesoftApi(`DBUPDATE`, parametro)
                } else {
                    throw new Error(`Produto não encontrado na API Bluesoft para o produtoKey ${produtoKey}`)
                }
            }


        } catch (e) {
            
            clsTools.PagErrorException('M0021', 'serviceProdutoBluesoftImportar.getScriptImportacaoProduto', e, false, `ProdutoKey: ${produtoKey}`, FLG_DEBUG_FILE_CONSOLE_LOG);
        }
        finally {
            return sql
        }

    }

}
