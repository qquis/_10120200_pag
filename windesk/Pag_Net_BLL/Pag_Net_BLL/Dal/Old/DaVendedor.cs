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
    public static class DaVendedor
    {
        public static TbVendedor[] GetList(modelSistemaUsuario myconnect)
        {
            SqlParameter _SqlParameterCodigoVendedor = dalUtil.SqlParameterCreator(SqlDbType.Char, "cd_usr", myconnect.user_name, true);

            SqlCommand _SqlCommand = new SqlCommand("prVendedor");
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.Parameters.Add(_SqlParameterCodigoVendedor);

            dalConnectX _daConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _daConnectX.SqlDataReader_Select();

            List<TbVendedor> _list = new List<TbVendedor>();

            while (_SqlDataReader.Read())
            {
                TbVendedor x = new TbVendedor(Convert.ToInt32(_SqlDataReader["CodigoVendedor"].ToString()), _SqlDataReader["NomeVendedor"].ToString(), _SqlDataReader["cderpvendedor"].ToString());

                _list.Add(x);
            }
            _SqlDataReader.Close();
            return _list.ToArray();
        }
    }
}
