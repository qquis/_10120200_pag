"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const reportParticipanteList_1 = __importDefault(require("./reportParticipanteList"));
const reportParticipanteBlueComGrupoEconomico_1 = __importDefault(require("./reportParticipanteBlueComGrupoEconomico"));
const reportParticipanteTipoList_1 = __importDefault(require("./reportParticipanteTipoList"));
const report_ParticipanteBluesoft_Redshift_1 = __importDefault(require("./report.ParticipanteBluesoft.Redshift"));
class reportParticipante {
}
reportParticipante.List = reportParticipanteList_1.default;
reportParticipante.GrupoEconomicoList = reportParticipanteBlueComGrupoEconomico_1.default;
reportParticipante.TipoList = reportParticipanteTipoList_1.default;
reportParticipante.Redshift = report_ParticipanteBluesoft_Redshift_1.default;
exports.default = reportParticipante;
