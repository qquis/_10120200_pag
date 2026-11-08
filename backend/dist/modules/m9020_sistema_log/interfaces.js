"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.isistemaLog_Constructor = void 0;
class isistemaLog_Constructor {
    static byfromRequest(request) {
        let _isistema_log;
        let sis_log_seq = 0;
        let proc_log_seq = 0;
        let sis_nucleo_prc_cd = 0;
        let sis_log_tag = ``;
        let sis_log_info = ``;
        let sis_batch_run_seq = 0;
        if (request.query.sis_log_seq)
            sis_log_seq = parseInt(`${request.query.sis_log_seq}`);
        if (request.query.proc_log_seq)
            sis_log_seq = parseInt(`${request.query.proc_log_seq}`);
        if (request.query.sis_nucleo_prc_cd)
            sis_nucleo_prc_cd = parseInt(`${request.query.sis_nucleo_prc_cd}`);
        if (request.query.sis_log_tag)
            sis_log_tag = request.query.sis_log_tag.toString().replace("'", "");
        if (request.query.sis_log_info)
            sis_log_info = request.query.sis_log_info.toString().replace("'", "");
        if (request.query.sis_batch_run_seq)
            sis_batch_run_seq = parseInt(`${request.query.sis_batch_run_seq}`);
        _isistema_log = {
            sis_log_seq: sis_log_seq,
            proc_log_seq: proc_log_seq,
            sis_nucleo_prc_cd: sis_nucleo_prc_cd,
            sis_log_tag: sis_log_tag,
            sis_log_info: sis_log_info,
            sis_batch_run_seq: sis_batch_run_seq
        };
        return _isistema_log;
    }
}
exports.isistemaLog_Constructor = isistemaLog_Constructor;
