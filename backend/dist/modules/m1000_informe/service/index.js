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
const service_1 = __importDefault(require("./service"));
const serviceInformeRouter = (0, express_1.Router)();
serviceInformeRouter.use("/if0017", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield service_1.default.if0017.start(request.query);
        return response.status(200).send();
    }
    catch (e) {
        return response.status(400).send({ status: 0, info: "Error fetching if0017 report" });
    }
}));
serviceInformeRouter.use("/if0045", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield service_1.default.if0045.start(request.query);
        return response.status(200).send();
    }
    catch (e) {
        return response.status(400).send({ status: 0, info: "Error fetching if0045 report" });
    }
}));
serviceInformeRouter.use("/if0100", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield service_1.default.if0100.start(request.query);
        return response.status(200).send();
    }
    catch (e) {
        return response.status(400).send({ status: 0, info: "Error fetching if0100 report" });
    }
}));
serviceInformeRouter.use("/if0050", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield service_1.default.if0050.start(request.query);
        return response.status(200).send();
    }
    catch (e) {
        return response.status(400).send({ status: 0, info: "Error fetching if0050 report" });
    }
}));
serviceInformeRouter.use("/if0110", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield service_1.default.if0110.start(request.query);
        return response.status(200).send();
    }
    catch (e) {
        return response.status(400).send({ status: 0, info: "Error fetching if0110 report" });
    }
}));
exports.default = serviceInformeRouter;
