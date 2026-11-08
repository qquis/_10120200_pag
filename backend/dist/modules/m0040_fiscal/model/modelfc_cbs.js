"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbfc_cbs_1 = __importDefault(require("../tbs/tbfc_cbs"));
class modelfc_cbs extends tbfc_cbs_1.default {
    constructor() {
        super();
    }
    ObterDadosAPIBluesoft_NFCE_PorProduto(ItemQueConteReformaTributariaIBS) {
        if (ItemQueConteReformaTributariaIBS.reformaTributaria.cbs.cbsKey
            && ItemQueConteReformaTributariaIBS.reformaTributaria.cbs.cbsKey > 0) {
            this.cbs_cd = ItemQueConteReformaTributariaIBS.reformaTributaria.cbs.cbsKey;
            this.cbs_descricao = ItemQueConteReformaTributariaIBS.reformaTributaria.cbs.descricao;
            this.cbs_descricao_abreviada = ItemQueConteReformaTributariaIBS.reformaTributaria.cbs.descricaoAbreviada;
        }
    }
}
exports.default = modelfc_cbs;
