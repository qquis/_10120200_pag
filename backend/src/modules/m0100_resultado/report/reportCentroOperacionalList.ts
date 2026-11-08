import { clsTools, clsBase} from '../../../model/modelbase';
import f0100_20_fechamento_consultar from '../scriptdb/f0100_20_fechamento_consultar';


export default class reportCentroOperacionalList{
    static sql (parametros: any = {}) : string { 
        try { 
            let sql = `
                            select 		co.op_cdoperacao 
                    ,		op.op_descricao 
                    ,		co.r_centro_op_cd
                    ,		co.r_centro_op_descricao
                    ,		co.r_resp_Cd 
                    ,		rs.r_resp_descricao 
                from 		tbresultado_centro_operacional co
                inner join  tboperacao op on op.op_cdoperacao = co.op_cdoperacao 
                inner join  tbresultado_resp rs on rs.r_resp_cd = co.r_resp_cd 
                where 		1 = 1 
                union 
                    select 0        as op_cdoperacao
                        , 'Todos'   as op_descricao
                        , 0         as r_centro_op_cd
                        , 'Todos'   as r_centro_op_descricao
                        , 0         as r_resp_cd
                        , 'Todos' as r_resp_descricao
                order by 	3
                        asc
            `
            return sql 
        } catch (e) { 
            clsTools.PagErrorException(`reportDREFechamento`, 'sql', e);   
            return ''       
        }
    }
    static async get(parametros: any = {}) {
            const myTools = new clsBase();
        try {
            return await myTools.myDataBase.pag.DataGet(this.sql(parametros));
        } catch (e) {
            clsTools.PagErrorException(`reportDREFechamento`, 'sql', e);
        }
    }

}