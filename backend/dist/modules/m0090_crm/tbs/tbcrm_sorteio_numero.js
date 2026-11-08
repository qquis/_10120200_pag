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
class tbcrm_sorteio_numero extends modelbase_1.clsBase {
    constructor() {
        super();
        this.crm_so_temp_cd = 0;
        this.crm_so_numero_seq = 0;
        this.crm_so_numero_ordem = 0;
        this.crm_so_cupom_seq = 0;
        this.numero = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.crm_so_temp_cd = item === null || item === void 0 ? void 0 : item.crm_so_temp_cd;
                this.crm_so_numero_seq = item === null || item === void 0 ? void 0 : item.crm_so_numero_seq;
                this.crm_so_numero_ordem = item === null || item === void 0 ? void 0 : item.crm_so_numero_ordem;
                this.crm_so_cupom_seq = item === null || item === void 0 ? void 0 : item.crm_so_cupom_seq;
                this.numero = item === null || item === void 0 ? void 0 : item.numero;
            }
        });
    }
}
exports.default = tbcrm_sorteio_numero;
