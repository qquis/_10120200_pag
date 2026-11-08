
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Models;

namespace Pag_Net.SPC0010.Models
{
    public class Pessoa 
    {
        public int CdPessoa { get; set; }
        public int CdPessoaBlueSoft { get; set; }
        public string Nome_Razao { get; set; }
        public string Sexo { get; set; }
        public string CPF_CNPJ { get; set; }
        public DateTime Data_Nascimento { get; set; }
		public Pessoa()
        {

        }

        public Pessoa(System.Data.DataRow i)
        {
            string errorString = i["CdPessoaBlueSoft"].ToString();
            try
            {
                CdPessoa = 0; 
                CdPessoaBlueSoft = Convert.ToInt32(i["CdPessoaBlueSoft"]);
                Nome_Razao = i["nome_razao"].ToString();
                Sexo = i["sexo"].ToString();
                CPF_CNPJ = i["cpf_cnpj"].ToString();
                Data_Nascimento = Convert.ToDateTime(i["data_nascimento"]);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " | " + errorString);
            }
        }

	
    }

}

namespace Pag_Net.SPC0010.Models.BD
{
    public static class Postgres
    {
        public static string SqlExecute(Pag_Net.SPC0010.Models.Pessoa item, Pag_Net.Models.BDCommandTypes _Type)
        {

            

            return "SELECT SPC0010TbPessoa ('" + BDTools.SqlCommandType(_Type) + "', '" + 
                                                 item.Nome_Razao.Replace("'","´") + "', '" + 
                                                 item.Sexo + "', '" + 
                                                 item.Data_Nascimento.ToString("yyyy-MM-dd") + "', '" + 
                                                 item.CPF_CNPJ + "')"

                ;
        }

   }

    public static class RedShift
    {
        public static string Select()
        {
            string SQL = " select pessoa_key                                 as cdpessoabluesoft" +
                         "      , isnull(nome_razao,'SEM IDENTIFICACAO')     as nome_razao" +
                         "      , cpf_cnpj                                   as cpf_cnpj " +
                         "      , ISNULL(sexo,'M')                           as sexo " +
                         "      , ISNULL(data_nascimento, '1900-01-01')      as data_nascimento " +
                         "        from pessoa ";
                         //"        where pessoa_key = 1 ";
            return SQL;
        }
    }

}