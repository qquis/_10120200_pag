
import reportFiguraFiscalProduto from './reportFiguraFiscalProduto';
import reportFiguraFiscalProdutoNfce from './reportFiguraFiscalProdutoNfce';
import reportFiguraFiscal from './reportFiguraFiscal';
import reportCbenefProduto from './reportCbenefProduto';
import reportCbenef from './reportCbenef';
import reportCbenefCst from './reportCbenefcst';
import reportFiscalZanthusTributacaoIcmsPdv from './report.Zanthus.TributacaoIcmsPdv';

export default class reportFiscal { 
    static figuraFiscalProduto = reportFiguraFiscalProduto
    static figuraFiscalProdutoNfce = reportFiguraFiscalProdutoNfce
    static figuraFiscal = reportFiguraFiscal
    static cbenefProduto = reportCbenefProduto
    static cbenef = reportCbenef
    static cbenefCst = reportCbenefCst
    static ZanthusTributacaoIcmsPdv = reportFiscalZanthusTributacaoIcmsPdv
}

