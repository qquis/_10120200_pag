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
const report_Zeus_Voucher_1 = __importDefault(require("./report.Zeus.Voucher"));
const report_ZanthusCarga_1 = __importDefault(require("./report.ZanthusCarga"));
class reportZanthus {
    static ZeusVoucherQtdeProdutos(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let result;
            try {
                result = yield report_Zeus_Voucher_1.default.get(parametros);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`reportZanthus`, 'ZeusVoucherQtdeProdutos', e);
                throw new Error(`reportZanthus | ZeusVoucherQtdeProdutos | Error \n ${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
reportZanthus.ZanthusCarga = report_ZanthusCarga_1.default;
exports.default = reportZanthus;
