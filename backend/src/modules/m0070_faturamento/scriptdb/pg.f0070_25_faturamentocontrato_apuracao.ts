import model_faturamento_controle from '../model/model_faturamento_controle';
import { clsTools } from '../../../model/modelbase';
export default class f0070_25_faturamentocontrato_apuracao {
    static version () : string { return `f0070_30_1012019_faturamentocontrato_apuracao`}
    static get(parametro : any) : string { 
        const sql =  `
            SELECT * FROM ${this.version()} 
            (
                    VCOMPETENCIA_CD:= ${parametro.competencia_cd}		
                ,	VCONTRATO_SEQ:= ${parametro.contrato_seq}					
                    		
            
            )
        `
        
        return sql;        
        

    }
}