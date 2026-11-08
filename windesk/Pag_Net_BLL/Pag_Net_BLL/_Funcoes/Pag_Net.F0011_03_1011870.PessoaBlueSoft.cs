using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;

namespace Pag_Net.Bll.F0011_03
{

    public static class RedShift
    {
        public static string get(
            DateTime data_inicial,
            DateTime data_final
            )
        {
            string SQL = "  SELECT        PS.PESSOA_KEY                              as cdpessoabluesoft " +
       "                            ,     PS.NOME_RAZAO                              as nome_razao " +
       "                            ,     PS.NOME_ABREVIADO                          as nome_abreviado " +
       "                            ,     PS.CPF_CNPJ                                as cnpj " +
       "                            ,     ISNULL(sexo,'M')                           as sexo  " +
       "                            ,     ISNULL(data_nascimento, '1900-01-01')      as data_nascimento " +
       "                            ,     left(ISNULL(email_comercial, ''),60)       as email_main " +
       "                            ,     ISNULL(latitude,0)                         as latitude " +
       "                            ,     ISNULL(longitude,0)                        as longitude        " +
       "                            ,     CASE WHEN COALESCE(CL.CLIENTE_KEY,0) <> 0 THEN 1 else 0    end as bluesoftcliente  " +
       "                            ,     CASE WHEN COALESCE(VE.VENDEDOR_EXTERNO_KEY,0) <> 0 THEN 1 else 0 end as bluesoftvendedor      " +
       "                            ,     CASE WHEN COALESCE(FO.FORNECEDOR_KEY,0) <> 0 THEN 1 else 0 end as bluesoftfornecedor " +
       "                            ,     CASE WHEN COALESCE(FA.FABRICANTE_KEY,0) <> 0 THEN 1 else 0 end as bluesoftfabricante" +
       "                            ,     COALESCE(CLIENTE.GRUPO_ECONOMICO_KEY,0) AS cdgrupoeconomico " +
       "                            ,     COALESCE(CLIENTE.VENDEDOR_EXTERNO_KEY,0) AS cdpessoabluesoft_vendedor" +
       "                            ,     COALESCE(CL.bluesoftclientestatus,0)     as bluesoftclientestatus " +
       "                            ,     COALESCE(PS.STATUS,0)                         AS bluesoftpessoastatus " +
       "                            ,     COALESCE(PS.DATA_CADASTRO, '1900-01-01')  AS bluesoftpessoa_data_cadastro " + 
       "                            ,     COALESCE(CL.bluesoftcliente_creditolimite_valor,0)           AS bluesoftcliente_creditolimite_valor " +
       "                            ,     COALESCE(CL.bluesoftcliente_creditolimite_valor_reservado,0) AS bluesoftcliente_creditolimite_valor_reservado " +
       "                            ,     COALESCE(CL.bluesoftcliente_creditostatus_cd,0)              AS bluesoftcliente_creditostatus_cd " +
       "                            ,     COALESCE(CL.bluesoftcliente_ramoatividade_cd,0)              AS bluesoftcliente_ramoatividade_cd " + 
       "                    FROM        PESSOA PS" +
       "                    LEFT JOIN   (     SELECT    FORNECEDOR_KEY        AS FORNECEDOR_KEY " +
       "                                      FROM      FORNECEDOR_PRODUTO " +
       "                                      GROUP BY  FORNECEDOR_KEY" +
       "                                ) FO ON FO.FORNECEDOR_KEY = PS.PESSOA_KEY " +
       "                    LEFT JOIN   (     SELECT    FABRICANTE_KEY        AS FABRICANTE_KEY" +
       "                                      FROM      PRODUTO_D" +
       "                                      GROUP BY  FABRICANTE_KEY" +
       "                                ) FA ON FA.FABRICANTE_KEY = PS.PESSOA_KEY " +
       "                    LEFT JOIN   (     SELECT    PESSOA_KEY        AS CLIENTE_KEY " +
       "                                            ,   cast(CASE WHEN COALESCE(STATUS,'INATIVO') = 'INATIVO' THEN 0 ELSE 1 END as int) AS bluesoftclientestatus " +
       "                                            ,   COALESCE(credito_limite,0)       AS bluesoftcliente_creditolimite_valor " +
       "                                            ,   COALESCE(credito_usado,0)        AS bluesoftcliente_creditolimite_valor_reservado " +
       "                                            ,   COALESCE(status_credito,0)       AS bluesoftcliente_creditostatus_cd " +
       "                                            ,   COALESCE(ramo_atividade_key,0)   AS bluesoftcliente_ramoatividade_cd " + 
       "                                      FROM      CLIENTE" +
       
       "                                ) CL ON CL.CLIENTE_KEY = PS.PESSOA_KEY " +
       "                    LEFT JOIN   (   select VENDEDOR_EXTERNO_KEY  as VENDEDOR_EXTERNO_KEY FROM GRUPO_ECONOMICO_COMISSAO GROUP BY VENDEDOR_EXTERNO_KEY ) VE ON VE.VENDEDOR_EXTERNO_KEY = PS.PESSOA_KEY " +
       "                    LEFT JOIN  ( SELECT      PS.PESSOA_KEY                   AS CLIENTE_KEY " + 
       "                                         ,   CG.GRUPO_ECONOMICO_KEY          AS GRUPO_ECONOMICO_KEY " + 
       "                                         ,   MIN(GM.VENDEDOR_EXTERNO_KEY)    AS VENDEDOR_EXTERNO_KEY " + 
       "                                 FROM        PESSOA  PS " + 
       "                                 INNER JOIN  CLIENTE_GRUPO_ECONOMICO     CG ON CG.CLIENTE_KEY = PS.PESSOA_KEY " + 
       "                                 INNER JOIN  GRUPO_ECONOMICO_COMISSAO    GM ON GM.CLIENTE_GRUPO_ECONOMICO_KEY = CG.CLIENTE_GRUPO_ECONOMICO_KEY " + 
       "                                 GROUP BY    PS.PESSOA_KEY " +
       "                                         ,   CG.GRUPO_ECONOMICO_KEY " + 
       "                               ) CLIENTE ON CLIENTE.CLIENTE_KEY = PS.PESSOA_KEY " +
       "                     WHERE CAST(PS.CPF_CNPJ AS NUMERIC(14,0)) > 0 ";
               return SQL;
           }
       }

    public static class Postgres
    {
        public static string post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            string _SqlCommand,
            bool _Api,
            Db item)
        {
            string SQL_POST = string.Format("SELECT " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0011_03) +
                                      "(   'DBINSERT' " +
                                      "  ,  {0}  " +
                                      "  , '{1}' " +
                                      "  , '{2}' " +
                                      "  , '{3}' " +
                                      "  , '{4}' " +
                                      "  , '{5}' " +
                                      "  , '{6}' " +
                                      "  ,  {7}  " +
                                      "  ,  {8}  " +
                                      "  ,  {9}  " +
                                      "  ,  {10}  " +
                                      "  ,  {11}  " +
                                      "  ,  {12}  " +
                                      "  ,  {13}  " +
                                      "  ,  {14}  " +
                                      "  ,  {15}  " +
                                      "  ,  {16}  " +
                                      "  ,  {17}  " +
                                      "  ,  {18}  " +
                                      "  ,  {19} " +
                                      "  , '{20}' " + 
                                      "  ,  {20}  )",
                                     item.cdpessoabluesoft.ToString()
                                   , item.nome_razao.ToString().Replace("'", "")
                                   , item.nome_abreviado.ToString().Replace("'", "")
                                   , item.cnpj.ToString()
                                   , item.sexo.ToString()
                                   , item.data_nascimento.ToString("yyyy-MM-dd")
                                   , item.email_main.ToString().Replace("'", "")
                                   , item.latitude.ToString("0.00").Replace(",", ".")
                                   , item.longitude.ToString("0.00").Replace(",", ".")
                                   , item.bluesoftcliente.ToString()
                                   , item.bluesoftvendedor.ToString()
                                   , item.bluesoftfornecedor.ToString()
                                   , item.bluesoftfabricante.ToString()
                                   , item.cdgrupoeconomico.ToString()
                                   , item.cdpessoabluesoft_vendedor.ToString()
                                   , item.bluesoftclientestatus.ToString()
                                   , item.bluesoftpessoastatus.ToString()
                                   , item.bluesoftcliente_creditolimite_valor.ToString("0.00").Replace(",",".")
                                   , item.bluesoftcliente_creditolimite_valor_reservado.ToString("0.00").Replace(",", ".")
                                   , item.bluesoftcliente_creditostatus_cd.ToString()
                                   , item.bluesoftpessoa_data_cadastro.ToString("yyyy-MM-dd")
                                   , item.bluesoftcliente_ramoatividade_cd.ToString()

                                                 );
            return SQL_POST;
        }
    }

    public class Db
    {
                public int      cdpessoabluesoft              { get; set; }
                public string   nome_razao                    { get; set; }
                public string   nome_abreviado                { get; set; }
                public string   cnpj                          { get; set; }
                public string   sexo                          { get; set; }
                public DateTime data_nascimento             { get; set; }
                public string   email_main                    { get; set; }
                public double   latitude                      { get; set; }
                public double   longitude                     { get; set; }
                public int      bluesoftcliente                  { get; set; }
                public int      bluesoftvendedor                 { get; set; }
                public int      bluesoftfornecedor               { get; set; }
                public int      bluesoftfabricante               { get; set; }
                public int      cdgrupoeconomico                 { get; set; }
                public int      cdpessoabluesoft_vendedor        { get; set; }

                public int      bluesoftclientestatus                           { get; set;  }
                public int      bluesoftpessoastatus                            { get; set; }
                public double   bluesoftcliente_creditolimite_valor             { get; set; }
                public double   bluesoftcliente_creditolimite_valor_reservado   { get; set; }
                public int      bluesoftcliente_creditostatus_cd                { get; set; }
                public DateTime bluesoftpessoa_data_cadastro                    { get; set; }
                public int      bluesoftcliente_ramoatividade_cd                { get; set; }
            


        public Db()
        {

        }

        public Db(System.Data.DataRow i)
        {
            string errorString = i["CdPessoaBlueSoft"].ToString();
            try
            {
                cdpessoabluesoft = Convert.ToInt32(i["cdpessoabluesoft"]);
                nome_razao = i["nome_razao"].ToString();
                nome_abreviado = i["nome_abreviado"].ToString();
                cnpj = i["cnpj"].ToString();
                sexo = i["sexo"].ToString();
                data_nascimento = Convert.ToDateTime(i["data_nascimento"]);
                email_main = i["email_main"].ToString();
                latitude = Convert.ToDouble(i["latitude"]);
                longitude = Convert.ToDouble(i["longitude"]);
                bluesoftcliente = Convert.ToInt32(i["bluesoftcliente"]);
                bluesoftvendedor = Convert.ToInt32(i["bluesoftvendedor"]);
                bluesoftfornecedor = Convert.ToInt32(i["bluesoftfornecedor"]);
                bluesoftfabricante = Convert.ToInt32(i["bluesoftfabricante"]);
                cdgrupoeconomico = Convert.ToInt32(i["cdgrupoeconomico"]);
                cdpessoabluesoft_vendedor = Convert.ToInt32(i["cdpessoabluesoft_vendedor"]);

                bluesoftclientestatus = Convert.ToInt32(i["bluesoftclientestatus"]);
                bluesoftpessoastatus = Convert.ToInt32(i["bluesoftpessoastatus"]);
                bluesoftcliente_creditolimite_valor = Convert.ToDouble(i["bluesoftcliente_creditolimite_valor"]);
                bluesoftcliente_creditolimite_valor_reservado = Convert.ToDouble(i["bluesoftcliente_creditolimite_valor_reservado"]);
                bluesoftcliente_creditostatus_cd = Convert.ToInt32(i["bluesoftcliente_creditostatus_cd"]);
                bluesoftpessoa_data_cadastro = Convert.ToDateTime(i["bluesoftpessoa_data_cadastro"].ToString());
                bluesoftcliente_ramoatividade_cd = Convert.ToInt32(i["bluesoftcliente_ramoatividade_cd"]);       

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " | " + errorString);
            }
        }

    }

}

