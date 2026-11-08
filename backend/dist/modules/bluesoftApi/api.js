"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const blueSoftApiPreco_1 = __importDefault(require("./preco/blueSoftApiPreco"));
const blueSoftApiProduto_1 = __importDefault(require("./produto/blueSoftApiProduto"));
class bluesoftApi {
    constructor() {
        this.produto = new blueSoftApiProduto_1.default();
        this.preco = new blueSoftApiPreco_1.default();
    }
}
exports.default = bluesoftApi;
