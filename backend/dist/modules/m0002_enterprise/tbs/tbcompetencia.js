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
class tbcompetencia extends modelbase_1.clsBase {
    constructor() {
        super();
        this.competencia_ano = 0;
        this.competencia_cd = 0;
        this.competencia_cd_ma = 0;
        this.competencia_data_fim = this.__defaultDateNow;
        this.competencia_data_ini = this.__defaultDateNow;
        this.competencia_descricao = '';
        this.competencia_mes = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.competencia_ano = item === null || item === void 0 ? void 0 : item.competencia_ano;
                this.competencia_cd = item === null || item === void 0 ? void 0 : item.competencia_cd;
                this.competencia_cd_ma = item === null || item === void 0 ? void 0 : item.competencia_cd_ma;
                this.competencia_data_fim = item === null || item === void 0 ? void 0 : item.competencia_data_fim;
                this.competencia_data_ini = item === null || item === void 0 ? void 0 : item.competencia_data_ini;
                this.competencia_descricao = item === null || item === void 0 ? void 0 : item.competencia_descricao;
                this.competencia_mes = item === null || item === void 0 ? void 0 : item.competencia_mes;
            }
        });
    }
}
exports.default = tbcompetencia;
