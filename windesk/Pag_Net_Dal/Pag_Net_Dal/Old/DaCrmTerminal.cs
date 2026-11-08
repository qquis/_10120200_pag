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
    public class DaCrmTerminal
    {
        private SqlParameter _sqlparameterCep;
        private SqlParameter _sqlparameterObservacaoCritica;
        private SqlParameter _sqlparameterProdutoNaoEncontrado;
        private ModelSysUserInfo MyConnect;
        public DaCrmTerminal(ModelSysUserInfo myConnect)
        {
            MyConnect = myConnect;
            _sqlparameterCep = new SqlParameter("Cep", SqlDbType.VarChar); _sqlparameterCep.IsNullable = true;
            _sqlparameterObservacaoCritica = new SqlParameter("ObservacaoCritica", SqlDbType.Text); _sqlparameterObservacaoCritica.IsNullable = true;
            _sqlparameterProdutoNaoEncontrado = new SqlParameter("ProdutoNaoEncontrado", SqlDbType.VarChar); _sqlparameterProdutoNaoEncontrado.IsNullable = true;
        }
        public int Insert(TbCrmTerminal regModelTbCrmTerminal)
        {
            SqlCommand SqlCommandCrmTerminal = new SqlCommand("PrCrmTerminal");
            SqlCommandCrmTerminal.CommandType = CommandType.StoredProcedure;
            _sqlparameterCep.Value = dalfunctions.DataValue(regModelTbCrmTerminal.Cep);
            _sqlparameterObservacaoCritica.Value = dalfunctions.DataValue(regModelTbCrmTerminal.ObservacaoCritica);
            _sqlparameterProdutoNaoEncontrado.Value = dalfunctions.DataValue(regModelTbCrmTerminal.ProdutoNaoEncontrado.ToString());
            SqlCommandCrmTerminal.Parameters.Add(_sqlparameterCep);
            SqlCommandCrmTerminal.Parameters.Add(_sqlparameterObservacaoCritica);
            SqlCommandCrmTerminal.Parameters.Add(_sqlparameterProdutoNaoEncontrado);
            dalConnectX dalConnectXCrmTerminal = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, SqlCommandCrmTerminal, IsolationLevel.Unspecified);
            return dalConnectXCrmTerminal.SqlExecuteCommandClosed();
        }
    }
}
