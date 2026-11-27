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
    FLG_MODULO: "M0071_INTERFACE - Report Interface Johnson MTRIX FORCA VENDA",
    FLG_DEBUG_FILE_CONSOLE_LOG: ``
});
class reportInterfaceJohnson_Mtrix_ForcaVenda {
    static sql(parametro) {
        let sql = `
            
           
          WITH cliente_mov AS (
                SELECT cdparticipantecliente
                  FROM tbinterfacefaturamentoinfoitem
				  where datafaturamento >= current_date - 720
                 GROUP BY cdparticipantecliente
            )

SELECT
    ROW_NUMBER() OVER(ORDER BY pe.cdpessoabluesoft) as seqlinha,
    'D'
    || '57895328000130'
    || RPAD(COALESCE(a.cpf_cnpj, '00077109970825')::TEXT, 18, ' ')
    || RPAD('TM', 13, ' ')
    || RPAD('FRANCISCO EDUARDO', 50, ' ')
    || RPAD('EQUIPE GERAL', 13, ' ')
    || RPAD('EQUIPE GERAL', 50, ' ')
    || RPAD(COALESCE(pe.cdpessoabluesoft, 2166)::TEXT, 20, ' ')
    || RPAD(COALESCE(pe.nome_razao, 'FRANCISCO EDUARDO')::TEXT, 50, ' ') as linha
FROM			tbparticipante			a
LEFT JOIN       tbpessoabluesoft			pa  on pa.cdpessoabluesoft = a.cdpessoabluesoft
LEFT JOIN		tbpessoabluesoft			pe  on pe.cdpessoabluesoft = pa.cdpessoabluesoft_vendedor
LEFT JOIN 		tbparticipante			e	ON e.cdpessoabluesoft = pe.cdpessoabluesoft
left join       tbparticipante_endereco	c	on c.cdparticipante = a.cdparticipante 

					WHERE			1 = 1 
					AND	(		(coalesce(pa.cdgrupoeconomico,0) <> 0 and pa.bluesoftclientestatus = 1)
								or	a.cdparticipante in ( select cdparticipantecliente from	cliente_mov)
						)

	union

	SELECT			
		0 as seqlinha
	,	'HFV10   62000278000701' as linha 


    order by 1,2
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
exports.default = reportInterfaceJohnson_Mtrix_ForcaVenda;
