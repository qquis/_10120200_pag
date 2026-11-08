/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ DECOMPOSICAO (JS ServiceAtualizacao.tabDecomposicao e Insumo)"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
    const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE : string = ``
/*  ____________________________________________________________________________________________*/    




import { clsBase, clsTools } from "../../../model/modelbase";
import tbZanthusTabProdutoDecomposicao from "../tbs/tbZanthusTabProdutoDecomposicao";
import tbZanthusTabProdutoDecomposicaoInsum from "../tbs/tbZanthusTabProdutoDecomposicaoInsum";


export default class serviceZanthusAtualizacaoDadosDecomposicao
  {

    static async start(parametro: any) { 
           await serviceAtualizacaoDadosDecomposicao.start(parametro)
           await serviceAtualizacaoDadosDecomposicaoInsum.start(parametro)
           
    }

    

}


class serviceAtualizacaoDadosDecomposicao {

    static async start (parametro: any) {

        let i = 0
             let icount = 0 
             let icountTotal = 0
             let ilimite_reg_bloq_update : number = 200
             let sql = ``
    
             try {
                let myclsBase : clsBase = new clsBase()
    
                let listTabDecomposicao = await this.getList_Decomposicao(parametro)
                await clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabDecomposicao Total de itens para processamento: ${listTabDecomposicao.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)

    
                let listTabREGRAICMS = listTabDecomposicao
                await clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabDecomposicao Total de itens para processamento: ${listTabREGRAICMS.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
    
    
                i = 0
                icount = 0 
                icountTotal = listTabREGRAICMS.length
                ilimite_reg_bloq_update =  myclsBase.myDataBase.MAX_UPDATE_DEFAULT
                sql = ``
    
                clsTools.pagConsole(`${FLG_MODULO} | Atualização TabDecomposicao MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)


                for await (const item of listTabDecomposicao) {
                    
                    sql += item.ZanthusPostGre_CRUD() 
                    i++
                    icount++
                    if (i >= ilimite_reg_bloq_update) {
                        await clsTools.pagConsole(`${FLG_MODULO} | Atualizando  atualizaTabDecomposicao | - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)

                        await myclsBase.myDataBase.zanthusPostgre.Execute(sql)
                        sql = ``
                        i = 0
                    }
                }
            
                if (sql !== ``) {
                    await myclsBase.myDataBase.zanthusPostgre.Execute(sql)
                }
    

    
            } catch (e) {
                await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO Tab Decomposicao', e);
            }
            finally {
                await clsTools.pagConsole(`${FLG_MODULO} | Atualizacao Tab Decomposicao finalizada - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
    }

    private static async getList_Decomposicao(parametro: any) {
        let listTabDecomposicao: tbZanthusTabProdutoDecomposicao[] = []
        try { 
                let myDataBase: clsBase = new clsBase()



                let resultTabDecomposicao = await myDataBase.myDataBase.pag.DataGet(this.scriptSql_Decomposicao(parametro))


            for await ( const[key, value] of Object.entries(resultTabDecomposicao)) {
                let itemTbZanthusTab_Decomposicao : tbZanthusTabProdutoDecomposicao = new tbZanthusTabProdutoDecomposicao()
                itemTbZanthusTab_Decomposicao.binding(value)
                listTabDecomposicao.push(itemTbZanthusTab_Decomposicao)

                if (process.env.ZANTHUS_TIPO_CARGA_LOG && process.env.ZANTHUS_TIPO_CARGA_LOG == "1") {
                   await clsTools.pagConsole(`${FLG_MODULO} | Produto: ${itemTbZanthusTab_Decomposicao.pr_cdproduto} - ${itemTbZanthusTab_Decomposicao.prb_cdprodutobluesoft}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG_TESTE)
                }
                
            }

            
         } catch (e) {
             await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO getList', e);
         }

         finally {
             await clsTools.pagConsole(`${FLG_MODULO} | Atualizacao - ${listTabDecomposicao.length} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
             return listTabDecomposicao;
         }
    }

    private static scriptSql_Decomposicao (parametro: any) { 
        let sqlscript : string = `` 
         sqlscript =   
                `select 	a.pr_cdproduto				
                        ,	a.prb_cdprodutobluesoft						
                        ,	a.preg_cdbarra								
                        ,	a.cod_loja 	
                        ,   coalesce(a.controle,'000') as controle
                        ,	a.cod_mercadoria
                        ,	forma_decomposicao 
                        ,	tipo_decomposicao 
                        ,	a.usuario 
                        ,	a.data_cadastro 
                        ,	coalesce(a.data_ultima_alteracao, current_timestamp) as data_ultima_alteracao
                from 		TbZanthustab_produto_decomposicao  a
                inner join  tbzanthustab_mercadoria  		   me on me.pr_cdproduto = a.pr_cdproduto 
                                                                 and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                inner join  tbproduto 						   pr on pr.pr_cdproduto = me.pr_cdproduto 												
                where		1 = 1 `


                if (parametro.cod_mercadoria && parametro.cod_mercadoria != '') {
                    sqlscript += ` and me.cod_mercadoria = '${parametro.cod_mercadoria}' `
                }
                /*
                if (parametro.carga_uuid && parametro.carga_uuid != '') {
                    sqlscript += ` and me.cod_mercadoria in (select cod_mercadoria from tbzanthus_carga_produto where carga_uuid = '${parametro.carga_uuid}') `
                }*/
        return sqlscript;
    }

}


class serviceAtualizacaoDadosDecomposicaoInsum {

    static async start (parametro: any) {

        let i = 0
             let icount = 0 
             let icountTotal = 0
             let ilimite_reg_bloq_update : number = 200
             let sql = ``
    
             try {
                let myclsBase : clsBase = new clsBase()
    
                let listTabDecomposicao = await this.getList_Decomposicao(parametro)
                await clsTools.pagConsole(`${FLG_MODULO} | Atualizando DECOMPOSICAO INSUM Total de itens para processamento: ${listTabDecomposicao.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)

    
                let listTabREGRAICMS = listTabDecomposicao
                await clsTools.pagConsole(`${FLG_MODULO} | Atualizando Tab DECOMPOSICAO INSUM Total de itens para processamento: ${listTabREGRAICMS.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
    
    
                i = 0
                icount = 0 
                icountTotal = listTabREGRAICMS.length
                ilimite_reg_bloq_update =  myclsBase.myDataBase.MAX_UPDATE_DEFAULT
                sql = ``
    
                clsTools.pagConsole(`${FLG_MODULO} | Atualização DECOMPOSICAO INSUM MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)


                for await (const item of listTabDecomposicao) {
                    
                    sql += item.ZanthusPostGre_CRUD() 
                    i++
                    icount++
                    if (i >= ilimite_reg_bloq_update) {
                        await clsTools.pagConsole(`${FLG_MODULO} | Atualizando  DECOMPOSICAO INSUM | - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)

                        await myclsBase.myDataBase.zanthusPostgre.Execute(sql)
                        sql = ``
                        i = 0
                    }
                }
            
                if (sql !== ``) {
                    await myclsBase.myDataBase.zanthusPostgre.Execute(sql)
                }
    

    
            } catch (e) {
                await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO Tab DECOMPOSICAO INSUM ATUALIZAÇÃO', e);
            }
            finally {
                await clsTools.pagConsole(`${FLG_MODULO} | Atualizacao Tab DECOMPOSICAO INSUM finalizada - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
    }

    private static async getList_Decomposicao(parametro: any) {
        let listTabDecomposicao: tbZanthusTabProdutoDecomposicaoInsum[] = []
        try { 
                let myDataBase: clsBase = new clsBase()



                let resultTabDecomposicaoInsum = await myDataBase.myDataBase.pag.DataGet(this.scriptSql_DecomposicaoInsum(parametro))


            for await ( const[key, value] of Object.entries(resultTabDecomposicaoInsum)) {
                let itemTbZanthusTab_DecomposicaoInsum : tbZanthusTabProdutoDecomposicaoInsum = new tbZanthusTabProdutoDecomposicaoInsum()
                itemTbZanthusTab_DecomposicaoInsum.binding(value)
                listTabDecomposicao.push(itemTbZanthusTab_DecomposicaoInsum)

                if (process.env.ZANTHUS_TIPO_CARGA_LOG && process.env.ZANTHUS_TIPO_CARGA_LOG == "1") {
                   await clsTools.pagConsole(`${FLG_MODULO} | Produto: ${itemTbZanthusTab_DecomposicaoInsum.pr_cdproduto} - ${itemTbZanthusTab_DecomposicaoInsum.prb_cdprodutobluesoft}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG_TESTE)
                }
                
            }

            
         } catch (e) {
             await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO getList', e);
         }

         finally {
             await clsTools.pagConsole(`${FLG_MODULO} | Atualizacao DECOMPOSICAO INSUM - ${listTabDecomposicao.length} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
             return listTabDecomposicao;
         }
    }

    private static scriptSql_DecomposicaoInsum (parametro: any) { 
        let sqlscript : string = `` 
         sqlscript =   
                `select 	a.pr_cdproduto				
                        ,	a.prb_cdprodutobluesoft						
                        ,	a.preg_cdbarra_insumo							
                        ,	a.cod_loja 	
                        ,   coalesce(a.controle,'000') as controle
                        ,	a.cod_mercadoria
                        ,   a.cod_insumo
                        ,	coalesce(percentual_insumo,0) as percentual_insumo
                        ,	coalesce(quantidade_insumo,0) as quantidade_insumo
                        ,	a.usuario 
                        ,	a.data_cadastro 
                        ,	coalesce(a.data_ultima_alteracao, current_timestamp) as data_ultima_alteracao
                from 		TbZanthustab_produto_decomposicao_insum  a
                inner join  tbzanthustab_mercadoria  		         me on me.pr_cdproduto = a.pr_cdproduto 
                                                                       and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                inner join  tbproduto 						         pr on pr.pr_cdproduto = me.pr_cdproduto 												
                where		1 = 1 `


                if (parametro.cod_mercadoria && parametro.cod_mercadoria != '') {
                    sqlscript += ` and me.cod_mercadoria = '${parametro.cod_mercadoria}' `
                }

                /*
                if (parametro.carga_uuid && parametro.carga_uuid != '') {
                    sqlscript += ` and me.cod_mercadoria in (select cod_mercadoria from tbzanthus_carga_produto where carga_uuid = '${parametro.carga_uuid}') `
                }*/
        return sqlscript;
    }

}