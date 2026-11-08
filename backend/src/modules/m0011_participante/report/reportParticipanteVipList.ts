import { clsTools } from "../../../model/modelbase";

export default class reportParticipanteVipList { 
    public static sql(par: any) : string {
        let sql = `select 	v.cdparticipante 
						,	v.vip_cpf_cnpj 
						,	v.vip_cpf
						,	v.vip_cnpj 
						,	v.vip_nome
						,	v.vip_sobre_nome
						,	v.vip_email
						,	v.vip_data_nascimento
					from 	tbparticipante_vip v
					where 		1 = 1
			${par.cdparticipante ? `and v.cdparticipante = ${par.cdparticipante}` : ''}
			${par.vip_cpf_cnpj ? `and LPAD(v.vip_cpf_cnpj,14,'0') = LPAD(${par.vip_cpf_cnpj},14,'0')` : ''}
			${par.nome_razao ? `and UPPER(v.vip_nome) like UPPER('%${par.nome_razao}%')` : ''}
			${par.email ? `and UPPER(v.vip_email) like UPPER('%${par.email}%')` : ''}

            `
			if (par.data_aniversario_filter && par.data_aniversario_filter_ini) { 
				sql += ` and coalesce(v.vip_data_nascimento,'1900-01-01') >= ${par.data_aniversario_filter_ini}`
			}

			if (par.data_aniversario_filter && par.data_aniversario_filter_fim) { 
				sql += ` and coalesce(v.vip_data_nascimento,'1900-01-01') <= ${par.data_aniversario_filter_fim}`
			}


            return sql;
    }
    public static async get(par: any) : Promise<any> {
        //let myBase = new clsBase()
        try {
            let result = await clsTools.PagDataBaseGet(this.sql(par)); 
            return result
        } catch (e) {
            clsTools.PagErrorException('reportParticipanteList', 'get', e)
            throw new Error('Error in reportParticipanteList.get')
        }

    } 
}

