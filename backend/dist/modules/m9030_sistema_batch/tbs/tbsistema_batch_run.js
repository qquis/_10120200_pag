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
const f9030_01_sistema_batch_run_crud_1 = __importDefault(require("../scriptpg/f9030_01_sistema_batch_run_crud"));
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const model_1 = require("../../../model/model");
class tbsistema_batch_run extends model_1.modelTb {
    constructor(sis_batch_run_seq) {
        super();
        const _dataInitial = Tools_1.default.pagDateTime_getDate();
        this.dtlog_insert = _dataInitial;
        this.dtlog_update = _dataInitial;
        this.sis_batch_cd = 0;
        this.sis_batch_run_seq = sis_batch_run_seq;
        this.sis_batch_run_status_cd = 0;
        this.sis_batch_run_dtlog_start = _dataInitial;
        this.sis_batch_run_dtlog_end = _dataInitial;
    }
    _Db_Pg_script(_stringCommand) {
        const script = `Select * from ${f9030_01_sistema_batch_run_crud_1.default.sqlScript_VERSION()}
            (     vcommand_db:=                     '${_stringCommand}', 
                  vsis_batch_cd:=                    ${this.sis_batch_cd},
                  vsis_batch_run_seq:=               ${this.sis_batch_run_seq},
                  vsis_batch_run_status_cd:=         ${this.sis_batch_run_status_cd},
                  vsis_batch_run_dtlog_start:=       '${Tools_1.default.format_Date_toStr_ShortDataBase(this.sis_batch_run_dtlog_start)}',
                  vsis_batch_run_dtlog_end:=         '${Tools_1.default.format_Date_toStr_ShortDataBase(this.sis_batch_run_dtlog_end)}'
                )`;
        return script;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item !== undefined) {
                    const _dataDefault = Tools_1.default.pagDateTime_getDate();
                    this.sis_batch_cd = item.sis_batch_cd;
                    this.sis_batch_run_seq = item.sis_batch_run_seq;
                    this.sis_batch_run_status_cd = item.sis_batch_run_status_cd;
                    this.sis_batch_run_dtlog_start = Tools_1.default.pagDateTime_getDate(item.sis_batch_run_dtlog_start ? item.sis_batch_run_dtlog_start : _dataDefault);
                    this.sis_batch_run_dtlog_end = Tools_1.default.pagDateTime_getDate(item.sis_batch_run_dtlog_end ? item.sis_batch_run_dtlog_end : _dataDefault);
                }
            }
            catch (e) {
                throw `tbsistema_batch_run | ${e}`;
            }
        });
    }
}
exports.default = tbsistema_batch_run;
