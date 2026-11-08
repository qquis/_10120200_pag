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
const Tools_1 = __importDefault(require("../../../../tools/Tools"));
const bluesoftApiUrl_1 = __importDefault(require("../url/bluesoftApiUrl"));
class blueSoftApiPrecoPadrao {
    constructor() {
    }
    post(item) {
        return __awaiter(this, void 0, void 0, function* () {
            let dados = {};
            try {
                if (item) {
                    const myTypeApi = this.getType(item);
                    dados = myTypeApi.dados;
                    //console.log("TESTE 04/12/2024 ------------")
                    //console.log(JSON.stringify(myTypeApi.dados))
                    let ResultadoBlue = {};
                    ResultadoBlue = yield bluesoftApiUrl_1.default.api_post(myTypeApi.url, myTypeApi.dados);
                    if (ResultadoBlue)
                        yield Tools_1.default.pagConsole(`BlueSoftApi | Preco COMUM _ post | Item : ${item.prb_cdprodutobluesoftunitario} Processado com sucesso `);
                    else
                        yield Tools_1.default.pagConsole(`(NULL) BlueSoftApi | Preco COMUM _ post | Item : ${item.prb_cdprodutobluesoftunitario} NÃO PROCESSADO`);
                }
            }
            catch (e) {
                yield Tools_1.default.pagConsole(`(ERROR) BlueSoftApi | Preco _ post_preco Item : ${item.prb_cdprodutobluesoftunitario} 
                            \n ${e} 
                            \n Dados informados na API da Bluesoft
                            \n -----------------------------------
                            \n ${JSON.stringify(dados, null, 2)}
                            `);
            }
        });
    }
    getType(item) {
        let myTypeApi = { url: "vendas/precos", dados: {} };
        let dados = {};
        try {
            dados = {
                "produtoKey": item.prb_cdprodutobluesoft,
                "dataInicialAVigorar": `${(new Date()).toLocaleString("pt-br").substring(0, 10)} 08:01:01`,
                "aplicarPrecoParaCaixa": true,
                "aplicarEquivalentes": true,
                "regioes": [
                    {
                        "precoAPartirDe": 0,
                        "precoAtacado": 0,
                        "precoFidelidade": 0,
                        "precoVenda": item.prc_valor,
                        "quantidadeAPartirDe": 0,
                        "regiaoKey": 1
                    }
                ]
            };
            const ItemProcessamento = {
                prb_cdprodutobluesoft: item.prb_cdprodutobluesoft,
                dados: dados
            };
            myTypeApi = { url: "vendas/precos", dados: ItemProcessamento.dados };
            return myTypeApi;
        }
        catch (e) {
            return myTypeApi;
        }
    }
}
exports.default = blueSoftApiPrecoPadrao;
