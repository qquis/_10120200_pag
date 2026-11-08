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
const model_1 = require("../../../model/model");
class tbfaturamentovipcomprastatus extends model_1.modelTb {
    constructor() {
        super();
        this.compra_status_id = 0;
        this.compra_status_descricao = "";
        this.notificacao_cd = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.compra_status_id = item.compra_status_id;
                this.compra_status_descricao = item.compra_status_descricao;
                this.notificacao_cd = item.notificacao_cd;
            }
        });
    }
}
exports.default = tbfaturamentovipcomprastatus;
