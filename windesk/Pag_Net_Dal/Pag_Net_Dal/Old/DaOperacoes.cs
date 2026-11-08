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
    public static class DaOperacoes
    {
        public static TbOperacoes[] GetList(ModelSysUserInfo myconnect, int _CdEmpresa)
        {
            SqlCommand _SqlCommand = new SqlCommand("prOperacoes");
            _SqlCommand.CommandType = CommandType.StoredProcedure;

            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdEmpresa", _CdEmpresa, true, _SqlCommand);



            dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbOperacoes> _list = new List<TbOperacoes>();

            while (_SqlDataReader.Read())
            {
                TbOperacoes x = new TbOperacoes(Convert.ToInt32(_SqlDataReader["CdOperacao"].ToString()), _SqlDataReader["DescricaoOperacao"].ToString(), Convert.ToInt32(_SqlDataReader["CdEmpresa"].ToString()));
                _list.Add(x);

            }
            _SqlDataReader.Close();
            return _list.ToArray();

        }
    }
}
