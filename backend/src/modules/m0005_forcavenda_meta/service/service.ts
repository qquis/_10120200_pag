
import serviceForcaVendaMetaFabricanteProcessar from "./serviceForcaVendaMeta.Fabricante.Processar"
import serviceForcaVendaMetaProcessar from "./serviceForcaVendaMeta.Processar"
import serviceProcessarMetasAtuais from "./serviceProcessarMetasAtuais"

export default class serviceForcaVendaMeta {
    static meta = serviceForcaVendaMetaProcessar
    static metaFabricante = serviceForcaVendaMetaFabricanteProcessar
    static metasAtuais = serviceProcessarMetasAtuais

}