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
//import f0210_01_notificacao_send_crud from '../scriptspg/f0210_01_notificacao_send_crud'
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const model_1 = require("../../../model/model");
class tbsistema_batch extends model_1.modelTb {
    constructor(sis_batch_cd) {
        super();
        const _dataInitial = Tools_1.default.pagDateTime_getDate();
        this.dtlog_insert = _dataInitial;
        this.dtlog_update = _dataInitial;
        this.sis_batch_cd = sis_batch_cd;
        this.sis_batch_descricao = ``;
        this.sis_batch_service_cd = 0;
        this.module_cd = ``;
    }
    _Db_Pg_script_Select() {
        let stringsql = ``;
        if (this.sis_batch_cd !== 0) {
            stringsql = `   SELECT      sis_batch_cd            
                                        ,   sis_batch_descricao
                                        ,   sis_batch_status 
                                        ,   sis_batch_service_cd 
                                FROM        tbsistema_batch   
                                WHERRE      sis_batch_cd = ${this.sis_batch_cd}
                    `;
        }
        return stringsql;
    }
    _Db_Pg_script(_stringCommand) {
        const script = ``;
        return script;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item != undefined) {
                this.sis_batch_cd = parseInt(item === null || item === void 0 ? void 0 : item.sis_batch_cd);
                this.sis_batch_descricao = item === null || item === void 0 ? void 0 : item.sis_batch_descricao;
                this.sis_batch_service_cd = parseInt(item === null || item === void 0 ? void 0 : item.sis_batch_service_cd);
                this.module_cd = item === null || item === void 0 ? void 0 : item.module_cd;
            }
        });
    }
}
exports.default = tbsistema_batch;
