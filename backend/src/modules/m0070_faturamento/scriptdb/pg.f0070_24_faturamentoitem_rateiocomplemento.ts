import model_faturamento_controle from '../model/model_faturamento_controle';
export default class f0070_24_faturamentoitem_rateiocomplemento {
    static version () : string { return `f0070_24_1012019_faturamentoitem_rateiocomplemento`}
    static get(parametro: any) : string { 
        const sql =  `
            SELECT ${this.version()} 
            (
                    vfaturamento_controle_seq:= ${parametro.faturamento_controle_seq}
                ,	vnumeropedido:= ${parametro.numeropedido}
                ,   vnumeropedido_fv:= ${parametro.numeropedido_fv}
                ,	vcdpessoabluesoft_cliente:= ${parametro.cdpessoabluesoft_cliente}
                ,   vop_cdoperacao:= ${parametro.op_cdoperacao}
                ,   vdf_nf_seq_blue:= ${parametro.df_nf_seq_blue}
            );
        `

        return sql;        
        

    }
}