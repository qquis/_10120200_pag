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
const reportCRMSorteio_1 = __importDefault(require("./reportCRMSorteio"));
const reportCRMSorteioRouter = (0, express_1.Router)();
reportCRMSorteioRouter.get('/list', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield reportCRMSorteio_1.default.List.get(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(500).send({ error: e.message });
    }
}));
reportCRMSorteioRouter.get('/temporada', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield reportCRMSorteio_1.default.Temporada.get(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(500).send({ error: e.message });
    }
}));
reportCRMSorteioRouter.get('/cupom', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield reportCRMSorteio_1.default.Cupom.get(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(500).send({ error: e.message });
    }
}));
reportCRMSorteioRouter.get('/numero', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield reportCRMSorteio_1.default.Numero.get(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(500).send({ error: e.message });
    }
}));
exports.default = reportCRMSorteioRouter;
