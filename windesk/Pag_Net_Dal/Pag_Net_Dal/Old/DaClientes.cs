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
    public class DaClientes
    {
        private ModelSysUserInfo MyConnect;
        public DaClientes(ModelSysUserInfo myConnect)
        {
            MyConnect = myConnect;
        }
        public TbClientes[] GetList(int cd_clien)
        {
            return GetList(cd_clien, string.Empty, Convert.ToDateTime("17/11/2011"), Convert.ToDateTime("17/11/2011"));
        }
        public TbClientes[] GetList(int cd_clien, string nome)
        {
            return GetList(cd_clien, nome, Convert.ToDateTime("17/11/2011"), Convert.ToDateTime("17/11/2011"));
        }
        public TbClientes[] GetList(int cd_clien, string nome, DateTime dtcad_ini, DateTime dtcad_fim)
        {
            //string tipoProcesso = "SELECT";

            SqlCommand SqlCommandTbClientes = new SqlCommand("prCliente");
            SqlCommandTbClientes.CommandType = CommandType.StoredProcedure;
            SqlCommandTbClientes.Parameters.AddWithValue("@cd_clien", cd_clien);




            dalConnectX dalConnectXTbClientes = new dalConnectX(MyConnect, DataBaseName.DATABASE_MIN, SqlCommandTbClientes, IsolationLevel.Unspecified);

            SqlDataReader sqlDataReaderTbClientes = dalConnectXTbClientes.SqlDataReader_Select();
            List<TbClientes> listModelClientes = new List<TbClientes>();

            while (sqlDataReaderTbClientes.Read())
            {
                listModelClientes.Add(new TbClientes(sqlDataReaderTbClientes["cd_clien"].ToString(),
                                                           sqlDataReaderTbClientes["nome"].ToString()));
            }

            sqlDataReaderTbClientes.Close();
            return listModelClientes.ToArray();


        }
    }
}
