"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class tbnotificacao_send_message {
    constructor(dtlog_insert, notificacao_send_seq, notificacao_send_message_seq, notificacao_send_message) {
        this.dtlog_insert = dtlog_insert;
        this.notificacao_send_seq = notificacao_send_seq;
        this.notificacao_send_message_seq = notificacao_send_message_seq;
        this.notificacao_send_message = notificacao_send_message;
    }
    binding(item) {
        try {
            if (item !== undefined) {
                this.dtlog_insert = item.dtlog_insert;
                this.notificacao_send_seq = item.notificacao_send_seq;
                this.notificacao_send_message_seq = item.notificacao_send_message_seq;
                this.notificacao_send_message = item.notificacao_send_message;
            }
        }
        catch (e) {
        }
    }
}
exports.default = tbnotificacao_send_message;
