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
const modelbase_1 = require("../../../model/modelbase");
const mdNotificacaoSend_1 = __importDefault(require("../model/mdNotificacaoSend"));
const f0210_03_notificacao_send_message_list_1 = __importDefault(require("../scriptdb/f0210_03_notificacao_send_message_list"));
class rptNotificacaoSendMessage extends modelbase_1.clsBase {
    constructor() {
        super();
        this.list = [];
        this.data = {};
    }
    dataBinding(result) {
        return __awaiter(this, void 0, void 0, function* () {
            this.list = [];
            try {
                for (const [Key, value] of Object.entries(result)) {
                    let i = new mdNotificacaoSend_1.default(0);
                    yield i.bindingMd(value);
                    this.list.push(i);
                }
            }
            catch (e) {
                this.myTools.PagErrorException('rptNotificacaoSendMessage', 'dataBinding', e);
            }
        });
    }
    sql(filter) {
        let sql = ``;
        try {
            sql = `Select * from ${f0210_03_notificacao_send_message_list_1.default.sqlScript_VERSION()}
            (       ${filter.notificacao_send_seq}, 
                   '${this.myTools._datemomentDateToStr(filter.notificacao_send_data_ini, `YYYY-MM-DD`)}', 
                   '${this.myTools._datemomentDateToStr(filter.notificacao_send_data_fim, `YYYY-MM-DD`)}', 
                   ${filter.notificacao_send_status_cd}, 
                   ${filter.notificacao_send_tipo_cd}, 
                  '${filter.notificacao_celular_dd_numero}', 
                  '${filter.notificacao_email}',
                   ${filter.notificacao_whatsapp}, 
                   ${filter.notificacao_mail},
                   ${filter.notificacao_whatsapp_gp}
            )`;
        }
        catch (e) {
            this.myTools.PagErrorException('rptNotificacaoSendMessage', 'sql', e);
        }
        finally {
            return sql;
        }
    }
}
exports.default = rptNotificacaoSendMessage;
