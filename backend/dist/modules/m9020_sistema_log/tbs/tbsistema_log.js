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
class tbsistema_log extends model_1.modelTb {
    constructor() {
        super();
        this.dtlog_insert = this.__defaultDateNow;
        this.sis_log_seq = 0;
        this.proc_log_seq = 0;
        this.sis_nucleo_prc_cd = 0;
        this.sis_log_tag = ``;
        this.sis_log_info = ``;
        this.sis_batch_run_seq = 0;
        this.uuid = ``;
        this.uuid_start = ``;
    }
    _Db_Pg_script_DBCRUD() {
        let sql = ///this._Db_Pg_script_Insert() + 
         this._Db_Pg_script_Select();
        return sql;
    }
    _Db_Pg_script_Insert() {
        try {
            let sql = `INSERT INTO TbSistema_Log 
                            (
                                    proc_log_seq 
                                ,   sis_nucleo_prc_cd 
                                ,   sis_log_tag 
                                ,   sis_log_info 
                                ,   sis_batch_run_seq
                                ,   uuid 
                                ,   uuid_start 
                            )
                            VALUES (
                                    ${this.proc_log_seq}
                                ,   ${this.sis_nucleo_prc_cd}
                                ,  '${this.sis_log_tag}'
                                ,  '${this.sis_log_info.length > 120 ? this.sis_log_info.substring(0, 120) : this.sis_log_info}'
                                ,   ${this.sis_batch_run_seq}
                                ,  '${this.uuid}'
                                ,  '${this.uuid_start}'
                            );
                        `;
            return sql;
        }
        catch (e) {
            return ``;
        }
    }
    _Db_Pg_script_Select() {
        let sql = `Select    dtlog_insert
                                        ,   sis_log_seq 
                                        ,   proc_log_seq 
                                        ,   sis_nucleo_prc_cd 
                                        ,   sis_log_tag 
                                        ,   sis_log_info 
                                        ,   sis_batch_run_seq
                                        ,   uuid 
                                  FROM      tbsistema_log 
                                  WHERE     1 = 1
                                  AND       uuid = '${this.uuid}'        
                                `;
        return sql;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item !== undefined) {
                    const _dataDefault = Tools_1.default.pagDateTime_getDate();
                    this.dtlog_insert = item.dtlog_insert;
                    this.sis_log_seq = item.sis_log_seq;
                    this.proc_log_seq = item.proc_log_seq;
                    this.sis_nucleo_prc_cd = item.sis_nucleo_prc_cd;
                    this.sis_log_tag = `${item.sis_log_tag}`.replace("'", "").trimEnd();
                    this.sis_log_info = `${item.sis_log_info}`.replace("'", "").trimEnd();
                    this.sis_batch_run_seq = item.sis_batch_run_seq;
                }
            }
            catch (e) {
                throw new Error(`TbSistema_Log Error:  ${e}`);
            }
        });
    }
}
exports.default = tbsistema_log;
