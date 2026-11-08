"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const tbforca_tabelaPrecoProdutoBluesoft_1 = __importDefault(require("../tbs/tbforca_tabelaPrecoProdutoBluesoft"));
class modelforca_venda_tabprecoProdutoBluesoft extends tbforca_tabelaPrecoProdutoBluesoft_1.default {
    constructor() {
        super();
    }
    apiBluesoftGet(item, fv_tabelapreco_cd) {
        try {
            this.fv_tabelapreco_cd = fv_tabelapreco_cd;
            this.fv_tabelapreco_prod_seq_blue = item === null || item === void 0 ? void 0 : item.tabelaPrecoVendaItemKey;
            this.prb_cdprodutobluesoft = item === null || item === void 0 ? void 0 : item.produtoKey;
            this.precoEmbalagem = item === null || item === void 0 ? void 0 : item.precoEmbalagem;
            this.precoUnitario = item === null || item === void 0 ? void 0 : item.precoUnitario;
            this.descontoMaximo = (item === null || item === void 0 ? void 0 : item.descontoMaximo) && (item === null || item === void 0 ? void 0 : item.descontoMaximo) != undefined ? item === null || item === void 0 ? void 0 : item.descontoMaximo : 0;
            this.descontoPadrao = (item === null || item === void 0 ? void 0 : item.descontoPadrao) && (item === null || item === void 0 ? void 0 : item.descontoPadrao) != undefined ? item === null || item === void 0 ? void 0 : item.descontoPadrao : 0;
            this.acrescimoMaximo = (item === null || item === void 0 ? void 0 : item.acrescimoMaximo) && (item === null || item === void 0 ? void 0 : item.acrescimoMaximo) != undefined ? item === null || item === void 0 ? void 0 : item.acrescimoMaximo : 0;
            this.fatorPreco = (item === null || item === void 0 ? void 0 : item.fatorPreco) && (item === null || item === void 0 ? void 0 : item.fatorPreco) != undefined ? item === null || item === void 0 ? void 0 : item.fatorPreco : 1;
            this.fatorEstoque = (item === null || item === void 0 ? void 0 : item.fatorEstoque) && (item === null || item === void 0 ? void 0 : item.fatorEstoque) != undefined ? item === null || item === void 0 ? void 0 : item.fatorEstoque : 1;
            this.versao = (item === null || item === void 0 ? void 0 : item.versao) && (item === null || item === void 0 ? void 0 : item.versao) != undefined ? item === null || item === void 0 ? void 0 : item.versao : 0;
            this.precoPromocional = (item === null || item === void 0 ? void 0 : item.precoPromocional) && (item === null || item === void 0 ? void 0 : item.precoPromocional) != undefined ? item === null || item === void 0 ? void 0 : item.precoPromocional : 0;
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
            this.fv_tabelapreco_prod_seq_blue = item === null || item === void 0 ? void 0 : item.tabela_preco_venda_item_key;
            this.prb_cdprodutobluesoft = item === null || item === void 0 ? void 0 : item.produto_key;
            this.precoEmbalagem = (item === null || item === void 0 ? void 0 : item.preco) != undefined ? item === null || item === void 0 ? void 0 : item.preco : 0;
            this.precoUnitario = (item === null || item === void 0 ? void 0 : item.preco) != undefined ? item === null || item === void 0 ? void 0 : item.preco : 0;
            this.descontoMaximo = item === null || item === void 0 ? void 0 : item.desconto_maximo;
            this.descontoPadrao = item === null || item === void 0 ? void 0 : item.desconto_padrao;
        }
        catch (e) {
            modelbase_1.clsTools.pagConsole(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | redshiftGet | Error \n ${e}`, false, false, 'modelforca_venda_pgtos');
            throw new Error(`modules | m0104_ForcaVenda | model | modelforca_venda_pgtos | redshiftGet | Error ${e}`);
        }
    }
    sqlPrimeInsert() {
        let sql = ``;
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
exports.default = modelforca_venda_tabprecoProdutoBluesoft;
