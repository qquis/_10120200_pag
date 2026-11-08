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
const servicePrecoAgendado_1 = __importDefault(require("./servicePrecoAgendado"));
const servicePrecoAplicado_1 = __importDefault(require("./servicePrecoAplicado"));
const serviceAplicacao_1 = __importDefault(require("./serviceAplicacao"));
class service {
    static integrarBlueSoftPrecoAplicado() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let PrecoAplicado = new servicePrecoAplicado_1.default();
                yield PrecoAplicado.bluesoftIntegrarPrecos(0);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0045`, `integrarBlueSoftPrecoAplicado.start Error`, e);
            }
        });
    }
    static integrarBlueSoftPrecoAgedando() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let PrecoAgedando = new servicePrecoAgendado_1.default();
                yield PrecoAgedando.bluesoftIntegrar(0);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0045`, `integrarBlueSoftPrecoAgedando.start Error`, e);
            }
        });
    }
    static AplicarPrecos() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            let statusExecucao = false;
            try {
                statusExecucao = yield serviceAplicacao_1.default.start(parametros);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0045`, `serviceAplicacao.start Error`, e);
            }
            finally {
                return statusExecucao;
            }
        });
    }
}
exports.default = service;
