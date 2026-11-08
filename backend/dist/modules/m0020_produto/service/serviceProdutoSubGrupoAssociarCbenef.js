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
class serviceProdutoSubGrupoAssociarCbenef {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                if (!parametro.prsg_cdsubgrupo || parametro.prsg_cdsubgrupo === 0) {
                    throw new Error('Subgrupo é obrigatório');
                }
                if (!parametro.fc_cbenef_cd || parametro.fc_cbenef_cd.trim() === '') {
                    throw new Error('Código do Cbenef é obrigatório');
                }
                let sql = `UPDATE tbproduto_subgrupo set fc_cbenef_cd = '${parametro.fc_cbenef_cd}' 
                        where prsg_cdsubgrupo = ${parametro.prsg_cdsubgrupo}
                        
                        `;
                let myBase = new modelbase_1.clsBase();
                yield myBase.myDataBase.pag.Execute(sql);
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`serviceProdutoSubGrupoAssociarCbenef | start \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = serviceProdutoSubGrupoAssociarCbenef;
