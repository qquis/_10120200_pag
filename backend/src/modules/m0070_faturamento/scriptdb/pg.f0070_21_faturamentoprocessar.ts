import model_faturamento_controle from '../model/model_faturamento_controle';
export default class f0070_21_faturamento_processar {
    static version () : string { return `f0070_21_1012019_faturamento_processar`}
    static get(parametro: any) : string { 
        const sql =  `
            SELECT * FROM ${this.version()} 
            (
                   vdata_processamento:= '${parametro.data_processamento}'
            )
        `
        
        return sql;        
        

    }
}