import { clsBase, clsTools } from '../../../model/modelbase';

export default class reportFaturamentoContrato {
    public static sql(parametro : any) : string {
        let sql = 
        
         `	select f.contrato_seq
                ,  f.contrato_descricao 
                ,  t.contrato_tipo_descricao 
                ,  f.contrato_data
                ,  f.contrato_tipo_cd
                ,  f.contrato_data_val_ini
                ,  f.contrato_data_val_fim
                ,  f.op_cdoperacao
                ,  f.cdparticipante_contratante
                ,  f.seqfaturamento
                ,  f.seqfaturamentoorigem
                ,  f.faturamento_controle_seq
                ,  f.contrato_valor
                ,  f.contrato_uuid
                ,  l.numeropedido_fv
                ,  l.numeropedido
                ,  l.numeronfe
                ,  f.contrato_status
            from   tbfaturamentocontrato f
            left join tbfaturamentocontrato_tipo t on t.contrato_tipo_cd = f.contrato_tipo_cd
            left join tbfaturamento_controle l 
                    on l.faturamento_controle_seq = f.faturamento_controle_seq
            where 1 = 1
        `
        if (parametro.competencia_cd) {
            sql += ` and f.competencia_cd = ${parametro.competencia_cd}`;
        }
        if (parametro.contrato_status && parseInt(parametro.contrato_status) !== 9) {
            sql += ` and f.contrato_status = ${parametro.contrato_status}`;
        }

        if (parametro.contrato_seq) {
            sql += ` and f.contrato_seq = ${parametro.contrato_seq}`;
        }

        if (parametro.contrato_data_val_ini) { 
            sql += ` and f.contrato_data_val_ini >= '${parametro.contrato_data_val_ini}'
                     and f.contrato_data_val_ini <= '${parametro.contrato_data_val_fim}'
            
            `;
        }
        if (parametro.contrato_data_val_fim) { 
            sql += ` and f.contrato_data_val_fim >= '${parametro.contrato_data_val_ini}'
                     and f.contrato_data_val_fim <= '${parametro.contrato_data_val_fim}'
            
            `;
        }

        if (parametro.contrato_tipo_cd && parseInt(parametro.contrato_tipo_cd) !== 0) { 
            sql += ` and f.contrato_tipo_cd = ${parametro.contrato_tipo_cd}`;
        }

        
            return sql
    }

    public static async get(filter : any) : Promise<object> {
        let result = { }
        try {
            
            result = await new clsBase().myDataBase.pag.DataGet( this.sql(filter));

            
            
        } catch (e) {
            clsTools.pagConsole(`reportFaturamentoStatus | get \n Error: ${e}`);
        
        } finally {
            
            return result
        }
    }   

}
