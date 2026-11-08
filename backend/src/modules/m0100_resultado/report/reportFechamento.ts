import { clsTools, clsBase} from '../../../model/modelbase';
import f0100_20_fechamento_consultar from '../scriptdb/f0100_20_fechamento_consultar';


export default class reportFechamento{
    static sql (parametros: any) : string { 
        try { 
            if (!parametros.competencia_cd)
                throw new Error("Parametro [competencia_cd] não informado ")
            let sql = f0100_20_fechamento_consultar.get(parametros)
            return sql
        } catch (e) { 
            clsTools.PagErrorException(`reportDREFechamento`, 'sql', e);   
            return `` 
        }
    }
    static async get(parametros : any) {
        const myTools = new clsBase();
        try {
            return await myTools.myDataBase.pag.DataGet(this.sql(parametros));
        } catch (e) {
            return clsTools.PagErrorException(`reportDREFechamento`, 'sql', e);
        }
    }

}