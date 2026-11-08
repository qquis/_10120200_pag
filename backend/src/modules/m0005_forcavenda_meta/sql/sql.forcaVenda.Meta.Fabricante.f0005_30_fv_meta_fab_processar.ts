/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - SCRIPT | f0005_30_fv_meta_fab_processar"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ____________________________________________________________________________________________*/    

type f0005_30_fv_meta_fab_processar_params = {
    fv_fab_meta_cd: string;
};


export default class f0005_30_fv_meta_fab_processar {
    public static _VERSION(): string {return `f0005_30_1012019_fv_meta_fab_processar`}
    public static get(params: f0005_30_fv_meta_fab_processar_params) : string {
        let sqlscript = `Select ${this._VERSION()}
                (    
        
                    vfv_fab_meta_cd:= ${params.fv_fab_meta_cd}


                ) `;
         return sqlscript;
    }
    public static info(): string {
        return `Script: ${FLG_MODULO} | Version: ${this._VERSION()}`;
    }
}


