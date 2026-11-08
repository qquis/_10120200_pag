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
const _serviceNotificacao_1 = __importDefault(require("../../m0210_notificacao/service/_serviceNotificacao"));
class serviceSistemaNotificacao {
    static notificar(mensagem) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield _serviceNotificacao_1.default.Criar({ notificacao_cd: 1009030001, notificacao_send_tipo_cd: 100, notificacao_send_message: mensagem });
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('serviceSistema', 'notificar', e);
                throw new Error('serviceSistema.notificar');
            }
        });
    }
}
exports.default = serviceSistemaNotificacao;
