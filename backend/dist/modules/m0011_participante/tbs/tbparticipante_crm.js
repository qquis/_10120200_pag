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
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class tbparticipante_crm extends modelbase_1.clsBase {
    constructor() {
        super();
        this.crm_seq = 0;
        this.crm_status_cd = 0;
        this.crm_email = '';
        this.cpf = '';
        this.nome = '';
        this.sobre_nome = '';
        this.crm_dt_cadastro = modelbase_1.clsTools._datemomentDatStrToDate('1900-01-01');
        this.data_nascimento = modelbase_1.clsTools._datemomentDatStrToDate('1900-01-01');
        this.pf_sexo = 'N';
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            /*
                Le as informações do banco de dados
            */
            if (item) {
                this.crm_seq = item === null || item === void 0 ? void 0 : item.crm_seq;
                this.crm_status_cd = item === null || item === void 0 ? void 0 : item.crm_status_cd;
                this.crm_email = item === null || item === void 0 ? void 0 : item.crm_email;
                this.cpf = item === null || item === void 0 ? void 0 : item.cpf;
                this.nome = item === null || item === void 0 ? void 0 : item.nome;
                this.sobre_nome = item === null || item === void 0 ? void 0 : item.sobre_nome;
                this.data_nascimento = item === null || item === void 0 ? void 0 : item.data_nascimento;
                this.crm_dt_cadastro = item === null || item === void 0 ? void 0 : item.crm_dt_cadastro;
                this.pf_sexo = item === null || item === void 0 ? void 0 : item.pf_sexo;
            }
        });
    }
}
exports.default = tbparticipante_crm;
