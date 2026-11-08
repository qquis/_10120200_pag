
import reportFaturamentoBluesoftList from "./reportFaturamentoBluesoftList"
import reportFaturamentoBluesoftStatus from "./reportFaturamentoBluesoftStatus"
import reportFaturamentoBluesoftRedshiftList from "./report.faturamentoBluesoft.RedShift"
import reportFaturamentoBluesoftProcesso from "./reportFaturamentoBluesoftProcesso"
import reportFaturamentoBluesoftSistemaLogList from "./reportFaturamentoBluesoft.SistemaLog"
import reportFaturamentoBluesoftFV_PedidoComCorte from "./reportFaturamentoBluesoft.FV.PedidoComCorte"


class reportForcaVenda { 
    static PedidoComCorte = reportFaturamentoBluesoftFV_PedidoComCorte
}



export default class reportFaturamentoBluesoft {
    static list = reportFaturamentoBluesoftList
    static statusList = reportFaturamentoBluesoftStatus
    static redshift_list = reportFaturamentoBluesoftRedshiftList
    static processo = reportFaturamentoBluesoftProcesso
    static Log = reportFaturamentoBluesoftSistemaLogList
    static ForcaVenda = reportForcaVenda
  
    
}


