import { clsTools, clsBase} from '../../../model/modelbase';
import f0141_65_salario_contratada_list from '../scriptdb/f0141_65_salario_contratada_list';


export default class reportRhFolhaContratada{
    static sql (parametros: any) : string { 
        return f0141_65_salario_contratada_list.get(parametros);
    }
    static async get(parametros: any) {
            const myTools = new clsBase();
        try {
            return await myTools.myDataBase.pag.DataGet(this.sql(parametros));
        } catch (e) {
            throw new Error(`Error in setorOpercional: ${e}`);
        }
    }

}