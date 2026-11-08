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
const modelcliente_1 = __importDefault(require("./modelcliente"));
const modelMercadoria_1 = __importDefault(require("./modelMercadoria"));
class modelExternalZanthusBase {
    static obterDadosDoCliente(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let dadosDoCliente = null;
            try {
                if (!parametro || !parametro.cod_cliente) {
                    throw new Error("Parâmetro inválido: cod_cliente é obrigatório");
                }
                let cliente = new modelcliente_1.default(parseInt(`${parametro.cod_cliente}`));
                dadosDoCliente = yield cliente.getData();
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modules.External | Zanthus`, "obterDadosDoCliente", e);
            }
            finally {
                return dadosDoCliente;
            }
        });
    }
    static obterDadosMercadoria(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let dadosDaMercadoria = null;
            try {
                let mercadoriaModal = new modelMercadoria_1.default();
                dadosDaMercadoria = yield mercadoriaModal.getinfoAllMercadoria(parametro.cod_mercadoria);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`modules.External | Zanthus`, "obterDadosMercadoria", e);
            }
            finally {
                return dadosDaMercadoria;
            }
        });
    }
}
exports.default = modelExternalZanthusBase;
