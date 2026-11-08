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
class tbfc_cofins extends modelbase_1.clsBase {
    constructor() {
        super();
        this.cofins_cd = 0;
        this.cofins_descricao = '';
        this.cst = 0;
        this.cofinsAliquota = 0;
        this.cofinsReducao = 0;
        this.pisrelacionado = 0;
        this.tipo_entrada = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.cofins_cd = item === null || item === void 0 ? void 0 : item.cofins_cd;
                this.cst = item === null || item === void 0 ? void 0 : item.cst;
                this.cofinsAliquota = item === null || item === void 0 ? void 0 : item.cofinsAliquota;
                this.cofinsReducao = item === null || item === void 0 ? void 0 : item.cofinsReducao;
                this.cofins_descricao = item === null || item === void 0 ? void 0 : item.cofins_descricao;
                this.pisrelacionado = item === null || item === void 0 ? void 0 : item.pisrelacionado;
            }
        });
    }
}
exports.default = tbfc_cofins;
