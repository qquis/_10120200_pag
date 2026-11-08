import { clsTools } from "../../../model/modelbase";
import serviceSistemaPermissao from "../../m0001_sistema/service/serviceSistemaPermissao";

export default class reportParticipanteList { 
    public static async sql(par: any) : Promise<string> {
        let sql = `select 		t.cdparticipante 
									,	t.cdpessoabluesoft
									,	cast(coalesce(rh.funcionario_cd ,0) as int) as funcionario_cd
									,	cast(t.cpf_cnpj as char(14)) as cpf_cnpj 
									,	cast(coalesce(t.nome_razao, '') as varchar(60)) as nome_razao 
									,	pb.nome_abreviado 
									,	cast(coalesce(coalesce(t.email_main, ps.email_main), '') as varchar(60)) as email_main 									
									,	coalesce(t.celular_dd,0) as celular_dd
									,	coalesce(t.celular_numero,0) as celular_numero							
									,	cast(coalesce(t.bluesoftcliente,0)  as smallint) as bluesoftcliente
									,	cast(coalesce(t.bluesoftvendedor,0) as smallint) as bluesoftvendedor
									,	cast(coalesce(t.bluesoftfornecedor,0) as smallint) as bluesoftfornecedor
									,	cast(coalesce(t.bluesoftfabricante,0)  as smallint) as bluesoftfabricante
									,	cast(coalesce(pb.bluesoft_pessoa_status,0) as smallint) as bluesoft_pessoa_status
									,	cast(coalesce(pb.bluesoftclientestatus,0)  as smallint) as bluesoftclientestatus
									,	cast(coalesce(t.participante_status,0)  as smallint) as participante_status
									
							from 		tbparticipante 					t
							left join 	tbpessoa						ps on ps.cdpessoa = t.cdpessoa
							left join   tbparticipante_bluesoft			pb on pb.cdparticipante = t.cdparticipante 
							left join   ( 	select 	max(xa.funcionario_cd) as funcionario_cd  
												,	xa.cdparticipante as cdparticipante 	
											from 	tbparticipante_funcionario    	xa
											group by xa.cdparticipante
										) 	rh on rh.cdparticipante = t.cdparticipante 
							where 		1 = 1
							${par.nome_razao ? `and UPPER(t.nome_razao) like UPPER('%${par.nome_razao}%')` : ''}
							${par.participante_tipo_cd && par.participante_tipo_cd != '0' ? 
									` and t.cdparticipante in (	select 	l.cdparticipante 
																from 	tbparticipante_tipo_reg l
																where  	l.participante_tipo_cd = ${par.participante_tipo_cd}
																)`: ''}
							${par.vendedor_pag ? ` and t.cdparticipante in (	select 	xx.cdparticipante 
																from 	TBPARTICIPANTE_TIPO_REG xx
																where  	xx.participante_tipo_cd = 121
																)`: ''}
            `

			if (par.cdparticipante && par.cdparticipante != '0') { 
				sql += ` and t.cdparticipante = ${par.cdparticipante} `
			}

			if (par.vendedor_pag && !par.relatorio) { 
				
				let permissaoTODOSVENDEDORES = await serviceSistemaPermissao.getFindPermissaoTarefa(par, 110010)
				
				if (!permissaoTODOSVENDEDORES) { 
					sql += ` and t.cdparticipante in (	select 	xa.cdparticipante 
													from 		tbparticipante xa
													inner join tbsistema_usuario u on u.cdpessoabluesoft = xa.cdpessoabluesoft
													where  	1 = 1
													  and   u.user_name = '${par.__systemUserConnect.user_name}'
													) `
				}
			}


			sql+= ` order by t.nome_razao  ASC`

			

            return sql;
    }
    public static async get(par: any) : Promise<any> {
        //let myBase = new clsBase()
        try {
            let result = await clsTools.PagDataBaseGet(await this.sql(par)); 
            return result
        } catch (e) {
            clsTools.PagErrorException('reportParticipanteList', 'get', e)
            throw new Error('Error in reportParticipanteList.get')
        }

    } 
	public static async getPagVendedor(parametro: any) : Promise<any> {
		try {
			parametro.vendedor_pag = 1
			let result = await this.get(parametro)
			return result
		} catch (e) {
			clsTools.PagErrorException('reportParticipanteList', 'getPagVendedor', e)
			throw new Error('Error in reportParticipanteList.getPagVendedor')
		}	
	}

	public static async getPagFabricante(parametro: any) : Promise<any> {
		try {
			parametro.participante_tipo_cd = 140
			let result = await this.get(parametro)
			return result
		} catch (e) {
			clsTools.PagErrorException('reportParticipanteList', 'getPagFabricante', e)
			throw new Error('Error in reportParticipanteList.getPagFabricante')
		}	
	}
}

