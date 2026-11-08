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
    FLG_MODULO: "M0071_INTERFACE - Report Interface Johnson Dial Venda ( rerpot.interfaceJohnson.Dial.Venda.ts )",
    FLG_DEBUG_FILE_CONSOLE_LOG: ``
});
class reportInterfaceJohnson_Dial_Cliente {
    static sql(parametro) {
        let sql = `
            SELECT		0 AS numerolinha
					,	'RecordType;Distributor code;Client code;Client Federal ID;Client name;Client status;Salesman code;Salesman name;SalesmanType'
                        as linha
				
				UNION
           
           
          SELECT
                ROW_NUMBER() OVER (ORDER BY a.cdparticipante) AS numerolinha
                , 'DIALCLIENT01BR'
                || ';'
                || '40870'
                || ';'
                || COALESCE(a.cdparticipante, 1)::VARCHAR(10)
                || ';'
                || LEFT(COALESCE(TRUNC(a.cpf_cnpj::NUMERIC)::VARCHAR(14), '57895328000130'), 14)
                || ';'
                || COALESCE(LEFT(ps.nome_razao, 40), 'OXAN ATACADISTA LTDA')
                || ';'
                || COALESCE(CASE ps.bluesoftclientestatus WHEN 0 THEN 'Closed' ELSE 'Active' END, 'Closed')
                || ';'
                -- || COALESCE(LEFT(REPLACE(pv.erptargetcd_vend, 'V', ''), 5), '236')
                || COALESCE(LEFT(psv.cdpessoabluesoft::TEXT, 5), '2046')
                || ';'
                || COALESCE(LEFT(psv.nome_razao, 40), 'FRANCISCO EDUARDO DA SILVA')
                || ';'
                || 'COMUM' AS linha
            ----------------------------------------------------------------------------------------------------------------------------------------------
            FROM        tbparticipante a
            INNER JOIN  tbpessoabluesoft ps  ON ps.cdpessoabluesoft = a.cdpessoabluesoft
            LEFT JOIN   tbparticipante   pv  ON pv.cdpessoabluesoft = ps.cdpessoabluesoft_vendedor
                                            AND ps.cdpessoabluesoft_vendedor <> 0
            LEFT JOIN   tbpessoabluesoft psv ON psv.cdpessoabluesoft = pv.cdpessoabluesoft
            WHERE 1 = 1
            AND (
                    a.cdparticipante IN (
                        SELECT x.cdparticipantecliente
                        FROM   tbinterfacefaturamentoinfoitem x
                        WHERE  x.datafaturamento >= current_date - 360
                        AND    x.datafaturamento <= current_date
                        AND    x.seqinterface = 1
                    )
                OR (ps.bluesoftclientestatus = 1 AND COALESCE(ps.cdgrupoeconomico, 0) > 0)
                )

            order by 1    


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
exports.default = reportInterfaceJohnson_Dial_Cliente;
