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
exports.wk = void 0;
const Tools_1 = __importDefault(require("../../tools/Tools"));
/*Data Base */
//Services
const Zanthus_1 = __importDefault(require("./services/Zanthus/Zanthus"));
const integratezanthuspag_1 = __importDefault(require("./services/Integrate/integratezanthuspag"));
const wk_faturamentoforcavenda_1 = __importDefault(require("./services/FaturamentoForcaVenda/wk.faturamentoforcavenda"));
const integratezanthusctrl_1 = __importDefault(require("./services/Integrate/integratezanthusctrl"));
class wk {
    FilterRequest_get(request) {
        try {
            /* Filter padrão para processamento dos cupons pendentes de qualquer ecf */
            let seqfaturamento = 0;
            let seqfaturamentoorigem = 0;
            let datafaturamento_ini = Tools_1.default.Date_br_current();
            let datafaturamento_fim = Tools_1.default.Date_br_current();
            let sat_ecf = 0;
            let cupom_fiscal = 0;
            let cdparticipantecliente = 0;
            let cdparticipantevendedor = 0;
            let integracao_tipo = "ZANTHUS";
            let integracao_registro = "PENDENTE";
            let sis_batch_run_seq = 0;
            let zanthus_base = "Zanthus";
            let zanthus_tipo = "ctrlcupom";
            console.log(datafaturamento_ini);
            //filter 
            if (request) {
                seqfaturamento = parseInt(`${request.body.filter.seqfaturamento}`);
                seqfaturamentoorigem = parseInt(`${request.body.filter.seqfaturamentoorigem}`);
                datafaturamento_ini = Tools_1.default.Date_br_new(`${request.body.filter.datafaturamento_ini}`);
                datafaturamento_fim = Tools_1.default.Date_br_new(`${request.body.filter.datafaturamento_fim}`);
                sat_ecf = parseInt(`${request.body.filter.sat_ecf}`);
                cupom_fiscal = parseInt(`${request.body.filter.cupom_fiscal}`);
                cdparticipantecliente = parseInt(`${request.body.filter.cdparticipantecliente}`);
                cdparticipantevendedor = parseInt(`${request.body.filter.cdparticipantevendedor}`);
                integracao_tipo = `${request.body.post_integracao.integracao_tipo}`;
                integracao_registro = `${request.body.post_integracao.integracao_registro}`;
                zanthus_base = `${request.body.get_zanthus.zanthus_base}`;
                zanthus_tipo = `${request.body.get_zanthus.zanthus_tipo}`;
            }
            let filter = {
                filter: {
                    seqfaturamento,
                    seqfaturamentoorigem,
                    datafaturamento_ini,
                    datafaturamento_fim,
                    sat_ecf,
                    cupom_fiscal,
                    cdparticipantecliente,
                    cdparticipantevendedor
                },
                post_integracao: {
                    integracao_tipo,
                    integracao_registro,
                    sis_batch_run_seq
                },
                get_zanthus: {
                    zanthus_base,
                    zanthus_tipo
                }
            };
            return filter;
        }
        catch (e) {
            console.log(`Service | FilterRequest_get: ${e}`);
            return {};
        }
    }
    Zanthus(request, response) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a;
            let filter = this.FilterRequest_get(request);
            let result = {};
            switch ((_a = filter.get_zanthus) === null || _a === void 0 ? void 0 : _a.zanthus_tipo) {
                case "ctrl":
                    result = yield Zanthus_1.default.Ctrl_Get(filter);
                    break;
                case "ctrlcupom":
                    result = yield Zanthus_1.default.CtrlCupom_Get(filter);
                    break;
                case "cupom":
                    console.log("CupomGet");
                    break;
                case "item":
                    console.log("CupomGet");
                    break;
            }
            return response.json(result);
        });
    }
    integrateZanthusPag(request, response) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a;
            let result = {};
            try {
                let filter = this.FilterRequest_get(request);
                switch ((_a = filter.post_integracao) === null || _a === void 0 ? void 0 : _a.integracao_tipo) {
                    case "ZANTHUS":
                        result = yield integratezanthuspag_1.default.Start(this.FilterRequest_get(request));
                        break;
                }
                return response.json(result);
            }
            catch (e) {
                return response.json(result);
            }
        });
    }
    integrateZanthusPagPendentes(request, response) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                result = yield integratezanthuspag_1.default.Start(this.FilterRequest_get());
                return response.json(result);
            }
            catch (e) {
                return response.json(result);
            }
        });
    }
    integrateZanthusData(request, response) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                //result = await integrateZanthusPag.Start(this.FilterRequest_get()); 
                let data = Tools_1.default.Date_br_new(`${request.query.data}`);
                let satecf = parseInt(`${request.query.satecf}`);
                let processavendapendente = `${request.query.processavendapendente}`;
                if (!processavendapendente)
                    processavendapendente = "1";
                let filter = {
                    filter: {
                        seqfaturamento: 0,
                        seqfaturamentoorigem: 0,
                        datafaturamento_ini: data,
                        datafaturamento_fim: data,
                        sat_ecf: satecf,
                        cupom_fiscal: 0,
                        cdparticipantecliente: 0,
                        cdparticipantevendedor: 0
                    },
                    post_integracao: {
                        integracao_tipo: "ZANTHUS",
                        integracao_registro: processavendapendente == "1" ? "PENDENTE" : "ALL",
                        sis_batch_run_seq: 0
                    },
                    get_zanthus: {
                        zanthus_base: "Zanthus",
                        zanthus_tipo: "ctrlcupom"
                    }
                };
                result = yield integratezanthuspag_1.default.Start(filter);
                return response.json(result);
            }
            catch (e) {
                return response.json(result);
            }
        });
    }
    integratectrl(request, response) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                //result = await integrateZanthusPag.Start(this.FilterRequest_get()); 
                let data = Tools_1.default.Date_br_new(`${request.query.data}`);
                let processavendapendente = `${request.query.processavendapendente}`;
                if (!processavendapendente)
                    processavendapendente = "1";
                console.log(`data selecionada ${data}`);
                let filter = {
                    filter: {
                        seqfaturamento: 0,
                        seqfaturamentoorigem: 0,
                        datafaturamento_ini: data,
                        datafaturamento_fim: data,
                        sat_ecf: 0,
                        cupom_fiscal: 0,
                        cdparticipantecliente: 0,
                        cdparticipantevendedor: 0
                    },
                    post_integracao: {
                        integracao_tipo: "ZANTHUS",
                        integracao_registro: processavendapendente == "1" ? "PENDENTE" : "ALL",
                        sis_batch_run_seq: 0
                    },
                    get_zanthus: {
                        zanthus_base: "Zanthus",
                        zanthus_tipo: "ctrlcupom"
                    }
                };
                result = yield integratezanthusctrl_1.default.start(filter);
                return response.json(result);
            }
            catch (e) {
                return response.json(result);
            }
        });
    }
    ForcaVenda(request, response) {
        return __awaiter(this, void 0, void 0, function* () {
            return response.json(yield wk_faturamentoforcavenda_1.default.Obter());
        });
    }
    batch(request, response) {
        return __awaiter(this, void 0, void 0, function* () {
            return [];
        });
    }
}
exports.wk = wk;
