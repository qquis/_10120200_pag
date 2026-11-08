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
require("dotenv/config");
const modelbase_1 = require("../../../model/modelbase");
const modelUserLogin_1 = __importDefault(require("../model/modelUserLogin"));
const f0001_02_sistema_login_1 = __importDefault(require("../scriptdb/f0001_02_sistema_login"));
const mail_login_log_1 = __importDefault(require("../mail/mail_login_log"));
const mail_login_crm_credentialnumber_1 = __importDefault(require("../mail/mail_login_crm_credentialnumber"));
const myBase = new modelbase_1.clsBase();
class serviceSistemaLogin {
    static checkWjt(hash) {
        return __awaiter(this, void 0, void 0, function* () {
            const mymodelUserConnect = new modelUserLogin_1.default();
            try {
                mymodelUserConnect.autorizado = 0;
                let loginCheck = yield modelbase_1.clsTools.jwt.check(hash);
                if (loginCheck.data) {
                    mymodelUserConnect.sis_id = loginCheck.data.sis_id;
                    mymodelUserConnect.autorizado = 1;
                    mymodelUserConnect.sis_us_seq = loginCheck.data.sis_us_seq;
                    mymodelUserConnect.user_name = loginCheck.data.user_name;
                    mymodelUserConnect.sis_id = loginCheck.data.sis_id;
                    mymodelUserConnect.jwtExp = loginCheck.exp;
                    mymodelUserConnect.jwtIat = loginCheck.iat;
                    mymodelUserConnect.email_login = loginCheck.data.email_login ? loginCheck.data.email_login : ``;
                    mymodelUserConnect.usuario_login_uuid = loginCheck.data.usuario_login_uuid ? loginCheck.data.usuario_login_uuid : ``;
                    mymodelUserConnect.user_credential_number = loginCheck.data.user_credential_number;
                }
                else {
                    mymodelUserConnect.autorizado = 0;
                    mymodelUserConnect.email_login = ``;
                    mymodelUserConnect.usuario_login_uuid = `HASH INVALIDO / EXPIRADO`;
                    mymodelUserConnect.sis_us_seq = 0;
                    mymodelUserConnect.user_name = '';
                    mymodelUserConnect.sis_id = 0;
                    throw new Error('Token Inválido ou Expirado');
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('serviceSistema', 'loginCheck', e);
                throw new Error('serviceSistema.loginCheck');
            }
            finally {
                yield this.__consolelogin(mymodelUserConnect);
                return mymodelUserConnect;
            }
        });
    }
    static Userlogin(sis_id, mail, password) {
        return __awaiter(this, void 0, void 0, function* () {
            let mymodelUserConnect = new modelUserLogin_1.default();
            try {
                mymodelUserConnect.email_login = mail;
                mymodelUserConnect.password = password;
                mymodelUserConnect.sis_id = sis_id;
                mymodelUserConnect = yield this.__dataBaseLogin('DBINSERT', mymodelUserConnect);
                if (mymodelUserConnect.autorizado == 1) {
                    const jwtPayload = this.__getjwtPayload(mymodelUserConnect);
                    let user_credential = modelbase_1.clsTools.jwt.get(jwtPayload, '24h');
                    mymodelUserConnect.user_credential = user_credential;
                    yield this.__dataBaseLogin('DBUPDATE', mymodelUserConnect);
                    mymodelUserConnect.user_credential = user_credential;
                    try {
                        yield mail_login_log_1.default.start(mymodelUserConnect.email_login);
                    }
                    catch (e) {
                        yield modelbase_1.clsTools.PagErrorException('SISTEMA LOGIN', 'Envio de E-mail de logiin falhou', e);
                    }
                }
                yield this.__consolelogin(mymodelUserConnect);
                return mymodelUserConnect;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException('serviceSistema', 'login', e);
                //throw new Error('serviceSistema.login')
            }
            finally {
                return mymodelUserConnect;
            }
        });
    }
    static ClienteCrmLogin(tipopost, email, credentialNumber, user_credential) {
        return __awaiter(this, void 0, void 0, function* () {
            let mymodelUserConnect = new modelUserLogin_1.default();
            try {
                if (tipopost === "R") {
                    /*Obter credential number*/
                    mymodelUserConnect.user_credential_number = yield myBase.criptRandomINT(100000, 999999).toString().padStart(6, '0');
                    mymodelUserConnect.sis_id = 6;
                    mymodelUserConnect.email_login = email;
                    mymodelUserConnect.autorizado = 0;
                    mymodelUserConnect.sis_us_seq = 0;
                    mymodelUserConnect.usuario_login_uuid = "";
                    mymodelUserConnect.user_name = "user_crm";
                    if (mymodelUserConnect.user_credential_number === "") {
                        throw new Error('Erro ao gerar número de credencial');
                    }
                    else {
                        const jwtPayload = this.__getjwtPayload(mymodelUserConnect);
                        mymodelUserConnect.user_credential = modelbase_1.clsTools.jwt.get(jwtPayload, '24h');
                        if (process.env.ENVIRONMENT === 'DES') {
                            console.log("Credential Number Generated:", mymodelUserConnect.user_credential_number);
                        }
                        if (mymodelUserConnect.user_credential !== "") {
                            mail_login_crm_credentialnumber_1.default.start(email, mymodelUserConnect.user_credential_number);
                        }
                        else {
                            throw new Error('Erro ao gerar hash de credencial');
                        }
                    }
                }
                if (tipopost === "L") {
                    /*Fazer o Login com a credencial*/
                    if (user_credential === "" || credentialNumber === "") {
                        throw new Error('Credencial ou número de credencial inválido');
                    }
                    mymodelUserConnect = yield this.checkWjt(user_credential);
                    mymodelUserConnect.user_credential = user_credential;
                    if (mymodelUserConnect.user_credential_number !== credentialNumber) {
                        mymodelUserConnect.autorizado = 0;
                        throw new Error('Número de credencial inválido');
                    }
                    else {
                        mymodelUserConnect = yield this.__dataBaseLogin('DBINSERT', mymodelUserConnect);
                        mymodelUserConnect.user_credential = user_credential;
                    }
                }
                /*CHAMADA DA SELECT COM A CRIPOGRAFIA DA SENHA*/
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('serviceSistema', 'ClienteCrmLogin', e);
                throw new Error('serviceSistema.ClienteCrmLogin');
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`M0001_SISTEMA-CLIENTE-CRM-LOGIN - ${email} - HASH ${mymodelUserConnect.usuario_login_uuid ? "ok" : "no"}`, false, false);
                return mymodelUserConnect;
            }
        });
    }
    static __dataBaseLogin(sqlCommand, modelUserConnect) {
        return __awaiter(this, void 0, void 0, function* () {
            let mymodelUserConnect = modelUserConnect;
            try {
                let sql = f0001_02_sistema_login_1.default.get({
                    SqlCommand: sqlCommand,
                    sis_id: modelUserConnect.sis_id,
                    passwd: myBase.criptString(modelUserConnect.password),
                    email_main: modelUserConnect.email_login,
                    usuario_login_uuid: modelUserConnect.usuario_login_uuid,
                    user_credential: modelUserConnect.user_credential,
                    user_credential_number: modelUserConnect.user_credential_number
                });
                let result = yield myBase.myDataBase.RecordItem(yield myBase.myDataBase.pag.DataGet(sql), 0);
                if (result) {
                    mymodelUserConnect.binding(result);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('serviceSistema', 'dataBaseLogin', e);
                throw new Error('serviceSistema.dataBaseLogin');
            }
            finally {
                return modelUserConnect;
            }
        });
    }
    static __getjwtPayload(modelUserConnect) {
        let jwtPayload = {};
        try {
            jwtPayload = {
                sis_id: modelUserConnect.sis_id ? modelUserConnect.sis_id : 0,
                sis_us_seq: modelUserConnect.sis_us_seq,
                user_name: modelUserConnect.user_name,
                email_login: modelUserConnect.email_login,
                user_credential_number: modelUserConnect.user_credential_number,
                usuario_login_uuid: modelUserConnect.usuario_login_uuid
            };
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException('serviceSistema', 'getjwtPayload', e);
            throw new Error('serviceSistema.getjwtPayload');
        }
        finally {
            return jwtPayload;
        }
    }
    static __consolelogin(modelUserConnect) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield modelbase_1.clsTools.pagConsole(`M0001_SISTEMA-LOGIN - ${modelUserConnect.user_name} - ${modelUserConnect.email_login} HASH ${modelUserConnect.usuario_login_uuid ? "ok" : "no"}`, false, false);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('serviceSistema', 'consolelogin', e);
                throw new Error('serviceSistema.consolelogin');
            }
        });
    }
}
exports.default = serviceSistemaLogin;
