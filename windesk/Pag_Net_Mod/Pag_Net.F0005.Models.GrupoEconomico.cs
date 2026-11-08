
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Models;
using Pag_Net.F0005.Models;

namespace Pag_Net.F0005.Models
{
    public class GrupoEconomico
    {
        public int      cdgrupoeconomico				{ get; set; }
		public string   descricao					    { get; set; }
		public string   descricaoresumida			    { get; set; }
		public string   Referencia					    { get; set; }
        public bool     grupoeconomicostatus            { get; set; }


		public GrupoEconomico()
        {

        }

        public GrupoEconomico(System.Data.DataRow i)
        {
            string errorString = i[0].ToString();
            try
            {

                grupoeconomicostatus = false;
                descricao = " - Grupo SEM DESCRIÇÃO - ";
                descricaoresumida = "";
                Referencia = "";

                cdgrupoeconomico = Convert.ToInt32(i["cdgrupoeconomico"]);
                descricao = i["descricao"].ToString();
                /*descricaoresumida = i["descricaoresumida"].ToString();*/
                /*Referencia = i["Referencia"].ToString();*/
                grupoeconomicostatus = Convert.ToBoolean(i["grupoeconomicostatus"]);
              
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " | " + errorString);
            }
        }

	
    }

}

namespace Pag_Net.F0005.Models.BD
{
    public static class Postgres
    {
        public static string F0005_01PC_tbgrupoeconomico(GrupoEconomico item, Pag_Net.Models.BDCommandTypes _Type)
        {
            return "SELECT F0005_01PC_tbgrupoeconomico ('" + BDTools.SqlCommandType(_Type) + "', " +
                                                 item.cdgrupoeconomico + ", '" +
                                                 item.descricao.Replace("'", "´") + "', '" +
                                                 item.descricaoresumida.Replace("'", "´") + "', '" +
                                                 item.Referencia.Replace("'", "´") + "', '" +
                                                 Convert.ToString(item.grupoeconomicostatus ? "1" : "0") + "')";




                ;
        }

   }

    public static class RedShift
    {
        public static string Select()
        {
            string SQL = " select   grupo_economico_key         cdgrupoeconomico " + 
                         "    ,     left(descricao,80)          descricao        " +
                         "    ,     isnull(status,0)            grupoeconomicostatus" + 
                         " from     grupo_economico";
            return SQL;
        }
    }

}
