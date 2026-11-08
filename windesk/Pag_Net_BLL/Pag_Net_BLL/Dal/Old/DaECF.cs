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
    public static class DaECF
    {
        public static TbECF[] GetList(modelSistemaUsuario myconnect)
        {
            SqlCommand _SqlCommand = new SqlCommand("prECF");
            _SqlCommand.CommandType = CommandType.StoredProcedure;



            dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbECF> _list = new List<TbECF>();

            while (_SqlDataReader.Read())
            {
                TbECF x = new TbECF(Convert.ToInt32(_SqlDataReader["ECF"].ToString()));

                _list.Add(x);

            }
            _SqlDataReader.Close();
            return _list.ToArray();
        }
    }
}
