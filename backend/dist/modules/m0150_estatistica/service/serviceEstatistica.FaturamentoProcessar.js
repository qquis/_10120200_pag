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
/*Imports*/
const scriptdbEstatistica_1 = __importDefault(require("../scriptdb/scriptdbEstatistica"));
const service_SistemaLog_1 = __importDefault(require("../../m9020_sistema_log/service/service.SistemaLog"));
/*Codigos de Procedimentos utilizados*/
const SIS_NUCLEO_PRC_CD_ATUALIZAR_ESTATISTICA = 10150010;
class serviceEstatisticaFaturamentoProcessar {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myDataBase = new modelbase_1.clsBase();
                const result = yield myDataBase.myDataBase.pag.Execute(scriptdbEstatistica_1.default.f0150_01_estatistica_processamento.get(parametro));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceEstatisticaFaturamentoProcessar", "start", e);
            }
        });
    }
    static onLineExec() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let dataHoje = new Date();
                yield this.start({ dataFaturamento_ini: dataHoje, dataFaturamento_fim: dataHoje, vprocessamento_parcial: 1 });
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceEstatisticaFaturamentoProcessar", "onLineExec", e);
            }
        });
    }
    static dailyExec() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let dataInicial = modelbase_1.clsTools._datemomentSubtractDays(new Date(), 45);
                let dataFinal = new Date();
                if (!(yield service_SistemaLog_1.default.Registrar.LogNucleoProcedimentoToday(SIS_NUCLEO_PRC_CD_ATUALIZAR_ESTATISTICA))) {
                    yield this.start({ dataFaturamento_ini: dataInicial, dataFaturamento_fim: dataFinal, vprocessamento_parcial: 0 });
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceEstatisticaFaturamentoProcessar", "dailyExec", e);
            }
        });
    }
}
exports.default = serviceEstatisticaFaturamentoProcessar;
