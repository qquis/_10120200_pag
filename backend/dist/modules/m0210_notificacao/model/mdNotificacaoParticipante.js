"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
//tbs
const tbnotificacao_participante_1 = __importDefault(require("../tbs/tbnotificacao_participante"));
//submodels
class mdNotificacaoParticipante extends tbnotificacao_participante_1.default {
    constructor() {
        super();
        this.nome_razao = '';
        this.celular_dd = "0";
        this.celular_numero = "0";
        this.nome_razao = '';
        this.email_main = '';
        this.isgroup = 0;
    }
    bindingMd(item) {
        try {
            if (item) {
                this.cdparticipante = parseInt(`${item.cdparticipante}`);
                this.nome_razao = `${item.nome_razao}`;
                this.celular_dd = `${item.celular_dd}`;
                this.celular_numero = `${item.celular_numero}`;
                this.email_main = `${item.email_main}`;
                this.isgroup = parseInt(`${item === null || item === void 0 ? void 0 : item.isgroup}`);
            }
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException('mdNotificacaoParticipante', 'bindingMd', e);
        }
    }
}
exports.default = mdNotificacaoParticipante;
