
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Models;
using Pag_Net.F0011;

namespace Pag_Net.F0011.Models
{
    public class PessoaBlueSoft
    {
        public int CdPessoaBlueSoft { get; set; }
        public string Nome_Razao { get; set; }
        public string Sexo { get; set; }
        public string CPF_CNPJ { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string email_main { get; set; }
        public double latitude { get; set;  }
        public double longitude { get; set; }


		public PessoaBlueSoft()
        {

        }

        public PessoaBlueSoft(System.Data.DataRow i)
        {
            string errorString = i["CdPessoaBlueSoft"].ToString();
            try
            {
                CdPessoaBlueSoft = Convert.ToInt32(i["CdPessoaBlueSoft"]);
                Nome_Razao = i["nome_razao"].ToString();
                Sexo = i["sexo"].ToString();
                CPF_CNPJ = i["cpf_cnpj"].ToString();
                Data_Nascimento = Convert.ToDateTime(i["data_nascimento"]);
                latitude = Convert.ToDouble(i["latitude"]);
                longitude = Convert.ToDouble(i["longitude"]);
                email_main = i["email_main"].ToString();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " | " + errorString);
            }
        }

	
    }

}

namespace Pag_Net.F0011.Models.BD
{
    public static class Postgres
    {
        public static string F0011_01PC_tbpessoabluesoft(PessoaBlueSoft item, Pag_Net.Models.BDCommandTypes _Type)
        {
            return "SELECT F0011_01PC_tbpessoabluesoft ('" + BDTools.SqlCommandType(_Type) + "', " +
                                                 item.CdPessoaBlueSoft + ", '" +
                                                 item.CPF_CNPJ + "', '" +
                                                 item.Nome_Razao.Replace("'", "´") + "', '" +
                                                 item.Sexo + "', '" +
                                                 item.Data_Nascimento.ToString("yyyy-MM-dd") + "', '" +
                                                 item.email_main.Replace("'","") + "', " +
                                                 item.latitude.ToString().Replace(",",".") +", " +
                                                 item.longitude.ToString().Replace(",", ".") + " ) "



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
                         "      , left(ISNULL(email_comercial, ''),60)       as email_main " + 
                         "      , ISNULL(latitude,0)                         as latitude " + 
                         "      , ISNULL(longitude,0)                        as longitude " + 
                         "        from pessoa ";
                         //"        where pessoa_key = 1 ";
            return SQL;
        }
    }

}
