
import { clsTools, clsBase} from '../../../model/modelbase'

let myBase = new clsBase()

import modelParticipanteBase from '../model/model';
import modelParticipante from '../model/modelparticipante'
import reportParticipante from '../report/report'
import modelSistema from '../../m0001_sistema/model/model'



/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 10050011
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0011-Service | ServiceParticipanteBlueSoftImport"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    

export default class serviceParticipanteBlueSoftAPIImport { 
    static async start(parametros: any): Promise<void> {
       try { 

            if (parametros.cdpessoabluesoft) { 
                await this.importItem(parametros)
            } else {
                await this.importList(parametros)
            }

       } catch (e: any) {
           await clsTools.PagErrorException(FLG_MODULO, `serviceParticipanteBlueSoftAPIImport.start()`, e, true);
           throw new Error(`modules | Participante | Error ${e.message}`);
       }
    }

    static async importList(parametros: any) { 
        await clsTools.pagConsole(`${FLG_MODULO}.start() - Iniciando importação de participante API`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
        try { 
                
    
            let myclsBase = new clsBase()
            
            let listaGeral : boolean = true
            let dataInicial = new Date(Date.now() - 1 * 24 * 60 * 60 * 1000)

            


            if (parametros.numeroDiasUltimaAlteracao && parametros.numeroDiasUltimaAlteracao > 0) {
                dataInicial = new Date(Date.now() - parametros.numeroDiasUltimaAlteracao * 24 * 60 * 60 * 1000)
                listaGeral = false
            }

            
            let totalPage: number = 10000

            let pageSize: number = 60
            await clsTools.pagConsole(`${FLG_MODULO} | Inicializando | Total pages: ${totalPage}, Page size: ${pageSize}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            

            let imaxUpdate : number = await modelSistema.resources.Sistema.limiteRegBloqUpdateGet(SISTEMA_NUCLEO_PRC_CD)

            for (let currentPage = 0; currentPage <= totalPage; currentPage++) {

                let url = `/clientes?currentPage=${currentPage}&pageSize=${pageSize}`
                if (!listaGeral) {
                    url += `&dataUltimaAlteracao=${clsTools._datemomentDateToStr(dataInicial, "DD/MM/YYYY")}` 
                }


                let result = await myclsBase.blueSoftApi.api_get(url)
               
                if (result.data.data && result.data.data.length > 0) {
                    
                    let listCliente = result.data.data as any[]
                    let sql : string = ""

                    await clsTools.pagConsole(`${FLG_MODULO} | Importação Cliente Bluesoft via API | Proc. página ${currentPage}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                    
                    

                    if (imaxUpdate == 0)
                        imaxUpdate = 100
                    let i : number = 0
                    let iBlocoTotal : number = Math.ceil(listCliente.length / imaxUpdate)
                    let iBloco: number = 0
                    
                    for await (const item of listCliente) {

                        let itemModelParticipante : modelParticipante = new modelParticipante({})
                        await itemModelParticipante.ObterDadosAPIBlueSoft(item)


                        sql += await itemModelParticipante.ScriptIncluirParticipanteFromAPI()
                    }
                    await myclsBase.myDataBase.pag.Execute(sql)
                } else { 
                    break;
                }
                
                
        }
        } catch (e: any) {
            await clsTools.PagErrorException(FLG_MODULO, `serviceParticipanteBlueSoftAPIImport.start()`, e, true);
            throw new Error(`modules | Participante | Error ${e.message}`);
        }

        finally {
            await clsTools.pagConsole(`${FLG_MODULO}.start() - Importação de participante BlueSoft API finalizada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
        }
    }

    static async importItem(parametros: any) { 
        
        await clsTools.pagConsole(`${FLG_MODULO}.start() - Iniciando importação de participante API (ITEM)`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
        try { 
            let myclsBase = new clsBase()
            
            

            let url = `/clientes/${parametros.cdpessoabluesoft}`
            
            

            let result = await myclsBase.blueSoftApi.api_get(url)

            let item = result.data




            let itemModelParticipante : modelParticipante = new modelParticipante({})
                await itemModelParticipante.ObterDadosAPIBlueSoft(item)

            let sql = await itemModelParticipante.ScriptIncluirParticipanteFromAPI()

                    
            await myclsBase.myDataBase.pag.Execute(sql)




        
        } catch (e: any) {
            await clsTools.PagErrorException(FLG_MODULO, `serviceParticipanteBlueSoftAPIImport.start()`, e, true);
            throw new Error(`modules | Participante | Error ${e.message}`);
        }

        finally {
            await clsTools.pagConsole(`${FLG_MODULO}.start() - Importação de participante BlueSoft API finalizada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
        }
    }
   

}