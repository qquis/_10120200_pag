
import { clsBase, clsTools } from "../../../model/modelbase";

import zanthusService from "./service";

/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 10050011
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085-ZANTHUS-Service | Atualizacao CBENEF CODIGO BENEFICIO FISCAL"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */  



export default class serviceAtualizacaoCbenef  {

    static async start(parametros: any = {}) : Promise<void> {
        try { 
            
            /* PREPARANDO BASE ZANTHUS */
            await clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - START (Preparando BASE ZANTHUS)`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            let myZanthusService : zanthusService = new zanthusService()
            await myZanthusService.PrepararDadosZanthusNaBasePag(true) 


            /* TAB MERCADORIA */
            await clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - START Iniciando Atualização CBENEF - TAB MERCADORIA`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            await this.AtualizarCbenefTabMercadoria(parametros)


            /* TAB REGRA ICMS */
            await clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - START Iniciando Atualização CBENEF - TAB REGRA ICMS`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            await this.AtualizarCbenefTabRegraIcms(parametros) 

        
            /* AJUSTE CST SEM CBENEF */
            await clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - START Iniciando Atualização AJUSTE CST SEM CBENEF`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            await this.AjusteCstSemCbenef(parametros)
    


            await clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Finalizado com SUCESSO - AJUSTE CBENEF`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
        } catch (e) {
            await clsTools.PagErrorException(`${FLG_MODULO}`, 'start', e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);
            throw new Error( `F0085 | ${FLG_MODULO}  ${e} `)
        }
    
    }



    static async AtualizarCbenefTabMercadoria(parametros: any) : Promise<void> {
        try {



            await clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Finalizado com SUCESSO - TAB MERCADORIA (LENDO BASE PAG)`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            let mydatabase : clsBase = new clsBase()

            let ScriptCbenefTabMercadoria : string = `

                                    SELECT  pr_cdproduto, 
                                            prb_cdprodutobluesoft, 
                                            cod_mercadoria,
                                            descricao, 
                                            coalesce(codigo_beneficio_fiscal,'') as codigo_beneficio_fiscal, 
                                            cod_situacao_tributaria as cod_situacao_tributaria
                                        FROM   tbzanthustab_mercadoria 
                                    where  cod_situacao_tributaria in ('40','20')

            `
            let resultCbenefTabMercadoria : any = await mydatabase.myDataBase.pag.DataGet(ScriptCbenefTabMercadoria)

            let i = 0
            let totalBlocoInsert = 50
            let blocoInsert = 0 
            let scriptInsertCbenef = ``

                        await clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Iniciando atualização de TAB MERCADORIA`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)

            for await (const item of resultCbenefTabMercadoria) {

                scriptInsertCbenef += 
                ` UPDATE tab_mercadoria
                    SET codigo_beneficio_fiscal = '${item.codigo_beneficio_fiscal}'
                    where  cod_mercadoria = '${item.cod_mercadoria}' ; 
                  
                  `
                i++

                if (i >= totalBlocoInsert) {
                    blocoInsert ++
                    clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - (TAB_MERCADORIA) Executando bloco de atualização de Cbenef. Total de registros no bloco: ${blocoInsert}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                    await mydatabase.myDataBase.zanthusPostgre.Execute(scriptInsertCbenef)
                    scriptInsertCbenef = ``
                    i = 0
                }

                

            }


            scriptInsertCbenef = scriptInsertCbenef + ` 
            
                        UPDATE tab_mercadoria set codigo_beneficio_fiscal = ''
                        where lpad(cod_situacao_tributaria, 3, '0') not in ('040','020')
                        and coalesce(codigo_beneficio_fiscal,'') != '' ; 
                                                               
                        UPDATE tab_regras_icms set codigo_beneficio_fiscal = ''
                        where flg_tipo_imposto = '0'
                        and lpad(cst,3,'0') not in ('040','020')	
                                                        `

            if (scriptInsertCbenef != ``) {
                clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Executando bloco final e ajuste final de outras csts: ${blocoInsert}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                await mydatabase.myDataBase.zanthusPostgre.Execute(scriptInsertCbenef)
                scriptInsertCbenef = ``
                i = 0
            }

            clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Processamento de atualização de Cbenef concluído.`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)



        } catch (e) {
            clsTools.PagErrorException(`serviceAtualizacaoCbenef`, 'start', e);
            throw new Error( `F0085 | serviceAtualizacaoCbenef  ${e} `)
        }
    }

    static async AtualizarCbenefTabRegraIcms(parametros: any) : Promise<void> {
        try {


            await clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Iniciando atualização de TAB_REGRAS_ICMS`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            let mydatabase : clsBase = new clsBase()

            let ScriptCbenefTabRegraIcms : string = `

                                    select cod_mercadoria
                                         , flg_revenda
                                         , flg_tipo_imposto
                                         , CST 
                                         , codigo_beneficio_fiscal
                                    from tbzanthustab_regra_icms  
                                    where  lpad(cst,3,'0') in ('040','020')
                                      and  flg_tipo_imposto = '0'

            `
            let resultCbenefTabRegraIcms : any = await mydatabase.myDataBase.pag.DataGet(ScriptCbenefTabRegraIcms)

            let i = 0
            let totalBlocoInsert = 50
            let blocoInsert = 0 
            let scriptInsertCbenef = ``


            await clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Preparando atualização de TAB_REGRAS_ICMS`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)

            for await (const item of resultCbenefTabRegraIcms) {

                scriptInsertCbenef += 
                ` UPDATE tab_regras_icms
                    SET    codigo_beneficio_fiscal = '${item.codigo_beneficio_fiscal}'
                    where  cod_mercadoria = '${item.cod_mercadoria}' 
                      and  flg_revenda = '${item.flg_revenda}'
                      and  flg_tipo_imposto = '${item.flg_tipo_imposto}'
                      ;
                  `
                i++

                if (i >= totalBlocoInsert) {
                    blocoInsert ++
                    await clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Executando bloco de atualização de Cbenef (TAB_REGRAS_ICMS). Total de registros no bloco: ${blocoInsert}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                    await mydatabase.myDataBase.zanthusPostgre.Execute(scriptInsertCbenef)
                    scriptInsertCbenef = ``
                    i = 0
                }

                await clsTools.pagConsole(`${FLG_MODULO} | serviceAtualizacaoCbenef - Finalizando atualização de TAB_REGRAS_ICMS`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)

            }




        } catch (e) {
            clsTools.PagErrorException(`serviceAtualizacaoCbenef`, 'start', e);
            throw new Error( `F0085 | serviceAtualizacaoCbenef  ${e} `)
        }
    }

    static async AjusteCstSemCbenef(parametros: any) : Promise<void> {

        try { 

            await clsTools.pagConsole(`${FLG_MODULO} | AjusteCstSemCbenef - Iniciando ajuste de CST sem Cbenef`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)

            let sql = `
            
                        UPDATE tab_mercadoria set codigo_beneficio_fiscal = ''
                        where lpad(cod_situacao_tributaria, 3, '0') not in ('040','020')
                        and coalesce(codigo_beneficio_fiscal,'') != '' ; 
                                                               
                        UPDATE tab_regras_icms set codigo_beneficio_fiscal = ''
                        where flg_tipo_imposto = '0'
                        and lpad(cst,3,'0') not in ('040','020')	
                                                        `;

            let mydatabase : clsBase = new clsBase()
            await mydatabase.myDataBase.zanthusPostgre.Execute(sql)

            await clsTools.pagConsole(`${FLG_MODULO} | AjusteCstSemCbenef - Ajuste de CST sem Cbenef concluído.`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)


        } catch (e) {
            await clsTools.PagErrorException(`${FLG_MODULO}`, 'AjusteCstSemCbenef',e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);

        }


    }





}
