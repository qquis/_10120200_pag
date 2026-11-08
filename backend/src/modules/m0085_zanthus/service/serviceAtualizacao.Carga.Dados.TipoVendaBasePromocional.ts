/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ TABTIPOVENDA (JS ServiceAtualizacao.tabMercadoria)"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
    const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE : string = ``
/*  ____________________________________________________________________________________________*/    




import { clsBase, clsTools } from "../../../model/modelbase";
import tbZanthusTabMercadoriaTipoVenda from "../tbs/tbZanthusTabMercadoriaTipoVenda";


export default class serviceZanthusAtualizacaoDadosTipoVenda  {


    static async start (parametro: any) {

        let i = 0
             let icount = 0 
             let icountTotal = 0
             let ilimite_reg_bloq_update : number = 200
             let sql = ``
    
             try {
                let myclsBase : clsBase = new clsBase()
    
                await clsTools.pagConsole(`${FLG_MODULO} | Iniciando processamento ${parametro?.carga_uuid !== '' ? `| Código da Carga ${parametro.carga_uuid}` : ''}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)    

    
                let listTabTipoVenda = await this.getList(parametro)
    
    
                await clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabTipoVenda Total de itens para processamento: ${listTabTipoVenda.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
    
    
                i = 0
                icount = 0 
                icountTotal = listTabTipoVenda.length
                ilimite_reg_bloq_update =  myclsBase.myDataBase.MAX_UPDATE_DEFAULT
                sql = ``

                
                let listCodMercadoria : string[] = []
                for (const item of listTabTipoVenda) {
                    if (item.tab_pre_cd == 2) {
                        listCodMercadoria.push(`'${item.cod_mercadoria}'`)
                    }
                }
                let stringListCodMercadoria = listCodMercadoria.join(',')
                this.LimpaDadosTipoVendaPromocional({ ListMercadoriaEmPromocao: stringListCodMercadoria })
                
    
                await clsTools.pagConsole(`${FLG_MODULO} | Atualização TabMercadoria MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
    
                for await (const item of listTabTipoVenda) {
                
                    
                    sql += item.ZanthusPostGre_CRUD() 
                    i++
                    icount++
                    if (i >= ilimite_reg_bloq_update) {
                        await clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabTipoVenda - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                        await myclsBase.myDataBase.zanthusPostgre.Execute(sql)
                        sql = ``
                        i = 0
                    }
                }
    
                if (sql !== ``) {
                    await myclsBase.myDataBase.zanthusPostgre.Execute(sql)
                }
    
            } catch (e) {
                await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO atualizaTabTipoVenda', e);
            }
            finally {
                await clsTools.pagConsole(`${FLG_MODULO} | Atualizacao TabTipoVenda finalizada - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
    }
    private static async LimpaDadosTipoVendaPromocional(parametro: any) {
        try { 
            let myclsBase : clsBase = new clsBase()
            await clsTools.pagConsole(`${FLG_MODULO} | Limpando dados de TipoVenda Promocional...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)

            let sql_delete_1 = `delete from tab_mercadoria_tipo_venda where cod_tipo_venda = 2; `
            let sql_delete_2 = `delete from tab_mercadoria_tipo_venda_qtde where cod_tipo_venda = 2; `
                        

            if (parametro.ListMercadoriaEmPromocao && parametro.ListMercadoriaEmPromocao.length > 0) {
                sql_delete_1 = `delete from tab_mercadoria_tipo_venda where cod_tipo_venda = 2 and cod_mercadoria not in(${parametro.ListMercadoriaEmPromocao}); `
                sql_delete_2 = `delete from tab_mercadoria_tipo_venda_qtde where cod_tipo_venda = 2 and cod_mercadoria not in(${parametro.ListMercadoriaEmPromocao}); `
                
                await myclsBase.myDataBase.zanthusPostgre.Execute(sql_delete_1)
                await myclsBase.myDataBase.zanthusPostgre.Execute(sql_delete_2)
            }
            await myclsBase.myDataBase.zanthusPostgre.Execute(sql_delete_1)
            await myclsBase.myDataBase.zanthusPostgre.Execute(sql_delete_2)

        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO LimpaDadosTipoVendaPromocional', e);
        }
    }

    private static async getList(parametro: any) {
        let listTabTipoVenda : tbZanthusTabMercadoriaTipoVenda[] = []
        try {

            let myClsBase : clsBase = new clsBase()

            let result : any = await myClsBase.myDataBase.pag.DataGet(this.scriptSql(parametro))

            for await ( const[key, value] of Object.entries(result)) {
                let itemTbZanthusTabMercadoriaTipoVenda : tbZanthusTabMercadoriaTipoVenda = new tbZanthusTabMercadoriaTipoVenda()
                itemTbZanthusTabMercadoriaTipoVenda.binding(value)
                listTabTipoVenda.push(itemTbZanthusTabMercadoriaTipoVenda)
                
            }
        } catch (e) {
            await clsTools.PagErrorException(`M0085_Zanthus`, `serviceAtualizacao.Dados.TipoVenda | getList`, e);
        }
        finally {
            return listTabTipoVenda
        }  return listTabTipoVenda;
         
    }

    private static scriptSql (parametro: any) { 
          let sqlscript : string = `` 
        sqlscript =   
                `select 	a.tab_pre_cd 
                        ,	a.pr_cdproduto				
                        ,	a.prb_cdprodutobluesoft						
                        ,	a.preg_cdbarra								
                        ,	a.cod_loja 									
                        ,	a.controle 									
                        ,	a.cod_mercadoria
                        ,	a.cod_tipo_venda 
                        ,	a.usuario 
                        ,	a.data_cadastro 
                        ,	coalesce(a.data_ultima_alteracao, current_timestamp) as data_ultima_alteracao
                        ,	a.preco_unitario 
                        ,	a.percentual_comissao_vendedor
                        ,   coalesce(a.preco_anterior,0) as preco_anterior
                from 		tbzanthustab_mercadoria_tipo_venda a
                inner join  tbzanthustab_mercadoria  		   me on me.pr_cdproduto = a.pr_cdproduto 
                                                                 and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                inner join  tbproduto 						   pr on pr.pr_cdproduto = me.pr_cdproduto 												
                where		1 = 1 
                `

                if (parametro.cod_mercadoria && parametro.cod_mercadoria != '') {
                    sqlscript += ` and me.cod_mercadoria = '${parametro.cod_mercadoria}' `
                }

                if (parametro.carga_uuid && parametro.carga_uuid != '') {
                    sqlscript += ` and ( 
                                            me.cod_mercadoria in (select cod_mercadoria from tbzanthus_carga_produto where carga_uuid = '${parametro.carga_uuid}') 
                                         or a.tab_pre_cd = 2  
                                        )
                                            `
                                        

                }
        return sqlscript;
    }

}