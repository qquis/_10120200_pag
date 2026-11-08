import { clsBase, clsTools } from "../../../model/modelbase";
import tbfc_ibs from "../tbs/tbfc_ibs";


export default class modelfc_ibs extends tbfc_ibs {

    
    constructor() { 
        super();

    }

    ObterDadosAPIBluesoft_NFCE_PorProduto(ItemQueConteReformaTributariaIBS: any) {
        
        if (ItemQueConteReformaTributariaIBS.reformaTributaria.ibs.ibsKey && ItemQueConteReformaTributariaIBS.reformaTributaria.ibs.ibsKey > 0 ) { 
                this.ibs_cd = ItemQueConteReformaTributariaIBS.reformaTributaria.ibs.ibsKey;
                this.ibs_descricao = ItemQueConteReformaTributariaIBS.reformaTributaria.ibs.descricao;
                this.ibs_descricao_abreviada = ItemQueConteReformaTributariaIBS.reformaTributaria.ibs.descricaoAbreviada;

        }
    }




}