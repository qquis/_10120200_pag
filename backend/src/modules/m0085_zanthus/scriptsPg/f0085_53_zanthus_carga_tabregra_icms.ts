/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - SCRIPT | f0085_53_zanthus_carga_tabregra_icms"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ____________________________________________________________________________________________*/    


import { clsTools } from "../../../model/modelbase";
export default class f0085_53_zanthus_carga_regra_icms {
    public static sqlScript_VERSION(): string {return `f0085_53_1012020_zanthus_carga_regra_icms`}
    public static ScriptExecute() : string {
        let sqlscript = `Select ${this.sqlScript_VERSION()}() `;
         return sqlscript;
    }
    public static info(): string {
        return `Script: ${FLG_MODULO} | Version: ${this.sqlScript_VERSION()}`;
    }
}


