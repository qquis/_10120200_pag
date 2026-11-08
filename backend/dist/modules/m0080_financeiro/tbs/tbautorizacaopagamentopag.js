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
class tbautorizacaopagamentopag extends modelbase_1.clsBase {
    constructor() {
        super();
        this.aut_pgto_pag_uuid = ``;
        this.aut_pgto_pag_data_pgto = this.__defaultDateNow;
        this.aut_pgto_pag_data = this.__defaultDateNow;
        this.aut_pgto_pag_seq = 0;
        this.aut_pgto_pag_valor = 0;
        this.cdparticipante = 0;
        this.competencia_cd = 0;
        this.dtlog_insert = this.__defaultDateNow;
        this.em_cdempresa = 0;
        this.sis_us_seq = 0;
        this.r_conta_cd = 0;
        this.aut_pgto_pag_cancelado = 0;
        this.aut_pgto_pag_cancelado_data = this.__defaultDateNow;
        this.aut_pgto_pag_cancelado_sis_us_seq = 0;
        this.aut_pgto_pag_obs = ``;
        this.debitocredito = -1;
        this.aut_pgto_pag_tipo_cd = 1;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.aut_pgto_pag_uuid = item === null || item === void 0 ? void 0 : item.aut_pgto_pag_uuid;
                this.aut_pgto_pag_data = item === null || item === void 0 ? void 0 : item.aut_pgto_pag_data;
                this.aut_pgto_pag_data_pgto = item === null || item === void 0 ? void 0 : item.aut_pgto_pag_data_pgto;
                this.aut_pgto_pag_seq = item === null || item === void 0 ? void 0 : item.aut_pgto_pag_seq;
                this.aut_pgto_pag_valor = item === null || item === void 0 ? void 0 : item.aut_pgto_pag_valor;
                this.cdparticipante = item === null || item === void 0 ? void 0 : item.cdparticipante;
                this.competencia_cd = item === null || item === void 0 ? void 0 : item.competencia_cd;
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_insert, `YYYY-MM-DD HH:mm:ss`);
                this.em_cdempresa = item === null || item === void 0 ? void 0 : item.em_cdempresa;
                this.sis_us_seq = item === null || item === void 0 ? void 0 : item.sis_us_seq;
                this.r_conta_cd = item === null || item === void 0 ? void 0 : item.r_conta_cd;
                this.aut_pgto_pag_cancelado = item === null || item === void 0 ? void 0 : item.aut_pgto_pag_cancelado;
                this.aut_pgto_pag_cancelado_data = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.aut_pgto_pag_cancelado_data);
                this.aut_pgto_pag_cancelado_sis_us_seq = item === null || item === void 0 ? void 0 : item.aut_pgto_pag_cancelado_sis_us_seq;
                this.aut_pgto_pag_obs = item === null || item === void 0 ? void 0 : item.aut_pgto_pag_obs;
                this.debitocredito = item === null || item === void 0 ? void 0 : item.debitocredito;
                this.aut_pgto_pag_tipo_cd = item === null || item === void 0 ? void 0 : item.aut_pgto_pag_tipo_cd;
            }
        });
    }
}
exports.default = tbautorizacaopagamentopag;
