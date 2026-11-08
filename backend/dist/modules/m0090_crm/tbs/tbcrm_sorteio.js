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
class tbcrm_sorteio extends modelbase_1.clsBase {
    constructor() {
        super();
        this.crm_numero_oficial = 0;
        this.crm_so_cd = 0;
        this.crm_so_data_fim = this.__defaultDateNow;
        this.crm_so_data_ini = this.__defaultDateNow;
        this.crm_so_data_sorteio = this.__defaultDateNow;
        this.crm_so_descricao = '';
        this.crm_so_seq = 0;
        this.crm_so_temp_cd = 0;
        this.crm_so_tipo_cd = 0;
        this.dtlog_insert = this.__defaultDateNow;
        this.dtlog_update = this.__defaultDateNow;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.crm_numero_oficial = item === null || item === void 0 ? void 0 : item.crm_numero_oficial;
                this.crm_so_cd = item === null || item === void 0 ? void 0 : item.crm_so_cd;
                this.crm_so_data_fim = item === null || item === void 0 ? void 0 : item.crm_so_data_fim;
                this.crm_so_data_ini = item === null || item === void 0 ? void 0 : item.crm_so_data_ini;
                this.crm_so_data_sorteio = item === null || item === void 0 ? void 0 : item.crm_so_data_sorteio;
                this.crm_so_descricao = item === null || item === void 0 ? void 0 : item.crm_so_descricao;
                this.crm_so_seq = item === null || item === void 0 ? void 0 : item.crm_so_seq;
                this.crm_so_temp_cd = item === null || item === void 0 ? void 0 : item.crm_so_temp_cd;
                this.crm_so_tipo_cd = item === null || item === void 0 ? void 0 : item.crm_so_tipo_cd;
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_insert, `YYYY-MM-DD HH:mm:ss`);
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_update, `YYYY-MM-DD HH:mm:ss`);
            }
        });
    }
}
exports.default = tbcrm_sorteio;
