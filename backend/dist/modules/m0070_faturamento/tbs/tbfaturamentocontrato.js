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
class tbfaturamentocontrato extends modelbase_1.clsBase {
    constructor() {
        super();
        this.contrato_seq = 0;
        this.contrato_descricao = '';
        this.contrato_data = new Date();
        this.contrato_tipo_cd = 0;
        this.contrato_data_val_ini = new Date();
        this.contrato_data_val_fim = new Date();
        this.op_cdoperacao = 0;
        this.cdparticipante_contratante = 0;
        this.seqfaturamento = 0;
        this.seqfaturamentoorigem = 0;
        this.faturamento_controle_seq = 0;
        this.contrato_valor = 0;
        this.contrato_uuid = '';
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item) {
                    this.contrato_seq = item === null || item === void 0 ? void 0 : item.contrato_seq;
                    this.contrato_descricao = item === null || item === void 0 ? void 0 : item.contrato_descricao;
                    this.contrato_data = item === null || item === void 0 ? void 0 : item.contrato_data;
                    this.contrato_tipo_cd = item === null || item === void 0 ? void 0 : item.contrato_tipo_cd;
                    this.contrato_data_val_ini = item === null || item === void 0 ? void 0 : item.contrato_data_val_ini;
                    this.contrato_data_val_fim = item === null || item === void 0 ? void 0 : item.contrato_data_val_fim;
                    this.op_cdoperacao = item === null || item === void 0 ? void 0 : item.op_cdoperacao;
                    this.cdparticipante_contratante = item === null || item === void 0 ? void 0 : item.cdparticipante_contratante;
                    this.seqfaturamento = item === null || item === void 0 ? void 0 : item.seqfaturamento;
                    this.seqfaturamentoorigem = item === null || item === void 0 ? void 0 : item.seqfaturamentoorigem;
                    this.faturamento_controle_seq = item === null || item === void 0 ? void 0 : item.faturamento_controle_seq;
                    this.contrato_valor = item === null || item === void 0 ? void 0 : item.contrato_valor;
                    this.contrato_uuid = item === null || item === void 0 ? void 0 : item.contrato_uuid;
                }
            }
            catch (e) {
                this.myTools.pagConsole(`tbfaturamentocontrato | binding \n Error: ${e}`);
                throw new Error(`tbfaturamentocontrato | binding \n Error: ${e}`);
            }
        });
    }
    scriptInsert() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = `
                        insert into tbfaturamentocontrato (
                            contrato_seq,
                            contrato_descricao,
                            contrato_data,
                            contrato_tipo_cd,
                            contrato_data_val_ini,
                            contrato_data_val_fim,
                            op_cdoperacao,
                            cdparticipante_contratante,
                            seqfaturamento,
                            seqfaturamentoorigem,
                            faturamento_controle_seq,
                            contrato_valor,
                            contrato_uuid
                        ) values (
                            ${this.contrato_seq},
                            '${this.contrato_descricao}',
                            '${this.contrato_data.toISOString()}',
                            ${this.contrato_tipo_cd},
                            '${modelbase_1.clsTools._datemomentDateToStr(this.contrato_data_val_ini, "YYYY-MM-DD")}',
                            '${modelbase_1.clsTools._datemomentDateToStr(this.contrato_data_val_fim, "YYYY-MM-DD")}',
                            ${this.op_cdoperacao},
                            ${this.cdparticipante_contratante},
                            ${this.seqfaturamento},
                            ${this.seqfaturamentoorigem},
                            ${this.faturamento_controle_seq},
                            ${this.contrato_valor},
                            '${this.contrato_uuid}'
                        )
            
            `;
            }
            catch (e) {
                this.myTools.pagConsole(`tbfaturamentocontrato | insert \n Error: ${e}`);
                throw new Error(`tbfaturamentocontrato | insert \n Error: ${e}`);
            }
        });
    }
}
exports.default = tbfaturamentocontrato;
