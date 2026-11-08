
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Models;
//using Pag_Net.F0021;

namespace Pag_Net.F0026.Models
{
    public class ProdutoBlueSoft_Fornecedor
    {

        public int prbf_seq { get; set; }
       public int prb_CdProdutoBlueSoft {get;set;}
       public int prbf_cdpessoabluesoft {get;set;}
       public int prbf_divisao_seq {get;set;}
       public string prbf_codigo_referencia {get;set;}
       public double prbf_fator_estoque {get;set;}
       public string prbf_descricao {get;set;}



        public ProdutoBlueSoft_Fornecedor() { }
        public ProdutoBlueSoft_Fornecedor(DataRow i)
        {
            prbf_seq =  Convert.ToInt32(i["prbf_seq"].ToString());
            prb_CdProdutoBlueSoft = Convert.ToInt32(i["prb_CdProdutoBlueSoft"].ToString());
            prbf_cdpessoabluesoft = Convert.ToInt32(i["prbf_cdpessoabluesoft"].ToString());
            prbf_divisao_seq = Convert.ToInt32(i["prbf_divisao_seq"].ToString());
            prbf_codigo_referencia = i["prbf_codigo_referencia"].ToString();
            prbf_fator_estoque = Convert.ToDouble(i["prbf_fator_estoque"]);
            prbf_descricao = i["prbf_descricao"].ToString();



            //dtupdate_from_api = Convert.ToDateTime(i["dtupdate_from_api"].ToString());
            //dtlog_insert = Convert.ToDateTime(i["dtlog_insert"].ToString());
            //dtlog_update = Convert.ToDateTime(i["dtlog_update"].ToString());
        }
    }
}

namespace Pag_Net.F0026.Models.BD
{
    public static class Postgres
    {
        public static string CRUD(ProdutoBlueSoft_Fornecedor item, Pag_Net.Models.BDCommandTypes _Type)
        {
            return string.Format("SELECT f0026_crud_produtobluesfot_fornecedor ('{0}', {1}, {2}, {3}, {4}, '{5}', {6}, '{7}', '{8}') ",
                                             BDTools.SqlCommandType(_Type).ToString(),
                                             item.prbf_seq,
                                             item.prb_CdProdutoBlueSoft,
                                             item.prbf_cdpessoabluesoft,
                                             item.prbf_divisao_seq,
                                             item.prbf_codigo_referencia.Replace("'", ""),
                                             item.prbf_fator_estoque.ToString("0.00").Replace(",", "."),
                                             item.prbf_descricao.Replace("'",""), 
                                             "false")

                ;
        }

   }

    public static class RedShift
    {
        public static string Select()
        {
            string SQL = " SELECT      FORNECEDOR_PRODUTO_KEY                  AS prbf_seq " + 
                         "         ,   ISNULL(PRODUTO_KEY,0)                   AS prb_CdProdutoBlueSoft " + 
                         "         ,   ISNULL(FORNECEDOR_KEY,0)                AS prbf_cdpessoabluesoft " + 
                         "         ,   ISNULL(DIVISAO_KEY,0)                   AS prbf_divisao_seq " + 
                         "         ,   ISNULL(CODIGO_REFERENCIA,'')            AS prbf_codigo_referencia " + 
                         "         ,   ISNULL(FATOR_FATURAMENTO_FORNECEDOR,1)  AS prbf_fator_estoque " + 
                         "         ,   ISNULL(DESCRICAO_NF,'')                 AS prbf_descricao " +
                         " FROM        FORNECEDOR_PRODUTO " + 
                         " WHERE       ISNULL(PRODUTO_KEY,0) > 0 ";
            return SQL;




        }
    }

}
