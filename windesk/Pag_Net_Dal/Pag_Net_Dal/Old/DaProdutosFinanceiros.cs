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
    public static class DaProdutosFinanceiros
    {
        public static TbProdutosFinanceiros[] Select(ModelSysUserInfo _myConnect)
        {
            SqlCommand _SqlCommandInsert = new SqlCommand("PrProdutoFinanceiro");
            _SqlCommandInsert.CommandType = CommandType.StoredProcedure;
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "TipoProcessamento", "SELECT", true, _SqlCommandInsert);
            dalConnectX _dalConnectX = new dalConnectX(_myConnect, DataBaseName.DBAMAINADM, _SqlCommandInsert, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();
            List<TbProdutosFinanceiros> _list = new List<TbProdutosFinanceiros>();
            while (_SqlDataReader.Read())
            {
                TbProdutosFinanceiros x = new TbProdutosFinanceiros();
                x.SeqProdutoFinanceiro = Convert.ToInt32(_SqlDataReader["SeqProdutoFinanceiro"].ToString());
                x.DescricaoProdutoFinanceiro = _SqlDataReader["DescricaoProdutoFinanceiro"].ToString();
                x.CdProdutoFinanceiro = _SqlDataReader["CdProdutoFinanceiro"].ToString();
                _list.Add(x);
            }
            return _list.ToArray();
        }
    }
}
