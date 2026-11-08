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
class blueSoftApiPrecoPromocional {
    constructor() {
    }
    post(item) {
        return __awaiter(this, void 0, void 0, function* () {
            let dados = {};
            try {
                if (item) {
                    let ResultadoBlue = {};
                    const myTypeApi = this.getType(item);
                    dados = myTypeApi.dados;
                    ResultadoBlue = yield bluesoftApiUrl_1.default.api_post(myTypeApi.url, myTypeApi.dados);
                    if (ResultadoBlue)
                        yield Tools_1.default.pagConsole(`BlueSoftApi | Preco PROMOCIONAL _ post | Item : ${item.prb_cdprodutobluesoftunitario} Processado com sucesso `);
                    else
                        yield Tools_1.default.pagConsole(`(NULL) BlueSoftApi | Preco PROMOCIONAL _ post | Item : ${item.prb_cdprodutobluesoftunitario} NÃO PROCESSADO`);
                }
            }
            catch (e) {
                yield Tools_1.default.pagConsole(`(ERROR) BlueSoftApi | Preco PROMOCIONAL _ post | Item : ${item.prb_cdprodutobluesoftunitario} 
                \n ${e} 
                \n Dados informados na API da Bluesoft
                \n -----------------------------------
                \n ${dados}
                `);
            }
        });
    }
    getType(item) {
        let myTypeApi = { url: "vendas/precos/ofertas", dados: {} };
        let dados = {};
        try {
            if (item) {
                dados = {
                    "produtoKey": item.prb_cdprodutobluesoft,
                    "dataInicialOferta": `${Tools_1.default._dataformatgetstr(item.prca_dt_aplicacao, "DD/MM/yyyy")} 08:00:00`,
                    "dataFinalOferta": `${Tools_1.default._dataformatgetstr(item.prca_dt_aplicacao, "DD/MM/yyyy")} 23:00:00`,
                    "lojasKeys": [
                        1
                    ],
                    "aplicarAosEquivalentes": false,
                    "precoOferta": item.prc_valor
                };
                const ItemProcessamento = {
                    prb_cdprodutobluesoft: item.prb_cdprodutobluesoft,
                    dados: dados
                };
                myTypeApi = { url: "vendas/precos/ofertas", dados: ItemProcessamento.dados };
                //console.log("--- TESTE API BLUESOFR PROMOCIONAL --- ")
                //console.log(myTypeApi)
                return myTypeApi;
                /*
                let ResultadoBlue = {}
                ResultadoBlue = await bluesoftApi.api_post("vendas/precos/ofertas", ItemProcessamento.dados )
                await myTools.pagConsole(`BlueSoftApi | Preco _ post | Item : ${item.prb_cdprodutobluesoftunitario} `)
                */
            }
            else {
                return myTypeApi;
            }
        }
        catch (e) {
            return myTypeApi;
        }
    }
}
exports.default = blueSoftApiPrecoPromocional;
