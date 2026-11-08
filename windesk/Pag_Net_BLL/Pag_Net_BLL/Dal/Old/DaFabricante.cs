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
    public static class DaFabricante
    {
        public static TbFabricante[] GetList(modelSistemaUsuario myconnect)
        {

            SqlParameter _SqlParameterCodigoUsuario = dalUtil.SqlParameterCreator(SqlDbType.Char, "cd_usr", myconnect.user_name, true);


            SqlCommand _SqlCommand = new SqlCommand("prFabricante");
            _SqlCommand.CommandType = CommandType.StoredProcedure;

            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "cd_usr", myconnect.user_name, true, _SqlCommand);

            dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbFabricante> _list = new List<TbFabricante>();

            while (_SqlDataReader.Read())
            {
                TbFabricante x = new TbFabricante(Convert.ToInt32(_SqlDataReader["CodigoFabricante"].ToString()), _SqlDataReader["DescricaoFabricante"].ToString());

                _list.Add(x);
            }
            _SqlDataReader.Close();
            return _list.ToArray();
        }
    }
}
