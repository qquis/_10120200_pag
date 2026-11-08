import serviceParticipanteVipImport from './ServiceParticipanteVipImport';
import serviceParticipanteBlueSoftRedShiftImport from './serviceParticipanteBlueSoftRedShiftImport';
import serviceParticipanteBlueSoftAPIImport from './serviceParticipanteBluesoftAPIImport';
import serviceParticipanteBlueSoftAPIAtualizarStatusCredito from './serviceParticipanteBluesoftApiAtualizarStatusCredito';
import serviceGrupoEconomicoImport from './serviceGrupoEconomicoImport';

export default class serviceParticipante { 
    static vipimport = serviceParticipanteVipImport
    static RedShiftBlueSoftImport = serviceParticipanteBlueSoftRedShiftImport
    static APIBlueSoftImport = serviceParticipanteBlueSoftAPIImport
    static GrupoEconomicoImport = serviceGrupoEconomicoImport
    static APIBlueSoftAtualizarStatusCredito = serviceParticipanteBlueSoftAPIAtualizarStatusCredito
}


