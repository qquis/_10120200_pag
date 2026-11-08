import { clsBase, clsTools } from "../../../model/modelbase";
import tbfc_ibs_mun from "../tbs/tbfc_ibs_mun";


export default class modelfc_ibs_mun  extends tbfc_ibs_mun {

    
    constructor() { 
        super();

    }

    ObterDadosAPIBluesoft_NFCE_PorProduto(ItemQueConteReformaTributariaIBS: any) {
        if (ItemQueConteReformaTributariaIBS.reformaTributaria.ibsMun.ibsMunKey && ItemQueConteReformaTributariaIBS.reformaTributaria.ibsMun.ibsMunKey > 0) { 
                this.ibs_mun_cd = ItemQueConteReformaTributariaIBS.reformaTributaria.ibsMun.ibsMunKey;
                this.ibs_mun_descricao = ItemQueConteReformaTributariaIBS.reformaTributaria.ibsMun.descricao;
                this.ibs_mun_descricao_abreviada = ItemQueConteReformaTributariaIBS.reformaTributaria.ibsMun.descricaoAbreviada;

        }
    }




}