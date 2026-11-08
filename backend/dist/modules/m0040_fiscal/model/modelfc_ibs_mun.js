"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbfc_ibs_mun_1 = __importDefault(require("../tbs/tbfc_ibs_mun"));
class modelfc_ibs_mun extends tbfc_ibs_mun_1.default {
    constructor() {
        super();
    }
    ObterDadosAPIBluesoft_NFCE_PorProduto(ItemQueConteReformaTributariaIBS) {
        if (ItemQueConteReformaTributariaIBS.reformaTributaria.ibsMun.ibsMunKey && ItemQueConteReformaTributariaIBS.reformaTributaria.ibsMun.ibsMunKey > 0) {
            this.ibs_mun_cd = ItemQueConteReformaTributariaIBS.reformaTributaria.ibsMun.ibsMunKey;
            this.ibs_mun_descricao = ItemQueConteReformaTributariaIBS.reformaTributaria.ibsMun.descricao;
            this.ibs_mun_descricao_abreviada = ItemQueConteReformaTributariaIBS.reformaTributaria.ibsMun.descricaoAbreviada;
        }
    }
}
exports.default = modelfc_ibs_mun;
