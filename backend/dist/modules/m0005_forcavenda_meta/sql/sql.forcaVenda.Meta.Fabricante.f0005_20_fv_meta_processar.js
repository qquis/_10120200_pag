"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
/*  CONSTANTES _________________________________________________________________________________*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "ForcaVenda Meta - Processar";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
class f0005_20_fv_meta_processar {
    static _VERSION() { return `f0005_20_1012019_fv_meta_processar`; }
    static get(params) {
        let sqlscript = `Select ${this._VERSION()}
                (    
        
                    vcompetencia_cd:= ${params.competencia_cd}


                ) `;
        return sqlscript;
    }
    static info() {
        return `Script: ${FLG_MODULO} | Version: ${this._VERSION()}`;
    }
}
exports.default = f0005_20_fv_meta_processar;
