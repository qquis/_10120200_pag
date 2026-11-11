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
const m1000_informe = (0, express_1.Router)();
const batch_1 = __importDefault(require("./batch"));
const service_1 = __importDefault(require("./service"));
const report_1 = __importDefault(require("./report"));
const model_1 = __importDefault(require("./model"));
m1000_informe.use('/service', service_1.default);
m1000_informe.use('/report', report_1.default);
m1000_informe.use('/model', model_1.default);
m1000_informe.post('/batch/inicializacao-diaria', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield batch_1.default.AtualizacaoDiaria();
    }
    catch (e) {
        res.status(500).send({ error: e });
    }
    res.status(200).send({ message: 'Processo concluído com sucesso' });
}));
exports.default = m1000_informe;
