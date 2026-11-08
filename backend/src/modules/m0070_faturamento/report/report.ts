
import reportFaturamentoStatus from "./reportFaturamentoStatus";
import reportFaturamentoOperacaoConferencia from "./reportFaturamentoOperacaoConferencia";
import reportFaturamentoExport from "./reportFaturamentoExport";
import reportFaturamentoContratoTipo from "./reportFaturamento.Contrato.Tipo";
import reportFaturamentoContrato from "./reportFaturamento.Contrato";
import reportfaturamentolist from "./reportFaturamento.list";
export default class reportFaturamento { 
    static faturamentoStatus = reportFaturamentoStatus
    static faturamentoOperacaoConferencia = reportFaturamentoOperacaoConferencia
    static faturamentoExport = reportFaturamentoExport
    static faturamentoContratoTipo = reportFaturamentoContratoTipo
    static faturamentoContrato = reportFaturamentoContrato
    static faturamentoList = reportfaturamentolist
    
}