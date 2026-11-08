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
class tbcrm_sorteio_temporada extends modelbase_1.clsBase {
    constructor() {
        super();
        this.crm_so_temp_cd = 0;
        this.crm_so_temp_descricao = '';
        this.crm_so_temp_valor_minimo = 0;
        this.crm_so_temp_status = 0;
        this.crm_so_temp_data_ini = this.__dataZERO;
        this.crm_so_temp_data_fim = this.__dataZERO;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.crm_so_temp_cd = item === null || item === void 0 ? void 0 : item.crm_so_temp_cd;
                this.crm_so_temp_descricao = item === null || item === void 0 ? void 0 : item.crm_so_temp_descricao;
                this.crm_so_temp_valor_minimo = item === null || item === void 0 ? void 0 : item.crm_so_temp_valor_minimo;
                this.crm_so_temp_status = item === null || item === void 0 ? void 0 : item.crm_so_temp_status;
                this.crm_so_temp_data_ini = item === null || item === void 0 ? void 0 : item.crm_so_temp_data_ini;
                this.crm_so_temp_data_fim = item === null || item === void 0 ? void 0 : item.crm_so_temp_data_fim;
            }
        });
    }
}
exports.default = tbcrm_sorteio_temporada;
