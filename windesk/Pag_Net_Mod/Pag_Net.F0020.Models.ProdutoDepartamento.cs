
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Models;
using Pag_Net.F0020;

namespace Pag_Net.F0020.Models
{
    public class produto_departamento
    {


        public int          prd_cddepartamento { get; set; }
		public string       prd_descricao	   {get;set;}
		

        public produto_departamento() { }
        public produto_departamento(DataRow i)
        {
            prd_cddepartamento = Convert.ToInt32(i["prd_cddepartamento"].ToString());
            prd_descricao = i["prd_descricao"].ToString();
        }
    }
}

namespace Pag_Net.F0020.Models.BD
{
    public static class Postgres
    {
        public static string CRUD(produto_departamento item, Pag_Net.Models.BDCommandTypes _Type)
        {
            return string.Format("SELECT f0020_crud_tbproduto_departamento ('{0}', {1}, '{2}', '{3}')",
                                             BDTools.SqlCommandType(_Type).ToString(),
                                             item.prd_cddepartamento,
                                             item.prd_descricao.Replace("'", ""),
                                             "false")



                ;
        }

   }

    public static class RedShift
    {
        public static string Select()
        {
            string SQL = "   select    departamento_key             as prd_cddepartamento " +
                         "           , departamento                 as prd_descricao " +
                         "   from      produto_d "+
                         "   where     departamento_key is not null " +
                         "   group by  departamento_key " +
                         "           , departamento " + 
                         "           order by 1  ";
            return SQL;
        }
    }

}

