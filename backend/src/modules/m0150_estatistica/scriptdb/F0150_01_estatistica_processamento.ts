import { clsTools} from '../../../model/modelbase';

type f0150_01_estatistica_processamento_parms = {
    dataFaturamento_ini?: Date, 
    dataFaturamento_fim?: Date,
    vprocessamento_parcial: number
    [key: string]: any


}

export default class f0150_01_estatistica_processamento {
    static version () : string { return `f0150_01_1012018_estatistica_processamento`}
    static get(parametro: any = {}) : string { 
        const sql =  `
            SELECT * FROM ${this.version()} (
                dataFaturamento_ini:= '${parametro.dataFaturamento_ini ? clsTools._datemomentDateToStr(parametro.dataFaturamento_ini, "YYYY-MM-DD") : '1900-01-01'}',
                dataFaturamento_fim:= '${parametro.dataFaturamento_fim ? clsTools._datemomentDateToStr(parametro.dataFaturamento_fim, "YYYY-MM-DD") : '1900-01-01'}',
                vprocessamento_parcial:= ${parametro.vprocessamento_parcial ? parametro.vprocessamento_parcial : 1}
            )
        `
        
        return sql;        
        

    }
}