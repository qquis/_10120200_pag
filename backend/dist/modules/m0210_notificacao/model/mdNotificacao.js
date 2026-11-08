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
const DataBase_1 = __importDefault(require("../../../database/DataBase"));
//tbs
const tbnotificacao_1 = __importDefault(require("../tbs/tbnotificacao"));
const myDataBase = new DataBase_1.default();
class mdNotificacao extends tbnotificacao_1.default {
    constructor() {
        super();
    }
    NotificacaoGet(notificacao_cd) {
        return __awaiter(this, void 0, void 0, function* () {
            if (notificacao_cd !== undefined) {
                let sql = ` SELECT  notificacao_cd
                            ,   notificacao_descricao
                            ,   notificacao_whatsapp
                            ,   notificacao_mail 
                            ,   notificacao_send_tipo_cd
                            ,   coalesce(notificacao_tipo_body_cd, 0) as notificacao_tipo_body_cd
                            ,   coalesce(notificacao_sql, '') as notificacao_sql
                            ,   coalesce(notificacao_whats_user_show, 0) as notificacao_whats_user_show
                        FROM    tbnotificacao WHERE notificacao_cd = ${notificacao_cd}`;
                let result = yield myDataBase.pag.DataGet(sql);
                this.binding(result[0]);
            }
        });
    }
}
exports.default = mdNotificacao;
