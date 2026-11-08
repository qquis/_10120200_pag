"use strict";
//import {clsBase} from '@modelbase'
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
//reports
const reportRhSetorOpercional_1 = __importDefault(require("./reportRhSetorOpercional"));
const reportRhTipoContrato_1 = __importDefault(require("./reportRhTipoContrato"));
const reportRhFolhaContratada_1 = __importDefault(require("./reportRhFolhaContratada"));
const reportRhFolhaPorCompetencia_1 = __importDefault(require("./reportRhFolhaPorCompetencia"));
const reportRhCompetencia_1 = __importDefault(require("./reportRhCompetencia"));
class reportrh {
    static CompetenciaGet() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            try {
                return yield reportRhCompetencia_1.default.get(parametros);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('reportrh', 'competencia', e);
            }
        });
    }
    static FolhaContrataPorCompetenciaGet(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield reportRhFolhaPorCompetencia_1.default.get(parametros);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('reportrh', 'folha_contratada', e);
            }
        });
    }
    static FolhaContratadaGet(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield reportRhFolhaContratada_1.default.get(parametros);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('reportrh', 'folha_contratada', e);
            }
        });
    }
    static SetorOperacional() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield reportRhSetorOpercional_1.default.get();
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('reportrh', 'SetorOperacional', e);
                throw new Error(`Error in SetorOperacional: ${e}`);
            }
        });
    }
    static TipoContrato() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield reportRhTipoContrato_1.default.get();
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('reportrh', 'SetorOperacional', e);
                throw new Error(`Error in SetorOperacional: ${e}`);
            }
        });
    }
}
exports.default = reportrh;
