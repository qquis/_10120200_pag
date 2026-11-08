"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
/*  CONSTANTES _________________________________________________________________________________*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0085 ZANTHUS - SCRIPT | f0005_30_fv_meta_fab_processar";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
class f0005_30_fv_meta_fab_processar {
    static _VERSION() { return `f0005_30_1012019_fv_meta_fab_processar`; }
    static get(params) {
        let sqlscript = `Select ${this._VERSION()}
                (    
        
                    vfv_fab_meta_cd:= ${params.fv_fab_meta_cd}


                ) `;
        return sqlscript;
    }
    static info() {
        return `Script: ${FLG_MODULO} | Version: ${this._VERSION()}`;
    }
}
exports.default = f0005_30_fv_meta_fab_processar;
