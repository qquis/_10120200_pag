"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbfc_ibs_1 = __importDefault(require("../tbs/tbfc_ibs"));
class modelfc_ibs extends tbfc_ibs_1.default {
    constructor() {
        super();
    }
    ObterDadosAPIBluesoft_NFCE_PorProduto(ItemQueConteReformaTributariaIBS) {
        if (ItemQueConteReformaTributariaIBS.reformaTributaria.ibs.ibsKey && ItemQueConteReformaTributariaIBS.reformaTributaria.ibs.ibsKey > 0) {
            this.ibs_cd = ItemQueConteReformaTributariaIBS.reformaTributaria.ibs.ibsKey;
            this.ibs_descricao = ItemQueConteReformaTributariaIBS.reformaTributaria.ibs.descricao;
            this.ibs_descricao_abreviada = ItemQueConteReformaTributariaIBS.reformaTributaria.ibs.descricaoAbreviada;
        }
    }
}
exports.default = modelfc_ibs;
