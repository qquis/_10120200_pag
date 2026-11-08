using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Bll;



namespace Pag_Net.Bll.F0060_03
{
    public static class Postgres
    {

        public static string post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            string _SqlCommand,
            bool _Api,
            Db item)
        {
            string SQL_COMMAND =  string.Format("SELECT " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0060_03) + " (	    " +
                                   "           'DBINSERT'        " +
                                   "       ,     {0}             " +
                                   "       ,    '{1}'            " +
                                   "       ,    '{2}'            " +
                                   "       ,    '{3}'            " +
                                   "       ,    '{4}'            " +
                                   "       ,     {5}             " +
                                   "       ,     {6}             )",
                                   item.dfr_nf_numero,
                                   item.dfr_nf_serie,
                                   item.dfr_nf_data_emissao.ToString("yyy-MM-dd"),
                                   item.dfr_chave,
                                   item.dfr_cnpj_cpf,
                                   item.df_seq,
                                   item.entrada_saida_seq
              );
            return SQL_COMMAND;

        }



    }
    public class Db
    {
        public int dfr_nf_numero { get; set; }
        public int dfr_nf_serie { get; set; }
        public string dfr_chave { get; set; }
        public string dfr_cnpj_cpf { get; set; }
        public int df_seq { get; set; }
        public int entrada_saida_seq { get; set; }
        public DateTime dfr_nf_data_emissao { get; set; }

        public Db() { }

        public Db(

             int _dfr_nf_numero
         , int _dfr_nf_serie
         , string _dfr_chave
         , string _dfr_cnpj_cpf
         , int _df_seq
         , int _entrada_saida_seq
          , DateTime _dfr_nf_data_emissao
           )
        {

            dfr_nf_numero = _dfr_nf_numero;
            dfr_nf_serie = _dfr_nf_serie;
            dfr_chave = _dfr_chave;
            dfr_cnpj_cpf = _dfr_cnpj_cpf;
            df_seq = _df_seq;
            entrada_saida_seq = _entrada_saida_seq;
            dfr_nf_data_emissao = _dfr_nf_data_emissao;
        }


        public Db(DataRow i)
        {
            df_seq = Convert.ToInt32(i["df_seq"].ToString());
            dfr_nf_serie = Convert.ToInt32(i["dfr_nf_serie"].ToString());
            dfr_nf_numero = Convert.ToInt32(i["dfr_nf_numero"].ToString());
            dfr_chave = i["dfr_chave"].ToString();
            dfr_cnpj_cpf = i["dfr_cnpj_cpf"].ToString();
            entrada_saida_seq = Convert.ToInt32(i["entrada_saida_seq"].ToString());
            dfr_nf_data_emissao = Convert.ToDateTime(i["dfr_nf_data_emissao"].ToString());
        }
    }
}


