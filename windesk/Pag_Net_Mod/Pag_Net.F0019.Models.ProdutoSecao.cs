
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Models;
using Pag_Net.F0019;

namespace Pag_Net.F0019.Models
{
    public class produto_secao
    {


        public int          prs_cdsecao 		                {get;set;}
		public string       prs_descricao		                {get;set;}
		public int          prd_cddepartamento	                {get;set;}

        public produto_secao() { }
        public produto_secao(DataRow i)
        {
            prs_cdsecao = Convert.ToInt32(i["prs_cdsecao"].ToString());
            prs_descricao = i["prs_descricao"].ToString();
            prd_cddepartamento = Convert.ToInt32(i["prd_cddepartamento"].ToString());
        }
    }
}

namespace Pag_Net.F0019.Models.BD
{
    public static class Postgres
    {
        public static string CRUD(produto_secao item, Pag_Net.Models.BDCommandTypes _Type)
        {
            return string.Format("SELECT f0019_crud_tbproduto_secao ('{0}', {1}, '{2}', {3}, '{4}')",
                                             BDTools.SqlCommandType(_Type).ToString(),
                                             item.prs_cdsecao,
                                             item.prs_descricao.Replace("'", ""),
                                             item.prd_cddepartamento,
                                             "false")



                ;
        }

   }

    public static class RedShift
    {
        public static string Select()
        {
            string SQL = "   select    secao_key                    as prs_cdsecao " +
                         "           , secao                        as prs_descricao " +
                         "           , departamento_key             as prd_cddepartamento " +
                         "   from      produto_d "+
                         "   where     secao_key is not null " +
                         "   group by  secao_key " +
                         "           , secao " +
                         "           , departamento_key " + 
                         "           order by 1  ";
            return SQL;
        }
    }

}

