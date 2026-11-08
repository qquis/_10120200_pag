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
    public static class DaOperadores
    {
        public static TbOperadores[] GetList(ModelSysUserInfo myconnect)
        {
            SqlCommand _SqlCommand = new SqlCommand("prOperadores");
            _SqlCommand.CommandType = CommandType.StoredProcedure;



            dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbOperadores> _list = new List<TbOperadores>();

            while (_SqlDataReader.Read())
            {
                TbOperadores x = new TbOperadores(Convert.ToInt32(_SqlDataReader["Cdoperador"].ToString()), _SqlDataReader["NomeOperador"].ToString());

                _list.Add(x);

            }
            _SqlDataReader.Close();
            return _list.ToArray();
        }
    }
}
