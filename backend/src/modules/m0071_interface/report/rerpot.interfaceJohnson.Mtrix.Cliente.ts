import { clsBase, clsTools } from "../../../model/modelbase";



const FLG_INFO : any = clsTools.pagLogSet(
    {       SISTEMA_NUCLEO_PRC_CD: 0
        ,   FLG_DEBUG_CONSOLE_LOG: true
        ,   FLG_MODULO: "M0071_INTERFACE - Report Interface Johnson MTRIX Cliente"
        ,   FLG_DEBUG_FILE_CONSOLE_LOG: ``
})



export default class reportInterfaceJohnson_Mtrix_Cliente {
    private static sql(parametro: any) : string { 
            let sql = `
            
           
         WITH cliente_mov AS (
                SELECT cdparticipantecliente
                  FROM tbinterfacefaturamentoinfoitem
				  where datafaturamento >= current_date - 720
                 GROUP BY cdparticipantecliente
            )
SELECT 
    ROW_NUMBER() OVER (ORDER BY pa.nome_razao) as seqlinha,
    'D'
    || '57895328000130'
    || LPAD(COALESCE(a.cpf_cnpj, '57895328000130'), 18)
    || LPAD(LEFT(COALESCE(pa.nome_razao, 'CLIENTE OXAN'), 40), 40)
    || LPAD(LEFT(COALESCE(c.endereco_logradouro, 'AV. RIO DAS PEDRAS, 729'), 40), 40)
    || LPAD(LEFT(COALESCE(c.endereco_bairro, 'VILA FORMOSA'), 30), 30)
    || LPAD(
        SUBSTRING(
            LPAD(COALESCE(c.endereco_cep, '03453000')::TEXT, 8, '0'),
            1, 5
        ) || '-' || SUBSTRING(
            LPAD(COALESCE(c.endereco_cep, '03453000')::TEXT, 8, '0'),
            6, 3
        ),
        9
    )
    || LPAD(LEFT(COALESCE(c.endereco_municipio, 'SAO PAULO'), 30), 30)
    || LPAD(COALESCE(c.endereco_uf, 'SP'), 30)
    || LPAD(LEFT(cast(coalesce(pe.cdpessoabluesoft,2166) as varchar(10)), 20), 20)
    || LPAD('00' || CAST('027825200' AS CHAR(38)), 40)
    || LPAD(COALESCE(a.cpf_cnpj, '57895328000130'), 18)
    || LPAD(LEFT(COALESCE(c.endereco_bairro, ''), 10), 10)
    || LPAD('', 10)
    || LPAD('1000', 10)
    || LPAD('', 6) as linha 


				FROM			tbparticipante				a
					LEFT JOIN   tbpessoabluesoft			pa  on pa.cdpessoabluesoft = a.cdpessoabluesoft
					LEFT JOIN	tbpessoabluesoft			pe  on pe.cdpessoabluesoft = pa.cdpessoabluesoft_vendedor
					LEFT JOIN 	tbparticipante				e	ON e.cdpessoabluesoft = pe.cdpessoabluesoft
					left join   tbparticipante_endereco		c	on c.cdparticipante = a.cdparticipante 
					

					WHERE			1 = 1 
					AND	(		(coalesce(pa.cdgrupoeconomico,0) <> 0 and pa.bluesoftclientestatus = 1)
								or	a.cdparticipante in ( select cdparticipantecliente from	cliente_mov)
						)
		
	union

	SELECT			
		0 as seqlinha
	,	'HPDV10  33122466000119' as linha


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