import { clsBase, clsTools } from "../../../model/modelbase";


export default class reportZeusVoucherQtdeProdutos { 

    static sql (parametros: any = {}) : string { 
        try { 

            return `select 		count(pm.cod_produto) as qtde_voucher_promocional_prd
                    from 		tab_voucher_promocional_prod 	pm
                    inner join  tab_voucher_promocional 		v on v.cod_voucher = pm.cod_voucher
                    where		 v.cod_voucher = '${parametros.cod_voucher}'` 

        } catch (e) { 
            clsTools.PagErrorException(`reportFinanceiroPagList`, 'sql', e);   
            return ''       
        }
    }
    static async get(parametros: any = {}) {
        const myTools = new clsBase();
        try {
            let result = await myTools.myDataBase.zanthusPostgre.DataGet(this.sql(parametros));

            return result //await myTools.myDataBase.pag.DataGet(this.sql(parametros));
        } catch (e) {
            clsTools.PagErrorException(`reportFinanceiroPagList`, 'sql', e);
        }
    }

}