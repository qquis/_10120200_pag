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
const apibluesoft_preco = (0, express_1.Router)();
apibluesoft_preco.get("/", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    const help = [
        {
            url: "/",
            info: "Não há possibilidade de executar esta api por ser apenas api post"
        },
    ];
    return response.send(help);
}));
exports.default = apibluesoft_preco;
