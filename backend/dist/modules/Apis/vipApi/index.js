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
const modelbase_1 = require("../../../model/modelbase");
const express_1 = require("express");
const vipApi = (0, express_1.Router)();
const api_1 = __importDefault(require("./api"));
vipApi.get("/", (req, res) => {
    const listmenu = [
        {
            methodo: "GET",
            url: "/clienteslist",
            info: "Exibe os dados da API VIP"
        },
        {
            methodo: "GET",
            url: "/clientesImport",
            info: "Importa dos dados da API VIP"
        },
    ];
    res.send(listmenu);
});
vipApi.get("/clientes", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const dataAtual = new Date();
        const dataInicial = new Date();
        dataInicial.setDate(dataAtual.getDate() - 60); // 7 dias atrás
        const pag = 1;
        const data_ultima_alteracao_ini = modelbase_1.clsTools._datemomentDateToStr(dataInicial, "YYYY-MM-DD");
        const data_ultima_alteracao_fim = modelbase_1.clsTools._datemomentDateToStr(dataAtual, "YYYY-MM-DD");
        let result = yield api_1.default.clientes.get({ page: pag,
            data_ultima_alteracao_ini: data_ultima_alteracao_ini,
            data_ultima_alteracao_fim: data_ultima_alteracao_fim });
        res.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.pagConsole(`modules | CRM VIP | Error \n ${e.message}`);
        res.status(500).send({ error: e.message });
    }
}));
exports.default = vipApi;
