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
exports.modelmovimento_caixa_bluesoft = exports.modelmovimentocaixabluesoftRouter = void 0;
const modelbase_1 = require("../../../model/modelbase");
const express_1 = require("express");
const tbmovimento_caixa_bluesoft_1 = __importDefault(require("../tbs/tbmovimento_caixa_bluesoft"));
const f0080_02_movimento_caixa_bluesoft_integ_1 = __importDefault(require("../scriptpg/f0080_02_movimento_caixa_bluesoft_integ"));
const myClsBase = new modelbase_1.clsBase();
const modelmovimentocaixabluesoftRouter = (0, express_1.Router)();
exports.modelmovimentocaixabluesoftRouter = modelmovimentocaixabluesoftRouter;
modelmovimentocaixabluesoftRouter.get("/", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let item = new modelmovimento_caixa_bluesoft();
    try {
        if (req.query) {
            if (req.query.aut_pgto_pag_seq) {
                yield item.select({ aut_pgto_pag_seq: req.query.aut_pgto_pag_seq });
            }
        }
        else {
            yield item.new();
        }
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("M0080", "modelautorizacaoPagamentoPagRouter", e);
    }
    finally {
        return res.send(item);
    }
}));
modelmovimentocaixabluesoftRouter.post("/", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    const modelmovimento_caixa_bluesoftPost = new modelmovimento_caixa_bluesoft();
    yield modelmovimento_caixa_bluesoftPost.update(req.body);
    return res.send(modelmovimento_caixa_bluesoftPost);
}));
class modelmovimento_caixa_bluesoft extends tbmovimento_caixa_bluesoft_1.default {
    constructor() {
        super();
        this.new();
    }
    new() {
        return __awaiter(this, void 0, void 0, function* () {
        });
    }
    update(DataBory) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ``;
            try {
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("M0080-Financeiro", "FinanceiroPag/Insert", e);
            }
        });
    }
    select(filtros) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ``;
            let result = yield myClsBase.myDataBase.pag.DataGet(sql);
            let dataItem = yield myClsBase.myDataBase.RecordItem(result, 0);
            if (dataItem) {
                this.binding(dataItem);
            }
        });
    }
    integSql_get() {
        return f0080_02_movimento_caixa_bluesoft_integ_1.default.get(this);
    }
}
exports.modelmovimento_caixa_bluesoft = modelmovimento_caixa_bluesoft;
