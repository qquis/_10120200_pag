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
class tbfaturamento_bluesoft_origem extends model_1.modelTb {
    constructor() {
        super();
        this.dtlog_insert = this.__defaultDateNow;
        this.dtlog_update = this.__defaultDateNow;
        this.fat_blue_origem_seq = 0;
        this.numeropedido = 0;
        this.numeropedido_fv = 0;
        this.op_cdoperacao = 0;
        this.df_nf_seq_blue = 0;
        this.df_nf_seq_blue_dev = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.dtlog_insert = Tools_1.default._dataMomentoStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_insert, `YYYY-MM-DD HH:mm:ss`);
                this.dtlog_update = Tools_1.default._dataMomentoStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_update, `YYYY-MM-DD HH:mm:ss`);
                this.fat_blue_origem_seq = item === null || item === void 0 ? void 0 : item.fat_blue_origem_seq;
                this.numeropedido_fv = item === null || item === void 0 ? void 0 : item.numeropedido_fv;
                this.numeropedido = item === null || item === void 0 ? void 0 : item.numeropedido;
                this.op_cdoperacao = item === null || item === void 0 ? void 0 : item.op_cdoperacao;
                this.df_nf_seq_blue_dev = item === null || item === void 0 ? void 0 : item.df_nf_seq_blue_dev;
                this.df_nf_seq_blue = item === null || item === void 0 ? void 0 : item.df_nf_seq_blue;
            }
        });
    }
}
exports.default = tbfaturamento_bluesoft_origem;
