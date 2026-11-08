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
const reportFechamento_1 = __importDefault(require("./reportFechamento"));
const reportCentroOperacionalList_1 = __importDefault(require("./reportCentroOperacionalList"));
const reportContaList_1 = __importDefault(require("./reportContaList"));
const reportRateioList_1 = __importDefault(require("./reportRateioList"));
const reportResponsavelList_1 = __importDefault(require("./reportResponsavelList"));
const reportOperacao_1 = __importDefault(require("./reportOperacao"));
const reportResultado_1 = __importDefault(require("./reportResultado"));
const reportCompetenciaResultado_1 = __importDefault(require("./reportCompetenciaResultado"));
const reportResultadoGrupoList_1 = __importDefault(require("./reportResultadoGrupoList"));
const reportFechamentoLanc_1 = __importDefault(require("./reportFechamentoLanc"));
class reportManagerResultado {
    static fechamento(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield reportFechamento_1.default.get(parametros);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('reportDRE', 'fechamento', e);
            }
        });
    }
    static CentroOperacionalListGet() {
        return __awaiter(this, void 0, void 0, function* () {
            return yield reportCentroOperacionalList_1.default.get();
        });
    }
    static ResultadoContaListGet() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            return yield reportContaList_1.default.get(parametros);
        });
    }
    static ResultadoRateioListGet() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            return yield reportRateioList_1.default.get(parametros);
        });
    }
    static ResultadoResposavelListGet() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            return yield reportResponsavelList_1.default.get(parametros);
        });
    }
    static ResultadoOperacaoListGet() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            return yield reportOperacao_1.default.get(parametros);
        });
    }
    static ResultadoGet() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            return yield reportResultado_1.default.get(parametros);
        });
    }
    static CompetenciaGet() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            return yield reportCompetenciaResultado_1.default.get(parametros);
        });
    }
    static ResultadoGrupoListGet() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            return yield reportResultadoGrupoList_1.default.get(parametros);
        });
    }
    static ResultadoFechamentoLancGet() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            return yield reportFechamentoLanc_1.default.get(parametros);
        });
    }
}
exports.default = reportManagerResultado;
