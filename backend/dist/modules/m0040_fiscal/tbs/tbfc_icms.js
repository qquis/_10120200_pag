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
class tbfc_icms extends modelbase_1.clsBase {
    constructor() {
        super();
        this.icms_cd = 0;
        this.codigoOrigem = 0;
        this.codigoTributacao = 0;
        this.icms_descricao = '';
        this.sigla = '';
        this.aliquota = 0;
        this.reducao = 0;
        this.porcentagemDiferimento = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.icms_cd = item === null || item === void 0 ? void 0 : item.icms_cd;
                this.codigoOrigem = item === null || item === void 0 ? void 0 : item.codigoOrigem;
                this.codigoTributacao = item === null || item === void 0 ? void 0 : item.codigoTributacao;
                this.icms_descricao = item === null || item === void 0 ? void 0 : item.icms_descricao;
                this.sigla = item === null || item === void 0 ? void 0 : item.sigla;
                this.aliquota = item === null || item === void 0 ? void 0 : item.aliquota;
                this.reducao = item === null || item === void 0 ? void 0 : item.reducao;
                this.porcentagemDiferimento = item === null || item === void 0 ? void 0 : item.porcentagemDiferimento;
            }
        });
    }
}
exports.default = tbfc_icms;
