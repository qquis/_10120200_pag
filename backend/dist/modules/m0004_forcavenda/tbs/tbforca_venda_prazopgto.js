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
class tbforca_venda_prazopgto extends modelbase_1.clsBase {
    constructor() {
        super();
        this.fv_prazopgto_cd = 0;
        this.fv_prazopgto_descricao = '';
        this.custofinanceiro = 0;
        this.coefcustofinanceiro = 0;
        this.tipo = '';
        this.tipocusto = '';
        this.status = 0;
        this.versao = 0;
        this.listapadraoorder = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.fv_prazopgto_cd = item === null || item === void 0 ? void 0 : item.fv_prazopgto_cd;
                this.fv_prazopgto_descricao = item === null || item === void 0 ? void 0 : item.fv_prazopgto_descricao;
                this.custofinanceiro = item === null || item === void 0 ? void 0 : item.custofinanceiro;
                this.coefcustofinanceiro = item === null || item === void 0 ? void 0 : item.coefcustofinanceiro;
                this.tipo = item === null || item === void 0 ? void 0 : item.tipo;
                this.tipocusto = item === null || item === void 0 ? void 0 : item.tipocusto;
                this.status = item === null || item === void 0 ? void 0 : item.status;
                this.versao = item === null || item === void 0 ? void 0 : item.versao;
                this.listapadraoorder = item === null || item === void 0 ? void 0 : item.listapadraoorder;
            }
        });
    }
}
exports.default = tbforca_venda_prazopgto;
