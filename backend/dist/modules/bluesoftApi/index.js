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
const api_1 = __importDefault(require("./api"));
const produto_1 = __importDefault(require("./produto"));
const myApi = new api_1.default();
const bluesoftapi = (0, express_1.Router)();
bluesoftapi.use("/produto", produto_1.default);
bluesoftapi.get("/", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    const help = {
        url: "/produto",
        info: "Informações sobre produto"
    };
    return response.send(help);
}));
exports.default = bluesoftapi;
