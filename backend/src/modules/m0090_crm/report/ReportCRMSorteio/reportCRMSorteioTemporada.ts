import { clsBase, clsTools } from "../../../../model/modelbase";
import modelcrm_sorteio_temporada from "../../model/modelcrm_soterio_temporada";


export default class reportCRMSorteioTemporada { 
    public static sql (parametros: any) : string { 
        let sql : string = `
        
                select  	crm_so_temp_cd			
                            ,	crm_so_temp_descricao 	
                            ,	crm_so_temp_valor_minimo
                            ,   crm_so_temp_status	
                            ,   crm_so_temp_data_ini
                            ,   crm_so_temp_data_fim
                    from tbcrm_sorteio_temporada        
                where 1 = 1
                ${(parametros.crm_so_temp_descricao && parametros.crm_so_temp_descricao != '') ? ` and crm_so_temp_descricao like '%${parametros.crm_so_temp_descricao}%' ` : `` }
                ${(parametros.apenas_ativa && parametros.apenas_ativa == 1) ? ` and crm_so_temp_status = 1 ` : `` }
                  
            `
    
        return sql
    
    }


    public static async get(parametros: any): Promise<modelcrm_sorteio_temporada[]> {
        {
            let mylist : modelcrm_sorteio_temporada[] = []
            try { 

                //Apenas uma temporada pode estar ativa

                const modeldb = new clsBase(); 
                let result =  await modeldb.myDataBase.pag.DataGet(this.sql(parametros));

                
                for await (const [key, value] of Object.entries(result)) {
                    let item : modelcrm_sorteio_temporada = new modelcrm_sorteio_temporada();
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

    public static async getTemporadaAtiva() : Promise<modelcrm_sorteio_temporada> { 
        let item : modelcrm_sorteio_temporada = new modelcrm_sorteio_temporada();

        try { 
            let list : modelcrm_sorteio_temporada[] = await this.get({apenas_ativa: 1});

            if (list.length > 0 ) { 
                item = list[0];
            }


        } catch (e) { 
            clsTools.PagErrorException(`reportCRMSorteioTemporada.getTemporadaAtiva`,`getTemporadaAtiva`, e);
        } finally { 
            return item;
        }
    }

} 