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
const F0040_05_fiscal_mapeamento_1 = __importDefault(require("../script/F0040_05_fiscal_mapeamento"));
const myBase = new modelbase_1.clsBase();
class serviceFiscal_AtualizaMapeamentoFiscal {
    static start() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield myBase.myDataBase.pag.Execute(F0040_05_fiscal_mapeamento_1.default.defaultExecution());
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscal_Figura', e);
            }
            finally {
                modelbase_1.clsTools.pagConsole('M0040_FISCAL', true, false);
            }
        });
    }
}
exports.default = serviceFiscal_AtualizaMapeamentoFiscal;
