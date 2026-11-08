import { clsBase, clsTools } from "../../../model/modelbase";
import tbfc_cbs from "../tbs/tbfc_cbs";


export default class modelfc_cbs extends tbfc_cbs {

    
    constructor() { 
        super();

    }

    ObterDadosAPIBluesoft_NFCE_PorProduto(ItemQueConteReformaTributariaIBS: any) {
        
        if (ItemQueConteReformaTributariaIBS.reformaTributaria.cbs.cbsKey 
            && ItemQueConteReformaTributariaIBS.reformaTributaria.cbs.cbsKey > 0 ) { 
            this.cbs_cd = ItemQueConteReformaTributariaIBS.reformaTributaria.cbs.cbsKey;
            this.cbs_descricao = ItemQueConteReformaTributariaIBS.reformaTributaria.cbs.descricao;
            this.cbs_descricao_abreviada = ItemQueConteReformaTributariaIBS.reformaTributaria.cbs.descricaoAbreviada;
        }
    }




}