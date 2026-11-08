/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "ForcaVenda Meta - Processar"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ____________________________________________________________________________________________*/    

type f0005_20_fv_meta_processar_params = {
    competencia_cd: number;
};


export default class f0005_20_fv_meta_processar {
    public static _VERSION(): string {return `f0005_20_1012019_fv_meta_processar`}
    public static get(params: f0005_20_fv_meta_processar_params) : string {
        let sqlscript = `Select ${this._VERSION()}
                (    
        
                    vcompetencia_cd:= ${params.competencia_cd}


                ) `;
         return sqlscript;
    }
    public static info(): string {
        return `Script: ${FLG_MODULO} | Version: ${this._VERSION()}`;
    }
}


