
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Models;
using Pag_Net.F0025;

namespace Pag_Net.F0025.Models
{
    public class ProdutoBlueSoft_Composicao 
    {
       
        public int          prb_CdProdutoBlueSoft               {get;set;}
        public int          prb_CdProdutoBlueSoft_Unitario      {get;set;}
        public double       prbc_qtde                           {get;set;}
        public string       prbc_descricao                      {get;set;}
        public double       prbc_percentual_composicao          {get;set;}
        public int          prbc_bluesoft_seq { get; set; }
        public DateTime prbc_data { get; set; }

        public ProdutoBlueSoft_Composicao() { }
        public ProdutoBlueSoft_Composicao(DataRow i)
        {
            prb_CdProdutoBlueSoft = Convert.ToInt32(i["prb_CdProdutoBlueSoft"]);
            prb_CdProdutoBlueSoft_Unitario = Convert.ToInt32(i["prb_CdProdutoBlueSoft_Unitario"]);  
            prbc_qtde = Convert.ToDouble(i["prbc_qtde"]);  
            prbc_descricao = i["prbc_descricao"].ToString();
            prbc_percentual_composicao = Convert.ToDouble(i["prbc_percentual_composicao"].ToString());
            prbc_bluesoft_seq = Convert.ToInt32(i["prbc_bluesoft_seq"].ToString());
            prbc_data = Convert.ToDateTime(i["prbc_data"].ToString());   
        }
    }
}

namespace Pag_Net.F0025.Models.BD
{
    public static class Postgres
    {
        public static string f0025_crud_produtobluesfot_composicao(ProdutoBlueSoft_Composicao item, Pag_Net.Models.BDCommandTypes _Type)
        {
            return string.Format("SELECT f0025_crud_produtobluesfot_composicao ('{0}', {1}, {2}, {3}, '{4}', {5}, {6}, '{7}', '{8}')",
                                             BDTools.SqlCommandType(_Type).ToString(),
                                             item.prb_CdProdutoBlueSoft,
                                             item.prb_CdProdutoBlueSoft_Unitario,
                                             item.prbc_qtde.ToString().Replace(",", "."),
                                             item.prbc_descricao.Replace("'", ""),
                                             item.prbc_percentual_composicao.ToString().Replace(",","."),
                                             item.prbc_bluesoft_seq.ToString(),
                                             item.prbc_data.ToString("yyyy-MM-dd"),
                                             "false")



                ;
        }

   }

    public static class RedShift
    {
        public static string Select()
        {
            string SQL = "   select       produto_final                   as prb_cdprodutobluesoft_unitario  " +
                         "              , produto_parte                   as prb_cdprodutobluesoft           " +
                         "              , quantidade                      as prbc_qtde                       " +
                         "              , 'kits'                          as prbc_descricao                  " +
                         "              , percentual_do_item_na_compra    as prbc_percentual_composicao      " +
                         "              , composicao_key                  as prbc_bluesoft_seq               " +
                         "              , ultima_alteracao                as prbc_data                       " + 
                         "      from      composicao " +
                         "      where     1 = 1 " +
                         "        AND     ISNULL(percentual_do_item_na_compra, 0) > 0 ";
            /*
                         "      group by  produto_final  " +
                         "              , produto_parte " +
                         "              , quantidade " +
                         "              , percentual_do_item_na_compra ";*/
            return SQL;
        }
    }

}

