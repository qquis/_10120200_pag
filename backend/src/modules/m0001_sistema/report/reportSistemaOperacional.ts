import { Console } from 'console';
import { clsTools, clsBase} from '../../../model/modelbase';



export default class reportSistemaOperacional{
    static sql (parametros: any = {}) : string { 
        try { 
            
            let sql =  `   SELECT 		
                                sis_operacional_cd serial
                            ,   sis_operacional_default 
                            ,   data_processamento_venda_ini 
                            ,   data_processamento_venda_fim 
                            ,   competencia_cd 
                            ,   fv_fab_meta_cd 
                            ,   faturamento_numero_dias_qtde
                            ,   faturamento_data_limite
                FROM 		tbsistema_operacional us
                WHERE 1=1
        `
        if (parametros.sis_operacional_default) {
            sql += ` AND us.sis_operacional_default = '${parametros.sis_operacional_default}' `
        }


        return sql

        } catch (e) { 
            clsTools.PagErrorException(`reportSistemaOperacional`, 'sql', e);   
            return ''       
        }
    }
    static async get(parametros: any = {}) {
            const myTools = new clsBase();
        try {
            let result = await myTools.myDataBase.pag.DataGet(this.sql(parametros));

            return result //await myTools.myDataBase.pag.DataGet(this.sql(parametros));
        } catch (e) {
            await clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemaOperacional.get', e);
        }
    }

    static async getDefault() {
        try { 
            const myTools = new clsBase();
            let result = await this.get({ sis_operacional_default: 1 }) as object[];
            
            let item : any = await myTools.myDataBase.RecordItem(result,0);  
            
            let dados = { 
                sis_operacional_cd: item.sis_operacional_cd,
                sis_operacional_default: item.sis_operacional_default,
                data_processamento_venda_ini: clsTools._datemomentDateToStr(clsTools._datemomentDatStrToDate(item.data_processamento_venda_ini, "YYYY-MM-DD HH:mm:ss"), "YYYY-MM-DD"),
                data_processamento_venda_fim: clsTools._datemomentDateToStr(clsTools._datemomentDatStrToDate(item.data_processamento_venda_fim, "YYYY-MM-DD HH:mm:ss"), "YYYY-MM-DD"),
                competencia_cd: item.competencia_cd,
                fv_fab_meta_cd: item.fv_fab_meta_cd,
                faturamento_numero_dias_qtde: item.faturamento_numero_dias_qtde,
                faturamento_data_limite: clsTools._datemomentDateToStr(clsTools._datemomentDatStrToDate(item.faturamento_data_limite, "YYYY-MM-DD HH:mm:ss"), "YYYY-MM-DD")
            }
            
            
            return dados;
        } catch (e) {
            await clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemaOperacional.getDefault', e);
        }
    }

}