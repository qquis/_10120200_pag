
import reportZanthusPagamento from "./reportZanthusPagamentos";
import reportZanthusCupom from "./reportZanthusCupom";
import reportZanthusCupomItem from "./reportZanthusCupomItem";


export default class reportFaturamentoZanthus { 
    static Cupom = reportZanthusCupom
    static CupomItem = reportZanthusCupomItem
    static Pagamento = reportZanthusPagamento
    
}