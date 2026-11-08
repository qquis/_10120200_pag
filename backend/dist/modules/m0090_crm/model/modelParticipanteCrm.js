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
const model_participante_1 = __importDefault(require("../../../modules/m0011_participante/model/model_participante"));
class modelParticipanteCrm {
    constructor() {
        this.participante = new model_participante_1.default();
    }
    conferirCadastro() {
        return __awaiter(this, void 0, void 0, function* () {
            let chekExist = false;
            try {
                let sql = `select cdparticipante, cpf_cnpj from `;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("M0090_ParticipanteCRM", "modelParticipanteCrm _ conferirCadastro", e);
            }
            finally {
                return chekExist;
            }
        });
    }
}
