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
    public static class DaAutorizadorFinanceiro
    {
        public static TbAutorizadorFinanceiro[] Select(ModelSysUserInfo _myConnect)
        {
            SqlCommand _SqlCommandInsert = new SqlCommand("PrAutorizadorFinanceiro");
            _SqlCommandInsert.CommandType = CommandType.StoredProcedure;
            dalConnectX _dalConnectX = new dalConnectX(_myConnect, DataBaseName.DBAMAINADM, _SqlCommandInsert, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();
            List<TbAutorizadorFinanceiro> _list = new List<TbAutorizadorFinanceiro>();
            while (_SqlDataReader.Read())
            {
                TbAutorizadorFinanceiro x = new TbAutorizadorFinanceiro();
                x.CdAutorizadorFinanceiro = _SqlDataReader["CdAutorizadorFinanceiro"].ToString();
                x.DescricaoAutorizadorFinanceiro= _SqlDataReader["Descricao"].ToString();
                _list.Add(x);
            }
            return _list.ToArray();
        }
    }
}
