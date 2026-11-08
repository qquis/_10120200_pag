
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Models;

namespace Pag_Net.SPP0015.Models
{
    public class ZanthusTabRegraICMS
    {

    }
    public class Parametros
    {

    }
}

namespace Pag_Net.SPP0015.Models.BD
{

	public static class SqlServer
	{
        public static string SqlProcedureName()
        {
            return "SPP0015_ZanthusTabRegraICMS";
        }
        public static ParameterQuey[] Fill(Pag_Net.Models.BDCommandTypes _Type)
        {
            string LinhaEmExecucao = "";
            try
            {
                List<ParameterQuey> SQLParametros = new List<ParameterQuey>();
                SQLParametros.Add(new ParameterQuey("SQLCommand", SqlDbType.VarChar, false, BDTools.SqlCommandType(_Type)));
                return SQLParametros.ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " | " + LinhaEmExecucao);
            }

        }
    }
}
