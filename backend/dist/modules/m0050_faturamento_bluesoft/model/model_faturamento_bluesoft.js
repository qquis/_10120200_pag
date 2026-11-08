"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const tbfaturamento_bluesoft_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft"));
const tbfaturamento_bluesoft_origem_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_origem"));
class model_faturamento_bluesoft {
    constructor() {
        this.faturamento = new tbfaturamento_bluesoft_1.default();
        this.origem = new tbfaturamento_bluesoft_origem_1.default();
        this.itens = [];
        this.cdparticipantecliente = 0;
        this.cdparticipantevendedor = 0;
    }
    model_binding(item) {
        try {
            if (item) {
                this.faturamento.binding(item);
                this.origem.binding(item);
            }
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException("model_fatutamento_bluesoft", "model_binding", e);
        }
    }
}
exports.default = model_faturamento_bluesoft;
