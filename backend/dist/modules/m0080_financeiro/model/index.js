"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const modelFinanceiroRouter = (0, express_1.Router)();
const modelautorizacaopagamentopag_1 = require("./modelautorizacaopagamentopag");
const modelAutorizacaoPagamento_1 = require("./modelAutorizacaoPagamento");
modelFinanceiroRouter.use("/autorizacaopagamentopag", modelautorizacaopagamentopag_1.modelautorizacaoPagamentoPagRouter);
modelFinanceiroRouter.use("/autorizacaopagamento", modelAutorizacaoPagamento_1.modelAutorizacaoPagamentoRouter);
exports.default = modelFinanceiroRouter;
