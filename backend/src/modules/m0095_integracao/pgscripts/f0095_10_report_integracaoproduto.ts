import myTools from "../../../tools/Tools"
import { iIntegracaoProduto } from "../interfaces";



export default class f0095_10_report_integracaoproduto {
    public static sqlScript_VERSION(): string {return `f0095_10_1012003_report_integracaoproduto`}
    public static SELECT(filter: iIntegracaoProduto) : string {
                let sqlscript = `Select * from ${this.sqlScript_VERSION()}
                ( 
                    vintegracao_cd:= '${filter.integracao_cd}' 
                ,   vintegracao_tipo_cd:= ${filter.integracao_tipo_cd}						
                ,   vintegracao_status_cd:= ${filter.integracao_status_cd}	
                , 	vpr_cdproduto:= ${filter.pr_cdproduto}	 	
                , 	vprb_cdprodutobluesoftunitario:= ${filter.prb_cdprodutobluesoftunitario}	 	
                , 	vprb_cdprodutobluesoft:= ${filter.prb_cdprodutobluesoft}	 	
                )`;
        
         console.log(sqlscript)

         return sqlscript;
    }
}


