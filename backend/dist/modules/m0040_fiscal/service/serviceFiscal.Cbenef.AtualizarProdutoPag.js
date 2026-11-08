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
const modelbase_1 = require("../../../model/modelbase");
class serviceFiscal_Cbenef_AtualizarProdutoPag {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (parametro.fc_cbenef_cd == null || parametro.fc_cbenef_cd.trim() === '') {
                    throw new Error('Código do Cbenef é obrigatório');
                }
                if (parametro.lista_produtos == null || parametro.lista_produtos.length === 0) {
                    throw new Error('Lista de produtos é obrigatória');
                }
                let sql = `UPDATE tbproduto 
                        set  pr_pag_fc_cbenef_cd = '${parametro.fc_cbenef_cd === "X" ? "" : parametro.fc_cbenef_cd}' 
                        where prb_cdprodutobluesoft in (${parametro.lista_produtos})
                        `;
                let myBase = new modelbase_1.clsBase();
                yield myBase.myDataBase.pag.Execute(sql);
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`serviceFiscal_Cbenef_AtualizarProdutoPag | start \n Error: ${e}`);
            }
            finally {
                return 1;
            }
        });
    }
}
exports.default = serviceFiscal_Cbenef_AtualizarProdutoPag;
