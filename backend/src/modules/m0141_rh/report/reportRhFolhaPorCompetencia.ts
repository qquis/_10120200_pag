import { clsTools, clsBase} from '../../../model/modelbase';
import f0141_66_salario_competencia_list from '../scriptdb/f0141_66_salario_competencia_list';


export default class reportFolhaPorCompetencia{
    static sql (parametros : any) : string { 
        
        return f0141_66_salario_competencia_list.get(parametros);
    }
    static async get(parametros: any) {
            const myTools = new clsBase();
        try {
            return await myTools.myDataBase.pag.DataGet(this.sql(parametros));
        } catch (e) {
            clsTools.PagErrorException('reportFolhaPorCompetencia', 'get', e);
        }
    }

}