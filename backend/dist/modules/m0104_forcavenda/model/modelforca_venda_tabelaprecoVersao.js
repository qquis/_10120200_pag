"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const tbforca_tabelaprecoVersao_1 = __importDefault(require("../tbs/tbforca_tabelaprecoVersao"));
class modelforca_venda_tabprecoVersao extends tbforca_tabelaprecoVersao_1.default {
    constructor() {
        super();
    }
    apiBluesoftGet(item) {
        try {
            this.fv_tabelapreco_cd = item === null || item === void 0 ? void 0 : item.tabelaPrecoVendaKey;
            this.versao = item === null || item === void 0 ? void 0 : item.versao;
            this.descontomaximo = item === null || item === void 0 ? void 0 : item.descontoMaximo;
            this.descontopadrao = item === null || item === void 0 ? void 0 : item.descontoPadrao;
            this.acrescimomaximo = item === null || item === void 0 ? void 0 : item.acrescimoMaximo;
            this.datainiciovigencia = modelbase_1.clsTools._datemomentDatStrToDate((item === null || item === void 0 ? void 0 : item.dataInicioVigencia) ? item === null || item === void 0 ? void 0 : item.dataInicioVigencia : "01/01/1900 01:01", 'DD/MM/YYYY HH:mm');
            this.datafimvigencia = modelbase_1.clsTools._datemomentDatStrToDate((item === null || item === void 0 ? void 0 : item.dataFimVigencia) ? item === null || item === void 0 ? void 0 : item.dataFimVigencia : "31/12/2050 01:01", 'DD/MM/YYYY HH:mm');
            this.ativo = (item === null || item === void 0 ? void 0 : item.ativo) ? 1 : 0;
            this.tabelareferencia = (item === null || item === void 0 ? void 0 : item.tabelaReferencia) ? (item === null || item === void 0 ? void 0 : item.tabelaReferencia) ? 1 : 0 : 0;
            this.publicada = 1;
        }
        catch (e) {
            modelbase_1.clsTools.pagConsole(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | apiBluesoftGet | Error \n ${e}`, false, false, 'modelforca_venda_pgtos');
            throw new Error(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | apiBluesoftGet | Error ${e}`);
        }
    }
    redshiftGet(item) {
        try {
            this.fv_tabelapreco_cd = item === null || item === void 0 ? void 0 : item.tabela_preco_venda_key;
            this.versao = item === null || item === void 0 ? void 0 : item.versao;
            this.descontomaximo = item === null || item === void 0 ? void 0 : item.desconto_maximo;
            this.descontopadrao = item === null || item === void 0 ? void 0 : item.desconto_padrao;
            this.acrescimomaximo = item === null || item === void 0 ? void 0 : item.acrescimo_maximo;
            this.datainiciovigencia = modelbase_1.clsTools._datemomentDatStrToDate((item === null || item === void 0 ? void 0 : item.data_inicio_vigencia) ? item === null || item === void 0 ? void 0 : item.data_inicio_vigencia : "1900-01-01 01:01", 'YYYY-MM-DD HH:mm');
            this.datafimvigencia = modelbase_1.clsTools._datemomentDatStrToDate((item === null || item === void 0 ? void 0 : item.data_fim_vigencia) ? item === null || item === void 0 ? void 0 : item.data_fim_vigencia : "2050-12-31 01:01", 'YYYY-MM-DD HH:mm');
            this.publicada = (item === null || item === void 0 ? void 0 : item.publicada) ? 1 : 0;
        }
        catch (e) {
            modelbase_1.clsTools.pagConsole(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | redshiftGet | Error \n ${e}`, false, false, 'modelforca_venda_pgtos');
        }
    }
    sqlPrimeInsert() {
        let sql = ``;
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
                 ,  ${this.descontomaximo ? this.descontomaximo : 0}
                 ,  ${this.descontopadrao ? this.descontopadrao : 0}
                 ,  ${this.acrescimomaximo ? this.acrescimomaximo : 0}
                 , '${this.datainiciovigencia !== undefined ? modelbase_1.clsTools._datemomentDateToStr(this.datainiciovigencia, 'YYYY-MM-DD HH:mm') : "1900-01-01 00:00"}'
                 , '${this.datafimvigencia !== undefined ? modelbase_1.clsTools._datemomentDateToStr(this.datafimvigencia, 'YYYY-MM-DD HH:mm') : "1900-01-01 00:00"}'
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
                      datainiciovigencia = '${this.datainiciovigencia !== undefined ? modelbase_1.clsTools._datemomentDateToStr(this.datainiciovigencia, 'YYYY-MM-DD HH:mm') : "1900-01-01 00:00"}'    
                    , datafimvigencia = '${this.datafimvigencia !== undefined ? modelbase_1.clsTools._datemomentDateToStr(this.datafimvigencia, 'YYYY-MM-DD HH:mm') : "1900-01-01 00:00"}'
                    , ativo = ${this.ativo}
                    , descontomaximo = ${this.descontomaximo ? this.descontomaximo : 0}
                    , descontopadrao = ${this.descontopadrao ? this.descontopadrao : 0}
                    , acrescimomaximo = ${this.acrescimomaximo ? this.acrescimomaximo : 0}
                    , tabelareferencia = ${this.tabelareferencia}     
                    , publicada = ${this.publicada}
                    where fv_tabelapreco_cd = ${this.fv_tabelapreco_cd}
                        and versao = ${this.versao}      
                ;         
            `;
        }
        catch (e) {
            modelbase_1.clsTools.pagConsole(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | sqlPrimeInsert | Error \n ${e}`, false, false, 'modelforca_venda_pgtos');
            throw new Error(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | sqlPrimeInsert | Error ${e}`);
        }
        finally {
            return sql;
        }
    }
}
exports.default = modelforca_venda_tabprecoVersao;
