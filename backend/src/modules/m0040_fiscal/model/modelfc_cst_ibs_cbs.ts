import { clsBase, clsTools } from "../../../model/modelbase";
import tbfc_cst_ibs_cbs from "../tbs/tbfc_cst_ibs_cbs";


export default class modelfc_cst_ibs_cbs  extends tbfc_cst_ibs_cbs {

    
    constructor() { 
        super();

    }

    ObterDadosAPIBluesoft_NFCE_PorProduto(item: any) {
        if (item.reformaTributaria.codigoCstIbsCbs && item.reformaTributaria.codigoCstIbsCbs !== '') { 
                this.rt_codigo_cst_ibs_cbs = item.reformaTributaria.codigoCstIbsCbs;
                this.cst_ibs_cbs_descricao = item.reformaTributaria.descricaoCstIbsCbs;

        }
    }




}