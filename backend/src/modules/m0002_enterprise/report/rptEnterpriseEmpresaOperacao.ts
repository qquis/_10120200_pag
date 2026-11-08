import { clsTools, clsBase} from '../../../model/modelbase';
import modelEmpresa from '../model/modelEmpresa';
import modelOperacao from '../model/modelOperacao';
export default class rptEnterpriseEmpresaOperacaoList {
    static sql (parametros: any = {}) : string { 


        let sql = `
                        select 		i.sis_ta_cd 
                            ,		i.em_cdempresa
                            ,		e.em_descricao 
                            ,		i.op_cdoperacao
                            ,		o.op_descricao 
                            ,		p.sis_ac_cd
                            ,		u.user_name
                            ,		u.sis_us_seq 
                        from 		tbsistema_tarefa_inter 	i
                        inner join 	tbsistema_tarefa 	t on t.sis_ta_cd = i.sis_ta_cd 
                        inner join  tbsistema_permissao p on p.sis_ta_cd = t.sis_ta_cd 
                        inner join  tbsistema 			s on s.sis_cd_pk = p.sis_cd
                        inner join  tbsistema_funcao 	f on f.sis_fc_cd = p.sis_fc_Cd 
                        inner join  tbsistema_usuario   u on u.sis_fc_cd = f.sis_fc_cd 
                        inner join  tboperacao  		o on o.op_cdoperacao = i.op_cdoperacao 
                        inner join  tbempresa   		e on e.em_cdempresa = i.em_cdempresa 
                        where		1 = 1
            `

      if (parametros.em_cdempresa) {
        sql += ` and i.em_cdempresa = ${parametros.em_cdempresa}`
      }

      if (parametros.op_cdoperacao) {
        sql += ` and i.op_cdoperacao = ${parametros.op_cdoperacao}`
      }
      if (parametros.__systemUserConnect && parametros.relatorio == 0)
        {
            if (parametros.__systemUserConnect.user_name !== '' && parametros.__systemUserConnect.user_name !== undefined) { 
                sql += ` and u.user_name = '${parametros.__systemUserConnect.user_name}'`
            }

            if (parametros.__systemUserConnect.user_credential !== '' 
                && parametros.__systemUserConnect.user_credential !== 'undefined'
                && parametros.__systemUserConnect.usuario_login_uuid !== ''
                && parametros.__systemUserConnect.usuario_login_uuid !== 'undefined') {
                    
                sql += ` and u.sis_us_seq = (select max(x.sis_us_seq) 
                                              from tbsistema_usuario_login x
                                              where 1 = 1 
                                                and x.usuario_login_uuid = '${parametros.__systemUserConnect.usuario_login_uuid}'
                                                and x.user_credential = '${parametros.__systemUserConnect.user_credential}')`
            }

            if (parametros.__systemUserConnect.sis_ac_cd !== '' && parametros.__systemUserConnect.sis_ac_cd !== undefined) {
                sql += ` and p.sis_ac_cd = ${parametros.__systemUserConnect.sis_ac_cd}`
            }
            if (parametros.__systemUserConnect.sis_cd !== '' && parametros.__systemUserConnect.sis_cd !== undefined) {
                sql += ` and s.sis_cd_pk = ${parametros.__systemUserConnect.sis_cd}`
            }
        }


        
        return sql 
    }
    static async get(parametros: any = {}) : Promise<any> {

        let result : any = {}

        try {
                const myTools = new clsBase();
                result = await myTools.myDataBase.pag.DataGet(this.sql(parametros))

                    
                
        } catch (e) {
            clsTools.PagErrorException(`reportDRresultado`, 'sql', e);
        }
        finally {
            return result;
        }
    }
    static async getModelOperacao(parametros: any = {}) : Promise<modelOperacao[]> {

        

        let list: modelOperacao[] = []
        const myTools = new clsBase();
        try {
                let result = await this.get(parametros)
                if (result && result.length > 0) {
                    for (const [key, value] of Object.entries(result)) {
                        let item = new modelOperacao();
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