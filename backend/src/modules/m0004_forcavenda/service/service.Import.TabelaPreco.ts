import { clsBase, clsTools } from "../../../model/modelbase";
import modelforca_venda_tabpreco from "../model/modelforca_venda_tabelapreco";
import modelforca_venda_tabprecoVersao from "../model/modelforca_venda_tabelaprecoVersao";
import modelforca_venda_tabprecoProdutoBluesoft from "../model/modelforca_venda_tabelaprecoProdutoBluesoft";

const myBase : clsBase = new clsBase()




class ForcaVendaImportTabelaPrecoApi { 
        static async start() { 
        try { 

                clsTools.pagConsole(`Iniciando Importação Tabela Preço Força de Venda`, false, false)
                let result = await myBase.blueSoftApi.api_get('/forca-de-vendas/tabelas-preco-venda?currentPage=0')
                let sqlInsert : string = ``

                let i = 0
                let max = 3

                for await (const item of result.data.data as any[]) {


                    sqlInsert += await this.getSqlInsertTabelaPreco(item)
                    sqlInsert += await this.getSqlUpdateTabelaPrecoVersao(item)
                    if (item?.produtos) {
                        sqlInsert += await this.getSqlInsertTabelaPrecoProdutoBluesoft(item, item?.tabelaPrecoVendaKey)
                    }
                    if (i >= max) {
                        await myBase.myDataBase.pag.Execute(sqlInsert)
                        sqlInsert = ``
                        i = 0
                    }
                    i++ 
                }


                
                if (sqlInsert) {
                    await myBase.myDataBase.pag.Execute(sqlInsert)
                }

                
                

        } catch (e) {
            clsTools.PagErrorException(`m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto `, "start", e)
            throw new Error(`modules | m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto.start | Error ${e}`);
        }
    }

    static async getSqlInsertTabelaPreco(dadosApi : any) : Promise<string> { 
        try { 
            let itemTabelaPreco = new modelforca_venda_tabpreco()
            itemTabelaPreco.apiBluesoftGet(dadosApi)
            return itemTabelaPreco.sqlPrimeInsert()


        } catch (e) {
            clsTools.PagErrorException(`m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto `, "start", e)
            throw new Error(`modules | m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto.getSqlInsertTabelaPreco | Error ${e}`);
        }
    }

    static async getSqlUpdateTabelaPrecoVersao(dadosApi : any) : Promise<string> {
        try { 

            let itemTabelaPrecoVersao = new modelforca_venda_tabprecoVersao()
            itemTabelaPrecoVersao.apiBluesoftGet(dadosApi)
            return itemTabelaPrecoVersao.sqlPrimeInsert()

        } catch (e) {
            clsTools.PagErrorException(`m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto `, "start", e)
            throw new Error(`modules | m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto.getSqlUpdateTabelaPrecoVersao | Error ${e}`);
        }
    
    }

    static async getSqlInsertTabelaPrecoProdutoBluesoft(dadosApi : any, tabelaPrecoVendaKey : any) : Promise<string> {
        try { 

            let sqlinsertItem : string = ``

            for await (const item of dadosApi?.produtos as any[]) {
                let itemTabelaPrecoProdutoBluesoft = new modelforca_venda_tabprecoProdutoBluesoft()
                itemTabelaPrecoProdutoBluesoft.apiBluesoftGet(item, tabelaPrecoVendaKey)
                sqlinsertItem += itemTabelaPrecoProdutoBluesoft.sqlPrimeInsert()
            }
            return sqlinsertItem

        } catch (e) {
            clsTools.PagErrorException(`m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto `, "start", e)
            throw new Error(`modules | m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto.getSqlInsertTabelaPrecoProdutoBluesoft | Error ${e}`);
        }
    
    }

}


class serviceForcaVendaImportTabelaPrecoRedshift {
    static sqlRedShiftTabelaPreco() : string { 
        let sql = `` 
        sql = `SELECT tabela_preco_venda_key 
                ,     descricao 
                from tabela_preco_venda

        `
        return sql 

    }

    static sqlRedShiftTabelaPrecoVersao() : string {
        let sql = `
                    SELECT  tabela_preco_venda_versao_key 
                        ,   tabela_preco_venda_key 
                        ,   versao 
                        ,   desconto_maximo 
                        ,   desconto_padrao 
                        ,   acrescimo_maximo
                        ,   publicada 
                        ,   coalesce(data_inicio_vigencia, '1900-01-01 01:01:01') as data_inicio_vigencia
                        ,   coalesce(data_fim_vigencia, '1900-01-01 01:01:01') as data_fim_vigencia      
                    from tabela_preco_venda_versao
                    where 1 = 1
                      and coalesce(data_inicio_vigencia, '1900-01-01 01:01:01') >= current_date - interval '10 day'

        `

        return sql

    }

    static sqlRedShiftTabelaPrecoProduto() : string {
        let sql = `
        select      i.tabela_preco_venda_item_key 
                ,   coalesce(v.versao, 0) as versao
                ,   coalesce(i.produto_key, 0) as produto_key
                ,   coalesce(i.desconto_maximo,0) as desconto_maximo
                ,   coalesce(i.desconto_padrao,0) as desconto_padrao
                ,   coalesce(i.quantidade_minima,0) as quantidade_minima
                ,   coalesce(i.quantidade_maxima,0) as quantidade_maxima
                ,   coalesce(i.preco,0) as preco
                ,   coalesce(v.tabela_preco_venda_key, 0) as tabela_preco_venda_key
            from tabela_preco_venda_item i 
            inner join tabela_preco_venda_versao v on v.tabela_preco_venda_versao_key = i.tabela_preco_venda_versao_key
            where 1= 1
            and coalesce(v.versao, 0) > 0 
            and coalesce(i.produto_key, 0) > 0 
            and coalesce(v.tabela_preco_venda_key, 0) > 0 
            and coalesce(data_inicio_vigencia, '1900-01-01 01:01:01') >= current_date - interval '10 day'

        `
        return sql
        
    }
    
    static async start() { 
        try { 

                let i : number = 0
                let imax : number = 3
                let bloq : number = 1
                let sql = ``

                clsTools.pagConsole(`Iniciando Importação Tabela Preço Força de Venda`, false, false)
                let resultTabela = await myBase.myDataBase.redshift.DataGet(this.sqlRedShiftTabelaPreco())
                
                for await (const item of resultTabela as any[]) {
                    let itemTabelaPreco = new modelforca_venda_tabpreco()
                    itemTabelaPreco.redshiftGet(item)
                    sql += itemTabelaPreco.sqlPrimeInsert()

                }




                clsTools.pagConsole(`Importação Tabela Preço Força de Venda - Tabela/Versão`, false, false)

                let resultVersao = await myBase.myDataBase.redshift.DataGet(this.sqlRedShiftTabelaPrecoVersao())


                for await (const item of resultVersao as any[]) {
                    let itemTabelaPrecoVersao = new modelforca_venda_tabprecoVersao()
                    itemTabelaPrecoVersao.redshiftGet(item)
                    sql += itemTabelaPrecoVersao.sqlPrimeInsert()
                }

                /*  Todas as tabelas e versões são inseridas 
                    no banco de dados por meio de apenas um processo 
                */
                if (sql) {
                    await myBase.myDataBase.pag.Execute(sql)
                }


                /* Inserindo os itens no banco de dados por meio de blocos */


                let resultproduto = await myBase.myDataBase.redshift.DataGet(this.sqlRedShiftTabelaPrecoProduto())


                sql = ``
                i = 0
                imax  = 300

                for await (const item of resultproduto as any[]) {
                    let itemTabelaPrecoProdutoBluesoft = new modelforca_venda_tabprecoProdutoBluesoft()
                    itemTabelaPrecoProdutoBluesoft.redshiftGet(item)
                    sql += itemTabelaPrecoProdutoBluesoft.sqlPrimeInsert()

                    if (i >= imax) {
                        clsTools.pagConsole(`m0104_ForcaVenda | service | serviceForcaVendaImport- Tabela Preço Redshift Bloco ${bloq} `, false, true )
                        await myBase.myDataBase.pag.Execute(sql)
                        sql = ``
                        i = 0
                        bloq++
                    }
                    i++
                }

                if (sql) {
                    await myBase.myDataBase.pag.Execute(sql)
                }


        } catch (e) {
            await clsTools.PagErrorException(`M0104 - serviceForcaVendaImportTabelaPrecoRedshift `, "start", e)
            throw new Error(`M0104 - serviceForcaVendaImportTabelaPrecoRedshift.start | Error ${e}`);
        }
    }

  

}

export default class serviceForcaVendaImportTabelaPreco {

    static async start() { 
        try { 

                
                await serviceForcaVendaImportTabelaPrecoRedshift.start()
                await ForcaVendaImportTabelaPrecoApi.start()



        } catch (e) {
            await clsTools.PagErrorException(`M0104 - serviceForcaVendaImportTabelaPreco `, "start", e)
            throw new Error(`M0104 - serviceForcaVendaImportTabelaPreco.start | Error ${e}`);
        }
    }


}