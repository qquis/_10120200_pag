
import { clsTools, clsBase} from '../../../model/modelbase'

let myBase = new clsBase()

import modelSistema from '../../m0001_sistema/model/model'



/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 10050011
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0008-Financeiro | ServiceFinanceiroFormaPgto"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    

export default class serviceFinanceiroFormaPgto { 
    static async start(parametros: any): Promise<void> {
       try { 

         let myBase : clsBase = new clsBase()
         myBase.blueSoftApi = new clsBase().blueSoftApi
         let result = await myBase.blueSoftApi.api_get(`modulos/financeiro/cadastros/tipos-forma-pagamento`);

         if (result && result.data) {
             await clsTools.pagConsole(`${FLG_MODULO} | Dados obtidos com sucesso`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
             let sql = ``   
             for (let item of result.data as any[]) {
 
                sql += `INSERT INTO tbforma_pgto_bluesoft (forma_pgto_cd, forma_pgto_descricao, forma_pgto_ref_blue) 
                                SELECT ${item.tipoFormaPagamentoKey}, '${item.descricao}', '${item.descricao}'
                                WHERE NOT EXISTS (SELECT 1 FROM tbforma_pgto_bluesoft WHERE forma_pgto_cd = ${item.tipoFormaPagamentoKey}) ; `
                 
             }

             await myBase.myDataBase.pag.Execute(sql);

         } else {
             await clsTools.pagConsole(`${FLG_MODULO} | Nenhum dado encontrado`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
         }
         

       } catch (e: any) {
           await clsTools.PagErrorException(FLG_MODULO, `serviceFinanceiroFormaPgto.start()`, e, true);
           throw new Error(`modules | Financeiro | Error ${e.message}`);
       }
    }


}