import { clsTools, clsBase } from "../../../model/modelbase";
import tbforca_venda_tabprecoVersao from "../tbs/tbforca_tabelaprecoVersao";

export default class modelforca_venda_tabprecoVersao extends tbforca_venda_tabprecoVersao {
    
    constructor() {
        super()
    }

    apiBluesoftGet(item : any) { 
        try {
            this.fv_tabelapreco_cd = item?.tabelaPrecoVendaKey
            this.versao = item?.versao
            this.descontomaximo = item?.descontoMaximo
            this.descontopadrao = item?.descontoPadrao
            this.acrescimomaximo = item?.acrescimoMaximo
            this.datainiciovigencia = clsTools._datemomentDatStrToDate(item?.dataInicioVigencia? item?.dataInicioVigencia : "01/01/1900 01:01", 'DD/MM/YYYY HH:mm')
            this.datafimvigencia = clsTools._datemomentDatStrToDate(item?.dataFimVigencia? item?.dataFimVigencia : "31/12/2050 01:01", 'DD/MM/YYYY HH:mm')
            this.ativo = item?.ativo? 1 : 0
            this.tabelareferencia = item?.tabelaReferencia ? item?.tabelaReferencia? 1: 0 : 0
            this.publicada = 1

        } catch (e) {
            clsTools.pagConsole(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | apiBluesoftGet | Error \n ${e}`, false, false, 'modelforca_venda_pgtos')
            throw new Error(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | apiBluesoftGet | Error ${e}`);
        }
    }

    redshiftGet(item: any) {
        try { 

            this.fv_tabelapreco_cd = item?.tabela_preco_venda_key  
            this.versao = item?.versao
            this.descontomaximo = item?.desconto_maximo
            this.descontopadrao = item?.desconto_padrao
            this.acrescimomaximo = item?.acrescimo_maximo
            this.datainiciovigencia = clsTools._datemomentDatStrToDate(item?.data_inicio_vigencia? item?.data_inicio_vigencia : "1900-01-01 01:01", 'YYYY-MM-DD HH:mm')
            this.datafimvigencia = clsTools._datemomentDatStrToDate(item?.data_fim_vigencia? item?.data_fim_vigencia : "2050-12-31 01:01", 'YYYY-MM-DD HH:mm')
            this.publicada = item?.publicada? 1 : 0



        } catch (e) { 
            clsTools.pagConsole(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | redshiftGet | Error \n ${e}`, false, false, 'modelforca_venda_pgtos')
        }
    }

    sqlPrimeInsert(): string {
        let sql = ``
        try { 

            sql = `insert into tbforca_venda_tabpreco_versao 
                    (       fv_tabelapreco_cd
                        ,   versao
                        ,   descontomaximo
                        ,   descontopadrao
                        ,   acrescimomaximo
                        ,   datainiciovigencia
                        ,   datafimvigencia
                        ,   ativo
                        ,   tabelareferencia
                        ,   publicada
                    ) 
            select  ${this.fv_tabelapreco_cd}
                 ,  ${this.versao}
                 ,  ${this.descontomaximo? this.descontomaximo : 0}
                 ,  ${this.descontopadrao? this.descontopadrao : 0}
                 ,  ${this.acrescimomaximo? this.acrescimomaximo : 0}
                 , '${this.datainiciovigencia !== undefined ? clsTools._datemomentDateToStr(this.datainiciovigencia, 'YYYY-MM-DD HH:mm') : "1900-01-01 00:00"}'
                 , '${this.datafimvigencia !== undefined ? clsTools._datemomentDateToStr(this.datafimvigencia, 'YYYY-MM-DD HH:mm') : "1900-01-01 00:00"}'
                 ,  ${this.ativo}
                 , ${this.tabelareferencia}
                 , ${this.publicada}
            
                 where not exists ( select 1 
                                    from tbforca_venda_tabpreco_versao 
                                    where fv_tabelapreco_cd = ${this.fv_tabelapreco_cd}
                                      and versao = ${this.versao}        
                            )

                 ;

                 update tbforca_venda_tabpreco_versao
                  set
                      datainiciovigencia = '${this.datainiciovigencia !== undefined ? clsTools._datemomentDateToStr(this.datainiciovigencia, 'YYYY-MM-DD HH:mm') : "1900-01-01 00:00"   }'    
                    , datafimvigencia = '${this.datafimvigencia !== undefined ? clsTools._datemomentDateToStr(this.datafimvigencia, 'YYYY-MM-DD HH:mm') : "1900-01-01 00:00"}'
                    , ativo = ${this.ativo}
                    , descontomaximo = ${this.descontomaximo? this.descontomaximo : 0}
                    , descontopadrao = ${this.descontopadrao? this.descontopadrao : 0}
                    , acrescimomaximo = ${this.acrescimomaximo? this.acrescimomaximo : 0}
                    , tabelareferencia = ${this.tabelareferencia}     
                    , publicada = ${this.publicada}
                    where fv_tabelapreco_cd = ${this.fv_tabelapreco_cd}
                        and versao = ${this.versao}      
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