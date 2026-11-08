/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - Service | CARGA PADRÃO"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
    const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE : string = ``
/*  ____________________________________________________________________________________________*/    





import { clsBase, clsTools } from "../../../model/modelbase";
import zanthusService from "./service";
import serviceZanthusAtualizacaoDadosPrepararBasePrime from "./serviceAtualizacao.Carga.Dados.PrepararBasePrime";
import serviceAtualizacaoDadosVoucherPromocional from "./serviceAtualizacao.Carga.Dados.VoucherPromocional";

import serviceSistemaLog from "../../m9020_sistema_log/service/service.SistemaLog";

import modelzanthus_produto from "../model/model_zanthus_produto";

import modelintegracao_tipo from "../../m0095_integracao";

import reportZanthusProduto from "../report/report.ZanthusTab";

import reportZanthus from "../report/report";

export default class serviceZanthusCargaOld  {

    static async start(parametros: any) : Promise<any> {

        try { 


            let resultadoCarga = { 
                integracao_tipo_cd: 0,
                integracao_tipo_descricao: "NÃO IDENTIFICADA",
                tipoCarga: parametros.TipoCompleta ? `COMPLETA` : `PARCIAL`,
                integracao_pendente_qtde: 0,
                integracao_qtde_promocional: 0,
                numero_voucher_atual: 0
            }

            

            /*Chamando o metodo de Preparação dos dados
            -------------------------------------------------------------------------------------
            -------------------------------------------------------------------------------------
            */
            await clsTools.pagConsole(`${FLG_MODULO} - Chamando o método PrepararDadosZanthusNaBasePag`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            await serviceZanthusAtualizacaoDadosPrepararBasePrime.start()


            /*Obtendo os produtos Pendentes
            -------------------------------------------------------------------------------------
            -------------------------------------------------------------------------------------
            */
            await clsTools.pagConsole(`${FLG_MODULO} - Chamando o método ObterProdutosPendentesDeIntegracao`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            let ListaDeProdutosPendentesDeIntegracao : modelzanthus_produto[] = await this.ObterProdutosPendentesDeIntegracao()
            resultadoCarga.integracao_pendente_qtde = ListaDeProdutosPendentesDeIntegracao.length


            /*LIMPANDO DADOS DE TIPO VENDA PROMOCIONAL
            -------------------------------------------------------------------------------------
            -------------------------------------------------------------------------------------
            */
            await this.LimparDadosTipoVendaPromocional({})


            /*Processando os produtos Pendentes
            -------------------------------------------------------------------------------------
            -------------------------------------------------------------------------------------
            */
            await clsTools.pagConsole(`${FLG_MODULO} - Chamando o método ProcessarProdutosPendentesDeIntegracao`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            await this.ProcessarProdutosPendentesDeIntegracao(ListaDeProdutosPendentesDeIntegracao)


            /*Finalização da CARGA - METODO FINALIZAR
            -------------------------------------------------------------------------------------
            -------------------------------------------------------------------------------------
            */
            await clsTools.pagConsole(`${FLG_MODULO} - Chamando o método finalizar`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            await this.finalizar()


            /*Conferindo o Voucher
            -------------------------------------------------------------------------------------
            -------------------------------------------------------------------------------------
            */
            await clsTools.pagConsole(`${FLG_MODULO} - Conferindo o Voucher`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            let numeroVoucherAtual = parseInt(clsTools._datemomentDateToStr(new Date(), `YYYYMMDD`))

                let result = await reportZanthus.ZeusVoucherQtdeProdutos({ cod_voucher: numeroVoucherAtual })
                let qtdePromocional = Array.isArray(result) ? result[0].qtde_voucher_promocional_prd : 0

            //let qtdePromocional = await myZanthusService.ZeusRetailConferirVoucher({ cod_voucher: numeroVoucherAtual })

            resultadoCarga.integracao_qtde_promocional = qtdePromocional;
            resultadoCarga.numero_voucher_atual = numeroVoucherAtual;


            /*Retornando o resultado da carga
            -------------------------------------------------------------------------------------
            -------------------------------------------------------------------------------------
            */
            await clsTools.pagConsole(`${FLG_MODULO} - FINALIZANDO CARGA -Retornando o resultado da carga`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            return resultadoCarga; 
        }
        catch (e) {
            await clsTools.PagErrorException(`${FLG_MODULO}`, 'start', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
           
        }

    }

    static async LimparDadosTipoVendaPromocional(parametro: any) {
        try {

            let myclsBase : clsBase = new clsBase()
            let sql =`  delete from tab_mercadoria_tipo_venda where cod_tipo_venda = 2; 
                        delete from tab_mercadoria_tipo_venda_qtde where cod_tipo_venda = 2; 
                       `
            await myclsBase.myDataBase.zanthusPostgre.Execute(sql)


        } catch (e) {
            await clsTools.PagErrorException(`${FLG_MODULO}`, 'LimparDadosTipoVendaPromocional', e, false, "ERRO AO LIMPAR DADOS DE TIPO VENDA PROMOCIONAL", FLG_DEBUG_FILE_CONSOLE_LOG);
        }
    }

    static async ObterProdutosPendentesDeIntegracao() : Promise<modelzanthus_produto[]> {
        let mylistZanthusProdutoPendenteIntegracao : modelzanthus_produto[] = []
        try { 

            let myDATABASE : clsBase = new clsBase()


        let script_PRODUTOS : string = `
                        SELECT      pr.pr_cdproduto
                                ,   pr.prb_cdprodutobluesoft 
                                ,   pr.prb_cdprodutobluesoft  as prb_cdprodutobluesoftunitario
                                ,   pr.pr_descricao 
                                ,   coalesce(ix.integracao_produto_seq, 0) as integracao_produto_seq
                                ,   cast(20008501 as int) as integracao_tipo_cd 
                        from tbproduto pr
                        left join  tbintegracao_produto ix on ix.pr_cdproduto = pr.pr_cdproduto 
                                                          and ix.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
                                                          and ix.prb_cdprodutobluesoftunitario = pr.prb_cdprodutobluesoft
                                                          and ix.integracao_tipo_cd = 20008501
                        where 1 = 1 
                                and coalesce(ix.integracao_produto_seq, 0) <> 0 
                                and ix.integracao_status_cd = 2
                                `
                            


            script_PRODUTOS += `union 



                         select 	  pr.pr_cdproduto
                                    ,   pr.prb_cdprodutobluesoft 
                                    ,   pr.prb_cdprodutobluesoft  as prb_cdprodutobluesoftunitario
                                    ,   pr.pr_descricao 
                                    ,   coalesce(ix.integracao_produto_seq, 0) as integracao_produto_seq
                                    ,   cast(20008501 as int) as integracao_tipo_cd 
                            from 		tbproduto_composicao cp 
                            inner join 	tbproduto pr on pr.prb_cdprodutobluesoft = cp.prb_cdprodutobluesoft_unitario
                            left join  tbintegracao_produto ix on ix.pr_cdproduto = pr.pr_cdproduto 
                                    and ix.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
                                    and ix.prb_cdprodutobluesoftunitario = pr.prb_cdprodutobluesoft
                                    and ix.integracao_tipo_cd = 20008501
                            where 1 = 1 
                                and coalesce(ix.integracao_produto_seq, 0) <> 0 
                                and ix.integracao_status_cd = 2
                            `
                            
                                                 
            script_PRODUTOS += `
                            group by  pr.pr_cdproduto
                                    ,   pr.prb_cdprodutobluesoft 
                                    ,   pr.prb_cdprodutobluesoft  
                                    ,   pr.pr_descricao 
                                    ,   coalesce(ix.integracao_produto_seq, 0)
                                    ,   cast(20008501 as int) 

                `





            script_PRODUTOS += " order by 1 asc "



            let myreportZanthusProduto : reportZanthusProduto  = new reportZanthusProduto()
            
            
            /*OBTENDO OS EANS PENDENTES POR TABELA ZANTHUS
            -------------------------------------------------------------------------------------
            -------------------------------------------------------------------------------------
            */
            await clsTools.pagConsole(`${FLG_MODULO} - Obtendo os EANS pendentes de integração | codigo integração = 20008501 (Método: ObterProdutosPendentesDeIntegracao)`, false, false)
            await myreportZanthusProduto.Select({
                ProdutosPendentesDeIntegracao : true,
                integracao_tipo_cd : 20008501

            })

           
           
            /*OBTENDO OS CODIGOS PENDENTES
            -------------------------------------------------------------------------------------
            -------------------------------------------------------------------------------------
            */      
            await clsTools.pagConsole(`${FLG_MODULO} - Obtendo os CODIGOS pendentes de integração | codigo integração = 20008501 (Método: ObterProdutosPendentesDeIntegracao)`, false, false)
            let ProdutosPendentesDeIntegracao : any = await myDATABASE.myDataBase.pag.DataGet(script_PRODUTOS)






            /*PROCESSANDO OS PRODUTOS PENDENTES DE INTEGRAÇÃO
            -------------------------------------------------------------------------------------
            -------------------------------------------------------------------------------------
            */      
            await clsTools.pagConsole(`${FLG_MODULO} - Processando Códigos/EANS | codigo integração = 20008501 (Método: ObterProdutosPendentesDeIntegracao)`, false, false)
            
            if (myreportZanthusProduto.listTabMercadoria.length > 0 ){
                for await ( const[key, value] of Object.entries(ProdutosPendentesDeIntegracao)) {
                    let myitem : modelzanthus_produto = new modelzanthus_produto()
                    await myitem.binding(value)

                    await myitem.binding_mercadoria(
                        myreportZanthusProduto.listTabMercadoria, 
                        myreportZanthusProduto.listTabRegrasIcms,
                        myreportZanthusProduto.listTabMercadoriaTipoVenda,
                        myreportZanthusProduto.listTabMercadoriaTipoVendaQtde, 
                        myreportZanthusProduto.listTabProdutoDecomposicao, 
                        myreportZanthusProduto.listTabProdutoDecomposicaoInsum
                    )
                    if (myitem.ListTabMercadoria.length > 0) {
                        mylistZanthusProdutoPendenteIntegracao.push(myitem)
                    }
                } 
            }

        } catch (e) {
            await clsTools.PagErrorException(`${FLG_MODULO}`, 'serviceAtualizacaoPadrao', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
        }
        
        
        finally { 
            return mylistZanthusProdutoPendenteIntegracao 
        }


    }

    static async ProcessarProdutosPendentesDeIntegracao(ListaDeProdutosPendentesDeIntegracao : modelzanthus_produto[]) : Promise<void> {
     
        let ZANTHUS_TIPO_CARGA_LOG : boolean = false;
        if (process.env.ZANTHUS_TIPO_CARGA_LOG && process.env.ZANTHUS_TIPO_CARGA_LOG == "1") {
            ZANTHUS_TIPO_CARGA_LOG = true;
            clsTools.pagConsole(`_ Carga ZANTHUS(POSTGRE) | Tipo de Log de Carga Ativado: ${ZANTHUS_TIPO_CARGA_LOG} `)
        }


        let myDATABASE : clsBase = new clsBase()
     
        let sqlScript : string = ``
        let numeroMaximo : number = 100
        let numeroCONTROLE_ITEM: number = 0;
        let numeroBloco: number = 1;
        let numeroTotalBloco: number = Math.ceil(ListaDeProdutosPendentesDeIntegracao.length / numeroMaximo);
        try {


            for await( let myitem  of ListaDeProdutosPendentesDeIntegracao) {

                if(ZANTHUS_TIPO_CARGA_LOG) {
                    await clsTools.pagConsole(`_ Carga ZANTHUS(POSTGRE) [Pendente] Processando _ Produto ${myitem.prb_cdprodutobluesoft}`)
                }


                if (myitem.PostGreSqlScriptUpdate.trim() !== ``) {
                    sqlScript += myitem.PostGreSqlScriptUpdate;
                }
                else { 
                   await clsTools.pagConsole(`_ Carga ZANTHUS(POSTGRE) [Pendente] Processando _ Produto ${myitem.prb_cdprodutobluesoft} NÃO POSSUI DADOS PARA ATUALIZAR`)
                }
                
                numeroCONTROLE_ITEM += 1;

                if (numeroCONTROLE_ITEM >= numeroMaximo) {
                    await serviceSistemaLog.Registrar.registrarLogResumido(0, "CARGA-NEW", `_ Carga ZANTHUS(POSTGRE) Proc Bloco ${numeroBloco}/${numeroTotalBloco} `,0,0)

                    if (sqlScript.trim() !== ``) {
                         await myDATABASE.myDataBase.zanthusPostgre.Execute(sqlScript);
                    }
                    sqlScript = ``;
                    numeroCONTROLE_ITEM = 0;
                    numeroBloco += 1;

                }
                clsTools._wait(15)                
            }

            if (sqlScript.trim() !== ``) {

                await serviceSistemaLog.Registrar.registrarLogResumido(0, "CARGA-NEW", `_ Carga ZANTHUS(POSTGRE) Proc Bloco ${numeroBloco}/${numeroTotalBloco} `,0,0)
                await myDATABASE.myDataBase.zanthusPostgre.Execute(sqlScript);

                sqlScript = ``;
                numeroCONTROLE_ITEM = 0;
            }


    
        } catch (e) {
            await clsTools.PagErrorException(`${FLG_MODULO}`, 'serviceAtualizacaoPadrao', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
        }
    }

    static async finalizar() { 
        try { 

                let myZanthuService : zanthusService = new zanthusService(); 

                myZanthuService.serviceLogTAG = "M0095_INT_PROD_20008501"
                await clsTools.pagConsole(`Atualizando TAB VOUCHERS`)
                await myZanthuService.AtualizarVoucherPromocionais();
                
                await clsTools.pagConsole(`zanthus.carga loja`)
                await myZanthuService.ZeusRetailCargaOxan();            

        } catch (e) {
            await clsTools.PagErrorException(`${FLG_MODULO}`, 'finalizar', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
        }
    }

}