"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class f0070_21_faturamento_processar {
    static version() { return `f0070_21_1012010_faturamento_processar`; }
    static get(parametro) {
        return `
            SELECT * FROM ${this.version()} 
            (
                    vfaturamento_controle_seq:= ${parametro.faturamento_controle_seq}		
                ,	vop_cdoperacao:= ${parametro.op_cdoperacao} 					
                ,	vnumeropedido:= ${parametro.numeropedido} 					
                ,	vdf_nf_seq_blue:= ${parametro.df_nf_seq_blue} 				
                ,	vsat_ecf:=  ${parametro.sat_ecf}						
                ,	vcupomfiscal:= ${parametro.cupomfiscal}					
                ,	vcdpessoabluesoft_cliente:= ${parametro.cdpessoabluesoft_cliente}	
            )
        `;
    }
}
exports.default = f0070_21_faturamento_processar;
