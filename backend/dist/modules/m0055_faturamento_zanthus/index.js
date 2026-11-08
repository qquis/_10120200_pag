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
const express_1 = require("express");
const wk_1 = require("./wk");
const report_1 = __importDefault(require("./report"));
const Wk = new wk_1.wk();
const faturamentoZanthus = (0, express_1.Router)();
const filter = (0, express_1.Router)();
//const entity = Router(); 
faturamentoZanthus.get("/", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    return response.status(200).send({ status: "1", info: "M0055 - Faturamento Zanthus - Ativo" });
}));
faturamentoZanthus.use('/report', report_1.default);
faturamentoZanthus.use("/filter", filter);
//faturamento.get("/entity", entity)
/*opt filter*/
filter.get("/zanthus", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        return yield Wk.Zanthus(request, response);
    }
    catch (e) {
        console.log(e);
    }
}));
filter.get("/integrate", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        return yield Wk.integrateZanthusPag(request, response);
    }
    catch (e) {
        console.log(e);
    }
}));
filter.get("/integratedata", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        return yield Wk.integrateZanthusData(request, response);
    }
    catch (e) {
        return { dados: `error na execução do /integratedata  ${e}` };
    }
}));
filter.get("/integratectrl", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        console.log("Entrou no ctrl");
        return yield Wk.integratectrl(request, response);
    }
    catch (e) {
        return { dados: `error na execução do /integratedata  ${e}` };
    }
}));
filter.get("/integratependente", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        return yield Wk.integrateZanthusPagPendentes(request, response);
    }
    catch (e) {
        console.log(e);
    }
}));
filter.get('/forcavenda', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        return yield Wk.ForcaVenda(request, response);
    }
    catch (e) {
        console.log(e);
    }
}));
exports.default = faturamentoZanthus;
