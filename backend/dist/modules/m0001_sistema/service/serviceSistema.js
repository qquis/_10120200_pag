"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const serviceSistemaNotificacao_1 = __importDefault(require("./serviceSistemaNotificacao"));
const serviceSistemaLogin_1 = __importDefault(require("./serviceSistemaLogin"));
const servicesistemaPassWord_1 = __importDefault(require("./servicesistemaPassWord"));
const serviceSistemaBackendStart_1 = __importDefault(require("./serviceSistemaBackendStart"));
class serviceSistema {
}
serviceSistema.Notificacao = serviceSistemaNotificacao_1.default;
serviceSistema.Login = serviceSistemaLogin_1.default;
serviceSistema.PassWord = servicesistemaPassWord_1.default;
serviceSistema.BackendStart = serviceSistemaBackendStart_1.default;
exports.default = serviceSistema;
