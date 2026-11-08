import { clsBase, clsTools } from "../../../model/modelbase";



const FLG_INFO : any = clsTools.pagLogSet(
    {       SISTEMA_NUCLEO_PRC_CD: 0
        ,   FLG_DEBUG_CONSOLE_LOG: true
        ,   FLG_MODULO: "M0071_INTERFACE - Report Interface Johnson Dial Venda ( rerpot.interfaceJohnson.Dial.Venda.ts )"
        ,   FLG_DEBUG_FILE_CONSOLE_LOG: ``
})



export default class reportInterfaceJohnson_Dial_Cliente {
    private static sql(parametro: any) : string { 
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
                    
                    `

                    
                    return sql 
    }

    static async get(parametro: any): Promise<any> {
        try { 
            let myBase : clsBase = new clsBase()
            let result = await myBase.myDataBase.pag.DataGet(this.sql(parametro), true)
            return result
        } catch (e) {

            await clsTools.PagErrorException(FLG_INFO.FLG_MODULO,"get",e,false,"",FLG_INFO.FLG_DEBUG_FILE_CONSOLE_LOG)
            throw new Error(`${e}`)
        }
    }



}