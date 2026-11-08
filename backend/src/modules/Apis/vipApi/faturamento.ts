import { clsTools, clsBase } from '../../../model/modelbase';



const myBase = new clsBase();

export default class FaturamentoVipPedido { 
    static async get(parametros: any) : Promise<object> { 

        let resultData: any 

        try { 

            resultData = await this.call(parametros)
            return resultData.data 

        } catch (e: any) {
            clsTools.PagErrorException(`modules | CRM VIP`, `FaturamentoVipPedido.get()`, e, true);
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
            clsTools.PagErrorException(`modules | CRM VIP`, `FaturamentoVipPedido.pagination()`, e, true);
            throw new Error(`modules | CRM VIP | Error ${e.message}`);
        } finally {
            return numeroPaginas
        }
    }

    private static async call (parametros: any) : Promise<object> { 
        let resultData: object = {}
        try { 

            let url = `/importacao/pedidos?filter=1`
            if (parametros.page) { url += `&page=${parametros.page}` }
            if (parametros.start_created) { url += `&start_created=${parametros.start_created}` }
            if (parametros.end_created) { url += `&end_created=${parametros.end_created}` }

            resultData  = await myBase.vipApi.vip_api_get(url)

        } catch (e: any) {
            clsTools.PagErrorException(`modules | CRM VIP`, `FaturamentoVipPedido.call()`, e, true);
        } finally {
            return resultData
        }
    }
}