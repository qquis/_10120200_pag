"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbfaturamentoVip_1 = __importDefault(require("../tbs/tbfaturamentoVip"));
const pg_f0051_10_faturamento_vip_crud_1 = __importDefault(require("../scripts/pg.f0051_10_faturamento_vip_crud"));
class modelfaturamentovip extends tbfaturamentoVip_1.default {
    getCrudSql() {
        return pg_f0051_10_faturamento_vip_crud_1.default.get(this);
    }
}
exports.default = modelfaturamentovip;
