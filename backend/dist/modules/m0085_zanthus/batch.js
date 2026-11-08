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
const serviceAtualizacaoClientes_1 = __importDefault(require("./service/serviceAtualizacaoClientes"));
const serviceAtualizacao_Carga_DeskTop_1 = __importDefault(require("./service/serviceAtualizacao.Carga.DeskTop"));
class batch_module_m0085 {
    static Procedimento(nucleo_procedimento) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield this.AtualizacaoDiaria();
                return true;
            }
            catch (e) {
                return false;
            }
            finally {
                return true;
            }
        });
    }
    static AtualizacaoDiaria() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                //await serviceAtualizacaoGeralFiscal.start({});
                yield serviceAtualizacaoClientes_1.default.start({});
                yield serviceAtualizacao_Carga_DeskTop_1.default.start({});
                return true;
            }
            catch (e) {
                return false;
            }
        });
    }
}
exports.default = batch_module_m0085;
