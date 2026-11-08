import { clsBase, clsTools } from "../../../model/modelbase";



const FLG_INFO : any = clsTools.pagLogSet(
    {       SISTEMA_NUCLEO_PRC_CD: 0
        ,   FLG_DEBUG_CONSOLE_LOG: true
        ,   FLG_MODULO: "M0071_INTERFACE - Report Interface Johnson Dial Venda ( rerpot.interfaceJohnson.Dial.Venda.ts )"
        ,   FLG_DEBUG_FILE_CONSOLE_LOG: ``
})



export default class reportInterfaceJohnson_Dial_Estoque {
    private static sql(parametro: any) : string { 
            let sql = `
           				WITH params AS (
    SELECT DATE '${clsTools._datemomentDateToStr(parametro.data_processamento_ini, "YYYY-MM-DD")}' AS dt_ini
         , DATE '${clsTools._datemomentDateToStr(parametro.data_processamento_fim, "YYYY-MM-DD")}' AS dt_fim
),
dias AS (
    SELECT d::DATE AS data
    FROM   params
    CROSS JOIN LATERAL generate_series(dt_ini, LEAST(dt_fim, dt_ini + 30), INTERVAL '1 day') AS d
),
produtos AS (
    SELECT  p.pr_cdproduto
          , p.pr_descricao
          , p.prb_cdprodutobluesoft
          , b.prb_cdpessoabluesoft_fabricante
          , ps.nome_razao
          , ps.nome_abreviado
          , ps.cpf_cnpj
          , b.prb_vendaexterna
          , b.prb_cdproduto_compra_padrao
          , x.prbf_codigo_referencia
          , bx.prb_cdbarra_principal
          , bx.prb_descricao AS prb_descricao_compra
          , p.pr_embalagemcompra_fator as pr_embalagemcompra_fator
    FROM        tbproduto p
    INNER JOIN  tbprodutobluesoft b   ON b.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft
    INNER JOIN  tbpessoabluesoft  ps  ON ps.cdpessoabluesoft = b.prb_cdpessoabluesoft_fabricante
    INNER JOIN  tbprodutobluesoft_fornecedor x
                                      ON x.prb_cdprodutobluesoft = b.prb_cdproduto_compra_padrao
                                     AND x.prbf_cdpessoabluesoft = ps.cdpessoabluesoft
    INNER JOIN  tbprodutobluesoft bx  ON bx.prb_cdprodutobluesoft_pk = b.prb_cdproduto_compra_padrao
    INNER JOIN  tbforca_venda_fabricante f ON f.fv_fabricante_cdpessoabluesoft = ps.cdpessoabluesoft
    WHERE f.fv_fabricante_cdpessoabluesoft = 13752 -- PRODUTOS CERAS JOHNSON
)
SELECT  



       ROW_NUMBER() OVER (ORDER BY pr.pr_cdproduto) as numerolinha
      , 'DIALSTOCK01BR'                                                                    || ';' ||  -- RecordType
        '40870'                                                                            || ';' ||  -- [DistributGO]
        COALESCE(TO_CHAR( dd.data, 'YYYYMMDD'), '')                                   || ';' ||  -- [DATE]
        COALESCE(LEFT(COALESCE(pr.prbf_codigo_referencia::TEXT, ''), 20), '')                       || ';' ||  -- [SCJ Produ]
        COALESCE(LEFT(pr.pr_cdproduto::TEXT, 10), '')                                          || ';' ||  -- [Distribut]
        COALESCE(LEFT(pr.pr_descricao, 40), '')                                                || ';' ||  -- [Distribut]
        COALESCE(LEFT(ROUND(GREATEST(es.ecdb_embalagemestoque_qtde / pr.pr_embalagemcompra_fator, 0)::NUMERIC, 2)::TEXT, 10), '') || ';' ||  -- [Qty]
        '00'                                                                               || ';' ||  -- [WareHouse]
        'Main Warehouse'                                                                   || ';' ||  -- [Warehouse]
        '1'                                                                                || ';' ||  -- [fraction]
        COALESCE(LEFT(pr.prb_cdbarra_principal::TEXT, 20), '')                                           || ';' ||  -- [Ean Code]
        ''                                                                                 || ';' ||  -- [Sales Qty]
        ''                                                                                 || ';' ||  -- [ExDO]
        ''                                                                                 || ';' ||  -- [BONus Sam]
        '' as linha 
FROM        produtos pr
CROSS JOIN  dias dd
LEFT JOIN   tbestoquecusto_diariobluesoft es
       ON   es.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
      AND   es.ecdb_data::DATE = dd.data

union 
select 0 as numerolinha
,'Record Type;Distributor Code;Date;SCJ Product Code;Distributor Product Code;Distributor Product DescriptiON;Qty;Warehouse Code;Warehouse Name;FractiON;EAN Code;Sales Qty;ExDO;BONus Sample;Others'
    as linha


ORDER BY    1



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