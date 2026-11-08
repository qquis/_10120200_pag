
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Models;
using Pag_Net.F0017;

namespace Pag_Net.F0017.Models
{
    public class produto_subgrupo
    {


        public int          prsg_cdsubgrupo		                {get;set;}
		public string       prsg_descricao		                {get;set;}
		public int          prg_cdgrupo			                {get;set;}		

        public produto_subgrupo() { }
        public produto_subgrupo(DataRow i)
        {
            prsg_cdsubgrupo = Convert.ToInt32(i["prsg_cdsubgrupo"].ToString());
            prsg_descricao = i["prsg_descricao"].ToString();
            prg_cdgrupo = Convert.ToInt32(i["prg_cdgrupo"].ToString());
            


           
        }
    }
}

namespace Pag_Net.F0017.Models.BD
{
    public static class Postgres
    {
        public static string CRUD(produto_subgrupo item, Pag_Net.Models.BDCommandTypes _Type)
        {
            return string.Format("SELECT f0017_crud_tbproduto_subgrupo ('{0}', {1}, '{2}', {3}, '{4}')",
                                             BDTools.SqlCommandType(_Type).ToString(),
                                             item.prsg_cdsubgrupo,
                                             item.prsg_descricao.Replace("'", ""),
                                             item.prg_cdgrupo,
                                             "false")



                ;
        }

   }

    public static class RedShift
    {
        public static string Select()
        {
            string SQL = "   select    sub_grupo_produto_key         as prsg_cdsubgrupo " +
                         "           , subgrupo                      as prsg_descricao " +
                         "           , grupo_produto_key             as prg_cdgrupo " +
                         "   from      produto_d "+ 
                         "   where     sub_grupo_produto_key is not null " +
                         "   group by  sub_grupo_produto_key " +
                         "           , subgrupo " + 
                         "           , grupo_produto_key " + 
                         "           order by 1  ";
            return SQL;
        }
    }

}

