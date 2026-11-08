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
class tbforca_venda_tabprecoVersao extends modelbase_1.clsBase {
    constructor() {
        super();
        this.fv_tabelapreco_cd = 0;
        this.versao = 0;
        this.descontomaximo = 0;
        this.descontopadrao = 0;
        this.acrescimomaximo = 0;
        this.datainiciovigencia = new Date();
        this.datafimvigencia = new Date();
        this.ativo = 0;
        this.tabelareferencia = 0;
        this.publicada = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.fv_tabelapreco_cd = item === null || item === void 0 ? void 0 : item.fv_tabelapreco_cd;
                this.versao = item === null || item === void 0 ? void 0 : item.versao;
                this.descontomaximo = item === null || item === void 0 ? void 0 : item.descontomaximo;
                this.descontopadrao = item === null || item === void 0 ? void 0 : item.descontopadrao;
                this.acrescimomaximo = item === null || item === void 0 ? void 0 : item.acrescimomaximo;
                this.datainiciovigencia = item === null || item === void 0 ? void 0 : item.datainiciovigencia;
                this.datafimvigencia = item === null || item === void 0 ? void 0 : item.datafimvigencia;
                this.ativo = item === null || item === void 0 ? void 0 : item.ativo;
                this.tabelareferencia = item === null || item === void 0 ? void 0 : item.tabelareferencia;
                this.publicada = item === null || item === void 0 ? void 0 : item.publicada;
            }
        });
    }
}
exports.default = tbforca_venda_tabprecoVersao;
