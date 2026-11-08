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
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const modelbase_1 = require("../../../model/modelbase");
const ServiceRh = (0, express_1.Router)();
ServiceRh.get(`/inativarfuncionariopag`, () => __awaiter(void 0, void 0, void 0, function* () {
    try {
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('ServiceNotificacao', 'inativarfuncionariopag', e);
    }
}));
exports.default = ServiceRh;
