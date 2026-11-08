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
    public static class DaLinha
    {
        public static TbLinha[] GetList(modelSistemaUsuario myconnect, Int32 _cdDepto, int _cdSecao)
        {
            SqlCommand _SqlCommand = new SqlCommand("prLinha");
            _SqlCommand.CommandType = CommandType.StoredProcedure;

            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "cddepartamento", _cdDepto, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "cdsecao", _cdSecao, true, _SqlCommand);


            dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbLinha> _list = new List<TbLinha>();

            while (_SqlDataReader.Read())
            {
                TbLinha x = new TbLinha(Convert.ToInt32(_SqlDataReader["CodigoLinha"].ToString()), _SqlDataReader["DescricaoLinha"].ToString());

                _list.Add(x);

            }
            _SqlDataReader.Close();
            return _list.ToArray();
        }
    }
}
