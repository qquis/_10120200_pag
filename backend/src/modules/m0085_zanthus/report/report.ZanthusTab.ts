import { clsTools, clsBase } from "../../../model/modelbase";

/*TABS*/
import tbZanthusTabMercadoria from "../tbs/tbZanthusTabMercadoria";
import tbZanthusTabMercadoriaTipoVenda from "../tbs/tbZanthusTabMercadoriaTipoVenda";
import tbZanthusTabMercadoriaTipoVendaQtde from "../tbs/tbZanthusTabMercadoriaTipoVendaQtde";
import tbZanthusTabRegrasIcms from "../tbs/tbZanthusTabRegraIcms";

/*PRODUTO DECOMPOSICAO*/
import reportZanthusTabMercadoria_Select from "./report.ZanthusTabMercadoria_Select";
import reportZanthusTabMercadoriaTipoVenda_Select from "./report.ZanthusTabMercadoriaTipoVenda_Select";
import reportZanthusTabRegrasIcms_Select from "./report.ZanthusTabRegrasIcms_Select";
import reportZanthusTabMercadoriaTipoVendaQtde_Select from "./report.ZanthusTabMercadoriaTipoVendaQtde_Select";
import reportZanthusTabProdutoDecomposicao_Select from "./report.ZanthusTabProdutoDecomposicao";
import reportZanthusTabProdutoDecomposicaoInsum_Select from "./report.ZanthusTabProdutoDecomposicaoInsum";

import reportZanthusType from "./ReportFilterType";

import tbZanthusTabProdutoDecomposicao from "../tbs/tbZanthusTabProdutoDecomposicao";
import tbZanthusTabProdutoDecomposicaoInsum from "../tbs/tbZanthusTabProdutoDecomposicaoInsum";


export default class reportZanthusProduto {
    listTabMercadoria : tbZanthusTabMercadoria[]
    listTabRegrasIcms : tbZanthusTabRegrasIcms[]
    listTabMercadoriaTipoVenda : tbZanthusTabMercadoriaTipoVenda[]
    listTabMercadoriaTipoVendaQtde : tbZanthusTabMercadoriaTipoVendaQtde[]
    listTabProdutoDecomposicao : tbZanthusTabProdutoDecomposicao[]
    listTabProdutoDecomposicaoInsum: tbZanthusTabProdutoDecomposicaoInsum[]
    constructor () {


        this.listTabMercadoria = [];
        this.listTabMercadoriaTipoVenda = []
        this.listTabRegrasIcms = []
        this.listTabMercadoriaTipoVendaQtde = []
        this.listTabProdutoDecomposicao = []
        this.listTabProdutoDecomposicaoInsum = []
   
    }

    async Select(filter : reportZanthusType) : Promise<void> {

        let myreportZanthusTabMercadoria_Select : reportZanthusTabMercadoria_Select = new reportZanthusTabMercadoria_Select(filter)
        let myreportZanthusTabMercadoriaTipoVenda_Select : reportZanthusTabMercadoriaTipoVenda_Select = new reportZanthusTabMercadoriaTipoVenda_Select(filter)
        let myreportZanthusTabRegrasIcms_Select : reportZanthusTabRegrasIcms_Select = new reportZanthusTabRegrasIcms_Select(filter)
        let myreportZanthusTabMercadoriaTipoVendaQtde_Select : reportZanthusTabMercadoriaTipoVendaQtde_Select = new reportZanthusTabMercadoriaTipoVendaQtde_Select(filter)
        let myreportZanthusTabProdutoDecomposicao_Select : reportZanthusTabProdutoDecomposicao_Select = new reportZanthusTabProdutoDecomposicao_Select(filter);
        let myreportZanthusTabProdutoDecomposicaoInsum_Select : reportZanthusTabProdutoDecomposicaoInsum_Select = new reportZanthusTabProdutoDecomposicaoInsum_Select(filter);
        try {
            
            this.listTabMercadoria = await myreportZanthusTabMercadoria_Select.tblist_Get()
            this.listTabMercadoriaTipoVenda = await myreportZanthusTabMercadoriaTipoVenda_Select.tblist_Get()
            this.listTabRegrasIcms = await myreportZanthusTabRegrasIcms_Select.tblist_Get()
            this.listTabMercadoriaTipoVendaQtde = await myreportZanthusTabMercadoriaTipoVendaQtde_Select.tblist_Get();
            this.listTabProdutoDecomposicao = await myreportZanthusTabProdutoDecomposicao_Select.tblist_Get();
            this.listTabProdutoDecomposicaoInsum = await myreportZanthusTabProdutoDecomposicaoInsum_Select.tblist_Get();

        } catch (e) {
            clsTools.PagErrorException(`reportZanthus`, 'Select', e);

        } 
    }
}