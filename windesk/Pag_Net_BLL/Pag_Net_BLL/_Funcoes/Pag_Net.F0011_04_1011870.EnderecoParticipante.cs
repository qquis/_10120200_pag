using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Models;

namespace Pag_Net.Bll.F0011_04
{

    public static class RedShift
    {
        public static string get(
            DateTime data_inicial,
            DateTime data_final
            )
        {
            string SQL = "  select  pessoa_key                      as cdpessoabluesoft " + 
                         "      ,   cpf_cnpj                        as cpf_cnpj " + 
                         "      ,   cast(0 as int)                  as cdpessoa " + 
                         "      ,   cast(0 as int)                  as cdparticipante "  + 
                         "      ,   coalesce(cep,0)                 as endereco_cep "  +  
                         "      ,   coalesce(endereco_key,0)            as enderecobluesoft_cd "  + 
                         "      ,   coalesce(endereco_rua,'')            as endereco_logradouro "  + 
                         "      ,   coalesce(endereco_numero,'')         as endereco_numero "  +
                         "      ,   case when coalesce(endereco_complemento,'X') = '' then 'X'  ELSE coalesce(endereco_complemento,'X') END as endereco_complemento " + 
                         "      ,   coalesce(bairro, 'NAO INFORMADO')   as endereco_bairro "  + 
                         "      ,   coalesce(municipio_key,0)           as endereco_municipio_cd "  +
                         "      ,   coalesce(municipio, 'NAO INFORMADO')     as endereco_municipio  " + 
                         "      ,   coalesce(estado_sigla, 'SP')   as endereco_uf " +
                         "      ,   coalesce(latitude, 0.00)       as endereco_latitude " +
                         "      ,   coalesce(longitude, 0.00)      as endereco_longitude " + 
                         "  from    pessoa " +
                         "  WHERE   coalesce(endereco_rua,'')  != '' and pessoa_key > 0 " + 
                         "  ORDER BY pessoa_key ASC ";
               return SQL;
           }
       }

    public static class Postgres
    {



        public static string post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            string _SqlCommand,
            bool _Api,
            DataRow i

            )
        {
                return post( MyConnect,
                _SqlCommand,
                _Api,
                Convert.ToInt32(i["cdparticipante"]),
                i["cpf_cnpj"].ToString(),
                Convert.ToInt32(i["cdpessoabluesoft"]),
                Convert.ToInt32(i["cdpessoa"]),
                Convert.ToInt32(i["cdparticipante"]),
                Convert.ToInt32(i["endereco_cep"].ToString()),
                i["endereco_logradouro"].ToString(),
                i["endereco_bairro"].ToString(),
                i["endereco_numero"].ToString(),
                i["endereco_municipio"].ToString(),
                i["endereco_complemento"].ToString(),
                Convert.ToDouble(i["endereco_latitude"]),
                Convert.ToDouble(i["endereco_longitude"]),
                i["endereco_uf"].ToString()
            );
        }

        public static string post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            string _SqlCommand,
            bool _Api,
            
            int    cdparticipante       ,
            string cpf_cnpj             ,
            int    cdpessoabluesoft     ,
            int    cdpessoa             ,
            int    endereco_tipo_cd     ,
            int    endereco_cep		   ,
            string endereco_logradouro	,
            string endereco_bairro		,
            string endereco_numero		,
            string endereco_municipio 	,
            string endereco_complemento	,
            double endereco_latitude	,	
            double endereco_longitude	,
            string endereco_uf          
            
            
            
            )
        {


            

            try
            {

/*                if (item.cdpessoabluesoft == 0 && item.cdpessoa == 0 && item.cdparticipante == 0)
                {
                    throw new Exception("Referência não informada");
                }*/

                string SQL_POST = string.Format("SELECT " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0011_04) +
                                          "(   'DBINSERT' " +
                                          "  ,   {0}    " +
                                          "  ,  '{1}'  " +
                                          "  ,   {2}  " +
                                          "  ,   {3}  " +
                                          "  ,   {4}  " +
                                          "  ,   {5}  " +
                                          "  ,  '{6}' " +
                                          "  ,  '{7}' " +
                                          "  ,  '{8}' " +
                                          "  ,  '{9}'  " +
                                          "  ,  '{10}'  " +
                                          "  ,   {11}  " +
                                          "  ,   {12}  " +
                                          "  ,  '{13}')  ",

                                  cdparticipante.ToString()
                                , cpf_cnpj.ToString()
                                , cdpessoabluesoft == null ? "0": cdpessoabluesoft.ToString()
                                , cdpessoa == null? "0": cdpessoa.ToString()
                                , endereco_tipo_cd == null? "1": endereco_tipo_cd.ToString()
                                , endereco_cep == null? "0": endereco_cep.ToString().Replace("'", "")
                                , endereco_logradouro == null? "": endereco_logradouro.ToString().Replace("'", "")
                                , endereco_bairro == null? "": endereco_bairro.ToString().Replace("'", "")
                                , endereco_numero == null? "": endereco_numero.ToString().Replace("'", "")
                                , endereco_municipio == null? "": endereco_municipio.ToString().Replace("'", "")
                                , endereco_complemento == null? "": endereco_complemento.ToString().Replace("'", "")
                                , "0"
                                , "0"
                                , endereco_uf == null? "SP": endereco_uf.ToString().Replace("'", "")
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

