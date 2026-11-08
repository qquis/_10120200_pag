
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Models;


namespace Pag_Net.SPC0110.Models
{
    public class ProdutoBlueSoftTributacao
    {
        public string SQLSP
        {
            get
            {
                return "SPC0110ProdutoBlueSoftTributacao";
            }
        }


        public string Tipo { get; set; }
        public int CdProdutoBlueSoft { get; set; }
        public int CdOperacao { get; set; }
        public int CdRegraFiscal { get; set; }
        public int CdRegraFiscalVersao { get; set; }
        public string CFOP { get; set; }
        public string RegimeTributario { get; set; }
        public string PIS_Entrada_CST { get; set; }
        public double PIS_Entrada_Aliquota { get; set; }
        public string PIS_Saida_CST { get; set; }
        public double PIS_Saida_Aliquota { get; set; }
        public string COFINS_Entrada_CST { get; set; }
        public double COFINS_Entrada_Aliquota { get; set; }
        public string COFINS_Saida_CST { get; set; }
        public double COFINS_Saida_Aliquota { get; set; }
        public string ICMS_Saida_CST { get; set; }
        public string ICMS_Entrada_CST { get; set; }
        public double ICMS_Aliquota_Interna { get; set; }
        public double ICMS_Reducao { get; set; }
        public string NCM { get; set; }
        public string CEST { get; set; }
        public double ST_IVA { get; set; }


        public ProdutoBlueSoftTributacao()
        {

        }


        public ProdutoBlueSoftTributacao(System.Data.DataRow i)
        {
            string errorString = i["CdProdutoBlueSoft"].ToString();
            try
            {
                //FiltroDePesquisa_NumeroPedidoForca = Convert.ToInt32(i["FiltroDePesquisa_NumeroPedidoForca"]);
                //FiltroDePesquisa_NumeroPedidoCliente = Convert.ToInt32(i["FiltroDePesquisa_NumeroPedidoCliente"]);
                //FiltroDePesquisa_NotaFiscalSeq = Convert.ToInt32(i["FiltroDePesquisa_NotaFiscalSeq"]);
                CdProdutoBlueSoft = Convert.ToInt32(i["CdProdutoBlueSoft"]);
                CdOperacao = Convert.ToInt32(i["CdOperacao"]);
                CdRegraFiscal = Convert.ToInt32(i["CdRegraFiscal"]);
                CdRegraFiscalVersao = Convert.ToInt32(i["CdRegraFiscalVersao"]);
                CFOP = i["CFOP"].ToString();
                RegimeTributario = i["RegimeTributario"].ToString();
                PIS_Entrada_CST = i["PIS_Entrada_CST"].ToString();
                PIS_Entrada_Aliquota = Convert.ToDouble(i["PIS_Entrada_Aliquota"].ToString());
                PIS_Saida_CST = i["PIS_Saida_CST"].ToString();
                PIS_Saida_Aliquota = Convert.ToDouble(i["PIS_Saida_Aliquota"].ToString());
                COFINS_Entrada_CST = i["COFINS_Entrada_CST"].ToString();
                COFINS_Entrada_Aliquota = Convert.ToDouble(i["COFINS_Entrada_Aliquota"].ToString());
                COFINS_Saida_CST = i["COFINS_Saida_CST"].ToString();
                COFINS_Saida_Aliquota = Convert.ToDouble(i["COFINS_Saida_Aliquota"].ToString());
                ICMS_Saida_CST = i["ICMS_Saida_CST"].ToString();
                ICMS_Entrada_CST = i["ICMS_Entrada_CST"].ToString();
                ICMS_Aliquota_Interna = Convert.ToDouble(i["ICMS_Aliquota_Interna"].ToString());
                ICMS_Reducao = Convert.ToDouble(i["ICMS_Reducao"].ToString());
                NCM = i["NCM"].ToString();
                CEST = i["CEST"].ToString();
                ST_IVA = Convert.ToDouble(i["ST_IVA"].ToString());

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " | " + errorString);
            }
        }




  

    }
    public class Parametros
    {

    }
}


namespace Pag_Net.SPC0110.Models.BD
{
    public static class SqlServer
    {
        public static string SqlProcedureName()
        {
            return "SPC0110_ProdutoBlueSoftTributacao";
        }

        public static ParameterQuey[] Fill(Pag_Net.SPC0110.Models.ProdutoBlueSoftTributacao item, Pag_Net.Models.BDCommandTypes _Type)
        {
            string LinhaEmExecucao = "Código do Produto: " + item.CdProdutoBlueSoft.ToString();
            try
            {
                List<ParameterQuey> SQLParametros = new List<ParameterQuey>();
                SQLParametros.Add(new ParameterQuey("SQLCommand", SqlDbType.VarChar, false, BDTools.SqlCommandType(_Type)));
                SQLParametros.Add(new ParameterQuey("CdProdutoBlueSoft", SqlDbType.Int, false, Convert.ToInt32(item.CdProdutoBlueSoft)));
                SQLParametros.Add(new ParameterQuey("CdOperacao", SqlDbType.Int, false, Convert.ToInt32(item.CdOperacao)));
                SQLParametros.Add(new ParameterQuey("CdRegraFiscal", SqlDbType.Int, false, Convert.ToInt32(item.CdRegraFiscal)));
                SQLParametros.Add(new ParameterQuey("CdRegraFiscalVersao", SqlDbType.Int, false, Convert.ToInt32(item.CdRegraFiscalVersao)));
                SQLParametros.Add(new ParameterQuey("CFOP", SqlDbType.VarChar, false, item.CFOP));
                SQLParametros.Add(new ParameterQuey("RegimeTributario", SqlDbType.VarChar, false, item.RegimeTributario));
                SQLParametros.Add(new ParameterQuey("PIS_Entrada_CST", SqlDbType.VarChar, false, item.PIS_Entrada_CST));
                SQLParametros.Add(new ParameterQuey("PIS_Entrada_Aliquota", SqlDbType.Decimal, false, item.PIS_Entrada_Aliquota));
                SQLParametros.Add(new ParameterQuey("PIS_Saida_CST", SqlDbType.VarChar, false, item.PIS_Saida_CST));
                SQLParametros.Add(new ParameterQuey("PIS_Saida_Aliquota", SqlDbType.Decimal, false, item.PIS_Saida_Aliquota));
                SQLParametros.Add(new ParameterQuey("COFINS_Entrada_CST", SqlDbType.VarChar, false, item.COFINS_Entrada_CST));
                SQLParametros.Add(new ParameterQuey("COFINS_Entrada_Aliquota", SqlDbType.Decimal, false, item.COFINS_Entrada_Aliquota));
                SQLParametros.Add(new ParameterQuey("COFINS_Saida_CST", SqlDbType.VarChar, false, item.COFINS_Saida_CST));
                SQLParametros.Add(new ParameterQuey("COFINS_Saida_Aliquota", SqlDbType.Decimal, false, item.COFINS_Saida_Aliquota));
                SQLParametros.Add(new ParameterQuey("ICMS_Saida_CST", SqlDbType.VarChar, false, item.ICMS_Saida_CST));
                SQLParametros.Add(new ParameterQuey("ICMS_Entrada_CST", SqlDbType.VarChar, false, item.ICMS_Entrada_CST));
                SQLParametros.Add(new ParameterQuey("ICMS_Aliquota_Interna", SqlDbType.Decimal, false, item.ICMS_Aliquota_Interna));
                SQLParametros.Add(new ParameterQuey("ICMS_Reducao", SqlDbType.Decimal, false, item.ICMS_Reducao));
                SQLParametros.Add(new ParameterQuey("NCM", SqlDbType.VarChar, false, item.NCM));
                SQLParametros.Add(new ParameterQuey("CEST", SqlDbType.VarChar, false, item.CEST));
                SQLParametros.Add(new ParameterQuey("ST_IVA", SqlDbType.Decimal, false, item.ST_IVA));

                return SQLParametros.ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " | " + LinhaEmExecucao);
            }

        }


    }

    public static class RedShift
    {
        public static string Select()
        {
            string SQL = "  SELECT   convert(int, 2)                                        AS CdOperacao     " +
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
                       "         ,   convert(numeric(13,2), ISNULL(ICM_SAIDA.ALIQUOTA,0))   AS ICMS_ALIQUOTA_INTERNA     " +
                       "         ,   convert(numeric(13,2),ICM_SAIDA.REDUCAO)               AS ICMS_REDUCAO     " +




                       "         ,   case char_length(ICM_SAIDA.CODIGO_TRIBUTACAO) " +
                       "                             when  1 then CAST(ICM_SAIDA.CODIGO_ORIGEM AS VARCHAR(1)) + '0' +  CAST(ICM_SAIDA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                       "                             when  2 then CAST(ICM_SAIDA.CODIGO_ORIGEM AS VARCHAR(1)) + CAST(ICM_SAIDA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                       "                             else         CAST(ICM_SAIDA.CODIGO_ORIGEM AS VARCHAR(1)) + CAST(ICM_SAIDA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                       "                             end          AS ICMS_SAIDA_CST     " +


                       "         ,   case char_length(ICM_ENTRADA.CODIGO_TRIBUTACAO) " +
                       "                             when  1 then CAST(ICM_ENTRADA.CODIGO_ORIGEM AS VARCHAR(1)) + '0' +  CAST(ICM_ENTRADA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                       "                             when  2 then CAST(ICM_ENTRADA.CODIGO_ORIGEM AS VARCHAR(1)) + CAST(ICM_ENTRADA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                       "                             else         CAST(ICM_ENTRADA.CODIGO_ORIGEM AS VARCHAR(1)) + CAST(ICM_ENTRADA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                       "                             end          AS ICMS_ENTRADA_CST     " +



                       "         ,   convert(varchar(8), CLAS.NCM)                          AS NCM     " +
                       "         ,   convert(varchar(7), CEST.codigo)                       AS CEST     " +
                       "         ,   convert(numeric(17,4), ISNULL(FX.IVA_ST,0))            AS ST_IVA     " +
                       "         ,   convert(varchar(1), '')                                as DADOS_ADICIONAIS " +
                       "         ,   convert(varchar(1), '')                                as OBSERVACAO_FISCAL " +
                       " FROM        PRODUTO_D                       X     " +
                       " INNER JOIN  FIGURA_FISCAL_ESTADUAL          FX          ON FX.PRODUTO_KEY = X.PRODUTO_KEY AND FX.ESTADO_SIGLA = 'SP'     " +
                       " INNER JOIN  ICM                             ICM_SAIDA   ON ICM_SAIDA.ICM_KEY = FX.ICM_KEY     " +
                       " INNER JOIN  ICM                             ICM_ENTRADA ON ICM_ENTRADA.ICM_KEY = FX.icm_entrada_key     " +
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
                       "        ,   CONVERT(NUMERIC(13,2), ic.aliquota)              AS ICMS_ALIQUOTA_INTERNA     " +
                       "        ,   CONVERT(NUMERIC(13,2), IC.REDUCAO)               AS ICMS_REDUCAO " +
                       "        ,   case char_length(IC.CODIGO_TRIBUTACAO) " +
                       "                             when  1 then CAST(IC.CODIGO_ORIGEM AS VARCHAR(1)) + '0' + CAST(IC.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                       "                             when  2 then CAST(IC.CODIGO_ORIGEM AS VARCHAR(1))       + CAST(IC.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                       "                             else         CAST(IC.CODIGO_ORIGEM AS VARCHAR(1))       + CAST(IC.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                       "                             end                             AS ICMS_SAIDA_CST     " +
                       "        ,   CONVERT(VARCHAR(3), '000')                       AS ICMS_ENTRADA_CST     " +
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

            return SQL;
        }
    }

    public static class Postgre
    {
        public static void Insert()
        {

        }

        public static void Delete()
        {

        }
    }
}
