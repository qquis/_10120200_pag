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
const modelbase_1 = require("../../model/modelbase");
/*-----------------------------------------------------*/
const service_1 = __importDefault(require("./service/service"));
class batch_module_m0005 {
    static Procedimento(sistema_nucleo_procedimento) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return true;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`M0080`, `batch_module_m0005.Procedimento Error`, e);
                return false;
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`Procedimento ${sistema_nucleo_procedimento.sis_nucleo_prc_descricao} finalizado`, true);
                return true;
            }
        });
    }
    static AtualizacaoDiaria() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield service_1.default.metasAtuais.start({});
                return true;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`M0080`, `batch_module_m0005.Procedimento Error`, e);
                return false;
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`Procedimento ${"Atualizacao Diaria"} finalizado`, true);
                return true;
            }
        });
    }
}
exports.default = batch_module_m0005;
