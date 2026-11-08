


import { clsBase, clsTools } from "../../../../model/modelbase";


import modelcrm_sorteio_numero from "../../model/modelcrm_soteio_numero";

export default class reportCRMSorteioConsultarNumero {
    static sql (parametro: any) : string { 
        console.log('reportCRMSorteioConsultarNumero - sql', parametro);
        let sql = `
                    SELECT  			
                        n.crm_so_temp_cd
                    ,   n.crm_so_numero_seq 
                    ,   n.crm_so_numero_ordem
                    ,   n.numero 				
                    ,	x.crm_so_cupom_seq			
                    ,	x.numero_cupom				
                    ,	x.numero_pedido 				
                    ,	x.data_emissao				
                    ,   x.sat_ecf						
                    ,	x.nf_numero					
                    ,	x.nf_data_emissao				
                    ,	x.nf_chave					
                    ,	x.valor						
                    ,	x.cpf_cnpj					
                    ,   x.cdparticipante				
                    ,   x.crm_so_cpf					
                    ,   x.crm_so_qtde_numero_sorteio    

                    FROM        tbcrm_sorteio_numero n
                    inner join   tbcrm_sorteio_cupom  X on n.crm_so_cupom_seq = x.crm_so_cupom_seq and n.crm_so_temp_cd = x.crm_so_temp_cd
                    WHERE 1 = 1
                    ${(parametro.crm_so_temp_cd)? ` AND n.crm_so_temp_cd = ${Number(parametro.crm_so_temp_cd)} ` : ``}
                    ${parametro.nao_registrado ? ` AND coalesce(x.crm_so_registrado,0) in (0,1) ` :  ` AND x.crm_so_registrado = 1 ` }
                    ${(parametro.cpf_cnpj)? ` AND cpf_cnpj = '${clsTools.document.formatdb(parametro.cpf_cnpj)}' ` : ``}
                    ${(parametro.numero_cupom)? ` AND x.numero_cupom = '${parametro.numero_cupom}' ` : ``}
                    ${(parametro.nf_chave)? ` AND n.nf_chave = '${parametro.nf_chave}' ` : ``}
                    ${(parametro.crm_so_cpf)? ` AND x.crm_so_cpf = '${clsTools.document.formatdb(parametro.crm_so_cpf)}' ` : ``}
                    ${(parametro.crm_so_temp_cd && parametro.crm_so_temp_cd !== '0') ? ` AND n.crm_so_temp_cd = ${parametro.crm_so_temp_cd} ` : ``}
                ORDER BY x.crm_so_cupom_seq DESC
                ${(parametro.limit && parametro.limit > 0) ? ` LIMIT ${parametro.limit} ` : ``}
                
       `
        return sql;
    }

    static async get (parametro: any) : Promise<modelcrm_sorteio_numero[]> {
        let mylist : modelcrm_sorteio_numero[] = []
        try { 
            const modeldb = new clsBase();
            let result = await modeldb.myDataBase.pag.DataGet(this.sql(parametro));

            

            for await (const [key, value] of Object.entries(result)) {
                let item : modelcrm_sorteio_numero = new modelcrm_sorteio_numero();
                item.model_biding(value)
                mylist.push(item);
            }


        } catch (error) {
            clsTools.PagErrorException("M0090_CRM", "reportCRMSorteioConsultarCupom - get", error);
            throw error;
        }
        finally {
            

            return mylist
        }
        
    }

}