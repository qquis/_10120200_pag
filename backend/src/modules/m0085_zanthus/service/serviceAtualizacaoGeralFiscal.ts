/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - Service | Atualização Geral Mercadoria/Fiscal"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
    const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE : string = ``
/*  ____________________________________________________________________________________________*/    


import { clsBase, clsTools } from "../../../model/modelbase";


import zanthusService from "./service";
import modelintegracao_tipo from "../../m0095_integracao/model/modelintegracao_tipo";


import reportZanthusTabMercadoria_Select from "../report/report.ZanthusTabMercadoria_Select";
import reportZanthusTabRegrasIcms_Select from "../report/report.ZanthusTabRegrasIcms_Select";
import tbZanthusTabRegrasIcms from "../tbs/tbZanthusTabRegraIcms";
import reportZanthusType from "../report/ReportFilterType";


import serviceZanthusAtualizacaoDadosMercadoria from "./serviceAtualizacao.Carga.Dados.Mercadoria";
import serviceZanthusAtualizacaoDadosRegraFiscal from "./serviceAtualizacao.Carga.Dados.RegrasFiscais";
import serviceZanthusAtualizacaoDadosMercadoriaInativacaoGeral from "./serviceAtualizacao.Carga.Dados.MercadoriaInativacaoGeral";




export default class serviceAtualizacaoGeralFiscal  {
    static async start(parametros: any) : Promise<void> {
        try {

            await clsTools.pagConsole(`${FLG_MODULO} | Atualização Zanthus (TAB MERCADORIA E TAB REGRAS ICMS) GERAL iniciada`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);

            
            
            /*Instancia do Módulo ZANTHUS*/  

            let myZanthusService : zanthusService = new zanthusService()
            await clsTools.pagConsole(`${FLG_MODULO} | Preparando dados Zanthus na base Pag`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            await myZanthusService.PrepararDadosZanthusNaBasePag(true)


            let reportZanthusType : reportZanthusType = {
                Base : 'Zanthus',
                ProdutosPendentesDeIntegracao : parametros.ProdutosPendentesDeIntegracao? true : false,
                AlteracaoTributaria: "0",
                integracao_tipo_cd : parametros.integracao_tipo_cd || 20008501
            }



            await serviceZanthusAtualizacaoDadosMercadoria.start(parametros)
            await serviceZanthusAtualizacaoDadosRegraFiscal.start(parametros)
            await serviceZanthusAtualizacaoDadosMercadoriaInativacaoGeral.start(parametros)




            
            if (parametros.integracao_tipo_cd && parametros.integracao_tipo_cd > 0) {
                await clsTools.pagConsole(`${FLG_MODULO} | Finalizando pendências de integração de produtos para integracao_tipo_cd: ${parametros.integracao_tipo_cd}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                let myModelIntegracaoTipo : modelintegracao_tipo = new modelintegracao_tipo()
                myModelIntegracaoTipo.integracao_tipo.integracao_tipo_cd = parametros.integracao_tipo_cd
                await myModelIntegracaoTipo.FinalizarTodosIntegracaoDeProdutoPendentes()
                await clsTools.pagConsole(`${FLG_MODULO} | Finalização pendências de integração de produtos para integracao_tipo_cd: ${parametros.integracao_tipo_cd} concluída`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            }

            await clsTools.pagConsole(`${FLG_MODULO} | Atualização fiscal concluída com sucesso!`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)


        } catch (e) {
            clsTools.PagErrorException(`serviceAtualizacaoGeral`, 'start', e);
            throw new Error( `F0085 | serviceAtualizacaoGeral ${e} `)
        }
    }


    static async atualizaTabMercadoria(reportZanthusType : reportZanthusType) : Promise<void> {


         let i = 0
         let icount = 0 
         let icountTotal = 0
         let ilimite_reg_bloq_update : number = 200
         let sql = ``

         try {
            let myclsBase : clsBase = new clsBase()



            let myReportZanthusTabMercadoria_Select : reportZanthusTabMercadoria_Select = new reportZanthusTabMercadoria_Select(reportZanthusType)
            let listTabMercadoria  = await myReportZanthusTabMercadoria_Select.tblist_Get()


            await clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabMercadoria Total de itens para processamento: ${listTabMercadoria.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)


            i = 0
            icount = 0 
            icountTotal = listTabMercadoria.length
            ilimite_reg_bloq_update =  myclsBase.myDataBase.MAX_UPDATE_DEFAULT
            sql = ``

            await clsTools.pagConsole(`${FLG_MODULO} | Atualização TabMercadoria MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)

            for await (const item of listTabMercadoria) {
                
                sql += item.ZanthusPostGre_CRUD() 
                i++
                icount++
                if (i >= ilimite_reg_bloq_update) {
                    await clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabMercadoria - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                    await myclsBase.myDataBase.zanthusPostgre.Execute(sql)
                    sql = ``
                    i = 0
                }
            }

            if (sql !== ``) {
                await myclsBase.myDataBase.zanthusPostgre.Execute(sql)
            }

        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO atualizaTabMercadoria', e);
        }
        finally {
            await clsTools.pagConsole(`${FLG_MODULO} | Atualizacao TabMercadoria finalizada - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
        }
    }

    static async atualizaTabRegrasIcms(reportZanthusType : reportZanthusType) : Promise<void> {

         let i = 0
         let icount = 0 
         let icountTotal = 0
         let ilimite_reg_bloq_update : number = 0
         
         let sql = ``

        try {



            let myclsBase : clsBase = new clsBase()



            let myreportZanthusTabRegrasIcms_Select : reportZanthusTabRegrasIcms_Select = new reportZanthusTabRegrasIcms_Select(reportZanthusType)
            let listTabRegrasIcms : tbZanthusTabRegrasIcms[] = await myreportZanthusTabRegrasIcms_Select.tblist_Get()

            await clsTools.pagConsole(`${FLG_MODULO} | Atualizando  atualizaTabRegrasIcms | Total de itens para processamento: ${listTabRegrasIcms.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)

            i = 0
            icount = 0 
            icountTotal = listTabRegrasIcms.length
            ilimite_reg_bloq_update =  myclsBase.myDataBase.MAX_UPDATE_DEFAULT
            sql = ``


            clsTools.pagConsole(`${FLG_MODULO} | Atualização TabRegrasIcms MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)


            for await (const item of listTabRegrasIcms) {
                
                sql += item.ZanthusPostGre_CRUD() 
                i++
                icount++
                if (i >= ilimite_reg_bloq_update) {
                    await clsTools.pagConsole(`${FLG_MODULO} | Atualizando  atualizaTabRegrasIcms | - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)

                    await myclsBase.myDataBase.zanthusPostgre.Execute(sql)
                    sql = ``
                    i = 0
                }
            }
            
            if (sql !== ``) {
                await myclsBase.myDataBase.zanthusPostgre.Execute(sql)
            }
            

        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO atualizaTabRegrasIcms', e);
        }
        finally {
            await clsTools.pagConsole(`${FLG_MODULO} | Atualizacao TabRegrasIcms finalizada - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
        }
    }   


    

}
