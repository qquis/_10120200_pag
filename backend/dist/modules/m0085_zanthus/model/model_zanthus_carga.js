"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbZanthusCarga_1 = __importDefault(require("../tbs/tbZanthusCarga"));
const model_zanthus_carga_produto_1 = __importDefault(require("./model_zanthus_carga_produto"));
class model_zanthus_carga extends tbZanthusCarga_1.default {
    constructor() {
        super();
        this.zanthusCargaProduto = new model_zanthus_carga_produto_1.default();
    }
    scriptAtualizarStatusIniciar() {
        return `Update tbzanthus_carga
                SET carga_status_cd = 2
                ,   dtlog_update = current_timestamp
                ,   carga_hora_ini = current_timestamp
                WHERE carga_uuid = '${this.carga_uuid}'`;
    }
    scriptAtualizarStatusFinalizar() {
        return `Update tbzanthus_carga
                SET carga_status_cd = 3
                ,   dtlog_update = current_timestamp
                ,   carga_hora_fim = current_timestamp
                WHERE carga_uuid = '${this.carga_uuid}'`;
    }
}
exports.default = model_zanthus_carga;
