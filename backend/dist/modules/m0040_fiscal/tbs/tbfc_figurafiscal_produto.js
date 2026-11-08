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
class tbfc_figurafiscal_produto extends modelbase_1.clsBase {
    constructor() {
        super();
        this.fc_figurafiscal_cd = 0;
        this.fc_figurafiscal_versao = 0;
        this.prb_cdprodutobluesoft = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.fc_figurafiscal_cd = item === null || item === void 0 ? void 0 : item.fc_figurafiscal_cd;
                this.fc_figurafiscal_versao = item === null || item === void 0 ? void 0 : item.fc_figurafiscal_versao;
                this.prb_cdprodutobluesoft = item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoft;
            }
        });
    }
}
exports.default = tbfc_figurafiscal_produto;
