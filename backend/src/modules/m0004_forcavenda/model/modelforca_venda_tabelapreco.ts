import { clsTools, clsBase } from "../../../model/modelbase";
import tbforca_venda_tabpreco from "../tbs/tbforca_tabelapreco";

export default class modelforca_venda_tabpreco extends tbforca_venda_tabpreco {
    
    constructor() {
        super()
    }

    apiBluesoftGet(item : any) { 
        try {
            this.fv_tabelapreco_cd = item?.tabelaPrecoVendaKey
            this.fv_tabelapreco_descricao = item?.descricao


        } catch (e) {
            clsTools.pagConsole(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | apiBluesoftGet | Error \n ${e}`, false, false, 'modelforca_venda_pgtos')
            throw new Error(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | apiBluesoftGet | Error ${e}`);
        }
    }

    redshiftGet(item : any) { 
        try {
            this.fv_tabelapreco_cd = item?.tabela_preco_venda_key
            this.fv_tabelapreco_descricao = item?.descricao
        } catch (e) {
            clsTools.pagConsole(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | redshiftGet | Error \n ${e}`, false, false, 'modelforca_venda_pgtos')
            throw new Error(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | redshiftGet | Error ${e}`);
        }
    }

    sqlPrimeInsert(): string {
        let sql = ``
        try { 

            sql = `insert into tbforca_venda_tabpreco (fv_tabelapreco_cd, fv_tabelapreco_descricao) 
            select  ${this.fv_tabelapreco_cd}
                 , '${this.fv_tabelapreco_descricao}'
            
                 where not exists (select 1 from tbforca_venda_tabpreco where fv_tabelapreco_cd = ${this.fv_tabelapreco_cd})

                 ;

                 update tbforca_venda_tabpreco 
                 set    fv_tabelapreco_descricao = '${this.fv_tabelapreco_descricao}'
                    ,   dtlog_update = current_timestamp
                 where fv_tabelapreco_cd = ${this.fv_tabelapreco_cd}
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