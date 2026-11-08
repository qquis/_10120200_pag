"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class f0095_10_report_integracaoproduto {
    static sqlScript_VERSION() { return `f0095_10_1012003_report_integracaoproduto`; }
    static SELECT(filter) {
        let sqlscript = `Select * from ${this.sqlScript_VERSION()}
                ( 
                    vintegracao_cd:= '${filter.integracao_cd}' 
                ,   vintegracao_tipo_cd:= ${filter.integracao_tipo_cd}						
                ,   vintegracao_status_cd:= ${filter.integracao_status_cd}	
                , 	vpr_cdproduto:= ${filter.pr_cdproduto}	 	
                , 	vprb_cdprodutobluesoftunitario:= ${filter.prb_cdprodutobluesoftunitario}	 	
                , 	vprb_cdprodutobluesoft:= ${filter.prb_cdprodutobluesoft}	 	
                )`;
        console.log(sqlscript);
        return sqlscript;
    }
}
exports.default = f0095_10_report_integracaoproduto;
