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
const FLG_INFO = modelbase_1.clsTools.pagLogSet({ SISTEMA_NUCLEO_PRC_CD: 0,
    FLG_DEBUG_CONSOLE_LOG: true,
    FLG_MODULO: "M0071_INTERFACE - Report Interface Johnson MTRIX Cliente",
    FLG_DEBUG_FILE_CONSOLE_LOG: ``
});
class reportInterfaceJohnson_Mtrix_Produto {
    static sql(parametro) {
        let sql = `
            
         

SELECT
    1 as seqlinha,
    RPAD('I', 1, ' ')
    || RPAD('57895328000130', 14, ' ') as linha

UNION ALL

SELECT
    ROW_NUMBER() OVER(ORDER BY P.pr_cdproduto) + 1 as seqlinha,
    RPAD('V', 1, ' ')
    || RPAD('62000278000701', 18, ' ')
    || RPAD('C.JOHSON', 30, ' ')
    || RPAD(COALESCE(P.pr_cdproduto::TEXT, ''), 14, ' ')
    || RPAD('0', 1, ' ')
    || RPAD(COALESCE(CB.prb_cdbarra_principal::TEXT, ''), 14, ' ')
    || RPAD('1', 1, ' ')
    || RPAD(COALESCE(P.pr_descricao::TEXT, ''), 100, ' ')
    || RPAD('CERAS JOHNSON', 40, ' ')
    || RPAD('', 30, ' ')
    || RPAD('A', 1, ' ')
    || RPAD('', 27, ' ') as linha 
	FROM		tbproduto					p 
	INNER JOIN  tbprodutobluesoft			CB ON CB.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft 
	INNER JOIN  tbforca_venda_fabricante  f on f.fv_fabricante_cdpessoabluesoft = cb.prb_cdpessoabluesoft_fabricante
	WHERE		f.fv_fabricante_Seq = 1
	AND			P.pr_status			=	true
	AND			p.pr_embalagemestoque	=	'UN'	

		;
                    
                    `;
        return sql;
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myBase = new modelbase_1.clsBase();
                let result = yield myBase.myDataBase.pag.DataGet(this.sql(parametro), true);
                return result;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_INFO.FLG_MODULO, "get", e, false, "", FLG_INFO.FLG_DEBUG_FILE_CONSOLE_LOG);
                throw new Error(`${e}`);
            }
        });
    }
}
exports.default = reportInterfaceJohnson_Mtrix_Produto;
