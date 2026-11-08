using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0011;
using Pag_Net.Models;

namespace Pag_Net.Bll.F0011_01
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
       "                    LEFT JOIN   (   SELECT     GV.VENDEDOR_EXTERNO_KEY                  AS VENDEDOR_EXTERNO_KEY " +
       "                                    FROM       PESSOA                   PS " +
       "                                    INNER JOIN CLIENTE_GRUPO_ECONOMICO  CR ON CR.CLIENTE_KEY = PS.PESSOA_KEY " +
       "                                    INNER JOIN GRUPO_ECONOMICO          GR ON GR.GRUPO_ECONOMICO_KEY = CR.GRUPO_ECONOMICO_KEY " +
       "                                    INNER JOIN ( SELECT    MAX(X.VENDEDOR_EXTERNO_KEY)  VENDEDOR_EXTERNO_KEY " +
       "                                                        ,  X.GRUPO_ECONOMICO_KEY        GRUPO_ECONOMICO_KEY" +
       "                                                 FROM      GRUPO_ECONOMICO_COMISSAO   X " +
       "                                                 GROUP BY  X.GRUPO_ECONOMICO_KEY " +
       "                                               ) GX ON GX.GRUPO_ECONOMICO_KEY  = GR.GRUPO_ECONOMICO_KEY " +
       "                                    INNER JOIN GRUPO_ECONOMICO_COMISSAO GV ON GV.GRUPO_ECONOMICO_KEY = GX.GRUPO_ECONOMICO_KEY AND GV.VENDEDOR_EXTERNO_KEY = GX.VENDEDOR_EXTERNO_KEY " +
       "                                    GROUP BY   GV.VENDEDOR_EXTERNO_KEY " +
       "                                ) VE ON VE.VENDEDOR_EXTERNO_KEY = PS.PESSOA_KEY " +
       "                    LEFT JOIN  ( " +
       "                                    SELECT     CR.GRUPO_ECONOMICO_KEY      AS GRUPO_ECONOMICO_KEY " +
       "                                            ,  GV.VENDEDOR_EXTERNO_KEY     AS VENDEDOR_EXTERNO_KEY " +
       "                                            ,  GV.VENDEDOR                 AS VENDEDOR_NOME  " +
       "                                            ,  CR.CLIENTE_KEY              AS CLIENTE_KEY  " +
       "                                    FROM       PESSOA                   PS  " +
       "                                    INNER JOIN CLIENTE_GRUPO_ECONOMICO  CR ON CR.CLIENTE_KEY = PS.PESSOA_KEY  " +
       "                                    INNER JOIN GRUPO_ECONOMICO          GR ON GR.GRUPO_ECONOMICO_KEY = CR.GRUPO_ECONOMICO_KEY  " +
       "                                    INNER JOIN ( SELECT    MAX(X.VENDEDOR_EXTERNO_KEY)  VENDEDOR_EXTERNO_KEY  " +
       "                                                        ,  X.GRUPO_ECONOMICO_KEY        GRUPO_ECONOMICO_KEY " +
       "                                                 FROM      GRUPO_ECONOMICO_COMISSAO   X " +
       "                                                 GROUP BY  X.GRUPO_ECONOMICO_KEY " +
       "                                               ) GX ON GX.GRUPO_ECONOMICO_KEY  = GR.GRUPO_ECONOMICO_KEY  " +
       "                                    INNER JOIN GRUPO_ECONOMICO_COMISSAO GV ON GV.GRUPO_ECONOMICO_KEY = GX.GRUPO_ECONOMICO_KEY AND GV.VENDEDOR_EXTERNO_KEY = GX.VENDEDOR_EXTERNO_KEY " +
       "                                    GROUP BY   CR.GRUPO_ECONOMICO_KEY " +
       "                                                ,  GV.VENDEDOR_EXTERNO_KEY  " +
       "                                                ,  GV.VENDEDOR  " +
       "                                                ,  CR.CLIENTE_KEY " +
       "                               ) CLIENTE ON CLIENTE.CLIENTE_KEY = PS.PESSOA_KEY " +
       "                     WHERE CAST(PS.CPF_CNPJ AS NUMERIC(14,0)) > 0 ";
               return SQL;
           }
       }

    
    public static class Postgres
    {
        public static string post(
                                 Pag_Net.Models.modelSistemaUsuario MyConnect
                        , string _SqlCommand
                        , bool _Api
                        , System.Data.DataRow i
            
            )
        {
            return post(MyConnect
                , _SqlCommand
                , _Api
                , Convert.ToInt32(i["cdpessoa"].ToString())
                , i["cpf_cnpj"].ToString()
                , i["nome_razao"].ToString()
                , i["sexo"].ToString()
                , Convert.ToDateTime(i["data_nascimento"].ToString())
                , i["email_main"].ToString()
                , i["instagram"].ToString()
                , i["facebook"].ToString()
                , i["documento_rg"].ToString()
                , i["documento_cnh"].ToString()
                , Convert.ToDateTime(i["documento_cnh_vencimento"].ToString())
                , Convert.ToBoolean(i["PessoaJuridica"])
                , i["telefone_ddd_main"].ToString()
                , i["telefone_numero_main"].ToString()
                );
        }






        public static string post(
            Pag_Net.Models.modelSistemaUsuario MyConnect
        ,   string      _SqlCommand
        ,   bool        _Api
        ,   int         cdpessoa                     
        ,   string      cpf_cnpj                  
        ,   string      nome_razao                
        ,   string      sexo                      
        ,   DateTime    data_nascimento         
        ,   string      email_main                
        ,   string      instagram                 
        ,   string      facebook                  
        ,   string      documento_rg              
        ,   string      documento_cnh             
        ,   DateTime    documento_cnh_vencimento
        ,   bool        PessoaJuridica 
        ,   string      telefone_ddd_main
        ,   string      telefone_ddd_numero
                )
        {
            try
            {

                

                string SQL_POST = string.Format("SELECT " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0011_01) +
                                          "(   'DBINSERT' " +
                                          "  ,  {0}   " +
                                          "  , '{1}'  " +
                                          "  , '{2}'  " +
                                          "  , '{3}'  " +
                                          "  , '{4}'  " +
                                          "  , '{5}'  " +
                                          "  , '{6}'  " +
                                          "  , '{7}'  " +
                                          "  , '{8}'  " +
                                          "  , '{9}'  " +
                                          "  , '{10}' " +
                                          "  ,  {11}  " +
                                          "  , '{12}' " + 
                                          "   ,'{13}')",
                                         cdpessoa.ToString()
                                       , cpf_cnpj.ToString()
                                       , nome_razao.ToString().Replace("'", "")
                                       , sexo == null ?  "": sexo.ToString()
                                       , data_nascimento.ToString("yyyy-MM-dd")
                                       , email_main == null ? "" : email_main.Replace("'", "")
                                       , instagram == null ? "" : instagram.ToString().Replace("'", "")
                                       , facebook == null ? "" : facebook.ToString().Replace("'", "")
                                       , documento_rg == null ? "" : documento_rg.ToString().Replace("'", "")
                                       , documento_cnh == null ? "" : documento_cnh.ToString().Replace("'", "")
                                       , documento_cnh_vencimento.ToString("yyyy-MM-dd")
                                       , PessoaJuridica ? "1": "0"
                                       , telefone_ddd_main.ToString()
                                       , telefone_ddd_numero.ToString()
                                                     );
                return SQL_POST;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


}

