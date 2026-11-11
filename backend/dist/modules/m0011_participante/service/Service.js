"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const ServiceParticipanteVipImport_1 = __importDefault(require("./ServiceParticipanteVipImport"));
const serviceParticipanteBlueSoftRedShiftImport_1 = __importDefault(require("./serviceParticipanteBlueSoftRedShiftImport"));
const serviceParticipanteBluesoftAPIImport_1 = __importDefault(require("./serviceParticipanteBluesoftAPIImport"));
const serviceParticipanteBluesoftApiAtualizarStatusCredito_1 = __importDefault(require("./serviceParticipanteBluesoftApiAtualizarStatusCredito"));
const serviceGrupoEconomicoImport_1 = __importDefault(require("./serviceGrupoEconomicoImport"));
const serviceParticipanteBluesoftApiAtualizarStatusCreditoCorrecao_1 = __importDefault(require("./serviceParticipanteBluesoftApiAtualizarStatusCreditoCorrecao"));
class serviceParticipante {
}
serviceParticipante.vipimport = ServiceParticipanteVipImport_1.default;
serviceParticipante.RedShiftBlueSoftImport = serviceParticipanteBlueSoftRedShiftImport_1.default;
serviceParticipante.APIBlueSoftImport = serviceParticipanteBluesoftAPIImport_1.default;
serviceParticipante.GrupoEconomicoImport = serviceGrupoEconomicoImport_1.default;
serviceParticipante.APIBlueSoftAtualizarStatusCredito = serviceParticipanteBluesoftApiAtualizarStatusCredito_1.default;
serviceParticipante.APIBlueSoftAtualizarStatusCreditoCorrecao = serviceParticipanteBluesoftApiAtualizarStatusCreditoCorrecao_1.default;
exports.default = serviceParticipante;
