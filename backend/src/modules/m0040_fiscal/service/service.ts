


import serviceFiguraFiscalRegraFiscal from "./serviceFiscal.ImportarFigura";
import serviceAtualizarFiguraFiscalPorProdutoUnitario from "./serviceFiscal.ImportarFiguraProduto";
import serviceFiscalImportarRegraNfceProduto from "./serviceFiscal.ImportarRegraFiscalNFCEProduto";
import serviceFiscal_AtualizaMapeamentoFiscal from "./serviceFiscal.AtualizaMapeamentoFiscal";
import serviceFiscal_Cbenef_AtualizarProdutoPag from "./serviceFiscal.Cbenef.AtualizarProdutoPag";
import serviceFiscal_Cbenef_ImportarBluesoft from "./serviceFiscal.Cbenef.ImportarBluesoft";
import serviceFiscal_Cbenef_ExportarProdutoBluesoft from "./serviceFiscal.Cbenef.ExportarProdutoBluesoft";
import serviceFiscalImportarCofins from "./serviceFiscal.ImportarCofins";
import serviceFiscalImportarPis from "./serviceFiscal.ImportarPis";
import serviceFiscalImportarRegraNfeProduto from "./serviceFiscal.ImportarRegraFiscalNFEProduto";

export default class serviceFiscal { 
    static FiguraFiscalRegraFiscal = serviceFiguraFiscalRegraFiscal;
    static FiguraFiscalPorProdutoUnitario = serviceAtualizarFiguraFiscalPorProdutoUnitario;
    static FiguraFiscalPorProdutoNfce = serviceFiscalImportarRegraNfceProduto;
    static FiguraFiscalPorProdutoNfe = serviceFiscalImportarRegraNfeProduto;
    static atualizaMapeamentoFiscal = serviceFiscal_AtualizaMapeamentoFiscal;
    static cbenefAtualizarProdutoPag = serviceFiscal_Cbenef_AtualizarProdutoPag;
    static cbenefImportarBluesoft = serviceFiscal_Cbenef_ImportarBluesoft;
    static cbenefExportarProdutoBluesoft = serviceFiscal_Cbenef_ExportarProdutoBluesoft;
    static Pis = serviceFiscalImportarPis;
    static Cofins = serviceFiscalImportarCofins;

}

