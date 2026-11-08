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
const modelbase_1 = require("../../../model/modelbase");
const rptNotificacaoSendMessage_1 = __importDefault(require("./rptNotificacaoSendMessage"));
class ReportNotificacaox extends modelbase_1.clsBase {
    constructor() {
        super();
    }
    rptNotificacaoSendMessageGet(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let rpt = new rptNotificacaoSendMessage_1.default();
            try {
                let result = yield this.myDataBase.pag.DataGet(rpt.sql(filter));
                if (result) {
                    yield rpt.dataBinding(result);
                }
            }
            catch (e) {
                this.myTools.PagErrorException('ReportNotificacaox', 'rptNotificacaoSendMessageGet', e);
            }
            finally {
                return rpt;
            }
        });
    }
}
exports.default = ReportNotificacaox;
