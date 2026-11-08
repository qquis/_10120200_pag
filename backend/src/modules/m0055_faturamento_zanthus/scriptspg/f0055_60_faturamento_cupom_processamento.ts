/*import { fil } from 'date-fns/locale'
import { faturamentofilter } from '../Service'
import Tools from '../../../tools/Tools'

export default class f0055_60_faturamento_cupom_processamento
{
    private static sqlScript_VERSION(): string {return `f0055_60_1011910_faturamento_cupom_processamento`}

    public static sqlScript_UPDATE(filter: faturamentofilter) : string {
        return `SELECT ${this.sqlScript_VERSION()}
                (   
                     '${Tools.format_Date_toStr_ShortDataBase(filter.dataProcessamento)}'
                    , ${filter.ecf}
                    , ${filter.cupomfiscal})`
    } 


}*/


export default class f0055_60_faturamento_cupom_processamento {

    //public static sqlScript_VERSION(): string {return `f0055_60_1012007_faturamento_cupom_processamento`}
    public static sqlScript_VERSION(): string {return `f0055_60_1012010_faturamento_cupom_processamento`}
    

}