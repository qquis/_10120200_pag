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
    public class DaSisFuncao
    {
        private ModelSysUserInfo MyConnect;
        public DaSisFuncao(ModelSysUserInfo myConnect)
        {
            MyConnect = myConnect;
        }
        public ModelTbSisFuncao[] GetList
            (
                string _Descricao
            )
        {
            SqlParameter _SqlParameterDescricao = new SqlParameter("descricao", _Descricao.ToString());

            SqlCommand _SqlCommand = new SqlCommand("prsisfuncao");
            _SqlCommand.Parameters.Add(_SqlParameterDescricao);

            _SqlCommand.CommandType = CommandType.StoredProcedure;
            dalConnectX _dalConnectX = new dalConnectX(MyConnect, DataBaseName.DATABASE_AUT, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _sqlDataReader = _dalConnectX.SqlDataReader_Select();
            List<ModelTbSisFuncao> _list = new List<ModelTbSisFuncao>();
            while (_sqlDataReader.Read())
            {
                _list.Add(new ModelTbSisFuncao(_sqlDataReader["cd_funcao"].ToString(), _sqlDataReader["descricao"].ToString(), _sqlDataReader["ativo"].ToString()));
            }
            _sqlDataReader.Close();
            return _list.ToArray();
        }
    }
}
