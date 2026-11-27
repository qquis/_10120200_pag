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
    FLG_MODULO: "M0071_INTERFACE - Report Interface Johnson MTRIX Estoque",
    FLG_DEBUG_FILE_CONSOLE_LOG: ``
});
class reportInterfaceJohnson_Mtrix_Estoque {
    static sql(parametro) {
        let sql = `
            
         

SELECT DISTINCT
    cast(0 as int) as seqlinha ,
    'HESTOQ1133122466000119'
    || TO_CHAR(current_date, 'YYYYMMDD') as linha

UNION ALL

SELECT
     cast(ROW_NUMBER() OVER(ORDER BY cb.prb_cdbarra_principal) as int) as seqlinha,
    'E' -- TIPO DO REGISTRO
    || '57895328000130' -- CNPJ AGENTE DE DISTRIBUIÇÃO
    || RPAD(COALESCE(cb.prb_cdbarra_principal::TEXT, ''), 14, ' ') -- CÓDIGO DO PRODUTO
    || LPAD(
        CASE 
            WHEN COALESCE(e.ec_embalagemestoque_qtde, 0) <= 0 THEN '0.0000'
            ELSE COALESCE(e.ec_embalagemestoque_qtde, 0)::TEXT
        END, 
        20, 
        '0'
    ) -- QUANTIDADE (20 posições preenchidas com zeros à esquerda)
    || RPAD('', 20, ' ') -- CÓDIGO DO LOTE
    || RPAD('', 8, ' ')  -- VALIDADE DO LOTE 'AAAAMM'
    || RPAD('0001', 4, ' ') -- TIPO DE UNIDADE (0001 = UNIDADE DE CONSUMO | 0002 = QUILOS(KG))
FROM		 tbproduto				pr 
inner join   tbprodutobluesoft		cb on cb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft 	
INNER JOIN  tbforca_venda_fabricante  f on f.fv_fabricante_cdpessoabluesoft = cb.prb_cdpessoabluesoft_fabricante
left join    tbestoquecusto          e on pr.pr_cdproduto = e.pr_cdproduto 
WHERE		f.fv_fabricante_Seq = 1
AND			pr.pr_status			=	true
AND			pr.pr_embalagemestoque	=	'UN'	

                    
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
exports.default = reportInterfaceJohnson_Mtrix_Estoque;
