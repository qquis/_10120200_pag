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
const myBase = new modelbase_1.clsBase();
class reportProdutoCategoria {
    static sql(parametro) {
        let sql = ` 
           select	 	sb.prsg_cdsubgrupo 
                    , 	sb.prsg_descricao
                    ,	gr.prg_cdgrupo 
                    ,	gr.prg_descricao
                    ,	sc.prs_cdsecao 
                    ,	sc.prs_descricao
                    ,	dp.prd_cddepartamento 
                    ,	dp.prd_descricao
            from 		tbproduto_subgrupo sb 
            left join   tbproduto_grupo gr on gr.prg_cdgrupo = sb.prg_cdgrupo 
            left join   tbproduto_secao sc on sc.prs_cdsecao = gr.prs_cdsecao
            left join   tbproduto_departamento dp on dp.prd_cddepartamento = sc.prd_cddepartamento
            where 1 = 1
            order by dp.prd_descricao 
                    , sc.prs_descricao 
                    , gr.prg_descricao 
                    , sb.prsg_descricao
                    
        `;
        return sql;
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = this.sql(parametro);
            let result = yield myBase.myDataBase.pag.DataGet(this.sql(parametro));
            return result;
        });
    }
}
exports.default = reportProdutoCategoria;
