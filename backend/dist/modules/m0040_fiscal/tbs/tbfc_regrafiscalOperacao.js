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
class tbfc_regrafiscalOperacao extends modelbase_1.clsBase {
    constructor() {
        super();
        this.fc_regrafiscal_cd = 0;
        this.df_nf_tipo = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.fc_regrafiscal_cd = item === null || item === void 0 ? void 0 : item.fc_regrafiscal_cd;
                this.df_nf_tipo = item === null || item === void 0 ? void 0 : item.df_nf_tipo;
            }
        });
    }
}
exports.default = tbfc_regrafiscalOperacao;
