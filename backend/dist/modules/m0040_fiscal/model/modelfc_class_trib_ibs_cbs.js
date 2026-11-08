"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbfc_class_trib_ibs_cbs_1 = __importDefault(require("../tbs/tbfc_class_trib_ibs_cbs"));
class modelfc_class_trib_ibs_cbs extends tbfc_class_trib_ibs_cbs_1.default {
    constructor() {
        super();
    }
    ObterDadosAPIBluesoft_NFCE_PorProduto(ItemQueConteReformaTributariaIBS) {
        var _a, _b;
        if (ItemQueConteReformaTributariaIBS.reformaTributaria.codigoClassTribIbsCbs && ItemQueConteReformaTributariaIBS.reformaTributaria.codigoClassTribIbsCbs !== '') {
            this.rt_codigo_class_trib_ibs_cbs = ((_a = ItemQueConteReformaTributariaIBS === null || ItemQueConteReformaTributariaIBS === void 0 ? void 0 : ItemQueConteReformaTributariaIBS.reformaTributaria) === null || _a === void 0 ? void 0 : _a.codigoClassTribIbsCbs) || '';
            this.rt_descricao_class_trib_ibs_cbs = ((_b = ItemQueConteReformaTributariaIBS === null || ItemQueConteReformaTributariaIBS === void 0 ? void 0 : ItemQueConteReformaTributariaIBS.reformaTributaria) === null || _b === void 0 ? void 0 : _b.descricaoCstIbsCbs) || '';
        }
    }
}
exports.default = modelfc_class_trib_ibs_cbs;
