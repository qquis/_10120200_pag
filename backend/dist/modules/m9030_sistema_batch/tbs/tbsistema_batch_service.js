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
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const model_1 = require("../../../model/model");
class tbsistema_batch_service extends model_1.modelTb {
    constructor(sis_batch_service_cd) {
        super();
        const _dataInitial = Tools_1.default.pagDateTime_getDate();
        this.dtlog_insert = _dataInitial;
        this.dtlog_update = _dataInitial;
        this.sis_batch_service_cd = sis_batch_service_cd;
        this.sis_batch_service_descricao = ``;
        this.sis_batch_service_ult_run_date = _dataInitial;
        this.sis_batch_service_ult_run_host = ``;
    }
    _Db_Pg_script_Update() {
        return `UPDATE tbsistema_batch_service 
                    SET sis_batch_service_ult_run_date = current_timestamp 
                    ,   sis_batch_service_ult_run_host = 'localhost'
                    where 1 = 1
                      and sis_batch_service_cd = ${this.sis_batch_service_cd}
                    ;

            `;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item !== undefined) {
                    this.dtlog_insert = this.__defaultDateNow;
                }
            }
            catch (e) {
                throw `tbsistema_batch_run | ${e}`;
            }
        });
    }
}
exports.default = tbsistema_batch_service;
