import { Console } from 'console';
import { clsTools, clsBase} from '../../../model/modelbase';



export default class reportSistemaOperacional{
    static sql (parametros: any = {}) : string { 
        try { 
            
            let sql =  `   SELECT 		
                                us.sis_operacional_cd 
                            ,   us.sis_operacional_default 
                            ,   us.data_processamento_venda_ini 
                            ,   us.data_processamento_venda_fim 
                            ,   us.competencia_cd 
                            ,   us.fv_fab_meta_cd 
                            ,   us.faturamento_numero_dias_qtde
                            ,   us.faturamento_data_limite
                            ,   c.competencia_data_ini
                            ,   c.competencia_data_fim                            
                FROM 		tbsistema_operacional us
                INNER JOIN  tbcompetencia c on c.competencia_cd = us.competencia_cd
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
                faturamento_data_limite: clsTools._datemomentDateToStr(clsTools._datemomentDatStrToDate(item.faturamento_data_limite, "YYYY-MM-DD HH:mm:ss"), "YYYY-MM-DD"),
                data_competencia_ini: clsTools._datemomentDateToStr(clsTools._datemomentDatStrToDate(item.competencia_data_ini, "YYYY-MM-DD HH:mm:ss"), "YYYY-MM-DD"),
                data_competencia_fim: clsTools._datemomentDateToStr(clsTools._datemomentDatStrToDate(item.competencia_data_fim, "YYYY-MM-DD HH:mm:ss"), "YYYY-MM-DD")
            }
            
            
            return dados;
        } catch (e) {
            await clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemaOperacional.getDefault', e);
        }
    }

}