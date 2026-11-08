"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class f0070_23_faturamentoitem_processar {
    static version() { return `f0070_23_1012019_faturamentoitem_processar`; }
    static get(parametro) {
        const sql = `
            SELECT * FROM ${this.version()} 
            (
                    vfaturamento_controle_seq:= ${parametro.faturamento_controle_seq}
                ,	vnumeropedido:= ${parametro.numeropedido}
                ,   vnumeropedido_fv:= ${parametro.numeropedido_fv}
                ,	vcdpessoabluesoft_cliente:= ${parametro.cdpessoabluesoft_cliente}
                ,   vop_cdoperacao:= ${parametro.op_cdoperacao}
                ,   vdf_nf_seq_blue:= ${parametro.df_nf_seq_blue}
            );
        `;
        return sql;
    }
}
exports.default = f0070_23_faturamentoitem_processar;
