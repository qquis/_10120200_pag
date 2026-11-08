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
const Tools_1 = __importDefault(require("../../tools/Tools"));
const integratezanthuspag_1 = __importDefault(require("./services/Integrate/integratezanthuspag"));
class batch_module_m0055 {
    static start(sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let filter = {
                    filter: {
                        seqfaturamento: 0,
                        seqfaturamentoorigem: 0,
                        datafaturamento_ini: Tools_1.default.Date_br_current(),
                        datafaturamento_fim: Tools_1.default.Date_br_current(),
                        sat_ecf: 0,
                        cupom_fiscal: 0,
                        cdparticipantecliente: 0,
                        cdparticipantevendedor: 0
                    },
                    post_integracao: {
                        integracao_tipo: "ZANTHUS",
                        integracao_registro: "PENDENTE",
                        sis_batch_run_seq: sis_batch_run_seq
                    },
                    get_zanthus: {
                        zanthus_base: "Zanthus",
                        zanthus_tipo: "ctrlcupom"
                    }
                };
                yield integratezanthuspag_1.default.Start(filter);
                return true;
            }
            catch (e) {
                return false;
            }
        });
    }
}
exports.default = batch_module_m0055;
