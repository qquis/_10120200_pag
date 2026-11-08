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
class tbrh_tipo_contrato extends modelbase_1.clsBase {
    constructor() {
        super();
        this.dtlog_insert = this.__defaultDateNow;
        this.dtlog_update = this.__defaultDateNow;
        this.rh_tipo_contrato_cd = 0;
        this.rh_tipo_contrato_descricao = '';
        this.rh_tipo_contrato_legal = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_insert, `YYYY-MM-DD HH:mm:ss`);
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_update, `YYYY-MM-DD HH:mm:ss`);
                this.rh_tipo_contrato_cd = item === null || item === void 0 ? void 0 : item.rh_tipo_contrato_cd;
                this.rh_tipo_contrato_descricao = item === null || item === void 0 ? void 0 : item.rh_tipo_contrato_descricao;
                this.rh_tipo_contrato_legal = item === null || item === void 0 ? void 0 : item.rh_tipo_contrato_legal;
            }
        });
    }
}
exports.default = tbrh_tipo_contrato;
