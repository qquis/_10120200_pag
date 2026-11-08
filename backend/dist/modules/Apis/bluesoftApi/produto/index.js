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
const blueSoftApiProduto_1 = __importDefault(require("./blueSoftApiProduto"));
const apibluesoft_produto = (0, express_1.Router)();
const myApiProduto = new blueSoftApiProduto_1.default();
apibluesoft_produto.get("/all", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    return response.send(yield myApiProduto.listall());
}));
apibluesoft_produto.get("/ultimaalteracao", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    return response.send(yield myApiProduto.listUltAlteracaoD1());
}));
apibluesoft_produto.get("/", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    const help = [
        {
            url: "/all",
            info: "listagem geral de produtos (Numero de Paginas 100/650"
        },
        {
            url: "/ultimaalteracao",
            info: "listagem geral de produtos considerando a data da ultima alteracao"
        }
    ];
    return response.send(help);
}));
exports.default = apibluesoft_produto;
