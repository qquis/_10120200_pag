
import {clsTools, clsBase} from '../../../model/modelbase'
import f0100_10_fechamento_processar from '../scriptdb/f0100_10_fechamento_processar'
export default class serviceResultado { 
    static async ProcessarFechamento(parametros : any) : Promise<void> {
        try {
            let myclsBase = new clsBase();
            const sql = f0100_10_fechamento_processar.post(parametros);

            await myclsBase.myDataBase.pag.Execute(sql)
        } catch(e) {
            clsTools.PagErrorException("serviceDRE", "ContaAtualizarCodigoRateio", e)
        }
    }
}