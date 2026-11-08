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
    public static class DaDepartamento
    {
        public static TbDepartamento[] GetList(ModelSysUserInfo myconnect)
        {
            SqlCommand _SqlCommand = new SqlCommand("prDepartamento");
            _SqlCommand.CommandType = CommandType.StoredProcedure;

            dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbDepartamento> _list = new List<TbDepartamento>();

            while (_SqlDataReader.Read())
            {
                TbDepartamento x = new TbDepartamento(Convert.ToInt32(_SqlDataReader["CodigoDepartamento"].ToString()), _SqlDataReader["DescricaoDepartamento"].ToString());

                _list.Add(x);
            }
            _SqlDataReader.Close();
            return _list.ToArray();
        }
    }
}
