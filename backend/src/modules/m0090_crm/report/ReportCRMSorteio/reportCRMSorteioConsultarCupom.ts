import { clsBase, clsTools } from "../../../../model/modelbase";
import modelcrm_sorteio_temporada from "../../model/modelcrm_soterio_temporada";
import modelcrm_sorteio_cupom from "../../model/modelcrm_sorteio_cupom";
import { Console } from "console";

export default class reportCRMSorteioConsultarCupom  { 
    static sql (parametro: any) : string { 




        let data_emissao_filter: Date = new Date('1900-01-01');

        if (parametro.data_emissao) { 
            
            data_emissao_filter = clsTools._datemomentDatStrToDate(parametro.data_emissao,  "YYYY-MM-DD");
            

        }

        let sql = `
                    SELECT  			
                    	crm_so_temp_cd				
                    ,	crm_so_cupom_seq			
                    ,	numero_cupom				
                    ,	numero_pedido 				
                    ,	data_emissao	
                    ,   data_emissao_hora			
                    ,   sat_ecf						
                    ,	nf_numero					
                    ,	nf_data_emissao				
                    ,	nf_chave					
                    ,	valor						
                    ,	cpf_cnpj					
                    ,   cdparticipante				
                    ,   crm_so_cpf					
                    ,   crm_so_qtde_numero_sorteio   
                    ,   coalesce(crm_so_externo_enviado,0) as crm_so_externo_enviado
                    ,   coalesce(crm_so_externo_enviado_data , '1900-01-01') as crm_so_externo_enviado_data

                    FROM tbcrm_sorteio_cupom X
                    WHERE 1 = 1`

                if (parametro.crm_so_cupom_seq && parametro.crm_so_cupom_seq > 0) { 
                    sql += ` AND crm_so_cupom_seq = ${Number(parametro.crm_so_cupom_seq)} `
                }


                if (parametro.status_envio_sorteio || parametro.status_envio_sorteio == 0) {
                    if (parametro.status_envio_sorteio == 99) {
                        sql += ` AND coalesce(crm_so_externo_enviado,0) in (0,1,9) `
                        
                    } else { 
                        sql += ` AND coalesce(crm_so_externo_enviado,0) = ${Number(parametro.status_envio_sorteio)} `
                        sql += ` AND cpf_cnpj != '00000000000000' `
                    }
                    //sql += ` AND numero_cupom = 18887`
                    sql += ` AND coalesce(cpf_cnpj,'0') != '0' `
                    
                    sql += ` AND coalesce(valor,0) > 0 `
                    sql += ` AND data_emissao = '${parametro.data_emissao}' `
                    sql += ` AND crm_so_cupom_seq > 0`
                }

                if (parametro.consultaCupomDisponivel && parametro.consultaCupomDisponivel == 1) {
                    sql += `${(parametro.cpf_cnpj) ? ` AND ( LPAD(cpf_cnpj, 14, '0') = LPAD('${parametro.cpf_cnpj}', 14, '0') OR coalesce(cpf_cnpj,'0') = '0' ) OR coalesce(cpf_cnpj,'0') = '' ` : ``} 
                            ${(parametro.nf_chave)? ` AND nf_chave = '${parametro.nf_chave}' ` : ``}
                            ${(parametro.nf_numero)? ` AND nf_numero = ${parametro.nf_numero} ` : ``}
                            ${(parametro.data_emissao)? ` AND data_emissao = '${clsTools._datemomentDateToStr(data_emissao_filter, 'YYYY-MM-DD')}' ` : ``}
                            ${(parametro.ecf_sat)? ` AND sat_ecf = ${parametro.ecf_sat} ` : ``}
                    `

                } else if (parametro.consultaCupomDisponivel && parametro.consultaCupomDisponivel == 0) {
                    sql += `
                    ${(parametro.validacpfcrm && parametro.validacpfcrm == 1) ? 
                        ` AND ( LPAD(cpf_cnpj, 14, '0') = LPAD('${this}', 14, '0') OR coalesce(cpf_cnpj,'0') = '0' ) ` : ``}
                    ${(parametro.cpf_cnpj)? ` AND cpf_cnpj = '${parametro.cpf_cnpj}' ` : ``}
                    ${(parametro.numero_cupom)? ` AND numero_cupom = '${parametro.numero_cupom}' ` : ``}
                    ${(parametro.crm_so_temp_cd)? ` AND crm_so_temp_cd = ${Number(parametro.crm_so_temp_cd)} ` : ``}
                    ${(parametro.nf_chave)? ` AND nf_chave = '${parametro.nf_chave}' ` : ``}
                    ${(parametro.crm_so_cpf)? ` AND crm_so_cpf = '${parametro.crm_so_cpf}' ` : ``}
                    ${(parametro.data_emissao? ` AND data_emissao = '${clsTools._datemomentDateToStr(parametro.data_emissao, 'YYYY-MM-DD')}' ` : ``)}
                    ) `
                }

                

        sql += ` ORDER BY crm_so_cupom_seq ASC `

        if (parametro.limit && parametro.limit > 0) {
            sql += ` LIMIT ${Number(parametro.limit)} `
        }
        

        return sql;
    }

    static async get (parametro: any) : Promise<modelcrm_sorteio_cupom[]> {
        let mylist = new Array<modelcrm_sorteio_cupom>()
        try { 
            const modeldb = new clsBase();
            let result = await modeldb.myDataBase.pag.DataGet(this.sql(parametro));

            for await (const [i, itemData] of Object.entries(result)) {
                let item : modelcrm_sorteio_cupom = new modelcrm_sorteio_cupom();
                item.binding(itemData);
                mylist.push(item);
            }

        } catch (error) {
            clsTools.PagErrorException("M0090_CRM", "reportCRMSorteioConsultarCupom - get", error);
            throw error;
        }
        finally {
            return mylist;
        }
        
    }

}