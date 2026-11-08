import { clsBase, clsTools } from "../../../../model/modelbase";
import modelcrm_sorteio from "../../model/modelcrm_soterio";


export default class reportCRMSorteioList { 
    public static sql (parametros: any) : string { 
        let sql : string = `
                 SELECT  so.crm_so_seq
                    ,   so.crm_so_cd 
                    ,   so.crm_so_temp_cd 
                    ,   st.crm_so_temp_descricao 
                    ,   so.crm_so_descricao 
                    ,   so.crm_so_data_ini 
                    ,   so.crm_so_data_fim 
                    ,   so.crm_so_data_sorteio 
                    ,   so.crm_so_tipo_cd 
                    ,   coalesce(crm_numero_oficial, 0) as crm_numero_oficial
                FROM        tbcrm_sorteio so 
                inner join  tbcrm_sorteio_temporada st on st.crm_so_temp_cd = so.crm_so_temp_cd
                WHERE  1 = 1

                ${(parametros.crm_so_temp_cd && parametros.crm_so_temp_cd != '0') ? ` and so.crm_so_temp_cd = ${parametros.crm_so_temp_cd} ` : `` }

            `
    
        return sql
    
    }


    public static async get(parametros: any): Promise<modelcrm_sorteio[]> {
        {
            let mylist : modelcrm_sorteio[] = []
            try { 

                //Apenas uma temporada pode estar ativa

                const modeldb = new clsBase(); 
                let result =  await modeldb.myDataBase.pag.DataGet(this.sql(parametros));

                
                for await (const [key, value] of Object.entries(result)) {
                    let item : modelcrm_sorteio = new modelcrm_sorteio();
                    Object.assign(item, value);
                    mylist.push(item);
                }
            }

             catch (e) { 
                clsTools.PagErrorException(`reportCRMSorteioTemporada.get`,`get`, e);
            } finally { 
                return mylist;
            }
        }
    }


} 