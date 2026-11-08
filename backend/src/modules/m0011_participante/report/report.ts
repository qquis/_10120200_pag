
import reportParticipanteList from "./reportParticipanteList";
import reportParticipanteGrupoEconomicoList from "./reportParticipanteBlueComGrupoEconomico";

import reportParticipanteTipoList from "./reportParticipanteTipoList";
import reportParticipanteBluesoftRedshift from "./report.ParticipanteBluesoft.Redshift";

export default class reportParticipante { 
    static List = reportParticipanteList
    static GrupoEconomicoList = reportParticipanteGrupoEconomicoList
    static TipoList = reportParticipanteTipoList
    static Redshift = reportParticipanteBluesoftRedshift
}