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
class tbresultado_conta_origem extends modelbase_1.clsBase {
    constructor() {
        super();
        this.contrato_bluesoft_seq = 0;
        this.op_cdoperacao = 0;
        this.plc_conta_cd = 0;
        this.prd_cddepartamento = 0;
        this.prs_cdsecao = 0;
        this.r_centro_op_cd = 0;
        this.r_conta_cd = 0;
        this.r_conta_origem_tipo_cd = 0;
        this.rh_setor_operacional_cd = 0;
        this.r_resp_cd = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.contrato_bluesoft_seq = item === null || item === void 0 ? void 0 : item.contrato_bluesoft_seq;
                this.op_cdoperacao = item === null || item === void 0 ? void 0 : item.op_cdoperacao;
                this.plc_conta_cd = item === null || item === void 0 ? void 0 : item.plc_conta_cd;
                this.prd_cddepartamento = item === null || item === void 0 ? void 0 : item.prd_cddepartamento;
                this.prs_cdsecao = item === null || item === void 0 ? void 0 : item.prs_cdsecao;
                this.r_centro_op_cd = item === null || item === void 0 ? void 0 : item.r_centro_op_cd;
                this.r_conta_cd = item === null || item === void 0 ? void 0 : item.r_conta_cd;
                this.r_conta_origem_tipo_cd = item === null || item === void 0 ? void 0 : item.r_conta_origem_tipo_cd;
                this.rh_setor_operacional_cd = item === null || item === void 0 ? void 0 : item.rh_setor_operacional_cd;
                this.r_resp_cd = item === null || item === void 0 ? void 0 : item.r_resp_cd;
            }
        });
    }
}
exports.default = tbresultado_conta_origem;
