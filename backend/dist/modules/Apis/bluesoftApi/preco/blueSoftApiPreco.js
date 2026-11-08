"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const blueSoftApiPrecoPadrao_1 = __importDefault(require("./blueSoftApiPrecoPadrao"));
const blueSoftApiPrecoPromocional_1 = __importDefault(require("./blueSoftApiPrecoPromocional"));
class bluesoftApiPreco {
    constructor() {
        this.apiPrecoPadrao = new blueSoftApiPrecoPadrao_1.default();
        this.apiPrecoPromocional = new blueSoftApiPrecoPromocional_1.default();
    }
}
exports.default = bluesoftApiPreco;
