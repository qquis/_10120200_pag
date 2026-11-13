/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ TABMERCADORIA - INATIVACAO (JS ServiceAtualizacao.tabMercadoria)"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
    const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE : string = ``
/*  ____________________________________________________________________________________________*/    




import { clsBase, clsTools } from "../../../model/modelbase";
import reportZanthusTabMercadoria_Select from "../report/report.ZanthusTabMercadoria_Select";
import reportZanthusType from "../report/ReportFilterType";
import tbZanthusTabMercadoria from "../tbs/tbZanthusTabMercadoria";


export default class serviceZanthusAtualizacaoDadosMercadoriaInativacaoGeral  {


    static async start (parametro: any) {

        let i = 0
             let icount = 0 
             let icountTotal = 0
             let ilimite_reg_bloq_update : number = 200
             let sql = ``
    
             try {
                let myclsBase : clsBase = new clsBase()
    
                await clsTools.pagConsole(`${FLG_MODULO} | Iniciando processamento ${parametro?.carga_uuid !== '' ? `| Código da Carga ${parametro.carga_uuid}` : ''}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)    

    
                let listTabMercadoria = await this.getList(parametro)
    
    
                await clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabMercadoria Total de itens para processamento: ${listTabMercadoria.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
    
    
                i = 0
                icount = 0 
                icountTotal = listTabMercadoria.length
                ilimite_reg_bloq_update =  myclsBase.myDataBase.MAX_UPDATE_DEFAULT
                sql = ``
    
                await clsTools.pagConsole(`${FLG_MODULO} | Atualização TabMercadoria MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
    
                for await (const item of listTabMercadoria) {
                    
                    sql += `UPDATE TAB_MERCADORIA 
                               SET FLGINATIVO = '1' 
                               ,   DATA_ULTIMA_ALTERACAO = CURRENT_DATE
                            WHERE COD_MERCADORIA = '${item.cod_mercadoria}'; `
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

    static async getList(parametro: any) {
        let listTabMercadoria: any[] = []
        try { 
                let myDataBase: clsBase = new clsBase()



                let listMercadoria = await myDataBase.myDataBase.pag.DataGet(this.scriptSql(parametro))
                 listTabMercadoria = Object.keys(listMercadoria)


            
         } catch (e) {
             await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO getList', e);
         }

         finally {
             await clsTools.pagConsole(`${FLG_MODULO} | Atualizacao - ${listTabMercadoria.length} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
             return listTabMercadoria;
         }
    }

    static scriptSql (parametro: any) { 
        let sqlscript : string = `` 
        sqlscript =   ` SELECT lpad(i.prbg_cdbarra_pk, 14, '0') as cod_mercadoria
                        from   tbprodutobluesoft_gtins  i
                        inner join  tbprodutobluesoft        prb on prb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
                        inner join  tbproduto_subgrupo       sb on sb.prg_cdgrupo = prb.prb_cdsubgrupo 
                        inner join  tbproduto_grupo          gr on gr.prg_cdgrupo = sb.prg_cdgrupo
                        inner join  tbproduto_secao          sc on sc.prs_cdsecao = gr.prs_cdsecao
                        inner join  tbproduto_departamento    dp on dp.prd_cddepartamento = sc.prd_cddepartamento
                        where       1 = 1
                        and         prb.prb_status = 'false'
                        and         dp.prd_habilita_integracao_zanthus = 'true'
                        `


        return sqlscript;
    }

}