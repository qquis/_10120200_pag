import { clsBase, clsTools } from "../../../model/modelbase";

import reportZeusVoucherQtdeProdutos from "./report.Zeus.Voucher";
import reportZanthusCarga from "./report.ZanthusCarga";

export default class reportZanthus { 
    static ZanthusCarga = reportZanthusCarga;
    public static async ZeusVoucherQtdeProdutos(parametros: any) : Promise<any> {
        let result : any
        try { 
            result = await reportZeusVoucherQtdeProdutos.get(parametros);
        } catch (e) {
            clsTools.PagErrorException(`reportZanthus`, 'ZeusVoucherQtdeProdutos', e);
            throw new Error(`reportZanthus | ZeusVoucherQtdeProdutos | Error \n ${e}`)
        } finally {
            return result
        }
     
    }
}