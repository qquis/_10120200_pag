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
class tbprodutoembalagem_gtins extends modelbase_1.clsBase {
    constructor() {
        super();
        this.dtlog_insert = this.__defaultDateNow;
        this.dtlog_update_api = this.__defaultDateNow;
        this.dtlog_update = this.__defaultDateNow;
        this.prb_cdprodutobluesoft = 0;
        this.pr_cdproduto = 0;
        this.pre_embalagem = '';
        this.preg_cdbarra = '';
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_insert, `YYYY-MM-DD HH:mm:ss`);
                this.dtlog_update_api = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_update_api, `YYYY-MM-DD HH:mm:ss`);
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_update, `YYYY-MM-DD HH:mm:ss`);
                this.prb_cdprodutobluesoft = item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoft;
                this.pr_cdproduto = item === null || item === void 0 ? void 0 : item.pr_cdproduto;
                this.pre_embalagem = item === null || item === void 0 ? void 0 : item.pre_embalagem;
                this.preg_cdbarra = item === null || item === void 0 ? void 0 : item.preg_cdbarra;
            }
        });
    }
}
exports.default = tbprodutoembalagem_gtins;
