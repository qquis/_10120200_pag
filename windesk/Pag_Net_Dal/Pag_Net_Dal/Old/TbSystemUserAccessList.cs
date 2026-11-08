using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Xml;
using System.IO;
using System.Linq;
using Pag_Net.Models;
using Pag_Net.Dal;
using System.Reflection;

namespace Pag_Net.Dal
{
    public class tbSystemUserAccessList
    {

        public string SystemId { get; set; }
        public string UserId { get; set; }
        public tbSystemUserAccessList(string _SystemId, string _UserId)
        {
            this.SystemId = _SystemId;
            this.UserId = _UserId;
        }

        public List<string> AccessList()
        {
            if (UserId != null && SystemId != null)
            {
                string sConexao = "";
                dalConnect dataConexao = new dalConnect();
                dataConexao.UserId = UserId.ToUpper().Trim();
                sConexao = dataConexao.StringConnection(dalConnect.dataBase.Oxan_Sis);
                SqlConnection dataSqlConnection = new SqlConnection(sConexao);

                SqlCommand dataSqlCommand = new SqlCommand("p_oxan_sis_0002");
                dataSqlCommand.CommandType = CommandType.StoredProcedure;
                dataSqlCommand.Parameters.AddWithValue("SISTEMA", SystemId);
                dataSqlCommand.Parameters.AddWithValue("cd_usr", UserId);
                dataSqlCommand.Connection = dataSqlConnection;

                //DataSet

                DataSet AcessosDataSet = new DataSet();
                SqlDataAdapter AcessosSqlDataAdapter = new SqlDataAdapter(dataSqlCommand);
                AcessosSqlDataAdapter.Fill(AcessosDataSet);
                AcessosSqlDataAdapter.Dispose();
                dataSqlCommand.Dispose();
                dataSqlConnection.Close();

                //Lendo AccessList

                List<string> lista_acessos = new List<string>();
                int i = 0;
                for (i = 0; i <= AcessosDataSet.Tables[0].Rows.Count - 1; i++)
                {
                    lista_acessos.Add(AcessosDataSet.Tables[0].Rows[i][0].ToString());
                }
                AcessosDataSet.Dispose();

                return lista_acessos;



            }
            else
            {
                return null;
            }


        }



    }
}
