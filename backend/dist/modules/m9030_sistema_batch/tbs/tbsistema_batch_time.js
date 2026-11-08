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
class tbsistema_batch_time extends model_1.modelTb {
    constructor(sis_batch_cd) {
        super();
        this.dtlog_insert = this.__defaultDateNow;
        this.dtlog_update = this.__defaultDateNow;
        this.sis_batch_cd = sis_batch_cd;
        this.sis_batch_recorrencia_cd = 0;
        this.sis_batch_dt_ini = this.__defaultDateNow;
        this.sis_batch_dt_fim = this.__defaultDateNow;
        this.sis_batch_hm_ini = `00:00`;
        this.sis_batch_hm_fim = `00:00`;
        this.sis_batch_wk_ini = 0;
        this.sis_batch_wk_fim = 0;
        this.notificacao_cd = 0;
        this.sis_batch_time_seq = 0;
    }
    _Db_Pg_script(_stringCommand) {
        const script = ``;
        return script;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
        });
    }
}
exports.default = tbsistema_batch_time;
