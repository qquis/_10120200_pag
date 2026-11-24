import { clsBase, clsTools } from "../../../model/modelbase";



const FLG_INFO : any = clsTools.pagLogSet(
    {       SISTEMA_NUCLEO_PRC_CD: 0
        ,   FLG_DEBUG_CONSOLE_LOG: true
        ,   FLG_MODULO: "M0071_INTERFACE - Report Interface Johnson MTRIX FORCA VENDA"
        ,   FLG_DEBUG_FILE_CONSOLE_LOG: ``
})



export default class reportInterfaceJohnson_Mtrix_ForcaVenda {
    private static sql(parametro: any) : string { 
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