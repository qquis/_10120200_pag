import { clsBase, clsTools } from "../../../model/modelbase";


import reportExternalZanthusTabMercadoria from "./report.tab_mercadoria";
import reportExternalZanthusTabFinalizadora from "./report.tab_finalizadora";
import reportExternalZanthusTabCliente from "./report.tab_cliente";
import reportExternalZanthusTabRegrasIcms from "./report.tab_regra_icms";

export default class reportExternalZanthus  { 
    static tabMercadoria = reportExternalZanthusTabMercadoria;
    static tabFinalizadora = reportExternalZanthusTabFinalizadora;
    static tabCliente = reportExternalZanthusTabCliente;
    static tabRegrasIcms = reportExternalZanthusTabRegrasIcms;
}