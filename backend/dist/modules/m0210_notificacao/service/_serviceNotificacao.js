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
var __asyncValues = (this && this.__asyncValues) || function (o) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var m = o[Symbol.asyncIterator], i;
    return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i);
    function verb(n) { i[n] = o[n] && function (v) { return new Promise(function (resolve, reject) { v = o[n](v), settle(resolve, reject, v.done, v.value); }); }; }
    function settle(resolve, reject, d, v) { Promise.resolve(v).then(function(v) { resolve({ value: v, done: d }); }, reject); }
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const _ModelNotificacao_1 = __importDefault(require("../model/_ModelNotificacao"));
const modelbase_1 = require("../../../model/modelbase");
const mdNotificacaoSend_1 = __importDefault(require("../model/mdNotificacaoSend"));
class serviceNotificacao {
    static CriarNotificacaoNucleBatch(message) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.Criar({ notificacao_cd: 1009030001,
                notificacao_send_tipo_cd: 100,
                notificacao_send_message: message
            });
        });
    }
    static CriarMailBasico(to_email, subject, title, message) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.Criar({ notificacao_cd: 1000000009,
                notificacao_send_tipo_cd: 110,
                notificacao_email: to_email,
                notificacao_email_subject: subject,
                notificacao_email_title: title,
                notificacao_send_message: message
            });
        });
    }
    static Criar(dados) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let mycls = new serviceNotificacao();
                let result = yield this.GerarEnvio(dados.notificacao_cd, dados, dados);
                return result;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('serviceNotificacao', 'Criar', e);
                throw new Error(`${e}`);
            }
        });
    }
    static GerarEnvio(notificacao_cd, parametros, body) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c, _d, e_2, _e, _f;
            let myNotificacao = new _ModelNotificacao_1.default();
            try {
                /*Abrir registro*/
                yield myNotificacao.notificacao.NotificacaoGet(notificacao_cd);
                /*Obter os destinatarios*/
                yield myNotificacao.NotificacaoParticipantesBinding();
                /* GERANDO AS NOTIFICAÇÕES */
                if (myNotificacao.Participantes.length == 0) {
                    yield myNotificacao.NotificacaoSendMessage.push(yield this.processar(myNotificacao, parametros, body, {}));
                }
                else {
                    try {
                        for (var _g = true, _h = __asyncValues(myNotificacao.Participantes), _j; _j = yield _h.next(), _a = _j.done, !_a; _g = true) {
                            _c = _j.value;
                            _g = false;
                            const ParticipanteDestinatario = _c;
                            yield myNotificacao.NotificacaoSendMessage.push(yield this.processar(myNotificacao, parametros, body, ParticipanteDestinatario));
                        }
                    }
                    catch (e_1_1) { e_1 = { error: e_1_1 }; }
                    finally {
                        try {
                            if (!_g && !_a && (_b = _h.return)) yield _b.call(_h);
                        }
                        finally { if (e_1) throw e_1.error; }
                    }
                    ;
                }
                try {
                    /* NOTIFICANDO O ARRAYS DAS NOTIFICAÇÕES GERADAS */
                    for (var _k = true, _l = __asyncValues(myNotificacao.NotificacaoSendMessage), _m; _m = yield _l.next(), _d = _m.done, !_d; _k = true) {
                        _f = _m.value;
                        _k = false;
                        const itemNotificacaoSendMessage = _f;
                        yield myNotificacao.Notificar(itemNotificacaoSendMessage);
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_k && !_d && (_e = _l.return)) yield _e.call(_l);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
                return myNotificacao;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('serviceNotificacao', 'GerarEnvio', e);
                return myNotificacao;
            }
        });
    }
    static processar(myNotificacao, parametros, infoDados, ParticipanteDestinatario) {
        return __awaiter(this, void 0, void 0, function* () {
            let myClsBase = new modelbase_1.clsBase();
            let dadosNOTIFICACAO;
            try {
                let itemNotificacaoSendMessage = new mdNotificacaoSend_1.default(0);
                itemNotificacaoSendMessage.notificacao_send_tipo_cd = infoDados.notificacao_send_tipo_cd;
                /* Enviar para o e-mail/celular indicado no bory prioritariamente caso contrário enviar para o e-mail do participante*/
                itemNotificacaoSendMessage.notificacao_email = infoDados.notificacao_email ? infoDados.notificacao_email : ParticipanteDestinatario.email_main;
                itemNotificacaoSendMessage.notificacao_celular_dd_numero = infoDados.notificacao_celular_dd_numero ? infoDados.notificacao_celular_dd_numero : this.CelularNumeroGet(ParticipanteDestinatario);
                //console.log(`E-mail infodados ${infoDados.notificacao_email} E-mail part ${ParticipanteDestinatario.email_main} Email Registrado ${itemNotificacaoSendMessage.notificacao_email}`)
                //console.log(ParticipanteDestinatario)
                if (ParticipanteDestinatario) {
                    if (ParticipanteDestinatario.isgroup == 1) {
                        itemNotificacaoSendMessage.notificacao_whatsapp_gp = 1;
                    }
                }
                itemNotificacaoSendMessage.notificacao_email_subject = infoDados.notificacao_email_subject;
                itemNotificacaoSendMessage.notificacao_email_title = infoDados.notificacao_email_title;
                itemNotificacaoSendMessage.notificacao_email_cc = infoDados.notificacao_email_cc;
                itemNotificacaoSendMessage.notificacao_email_co = infoDados.notificacao_email_co;
                /* Tratamento da Mensagem */
                let MESSAGE = ``;
                if (myNotificacao.notificacao.notificacao_tipo_body_cd == 1)
                    if (myNotificacao.notificacao.notificacao_whats_user_show == 1) {
                        MESSAGE = `Olá, ${ParticipanteDestinatario.nome_razao}.\n\n` + infoDados.notificacao_send_message;
                    }
                    else {
                        MESSAGE = infoDados.notificacao_send_message;
                    }
                itemNotificacaoSendMessage.SetMessage(infoDados.notificacao_send_message);
                if (myNotificacao.notificacao.notificacao_tipo_body_cd == 2) {
                    let result = yield myClsBase.myDataBase.pag.DataGet(`SELECT * FROM ${myNotificacao.notificacao.notificacao_sql} (cdparticipante:= ${ParticipanteDestinatario.cdparticipante})`);
                    MESSAGE = JSON.stringify(result);
                }
                if (myClsBase.ENVIRONMENT_CLASS == 'DES' && itemNotificacaoSendMessage.notificacao_whatsapp == 1) {
                    MESSAGE = `- TESTE DESENVOL - ` + MESSAGE;
                }
                itemNotificacaoSendMessage.SetMessage(MESSAGE);
                /* _____________________________________________________________________ */
                if (myNotificacao.notificacao.notificacao_cd == 10) {
                    itemNotificacaoSendMessage.notificacao_whatsapp = 1;
                    itemNotificacaoSendMessage.notificacao_send_tipo_cd = parametros.notificacao_send_tipo_cd;
                    itemNotificacaoSendMessage.notificacao_email = parametros.notificacao_email;
                    itemNotificacaoSendMessage.notificacao_celular_dd_numero = parametros.notificacao_celular_dd_numero;
                    itemNotificacaoSendMessage.SetMessage(parametros.notificacao_send_message);
                }
                return itemNotificacaoSendMessage;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('serviceNotificacao', 'processar', e);
                throw new Error(`${e}`);
            }
        });
    }
    static CelularNumeroGet(ParticipanteDestinatario) {
        return `${ParticipanteDestinatario.celular_dd}${ParticipanteDestinatario.celular_numero}`;
    }
    static MessageWhatsTeste(send_tipo_cd, celular_dd_numero, message) {
        return __awaiter(this, void 0, void 0, function* () {
            let result;
            try {
                result = yield this.Criar({
                    notificacao_cd: 10,
                    notificacao_send_tipo_cd: send_tipo_cd,
                    notificacao_email: "",
                    notificacao_email_subject: "",
                    notificacao_email_title: "",
                    notificacao_celular_dd_numero: parseInt(celular_dd_numero),
                    notificacao_send_message: message
                });
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('serviceNotificacao', 'MessageTeste', e);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = serviceNotificacao;
