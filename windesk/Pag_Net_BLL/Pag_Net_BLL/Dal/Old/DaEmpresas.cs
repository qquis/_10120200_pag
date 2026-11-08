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
    public static class DaEmpresas
    {
        public static TbEmpresas[] GetList(modelSistemaUsuario myconnect)
        {
            SqlCommand _SqlCommand = new SqlCommand("prEmpresas ");
            _SqlCommand.CommandType = CommandType.StoredProcedure;

            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "cd_usr", myconnect.user_name, true, _SqlCommand);

            dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbEmpresas> _list = new List<TbEmpresas>();

            while (_SqlDataReader.Read())
            {
                TbEmpresas x = new TbEmpresas(_SqlDataReader["DescricaoEmpresa"].ToString());
                x.CdEmpresa = Convert.ToInt32(_SqlDataReader["CdEmpresa"].ToString());
                _list.Add(x);

            }
            _SqlDataReader.Close();
            return _list.ToArray();
        }
    }
}
