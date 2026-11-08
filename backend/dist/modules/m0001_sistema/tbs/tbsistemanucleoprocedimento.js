"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class tbsistemanucleoprocedimento {
    constructor() {
        this.sis_nucleo_cd_fk = 0;
        this.sis_nucleo_prc_cd = 0;
        this.sis_nucleo_prc_descricao = '';
        this.sis_nucleo_prc_tipo = 0;
        this.data_reprocessamento_default = new Date();
        this.data_reprocessamento_default_fim = new Date();
        this.dateadd_ini = 0;
        this.dateadd_fim = 0;
        this.data_default_ini = 0;
        this.data_default_fim = 0;
        this.permite_execucao_manual = 0;
        this.notificacao_cd = 0;
        this.limite_reg_bloq_update = 0;
    }
    binding(item) {
        if (item) {
            this.sis_nucleo_cd_fk = item === null || item === void 0 ? void 0 : item.sis_nucleo_cd_fk;
            this.sis_nucleo_prc_cd = item === null || item === void 0 ? void 0 : item.sis_nucleo_prc_cd;
            this.sis_nucleo_prc_descricao = item === null || item === void 0 ? void 0 : item.sis_nucleo_prc_descricao;
            this.sis_nucleo_prc_tipo = item === null || item === void 0 ? void 0 : item.sis_nucleo_prc_tipo;
            this.data_reprocessamento_default = item === null || item === void 0 ? void 0 : item.data_reprocessamento_default;
            this.data_reprocessamento_default_fim = item === null || item === void 0 ? void 0 : item.data_reprocessamento_default_fim;
            this.dateadd_ini = item === null || item === void 0 ? void 0 : item.dateadd_ini;
            this.dateadd_fim = item === null || item === void 0 ? void 0 : item.dateadd_fim;
            this.data_default_ini = item === null || item === void 0 ? void 0 : item.data_default_ini;
            this.data_default_fim = item === null || item === void 0 ? void 0 : item.data_default_fim;
            this.permite_execucao_manual = item === null || item === void 0 ? void 0 : item.permite_execucao_manual;
            this.notificacao_cd = item === null || item === void 0 ? void 0 : item.notificacao_cd;
            this.limite_reg_bloq_update = item === null || item === void 0 ? void 0 : item.limite_reg_bloq_update;
        }
    }
    static sqlSelectLimiteRegBloqUpdate(sis_nucleo_prc_cd) {
        let sql = `SELECT coalesce(limite_reg_bloq_update,0) as limite_reg_bloq_update 
                        FROM tbsistema_nucleo_procedimento 
                        WHERE sis_nucleo_prc_cd = ${sis_nucleo_prc_cd}`;
        return sql;
    }
}
exports.default = tbsistemanucleoprocedimento;
