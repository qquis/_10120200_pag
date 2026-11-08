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
const f0210_01_notificacao_send_crud_1 = __importDefault(require("../scriptdb/f0210_01_notificacao_send_crud"));
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const model_1 = require("../../../model/model");
class tbnotificacao_send extends model_1.modelTb {
    //notificacao_send_message?: tbnotificacao_send_message
    constructor(notificacao_send_seq) {
        super();
        try {
            this.dtlog_insert = new Date();
            this.dtlog_update = new Date();
            this.proc_log_seq = 0;
            this.notificacao_cd = 0;
            this.notificacao_send_seq = notificacao_send_seq;
            this.notificacao_send_data = new Date();
            this.notificacao_send_tipo_cd = 0;
            this.notificacao_send_status_cd = 0;
            this.notificacao_whatsapp = 0;
            this.notificacao_mail = 0;
            this.notificacao_celular_dd_numero = "";
            this.notificacao_email = "";
            this.notificacao_email_cc = '';
            this.notificacao_email_co = '';
            this.notificacao_email_subject = '';
            this.notificacao_email_title = '';
            this.notificacao_whatsapp_gp = 0;
            this.notificacao_mk_cd = 0;
            //this.notificacao_send_message = new tbnotificacao_send_message(new Date('1900-01-01'), 0, 0, '')
        }
        catch (e) {
            this.dtlog_insert = new Date();
            this.dtlog_update = new Date();
            this.proc_log_seq = 0;
            this.notificacao_cd = 0;
            this.notificacao_send_seq = 0;
            this.notificacao_send_data = new Date();
            this.notificacao_send_tipo_cd = 0;
            this.notificacao_send_status_cd = 0;
            this.notificacao_whatsapp = 0;
            this.notificacao_mail = 0;
            this.notificacao_celular_dd_numero = "";
            this.notificacao_email = `suporte@oxan.com.br`;
            //this.notificacao_send_message = new tbnotificacao_send_message(new Date("1900-01-01"),0,0,"");
            this.notificacao_email_cc = '';
            this.notificacao_email_co = '';
            this.notificacao_email_subject = '';
            this.notificacao_email_title = '';
            this.notificacao_whatsapp_gp = 0;
            this.notificacao_mk_cd = 0;
        }
    }
    _Db_Pg_script(_stringCommand) {
        const script = `Select * from ${f0210_01_notificacao_send_crud_1.default.sqlScript_VERSION()}
            (     vcommand_db:=                     '${_stringCommand}', 
                  vnotificacao_cd:=                 ${this.notificacao_cd},
                  vnotificacao_send_seq:=            ${this.notificacao_send_seq},
                  vnotificacao_send_data:=           '${Tools_1.default.format_Date_toStr_ShortDataBase(this.notificacao_send_data)}',
                  vnotificacao_send_tipo_cd:=        ${this.notificacao_send_tipo_cd ? this.notificacao_send_tipo_cd : 0},
                  vnotificacao_send_status_cd:=      ${this.notificacao_send_status_cd ? this.notificacao_send_status_cd : 1},
                  vproc_log_seq:=                    ${this.proc_log_seq ? this.proc_log_seq : 0},
                  vnotificacao_whatsapp:=            ${this.notificacao_whatsapp ? this.notificacao_whatsapp : 0},
                  vnotificacao_mail:=                ${this.notificacao_mail ? this.notificacao_mail : 0},
                  vnotificacao_celular_dd_numero:=   '${this.notificacao_celular_dd_numero ? this.notificacao_celular_dd_numero : '1127825227'}',
                  vnotificacao_email:=               '${this.notificacao_email ? this.notificacao_email : 'comunicacao@oxan.com.br'}',
                  vnotificacao_email_cc:=            '${this.notificacao_email_cc ? this.notificacao_email_cc : ''}',
                  vnotificacao_email_co:=            '${this.notificacao_email_co ? this.notificacao_email_co : ''}',
                  vnotificacao_email_subject:=       '${this.notificacao_email_subject ? this.notificacao_email_subject : ''}',
                  vnotificacao_email_title:=         '${this.notificacao_email_title ? this.notificacao_email_title : ''}',
                  vnotificacao_whatsapp_gp:=         ${this.notificacao_whatsapp_gp ? this.notificacao_whatsapp_gp : 0}, 
                  vnotificacao_mk_cd:=               ${this.notificacao_mk_cd ? this.notificacao_mk_cd : 0}
                )`;
        return script;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item !== undefined) {
                    this.notificacao_send_seq = item.notificacao_send_seq;
                    this.proc_log_seq = item.proc_log_seq;
                    this.notificacao_cd = item.notificacao_cd;
                    this.notificacao_send_data = item.notificacao_send_data;
                    this.notificacao_whatsapp = item.notificacao_whatsapp;
                    this.notificacao_whatsapp_gp = item.notificacao_whatsapp_gp;
                    this.notificacao_email = item.notificacao_email;
                    this.notificacao_send_status_cd = item.notificacao_send_status_cd;
                    this.notificacao_send_tipo_cd = item.notificacao_send_tipo_cd;
                    this.notificacao_celular_dd_numero = item.notificacao_celular_dd_numero;
                    this.notificacao_email = item.notificacao_email;
                    this.notificacao_email_subject = item.notificacao_email_subject;
                    this.notificacao_email_cc = item.notificacao_email_cc;
                    this.notificacao_email_co = item.notificacao_email_co;
                    this.notificacao_email_title = item.notificacao_email_title;
                    this.notificacao_mk_cd = item.notificacao_mk_cd;
                    //this.notificacao_send_message?.binding(item)
                }
            }
            catch (e) {
                throw `tbnotificacao_send | ${e}`;
            }
        });
    }
}
exports.default = tbnotificacao_send;
