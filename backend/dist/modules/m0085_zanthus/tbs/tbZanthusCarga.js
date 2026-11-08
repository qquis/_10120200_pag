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
const modelbase_1 = require("../../../model/modelbase");
class tbzanthus_carga extends model_1.modelTb {
    constructor() {
        super();
        this.carga_uuid = ``;
        this.carga_seq = 0;
        this.carga_data = this.__defaultDateNow;
        this.carga_status_cd = 0;
        this.carga_hora_ini = this.__defaultDateNow;
        this.carga_hora_fim = this.__defaultDateNow;
        this.carga_tipo_cd = 0;
        this.carga_usr_seq_create = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.carga_uuid = item === null || item === void 0 ? void 0 : item.carga_uuid;
                this.carga_seq = parseInt(item === null || item === void 0 ? void 0 : item.carga_seq);
                this.carga_data = (item === null || item === void 0 ? void 0 : item.carga_data) ? new Date(item.carga_data) : this.__defaultDateNow;
                this.carga_status_cd = parseInt(item === null || item === void 0 ? void 0 : item.carga_status_cd);
                this.carga_hora_ini = (item === null || item === void 0 ? void 0 : item.carga_hora_ini) ? new Date(item.carga_hora_ini) : this.__defaultDateNow;
                this.carga_hora_fim = (item === null || item === void 0 ? void 0 : item.carga_hora_fim) ? new Date(item.carga_hora_fim) : this.__defaultDateNow;
                this.carga_tipo_cd = parseInt(item === null || item === void 0 ? void 0 : item.carga_tipo_cd);
                this.carga_usr_seq_create = parseInt(item === null || item === void 0 ? void 0 : item.carga_usr_seq_create);
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`M0085 _ Zanthus | tbZanthusCarga.binding Error: ${e}`, true);
            }
        });
    }
    _Db_Pg_script_Insert() {
        return `
                        INSERT INTO		tbzanthus_carga (
                                            carga_uuid
                                        ,	carga_status_cd
                                        ,	carga_hora_ini
                                        ,	carga_hora_fim
                                        ,	carga_tipo_cd
                                        ,	carga_usr_seq_create
                                        )
    
                            SELECT			DISTINCT
                                            '${this.carga_uuid}'
                                        ,	1
                                        ,	'${modelbase_1.clsTools._datemomentDateToStr(this.carga_hora_ini, 'YYYY-MM-DD HH:mm:ss')}'::timestamp
                                        ,	'${modelbase_1.clsTools._datemomentDateToStr(this.carga_hora_fim, 'YYYY-MM-DD HH:mm:ss')}'::timestamp
                                        ,	${this.carga_tipo_cd}
                                        ,	${this.carga_usr_seq_create}
                            WHERE NOT EXISTS (
                                            SELECT 1
                                            FROM tbzanthus_carga
                                            WHERE carga_uuid = '${this.carga_uuid}'
                                        );
            `;
    }
    _Db_Pg_script_Update() {
        return `
                        UPDATE  tbzanthus_carga
                           SET  carga_status_cd = ${this.carga_status_cd}
                            ,   carga_hora_ini = '${modelbase_1.clsTools._datemomentDateToStr(this.carga_hora_ini, 'YYYY-MM-DD HH:mm:ss')}'::timestamp
                            ,   carga_hora_fim = '${modelbase_1.clsTools._datemomentDateToStr(this.carga_hora_fim, 'YYYY-MM-DD HH:mm:ss')}'::timestamp
                            ,   dtlog_update = current_timestamp
                        WHERE   carga_uuid = '${this.carga_uuid}'
            `;
    }
}
exports.default = tbzanthus_carga;
