
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Models;


namespace Pag_Net.SPC0111.Models
{
    public class ProdutoBlueSoftTributacaoObservacoes
    {
        public int CdProdutoBlueSoft { get; set; }
        public int CdOperacao { get; set; }
        public int CdRegraFiscal { get; set; }
        public int CdRegraFiscalVersao { get; set; }
        public string CFOP { get; set; }
        public string RegimeTributario { get; set; }
        public string Observacoes { get; set; }
        public string DadosFiscais  { get; set; }


        public ProdutoBlueSoftTributacaoObservacoes()
        {

        }

        public ProdutoBlueSoftTributacaoObservacoes(System.Data.DataRow i)
        {
            string errorString = i["CdProdutoBlueSoft"].ToString();
            try
            {
                CdProdutoBlueSoft = Convert.ToInt32(i["CdProdutoBlueSoft"]);
                CdOperacao = Convert.ToInt32(i["CdOperacao"]);
                CdRegraFiscal = Convert.ToInt32(i["CdRegraFiscal"]);
                CdRegraFiscalVersao = Convert.ToInt32(i["CdRegraFiscalVersao"]);
                CFOP = i["CFOP"].ToString();
                RegimeTributario = i["RegimeTributario"].ToString();
                Observacoes = i["Observacoes"].ToString();
                DadosFiscais = i["DadosFiscais"].ToString();
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



namespace Pag_Net.SPC0111.Models.BD
{
    public static class SqlServer
    {
        public static string SqlProcedureName()
        {
            return "SPC0111_ProdutoBlueSoftTributacaoObservacoes";
        }

        public static ParameterQuey[] Fill(Pag_Net.SPC0111.Models.ProdutoBlueSoftTributacaoObservacoes item, Pag_Net.Models.BDCommandTypes _Type)
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
                SQLParametros.Add(new ParameterQuey("Observacoes", SqlDbType.VarChar, false, item.Observacoes));
                SQLParametros.Add(new ParameterQuey("DadosFiscais", SqlDbType.VarChar, false, item.DadosFiscais));

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
                       "         ,   convert(varchar(1), '')                                as DadosFiscais " +
                       "         ,   convert(varchar(1), '')                                as Observacoes " +
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
                       "        ,   tb.dados_adicionais                              AS DadosFiscais " +
                       "        ,   tb.observacoes                                   AS Observacoes " +
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
