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
const crmVipApiRouter = (0, express_1.Router)();
const api_crm_vip_1 = __importDefault(require("./api_crm_vip"));
crmVipApiRouter.get("/", (req, res) => {
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
crmVipApiRouter.get("/clientes", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const dataAtual = new Date();
        const dataInicial = new Date();
        dataInicial.setDate(dataAtual.getDate() - 60); // 7 dias atrás
        const pag = 1;
        const dataAtualizacaoInicial = modelbase_1.clsTools._datemomentDateToStr(dataAtual, "YYYY-MM-DD");
        const dataAtualizacaoFinal = modelbase_1.clsTools._datemomentDateToStr(dataAtual, "YYYY-MM-DD");
        let result = yield api_crm_vip_1.default.getClientesAll({ page: pag, datal_alteracao_inicial: dataAtualizacaoInicial, datal_alteracao_final: dataAtualizacaoFinal });
        res.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.pagConsole(`modules | CRM VIP | Error \n ${e.message}`);
        res.status(500).send({ error: e.message });
    }
}));
exports.default = crmVipApiRouter;
