"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbnotificacao_send_1 = __importDefault(require("../tbs/tbnotificacao_send"));
const tbnotificacao_send_message_1 = __importDefault(require("../tbs/tbnotificacao_send_message"));
const Tools_1 = __importDefault(require("../../../tools/Tools"));
class mdNotificacaoSendMessage extends tbnotificacao_send_1.default {
    constructor(notificacao_send_seq) {
        super(notificacao_send_seq);
        this.notificacao_send_message = new tbnotificacao_send_message_1.default(new Date('1900-01-01'), 0, 0, '');
    }
    bindingMd(item) {
        const _super = Object.create(null, {
            binding: { get: () => super.binding }
        });
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield _super.binding.call(this, item);
                this.notificacao_send_message.binding(item);
            }
            catch (e) {
                Tools_1.default.PagErrorException('mdNotificacaoSendMessage', 'bindingMd', e);
            }
        });
    }
    NotificacaoSendGet(request) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (request !== undefined) {
                    this.notificacao_send_seq = parseInt(`${request.query.notificacao_send_seq}`);
                }
            }
            catch (e) {
                console.log(`ModelTbNoficiacao getNotificacaoSendSeqFromQuery Get error \n ${e}`);
            }
        });
    }
    SetMessage(message) {
        this.notificacao_send_message = new tbnotificacao_send_message_1.default(new Date('1900-01-01'), 0, 0, `${message}`);
    }
    getModelFromRequest(request) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (request !== undefined) {
                    this.notificacao_send_seq = parseInt(`${request.body.notificacao_send_seq}`);
                    this.notificacao_cd = parseInt(`${request.body.notificacao_cd}`);
                    this.notificacao_send_data = Tools_1.default.Date_br_new(`${request.body.notificacao_send_data}`);
                    this.notificacao_send_tipo_cd = parseInt(`${request.body.notificacao_send_tipo_cd}`);
                    this.notificacao_send_status_cd = parseInt(`${request.body.notificacao_send_status_cd}`);
                    this.proc_log_seq = parseInt(`${request.body.proc_log_seq}`);
                    this.notificacao_whatsapp = parseInt(`${request.body.notificacao_whatsapp}`);
                    this.notificacao_whatsapp_gp = parseInt(`${request.body.notificacao_whatsapp_gp}`);
                    this.notificacao_mail = parseInt(`${request.body.notificacao_mail}`);
                    this.notificacao_celular_dd_numero = `${request.body.notificacao_celular_dd_numero}`;
                    this.notificacao_email = `${request.body.notificacao_email}`;
                    this.notificacao_email_cc = `${request.body.notificacao_email_cc}`;
                    this.notificacao_email_co = `${request.body.notificacao_email_co}`;
                    this.notificacao_email_subject = `${request.body.notificacao_email_subject}`;
                    this.notificacao_email_title = `${request.body.notificacao_email_title}`;
                    this.notificacao_send_message = new tbnotificacao_send_message_1.default(new Date('1900-01-01'), 0, 0, `${request.body.notificacao_send_message}`);
                }
            }
            catch (e) {
                console.log(`ModelTbNoficiacao Request Get error \n ${e}`);
            }
        });
    }
    MessageStart() {
        const _super = Object.create(null, {
            _Db_Pg_UPDATE: { get: () => super._Db_Pg_UPDATE }
        });
        return __awaiter(this, void 0, void 0, function* () {
            this.notificacao_send_status_cd = 10;
            yield _super._Db_Pg_UPDATE.call(this);
        });
    }
    MessageSend() {
        const _super = Object.create(null, {
            _Db_Pg_UPDATE: { get: () => super._Db_Pg_UPDATE }
        });
        return __awaiter(this, void 0, void 0, function* () {
            this.notificacao_send_status_cd = 30;
            yield _super._Db_Pg_UPDATE.call(this);
        });
    }
    MessageSetError() {
        const _super = Object.create(null, {
            _Db_Pg_UPDATE: { get: () => super._Db_Pg_UPDATE }
        });
        return __awaiter(this, void 0, void 0, function* () {
            this.notificacao_send_status_cd = 90;
            yield _super._Db_Pg_UPDATE.call(this);
        });
    }
}
exports.default = mdNotificacaoSendMessage;
