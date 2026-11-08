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
//import DataBase from "../../../database/DataBase";
//import myTools from "../../../tools/Tools";
const modelbase_1 = require("../../../model/modelbase");
const mdNotificacao_1 = __importDefault(require("./mdNotificacao"));
const mdNotificacaoParticipante_1 = __importDefault(require("./mdNotificacaoParticipante"));
const mdNotificacaoSend_1 = __importDefault(require("./mdNotificacaoSend"));
//const myDataBase = new DataBase()
class modelNotificacao extends modelbase_1.clsBase {
    constructor() {
        super();
        this.notificacao = new mdNotificacao_1.default();
        this.NotificacaoSendMessage = [];
        this.Participantes = [];
    }
    NotificacaoAddParticipante(cdparticipante) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = `INSERT INTO tbnotificacao_participante (notificacao_cd, cdparticipante) 
                        SELECT ${this.notificacao.notificacao_cd}, ${cdparticipante}
                    where not exists (
                            SELECT 1 FROM tbnotificacao_participante 
                            WHERE notificacao_cd = ${this.notificacao.notificacao_cd}
                            AND cdparticipante = ${cdparticipante}
                        )    
                `;
            try {
                yield this.myDataBase.pag.Execute(sql);
            }
            catch (e) {
                this.myTools.PagErrorException('model_notificacao', 'addParticipante', e);
            }
        });
    }
    NotificaoDelParticipante(cdparticipante) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = `DELETE FROM tbnotificacao_participante 
                        WHERE notificacao_cd = ${this.notificacao.notificacao_cd}
                        AND cdparticipante = ${cdparticipante}`;
            try {
                yield this.myDataBase.pag.Execute(sql);
            }
            catch (e) {
                this.myTools.PagErrorException('model_notificacao', 'delParticipante', e);
            }
        });
    }
    NotificacaoParticipantesBinding() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.Participantes = [];
                let sql = `SELECT   p.cdparticipante
                        ,    p.nome_razao 
                        ,    coalesce(p.email_main, '') as email_main
                        ,    cast(coalesce(p.celular_dd,'0') as varchar(2)) as celular_dd
                        ,    cast(coalesce(p.celular_numero,0) as varchar(20)) as celular_numero
                        ,    cast(0 as int) as isGroup
                  FROM          tbnotificacao_participante i 
                  INNER JOIN    tbparticipante p on p.cdparticipante = i.cdparticipante
                    WHERE       i.notificacao_cd = ${this.notificacao.notificacao_cd}
                    
                    UNION
                SELECT		0 as cdparticipante
                        ,	'GRUPO' as nome_razao
                        ,	'suporte@oxan.com.br' as email_main
                        ,	cast('' as varchar(2))  as celular_dd
                        ,	cast(notificacao_gp_whats as varchar(20)) as celular_numero
                        ,	cast(1 as int) as isGroup
                from 		tbnotificacao_grupo g
                where		g.notificacao_cd  = ${this.notificacao.notificacao_cd}
                    
                    
                    
                    
                    `;
                let result = yield this.myDataBase.pag.DataGet(sql);
                for (const [key, value] of Object.entries(result)) {
                    let item = new mdNotificacaoParticipante_1.default();
                    item.bindingMd(value);
                    this.Participantes.push(item);
                }
            }
            catch (e) {
                this.myTools.PagErrorException('model_notificacao', 'NotificacaoGetParticipantes', e);
            }
        });
    }
    Notificar(itemNotificacaoSendMessage) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a;
            try {
                let PROCESSOLOG = yield this.ProcessoLogGerar(99901, 1);
                itemNotificacaoSendMessage.notificacao_cd = this.notificacao.notificacao_cd;
                itemNotificacaoSendMessage.notificacao_send_status_cd = 1;
                itemNotificacaoSendMessage.proc_log_seq = PROCESSOLOG;
                yield itemNotificacaoSendMessage.__CRUD();
                yield this.myDataBase.pag.Execute(`
                                INSERT INTO tbnotificacao_send_message (notificacao_send_seq, notificacao_send_message) 
                                VALUES (    ${itemNotificacaoSendMessage.notificacao_send_seq}
                                        ,   '${(_a = itemNotificacaoSendMessage.notificacao_send_message) === null || _a === void 0 ? void 0 : _a.notificacao_send_message}'
                                        )`);
                if (!itemNotificacaoSendMessage.notificacao_celular_dd_numero && !itemNotificacaoSendMessage.notificacao_email) {
                    yield itemNotificacaoSendMessage.MessageSetError();
                }
            }
            catch (e) {
                this.myTools.PagErrorException('model_notificacao', 'Notificar', e);
            }
        });
    }
    ProcessNotificacaoSend(notificacao_send_seq, process) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let itemNotificacaoSendMessage = new mdNotificacaoSend_1.default(notificacao_send_seq);
                switch (process) {
                    case modelNotificacao.NotificacaoSendProcessStatus.start:
                        yield itemNotificacaoSendMessage.MessageStart();
                        break;
                    case modelNotificacao.NotificacaoSendProcessStatus.send:
                        yield itemNotificacaoSendMessage.MessageSend();
                        break;
                }
            }
            catch (e) {
                this.myTools.PagErrorException('model_notificacao', 'NotificacaoSendStart', e);
            }
        });
    }
}
modelNotificacao.NotificacaoSendProcessStatus = {
    start: 10,
    send: 30,
};
exports.default = modelNotificacao;
