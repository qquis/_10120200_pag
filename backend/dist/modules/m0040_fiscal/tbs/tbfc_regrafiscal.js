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
class tbfc_regrafiscal extends modelbase_1.clsBase {
    constructor() {
        super();
        this.tipo = '';
        this.fc_regrafiscal_cd = 0;
        this.cfop = 0;
        this.fc_figurafiscal_cd = 0;
        this.vigenciainicial = new Date(0);
        this.fc_regrafiscal_status = 0;
        this.icms_cd = 0;
        this.pis_cd = 0;
        this.cofins_cd = 0;
        this.regimeincidenciapiscofins = '';
        this.tipocliente = '';
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.tipo = item === null || item === void 0 ? void 0 : item.tipo;
                this.fc_regrafiscal_cd = item === null || item === void 0 ? void 0 : item.fc_regrafiscal_cd;
                this.cfop = item === null || item === void 0 ? void 0 : item.cfop;
                this.fc_figurafiscal_cd = item === null || item === void 0 ? void 0 : item.fc_figurafiscal_cd;
                this.vigenciainicial = item === null || item === void 0 ? void 0 : item.vigenciainicial;
                this.fc_regrafiscal_status = item === null || item === void 0 ? void 0 : item.fc_regrafiscal_status;
                this.icms_cd = item === null || item === void 0 ? void 0 : item.icms_cd;
                this.regimeincidenciapiscofins = item === null || item === void 0 ? void 0 : item.regimeincidenciapiscofins;
                this.tipocliente = item === null || item === void 0 ? void 0 : item.tipocliente;
                this.pis_cd = item === null || item === void 0 ? void 0 : item.pis_cd;
                this.cofins_cd = item === null || item === void 0 ? void 0 : item.cofins_cd;
            }
        });
    }
}
exports.default = tbfc_regrafiscal;
