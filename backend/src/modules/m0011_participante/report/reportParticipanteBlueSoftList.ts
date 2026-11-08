import { clsTools } from "../../../model/modelbase";

export default class reportParticipanteBlueSoftList { 
    public static sql(par: any) : string {
        let sql = `SELECT 	b.cdparticipante
						,	b.cdpessoabluesoft
						,	b.cpf_cnpj 
						,	b.pessoajuridica
						,	b.bluesoft_pessoa_data_cadastro 
						,	b.bluesoft_pessoa_status
						,	b.nome_razao 
						,	b.nome_abreviado
						,	b.bluesoftcliente
						,	b.bluesoftclientestatus
						,	b.cdgrupoeconomico 
						,	ge.descricao 
						,	b.cdpessoabluesoft_vendedor
						,   pv.nome_razao as nome_vendedor
						,	b.bluesoftvendedor
						,	b.bluesoftfornecedor
						,	b.bluesoftfabricante
						,	b.bluesoftmotorista
					from 	tbparticipante_bluesoft b
					left join tbgrupoeconomico ge on ge.cdgrupoeconomico = b.cdgrupoeconomico
					left join tbparticipante   pv on pv.cdpessoabluesoft = b.cdpessoabluesoft_vendedor AND b.cdpessoabluesoft_vendedor > 0 
					where 		1 = 1
			${par.cdparticipante ? `and b.cdparticipante = ${par.cdparticipante}` : ''}
			${par.cpf_cnpj ? `and LPAD(b.cpf_cnpj,14,'0') = LPAD(${par.cpf_cnpj},14,'0')` : ''}
			${par.nome_razao ? `and UPPER(b.nome_razao) like UPPER('%${par.nome_razao}%')` : ''}
			${par.bluesoft_motorista ? `and b.bluesoftmotorista = ${par.bluesoft_motorista}` : ''}

            `


            return sql;
    }
    public static async get(par: any) : Promise<any> {
        //let myBase = new clsBase()
        try {
            let result = await clsTools.PagDataBaseGet(this.sql(par)); 
            return result
        } catch (e) {
            clsTools.PagErrorException('reportParticipanteBlueSoftList', 'get', e)
            throw new Error('Error in reportParticipanteBlueSoftList.get')
        }

    } 
}

