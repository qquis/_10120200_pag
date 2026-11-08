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
class reportResultadoGruopoList {
    static sql(parametros = {}) {
        let sql = `
                        select  g.r_grupo_cd
                        ,       g.r_grupo_descricao
                        ,       coalesce(g.r_grupo_origem_blue,0) as r_grupo_origem_blue
                        from    tbresultado_grupo g
                        order by g.r_grupo_descricao 
                `;
        return sql;
    }
    static get() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}, sql = ``) {
            const myTools = new modelbase_1.clsBase();
            try {
                let result = yield myTools.myDataBase.pag.DataGet(sql || this.sql(parametros));
                return result;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`reportDREOperacaoList`, 'sql', e);
            }
        });
    }
}
exports.default = reportResultadoGruopoList;
