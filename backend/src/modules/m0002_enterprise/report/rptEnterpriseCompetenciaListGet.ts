import { clsTools, clsBase} from '../../../model/modelbase';
import modelcompetencia from '../model/modelcompetencia';
export default class rptEnterpriseCompetenciaList {
    static sql (parametros: any = {}) : string { 
        let sql = `
            select      x.competencia_cd 
                    ,   x.competencia_ano 
                    ,   x.competencia_mes
                    ,   x.competencia_descricao
                    ,   x.competencia_data_ini 
                    ,   x.competencia_data_fim
                    ,   x.competencia_cd_ma 
            FROM       tbcompetencia x       
            
            WHERE 1 = 1 
            ${(parametros.listall && parametros.listall == 1)? ` and  competencia_data_ini <= current_date ` : ' and  competencia_data_ini <= current_date '}
            ${(parametros.orderbycolunm && !parametros.orderby)? ` order by ${parametros.orderbycolunm}` : ''}
            ${(parametros.orderbycolunm && parametros.orderby)? ` order by ${parametros.orderbycolunm} ${parametros.orderby}` : ''}


            `
            return sql 
    }
    static async get(parametros: any = {}, sql = ``) : Promise<modelcompetencia[]> {


        let list: modelcompetencia[] = []
        const myTools = new clsBase();
        if (!sql) {
            sql = this.sql(parametros);
        }
        try {
                let result = await myTools.myDataBase.pag.DataGet(sql)
                if (result && result.length > 0) {
                    for (const [key, value] of Object.entries(result)) {
                        let item = new modelcompetencia();
                        await item.binding(value);
                        list.push(item);
                    }
                }
                    
                
        } catch (e) {
            clsTools.PagErrorException(`reportDRresultado`, 'sql', e);
        }
        finally {
            return list;
        }
    }

}