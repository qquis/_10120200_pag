import { clsTools, clsBase } from '../../../model/modelbase';



const myBase = new clsBase();

export default class clientes { 
    static async get(parametros: any) : Promise<object> { 

        let resultData: any 

        try { 

            resultData = await this.call(parametros)
            return resultData.data 

        } catch (e: any) {
            clsTools.PagErrorException(`modules | CRM VIP`, `clientes.get()`, e, true);
            throw new Error(`modules | CRM VIP | Error ${e.message}`);
        }
    }

    static async pagination (parametros: any) : Promise<number> {
        
        let numeroPaginas = 0
        
        try { 

            let result : any   = await this.call(parametros)
            if (result && result.pagination) {
                numeroPaginas = parseInt  ( result.pagination.page_count ) 
            }

        } catch (e: any) {
            clsTools.PagErrorException(`modules | CRM VIP`, `clientes.pagination()`, e, true);
            throw new Error(`modules | CRM VIP | Error ${e.message}`);
        } finally {
            return numeroPaginas
        }
    }

    private static async call (parametros: any) : Promise<object> { 
        let resultData: object = {}
        try { 

            if (!parametros.page) { parametros.page = 1; }
            if (!parametros.data_ultima_alteracao_ini) { parametros.data_ultima_alteracao_ini = '2025-01-01'; }
            if (!parametros.data_ultima_alteracao_fim) {
                const now = new Date();
                const yyyy = now.getFullYear();
                const mm = String(now.getMonth() + 1).padStart(2, '0');
                const dd = String(now.getDate()).padStart(2, '0');
                parametros.data_ultima_alteracao_fim = `${yyyy}-${mm}-${dd}`;
            }

            let url = `/importacao/clientes`

            if (parametros.id) { 
                url += `/${parametros.id}`
            }
            else {
                url += `?page=${parametros.page}`
            
                if (parametros.data_ultima_alteracao_ini) {
                    url += `&modified_inicial=${parametros.data_ultima_alteracao_ini}`
                }
                if (parametros.data_ultima_alteracao_fim) {
                    url += `&modified_final=${parametros.data_ultima_alteracao_fim}`
                }
            }

            resultData  = await myBase.vipApi.vip_api_get(url)

        } catch (e: any) {
            clsTools.PagErrorException(`modules | CRM VIP`, `clientes.call()`, e, true);
        } finally {
            return resultData
        }
    }
}