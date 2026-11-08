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
class tbfaturamento_bluesoft_processo extends modelbase_1.clsBase {
    constructor() {
        super();
        this.fat_blue_processo_seq = 0;
        this.op_cdoperacao = 0;
        this.numeropedido = 0;
        this.numeropedido_fv = 0;
        this.fat_blue_status_cd = 0;
        this.notificacao_cd = 0;
        this.notificado = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.fat_blue_processo_seq = item === null || item === void 0 ? void 0 : item.fat_blue_processo_seq;
                this.op_cdoperacao = item === null || item === void 0 ? void 0 : item.op_cdoperacao;
                this.numeropedido = item === null || item === void 0 ? void 0 : item.numeropedido;
                this.numeropedido_fv = item === null || item === void 0 ? void 0 : item.numeropedido_fv;
                this.fat_blue_status_cd = item === null || item === void 0 ? void 0 : item.fat_blue_status_cd;
                this.notificacao_cd = item === null || item === void 0 ? void 0 : item.notificacao_cd;
                this.notificado = item === null || item === void 0 ? void 0 : item.notificado;
            }
        });
    }
}
exports.default = tbfaturamento_bluesoft_processo;
