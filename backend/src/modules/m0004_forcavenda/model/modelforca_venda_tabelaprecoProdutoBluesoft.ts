import { clsTools, clsBase } from "../../../model/modelbase";
import tbforca_venda_tabprecoProdutoBluesoft from "../tbs/tbforca_tabelaPrecoProdutoBluesoft"; 

export default class modelforca_venda_tabprecoProdutoBluesoft extends tbforca_venda_tabprecoProdutoBluesoft {
    
    constructor() {
        super()
    }

    apiBluesoftGet(item : any, fv_tabelapreco_cd: number) { 
        try {
            this.fv_tabelapreco_cd = fv_tabelapreco_cd
            this.fv_tabelapreco_prod_seq_blue = item?.tabelaPrecoVendaItemKey
            this.prb_cdprodutobluesoft = item?.produtoKey
            this.precoEmbalagem = item?.precoEmbalagem
            this.precoUnitario = item?.precoUnitario
            this.descontoMaximo = item?.descontoMaximo && item?.descontoMaximo != undefined ? item?.descontoMaximo : 0
            this.descontoPadrao = item?.descontoPadrao && item?.descontoPadrao != undefined ? item?.descontoPadrao : 0
            this.acrescimoMaximo = item?.acrescimoMaximo && item?.acrescimoMaximo != undefined ? item?.acrescimoMaximo : 0
            this.fatorPreco = item?.fatorPreco && item?.fatorPreco != undefined ? item?.fatorPreco : 1
            this.fatorEstoque = item?.fatorEstoque && item?.fatorEstoque != undefined ? item?.fatorEstoque : 1
            this.versao = item?.versao && item?.versao != undefined ? item?.versao : 0
            this.precoPromocional = item?.precoPromocional && item?.precoPromocional != undefined ? item?.precoPromocional : 0

        } catch (e) {
            clsTools.pagConsole(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | apiBluesoftGet | Error \n ${e}`, false, false, 'modelforca_venda_pgtos')
            throw new Error(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | apiBluesoftGet | Error ${e}`);
        }
    }

    redshiftGet(item : any) { 
        try {
            this.fv_tabelapreco_cd = item?.tabela_preco_venda_key 
            this.versao = item?.versao 
            this.fv_tabelapreco_prod_seq_blue = item?.tabela_preco_venda_item_key
            this.prb_cdprodutobluesoft = item?.produto_key 
            this.precoEmbalagem = item?.preco != undefined ? item?.preco : 0
            this.precoUnitario = item?.preco != undefined ? item?.preco : 0
            this.descontoMaximo = item?.desconto_maximo
            this.descontoPadrao = item?.desconto_padrao

        } catch (e) {
            clsTools.pagConsole(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | redshiftGet | Error \n ${e}`, false, false, 'modelforca_venda_pgtos')
            throw new Error(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | redshiftGet | Error ${e}`);
        }
    }

    sqlPrimeInsert(): string {
        let sql = ``
        try { 

            sql = `insert into tbforca_venda_tabprecoprodutobluesoft 
                    (       fv_tabelapreco_cd
                        ,   fv_tabelapreco_prod_seq_blue
                        ,   prb_cdprodutobluesoft
                        ,   precoEmbalagem
                        ,   precoUnitario
                        ,   descontoMaximo
                        ,   descontoPadrao
                        ,   acrescimoMaximo
                        ,   fatorPreco
                        ,   fatorEstoque
                        ,   versao
                        ,   precoPromocional
                    )
            select  ${this.fv_tabelapreco_cd}
                 , ${this.fv_tabelapreco_prod_seq_blue}
                 , ${this.prb_cdprodutobluesoft}
                 , ${this.precoEmbalagem}
                 , ${this.precoUnitario}
                 , ${this.descontoMaximo}
                 , ${this.descontoPadrao}
                 , ${this.acrescimoMaximo}
                 , ${this.fatorPreco}
                 , ${this.fatorEstoque}
                 , ${this.versao}
                 , ${this.precoPromocional}

            
                 where not exists ( select 1 from 
                                    tbforca_venda_tabprecoprodutobluesoft 
                                    where fv_tabelapreco_cd = ${this.fv_tabelapreco_cd} 
                                    and   fv_tabelapreco_prod_seq_blue = ${this.fv_tabelapreco_prod_seq_blue} 
                                    and   prb_cdprodutobluesoft = ${this.prb_cdprodutobluesoft})
                ;

                update tbforca_venda_tabprecoprodutobluesoft
                set precoEmbalagem = ${this.precoEmbalagem}
                    , precoUnitario = ${this.precoUnitario}

                where fv_tabelapreco_cd = ${this.fv_tabelapreco_cd}
                and   versao = ${this.versao}
                and   prb_cdprodutobluesoft = ${this.prb_cdprodutobluesoft}
                ;
            `
            

        } catch (e) {
            clsTools.pagConsole(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | sqlPrimeInsert | Error \n ${e}`, false, false, 'modelforca_venda_pgtos')
            throw new Error(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | sqlPrimeInsert | Error ${e}`);
        }
        finally {
            return sql
        }
        
    }

}