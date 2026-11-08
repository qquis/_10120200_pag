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
class tbfc_pis extends modelbase_1.clsBase {
    constructor() {
        super();
        this.pis_cd = 0;
        this.pis_descricao = '';
        this.cst = 0;
        this.pisAliquota = 0;
        this.pisReducao = 0;
        this.cofinsRelacionado = 0;
        this.tipo_entrada = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.pis_cd = item === null || item === void 0 ? void 0 : item.pis_cd;
                this.cst = item === null || item === void 0 ? void 0 : item.cst;
                this.pisAliquota = item === null || item === void 0 ? void 0 : item.pisAliquota;
                this.pisReducao = item === null || item === void 0 ? void 0 : item.pisReducao;
                this.pis_descricao = item === null || item === void 0 ? void 0 : item.pis_descricao;
                this.cofinsRelacionado = item === null || item === void 0 ? void 0 : item.cofinsRelacionado;
            }
        });
    }
}
exports.default = tbfc_pis;
