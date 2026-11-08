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
const Tools_1 = __importDefault(require("../../../../tools/Tools"));
const faturamentozanthus_1 = __importDefault(require("../faturamentozanthus/faturamentozanthus"));
const Zanthus_1 = __importDefault(require("../Zanthus/Zanthus"));
class integrateZanthusCtrl {
    static start(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                Tools_1.default.pagConsole("Integracao Zanthus CTRL - Start");
                yield this._ECF_Atualizar_Integracao(filter);
                return yield this._ECF_Obter_Pendentes(filter);
            }
            catch (e) {
                Tools_1.default.PagErrorException(`integrateZanthusCtrl`, `start`, e, false, "Atualização dos registros de Zanthus/Ctrl");
                throw new Error(`integrateZanthusCtrl - start - ${e}`);
            }
        });
    }
    static _ECF_Atualizar_Integracao(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                // __ 06/09/2025 _ desabiliar acesso ao SQL Server __ 
                //await FaturamentoZanthus.Ctrl_List(await Zanthus.Ctrl_Get(filter, "ZANTHUSSQLSERVER"), true)
                yield faturamentozanthus_1.default.Ctrl_List(yield Zanthus_1.default.Ctrl_Get(filter, "ZANTHUSPOSTGRE"), true);
            }
            catch (e) {
                yield Tools_1.default.pagConsoleLog(`_ECF_Atualizar_Integracao \n ${e}`);
            }
        });
    }
    static CtrlUpdatePagFaturamento(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield faturamentozanthus_1.default.Ctrl_FaturamentoUpdate(filter);
            }
            catch (e) {
                yield Tools_1.default.pagConsoleLog(`_ECF_Obter_Pendentes ${e}`);
            }
        });
    }
    static _ECF_Obter_Pendentes(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let list = yield faturamentozanthus_1.default.Report_Ctrl_Get(filter);
                return Promise.resolve(list);
            }
            catch (e) {
                yield Tools_1.default.pagConsoleLog(`_ECF_Obter_Pendentes ${e}`);
                return Promise.reject([]);
            }
        });
    }
}
exports.default = integrateZanthusCtrl;
