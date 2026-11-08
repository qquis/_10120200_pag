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
const tbresultado_conta_origem_1 = __importDefault(require("../tbs/tbresultado_conta_origem"));
class modelResultaContaOrigem extends tbresultado_conta_origem_1.default {
    constructor() {
        super();
        this.op_descricao = ``;
        this.r_conta_origem_tipo_descricao = ``;
        this.r_centro_op_descricao = ``;
        this.plc_descricao = ``;
        this.prd_descricao = ``;
        this.prs_descricao = ``;
        this.rh_setor_operacional_descricao = ``;
        this.r_resp_descricao = ``;
        this.cdparticipante = 0;
        this.nome_razao = ``;
    }
    modelBinding(item) {
        const _super = Object.create(null, {
            binding: { get: () => super.binding }
        });
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                _super.binding.call(this, item);
                this.op_descricao = item === null || item === void 0 ? void 0 : item.op_descricao;
                this.r_conta_origem_tipo_descricao = item === null || item === void 0 ? void 0 : item.r_conta_origem_tipo_descricao;
                this.r_centro_op_descricao = item === null || item === void 0 ? void 0 : item.r_centro_op_descricao;
                this.plc_descricao = item === null || item === void 0 ? void 0 : item.plc_descricao;
                this.prd_descricao = item === null || item === void 0 ? void 0 : item.prd_descricao;
                this.prs_descricao = item === null || item === void 0 ? void 0 : item.prs_descricao;
                this.rh_setor_operacional_descricao = item === null || item === void 0 ? void 0 : item.rh_setor_operacional_descricao;
                this.r_resp_descricao = item === null || item === void 0 ? void 0 : item.r_resp_descricao;
                this.cdparticipante = item === null || item === void 0 ? void 0 : item.cdparticipante;
                this.nome_razao = item === null || item === void 0 ? void 0 : item.nome_razao;
            }
        });
    }
}
exports.default = modelResultaContaOrigem;
