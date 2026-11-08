"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbfc_cst_ibs_cbs_1 = __importDefault(require("../tbs/tbfc_cst_ibs_cbs"));
class modelfc_cst_ibs_cbs extends tbfc_cst_ibs_cbs_1.default {
    constructor() {
        super();
    }
    ObterDadosAPIBluesoft_NFCE_PorProduto(item) {
        if (item.reformaTributaria.codigoCstIbsCbs && item.reformaTributaria.codigoCstIbsCbs !== '') {
            this.rt_codigo_cst_ibs_cbs = item.reformaTributaria.codigoCstIbsCbs;
            this.cst_ibs_cbs_descricao = item.reformaTributaria.descricaoCstIbsCbs;
        }
    }
}
exports.default = modelfc_cst_ibs_cbs;
