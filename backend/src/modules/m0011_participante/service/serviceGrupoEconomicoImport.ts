
import { clsTools, clsBase} from '../../../model/modelbase'

let myBase = new clsBase()

import modelGrupoEconomico from '../model/modelGrupoEconomico'
import modelSistema from '../../m0001_sistema/model/model'



/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 10050011
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0011-Service | ServiceGrupoEconomicoImport"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    

export default class serviceGrupoEconomicoImport { 
    static async start(parametros: any): Promise<void> {
       try { 

            if (parametros.cdgrupoeconomico) { 
                //await this.importItem(parametros)
                this.__log(`Importação por item EM DESENVOLVIMENTO...`)
            } else {
                await this.importList(parametros)
            }

       } catch (e: any) {
            await this.__error(`serviceGrupoEconomicoImport.start()`, e);
           throw new Error(`modules | Participante | Error ${e.message}`);
       }
    }

    static async importList(parametros: any): Promise<void> {

          await this.__log(`Iniciando importação de lista de grupos econômicos`)
          try { 
                  
      
              let myclsBase = new clsBase()
 
              let totalPage: number = 10000
  
              let pageSize: number = 60

              await this.__log(`Inicializando | Total pages: ${totalPage}, Page size: ${pageSize}`)
              
              
  
              let imaxUpdate : number = await modelSistema.resources.Sistema.limiteRegBloqUpdateGet(SISTEMA_NUCLEO_PRC_CD)
  
              for (let currentPage = 0; currentPage <= totalPage; currentPage++) {
                   let url = `/forca-de-vendas/grupos-economicos?currentPage=${currentPage}&pageSize=${pageSize}`
                   let result = await myclsBase.blueSoftApi.api_get(url)
                   if (result && result.data && result.data.data) {
                       await this.__log(`Página ${currentPage} retornou dados`)
                       let dados = result.data.data as any[];
                       if (dados.length > 0 ) {
                            let scriptSQL: string = ``
                            for await (let item of dados) {
                                let itemGrupoeconomico : modelGrupoEconomico = new modelGrupoEconomico({})
                                await itemGrupoeconomico.lerApiBluesoft(item)
                                if (itemGrupoeconomico.dadosApi.cdgrupoeconomico) {
                                    scriptSQL += itemGrupoeconomico.script_update_from_api() + `\n`
                                }
                            }
                            if (scriptSQL) {
                                await this.__log(`Executando script SQL para atualização de grupos econômicos`)
                                await this.__dbExecute(scriptSQL)   
                                scriptSQL = ``
                            }
                        
                        
                        }
                        else {
                            await this.__log(`Nenhum dado retornado na página ${currentPage}`)
                            break;
                        }
                   }
                   else { 
                        await this.__log(`Nenhum dado retornado na página ${currentPage}`)
                        break;
                   }
              }
          } catch (e: any) {
              await clsTools.PagErrorException(FLG_MODULO, `serviceGrupoEconomicoImport.importList()`, e, true);
              throw new Error(`modules | Participante | Error ${e.message}`);
          }
    }

    
    private static async __log(message: string): Promise<void>  {
        await clsTools.pagConsole(`${FLG_MODULO} ${message}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
    }

    private static async __error(message: string, e : any): Promise<void>  {
        await clsTools.PagErrorException(FLG_MODULO, message, e, true);
    }

    private static async __dbExecute(scriptSQL: string): Promise<void> {
        try { 

            let myDatabase = new clsBase()
            await myDatabase.myDataBase.pag.Execute(scriptSQL)


        } catch (e: any) {
            this.__error(`serviceGrupoEconomicoImport.__dbExecute()`, e)
            throw new Error(`modules | Participante | Error ${e.message}`);
        }
    }

}