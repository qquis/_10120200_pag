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
    public static class DaEquipeRepositor
    {
        public static TbEquipeRepositor[] GetList(ModelSysUserInfo myconnect)
        {
            SqlCommand _SqlCommand = new SqlCommand("PrEquipeRepositor");
            _SqlCommand.CommandType = CommandType.StoredProcedure;

            dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();
            List<TbEquipeRepositor> _list = new List<TbEquipeRepositor>();
            while (_SqlDataReader.Read())
            {
                TbEquipeRepositor x = new TbEquipeRepositor(Convert.ToInt32(_SqlDataReader["CodigoEquipeRepositor"].ToString()), _SqlDataReader["DescricaoEquipeRepositor"].ToString());
                _list.Add(x);
            }
            _SqlDataReader.Close();
            return _list.ToArray();
        }
    }
}
