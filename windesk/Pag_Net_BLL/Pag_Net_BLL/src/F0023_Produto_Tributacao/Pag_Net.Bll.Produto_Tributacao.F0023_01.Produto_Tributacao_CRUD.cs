using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0023_ProdutoTributacao
{
    public static class F0023_01_Produto_Tributacao_CRUD
    {
        private static string _VERSION() { return "f0023_01_1011924_produtobluesoft_tributacao_crud"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            TbProdutoTributacao ProdutoTributacao
            )
        {
            try
            {
                string RedShift_SELECT = string.Format("SELECT * FROM " + _VERSION() + " ('{0}', {1}, {2}, {3}, {4}, '{5}', '{6}', '{7}', {8}, '{9}', {10}, '{11}', {12}, '{13}', {14}, '{15}', {16}, {17}, '{18}', {19}, {20}, '{21}', {22}, {23}, '{24}', '{25}', {26}, '{27}')",
                                                             BDCommnadType.ToString(),                                   //0
                                                             ProdutoTributacao.op_cdoperacao,                                                //1
                                                             ProdutoTributacao.prb_CdProdutoBlueSoft,                                        //2
                                                             ProdutoTributacao.prbt_RegraFiscal,                                             //3 
                                                             ProdutoTributacao.prbt_RegraFiscalVersao,                                       //4    
                                                             ProdutoTributacao.prbt_RegimeTributario,                                        //5   
                                                             ProdutoTributacao.prbt_CFOP,                                                    //6
                                                             ProdutoTributacao.prbt_PIS_Entrada_CST,                                         //7
                                                             ProdutoTributacao.prbt_PIS_Entrada_Aliquota.ToString().Replace(",", "."),       //8
                                                             ProdutoTributacao.prbt_PIS_Saida_CST,                                           //9
                                                             ProdutoTributacao.prbt_PIS_Saida_Aliquota.ToString().Replace(",", "."),         //10
                                                             ProdutoTributacao.prbt_COFINS_Entrada_CST,                                      //11
                                                             ProdutoTributacao.prbt_COFINS_Entrada_Aliquota.ToString().Replace(",", "."),    //12
                                                             ProdutoTributacao.prbt_COFINS_Saida_CST,                                        //13
                                                             ProdutoTributacao.prbt_COFINS_Saida_Aliquota.ToString().Replace(",", "."),      //14
                                                             ProdutoTributacao.prbt_ICMS_Entrada_CST,                                            //15
                                                             ProdutoTributacao.prbt_ICMS_Entrada_Aliquota_Interna.ToString().Replace(",", "."),      //16
                                                             ProdutoTributacao.prbt_ICMS_Entrada_Reducao.ToString().Replace(",", "."),               //17
                                                             ProdutoTributacao.prbt_ICMS_Saida_CST,                                                  //18
                                                             ProdutoTributacao.prbt_ICMS_Aliquota_Interna.ToString().Replace(",", "."),              //19
                                                             ProdutoTributacao.prbt_ICMS_Reducao.ToString().Replace(",", "."),                       //20
                                                             ProdutoTributacao.prbt_ICMS_Revenda_CST,                                                //21
                                                             ProdutoTributacao.prbt_ICMS_Revenda_Aliquota_Interna.ToString().Replace(",", "."),      //22
                                                             ProdutoTributacao.prbt_ICMS_Revenda_Reducao.ToString().Replace(",", "."),               //23
                                                             ProdutoTributacao.prbt_NCM,                                                             //24
                                                             ProdutoTributacao.prbt_CEST,                                                            //25
                                                             ProdutoTributacao.prbt_ST_IVA.ToString().Replace(",", "."),                             //26
                                                             "false");
                return RedShift_SELECT;                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static string RedShift_Select()
        {
            string RedShift_SELECT = "  SELECT   convert(int, 2)                                    AS CdOperacao     " +
          "         ,   convert(int,X.PRODUTO_KEY)                             AS CdProdutoBlueSoft     " +
          "         ,   convert(int,99999)                                     AS CdRegraFiscal     " +
          "         ,   convert(int,99999)                                     AS CdRegraFiscalVersao     " +
          "         ,   convert(char(1), 'X')                                  AS RegimeTributario     " +
          "         ,   convert(char(4), '5102')                               AS CFOP     " +
          "         ,   convert(char(2), PISE.CST_PIS_COFINS_KEY)              AS PIS_ENTRADA_CST     " +
          "         ,   convert(numeric(13,2), ISNULL(PISE.ALIQUOTA,0))        AS PIS_ENTRADA_ALIQUOTA     " +
          "         ,   convert(char(2), PISS.CST_PIS_COFINS_KEY)              AS PIS_SAIDA_CST     " +
          "         ,   convert(numeric(13,2), ISNULL(PISS.ALIQUOTA,0))        AS PIS_SAIDA_ALIQUOTA     " +
          "         ,   convert(char(2), COFE.CST_PIS_COFINS_KEY)              AS COFINS_ENTRADA_CST     " +
          "         ,   convert(numeric(13,2), ISNULL(COFE.ALIQUOTA,0))        AS COFINS_ENTRADA_ALIQUOTA     " +
          "         ,   convert(char(2), COFS.CST_PIS_COFINS_KEY)              AS COFINS_SAIDA_CST     " +
          "         ,   convert(numeric(13,2), ISNULL(COFS.ALIQUOTA,0))        AS COFINS_SAIDA_ALIQUOTA     " +

          "         ,   case char_length(ICM_SAIDA.CODIGO_TRIBUTACAO) " +
          "                             when  1 then CAST(ICM_SAIDA.CODIGO_ORIGEM AS VARCHAR(1)) + '0' +  CAST(ICM_SAIDA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
          "                             when  2 then CAST(ICM_SAIDA.CODIGO_ORIGEM AS VARCHAR(1)) + CAST(ICM_SAIDA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
          "                             else         CAST(ICM_SAIDA.CODIGO_ORIGEM AS VARCHAR(1)) + CAST(ICM_SAIDA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
          "                             end          AS ICMS_SAIDA_CST     " +
          "         ,   convert(numeric(13,2), ISNULL(ICM_SAIDA.ALIQUOTA,0))   AS ICMS_ALIQUOTA_INTERNA     " +
          "         ,   convert(numeric(13,2), ICM_SAIDA.REDUCAO)              AS ICMS_REDUCAO     " +

          "         ,   case char_length(ICM_ENTRADA.CODIGO_TRIBUTACAO) " +
          "                             when  1 then CAST(ICM_ENTRADA.CODIGO_ORIGEM AS VARCHAR(1)) + '0' +  CAST(ICM_ENTRADA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
          "                             when  2 then CAST(ICM_ENTRADA.CODIGO_ORIGEM AS VARCHAR(1)) + CAST(ICM_ENTRADA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
          "                             else         CAST(ICM_ENTRADA.CODIGO_ORIGEM AS VARCHAR(1)) + CAST(ICM_ENTRADA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
          "                             end          AS ICMS_ENTRADA_CST     " +
          "         ,   convert(numeric(13,2), ISNULL(ICM_ENTRADA.ALIQUOTA,0))   AS ICMS_ENTRADA_ALIQUOTA_INTERNA     " +
          "         ,   convert(numeric(13,2), ICM_ENTRADA.REDUCAO)              AS ICMS_ENTRADA_REDUCAO     " +


          "         ,   case char_length(ICM_REVENDA.CODIGO_TRIBUTACAO) " +
          "                             when  1 then CAST(ICM_REVENDA.CODIGO_ORIGEM AS VARCHAR(1)) + '0' +  CAST(ICM_REVENDA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
          "                             when  2 then CAST(ICM_REVENDA.CODIGO_ORIGEM AS VARCHAR(1)) + CAST(ICM_REVENDA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
          "                             else         CAST(ICM_REVENDA.CODIGO_ORIGEM AS VARCHAR(1)) + CAST(ICM_REVENDA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
          "                             end          AS ICMS_REVENDA_CST     " +
          "         ,   convert(numeric(13,2), ISNULL(ICM_REVENDA.ALIQUOTA,0))   AS ICMS_REVENDA_ALIQUOTA_INTERNA     " +
          "         ,   convert(numeric(13,2), ICM_REVENDA.REDUCAO)              AS ICMS_REVENDA_REDUCAO     " +

          "         ,   convert(varchar(8), CLAS.NCM)                          AS NCM     " +
          "         ,   convert(varchar(7), CEST.codigo)                       AS CEST     " +
          "         ,   convert(numeric(17,4), ISNULL(FX.IVA_ST,0))            AS ST_IVA     " +
          "         ,   convert(varchar(1), '')                                as DADOS_ADICIONAIS " +
          "         ,   convert(varchar(1), '')                                as OBSERVACAO_FISCAL " +
          " FROM        PRODUTO_D                       X     " +
          " INNER JOIN  FIGURA_FISCAL_ESTADUAL          FX          ON FX.PRODUTO_KEY = X.PRODUTO_KEY AND FX.ESTADO_SIGLA = 'SP'     " +
          " INNER JOIN  ICM                             ICM_SAIDA   ON   ICM_SAIDA.ICM_KEY = FX.ICM_KEY     " +
          " INNER JOIN  ICM                             ICM_ENTRADA ON ICM_ENTRADA.ICM_KEY = FX.icm_entrada_key     " +
          " INNER JOIN  ICM                             ICM_REVENDA ON ICM_REVENDA.ICM_KEY = FX.icm_revenda_key     " +
          " INNER JOIN  PIS                             PISS        ON PISS.PIS_KEY = X.PIS_KEY     " +
          " INNER JOIN  PIS                             PISE        ON PISE.PIS_KEY = X.PIS_ENTRADA_KEY     " +
          " INNER JOIN  COFINS                          COFS        ON COFS.COFINS_KEY = X.COFINS_KEY     " +
          " INNER JOIN  COFINS                          COFE        ON COFE.COFINS_KEY = X.COFINS_ENTRADA_KEY     " +
          " INNER JOIN  CLASSIFICACAO_FISCAL            CLAS        ON CLAS.CLASSIFICACAO_FISCAL_KEY = X.CLASSIFICACAO_FISCAL_KEY     " +
          " LEFT  JOIN  CEST                            CEST        ON CEST.CEST_KEY = X.CEST_KEY     " +
          " WHERE x.produto_key > 0     " +
          " UNION     " +
          " select     convert(int,1)                                   as CdOperacao     " +
          "        ,   convert(int,pd.produto_key)                      as CdProdutoBlueSoft     " +
          "        ,   convert(int,rs.regra_fiscal_saida_key)           AS CdRegraFiscal " +
          "        ,   convert(int,rg.regra_fiscal_saida_versao_key)    AS CdRegraFiscalVersao " +
          "        ,   convert(char(1), left(tb.regime_tributario,1))   AS RegimeTributario " +
          "        ,   convert(char(4), tb.cfop_key)                    AS CFOP     " +
          "        ,   CONVERT(VARCHAR(2), '00')                        AS PIS_ENTRADA_CST     " +
          "        ,   CONVERT(NUMERIC(13,2), 0)                        AS PIS_ENTRADA_ALIQUOTA     " +
          "        ,   convert(char(2), PS.CST_PIS_COFINS_KEY)          AS PIS_SAIDA_CST     " +
          "        ,   convert(numeric(13,2), ps.aliquota)              AS PIS_SAIDA_ALIQUOTA     " +
          "        ,   CONVERT(VARCHAR(2), '00')                        AS COFINS_ENTRADA_CST     " +
          "        ,   CONVERT(NUMERIC(13,2), 0)                        AS COFINS_ENTRADA_ALIQUOTA     " +
          "        ,   convert(char(2), CS.cst_pis_cofins_key)          AS COFINS_SAIDA_CST     " +
          "        ,   convert(numeric(13,2), cs.aliquota)              AS COFINS_SAIDA_ALIQUOTA     " +
          "        ,   case char_length(IC.CODIGO_TRIBUTACAO) " +
          "                             when  1 then CAST(IC.CODIGO_ORIGEM AS VARCHAR(1)) + '0' + CAST(IC.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
          "                             when  2 then CAST(IC.CODIGO_ORIGEM AS VARCHAR(1))       + CAST(IC.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
          "                             else         CAST(IC.CODIGO_ORIGEM AS VARCHAR(1))       + CAST(IC.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
          "                             end                             AS ICMS_SAIDA_CST     " +
          "        ,   CONVERT(NUMERIC(13,2), ic.aliquota)              AS ICMS_ALIQUOTA_INTERNA     " +
          "        ,   CONVERT(NUMERIC(13,2), IC.REDUCAO)               AS ICMS_REDUCAO " +

          "        ,   CONVERT(VARCHAR(3), '000')                       AS ICMS_ENTRADA_CST     " +
          "        ,   CONVERT(NUMERIC(13,2), ic.aliquota)              AS ICMS_ENTRADA_ALIQUOTA_INTERNA     " +
          "        ,   CONVERT(NUMERIC(13,2), IC.REDUCAO)               AS ICMS_ENTRADA_REDUCAO " +

          "        ,   case char_length(IC.CODIGO_TRIBUTACAO) " +
          "                             when  1 then CAST(IC.CODIGO_ORIGEM AS VARCHAR(1)) + '0' + CAST(IC.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
          "                             when  2 then CAST(IC.CODIGO_ORIGEM AS VARCHAR(1))       + CAST(IC.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
          "                             else         CAST(IC.CODIGO_ORIGEM AS VARCHAR(1))       + CAST(IC.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
          "                             end                             AS ICMS_REVENDA_CST     " +
          "        ,   CONVERT(NUMERIC(13,2), ic.aliquota)              AS ICMS_REVENDA_ALIQUOTA_INTERNA     " +
          "        ,   CONVERT(NUMERIC(13,2), IC.REDUCAO)               AS ICMS_REVENDA_REDUCAO " +

          "        ,   CONVERT(VARCHAR(8), '00000000')                  AS NCM     " +

          "        ,   CONVERT(VARCHAR(7), '0000000')                   AS CEST     " +
          "        ,   CONVERT(NUMERIC(13,2),0)                         AS ST_IVA     " +
          "        ,   tb.dados_adicionais                              AS DADOS_ADICIONAIS " +
          "        ,   tb.observacoes                                   AS OBSERVACAO_FISCAL " +
          "  from       regra_fiscal_saida_produto    pd     " +
          "  inner join regra_fiscal_saida_versao     rg  on rg.regra_fiscal_saida_key = pd.regra_fiscal_saida_key     " +
          "  inner join (  select     rg1.regra_fiscal_saida_key                as  regra_fiscal_saida_key     " +
          "                        ,  max(rg1.regra_fiscal_saida_versao_key)    as  regra_fiscal_saida_versao_key     " +
          "                from       regra_fiscal_saida_versao             rg1     " +
          "                inner join (   select    regra_fiscal_saida_key        as regra_fiscal_saida_key,     " +
          "                                         max(data_inicio_vigencia)     as data_inicio_vigencia     " +
          "                               from      regra_fiscal_saida_versao     " +
          "                               group by  regra_fiscal_saida_key     " +
          "                            )  rg2 on rg2.regra_fiscal_saida_key = rg1.regra_fiscal_saida_key and rg2.data_inicio_vigencia = rg1.data_inicio_vigencia     " +
          "                group by rg1.regra_fiscal_saida_key     " +
          "             ) rg_versao_atual on rg.regra_fiscal_saida_versao_key = rg_versao_atual.regra_fiscal_saida_versao_key     " +
          "  inner join regra_fiscal_saida               rs on rs.regra_fiscal_saida_key = rg.regra_fiscal_saida_key     " +
          "  inner join regra_fiscal_saida_trib          tb on tb.regra_fiscal_saida_versao_key = rg.regra_fiscal_saida_versao_key     " +
          "  inner join ICM                              ic on ic.icm_key = tb.icm_key     " +
          "  inner join PIS                              ps on ps.pis_key = rg.pis_key     " +
          "  inner join COFINS                           cs on cs.COFINS_key = rg.COFINS_key  " +
          "  ORDER BY 1,2,5,6,7 ASC ";

            return RedShift_SELECT;

        }
    }
}
