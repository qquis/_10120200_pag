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
const integracao_produto_service_default_1 = __importDefault(require("./integracao.produto.service_default"));
const api_1 = __importDefault(require("../../../Apis/bluesoftApi/api"));
const Tools_1 = __importDefault(require("../../../../tools/Tools"));
let myBlueSoftApi = new api_1.default();
class integracaoProdutoService_20004502_Api_PrecoPromocional extends integracao_produto_service_default_1.default {
    constructor(item) {
        super(item);
    }
    ApiItemProcessar(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield Tools_1.default.pagConsole(`integracaoProdutoService_20004502_Api_Preco PROMOCIONAL - ENV ${process.env.ENVIRONMENT} ITEM ${item.prb_cdprodutobluesoftunitario} / ${item.prb_cdprodutobluesoft}`, false);
                if (!process.env.ENVIRONMENT || process.env.ENVIRONMENT !== `DES`) {
                    yield myBlueSoftApi.preco.apiPrecoPromocional.post(item);
                }
                else {
                    yield Tools_1.default.pagConsole(`Ambiente de Desenvolvimento (Produto não lançado na API) ${item.prb_cdprodutobluesoftunitario} / ${item.prb_cdprodutobluesoft}`, false);
                    //await myBlueSoftApi.preco.apiPrecoPromocional.post(item)
                }
            }
            catch (e) {
                yield Tools_1.default.pagConsole(`(ERROR) integracaoProdutoService_20004502_Api_Preco PROMOCIONAL Item : ${item.prb_cdprodutobluesoftunitario} `);
                throw new Error(`Error ${e}`);
            }
        });
    }
    ApiItemValidar(item) {
        return __awaiter(this, void 0, void 0, function* () {
            let validacao = false;
            try {
                if (item.prb_cdprodutobluesoft && item.ItemObjectIntegracao.prc_valor && item.ItemObjectIntegracao.prca_dt_aplicacao) {
                    validacao = true;
                }
            }
            catch (e) {
                validacao = false;
            }
            finally {
                item.ApiValidacao = validacao;
                return validacao;
            }
        });
    }
}
exports.default = integracaoProdutoService_20004502_Api_PrecoPromocional;
