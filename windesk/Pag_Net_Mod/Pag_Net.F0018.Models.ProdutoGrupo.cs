
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Models;
using Pag_Net.F0018;

namespace Pag_Net.F0018.Models
{
    public class produto_grupo
    {


        public int          prg_cdgrupo	    	                {get;set;}
		public string       prg_descricao		                {get;set;}
		public int          prs_cdsecao			                {get;set;}		

        public produto_grupo() { }
        public produto_grupo(DataRow i)
        {
            prg_cdgrupo = Convert.ToInt32(i["prg_cdgrupo"].ToString());
            prg_descricao = i["prg_descricao"].ToString();
            prs_cdsecao = Convert.ToInt32(i["prs_cdsecao"].ToString());
            


           
        }
    }
}

namespace Pag_Net.F0018.Models.BD
{
    public static class Postgres
    {
        public static string CRUD(produto_grupo item, Pag_Net.Models.BDCommandTypes _Type)
        {
            return string.Format("SELECT f0018_crud_tbproduto_grupo ('{0}', {1}, '{2}', {3}, '{4}')",
                                             BDTools.SqlCommandType(_Type).ToString(),
                                             item.prg_cdgrupo,
                                             item.prg_descricao.Replace("'", ""),
                                             item.prs_cdsecao,
                                             "false")



                ;
        }

   }

    public static class RedShift
    {
        public static string Select()
        {
            string SQL = "   select    grupo_produto_key             as prg_cdgrupo " +
                         "           , grupo                         as prg_descricao " +
                         "           , secao_key                     as prs_cdsecao " +
                         "   from      produto_d "+ 
                         "   where     sub_grupo_produto_key is not null " +
                         "   group by  grupo_produto_key " +
                         "           , grupo " +
                         "           , secao_key " + 
                         "           order by 1  ";
            return SQL;
        }
    }

}

