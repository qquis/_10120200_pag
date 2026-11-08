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
    public static class DaSecao
    {
        public static TbSecao[] GetList(ModelSysUserInfo myconnect, int _cdDepto)
        {
            SqlCommand _SqlCommand = new SqlCommand("prSecao");
            _SqlCommand.CommandType = CommandType.StoredProcedure;

            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "cddepartamento", _cdDepto, true, _SqlCommand);

            dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbSecao> _list = new List<TbSecao>();

            while (_SqlDataReader.Read())
            {
                TbSecao x = new TbSecao(Convert.ToInt32(_SqlDataReader["CodigoSecao"].ToString()), _SqlDataReader["DescricaoSecao"].ToString());

                _list.Add(x);

            }
            _SqlDataReader.Close();
            return _list.ToArray();
        }
    }
}
