"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
/*  CONSTANTES _________________________________________________________________________________*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0085 ZANTHUS - SCRIPT | f0085_50_zanthus_carga_decomposicao";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
class f0085_50_zanthus_carga_decomposicao {
    static sqlScript_VERSION() { return `f0085_50_1012019_zanthus_carga_decomposicao`; }
    static ScriptExecute() {
        let sqlscript = `Select ${this.sqlScript_VERSION()}() `;
        return sqlscript;
    }
    static info() {
        return `Script: ${FLG_MODULO} | Version: ${this.sqlScript_VERSION()}`;
    }
}
exports.default = f0085_50_zanthus_carga_decomposicao;
