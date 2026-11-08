/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ TABMERCADORIA (JS ServiceAtualizacao.tabMercadoria)"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
    const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE : string = ``
/*  ____________________________________________________________________________________________*/    




import { clsBase, clsTools } from "../../../model/modelbase";
import reportZanthusTabMercadoria_Select from "../report/report.ZanthusTabMercadoria_Select";
import reportZanthusType from "../report/ReportFilterType";
import tbZanthusTabMercadoria from "../tbs/tbZanthusTabMercadoria";


export default class serviceZanthusAtualizacaoDadosMercadoria  {


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

    static async getList(parametro: any) {
        let listTabMercadoria: tbZanthusTabMercadoria[] = []
        try { 
                let myDataBase: clsBase = new clsBase()



                let listMercadoria = await myDataBase.myDataBase.pag.DataGet(this.scriptSql(parametro))


            for await ( const[key, value] of Object.entries(listMercadoria)) {
                let itemTbZanthusTab_Mercadoria : tbZanthusTabMercadoria = new tbZanthusTabMercadoria()
                itemTbZanthusTab_Mercadoria.binding(value)
                listTabMercadoria.push(itemTbZanthusTab_Mercadoria)

                if (process.env.ZANTHUS_TIPO_CARGA_LOG && process.env.ZANTHUS_TIPO_CARGA_LOG == "1") {
                   await clsTools.pagConsole(`${FLG_MODULO} | Produto: ${itemTbZanthusTab_Mercadoria.pr_cdproduto} - ${itemTbZanthusTab_Mercadoria.descricao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG_TESTE)
                }
                
            }

            
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
        sqlscript =   `SELECT	me.pr_cdproduto				
                            ,   pr.prb_cdprodutobluesoft as prb_cdprodutobluesoftunitario 				
                            ,	me.prb_cdprodutobluesoft						
                            ,	me.preg_cdbarra								
                            ,	me.cod_loja 									
                            ,	me.controle 									
                            ,	me.cod_mercadoria 								
                            ,	me.descricao 									
                            ,	me.desc_abr             as descricao_abr								
                            ,	me.cod_departamento 							
                            ,	me.cod_tributacao_mercadoria					
                            ,	me.cod_tecla 									
                            ,	me.percentual_desc_venda						
                            ,	me.permissao_venda  							
                            ,	me.percentual_reduz_b_calculo					
                            ,	me.indica_merc_peso_variavel					
                            ,	me.custo_unitario 								
                            ,	me.grupo_garantia								
                            ,	me.fator_seguranca_venda_estoque				
                            ,	me.unidade_venda								
                            ,	me.data_modo_preco 							
                            ,	me.margem_mercadoria 							
                            ,	me.quantidade_embalagem 						
                            ,	me.cod_fornecedor								
                            ,	me.custo_moeda_estavel							
                            ,	me.aliquota_icms 								
                            ,	me.quantidade_bonus_venda						
                            ,	me.quantidade_max_preco_promo 					
                            ,	me.valor_total_preco_promocao 					
                            ,	me.custo_contabil 								
                            ,	me.quantidade_maxima_venda 					
                            ,	me.multiplica_pontos_valor_liq 				
                            ,	me.quantidade_pontos_venda 					
                            ,	me.cod_situacao_tributaria 					
                            ,   me.data_cadastro 								
                            ,	me.data_ultima_alteracao 						
                            ,	me.cod_ncm										
                            ,	me.cod_produto_pai	
                            ,	me.cest 
                            ,   me.cfop
                            ,   me.cod_sit_trib_pis
                            ,   me.aliquota_pis
                            ,   me.cod_sit_trib_cofins
                            ,   me.aliquota_cofins
                            ,   coalesce(me.codigo_beneficio_fiscal, '') as codigo_beneficio_fiscal
                FROM            tbzanthustab_mercadoria me
                inner join      tbproduto pr on pr.pr_cdproduto = me.pr_cdproduto
                WHERE   1 = 1 `


                if (parametro.cod_mercadoria && parametro.cod_mercadoria != '') {
                    sqlscript += ` and me.cod_mercadoria = '${parametro.cod_mercadoria}' `
                }

                if (parametro.carga_uuid && parametro.carga_uuid != '') {
                    sqlscript += ` and cod_mercadoria in (select cod_mercadoria from tbzanthus_carga_produto where carga_uuid = '${parametro.carga_uuid}') `
                }
        return sqlscript;
    }

}