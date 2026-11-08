


import reportCRMSorteioTemporada from "./reportCRMSorteioTemporada";
import reportCRMSorteioConsultarCupom from "./reportCRMSorteioConsultarCupom";
import reportCRMSorteioNumero from "./reportCRMSorteioNumero";
import reportCRMSorteioList from "./reportCRMSorteioList";

export default class reportCRMSorteio  { 
    static Temporada = reportCRMSorteioTemporada
    static Cupom = reportCRMSorteioConsultarCupom
    static Numero = reportCRMSorteioNumero
    static List = reportCRMSorteioList
}