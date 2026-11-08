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
const serviceFaturamentoBluesoftProcessar_1 = __importDefault(require("./service/serviceFaturamentoBluesoftProcessar"));
const serviceFaturamentoContratoProcessarApurar_1 = __importDefault(require("./service/serviceFaturamentoContratoProcessarApurar"));
class batch_module_m0070 {
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
                const fmt = (d) => `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, "0")}-${String(d.getDate()).padStart(2, "0")}`;
                const hoje = new Date();
                for (let i = -4; i <= -1; i++) {
                    let parametro = {};
                    const d = new Date(hoje);
                    d.setDate(d.getDate() + i);
                    const dataprocessamento = fmt(d);
                    parametro.data_processamento = dataprocessamento;
                    yield serviceFaturamentoBluesoftProcessar_1.default.start(parametro);
                    yield modelbase_1.clsTools.pagConsole(`Processando faturamento contrato para data: ${dataprocessamento}`, true, false, ``);
                    parametro.op_cdoperacao = 4;
                    parametro.dataFaturamento_filter = 1;
                    parametro.faturamento_controle_seq = 0;
                    parametro.contrato_seq = 0;
                    parametro.data_val_ini = modelbase_1.clsTools._datemomentDatStrToDate(parametro.data_processamento, "YYYY-MM-DD");
                    parametro.data_val_fim = modelbase_1.clsTools._datemomentDatStrToDate(parametro.data_processamento, "YYYY-MM-DD");
                    yield serviceFaturamentoContratoProcessarApurar_1.default.start(parametro);
                }
                return true;
            }
            catch (e) {
                return false;
            }
        });
    }
}
exports.default = batch_module_m0070;
