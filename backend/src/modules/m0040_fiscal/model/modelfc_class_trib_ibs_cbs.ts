import { clsBase, clsTools } from "../../../model/modelbase";
import tbfc_class_trib_ibs_cbs from "../tbs/tbfc_class_trib_ibs_cbs";


export default class modelfc_class_trib_ibs_cbs extends tbfc_class_trib_ibs_cbs {

    
    constructor() { 
        super();

    }

    ObterDadosAPIBluesoft_NFCE_PorProduto(ItemQueConteReformaTributariaIBS: any) {
        
        if (ItemQueConteReformaTributariaIBS.reformaTributaria.codigoClassTribIbsCbs  && ItemQueConteReformaTributariaIBS.reformaTributaria.codigoClassTribIbsCbs !== '') { 
            this.rt_codigo_class_trib_ibs_cbs = ItemQueConteReformaTributariaIBS?.reformaTributaria?.codigoClassTribIbsCbs || '';
            this.rt_descricao_class_trib_ibs_cbs = ItemQueConteReformaTributariaIBS?.reformaTributaria?.descricaoCstIbsCbs || ''   
        }
    }




}