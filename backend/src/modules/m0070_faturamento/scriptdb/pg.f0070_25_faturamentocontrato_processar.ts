import model_faturamento_controle from '../model/model_faturamento_controle';
import { clsTools } from '../../../model/modelbase';
export default class f0070_25_faturamentocontrato_processar {
    static version () : string { return `f0070_25_1012019_faturamentocontrato_processamento`}
    static get(parametro : any) : string { 
        const sql =  `
            SELECT * FROM ${this.version()} 
            (
                    vfaturamento_controle_seq:= ${parametro.faturamento_controle_seq}		
                ,	vcontrato_seq:= ${parametro.contrato_seq}					
                ,	vdata_val_ini:= '${clsTools._datemomentDateToStr(parametro.data_val_ini, "YYYY-MM-DD")}' 					
                ,	vdata_val_fim:= '${clsTools._datemomentDateToStr(parametro.data_val_fim, "YYYY-MM-DD")}'			
            
            )
        `
        
        return sql;        
        

    }
}