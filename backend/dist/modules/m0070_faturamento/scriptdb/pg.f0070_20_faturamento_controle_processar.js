"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class f0070_20_faturamento_controle_processar {
    static version() { return `f0070_20_1012017_faturamento_controle_processar`; }
    static get(parametro) {
        const sql = `
            SELECT * FROM ${this.version()} 
            (
                    vfat_controle_tipo_cd:= ${parametro.fat_controle_tipo_cd}		
                ,	vseqfaturamento_uuid:= '${parametro.seqfaturamento_uuid}' 					
                ,	vop_cdoperacao:= ${parametro.op_cdoperacao} 					
                ,	vnumeropedido:= ${parametro.numeropedido} 	
                ,   vnumeropedido_fv:= ${parametro.numeropedido_fv}
                ,   vdf_nf_seq_blue:= ${parametro.df_nf_seq_blue}			
                ,	vsat_ecf:=  ${parametro.sat_ecf}						
                ,	vcupomfiscal:= ${parametro.cupomfiscal}					
                ,	vcdpessoabluesoft_cliente:= ${parametro.cdpessoabluesoft_cliente}	
                ,   vreprocessaritem:= ${parametro.reprocessaritem ? 1 : 0}
            )
        `;
        return sql;
    }
}
exports.default = f0070_20_faturamento_controle_processar;
