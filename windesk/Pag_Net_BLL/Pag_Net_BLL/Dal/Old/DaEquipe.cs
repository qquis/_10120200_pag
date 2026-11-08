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
    public static class DaEquipe
    {
        public static TbEquipe[] GetList(modelSistemaUsuario myconnect)
        {
            SqlParameter _SqlParameterCodigoEquipe = dalUtil.SqlParameterCreator(SqlDbType.Char, "cd_usr", myconnect.user_name, true);

            SqlCommand _SqlCommand = new SqlCommand("prEquipe");
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.Parameters.Add(_SqlParameterCodigoEquipe);

            dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbEquipe> _list = new List<TbEquipe>();

            while (_SqlDataReader.Read())
            {
                TbEquipe x = new TbEquipe(Convert.ToInt32(_SqlDataReader["CodigoEquipe"].ToString()), _SqlDataReader["DescricaoEquipe"].ToString());

                _list.Add(x);
            }
            _SqlDataReader.Close();
            return _list.ToArray();
        }
    }
}
