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
class TbEmpresa extends modelbase_1.clsBase {
    constructor() {
        super();
        this.em_cdempresa = 0;
        this.em_descricao = '';
        this.em_cdpessoabluesoft = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.em_cdempresa = item === null || item === void 0 ? void 0 : item.em_cdempresa;
                this.em_descricao = item === null || item === void 0 ? void 0 : item.em_descricao;
                this.em_cdpessoabluesoft = item === null || item === void 0 ? void 0 : item.em_cdpessoabluesoft;
            }
        });
    }
}
exports.default = TbEmpresa;
