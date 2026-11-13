/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ TABTIPOVENDAQTDE (JS ServiceAtualizacao.tabTipoVendaQtde)"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
    const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE : string = ``
/*  ____________________________________________________________________________________________*/    




import { clsBase, clsTools } from "../../../model/modelbase";
import tbZanthusTabMercadoriaTipoVendaQtde from "../tbs/tbZanthusTabMercadoriaTipoVendaQtde";


export default class serviceZanthusAtualizacaoDadosTipoVendaQtde  {


    static async start (parametro: any) {

        let i = 0
             let icount = 0 
             let icountTotal = 0
             let ilimite_reg_bloq_update : number = 200
             let sql = ``
    
             try {
                let myclsBase : clsBase = new clsBase()
    
                await clsTools.pagConsole(`${FLG_MODULO} | Iniciando processamento ${parametro?.carga_uuid !== '' ? `| Código da Carga ${parametro.carga_uuid}` : ''}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)    

    
                let listTabTipoVendaQtde = await this.getList(parametro)
    
    
                await clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabTipoVendaQtde Total de itens para processamento: ${listTabTipoVendaQtde.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
    
    
                i = 0
                icount = 0 
                icountTotal = listTabTipoVendaQtde.length
                ilimite_reg_bloq_update =  myclsBase.myDataBase.MAX_UPDATE_DEFAULT
                sql = ``
    
                await clsTools.pagConsole(`${FLG_MODULO} | Atualização TabTipoVendaQtde MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
    
                for await (const item of listTabTipoVendaQtde) {
                    
                    sql += item.ZanthusPostGre_CRUD() 
                    i++
                    icount++
                    if (i >= ilimite_reg_bloq_update) {
                        await clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabTipoVendaQtde - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                        await myclsBase.myDataBase.zanthusPostgre.Execute(sql)
                        sql = ``
                        i = 0
                    }
                }
    
                if (sql !== ``) {
                    await myclsBase.myDataBase.zanthusPostgre.Execute(sql)
                }
    
            } catch (e) {
                await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO atualizaTabTipoVendaQtde', e);
            }
            finally {
                await clsTools.pagConsole(`${FLG_MODULO} | Atualizacao TabTipoVendaQtde finalizada - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
    }

    static async getList(parametro: any) {
        let listTabTipoVendaQtde : tbZanthusTabMercadoriaTipoVendaQtde[] = []
        try {

            let myClsBase : clsBase = new clsBase()

            let result : any = await myClsBase.myDataBase.pag.DataGet(this.scriptSql(parametro))

            for await ( const[key, value] of Object.entries(result)) {
                let itemTbZanthusTabTipoVendaQtde : tbZanthusTabMercadoriaTipoVendaQtde = new tbZanthusTabMercadoriaTipoVendaQtde()
                itemTbZanthusTabTipoVendaQtde.binding(value)
                listTabTipoVendaQtde.push(itemTbZanthusTabTipoVendaQtde)
                
            }

        } catch (e) {

            await clsTools.PagErrorException(`M0085_Zanthus`, `serviceAtualizacao.Dados.TipoVendaQtde | getList`, e);

        }
        finally {
            return listTabTipoVendaQtde
        }
         
    }

    static scriptSql (parametro: any) { 
               let sqlscript : string = `` 
                    sqlscript =   
                            `select 		a.pr_cdproduto
                                        ,	a.prb_cdprodutobluesoft 
                                        ,	a.preg_cdbarra 
                                        ,	a.cod_loja
                                        ,	a.cod_mercadoria
                                        ,	a.cod_tipo_venda
                                        ,	a.qtde_venda
                                        --,	a.flag_geral
                                        ,	a.preco_unitario
                                        ,	a.perc_desconto
                                        --,	a.flag_ativo
                                        ,	a.Dth_inclusao
                                        ,	a.Dth_alteracao
                                        ,	a.Idt_usuario_alteracao
                            from   		tbzanthustab_mercadoria_tipo_venda_qtde a
                            inner join  tbzanthustab_mercadoria  		   me on me.pr_cdproduto = a.pr_cdproduto 
                                                                            and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                                                                            and me.cod_mercadoria = a.cod_mercadoria
                            inner join  tbproduto 						   pr on pr.pr_cdproduto = me.pr_cdproduto 												
                            where		1 = 1 
                            `

                if (parametro.cod_mercadoria && parametro.cod_mercadoria != '') {
                    sqlscript += ` and me.cod_mercadoria = '${parametro.cod_mercadoria}' `
                }

                if (parametro.carga_uuid && parametro.carga_uuid != '') {
                    sqlscript += ` and me.cod_mercadoria in (select cod_mercadoria from tbzanthus_carga_produto where carga_uuid = '${parametro.carga_uuid}') `
                }
        return sqlscript;
    }

}