import serviceParticipanteVipImport from './ServiceParticipanteVipImport';
import serviceParticipanteBlueSoftRedShiftImport from './serviceParticipanteBlueSoftRedShiftImport';
import serviceParticipanteBlueSoftAPIImport from './serviceParticipanteBluesoftAPIImport';
import serviceParticipanteBlueSoftAPIAtualizarStatusCredito from './serviceParticipanteBluesoftApiAtualizarStatusCredito';
import serviceGrupoEconomicoImport from './serviceGrupoEconomicoImport';
import serviceParticipanteBlueSoftAPIAtualizarStatusCreditoCorrecao from './serviceParticipanteBluesoftApiAtualizarStatusCreditoCorrecao';

export default class serviceParticipante { 
    static vipimport = serviceParticipanteVipImport
    static RedShiftBlueSoftImport = serviceParticipanteBlueSoftRedShiftImport
    static APIBlueSoftImport = serviceParticipanteBlueSoftAPIImport
    static GrupoEconomicoImport = serviceGrupoEconomicoImport
    static APIBlueSoftAtualizarStatusCredito = serviceParticipanteBlueSoftAPIAtualizarStatusCredito
    static APIBlueSoftAtualizarStatusCreditoCorrecao = serviceParticipanteBlueSoftAPIAtualizarStatusCreditoCorrecao
}


