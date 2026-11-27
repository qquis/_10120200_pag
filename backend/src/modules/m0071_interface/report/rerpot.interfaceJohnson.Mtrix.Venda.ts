import { clsBase, clsTools } from "../../../model/modelbase";



const FLG_INFO : any = clsTools.pagLogSet(
    {       SISTEMA_NUCLEO_PRC_CD: 0
        ,   FLG_DEBUG_CONSOLE_LOG: true
        ,   FLG_MODULO: "M0071_INTERFACE - Report Interface Johnson MTRIX Venda"
        ,   FLG_DEBUG_FILE_CONSOLE_LOG: ``
})



export default class reportInterfaceJohnson_Mtrix_Venda {
    private static sql(parametro: any) : string { 
            let sql = `

           select 				0 as seqlinha 
							,	'HVENDA1133122466000119' as linha
           union 
           SELECT
                    ROW_NUMBER() OVER (ORDER BY x.seqprocessamentoitemdocumento) AS seqlinha,

                    'D'                                                     -- Tipo de registro
                    || '57895328000130'                                     -- CNPJ do agente
                    || RPAD(COALESCE(c.cpf_cnpj::text, '57895328000130'), 18, ' ')
                    || TO_CHAR(x.datafaturamento, 'YYYYMMDD')                -- Data da transação
                    || '001'                                                -- Série
                    || RPAD(x.seqprocessamentoitemdocumento::text, 17, ' ')  -- Documento
                    || RPAD(cb.prb_cdbarra_principal::text, 14, ' ')        -- Produto

                    || CASE                                                 -- Quantidade
                        WHEN x.embalagemestoqueqtde < 0 THEN
                            '-' || LPAD(REPLACE(x.embalagemestoqueqtde::text, '-', ''), 19, '0')
                        ELSE
                            LPAD(x.embalagemestoqueqtde::text, 20, '0')
                    END

                    || LPAD(                                                -- Preço de venda
                        (x.valortotalfaturamento / x.embalagemestoqueqtde)::numeric(5, 2)::text,
                        8,
                        '0'
                    )

                    || RPAD(COALESCE(v.cdpessoabluesoft::text, '2046'), 20, ' ')
                    || REPEAT(' ', 10)                                      -- Campo reservado

                    || CASE                                                 -- Tipo da venda
                        WHEN x.valortotalfaturamento::numeric(13, 5) = 0
                        AND x.embalagemestoqueqtde::numeric(13, 5) > 0
                        THEN 'B'
                        ELSE 'N'
                    END

                    || SUBSTRING(LPAD(COALESCE(e.endereco_cep::text, '3453000'), 8, '0'), 1, 5)
                    || '-'
                    || SUBSTRING(LPAD(COALESCE(e.endereco_cep::text, '3453000'), 8, '0'), 6, 3)

                    || REPEAT(' ', 13)                                      -- Código do lote
                    || REPEAT(' ', 6)                                       -- Validade AAAAMM
                    || REPEAT(' ', 2)                                       -- Dia da validade
                    || REPEAT(' ', 1)                                       -- Pedido sugerido
                    || REPEAT(' ', 8)                                       -- Preço em dólar
                    || CASE
                        WHEN x.embalagemestoque = 'KG' THEN '0002'
                        ELSE '0001'
                    END AS linha

                FROM tbinterfacefaturamentoinfoitem x
                LEFT JOIN tbproduto pr ON pr.pr_cdproduto = x.pr_cdproduto
                LEFT JOIN tbprodutobluesoft cb ON cb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
                LEFT JOIN tbparticipante v ON v.cdparticipante = x.cdparticipantevendedor
                LEFT JOIN tbparticipante c ON c.cdparticipante = x.cdparticipantecliente
                LEFT JOIN tbparticipante_endereco e ON e.cdparticipante = c.cdparticipante
                WHERE x.seqinterface = 1
                AND TO_CHAR(x.datafaturamento, 'YYYYMMDD') >= '${clsTools._datemomentDateToStr(parametro.data_processamento_ini, "YYYYMMDD")}'
                AND TO_CHAR(x.datafaturamento, 'YYYYMMDD') <= '${clsTools._datemomentDateToStr(parametro.data_processamento_fim, "YYYYMMDD")}'
                GROUP BY
                    COALESCE(c.cpf_cnpj::text, '57895328000130'),
                    cb.prb_cdbarra_principal,
                    x.seqprocessamentoitemdocumento,
                    x.datafaturamento,
                    v.cdpessoabluesoft,
                    e.endereco_cep,
                    x.embalagemestoque,
                    x.embalagemestoqueqtde,
                    x.valortotalfaturamento




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