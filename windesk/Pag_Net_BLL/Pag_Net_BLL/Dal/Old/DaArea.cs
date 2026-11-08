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
    public static class DaArea
    {
        public static TbArea[] GetList(modelSistemaUsuario myconnect)
        {
            SqlParameter _SqlParameterCodigoArea = dalUtil.SqlParameterCreator(SqlDbType.Char, "cd_usr", myconnect.user_name, true);

            SqlCommand _SqlCommand = new SqlCommand("prArea");
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.Parameters.Add(_SqlParameterCodigoArea);

            dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbArea> _list = new List<TbArea>();

            while (_SqlDataReader.Read())
            {
                TbArea x = new TbArea(_SqlDataReader["CodigoArea"].ToString(), _SqlDataReader["DescricaoArea"].ToString());

                _list.Add(x);
            }
            _SqlDataReader.Close();
            return _list.ToArray();
        }
    }
}
