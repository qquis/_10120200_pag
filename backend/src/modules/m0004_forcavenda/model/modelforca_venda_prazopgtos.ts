import { clsTools, clsBase } from "../../../model/modelbase";
import tbforca_venda_prazopgto from "../tbs/tbforca_venda_prazopgto";

export default class modelforca_venda_prazopgto extends tbforca_venda_prazopgto {
    
    constructor() {
        super()
    }

    apiBluesoftGet(item : any) { 
        try {
            this.fv_prazopgto_cd = item?.prazoPagamentoFvKey
            this.fv_prazopgto_descricao = item?.descricao
            this.custofinanceiro = item?.custoFinanceiro
            this.coefcustofinanceiro = item?.coefCustoFinanceiro
            this.tipo = item?.tipo
            this.tipocusto = item?.tipoCusto
            this.status = item?.status? 1 : 0
            this.versao = item?.versao
            

        } catch (e) {
            clsTools.pagConsole(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | apiBluesoftGet | Error \n ${e}`, false, false, 'modelforca_venda_pgtos')
            throw new Error(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | apiBluesoftGet | Error ${e}`);
        }
    }

    sqlPrimeInsert(): string {
        let sql = ``
        try { 

            sql = `insert into tbforca_venda_prazopgto (fv_prazopgto_cd, fv_prazopgto_descricao, custofinanceiro, coefcustofinanceiro, tipo, tipocusto, status, versao) 
            select  ${this.fv_prazopgto_cd}
                 , '${this.fv_prazopgto_descricao}'
                 ,  ${this.custofinanceiro}
                 ,  ${this.coefcustofinanceiro}
                 , '${this.tipo}'
                 , '${this.tipocusto}'
                 ,  ${this.status}
                 ,  ${this.versao}
            
                 where not exists (select 1 from tbforca_venda_prazopgto where fv_prazopgto_cd = ${this.fv_prazopgto_cd})

                 ;

                 update tbforca_venda_prazopgto set
                    fv_prazopgto_descricao = '${this.fv_prazopgto_descricao}'
                    , custofinanceiro = ${this.custofinanceiro}
                    , coefcustofinanceiro = ${this.coefcustofinanceiro}
                    , tipo = '${this.tipo}'
                    , tipocusto = '${this.tipocusto}'
                    , status = ${this.status}
                    , versao = ${this.versao}

                where fv_prazopgto_cd = ${this.fv_prazopgto_cd}
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