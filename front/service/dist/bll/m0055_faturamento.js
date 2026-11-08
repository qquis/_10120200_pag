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
var _a;
Object.defineProperty(exports, "__esModule", { value: true });
require("dotenv/config");
const Tools_1 = __importDefault(require("../tools/Tools"));
const pag_1 = __importDefault(require("../api/pag"));
const ENVIRONMENT = (_a = process.env) === null || _a === void 0 ? void 0 : _a.ENVIRONMENT;
const DEBUG_LOG = false;
function m0055_faturamento() {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            if (ENVIRONMENT == "DES") {
                DEBUG_LOG == true;
            }
            const stringData_Processamento = Tools_1.default.pagDateTime_getDateStringShortBrBarra(Tools_1.default.Date_br_current());
            Tools_1.default.pagConsoleLog(`Step 001 _ m0055_faturamento | Iniciando Faturamento (Data: ${stringData_Processamento})`, DEBUG_LOG);
            const url = `${process.env.PAG_API_URL}/faturamento/filter/integrate`;
            const data = m0055_faturamento_data();
            yield pag_1.default.ApiGet(url, data);
        }
        catch (e) {
            Tools_1.default.pagConsoleLog(`m0055_faturamento | Error ${e}`, true);
        }
        finally {
            Tools_1.default.pagConsoleLog(`m0055_faturamento | Finalizado`, DEBUG_LOG);
        }
    });
}
function m0055_faturamento_data() {
    const data = {
        filter: {
            seqfaturamento: 0,
            seqfaturamentoorigem: 0,
            datafaturamento_ini: Tools_1.default.pagDateTime_getDateStringShortBrBarra(Tools_1.default.Date_br_current()),
            datafaturamento_fim: Tools_1.default.pagDateTime_getDateStringShortBrBarra(Tools_1.default.Date_br_current()),
            sat_ecf: 0,
            cupom_fiscal: 0,
            cdparticipantecliente: 0,
            cdparticipantevendedor: 0
        },
        post_integracao: {
            integracao_tipo: "ZANTHUS",
            integracao_registro: "PENDENTE"
        },
        get_zanthus: {
            zanthus_base: "Zanthus",
            zanthus_tipo: "ctrlcupom"
        }
    };
    return data;
}
exports.default = m0055_faturamento;
