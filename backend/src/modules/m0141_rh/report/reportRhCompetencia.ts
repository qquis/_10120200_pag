import { clsTools, clsBase} from '../../../model/modelbase';
import modelcompetencia from '../../m0002_enterprise/model/modelcompetencia';
import rptEnterpriseCompetenciaList from '../../m0002_enterprise/report/rptEnterpriseCompetenciaListGet';
export default class reportRhCompetencia {
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
            AND x.competencia_cd  in (
                            SELECT a.competencia_cd FROM tbrh_salario a
                           )
            
            `
            return sql 
    }
    static async get(parametros: any = {}) : Promise<modelcompetencia[]> {
        let list: modelcompetencia[] = []
        const myTools = new clsBase();
        try {
                list =  await rptEnterpriseCompetenciaList.get(parametros, this.sql(parametros));
                
        } catch (e) {
            clsTools.PagErrorException(`reportDRresultado`, 'sql', e);
        } finally {
            return list;
        }
    }

}