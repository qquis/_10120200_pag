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
    public static class DaDepartamentoSecaoLinha
    {
        public static TbDeptoSecaoLinha[] GetList(ModelSysUserInfo myconnect)
        {
            SqlCommand _SqlCommand = new SqlCommand("prDeptoSecaoLinha");
            _SqlCommand.CommandType = CommandType.StoredProcedure;


            dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbDeptoSecaoLinha> _list = new List<TbDeptoSecaoLinha>();

            while (_SqlDataReader.Read())
            {
                TbDeptoSecaoLinha x = new TbDeptoSecaoLinha(Convert.ToInt32(_SqlDataReader["CdDepartamento"].ToString()), Convert.ToInt32(_SqlDataReader["CdSecao"].ToString()), Convert.ToInt32(_SqlDataReader["CdLinha"].ToString()), _SqlDataReader["DescricaoDepartamento"].ToString(), _SqlDataReader["DescricaoSecao"].ToString(), _SqlDataReader["DescricaoLinha"].ToString());

                _list.Add(x);

            }
            _SqlDataReader.Close();
            return _list.ToArray();
        }
    }
}
