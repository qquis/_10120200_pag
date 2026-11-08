


import reportForcaVendaPrazoPgto from "./rerpot.forcaVenda.PrazoPgto";
import reportForcaVendaTabela from "./rerpot.forcaVenda.tabela";
import reportForcaVendaTabelaVersao from "./rerpot.forcaVenda.tabelaVersao";
import reportForcaVendaTabelaProduto from "./rerpot.forcaVenda.tabelaVersaoProduto";
import reportForcaVendaTabelaPadrao from "./rerpot.forcaVenda.tabelaPadrao";
import reportForcaVendaFabricante from "./report.forcavenda.fabricante";


export default class reportForcaVenda {
    static prazopgto = reportForcaVendaPrazoPgto
    static tabela = reportForcaVendaTabela
    static tabelaVersao = reportForcaVendaTabelaVersao
    static tabelaProduto = reportForcaVendaTabelaProduto
    static tabelaPadrao = reportForcaVendaTabelaPadrao
    static fabricanteFv = reportForcaVendaFabricante
}

