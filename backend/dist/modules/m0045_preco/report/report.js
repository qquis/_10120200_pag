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
const reportPrecoAgendado_1 = __importDefault(require("./reportPrecoAgendado"));
const reportPrecoAplicacao_1 = __importDefault(require("./reportPrecoAplicacao"));
class reportPreco {
    constructor() {
        this.__reportPrecoAplicado = new reportPrecoAplicacao_1.default();
        this.__reportPrecoAgendado = new reportPrecoAgendado_1.default();
    }
    PrecosAplicados(request) {
        return __awaiter(this, void 0, void 0, function* () {
            return yield this.__reportPrecoAplicado.dataPag_get(request);
        });
    }
    PrecosAplicadosIntegracaoBlueSoftPendente() {
        return __awaiter(this, void 0, void 0, function* () {
            this.__reportPrecoAplicado.Filtros.tipo_relatorio = "INTEGRACAO_BLUESOFT_PENDENTE";
            return yield this.__reportPrecoAplicado.dataPag_get(null);
        });
    }
    PrecosAplicadosIntegracaoBlueSoftGeral() {
        return __awaiter(this, void 0, void 0, function* () {
            this.__reportPrecoAplicado.Filtros.tipo_relatorio = "INTEGRACAO_BLUESOFT";
            return yield this.__reportPrecoAplicado.dataPag_get(null);
        });
    }
    PrecoAgendadoIntegracaoBlueSoftPendente() {
        return __awaiter(this, void 0, void 0, function* () {
            this.__reportPrecoAgendado.Filtros.tipo_relatorio = "INTEGRACAO_BLUESOFT_PENDENTE";
            return yield this.__reportPrecoAgendado.dataPag_get(null);
        });
    }
}
exports.default = reportPreco;
